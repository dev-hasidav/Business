using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Atributes;

namespace Business.Models.Tasks.TaskAction
{
    [NumClass(67)]
    public class ActionTaskObjednalky : Interfases.IActionStart
    {
        private object cl_Connect;
        private Type tt;
        private string s_load = @"Load. Srv: {0}, Base: {1}, Id: {2}, Ico: {3}";
        private string s_create = @"Create. Ids: {0}, Name: {1}, Message: {2}";
        private string s_update = @"Update. Id: {0}, Ids: {1}, Name: {2}, Message: {3}";
        public ActionTaskObjednalky()
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
            List<Tables.Objednalky> li_in = null;
            //  загружаем список исходных данных
            switch (pa.Tsk.ServerSource.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    li_in = GetListSql(pa);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    li_in = GetInList(pa, pa.Tsk.ServerSource, null, 0);
                    break;
            }
            // 
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
            List<Tables.Objednalky> li_in = GetInList(pa, pa.Tsk.ServerSource, pa.retSql.NameBase, pa.retSql.IdRecord);

            switch (pa.Tsk.ServerReceiver.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    //WriteListSql(pa, li_in);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    //WriteListOdoo(pa, li_in);
                    break;
            }

            b_end = true;
            return b_end;
        }


        /// <summary>
        /// создаёт полный список из всех выбранных баз инфо о банках в POHODA (SQL)
        /// </summary>
        /// <param name="Tsk"></param>
        /// <returns></returns>
        [NumFunction(3)]
        private List<Tables.Objednalky> GetListSql(ParamActior pa)
        {
            List<Tables.Objednalky> li = new List<Tables.Objednalky>();
            Dictionary<string, Tables.Objednalky> di = new Dictionary<string, Tables.Objednalky>();
            foreach (InfoBasePohoda ibp in pa.Tsk.Param.CollectionBaseSource)
            {
                List<Tables.Objednalky> li_n = GetInList(pa, pa.Tsk.ServerSource, ibp.Soubor, 0);
                foreach (Tables.Objednalky bn in li_n)
                {
                    if (string.IsNullOrWhiteSpace(bn.Ids)) continue;
                    if (!di.ContainsKey(bn.Ids))
                    {
                        di.Add(bn.Ids, bn);
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
        private void WriteListSql(ParamActior pa, List<Tables.Objednalky> li_in)
        {
            foreach (InfoBasePohoda ibp in pa.Tsk.Param.CollectionBaseReceiver)
            {
                List<Tables.Objednalky> li_out = GetInList(pa, pa.Tsk.ServerReceiver, ibp.Soubor, 0, ibp.ICO);
                List<Tables.Objednalky> li_new;
                List<Tables.Objednalky> li_chg;
                List<Tables.Objednalky> li_eql;

                Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                string s1 = string.Format("({0:n0}:{1}) Task: {2}, Base: {6}, New: {3}, Chg: {4}, Eql: {5} ",
                   pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count, ibp.Soubor);
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                //  создание
                Tables.Objednalky item = new Tables.Objednalky();
                item.Srv = pa.Tsk.ServerReceiver;
                item.Base = ibp.Soubor;
                if (li_new.Count != 0)
                {
                    foreach (var bn in li_new)
                    {
                        bn.Srv = pa.Tsk.ServerReceiver;
                        bn.Base = ibp.Soubor;
                    }
                    item.CollectionObjednalky = li_new;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("CreateZakazka").Invoke(cl_Connect, new object[] { item, ibp.ICO });
                    if (ret.IsError)
                    {
                        pa.Tsk.WriteMessageError(string.Format(s_create, item.Id, item.Ids, item.Name, ret.Message));
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
                    item.CollectionObjednalky = li_chg;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateZakazka").Invoke(cl_Connect, new object[] { item, ibp.ICO });
                    if (ret.IsError)
                    {
                        pa.Tsk.WriteMessageError(string.Format(s_update, item.Id, item.Ids, item.Name, ret.Message));
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
        private void WriteListOdoo(ParamActior pa, List<Tables.Objednalky> li_in)
        {
            List<Tables.Objednalky> li_out = GetInList(pa, pa.Tsk.ServerReceiver, null, 0);
            List<Tables.Objednalky> li_new;
            List<Tables.Objednalky> li_chg;
            List<Tables.Objednalky> li_eql;

            Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

            string s1 = string.Format("({0:n0}:{1}) Task: {2}, New: {3}, Chg: {4}, Eql: {5} ",
               pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count);
            pa.Tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());

            return;

            //  создание  
            Tables.Objednalky item = new Tables.Objednalky();
            item.Srv = pa.Tsk.ServerReceiver;
            item.Base = "";
            if (li_new.Count != 0)
            {
                foreach (var bn in li_new)
                {
                    bn.Srv = pa.Tsk.ServerReceiver;
                    bn.Base = "";
                }
                item.CollectionObjednalky = li_new;
                ResponseResult ret = (ResponseResult)tt.GetMethod("CreateZakazka").Invoke(cl_Connect, new object[] { item, "" });
                if (ret.IsError)
                {
                    pa.Tsk.WriteMessageError(string.Format(s_create, item.Ids, item.Name, ret.Message));
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
                item.CollectionObjednalky = li_chg;
                ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateZakazka").Invoke(cl_Connect, new object[] { item, "" });
                if (ret.IsError)
                {
                    pa.Tsk.WriteMessageError(string.Format(s_update, item.Id, item.Ids, item.Name, ret.Message));
                }
            }
        }

        /// <summary>
        /// Загрузка списка илм 1 записи банка из указанной базы
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">Идентификатор записи. Равно 0-весь список, не равно 0 - только указанная запись</param>
        /// <returns></returns>
        [NumFunction(6)]
        private List<Tables.Objednalky> GetInList(ParamActior pa, Servers Srv, string NameBase, int Id, string Ico = null)
        {
            if (string.IsNullOrWhiteSpace(Ico))
            {
                if (!string.IsNullOrWhiteSpace(NameBase))
                {
                    string[] ss = NameBase.Split(new char[] { '_' });
                    if (ss.Length == 3) Ico = ss[1];
                }
            }
            ResponseResult ret = (ResponseResult)tt.GetMethod("GetListObjednalky").Invoke(cl_Connect, new object[] { Srv, NameBase, Ico, Id });
            if (ret.IsError)
            {
                pa.Tsk.WriteMessageError(string.Format(s_load, Srv.Name, NameBase, Id, Ico));
                throw new Exception(ret.Message);
            }
            return ret.Sender as List<Tables.Objednalky>;
        }

        /// <summary>
        /// Сравниваем списки source-Zakazka и receiver-Zakazka и составляем list для NEW, Change и Equals
        /// </summary>
        /// <param name="li_in">source-Zakazka</param>
        /// <param name="li_out">receiver-Zakazka</param>
        /// <param name="IsFull">True - сравнение по всем полям, false - только по ключу (IDS)</param>
        [NumFunction(7)]
        private void Compare(List<Tables.Objednalky> li_in, List<Tables.Objednalky> li_out,
            out List<Tables.Objednalky> li_new, out List<Tables.Objednalky> li_chg, out List<Tables.Objednalky> li_eql,
            bool IsFull = false)
        {
            li_new = new List<Tables.Objednalky>();
            li_chg = new List<Tables.Objednalky>();
            li_eql = new List<Tables.Objednalky>();
            for (int n1 = li_in.Count - 1; n1 >= 0; n1--)
            {
                bool IsNew = true;
                Tables.Objednalky bn_in = li_in[n1];
                for (int n2 = li_out.Count - 1; n2 >= 0; n2--)
                {
                    Tables.Objednalky bn_out = li_out[n2];
                    int m1 = bn_in.Ids.CompareTo(bn_out.Ids);
                    if (m1 == 0)        //  основные параметры Ids - равны 
                    {
                        if (IsFull)
                        {
                            int b1 = TestCompare(bn_in, bn_out);
                            if (b1 == 0)
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
                                //bn_out.Remark = bn_in.Remark;
                                //bn_out.IdPartner = bn_in.IdPartner;
                                //bn_out.Partner = bn_in.Partner;
                                //bn_out.IdManager = bn_in.IdManager;
                                //bn_out.Manager = bn_in.Manager;
                                //bn_out.Status = bn_in.Status;
                                //bn_out.DatesStatus = bn_in.DatesStatus;
                                bn_out.Active = bn_in.Active;
                                //bn_out.Polizkys = bn_in.Polizkys;
                                li_chg.Add(bn_out);
                                IsNew = false;
                                break;
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
                    Tables.Objednalky bn_out = new Tables.Objednalky();
                    bn_out.Name = bn_in.Name;
                    //bn_out.Remark = bn_in.Remark;
                    //bn_out.IdPartner = bn_in.IdPartner;
                    //bn_out.Partner = bn_in.Partner;
                    //bn_out.IdManager = bn_in.IdManager;
                    //bn_out.Manager = bn_in.Manager;
                    //bn_out.Status = bn_in.Status;
                    //bn_out.DatesStatus = bn_in.DatesStatus;
                    bn_out.Active = bn_in.Active;
                    //bn_out.Polizkys = bn_in.Polizkys;
                    //li_new.Add(bn_out);
                }
            }
        }

        private int TestCompare(Tables.Objednalky bn_in, Tables.Objednalky bn_out)
        {
            int n1 = 0;
            //if (bn_in.AccessToken.CompareTo(bn_out.AccessToken) != 0)
            //{
            //    n1 = 1;
            //}
            if (bn_in.Name.CompareTo(bn_out.Name) != 0)
            {
                n1 = 2;
            }
            //else if (bn_in.Remark.CompareTo(bn_out.Remark) != 0)
            //{
            //    n1 = 3;
            //}
            //else if (bn_in.IdPartner != bn_out.IdPartner)
            //{
            //    n1 = 4;
            //}
            //else if (bn_in.IdManager != bn_out.IdManager)
            //{
            //    n1 = 5;
            //}
            //else if (bn_in.Status.StatusP != bn_out.Status.StatusP)
            //{
            //    n1 = 6;
            //}
            //else if (bn_in.ConfirmationDate != bn_out.ConfirmationDate)
            //{
            //    n1 = 7;
            //}
            //else if (bn_in.CommitmentDate != bn_out.CommitmentDate)
            //{
            //    n1 = 8;
            //}
            //else if (bn_in.Email.CompareTo(bn_out.Email) != 0)
            //{
            //    n1 = 9;
            //}
            //else if (bn_in.Www.CompareTo(bn_out.Www) != 0)
            //{
            //    n1 = 10;
            //}
            //else if (bn_in.Remark.CompareTo(bn_out.Remark) != 0)
            //{
            //    n1 = 11;
            //}
            //else if (bn_in.Country.CompareTo(bn_out.Country) != 0)
            //{
            //    n1 = 12;
            //}
            //else if (bn_in.Active != bn_out.Active)
            //{
            //    n1 = 13;
            //}
            return n1;
        }
    }
}
