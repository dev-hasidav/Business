using Business.Atributes;
using mod = Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.SyncAgent.Connect
{
    public class ConnectMainSyncAgent : MarshalByRefObject, Interfases.IConnectMainSyncAgent
    {
        private Sync.Main.MainSync ms = new Sync.Main.MainSync();

        #region  ==========  Test-запросы-r  ==========

        public ResponseResult CheckServers(mod.Servers srv)
        {
            return ms.CheckServers(srv);
        }

        #endregion

        #region  ==========  работа с базой(сервером)  ==========

        public ResponseResult GetServers(bool IsEnable = false)
        {
            return ms.GetServers(IsEnable);
        }
        public ResponseResult GetListBase(mod.Servers srv)
        {
            return ms.GetListBase(srv);
        }
        public ResponseResult CheckOrCreateTableAgent(mod.Servers srv)
        {
            return ms.CheckOrCreateTableAgent(srv);
        }
        public ResponseResult CheckingOrCreateOdoo(mod.Servers srv)
        {
            return ms.CheckingOrCreateOdoo(srv);
        }

        #endregion

        #region  ==========  Trigers Dml  ==========

        public Dictionary<string, Models.ListTrigger> GetDictionaryTriggers(mod.Servers srv)
        {
            return ms.GetDictionaryTriggers(srv);
        }
        public bool CheckTriggersDml(mod.Task tsk, string Base, string NameTrigger)
        {
            return ms.CheckTriggersDml(tsk, Base, NameTrigger);
        }
        public bool CreateTriggersDml(mod.Task tsk, string Base, string NameTableAgent)
        {
            return ms.CreateTriggersDml(tsk, Base, NameTableAgent);
        }
        public bool UodateTriggersDml(mod.Task tsk, string Base, string NameTrigger, string NameTableAgent)
        {
            return ms.UpdateTriggersDml(tsk, Base, NameTrigger, NameTableAgent);
        }
        public bool DeleteTriggersDml(mod.Servers srv, string Base, string NameTrigger, string NameTable)
        {
            return ms.DeleteTriggersDml(srv, Base, NameTrigger, NameTable);
        }
        public bool UpdateTriggersOdooDml(mod.Task tsk, string Base, string NameTrigger)
        {
            return ms.UpdateTriggersOdooDml(tsk, Base, NameTrigger);
        }
        public void UpdateReadTriggers(mod.Servers Srv, RetTriggers ret)
        {
            ms.UpdateReadTriggers(Srv, ret);
        }

        #endregion

        #region  ==========  Run task triggers  ==========

        [NumFunction(34)]
        public List<RetTriggers> GetTriggers(mod.Servers Srv, Enums.StTriggers St = Enums.StTriggers.ClrTrigger)
        {
            return ms.GetTriggers(Srv, St);
        }
        public void UpdateRemTriggers(mod.Servers Srv, RetTriggers reT, Enums.StTriggers St)
        {
            ms.UpdateRemTriggers(Srv, reT, St);
        }

        #endregion

        #region  ==========  Action Task  ==========

        #region  ==========  Bank  ==========
        public ResponseResult GetListBank(mod.Servers Srv, string NameBase, int Id = 0)
        {
            return ms.GetListBank(Srv, NameBase, Id);
        }
        public ResponseResult CreateBank(mod.Tables.Bank Bnk)
        {
            return ms.CreateBank(Bnk);
        }
        public ResponseResult UpdateBank(mod.Tables.Bank Bnk)
        {
            return ms.UpdateBank(Bnk);
        }
        #endregion

        #region  ==========  Country  ==========
        public ResponseResult GetListCountry(mod.Servers Srv, string NameBase, int Id)
        {
            return ms.GetListCountry(Srv, NameBase, Id);
        }
        public ResponseResult CreateCountry(mod.Tables.Country Cnt)
        {
            return ms.CreateCountry(Cnt);
        }
        public ResponseResult UpdateCountry(mod.Tables.Country Cnt)
        {
            return ms.UpdateCountry(Cnt);
        }
        #endregion

        #region  ==========  Currency  ==========
        public ResponseResult GetListCurrency(mod.Servers Srv, string NameBase, int Id)
        {
            return ms.GetListCurrency(Srv, NameBase, Id);
        }
        public ResponseResult CreateCurrency(mod.Tables.Currency Cnt)
        {
            return ms.CreateCurrency(Cnt);
        }
        public ResponseResult UpdateCurrency(mod.Tables.Currency Cnt)
        {
            return ms.UpdateCurrency(Cnt);
        }
        #endregion

        #region  ==========  Partner  ==========
        public ResponseResult GetListPartner(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            return ms.GetListPartner(Srv, NameBase, Ico, Id);
        }
        public ResponseResult CreatePartner(mod.Tables.Partner Cnt, string Ico)
        {
            return ms.CreatePartner(Cnt, Ico);
        }
        public ResponseResult UpdatePartner(mod.Tables.Partner Cnt, string Ico)
        {
            return ms.UpdatePartner(Cnt, Ico);
        }
        #endregion

        #region  ==========  Company  ==========
        public ResponseResult GetListCompany(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            return ms.GetListCompany(Srv, NameBase, Ico, Id);
        }
        public ResponseResult CreateCompany(mod.Tables.Company Cnt, string Ico)
        {
            return ms.CreateCompany(Cnt, Ico);
        }
        public ResponseResult UpdateCompany(mod.Tables.Company Cnt, string Ico)
        {
            return ms.UpdateCompany(Cnt, Ico);
        }
        #endregion

        #region  ==========  User  ==========
        public ResponseResult GetListUser(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            return ms.GetListUser(Srv, NameBase, Ico, Id);
        }
        public ResponseResult CreateUser(mod.Tables.User Cnt, string Ico)
        {
            return ms.CreateUser(Cnt, Ico);
        }
        public ResponseResult UpdateUser(mod.Tables.User Cnt, string Ico)
        {
            return ms.UpdateUser(Cnt, Ico);
        }
        #endregion

        #region  ==========  Zakazka  ==========
        public ResponseResult GetListZakazka(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            return ms.GetListZakazka(Srv, NameBase, Ico, Id);
        }
        public ResponseResult CreateZakazka(mod.Tables.Zakazka Cnt, string Ico)
        {
            return ms.CreateZakazka(Cnt, Ico);
        }
        public ResponseResult UpdateZakazka(mod.Tables.Zakazka Cnt, string Ico)
        {
            return ms.UpdateZakazka(Cnt, Ico);
        }
        #endregion

        #region  ==========  Objednalky  ==========
        public ResponseResult GetListObjednalky(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            return ms.GetListObjednalky(Srv, NameBase, Ico, Id);
        }
        public ResponseResult CreateObjednalky(mod.Tables.Objednalky Cnt, string Ico)
        {
            return ms.CreateObjednalky(Cnt, Ico);
        }
        public ResponseResult UpdateObjednalky(mod.Tables.Objednalky Cnt, string Ico)
        {
            return ms.UpdateObjednalky(Cnt, Ico);
        }
        #endregion

        #endregion

    }
}
