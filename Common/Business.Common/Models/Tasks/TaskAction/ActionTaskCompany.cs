using Business.Atributes;
using Business.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    [NumClass(63)]
    public class ActionTaskCompany : Interfases.IActionStart
    {
        private object cl_Connect;
        private Type tt;
        private string s_load = @"Load {0}. Srv: {1}, Type: {2}, Message: {3}";
        private string s_create = @"Create. Ids: {0}, Name: {1}, Message: {2}";
        private string s_update = @"Update. Id: {0}, Ids: {1}, Name: {2}, Message: {3}";
        public int NumberClass { set; get; }

        public event dIntString OnEndTask;
        public ActionTaskCompany()
        {
            string s1 = string.Format(@"http://{0}:{1}/{2}", "localhost", StaticProperty.PortBase, StaticProperty.NameScopeBase);
            tt = typeof(Interfases.IConnectMainSyncAgent);
            cl_Connect = Activator.GetObject(tt, s1);
        }
        ~ActionTaskCompany()
        {
            FileEventLog.WriteOk(string.Format("Class 'ActionTaskCompany'-{0} Disposed.", NumberClass));
        }
        /// <summary>
        /// Запуск задачи из MAIN блока
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(1)]
        public void RunTask()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            string s1 = string.Format("Class 'ActionTaskCompany'-{0}. Start checking companies and users ", NumberClass);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            //  загружаем список исходных данных
            List<Tables.Company> li_in = GetListSql(null, null);
            WriteListOdoo(null, li_in);
            sw.Stop();
            s1 = string.Format("Time: {0}, Class 'ActionTaskCompany'-{1}. End of verification of companies and users ", sw.Elapsed, NumberClass);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            if (this.OnEndTask != null)
            {
                OnEndTask.BeginInvoke(NumberClass, "", null, null);
            }
            return;
        }

        /// <summary>
        /// Запуск задачи по расписанию
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public bool RunTaskSchedule(ParamActior pa)
        {  
            bool b_end = false;
            RunTask();
            b_end = true;
            return b_end;
        }

        /// <summary>
        /// Запуск тригерной задачи
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(3)]
        public bool RunTaskTriggers(ParamActior pa)
        {
            bool b_end = false;
            return b_end;
        }

        /// <summary>
        /// создаёт полный список из всех выбранных баз инфо о банках в POHODA (SQL)
        /// </summary>
        /// <param name="Tsk"></param>
        /// <returns></returns>
        [NumFunction(4)]
        private List<Tables.Company> GetListSql(ParamActior pa, Models.Task Tsk)
        {
            List<Tables.Company> li_n = null;
            if (pa == null) li_n = GetInList(null, null, "", 0, "");
            else li_n = GetInList(pa, Tsk.ServerSource, "", 0, "");
            return li_n;
        }

        /// <summary>
        /// Загрузка списка из SQL
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">Идентификатор записи. Равно 0-весь список, не равно 0 - только указанная запись</param>
        /// <returns></returns>
        [NumFunction(5)]
        private List<Company> GetInList(ParamActior pa, Servers Srv, string NameBase, int Id, string Ico = "")
        {
            List<Servers> li_srv = Servers.GetServers(true);
            Dictionary<string, List<Company>> di_cmp_li = new Dictionary<string, List<Company>>();
            foreach (Servers _srv in li_srv)
            {
                if ((_srv.Type == TypeServers.MsSql) || (_srv.Type == TypeServers.PohodaXml))
                {

                    ResponseResult ret = (ResponseResult)tt.GetMethod("GetListCompany").Invoke(cl_Connect, new object[] { _srv, NameBase, Ico, Id });
                    if (ret.IsError)
                    {
                        string s1 = string.Format(s_load, "SQL", _srv.Name, _srv.Type, ret.Message);
                        if (pa != null) pa.Tsk.WriteMessageError(s1);
                        throw new Exception(s1);
                    }
                    List<Tables.Company> li_cmp_ret = ret.Sender as List<Tables.Company>;
                    foreach (Company cmp in li_cmp_ret)
                    {
                        if (di_cmp_li.TryGetValue(cmp.Ids, out List<Company> li_cmp))
                        {
                            li_cmp.Add(cmp);
                        }
                        else di_cmp_li.Add(cmp.Ids, new List<Company>() { cmp });
                    }
                }
            }
            Dictionary<string, User> di_user = new Dictionary<string, User>();
            Dictionary<string, int> di_user_f = new Dictionary<string, int>();
            Dictionary<string, PartnerBank> di_pb = new Dictionary<string, PartnerBank>();
            Dictionary<string, Bank> di_bank = new Dictionary<string, Bank>();
            Dictionary<string, int> di_pb_f = new Dictionary<string, int>();
            foreach (var item in di_cmp_li)
            {
                foreach (Company cmp in item.Value)
                {
                    foreach (User usr_next in cmp.CollectionUser)
                    {
                        if (di_user.TryGetValue(usr_next.Ids, out User usr_cur))
                        {
                            if (usr_cur.Partner.Name.CompareTo(usr_next.Partner.Name) != 0)
                            {
                                if (string.IsNullOrWhiteSpace(usr_next.Partner.Name)) {; }
                                else if (string.IsNullOrWhiteSpace(usr_cur.Partner.Name))
                                {
                                    usr_cur.Partner.Name = usr_next.Partner.Name;
                                }
                                else if (usr_cur.Partner.Name.Length != usr_next.Partner.Name.Length)
                                {
                                    usr_cur.Partner.Name = usr_cur.Partner.Name.Length > usr_next.Partner.Name.Length ? usr_cur.Partner.Name : usr_next.Partner.Name;
                                }
                                else {; }
                            }
                            if (usr_cur.Partner.Jmeno.CompareTo(usr_next.Partner.Jmeno) != 0)
                            {
                                if (string.IsNullOrWhiteSpace(usr_next.Partner.Jmeno)) {; }
                                else if (string.IsNullOrWhiteSpace(usr_cur.Partner.Jmeno))
                                {
                                    usr_cur.Partner.Jmeno = usr_next.Partner.Jmeno;
                                }
                                else if (usr_cur.Partner.Jmeno.Length != usr_next.Partner.Jmeno.Length)
                                {
                                    usr_cur.Partner.Jmeno = usr_cur.Partner.Jmeno.Length > usr_next.Partner.Jmeno.Length ? usr_cur.Partner.Jmeno : usr_next.Partner.Jmeno;
                                }
                                else {; }
                            }
                            if (usr_cur.Partner.Tel.CompareTo(usr_next.Partner.Tel) != 0)
                            {
                                if (string.IsNullOrWhiteSpace(usr_next.Partner.Tel)) {; }
                                else if (string.IsNullOrWhiteSpace(usr_cur.Partner.Tel))
                                {
                                    usr_cur.Partner.Tel = usr_next.Partner.Tel;
                                }
                                else if (usr_cur.Partner.Tel.Length != usr_next.Partner.Tel.Length)
                                {
                                    usr_cur.Partner.Tel = usr_cur.Partner.Tel.Length > usr_next.Partner.Tel.Length ? usr_cur.Partner.Tel : usr_next.Partner.Tel;
                                }
                                else {; }
                            }
                            if (usr_cur.Partner.Email.CompareTo(usr_next.Partner.Email) != 0)
                            {
                                if (string.IsNullOrWhiteSpace(usr_next.Partner.Email)) {; }
                                else if (string.IsNullOrWhiteSpace(usr_cur.Partner.Email))
                                {
                                    usr_cur.Partner.Email = usr_next.Partner.Email;
                                }
                                else if (usr_cur.Partner.Email.Length != usr_next.Partner.Email.Length)
                                {
                                    usr_cur.Partner.Email = usr_cur.Partner.Email.Length > usr_next.Partner.Email.Length ? usr_cur.Partner.Email : usr_next.Partner.Email;
                                }
                                else {; }
                            }
                            if (usr_cur.Partner.Remark.CompareTo(usr_next.Partner.Remark) != 0)
                            {
                                if (string.IsNullOrWhiteSpace(usr_next.Partner.Remark)) {; }
                                else if (string.IsNullOrWhiteSpace(usr_cur.Partner.Remark))
                                {
                                    usr_cur.Partner.Remark = usr_next.Partner.Remark;
                                }
                                else if (usr_cur.Partner.Remark.Length != usr_next.Partner.Remark.Length)
                                {
                                    usr_cur.Partner.Remark = usr_cur.Partner.Remark.Length > usr_next.Partner.Remark.Length ? usr_cur.Partner.Remark : usr_next.Partner.Remark;
                                }
                                else {; }
                            }
                        }
                        else
                        {
                            di_user.Add(usr_next.Ids, usr_next);
                        }
                    }
                    foreach (PartnerBank pb_next in cmp.Partner.CollectionUcet)
                    {
                        if (di_pb.TryGetValue(pb_next.Ids, out PartnerBank pb_cur))
                        {
                            if (pb_cur.Banky == null)
                            {
                                pb_cur.Banky = pb_next.Banky;
                            }
                            else if (pb_next.Banky == null) {; }
                            else
                            {
                                if (pb_cur.Banky.Name.CompareTo(pb_next.Banky.Name) != 0)
                                {
                                    if (string.IsNullOrWhiteSpace(pb_next.Banky.Name)) {; }
                                    else if (string.IsNullOrWhiteSpace(pb_cur.Banky.Name))
                                    {
                                        pb_cur.Banky.Name = pb_next.Banky.Name;
                                    }
                                    else if (pb_cur.Banky.Name.Length != pb_next.Banky.Name.Length)
                                    {
                                        pb_cur.Banky.Name = pb_cur.Banky.Name.Length > pb_next.Banky.Name.Length ? pb_cur.Banky.Name : pb_next.Banky.Name;
                                    }
                                    else {; }
                                }
                                if (pb_cur.Banky.Ids.CompareTo(pb_next.Banky.Ids) != 0)
                                {
                                    if (string.IsNullOrWhiteSpace(pb_next.Banky.Ids)) {; }
                                    else if (string.IsNullOrWhiteSpace(pb_cur.Banky.Ids))
                                    {
                                        pb_cur.Banky.Ids = pb_next.Banky.Ids;
                                    }
                                    else if (pb_cur.Banky.Ids.Length != pb_next.Banky.Ids.Length)
                                    {
                                        pb_cur.Banky.Ids = pb_cur.Banky.Ids.Length > pb_next.Banky.Ids.Length ? pb_cur.Banky.Ids : pb_next.Banky.Ids;
                                    }
                                    else {; }
                                }
                                if (pb_cur.Banky.SWIFT.CompareTo(pb_next.Banky.SWIFT) != 0)
                                {
                                    if (string.IsNullOrWhiteSpace(pb_next.Banky.SWIFT)) {; }
                                    else if (string.IsNullOrWhiteSpace(pb_cur.Banky.SWIFT))
                                    {
                                        pb_cur.Banky.SWIFT = pb_next.Banky.SWIFT;
                                    }
                                    else if (pb_cur.Banky.SWIFT.Length != pb_next.Banky.SWIFT.Length)
                                    {
                                        pb_cur.Banky.SWIFT = pb_cur.Banky.SWIFT.Length > pb_next.Banky.SWIFT.Length ? pb_cur.Banky.SWIFT : pb_next.Banky.SWIFT;
                                    }
                                    else {; }
                                }
                            }
                            if (pb_cur.Banky != null)
                            {
                                if (!di_bank.ContainsKey(pb_cur.Banky.Ids)) di_bank.Add(pb_cur.Banky.Ids, pb_cur.Banky);
                            }
                        }
                        else
                        {
                            di_pb.Add(pb_next.Ids, pb_next);
                            if (pb_next.Banky != null)
                            {
                                if (!di_bank.ContainsKey(pb_next.Banky.Ids)) di_bank.Add(pb_next.Banky.Ids, pb_next.Banky);
                            }
                        }
                    }
                }
            }
            Dictionary<string, Company> di_cmp = new Dictionary<string, Company>();
            foreach (var item in di_cmp_li)
            {
                di_user_f.Clear();
                di_pb_f.Clear();
                foreach (Company cmp in item.Value)
                {
                    for (int n1 = 0; n1 < cmp.CollectionUser.Count; n1++)
                    {
                        if(di_user.TryGetValue(cmp.CollectionUser[n1].Ids, out User usr_cur))
                        {
                            cmp.CollectionUser[n1] = usr_cur;
                        }
                    }
                    for (int n1 = 0; n1 < cmp.Partner.CollectionUcet.Count; n1++)
                    {
                        if (di_pb.TryGetValue(cmp.Partner.CollectionUcet[n1].Ids, out PartnerBank pb_cur))
                        {
                            cmp.Partner.CollectionUcet[n1] = pb_cur;
                            if (di_bank.TryGetValue(pb_cur.Banky.Ids, out Bank bn)) cmp.Partner.CollectionUcet[n1].Banky = bn;
                        }
                    }
                    if (di_cmp.TryGetValue(cmp.Ids, out Company cmp_f))
                    {
                        foreach (User usr_f in cmp.CollectionUser)
                        {
                            if (di_user_f.ContainsKey(usr_f.Ids)) continue;
                            cmp_f.CollectionUser.Add(usr_f);
                            di_user_f.Add(usr_f.Ids, 0);
                        }
                        foreach (PartnerBank pb_f in cmp.Partner.CollectionUcet)
                        {
                            if (di_pb_f.ContainsKey(pb_f.Ids)) continue;
                            cmp_f.Partner.CollectionUcet.Add(pb_f);
                            di_pb_f.Add(pb_f.Ids, 0);
                        }
                    }
                    else
                    {
                        di_cmp.Add(cmp.Ids, cmp);
                        foreach (User usr_f in cmp.CollectionUser) di_user_f.Add(usr_f.Ids, 0);
                        foreach (PartnerBank pb_f in cmp.Partner.CollectionUcet) di_pb_f.Add(pb_f.Ids, 0);
                    }
                }
            }
            return di_cmp.Values.ToList();
        }

        /// <summary>
        /// Загрузка списка из ODOO
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">Идентификатор записи. Равно 0-весь список, не равно 0 - только указанная запись</param>
        /// <returns></returns>
        [NumFunction(6)]
        private List<Tables.Company> GetInListOdoo(ParamActior pa, Servers Srv, string NameBase, int Id, string Ico = "")
        {
            ResponseResult ret = (ResponseResult)tt.GetMethod("GetListCompany").Invoke(cl_Connect, new object[] { Srv, NameBase, Ico, Id });
            if (ret.IsError)
            {
                string s1 = string.Format(s_load, "ODOO", Srv.Name, Srv.Type, ret.Message);
                if (pa != null) pa.Tsk.WriteMessageError(s1);
                throw new Exception(s1);
            }
            return ret.Sender as List<Tables.Company>;
        }

        /// <summary>
        /// Запись (создание и обновление) в ODOO (PostgreSql)
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="li_in"></param>
        [NumFunction(7)]
        private void WriteListOdoo(ParamActior pa, List<Tables.Company> li_in)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try
            {
                List<Tables.Company> li_new;
                List<Tables.Company> li_chg;
                List<Tables.Company> li_eql;
                List<Servers> li_srv = Servers.GetServers(true);
                foreach (Servers _srv in li_srv)
                {
                    if (_srv.Type == TypeServers.Odoo)
                    {
                        sw.Restart();
                        List<Tables.Company> li_out = GetInListOdoo(pa, _srv, null, 0);
                        //return;
                        Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                        string s1 = string.Format("Time: {4}, Checking - Name out: {0}, New: {1}, Chg: {2}, Eql: {3}",
                           _srv.Name, li_new.Count, li_chg.Count, li_eql.Count, sw.Elapsed);
                        if (pa != null) pa.Tsk.WriteMessageInfo(s1);
                        FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                        //  создание  
                        Tables.Company item = new Tables.Company();
                        item.Srv = _srv;   
                        item.Base = "";
                        if (li_new.Count != 0)
                        {
                            foreach (var bn in li_new)
                            {
                                bn.Srv = _srv;
                                bn.Base = "";
                            }
                            item.CollectionCompany = li_new;
                            ResponseResult ret = (ResponseResult)tt.GetMethod("CreateCompany").Invoke(cl_Connect, new object[] { item, "" });
                            if (ret.IsError)
                            {
                                s1 = string.Format(s_create, item.Ids, item.Name, ret.Message);
                                if (pa != null) pa.Tsk.WriteMessageError(s1);
                                throw new Exception(s1);
                            }
                        }
                        //  обновление
                        if (li_chg.Count != 0)
                        {
                            foreach (var bn in li_chg)
                            {
                                bn.Srv = _srv;
                                bn.Base = "";
                            }
                            item.CollectionCompany = li_chg;
                            ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateCompany").Invoke(cl_Connect, new object[] { item, "" });
                            if (ret.IsError)
                            {
                                s1 = string.Format(s_update, item.Id, item.Ids, item.Name, ret.Message);
                                if (pa != null) pa.Tsk.WriteMessageError(s1);
                                throw new Exception(s1);
                            }
                        }
                        s1 = string.Format("Time: {1}, Checking end - Name out: {0}", _srv.Name, sw.Elapsed);
                        if (pa != null) pa.Tsk.WriteMessageInfo(s1);
                        FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                sw?.Stop();
            }
        }

        /// <summary>
        /// Сравниваем списки source-Company и receiver-Company и составляем list для NEW, Change и Equals
        /// </summary>
        /// <param name="li_in">source-Company</param>
        /// <param name="li_out">receiver-Company</param>
        /// <param name="IsFull">True - сравнение по всем полям, false - только по ключу (IDS)</param>
        [NumFunction(8)]
        private void Compare(List<Tables.Company> li_in, List<Tables.Company> li_out,
            out List<Tables.Company> li_new, out List<Tables.Company> li_chg, out List<Tables.Company> li_eql,
            bool IsFull = false)
        {
            li_new = new List<Tables.Company>();
            li_chg = new List<Tables.Company>();
            li_eql = new List<Tables.Company>();
            for (int n1 = li_in.Count - 1; n1 >= 0; n1--)
            {
                bool IsNew = true;
                Tables.Company bn_in = li_in[n1];
                for (int n2 = li_out.Count - 1; n2 >= 0; n2--)
                {
                    Tables.Company bn_out = li_out[n2];
                    int m1 = bn_in.Ids.CompareTo(bn_out.Ids);
                    if (m1 == 0)        //  основные параметры Ids - равны 
                    {
                        if (IsFull)
                        {
                            int b1 = TestCompare(bn_in, bn_out);
                            int b2 = TestCompareUcet(bn_in, bn_out);
                            int b3 = TestCompareUser(bn_in, bn_out);
                            if ((b1 == 0) && (b2 == 0) && (b3 == 0))
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
                                bn_out.Ids = bn_in.Ids;
                                bn_out.Name = bn_in.Name;
                                bn_out.Currency = bn_in.Currency;
                                int m3 = bn_out.Partner.Id;
                                bn_out.Partner = bn_in.Partner;
                                bn_out.Partner.Id = m3;
                                bn_out.CollectionUser = bn_in.CollectionUser;
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
                    Tables.Company bn_out = new Tables.Company();
                    bn_out.Ids = bn_in.Ids;
                    bn_out.Name = bn_in.Name;
                    bn_out.Currency = bn_in.Currency;
                    bn_out.Partner = bn_in.Partner;
                    bn_out.CollectionUser = bn_in.CollectionUser;
                    li_new.Add(bn_out);
                }
            }
        }

        private int TestCompare(Tables.Company bn_in, Tables.Company bn_out)
        {
            int n1 = 0;
            if (bn_in.Name.CompareTo(bn_out.Name) != 0) n1 = 1;
            else if (bn_in.Partner.DIC.CompareTo(bn_out.Partner.DIC) != 0) n1 = 2;
            else if (bn_in.Partner.Jmeno.CompareTo(bn_out.Partner.Jmeno) != 0) n1 = 3;
            else if (bn_in.Partner.Ulice.CompareTo(bn_out.Partner.Ulice) != 0) n1 = 4;
            else if (bn_in.Partner.Obec.CompareTo(bn_out.Partner.Obec) != 0) n1 = 5;
            else if (bn_in.Partner.Psc.CompareTo(bn_out.Partner.Psc) != 0) n1 = 6;
            else if (bn_in.Partner.Tel.CompareTo(bn_out.Partner.Tel) != 0) n1 = 7;
            else if (bn_in.Partner.Email.CompareTo(bn_out.Partner.Email) != 0) n1 = 8;
            else if (string.IsNullOrWhiteSpace(bn_in.Partner.Www) && !string.IsNullOrWhiteSpace(bn_out.Partner.Www)) n1 = 9;
            else if (!string.IsNullOrWhiteSpace(bn_in.Partner.Www) && string.IsNullOrWhiteSpace(bn_out.Partner.Www)) n1 = 10;
            else if (!string.IsNullOrWhiteSpace(bn_in.Partner.Www) && !string.IsNullOrWhiteSpace(bn_out.Partner.Www))
            {
                if (bn_in.Partner.Www.ToLower().Trim().IndexOf(bn_out.Partner.Www.ToLower().Trim()) < 0)
                {
                    if (bn_out.Partner.Www.ToLower().Trim().IndexOf(bn_in.Partner.Www.ToLower().Trim()) < 0)
                    {
                        n1 = 11;
                    }
                }
            }
            return n1;
        }
        private int TestCompareUcet(Tables.Company bn_in, Tables.Company bn_out)
        {
            int n1 = 0;
            if ((bn_in.Partner.CollectionUcet.Count == 0) && (bn_out.Partner.CollectionUcet.Count == 0)) {; }
            else if ((bn_in.Partner.CollectionUcet.Count != 0) && (bn_out.Partner.CollectionUcet.Count == 0)) n1 = 51;
            else if ((bn_in.Partner.CollectionUcet.Count == 0) && (bn_out.Partner.CollectionUcet.Count != 0)) { n1 = 52; }
            else if (bn_in.Partner.CollectionUcet.Count != bn_out.Partner.CollectionUcet.Count) n1 = 53;
            else                   // if ((bn_in.CollectionUcet.Count != 0) && (bn_out.CollectionUcet.Count != 0))
            {
                foreach (var itemIn in bn_in.Partner.CollectionUcet)
                {
                    bool b1 = true;
                    foreach (var itemOut in bn_out.Partner.CollectionUcet)
                    {
                        if (DelSpace(itemIn.Ids).CompareTo(DelSpace(itemOut.Ids)) != 0) continue;
                        if (itemIn.Banky != null && itemOut.Banky == null) continue;
                        if (itemIn.Banky == null && itemOut.Banky != null) continue;
                        if (itemIn.Banky != null && itemOut.Banky != null)
                        {
                            if (itemIn.Banky.Ids.CompareTo(itemOut.Banky.Ids) != 0) continue;
                            if (itemIn.Banky.SWIFT.CompareTo(itemOut.Banky.SWIFT) != 0) continue;
                            if (itemIn.Banky.Name.CompareTo(itemOut.Banky.Name) != 0) continue;
                        }
                        b1 = false;
                        break;
                    }
                    if (b1)
                    {
                        n1 = 54;
                        break;
                    }
                }
            }
            return n1;
        }
        private int TestCompareUser(Tables.Company bn_in, Tables.Company bn_out)
        {
            int n1 = 0;
            foreach (var itemIn in bn_in.CollectionUser)
            {
                bool b1 = true;
                foreach (var itemOut in bn_out.CollectionUser)
                {
                    if (DelSpace(itemIn.Ids).CompareTo(DelSpace(itemOut.Ids)) != 0) continue;
                    if (itemIn.Partner.Name != null && itemOut.Partner.Name == null) continue;
                    if (itemIn.Partner.Jmeno == null && itemOut.Partner.Jmeno != null) continue;
                    if (itemIn.Partner.Tel.CompareTo(itemOut.Partner.Tel) != 0) continue;
                    if (itemIn.Partner.Email.CompareTo(itemOut.Partner.Email) != 0) continue;
                    if (itemIn.Partner.Remark.CompareTo(itemOut.Partner.Remark) != 0) continue;
                    b1 = false;
                    break;
                }
                if (b1)
                {
                    n1 = 74;
                    break;
                }
            }
            return n1;
        }
        private string DelSpace(string Value)
        {
            string s1 = "";
            for (int n1 = 0; n1 < Value.Length; n1++)
            {
                if (Value[n1] == ' ') continue;
                s1 += Value[n1];
            }
            return s1;
        }
    }
}
