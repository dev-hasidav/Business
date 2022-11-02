using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    [NumClass(64)]
    public class ActionTaskUser : Interfases.IActionStart
    {
        private object cl_Connect;
        private Type tt;
        private string s_load = @"Load. Srv: {0}, Base: {1}, Id: {2}, Ico: {3}";
        private string s_create = @"Create. Ids: {0}, Name: {1}, Message: {2}";
        private string s_update = @"Update. Id: {0}, Ids: {1}, Name: {2}, Message: {3}";
        public ActionTaskUser()
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
            List<Tables.User> li_in = null;
            //  загружаем список исходных данных
            switch (pa.Tsk.ServerSource.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    li_in = GetListSql(pa, pa.Tsk);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    li_in = GetInList(pa, pa.Tsk.ServerSource, null, 0);
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
            List<Tables.User> li_in = GetInList(pa, pa.Tsk.ServerSource, pa.retSql.NameBase, pa.retSql.IdRecord);

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
        /// создаёт полный список из всех выбранных баз инфо о банках в POHODA (SQL)
        /// </summary>
        /// <param name="Tsk"></param>
        /// <returns></returns>
        [NumFunction(3)]
        private List<Tables.User> GetListSql(ParamActior pa, Models.Task Tsk)
        {
            List<Tables.User> li = new List<Tables.User>();
            Dictionary<string, Tables.User> di = new Dictionary<string, Tables.User>();
            foreach (InfoBasePohoda ibp in Tsk.Param.CollectionBaseSource)
            {
                List<Tables.User> li_n = GetInList(pa, Tsk.ServerSource, ibp.Soubor, 0, ibp.ICO);
                foreach (Tables.User bn in li_n)
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
        private void WriteListSql(ParamActior pa, List<Tables.User> li_in)
        {
            try
            {
                foreach (InfoBasePohoda ibp in pa.Tsk.Param.CollectionBaseReceiver)
                {
                    List<Tables.User> li_out = GetInList(pa, pa.Tsk.ServerReceiver, ibp.Soubor, 0, ibp.ICO);
                    List<Tables.User> li_new;
                    List<Tables.User> li_chg;
                    List<Tables.User> li_eql;

                    Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                    string s1 = string.Format("({0:n0}:{1}) Task: {2}, Base: {6}, New: {3}, Chg: {4}, Eql: {5} ",
                       pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count, ibp.Soubor);
                    pa.Tsk.WriteMessageInfo(s1);
                    FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    //  создание
                    Tables.User item = new Tables.User();
                    item.Srv = pa.Tsk.ServerReceiver;
                    item.Base = ibp.Soubor;
                    if (li_new.Count != 0)
                    {
                        foreach (var bn in li_new)
                        {
                            bn.Srv = pa.Tsk.ServerReceiver;
                            bn.Base = ibp.Soubor;
                        }
                        item.CollectionUser = li_new;
                        ResponseResult ret = (ResponseResult)tt.GetMethod("CreateUser").Invoke(cl_Connect, new object[] { item, ibp.ICO });
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
                            bn.Base = ibp.Soubor;
                        }
                        item.CollectionUser = li_chg;
                        ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateUser").Invoke(cl_Connect, new object[] { item, ibp.ICO });
                        if (ret.IsError)
                        {
                            pa.Tsk.WriteMessageError(string.Format(s_update, item.Id, item.Ids, item.Name, ret.Message));
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        /// <summary>
        /// Запись (создание и обновление) в ODOO (PostgreSql)
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="li_in"></param>
        [NumFunction(5)]
        private void WriteListOdoo(ParamActior pa, List<Tables.User> li_in)
        {
            try
            {
                List<Tables.User> li_out = GetInList(pa, pa.Tsk.ServerReceiver, null, 0);
                List<Tables.User> li_new;
                List<Tables.User> li_chg;
                List<Tables.User> li_eql;

                Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                string s1 = string.Format("({0:n0}:{1}) Task: {2}, New: {3}, Chg: {4}, Eql: {5} ",
                   pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count);
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                //  создание  
                Tables.User item = new Tables.User();
                item.Srv = pa.Tsk.ServerReceiver;
                item.Base = "";
                if (li_new.Count != 0)
                {
                    foreach (var bn in li_new)
                    {
                        bn.Srv = pa.Tsk.ServerReceiver;
                        bn.Base = "";
                    }
                    item.CollectionUser = li_new;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("CreateUser").Invoke(cl_Connect, new object[] { item, "" });
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
                    item.CollectionUser = li_chg;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateUser").Invoke(cl_Connect, new object[] { item, "" });
                    if (ret.IsError)
                    {
                        pa.Tsk.WriteMessageError(string.Format(s_update, item.Id, item.Ids, item.Name, ret.Message));
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        /// <summary>
        /// Загрузка списка илм 1 записи партнёра из указанной базы
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">Идентификатор записи. Равно 0-весь список, не равно 0 - только указанная запись</param>
        /// <returns></returns>
        [NumFunction(6)]
        private List<Tables.User> GetInList(ParamActior pa, Servers Srv, string NameBase, int Id, string Ico = "")
        {
            if (string.IsNullOrWhiteSpace(Ico))
            {
                if (!string.IsNullOrWhiteSpace(NameBase))
                {
                    string[] ss = NameBase.Split(new char[] { '_' });
                    if (ss.Length == 3) Ico = ss[1];
                }
                else
                {
                    NameBase = "";
                }
            }
            ResponseResult ret = (ResponseResult)tt.GetMethod("GetListUser").Invoke(cl_Connect, new object[] { Srv, NameBase, Ico, Id });
            if (ret.IsError)
            {
                pa.Tsk.WriteMessageError(string.Format(s_load, Srv.Name, NameBase, Id, Ico));
                throw new Exception(ret.Message);
            }
            return ret.Sender as List<Tables.User>;
        }

        /// <summary>
        /// Сравниваем списки source-User и receiver-User и составляем list для NEW, Change и Equals
        /// </summary>
        /// <param name="li_in">source-User</param>
        /// <param name="li_out">receiver-User</param>
        /// <param name="IsFull">True - сравнение по всем полям, false - только по ключу (IDS)</param>
        [NumFunction(7)]
        private void Compare(List<Tables.User> li_in, List<Tables.User> li_out,
            out List<Tables.User> li_new, out List<Tables.User> li_chg, out List<Tables.User> li_eql,
            bool IsFull = false)
        {
            li_new = new List<Tables.User>();
            li_chg = new List<Tables.User>();
            li_eql = new List<Tables.User>();
            for (int n1 = li_in.Count - 1; n1 >= 0; n1--)
            {
                bool IsNew = true;
                Tables.User bn_in = li_in[n1];
                for (int n2 = li_out.Count - 1; n2 >= 0; n2--)
                {
                    Tables.User bn_out = li_out[n2];
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
                                //bn_out.Name = bn_in.Name;
                                //bn_out.CompanyIco = bn_in.CompanyIco;
                                //bn_out.Partner = bn_in.Partner;
                                //bn_out.Tel = bn_in.Partner.Tel;
                                //bn_out.Email = bn_in.Partner.Email;
                                //bn_out.Pozn = bn_in.Partner.Remark;
                                //li_chg.Add(bn_out);
                                //IsNew = false;
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
                    Tables.User bn_out = new Tables.User();
                    //bn_out.Ids = bn_in.Ids;
                    //bn_out.Name = bn_in.Name;
                    //bn_out.CompanyIco = bn_in.CompanyIco;
                    //bn_out.Partner = bn_in.Partner;
                    //bn_out.Tel = bn_in.Partner.Tel;
                    //bn_out.Email = bn_in.Partner.Email;
                    //bn_out.Pozn = bn_in.Partner.Remark;
                    li_new.Add(bn_out);
                }
            }
        }

        private int TestCompare(Tables.User bn_in, Tables.User bn_out)
        {
            int n1 = 0;
            if (bn_in.Name.CompareTo(bn_out.Name) != 0) n1 = 1;
            return n1;
        }
    }
}
