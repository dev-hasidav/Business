using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    /// <summary>
    /// ЗАДАЧА --  Синхронизация партнёров (контрагентов)
    /// </summary>
    [NumClass(47)]
    public class ActionTaskPartner : Interfases.IActionStart
    {
        private object cl_Connect;
        private Type tt;
        private string s_load = @"Load. Srv: {0}, Base: {1}, Id: {2}, Ico: {3}";
        private string s_create = @"Create. Ids: {0}, Name: {1}, Message: {2}";
        private string s_update = @"Update. Id: {0}, Ids: {1}, Name: {2}, Message: {3}";
        public ActionTaskPartner()
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
            List<Tables.Partner> li_in = null;
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
            List<Tables.Partner> li_in = GetInList(pa, pa.Tsk.ServerSource, pa.retSql.NameBase, pa.retSql.IdRecord);

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
        private List<Tables.Partner> GetListSql(ParamActior pa, Models.Task Tsk)
        {
            List<Tables.Partner> li = new List<Tables.Partner>();
            Dictionary<string, Tables.Partner> di = new Dictionary<string, Tables.Partner>();
            foreach (InfoBasePohoda ibp in Tsk.Param.CollectionBaseSource)
            {
                List<Tables.Partner> li_n = GetInList(pa, Tsk.ServerSource, ibp.Soubor, 0, ibp.ICO);
                foreach (Tables.Partner bn in li_n)
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
        private void WriteListSql(ParamActior pa, List<Tables.Partner> li_in)
        {
            try
            {
                foreach (InfoBasePohoda ibp in pa.Tsk.Param.CollectionBaseReceiver)
                {
                    List<Tables.Partner> li_out = GetInList(pa, pa.Tsk.ServerReceiver, ibp.Soubor, 0, ibp.ICO);
                    List<Tables.Partner> li_new;
                    List<Tables.Partner> li_chg;
                    List<Tables.Partner> li_eql;

                    Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                    string s1 = string.Format("({0:n0}:{1}) Task: {2}, Base: {6}, New: {3}, Chg: {4}, Eql: {5} ",
                       pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count, ibp.Soubor);
                    pa.Tsk.WriteMessageInfo(s1);
                    FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    //  создание
                    Tables.Partner item = new Tables.Partner();
                    item.Srv = pa.Tsk.ServerReceiver;
                    item.Base = ibp.Soubor;
                    if (li_new.Count != 0)
                    {
                        foreach (var bn in li_new)
                        {
                            bn.Srv = pa.Tsk.ServerReceiver;
                            bn.Base = ibp.Soubor;
                        }
                        item.CollectionPartner = li_new;
                        ResponseResult ret = (ResponseResult)tt.GetMethod("CreatePartner").Invoke(cl_Connect, new object[] { item, ibp.ICO });
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
                        item.CollectionPartner = li_chg;
                        ResponseResult ret = (ResponseResult)tt.GetMethod("UpdatePartner").Invoke(cl_Connect, new object[] { item, ibp.ICO });
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
        private void WriteListOdoo(ParamActior pa, List<Tables.Partner> li_in)
        {
            try
            {
                List<Tables.Partner> li_out = GetInList(pa, pa.Tsk.ServerReceiver, null, 0);
                List<Tables.Partner> li_new;
                List<Tables.Partner> li_chg;
                List<Tables.Partner> li_eql;
                Compare(li_in, li_out, out li_new, out li_chg, out li_eql, true);

                string s1 = string.Format("({0:n0}:{1}) Task: {2}, New: {3}, Chg: {4}, Eql: {5} ",
                   pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_new.Count, li_chg.Count, li_eql.Count);
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                //  создание  
                Tables.Partner item = new Tables.Partner();
                item.Srv = pa.Tsk.ServerReceiver;
                item.Base = "";
                if (li_new.Count != 0)
                {
                    foreach (var bn in li_new)
                    {
                        bn.Srv = pa.Tsk.ServerReceiver;
                        bn.Base = "";
                    }
                    item.CollectionPartner = li_new;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("CreatePartner").Invoke(cl_Connect, new object[] { item, "" });
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
                    item.CollectionPartner = li_chg;
                    ResponseResult ret = (ResponseResult)tt.GetMethod("UpdatePartner").Invoke(cl_Connect, new object[] { item, "" });
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
        private List<Tables.Partner> GetInList(ParamActior pa, Servers Srv, string NameBase, int Id, string Ico = "")
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
            ResponseResult ret = (ResponseResult)tt.GetMethod("GetListPartner").Invoke(cl_Connect, new object[] { Srv, NameBase, Ico, Id });
            if (ret.IsError)
            {
                pa.Tsk.WriteMessageError(string.Format(s_load, Srv.Name, NameBase, Id, Ico));
                throw new Exception(ret.Message);
            }
            return ret.Sender as List<Tables.Partner>;
        }

        /// <summary>
        /// Сравниваем списки source-Partner и receiver-Partner и составляем list для NEW, Change и Equals
        /// </summary>
        /// <param name="li_in">source-Partner</param>
        /// <param name="li_out">receiver-Partner</param>
        /// <param name="IsFull">True - сравнение по всем полям, false - только по ключу (IDS)</param>
        [NumFunction(7)]
        private void Compare(List<Tables.Partner> li_in, List<Tables.Partner> li_out,
            out List<Tables.Partner> li_new, out List<Tables.Partner> li_chg, out List<Tables.Partner> li_eql,
            bool IsFull = false)
        {
            li_new = new List<Tables.Partner>();
            li_chg = new List<Tables.Partner>();
            li_eql = new List<Tables.Partner>();
            for (int n1 = li_in.Count - 1; n1 >= 0; n1--)
            {
                bool IsNew = true;
                Tables.Partner bn_in = li_in[n1];
                for (int n2 = li_out.Count - 1; n2 >= 0; n2--)
                {
                    Tables.Partner bn_out = li_out[n2];
                    int m1 = bn_in.Ids.CompareTo(bn_out.Ids);
                    if (m1 == 0)        //  основные параметры Ids - равны 
                    {
                        if (IsFull)
                        {
                            int b1 = TestCompare(bn_in, bn_out);
                            int b2 = TestCompareBanky(bn_in, bn_out);
                            if ((b1 == 0) && (b2 == 0))
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
                                bn_out.Jmeno = bn_in.Jmeno;
                                bn_out.DIC = bn_in.DIC;
                                bn_out.Ulice = bn_in.Ulice;
                                bn_out.Psc = bn_in.Psc;
                                bn_out.Obec = bn_in.Obec;
                                bn_out.Tel = bn_in.Tel;
                                bn_out.Gsm = bn_in.Gsm;
                                bn_out.Email = bn_in.Email;
                                bn_out.Www = bn_in.Www;
                                bn_out.Remark = bn_in.Remark;
                                bn_out.Active = bn_in.Active;
                                //bn_out.IdCountry = bn_in.IdCountry;
                                //bn_out.Country = bn_in.Country;
                                bn_out.IdCountry = 0;
                                bn_out.CollectionUcet = bn_in.CollectionUcet;
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
                    Tables.Partner bn_out = new Tables.Partner();
                    bn_out.Ids = bn_in.Ids;
                    bn_out.Name = bn_in.Name;
                    bn_out.Jmeno = bn_in.Jmeno;
                    bn_out.DIC = bn_in.DIC;
                    bn_out.Ulice = bn_in.Ulice;
                    bn_out.Psc = bn_in.Psc;
                    bn_out.Obec = bn_in.Obec;
                    bn_out.Tel = bn_in.Tel;
                    bn_out.Gsm = bn_in.Gsm;
                    bn_out.Email = bn_in.Email;
                    bn_out.Www = bn_in.Www;
                    bn_out.Remark = bn_in.Remark;
                    bn_out.Active = bn_in.Active;
                    //bn_out.IdCountry = bn_in.IdCountry;
                    //bn_out.Country = bn_in.Country;
                    bn_out.IdCountry = 0;
                    bn_out.CollectionUcet = bn_in.CollectionUcet;
                    li_new.Add(bn_out);
                }
            }
        }

        private int TestCompare(Tables.Partner bn_in, Tables.Partner bn_out)
        {
            int n1 = 0;
            if (bn_in.Name.CompareTo(bn_out.Name) != 0) n1 = 1;
            else if (bn_in.Jmeno.CompareTo(bn_out.Jmeno) != 0) n1 = 2;
            else if (bn_in.Ulice.CompareTo(bn_out.Ulice) != 0) n1 = 3;
            else if (bn_in.Psc.CompareTo(bn_out.Psc) != 0) n1 = 4;
            else if (bn_in.Obec.CompareTo(bn_out.Obec) != 0) n1 = 5;
            else if (bn_in.Tel.CompareTo(bn_out.Tel) != 0) n1 = 6;
            else if (bn_in.Gsm.CompareTo(bn_out.Gsm) != 0) n1 = 7;
            else if (bn_in.Email.CompareTo(bn_out.Email) != 0) n1 = 8;
            else if (bn_in.Remark.CompareTo(bn_out.Remark) != 0) n1 = 9;
            //else if (bn_in.Country.ToLower().CompareTo(bn_out.Country.ToLower()) != 0) n1 = 10;
            else if (bn_in.DIC.CompareTo(bn_out.DIC) != 0) n1 = 11;
            //else if (bn_in.Active != bn_out.Active) n1 = 13;
            else if (string.IsNullOrWhiteSpace(bn_in.Www) && !string.IsNullOrWhiteSpace(bn_out.Www)) n1 = 12;
            else if (!string.IsNullOrWhiteSpace(bn_in.Www) && string.IsNullOrWhiteSpace(bn_out.Www)) n1 = 13;
            else if (!string.IsNullOrWhiteSpace(bn_in.Www) && !string.IsNullOrWhiteSpace(bn_out.Www))
            {
                if (bn_in.Www.ToLower().Trim().IndexOf(bn_out.Www.ToLower().Trim()) < 0)
                {
                    if (bn_out.Www.ToLower().Trim().IndexOf(bn_in.Www.ToLower().Trim()) < 0)
                    {
                        n1 = 14;
                    }
                }
            }
            return n1;
        }
        private int TestCompareBanky(Tables.Partner bn_in, Tables.Partner bn_out)
        {
            int n1 = 0;
            if ((bn_in.CollectionUcet.Count == 0) && (bn_out.CollectionUcet.Count == 0)) {; }
            else if ((bn_in.CollectionUcet.Count != 0) && (bn_out.CollectionUcet.Count == 0)) n1 = 51;
            else if ((bn_in.CollectionUcet.Count == 0) && (bn_out.CollectionUcet.Count != 0)) { n1 = 52; }
            else if (bn_in.CollectionUcet.Count != bn_out.CollectionUcet.Count) n1 = 53;
            else                   // if ((bn_in.CollectionUcet.Count != 0) && (bn_out.CollectionUcet.Count != 0))
            {
                foreach (var itemIn in bn_in.CollectionUcet)
                {
                    bool b1 = true;
                    foreach (var itemOut in bn_out.CollectionUcet)
                    {
                        if (DelSpace(itemIn.Ids).CompareTo(DelSpace(itemOut.Ids)) != 0) continue;
                        //if (itemIn.Name.CompareTo(itemOut.Name) != 0) continue;
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
