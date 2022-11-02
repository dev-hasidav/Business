using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    /// <summary>
    /// ЗАДАЧА --  Синхронизация валюты
    /// </summary>
    [NumClass(45)]
    class ActionTaskCurrency : Interfases.IActionStart
    {
        private object cl_Connect;
        private Type tt;
        private string s2 = @"Create. Ids: {0}, Name: {1}, Message: {2}";
        private string s3 = @"Update. Id: {0}, Ids: {1}, Name: {2}, Message: {3}";
        public ActionTaskCurrency()
        {
            string s1 = string.Format(@"http://{0}:{1}/{2}", "localhost", StaticProperty.PortBase, StaticProperty.NameScopeBase);
            tt = typeof(Interfases.IConnectMainSyncAgent);
            cl_Connect = Activator.GetObject(tt, s1);
        }

        /// <summary>
        /// Запуск задачи по расписанию
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(1)]
        public bool RunTaskSchedule(ParamActior pa)
        {
            bool b_end = false;
            List<Tables.Currency> li_in = null;
            //  загружаем список исходных данных
            switch (pa.Tsk.ServerSource.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    li_in = GetListSql(pa.Tsk);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    li_in = GetInList(pa.Tsk.ServerSource, null, 0);
                    break;
            }

            switch (pa.Tsk.ServerReceiver.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    WriteListSql(pa, li_in);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    WriteListOdoo(pa, li_in);
                    break;
            }
            b_end = true;
            return b_end;
        }

        /// <summary>
        /// Запуск тригерной задачи
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public bool RunTaskTriggers(ParamActior pa)
        {
            bool b_end = false;
            List<Tables.Currency> li_in = GetInList(pa.Tsk.ServerSource, pa.retSql.NameBase, pa.retSql.IdRecord);

            switch (pa.Tsk.ServerReceiver.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    WriteListSql(pa, li_in);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    WriteListOdoo(pa, li_in);
                    break;
            }

            b_end = true;
            return b_end;
        }

        /// <summary>
        /// создаёт полный список из всех выбранных баз инфо о валюте в POHODA (SQL)
        /// </summary>
        /// <param name="Tsk"></param>
        /// <returns></returns>
        [NumFunction(3)]
        private List<Tables.Currency> GetListSql(Models.Task Tsk)
        {
            List<Tables.Currency> li = new List<Tables.Currency>();
            Dictionary<string, Tables.Currency> di = new Dictionary<string, Tables.Currency>();
            foreach (InfoBasePohoda ibp in Tsk.Param.CollectionBaseSource)
            {
                List<Tables.Currency> li_n = GetInList(Tsk.ServerSource, ibp.Soubor, 0);
                foreach (Tables.Currency bn in li_n)
                {
                    if (string.IsNullOrWhiteSpace(bn.Name)) continue;
                    if (!di.ContainsKey(bn.Name))
                    {
                        di.Add(bn.Name, bn);
                    }
                }
            }
            foreach (var item in di)
            {
                li.Add(item.Value);
            }
            return li;
        }

        /// <summary>
        /// Запись (создание и обновление) в POHODA (SQL)
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="li_in"></param>
        [NumFunction(4)]
        private void WriteListSql(ParamActior pa, List<Tables.Currency> li_in)
        {
            foreach (InfoBasePohoda ibp in pa.Tsk.Param.CollectionBaseReceiver)
            {
                List<Tables.Currency> li_out = GetInList(pa.Tsk.ServerReceiver, ibp.Soubor, 0);
                List<Tables.Currency> li_new;
                List<Tables.Currency> li_chg;
                List<Tables.Currency> li_eql;

                Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                string s1 = string.Format("({0:n0}:{1}) Task: {2}, Base: {6}, New: {3}, Chg: {4}, Eql: {5} ",
                   pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count, ibp.Soubor);
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                //  создание
                Tables.Currency item = new Tables.Currency();
                item.Srv = pa.Tsk.ServerReceiver;
                item.Base = ibp.Soubor;
                if (li_new.Count != 0)
                {
                    foreach (var bn in li_new)
                    {
                        bn.Srv = pa.Tsk.ServerReceiver;
                        bn.Base = ibp.Soubor;
                    }
                    item.CollectionCurrency = li_new;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("CreateCurrency").Invoke(cl_Connect, new object[] { item });
                    if (ret.IsError)
                    {
                        pa.Tsk.WriteMessageError(string.Format(s2, item.Ids, item.Name, ret.Message));
                    }
                }
                //  обновление
                if (li_chg.Count != 0)
                {
                    foreach (var bn in li_chg)
                    {
                        bn.Srv = pa.Tsk.ServerReceiver;
                        bn.Base = ibp.Soubor;
                    }
                    item.CollectionCurrency = li_chg;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateCurrency").Invoke(cl_Connect, new object[] { item });
                    if (ret.IsError)
                    {
                        pa.Tsk.WriteMessageError(string.Format(s3, item.Id, item.Ids, item.Name, ret.Message));
                    }
                }
            }
        }

        /// <summary>
        /// Запись (создание и обновление) в ODOO (PostgreSql)
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="li_in"></param>
        [NumFunction(5)]
        private void WriteListOdoo(ParamActior pa, List<Tables.Currency> li_in)
        {
            List<Tables.Currency> li_out = GetInList(pa.Tsk.ServerReceiver, null, 0);
            List<Tables.Currency> li_new;
            List<Tables.Currency> li_chg;
            List<Tables.Currency> li_eql;

            Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

            string s1 = string.Format("({0:n0}:{1}) Task: {2}, New: {3}, Chg: {4}, Eql: {5} ",
               pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count);
            pa.Tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            //  создание  
            Tables.Currency item = new Tables.Currency();
            item.Srv = pa.Tsk.ServerReceiver;
            item.Base = "";
            if (li_new.Count != 0)
            {
                foreach (var bn in li_new)
                {
                    bn.Srv = pa.Tsk.ServerReceiver;
                    bn.Base = "";
                }
                item.CollectionCurrency = li_new;
                ResponseResult ret = (ResponseResult)tt.GetMethod("CreateCurrency").Invoke(cl_Connect, new object[] { item });
                if (ret.IsError)
                {
                    pa.Tsk.WriteMessageError(string.Format(s2, item.Ids, item.Name, ret.Message));
                }
            }
            //  обновление
            if (li_chg.Count != 0)
            {
                foreach (var bn in li_chg)
                {
                    bn.Srv = pa.Tsk.ServerReceiver;
                    bn.Base = "";
                }
                item.CollectionCurrency = li_chg;
                ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateCurrency").Invoke(cl_Connect, new object[] { item });
                if (ret.IsError)
                {
                    pa.Tsk.WriteMessageError(string.Format(s3, item.Id, item.Ids, item.Name, ret.Message));
                }
            }
        }

        /// <summary>
        /// Загрузка списка илм 1 записи валюте из указанной базы
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">Идентификатор записи. Равно 0-весь список, не равно 0 - только указанная запись</param>
        /// <returns></returns>
        [NumFunction(6)]
        private List<Tables.Currency> GetInList(Servers Srv, string NameBase, int Id)
        {
            ResponseResult ret = (ResponseResult)tt.GetMethod("GetListCurrency").Invoke(cl_Connect, new object[] { Srv, NameBase, Id });
            if (ret.IsError)
            {
                throw new Exception(ret.Message);
            }
            return ret.Sender as List<Tables.Currency>;
        }

        /// <summary>
        /// Сравниваем списки source-валюте и receiver-валюте и составляем list для NEW, Change и Equals
        /// </summary>
        /// <param name="li_in">source-bank</param>
        /// <param name="li_out">receiver-bank</param>
        /// <param name="IsFull">True - сравнение по всем полям, false - только по ключу (IDS)</param>
        [NumFunction(7)]
        private void Compare(List<Tables.Currency> li_in, List<Tables.Currency> li_out,
            out List<Tables.Currency> li_new, out List<Tables.Currency> li_chg, out List<Tables.Currency> li_eql,
            bool IsFull = false)
        {
            li_new = new List<Tables.Currency>();
            li_chg = new List<Tables.Currency>();
            li_eql = new List<Tables.Currency>();
            for (int n1 = li_in.Count - 1; n1 >= 0; n1--)
            {
                bool IsNew = true;
                Tables.Currency bn_in = li_in[n1];
                for (int n2 = li_out.Count - 1; n2 >= 0; n2--)
                {
                    Tables.Currency bn_out = li_out[n2];
                    int m1 = bn_in.Name.CompareTo(bn_out.Name);
                    if (m1 == 0)        //  основные параметры Ids - равны 
                    {
                        if (IsFull)
                        {
                            if ((bn_in.Active == bn_out.Active) && (bn_in.Mnozstvi == bn_out.Mnozstvi) &&
                                (bn_in.Zeme.ToLower().Trim().CompareTo(bn_out.Zeme.ToLower().Trim()) == 0))
                            {
                                //  все РАВНО
                                li_out.Remove(bn_out);
                                li_eql.Add(bn_out);
                                IsNew = false;
                                break;
                            }
                            else
                            {
                                //  ids-равно в остальных полях есть расхождения
                                li_out.Remove(bn_out);
                                bn_out.Name = bn_in.Name;
                                bn_out.Ids = string.IsNullOrWhiteSpace(bn_in.Ids) ?
                                    bn_out.Ids.IndexOf("?") >= 0 ? "?" : bn_out.Ids :
                                    bn_in.Ids.IndexOf("?") >= 0 ? "?" : bn_in.Ids;
                                bn_out.Mnozstvi = bn_in.Mnozstvi;
                                bn_out.Zeme = bn_in.Zeme;
                                bn_out.Active = bn_in.Active;
                                li_chg.Add(bn_out);
                                IsNew = false;
                            }
                        }
                        else
                        {
                            //  равно только ids, остальное НЕ проверяем
                            li_out.Remove(bn_out);
                            li_eql.Add(bn_out);
                            IsNew = false;
                            break;
                        }
                    }
                }
                if (IsNew)
                {
                    //li_in.Remove(bn_in);
                    Tables.Currency bn_out = new Tables.Currency();
                    bn_out.Name = bn_in.Name;
                    bn_out.Ids = string.IsNullOrWhiteSpace(bn_in.Ids) ?
                                    bn_out.Ids.IndexOf("?") >= 0 ? "?" : bn_out.Ids :
                                    bn_in.Ids.IndexOf("?") >= 0 ? "?" : bn_in.Ids;
                    bn_out.Mnozstvi = bn_in.Mnozstvi;
                    bn_out.Zeme = bn_in.Zeme;
                    bn_out.Active = bn_in.Active;
                    li_new.Add(bn_out);
                }
            }
        }
    }
}
