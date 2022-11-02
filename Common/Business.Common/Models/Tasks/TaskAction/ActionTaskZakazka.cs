using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    [NumClass(66)]
    public class ActionTaskZakazka : Interfases.IActionStart
    {
        private object cl_Connect;
        private Type tt;
        private string s_load = @"Load. Srv: {0}, Base: {1}, Id: {2}, Ico: {3}";
        private string s_create = @"Create. Ids: {0}, Name: {1}, Message: {2}";
        private string s_update = @"Update. Id: {0}, Ids: {1}, Name: {2}, Message: {3}";
        public ActionTaskZakazka()
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
            Dictionary<string, List<Tables.Zakazka>> di_in = null;
            Dictionary<string, List<Tables.Zakazka>> di_out = null;
            //  загружаем список исходных данных
            switch (pa.Tsk.ServerSource.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    di_in = GetListSql(pa, pa.Tsk.ServerSource);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    di_in = GetListOdoo(pa, pa.Tsk.ServerSource);
                    break;
            }
            // 
            switch (pa.Tsk.ServerReceiver.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    di_out = GetListSql(pa, pa.Tsk.ServerReceiver);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    di_out = GetListOdoo(pa, pa.Tsk.ServerReceiver);
                    break;
            }
            WriteList(pa, di_in, di_out);

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
            List<Tables.Zakazka> li_in = GetInList(pa, pa.Tsk.ServerSource, pa.retSql.NameBase, pa.retSql.IdRecord);

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
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(3)]
        private Dictionary<string, List<Tables.Zakazka>> GetListSql(ParamActior pa, Servers Srv)
        {
            Dictionary<string, List<Tables.Zakazka>> di = new Dictionary<string, List<Tables.Zakazka>>();
            foreach (InfoBasePohoda ibp in pa.Tsk.Param.CollectionBaseSource)
            {
                List<Tables.Zakazka> li_n = GetInList(pa, Srv, ibp.Soubor, 0, ibp.ICO);
                foreach (Tables.Zakazka bn in li_n)
                {
                    if (!di.TryGetValue(ibp.ICO, out List<Tables.Zakazka> li))
                    {
                        li = new List<Tables.Zakazka>();
                        di.Add(ibp.ICO, li);
                    }
                    bn.Base = ibp.Soubor;
                    li.Add(bn);
                }
            }
            return di;
        }

        /// <summary>
        /// создаёт полный список из всех выбранных баз инфо о банках в ODOO (PostgreSQL)
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [NumFunction(3)]
        private Dictionary<string, List<Tables.Zakazka>> GetListOdoo(ParamActior pa, Servers Srv)
        {
            Dictionary<string, List<Tables.Zakazka>> di = new Dictionary<string, List<Tables.Zakazka>>();
            List<Tables.Zakazka> li_n = GetInList(pa, Srv, null, 0);
            foreach (Tables.Zakazka bn in li_n)
            {
                if (string.IsNullOrWhiteSpace(bn.CompanyIco)) continue;
                if (!di.TryGetValue(bn.CompanyIco, out List<Tables.Zakazka> li))
                {
                    li = new List<Tables.Zakazka>();
                    di.Add(bn.CompanyIco, li);
                }
                li.Add(bn);
            }
            return di;
        }

        /// <summary>
        /// Загрузка списка илм 1 записи банка из указанной базы
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">Идентификатор записи. Равно 0-весь список, не равно 0 - только указанная запись</param>
        /// <returns></returns>
        [NumFunction(6)]
        private List<Tables.Zakazka> GetInList(ParamActior pa, Servers Srv, string NameBase, int Id, string Ico = null)
        {
            if (string.IsNullOrWhiteSpace(Ico))
            {
                if (!string.IsNullOrWhiteSpace(NameBase))
                {
                    string[] ss = NameBase.Split(new char[] { '_' });
                    if (ss.Length == 3) Ico = ss[1];
                }
            }
            ResponseResult ret = (ResponseResult)tt.GetMethod("GetListZakazka").Invoke(cl_Connect, new object[] { Srv, NameBase, Ico, Id });
            if (ret.IsError)
            {
                pa.Tsk.WriteMessageError(string.Format(s_load, Srv.Name, NameBase, Id, Ico));
                throw new Exception(ret.Message);
            }
            return ret.Sender as List<Tables.Zakazka>;
        }

        /// <summary>
        /// Запись (создание и обновление) в POHODA (SQL)
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="li_in"></param>
        [NumFunction(4)]
        private void WriteList(ParamActior pa, Dictionary<string, List<Tables.Zakazka>> di_in, Dictionary<string, List<Tables.Zakazka>> di_out)
        {
            Dictionary<string, List<Tables.Zakazka>> di_new = new Dictionary<string, List<Tables.Zakazka>>();
            Dictionary<string, List<Tables.Zakazka>> di_chg = new Dictionary<string, List<Tables.Zakazka>>();
            Dictionary<string, List<Tables.Zakazka>> di_eql = new Dictionary<string, List<Tables.Zakazka>>();

            foreach (var li_in in di_in)
            {
                if (di_out.TryGetValue(li_in.Key, out List<Tables.Zakazka> li_out))
                {
                    List<Tables.Zakazka> li_new;
                    List<Tables.Zakazka> li_chg;
                    List<Tables.Zakazka> li_eql;
                    Compare(li_in.Value, li_out, out li_new, out li_chg, out li_eql, true);
                    if (li_new.Count > 0)
                    {
                        if (di_new.TryGetValue(li_in.Key, out List<Tables.Zakazka> li_new_1))
                        {
                            li_new_1.AddRange(li_new);
                        }
                        else
                        {
                            di_new.Add(li_in.Key, li_new);
                        }
                    }
                    if (li_chg.Count > 0)
                    {
                        if (di_chg.TryGetValue(li_in.Key, out List<Tables.Zakazka> li_chg_1))
                        {
                            li_chg_1.AddRange(li_chg);
                        }
                        else
                        {
                            di_chg.Add(li_in.Key, li_chg);
                        }
                    }
                    if (li_eql.Count > 0)
                    {
                        if (di_eql.TryGetValue(li_in.Key, out List<Tables.Zakazka> li_eql_1))
                        {
                            li_eql_1.AddRange(li_eql);
                        }
                        else
                        {
                            di_eql.Add(li_in.Key, li_eql);
                        }
                    }
                }
                else
                {
                    di_new.Add(li_in.Key, li_in.Value);
                }
            }
            string s1 = "({0:n0}:{1}) Task: {2}, {3} - Firma: {4} ({5})";
            foreach (var li_in in di_new)
            {
                string s2 = string.Format(s1, pa.NumTask, pa.LevelTask, pa.Tsk.Name, "NEW", li_in.Key, li_in.Value.Count);
                pa.Tsk.WriteMessageInfo(s2);
                FileEventLog.WriteOk(this, s2, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            foreach (var li_in in di_chg)
            {
                string s2 = string.Format(s1, pa.NumTask, pa.LevelTask, pa.Tsk.Name, "CHG", li_in.Key, li_in.Value.Count);
                pa.Tsk.WriteMessageInfo(s2);
                FileEventLog.WriteOk(this, s2, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            foreach (var li_in in di_eql)
            {
                string s2 = string.Format(s1, pa.NumTask, pa.LevelTask, pa.Tsk.Name, "EQL", li_in.Key, li_in.Value.Count);
                pa.Tsk.WriteMessageInfo(s2);
                FileEventLog.WriteOk(this, s2, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            //  создание
            foreach (var li_new_c in di_new)
            {
                Tables.Zakazka item = new Tables.Zakazka();
                item.Srv = pa.Tsk.ServerReceiver;
                item.IcoBase = li_new_c.Key;
                if (li_new_c.Value.Count != 0)
                {
                    item.Base = li_new_c.Value[0].Base;
                    item.CollectionZakazka = li_new_c.Value.ToList();
                    ResponseResult ret = (ResponseResult)tt.GetMethod("CreateZakazka").Invoke(cl_Connect, new object[] { item, li_new_c.Key });
                    if (ret.IsError)
                    {
                        pa.Tsk.WriteMessageError(string.Format(s_create, item.Id, item.Ids, item.Name, ret.Message));
                    }
                }
            }
            ////  обновление
            //if (li_chg.Count != 0)
            //{
            //    foreach (var bn in li_chg)
            //    {
            //        bn.Srv = pa.Tsk.ServerReceiver;
            //        bn.Base = ibp.Soubor;
            //    }
            //    item.CollectionZakazka = li_chg;
            //    ResponseResult ret = (ResponseResult)tt.GetMethod("UpdateZakazka").Invoke(cl_Connect, new object[] { item, ibp.ICO });
            //    if (ret.IsError)
            //    {
            //        pa.Tsk.WriteMessageError(string.Format(s_update, item.Id, item.Ids, item.Name, ret.Message));
            //    }
            //}
        }

        /// <summary>
        /// Сравниваем списки source-Zakazka и receiver-Zakazka и составляем list для NEW, Change и Equals
        /// </summary>
        /// <param name="li_in">source-Zakazka</param>
        /// <param name="li_out">receiver-Zakazka</param>
        /// <param name="IsFull">True - сравнение по всем полям, false - только по ключу (IDS)</param>
        [NumFunction(7)]
        private void Compare(List<Tables.Zakazka> li_in, List<Tables.Zakazka> li_out,
            out List<Tables.Zakazka> li_new, out List<Tables.Zakazka> li_chg, out List<Tables.Zakazka> li_eql,
            bool IsFull = false)
        {
            li_new = new List<Tables.Zakazka>();
            li_chg = new List<Tables.Zakazka>();
            li_eql = new List<Tables.Zakazka>();
            for (int n1 = li_in.Count - 1; n1 >= 0; n1--)
            {
                bool IsNew = true;
                Tables.Zakazka bn_in = li_in[n1];
                for (int n2 = li_out.Count - 1; n2 >= 0; n2--)
                {
                    Tables.Zakazka bn_out = li_out[n2];
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
                                bn_out.Ids = bn_in.Ids;
                                bn_out.CompanyIco = bn_in.CompanyIco;
                                bn_out.UserName = bn_in.UserName;
                                bn_out.Name = bn_in.Name;
                                bn_out.DatesStatus = bn_in.DatesStatus;
                                bn_out.Status = bn_in.Status;
                                bn_out.Ost1 = bn_in.Ost1;
                                bn_out.Ost2 = bn_in.Ost2;
                                bn_out.Remark = bn_in.Remark;
                                bn_out.KcCelkem = bn_in.KcCelkem;
                                bn_out.Partners = bn_in.Partners;
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
                    Tables.Zakazka bn_out = new Tables.Zakazka();
                    bn_out.Ids = bn_in.Ids;
                    bn_out.CompanyIco = bn_in.CompanyIco;
                    bn_out.UserName = bn_in.UserName;
                    bn_out.Name = bn_in.Name;
                    bn_out.DatesStatus = bn_in.DatesStatus;
                    bn_out.Status = bn_in.Status;
                    bn_out.Ost1 = bn_in.Ost1;
                    bn_out.Ost2 = bn_in.Ost2;
                    bn_out.Remark = bn_in.Remark;
                    bn_out.KcCelkem = bn_in.KcCelkem;
                    bn_out.Partners = bn_in.Partners;
                    li_new.Add(bn_out);
                }
            }
        }

        private int TestCompare(Tables.Zakazka bn_in, Tables.Zakazka bn_out)
        {
            int n1 = 0;
            if (bn_in.CompanyIco.CompareTo(bn_out.CompanyIco) != 0) n1 = 1;
            else if ((bn_in.UserName.CompareTo(bn_out.UserName) != 0) && (!string.IsNullOrWhiteSpace(bn_in.UserName))) n1 = 2;
            else if (bn_in.Name.CompareTo(bn_out.Name) != 0) n1 = 3;
            else if (bn_in.DatesStatus.CompareTo(bn_out.DatesStatus) != 0) n1 = 4;
            else if (!bn_in.Status.CompareTo(bn_out.Status)) n1 = 5;
            else if (bn_in.Ost1.CompareTo(bn_out.Ost1) != 0) n1 = 6;
            else if (bn_in.Ost2.CompareTo(bn_out.Ost2) != 0) n1 = 7;
            else if (bn_in.Remark.CompareTo(bn_out.Remark) != 0) n1 = 8;
            else if (bn_in.KcCelkem != bn_out.KcCelkem) n1 = 9;
            else if (bn_in.Partners.Ids.CompareTo(bn_out.Partners.Ids) != 0) n1 = 10;
            return n1;
        }
    }
}
