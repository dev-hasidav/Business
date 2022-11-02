using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Компания
    /// </summary>
    [NumClass(53)]
    [Serializable]
    public class Company : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Company() : base(Actions.SyncCompany) { }
        public Company(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncCompany) { }
        public Company(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncCompany) { }

        #endregion

        #region  ==========  Property  ==========
        public Partner Partner { set; get; } = new Partner();
        /// <summary>
        /// ids валюты   P=Firma-USR-CMene,  O=res_compamy-res_currency-res_country
        /// </summary>
        public string Currency { set; get; }
        /// <summary>
        /// P-Prijm  , O-
        /// </summary>
        public string Prijm { set; get; }
        /// <summary>
        /// P-Soubor  , O-
        /// </summary>
        public string Soubor { set; get; }
        /// <summary>
        /// P-год
        /// </summary>
        public int Rok { set; get; } = 0;
        /// <summary>
        /// P-Дата от
        /// </summary>
        public DateTime? DatRokOd { set; get; }
        /// <summary>
        /// P-Дато по
        /// </summary>
        public DateTime? DatRokDo { set; get; }
        /// <summary>
        /// res_company-fiscalyear_last_day, 
        /// </summary>
        public int FiscalyearLastDay { set; get; } = 31;
        /// <summary>
        /// res_company-fiscalyear_last_month
        /// </summary>
        public int FiscalyearLastMonth { set; get; } = 12;
        /// <summary>
        /// res_company-manufacturing_lead, 
        /// </summary>
        public double ManufacturingLead { set; get; } = 0;
        /// <summary>
        /// res_company-po_lead, 
        /// </summary>
        public double PoLead { set; get; } = 0;
        /// <summary>
        /// res_company-security_lead, 
        /// </summary>
        public double SecurityLead { set; get; } = 0;

        private List<Company> _CollectionCompany = new List<Company>();
        public List<Company> CollectionCompany { get { return _CollectionCompany; } set { _CollectionCompany = value; IsRecord = NumberRecord.Many; } }

        private List<User> _CollectionUser = new List<User>();
        public List<User> CollectionUser { get { return _CollectionUser; } set { _CollectionUser = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; } = NumberRecord.One;
		public string Tag { set; get; }

		#endregion

		#region  ==========  SQL  ==========
		[NumFunction(1)]
        protected override void LoadSql(int Id, string Ico)
        {
            bool IsSelect = true;
            System.Data.SqlClient.SqlConnection cn = null;
            System.Data.SqlClient.SqlConnection cn1 = null;
            try
            {
                if (this.Srv.Type == TypeServers.PohodaXml)
                {
                    this.Srv.Type = TypeServers.MsSql;
                    this.Srv.SqlHostIp = this.Srv.PohodaSqlHostIp;
                    this.Srv.SqlUser = this.Srv.PohodaSqlUser;
                    this.Srv.SqlPassword = this.Srv.PohodaSqlPassword;
                }
                string sys_base = string.Format("{0}_sys", InfoBasePohoda.GetPrifixPohoda(Srv));
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, sys_base));
                cn.Open();
                cn1 = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, sys_base));
                cn1.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = @"SELECT f.ID, f.ICO, f.DIC, f.Firma, f.RefZeme, f.Jmeno, f.Prijm, f.Ulice, f.CP, f.Obec, " +
                        @" f.PSC, f.Tel, f.GSM, f.Email, f.WWW, f.Soubor, f.Pozn, f.Rok, f.DatRokOd, f.DatRokDo, " +
                        @" z.IDS, z.SText, z.Kod " +
                        @" FROM Firma AS f LEFT OUTER JOIN sZeme AS z ON f.RefZeme = z.ID order by f.ICO, f.Rok DESC "
                };
                if (Id > 0)
                {
                    cm.CommandText = @"SELECT f.ID, f.ICO, f.DIC, f.Firma, f.RefZeme, f.Jmeno, f.Prijm, f.Ulice, f.CP, f.Obec, " +
                        @" f.PSC, f.Tel, f.GSM, f.Email, f.WWW, f.Soubor, f.Pozn, f.Rok, f.DatRokOd, f.DatRokDo, " +
                        @" z.IDS, z.SText, z.Kod " +
                        @" FROM Firma AS f LEFT OUTER JOIN sZeme AS z ON f.RefZeme = z.ID" +
                        @" WHERE (f.ID = @ID)";
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ico))
                {
                    cm.CommandText = @"SELECT f.ID, f.ICO, f.DIC, f.Firma, f.RefZeme, f.Jmeno, f.Prijm, f.Ulice, f.CP, f.Obec, " +
                        @" f.PSC, f.Tel, f.GSM, f.Email, f.WWW, f.Soubor, f.Pozn, f.Rok, f.DatRokOd, f.DatRokDo, " +
                        @" z.IDS, z.SText, z.Kod " +
                        @" FROM Firma AS f LEFT OUTER JOIN sZeme AS z ON f.RefZeme = z.ID" +
                        @" WHERE (f.Ico = @Ico)";
                    System.Data.SqlClient.SqlParameter pr_Ico = cm.Parameters.Add("Ico", System.Data.SqlDbType.VarChar);
                    pr_Ico.Value = Ico;
                }
                else { IsSelect = false; }
                this.IsRecord = NumberRecord.Many;
                Dictionary<string, Company> di = new Dictionary<string, Company>();
                SqlScripts ss = new SqlScripts();
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    string s_soubor = dr["Soubor"] == DBNull.Value ? "" : dr["Soubor"].ToString().Trim();
                    if (!ss.CheckConnectSqlBase(s_soubor, cn1)) continue;
                    Company cmp = new Company();
                    cmp.Srv = this.Srv;
                    cmp.Base = this.Base;
                    cmp.Id = (int)dr["ID"];
                    cmp.Ids = dr["ICO"] == DBNull.Value ? "" : dr["ICO"].ToString().Trim();
                    cmp.Name = dr["Firma"] == DBNull.Value ? "" : dr["Firma"].ToString().Trim();
                    cmp.Prijm = dr["Prijm"] == DBNull.Value ? "" : dr["Prijm"].ToString().Trim();
                    cmp.Soubor = s_soubor;
                    cmp.Rok = dr["Rok"] == DBNull.Value ? 0 : (int)dr["Rok"];
                    if (dr["DatRokOd"] != DBNull.Value) cmp.DatRokDo = (DateTime)dr["DatRokOd"];
                    if (dr["DatRokDo"] != DBNull.Value) cmp.DatRokOd = (DateTime)dr["DatRokDo"];
                    cmp.Partner.Ids = cmp.Ids;
                    cmp.Partner.Name = cmp.Name;
                    cmp.Partner.DIC = dr["DIC"] == DBNull.Value ? "" : dr["DIC"].ToString().Trim();
                    cmp.Partner.Country = dr["Kod"] == DBNull.Value ? "CZ" : dr["Kod"].ToString().Trim();
                    cmp.Partner.Jmeno = dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim();
                    cmp.Partner.Ulice = ((dr["Ulice"] == DBNull.Value ? "" : dr["Ulice"].ToString().Trim()) + " " +
                        (dr["CP"] == DBNull.Value ? "" : dr["CP"].ToString().Trim())).Trim();
                    cmp.Partner.Obec = dr["Obec"] == DBNull.Value ? "" : dr["Obec"].ToString().Trim();
                    cmp.Partner.Psc = dr["PSC"] == DBNull.Value ? "" : dr["PSC"].ToString().Trim();
                    cmp.Partner.Tel = dr["Tel"] == DBNull.Value ? "" : dr["Tel"].ToString().Trim();
                    cmp.Partner.Gsm = "";
                    //cmp.Partner.Gsm = dr["GSM"] == DBNull.Value ? "" : dr["GSM"].ToString().Trim();
                    cmp.Partner.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString().Trim();
                    cmp.Partner.Www = dr["WWW"] == DBNull.Value ? "" : dr["WWW"].ToString().Trim();
                    cmp.Partner.Remark = dr["Pozn"] == DBNull.Value ? "" : dr["Pozn"].ToString().Trim();
                    if (!di.ContainsKey(cmp.Ids)) di.Add(cmp.Ids, cmp);
                }
                dr.Close();
                cm = new System.Data.SqlClient.SqlCommand();
                cm.CommandText = @"SELECT ID, IDS, SText, IBAN, Banka, KodBanky, Swift " +
                    @" FROM sUcet where IBAN IS NOT NULL ORDER BY IDS";
                Dictionary<string, int> di_check = new Dictionary<string, int>();
                foreach (Company item in di.Values)
                {
                    item.CollectionUser = User.GetList(item.Srv, item.Soubor);
                    cm.Connection = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, item.Soubor));
                    cm.Connection.Open();
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        string s_ucet = dr["IBAN"] == DBNull.Value ? "" : dr["IBAN"].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(s_ucet))
                        {
                            if (!di_check.ContainsKey(s_ucet))
                            {
                                di_check.Add(s_ucet, 0);
                                PartnerBank pb = new PartnerBank();
                                pb.Id = (int)dr["ID"];
                                pb.Ids = s_ucet;
                                pb.Name = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                                string s_kodBanky = dr["KodBanky"] == DBNull.Value ? "" : dr["KodBanky"].ToString().Trim();
                                if (!string.IsNullOrWhiteSpace(s_kodBanky))
                                {
                                    pb.Banky = new Bank();
                                    pb.Banky.Ids = s_kodBanky;
                                    pb.Banky.Name = dr["Banka"] == DBNull.Value ? "" : dr["Banka"].ToString().Trim();
                                    pb.Banky.SWIFT = dr["Swift"] == DBNull.Value ? "" : dr["Swift"].ToString().Trim();
                                }
                                item.Partner.CollectionUcet.Add(pb);
                            }
                        }
                        s_ucet = dr["SText"] == DBNull.Value ? "" : dr["SText"].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(s_ucet))
                        {
                            if (!di_check.ContainsKey(s_ucet))
                            {
                                di_check.Add(s_ucet, 0);
                                PartnerBank pb = new PartnerBank();
                                pb.Id = (int)dr["ID"];
                                pb.Ids = s_ucet;
                                pb.Name = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                                string s_kodBanky = dr["KodBanky"] == DBNull.Value ? "" : dr["KodBanky"].ToString().Trim();
                                if (!string.IsNullOrWhiteSpace(s_kodBanky))
                                {
                                    pb.Banky = new Bank();
                                    pb.Banky.Ids = s_kodBanky;
                                    pb.Banky.Name = dr["Banka"] == DBNull.Value ? "" : dr["Banka"].ToString().Trim();
                                    pb.Banky.SWIFT = dr["Swift"] == DBNull.Value ? "" : dr["Swift"].ToString().Trim();
                                }
                                item.Partner.CollectionUcet.Add(pb);
                            }
                        }
                    }
                    this.CollectionCompany.Add(item);
                    dr.Close();
                    cm.Connection.Close();
                }
                di.Clear();
                if (IsSelect && this.CollectionCompany.Count != 0)
                {
                    this.Id = this.CollectionCompany[0].Id;
                    this.Currency = this.CollectionCompany[0].Currency;
                    this.DatRokDo = this.CollectionCompany[0].DatRokDo;
                    this.DatRokOd = this.CollectionCompany[0].DatRokOd;
                    this.FiscalyearLastDay = this.CollectionCompany[0].FiscalyearLastDay;
                    this.FiscalyearLastMonth = this.CollectionCompany[0].FiscalyearLastMonth;
                    this.Ids = this.CollectionCompany[0].Ids;
                    this.ManufacturingLead = this.CollectionCompany[0].ManufacturingLead;
                    this.Name = this.CollectionCompany[0].Name;
                    this.PoLead = this.CollectionCompany[0].PoLead;
                    this.Prijm = this.CollectionCompany[0].Prijm;
                    this.Rok = this.CollectionCompany[0].Rok;
                    this.SecurityLead = this.CollectionCompany[0].SecurityLead;
                    this.Soubor = this.CollectionCompany[0].Soubor;
                    this.Partner = this.CollectionCompany[0].Partner;
                    this.CollectionCompany = null;
                    this.IsRecord = NumberRecord.One;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); cn1?.Close(); }
            return;
        }
        [NumFunction(19)]
        protected override string LoadSql(int Id)
        {
            string Ico = "";
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (this.Srv.Type == TypeServers.PohodaXml)
                {
                    this.Srv.Type = TypeServers.MsSql;
                    this.Srv.SqlHostIp = this.Srv.PohodaSqlHostIp;
                    this.Srv.SqlUser = this.Srv.PohodaSqlUser;
                    this.Srv.SqlPassword = this.Srv.PohodaSqlPassword;
                }
                string sys_base = string.Format("{0}_sys", InfoBasePohoda.GetPrifixPohoda(Srv));
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, sys_base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = @"SELECT f.ICO  FROM Firma AS f WHERE (f.ID = @ID) "
                };
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                pr_Id.Value = Id;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Ico = o1.ToString().Trim();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Ico;
        }
        [NumFunction(20)]
        protected override int LoadSql(string Ids)
        {
            int Id = 0;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (this.Srv.Type == TypeServers.PohodaXml)
                {
                    this.Srv.Type = TypeServers.MsSql;
                    this.Srv.SqlHostIp = this.Srv.PohodaSqlHostIp;
                    this.Srv.SqlUser = this.Srv.PohodaSqlUser;
                    this.Srv.SqlPassword = this.Srv.PohodaSqlPassword;
                }
                string sys_base = string.Format("{0}_sys", InfoBasePohoda.GetPrifixPohoda(Srv));
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, sys_base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = @"SELECT f.ID  FROM Firma AS f WHERE (f.ICO = @ICO) "
                };
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                pr_Id.Value = Ids;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Id = (int)o1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Id;
        }
        [NumFunction(2)]
        protected override void CreateSql()
        {
            throw new Exception(string.Format("You cannot create a new company in the '_sys' database"));
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            throw new Exception(string.Format("Cannot update company in '_sys' database"));
        }
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            throw new Exception(string.Format("Cannot delete company in '_sys' database"));
        }

        #endregion

        #region  ==========  Pohoda  ==========
        [NumFunction(5)]
        protected override void LoadPohoda(int Id, string Name)
        {
            LoadSql(Id, Name);
        }
        [NumFunction(6)]
        protected override void CreatePohoda()
        {
            CreateSql();
        }
        [NumFunction(7)]
        protected override void UpdatePohoda()
        {
            UpdateSql();
        }
        [NumFunction(8)]
        protected override void DeletePohoda()
        {
            DeleteSql();
        }
        #endregion

        #region  ==========  Odoo  ==========
        [NumFunction(9)]
        protected override void LoadOdoo(int Id, string Ico)
        {
            bool IsSelect = true;
            try
            {
                this.IsRecord = NumberRecord.Many;

                Servers sr = new Servers();
                sr.Type = TypeServers.PostgreSQL;
                sr.PostgreBase = this.Srv.PostgreBase;
                sr.PostgreHostIp = this.Srv.PostgreHostIp;
                sr.PostgreIntegratedSecurity= this.Srv.PostgreIntegratedSecurity;
                sr.PostgrePassword= this.Srv.PostgrePassword;
                sr.PostgrePort= this.Srv.PostgrePort;
                sr.PostgreUser= this.Srv.PostgreUser;
                sr.PostgreUseSslStream= this.Srv.PostgreUseSslStream;

                List<string> li_pole = new List<string>
                {
                    "id",
                    "x_ico",
                    "x_dic",
                    "name",
                    "currency_id",
                    "partner_id",
                    "company_registry",
                    "country_id",
                    "x_jmeno",
                    "street",
                    "city",
                    "zip",
                    "phone",
                    "mobile",
                    "email",
                    "website",
                    "x_comment"
                };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0) odoFiltr.Filter("id", "=", Id);
                else if (!string.IsNullOrWhiteSpace(Ico)) odoFiltr.Filter("x_ico", "=", Ico);
                else IsSelect = false;
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr, "x_ico");
                Dictionary<int, List<PartnerBank>> di_ucet = PartnerBank.GetChashBankPartner(sr, this.Base, this.IcoBase);
                Dictionary<int, User> di_user = User.GetChashUserId(sr, this.Base, "");
                List<PartnerBank> li_pb;
                User us;
                foreach (var item in Datas)
                {
                    Company cmp = new Company();
                    cmp.Srv = this.Srv;
                    cmp.Base = this.Base;
                    cmp.Id = int.Parse(item["id"]);
                    cmp.Ids = item["x_ico"] == "False" ? "" : item["x_ico"].Trim();
                    cmp.Name = item["name"] == "False" ? "" : item["name"].Trim();
                    int IdCurrency = Funcs.ConvertStringToInt.StringOdooToInt(item["currency_id"] == "False" ? "0" : item["currency_id"]);
                    Currency cur = Tables.Currency.GetCurrency(this.Srv, this.Base, IdCurrency);
                    if (cur.Id != 0) cmp.Currency = cur.Name;
                    cmp.Partner.Id = Funcs.ConvertStringToInt.StringOdooToInt(item["partner_id"] == "False" ? "0" : item["partner_id"]);
                    cmp.Partner.Ids = cmp.Ids;
                    cmp.Partner.Name = cmp.Name;
                    int IdCountry = Funcs.ConvertStringToInt.StringOdooToInt(item["country_id"] == "False" ? "0" : item["country_id"]);
                    Country cn = Tables.Country.GetCountry(this.Srv, this.Base, IdCountry);
                    if (cn.Id != 0) cmp.Partner.Country = cn.Name;
                    cmp.Partner.DIC = item["x_dic"] == "False" ? "" : item["x_dic"].Trim();
                    cmp.Partner.Jmeno = item["x_jmeno"] == "False" ? "" : item["x_jmeno"].Trim();
                    cmp.Partner.Ulice = item["street"] == "False" ? "" : item["street"].Trim();
                    cmp.Partner.Obec = item["city"] == "False" ? "" : item["city"].Trim();
                    cmp.Partner.Psc = item["zip"] == "False" ? "" : item["zip"].Trim();
                    cmp.Partner.Tel = item["phone"] == "False" ? "" : item["phone"].Trim();
                    cmp.Partner.Gsm = "";
                    //cmp.Partner.Gsm = item["mobile"] == "False" ? "" : item["mobile"].Trim();
                    cmp.Partner.Email = item["email"] == "False" ? "" : item["email"].Trim();
                    cmp.Partner.Www = item["website"] == "False" ? "" : item["website"].Trim();
                    cmp.Partner.Remark = item["x_comment"] == "False" ? "" : item["x_comment"].Trim();
                    if (di_ucet.TryGetValue(cmp.Partner.Id, out li_pb)) cmp.Partner.CollectionUcet = li_pb;
                    List<int> li_users = GetPostgreUsers(cmp.Id);
                    foreach (int usr in li_users)
                    {
                        if (di_user.TryGetValue(usr, out us))
                        {
                            cmp.CollectionUser.Add(us);
                        }
                    }
                    this.CollectionCompany.Add(cmp);
                }
                if (IsSelect && this.CollectionCompany.Count != 0)
                {
                    this.Id = this.CollectionCompany[0].Id;
                    this.Currency = this.CollectionCompany[0].Currency;
                    this.DatRokDo = this.CollectionCompany[0].DatRokDo;
                    this.DatRokOd = this.CollectionCompany[0].DatRokOd;
                    this.FiscalyearLastDay = this.CollectionCompany[0].FiscalyearLastDay;
                    this.FiscalyearLastMonth = this.CollectionCompany[0].FiscalyearLastMonth;
                    this.Currency = this.CollectionCompany[0].Currency;
                    this.Ids = this.CollectionCompany[0].Ids;
                    this.ManufacturingLead = this.CollectionCompany[0].ManufacturingLead;
                    this.Name = this.CollectionCompany[0].Name;
                    this.Partner = this.CollectionCompany[0].Partner;
                    this.PoLead = this.CollectionCompany[0].PoLead;
                    this.Prijm = this.CollectionCompany[0].Prijm;
                    this.Rok = this.CollectionCompany[0].Rok;
                    this.SecurityLead = this.CollectionCompany[0].SecurityLead;
                    this.Soubor = this.CollectionCompany[0].Soubor;
                    //this.CollectionCompany = this.CollectionCompany[0].CollectionCompany;
                    this.CollectionUser = this.CollectionCompany[0].CollectionUser;
                    this.IsRecord = NumberRecord.One;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            return;
        }
        [NumFunction(10)]
        protected override void CreateOdoo()
        {
            string s_t1 = null, s_t2 = null, s_t3 = null;
            try
            {
                OdooScripts odScr = new OdooScripts();
                Servers sr = new Servers();
                sr.Type = TypeServers.PostgreSQL;
                sr.PostgreBase = this.Srv.PostgreBase;
                sr.PostgreHostIp = this.Srv.PostgreHostIp;
                sr.PostgreIntegratedSecurity = this.Srv.PostgreIntegratedSecurity;
                sr.PostgrePassword = this.Srv.PostgrePassword;
                sr.PostgrePort = this.Srv.PostgrePort;
                sr.PostgreUser = this.Srv.PostgreUser;
                sr.PostgreUseSslStream = this.Srv.PostgreUseSslStream;
                Dictionary<string, User> di_user = User.GetChashUserLogin(sr, this.Base, "");
                Dictionary<int, Dictionary<int, int>> di_user_comps = new Dictionary<int, Dictionary<int, int>>();
                User us1;
                OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                foreach (var item in this.CollectionCompany)
                {
                    s_t1 = item.Name;
                    s_t2 = item.Ids;
                    s_t3 = item.Partner.Jmeno;
                    int IdCurrency = GetCurrencyOdoo(item);
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico", item.Ids },
                            { "name", item.Name },
                            { "company_registry", item.Partner.DIC },
                            { "vat", item.Ids },
                            { "x_dic", item.Partner.DIC },
                            { "currency_id", IdCurrency },
                            { "x_jmeno", item.Partner.Jmeno },
                            { "street", item.Partner.Ulice },
                            { "city", item.Partner.Obec },
                            { "zip", item.Partner.Psc },
                            { "phone", item.Partner.Tel },
                            { "email", item.Partner.Email },
                            { "website", item.Partner.Www },
                            { "x_comment", item.Partner.Remark }
                        };
                    item.Id = (int)odScr.InsertRowPacket(Client, this.PrAction.TableOdoo, di);
                    Dictionary<int, int> di_comps = null;
                    foreach (User us in item.CollectionUser)
                    {
                        us.Srv = this.Srv;
                        us.Base = this.Base;
                        us.Client = Client;
                        if (!di_user.TryGetValue(us.Ids, out us1))
                        {
                            us.IdCompany = item.Id;
                            us.Create();
                            di_user.Add(us.Ids, us);
                            us1 = us;
                        }
                        if (di_user_comps.TryGetValue(us1.Id, out di_comps))
                        {
                            if (!di_comps.TryGetValue(item.Id, out int n1))
                            {
                                di_comps.Add(item.Id, 0);
                            }
                        }
                        else
                        {
                            Dictionary<int, int> dd = new Dictionary<int, int>();
                            dd.Add(item.Id, 0);
                            di_user_comps.Add(us1.Id, dd);
                        }
                    }
                    int IdPartner = GetPostgrePartner(item.Id);
                    foreach (PartnerBank pb in item.Partner.CollectionUcet)
                    {
                        pb.Client = Client;
                        pb.IdPartner = IdPartner;
                        pb.Srv = sr;
                        pb.Base = this.Base;
                        pb.IdCompany = item.Id;
                        pb.Create();
                    }
                }
                User us2 = new User();
                us2.Srv = this.Srv;
                us2.Base = this.Base;
                us2.Client = Client;
                us2.UpdateOdooUsers(di_user_comps);
            }
            catch (Exception e1)
            {
                string s1 = string.Format("Error: {3}, Name: {0}, ICO: {1}, Jmeno: {2}", s_t1, s_t2, s_t3, e1.Message);
                Exception e = new Exception(s1, e1);
                FileEventLog.WriteErr(this, e, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e;
            }
        }
        [NumFunction(11)]
        protected override void UpdateOdoo()
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                Servers sr = new Servers();
                sr.Type = TypeServers.PostgreSQL;
                sr.PostgreBase = this.Srv.PostgreBase;
                sr.PostgreHostIp = this.Srv.PostgreHostIp;
                sr.PostgreIntegratedSecurity = this.Srv.PostgreIntegratedSecurity;
                sr.PostgrePassword = this.Srv.PostgrePassword;
                sr.PostgrePort = this.Srv.PostgrePort;
                sr.PostgreUser = this.Srv.PostgreUser;
                sr.PostgreUseSslStream = this.Srv.PostgreUseSslStream;
                Dictionary<string, User> di_user = User.GetChashUserLogin(sr, this.Base, "");
                Dictionary<int, Dictionary<int, int>> di_user_comps = new Dictionary<int, Dictionary<int, int>>();
                User us1;
                OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                foreach (var item in this.CollectionCompany)
                {
                    int IdCurrency = GetCurrencyOdoo(item);
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico", item.Ids },
                            { "name", item.Name },
                            { "company_registry", item.Partner.DIC },
                            { "vat", item.Ids },
                            { "x_dic", item.Partner.DIC },
                            { "currency_id", IdCurrency },
                            { "x_jmeno", item.Partner.Jmeno },
                            { "street", item.Partner.Ulice },
                            { "city", item.Partner.Obec },
                            { "zip", item.Partner.Psc },
                            { "phone", item.Partner.Tel },
                            { "email", item.Partner.Email },
                            { "website", item.Partner.Www },
                            { "x_comment", item.Partner.Remark }
                        };
                    odScr.UpdateRowPacket(Client, this.PrAction.TableOdoo, item.Id, di);
                    item.Partner.Srv = this.Srv;
                    item.Partner.Base = this.Base;
                    CollPartBankUpdate(item.Partner, sr);

                    Dictionary<int, int> di_comps = null;
                    foreach (User us in item.CollectionUser)
                    {
                        us.Srv = this.Srv;
                        us.Base = this.Base;
                        us.Client = Client;
                        if (!di_user.TryGetValue(us.Ids, out us1))
                        {
                            us.IdCompany = item.Id;
                            us.Create();
                            di_user.Add(us.Ids, us);
                            us1 = us;
                        }
                        else
                        {
                            us.Srv = sr;
                            us.Base = this.Base;
                            us.IdCompany = item.Id;
                            us.Update();
                        }
                        if (di_user_comps.TryGetValue(us1.Id, out di_comps))
                        {
                            if (!di_comps.TryGetValue(item.Id, out int n1))
                            {
                                di_comps.Add(item.Id, 0);
                            }
                        }
                        else
                        {
                            Dictionary<int, int> dd = new Dictionary<int, int>();
                            dd.Add(item.Id, 0);
                            di_user_comps.Add(us1.Id, dd);
                        }
                    }
                }
                User us2 = new User();
                us2.Srv = this.Srv;
                us2.Base = this.Base;
                us2.Client = Client;
                us2.UpdateOdooUsers(di_user_comps);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(12)]
        protected override void DeleteOdoo()
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                odScr.DeleteRow(Srv, this.PrAction.TableOdoo, this.Id);
                this.Id = 0;
                this.Ids = "";
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        #endregion

        #region  ==========  PostgreSQL  ==========
        [NumFunction(13)]
        protected override void LoadPostgre(int Id, string Ico)
        {
            bool IsSelect = true;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                this.IsRecord = NumberRecord.Many;
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT * FROM {0} order by name ", this.PrAction.TablePostgreSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ico))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where x_ico = @x_ico", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_x_ico = cm.Parameters.Add("x_ico", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_x_ico.Value = Ico;
                }
                else { IsSelect = false; }
                Dictionary<int, List<PartnerBank>> di_ucet = PartnerBank.GetChashBankPartner(this.Srv, this.Base, this.IcoBase);
                List<PartnerBank> li_pb;
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Company cmp = new Company();
                    cmp.Srv = this.Srv;
                    cmp.Base = this.Base;
                    cmp.IcoBase = this.IcoBase;
                    cmp.Id = (int)dr["id"];
                    cmp.Ids = dr["x_ico"] == DBNull.Value ? "" : dr["x_ico"].ToString().Trim();
                    cmp.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    int IdCurrency = dr["currency_id"] == DBNull.Value ? 0 : (int)dr["currency_id"];
                    Currency cur = Tables.Currency.GetCurrency(cmp.Srv, cmp.Base, IdCurrency);
                    if (cur.Id != 0) cmp.Currency = cur.Name;
                    int IdPartner = dr["partner_id"] == DBNull.Value ? 0 : (int)dr["partner_id"];
                    cmp.Partner.Srv = this.Srv;
                    cmp.Partner.Base = this.Base;
                    cmp.Partner.Load(IdPartner, "");
                    if (cmp.Partner.Id == 0)
                    {
                        cmp.Partner.Ids = cmp.Ids;
                        cmp.Partner.Name = cmp.Name;
                        cmp.Partner.DIC = dr["company_registry"] == DBNull.Value ? "" : dr["company_registry"].ToString().Trim();
                        int IdCountry = dr["country_id"] == DBNull.Value ? 0 : (int)dr["country_id"];
                        Country con = Tables.Country.GetCountry(cmp.Srv, cmp.Base, IdCountry);
                        if (con.Id != 0) cmp.Partner.Country = con.Name;
                        cmp.Partner.Jmeno = dr["x_jmeno"] == DBNull.Value ? "" : dr["x_jmeno"].ToString().Trim();
                        cmp.Partner.Ulice = dr["street"] == DBNull.Value ? "" : dr["street"].ToString().Trim();
                        cmp.Partner.Obec = dr["city"] == DBNull.Value ? "" : dr["city"].ToString().Trim();
                        cmp.Partner.Psc = dr["zip"] == DBNull.Value ? "" : dr["zip"].ToString().Trim();
                        cmp.Partner.Tel = dr["phone"] == DBNull.Value ? "" : dr["phone"].ToString().Trim();
                        cmp.Partner.Gsm = dr["mobile"] == DBNull.Value ? "" : dr["mobile"].ToString().Trim();
                        cmp.Partner.Email = dr["email"] == DBNull.Value ? "" : dr["email"].ToString().Trim();
                        cmp.Partner.Www = dr["website"] == DBNull.Value ? "" : dr["website"].ToString().Trim();
                        cmp.Partner.Remark = dr["x_comment"] == DBNull.Value ? "" : dr["x_comment"].ToString().Trim();
                        if (di_ucet.TryGetValue(IdPartner, out li_pb)) cmp.Partner.CollectionUcet = li_pb;
                    }
                    this.CollectionCompany.Add(cmp);
                }
                dr.Close();
                if (IsSelect && this.CollectionCompany.Count != 0)
                {
                    this.Id = this.CollectionCompany[0].Id;
                    this.DatRokDo = this.CollectionCompany[0].DatRokDo;
                    this.DatRokOd = this.CollectionCompany[0].DatRokOd;
                    this.FiscalyearLastDay = this.CollectionCompany[0].FiscalyearLastDay;
                    this.FiscalyearLastMonth = this.CollectionCompany[0].FiscalyearLastMonth;
                    this.Currency = this.CollectionCompany[0].Currency;
                    this.Ids = this.CollectionCompany[0].Ids;
                    this.ManufacturingLead = this.CollectionCompany[0].ManufacturingLead;
                    this.Name = this.CollectionCompany[0].Name;
                    this.PoLead = this.CollectionCompany[0].PoLead;
                    this.Prijm = this.CollectionCompany[0].Prijm;
                    this.Rok = this.CollectionCompany[0].Rok;
                    this.SecurityLead = this.CollectionCompany[0].SecurityLead;
                    this.Soubor = this.CollectionCompany[0].Soubor;
                    this.Partner = this.CollectionCompany[0].Partner;
                    this.CollectionCompany = null;
                    this.IsRecord = NumberRecord.One;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(25)]
        protected override string LoadPostgre(int Id)
        {
            string Ico = "";
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT x_ico FROM {0} where id = @id", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = Id;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Ico = o1.ToString().Trim();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Ico;
        }
        [NumFunction(26)]
        protected override int LoadPostgre(string Ico)
        {
            int Id = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT id FROM {0} where x_ico = @x_ico", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("x_ico", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_Id.Value = Ico;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Id = (int)o1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Id;
        }
        [NumFunction(14)]
        protected override void CreatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} " +
                        @" ( x_ico, name, currency_id, phone, email, company_registry, partner_id, fiscalyear_last_day, fiscalyear_last_month, manufacturing_lead, po_lead, security_lead, " +
                        @" x_jmeno ) VALUES " +
                        @" ( @x_ico, @name, @currency_id, @phone, @email, @company_registry, @partner_id, @fiscalyear_last_day, @fiscalyear_last_month, @manufacturing_lead, @po_lead, @security_lead, " +
                        @" @x_jmeno ); " +
                        " SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_x_ico = cm.Parameters.Add("x_ico", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_currency = cm.Parameters.Add("currency_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_phone = cm.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_email = cm.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_company_registry = cm.Parameters.Add("company_registry", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_partner = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_FDay = cm.Parameters.Add("fiscalyear_last_day", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_DMonth = cm.Parameters.Add("fiscalyear_last_month", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_manufacturing_lead = cm.Parameters.Add("manufacturing_lead", NpgsqlTypes.NpgsqlDbType.Double);
                Npgsql.NpgsqlParameter pr_PoLead = cm.Parameters.Add("po_lead", NpgsqlTypes.NpgsqlDbType.Double);
                Npgsql.NpgsqlParameter pr_SecLead = cm.Parameters.Add("security_lead", NpgsqlTypes.NpgsqlDbType.Double);
                Npgsql.NpgsqlParameter pr_x_jmeno = cm.Parameters.Add("x_jmeno", NpgsqlTypes.NpgsqlDbType.Varchar);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCompany)
                    {
                        pr_x_ico.Value = item.Ids;
                        pr_name.Value = item.Name;
                        pr_currency.Value = GetCurrencyOdoo(item);
                        pr_phone.Value = item.Partner.Tel;
                        pr_email.Value = item.Partner.Email;
                        pr_company_registry.Value = item.Partner.DIC;
                        pr_FDay.Value = item.FiscalyearLastDay;
                        pr_DMonth.Value = item.FiscalyearLastMonth;
                        pr_manufacturing_lead.Value = item.ManufacturingLead;
                        pr_PoLead.Value = item.PoLead;
                        pr_SecLead.Value = item.SecurityLead;
                        pr_x_jmeno.Value = item.Partner.Jmeno;
                        item.Partner.Srv = item.Srv;
                        item.Partner.Base = item.Base;
                        item.Partner.IsCompany = true;
                        item.Partner.Create();
                        pr_partner.Value = item.Partner.Id;
                        object o1 = cm.ExecuteScalar();
                        item.Id = (int)((long)o1);
                        item.Partner.IdCompany = item.Id;
                        //foreach (PartnerBank pb in item.Partner.CollectionUcet)
                        //{
                        //    pb.IdPartner = item.Partner.Id;
                        //    pb.Srv = item.Srv;
                        //    pb.Base = item.Base;
                        //    pb.Create();
                        //}
                    }
                }
                else
                {
                    pr_x_ico.Value = this.Ids;
                    pr_name.Value = this.Name;
                    pr_currency.Value = GetCurrencyOdoo(this);
                    pr_phone.Value = this.Partner.Tel;
                    pr_email.Value = this.Partner.Email;
                    pr_company_registry.Value = this.Partner.DIC;
                    pr_FDay.Value = this.FiscalyearLastDay;
                    pr_DMonth.Value = this.FiscalyearLastMonth;
                    pr_manufacturing_lead.Value = this.ManufacturingLead;
                    pr_PoLead.Value = this.PoLead;
                    pr_SecLead.Value = this.SecurityLead;
                    pr_x_jmeno.Value = this.Partner.Jmeno;
                    this.Partner.Srv = this.Srv;
                    this.Partner.Base = this.Base;
                    this.Partner.IsCompany = true;
                    this.Partner.Create();
                    pr_partner.Value = this.Partner.Id;
                    object o1 = cm.ExecuteScalar();
                    this.Id = (int)((long)o1);
                    this.Partner.IdCompany = this.Id;
                    //foreach (PartnerBank pb in this.Partner.CollectionUcet)
                    //{
                    //    pb.IdPartner = this.Partner.Id;
                    //    pb.Srv = this.Srv;
                    //    pb.Base = this.Base;
                    //    pb.Create();
                    //}
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(15)]
        protected override void UpdatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET " +
                        @" x_ico = @x_ico, name = @name, currency_id = @currency_id, phone = @phone, email = @email, company_registry = @company_registry, " +
                        @" fiscalyear_last_day = @fiscalyear_last_day, fiscalyear_last_month = @fiscalyear_last_month, manufacturing_lead = @manufacturing_lead,  " +
                        @" po_lead = @po_lead, security_lead = @security_lead, x_jmeno = @x_jmeno " +
                    //    @" , street = @street, zip = @zip, mobile = @mobile, website = @website, city = @city, comment = @comment  " +
                        @" WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_x_ico = cm.Parameters.Add("x_ico", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_currency = cm.Parameters.Add("currency_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_phone = cm.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_email = cm.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_company_registry = cm.Parameters.Add("company_registry", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_FDay = cm.Parameters.Add("fiscalyear_last_day", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_DMonth = cm.Parameters.Add("fiscalyear_last_month", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_manufacturing_lead = cm.Parameters.Add("manufacturing_lead", NpgsqlTypes.NpgsqlDbType.Double);
                Npgsql.NpgsqlParameter pr_PoLead = cm.Parameters.Add("po_lead", NpgsqlTypes.NpgsqlDbType.Double);
                Npgsql.NpgsqlParameter pr_SecLead = cm.Parameters.Add("security_lead", NpgsqlTypes.NpgsqlDbType.Double);
                Npgsql.NpgsqlParameter pr_x_jmeno = cm.Parameters.Add("x_jmeno", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCompany)
                    {
                        pr_x_ico.Value = item.Ids;
                        pr_name.Value = item.Name;
                        pr_currency.Value = GetCurrencyOdoo(item);
                        pr_phone.Value = item.Partner.Tel;
                        pr_email.Value = item.Partner.Email;
                        pr_company_registry.Value = item.Partner.DIC;
                        pr_FDay.Value = item.FiscalyearLastDay;
                        pr_DMonth.Value = item.FiscalyearLastMonth;
                        pr_manufacturing_lead.Value = item.ManufacturingLead;
                        pr_PoLead.Value = item.PoLead;
                        pr_SecLead.Value = item.SecurityLead;
                        pr_x_jmeno.Value = item.Partner.Jmeno;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                        item.Partner.Srv = item.Srv;
                        item.Partner.Update();
                    }
                }
                else
                {
                    pr_x_ico.Value = this.Ids;
                    pr_name.Value = this.Name;
                    pr_currency.Value = GetCurrencyOdoo(this);
                    pr_phone.Value = this.Partner.Tel;
                    pr_email.Value = this.Partner.Email;
                    pr_company_registry.Value = this.Partner.DIC;
                    pr_FDay.Value = this.FiscalyearLastDay;
                    pr_DMonth.Value = this.FiscalyearLastMonth;
                    pr_manufacturing_lead.Value = this.ManufacturingLead;
                    pr_PoLead.Value = this.PoLead;
                    pr_SecLead.Value = this.SecurityLead;
                    pr_x_jmeno.Value = this.Partner.Jmeno;
                    pr_Id.Value = this.Id;
                    cm.ExecuteNonQuery();
                    this.Partner.Srv = this.Srv;
                    this.Partner.Update();
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(16)]
        protected override void DeletePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"DELETE FROM {0} WHERE (id = @id)", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
                this.Id = 0;
                this.Ids = "";
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(17)]
        protected int GetPostgrePartner(int IdCompany)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = "SELECT partner_id FROM res_company WHERE(ID = @id)"
                };
                Npgsql.NpgsqlParameter pr_id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_id.Value = IdCompany;
                n1 = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return n1;
        }
        [NumFunction(18)]
        protected List<int> GetPostgreUsers(int IdCompany)
        {
            List<int> li = new List<int>();
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = "SELECT user_id FROM res_company_users_rel WHERE(cid = @cid)"
                };
                Npgsql.NpgsqlParameter pr_cid = cm.Parameters.Add("cid", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_cid.Value = IdCompany;
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    li.Add((int)dr["user_id"]);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return li;
        }
        #endregion

        #region  ==========  Доп функции  ==========

        private int GetCurrencyOdoo(Company com)
        {
            int o_IdCurrency = 0;
            if (!string.IsNullOrWhiteSpace(com.Partner.Country))
            {
                Country cuu = Tables.Country.GetCountry(com.Srv, com.Base, com.Partner.Country);
                if (cuu.Id != 0)
                {
                    o_IdCurrency = cuu.IdCurrency;
                    com.Partner.IdCountry = cuu.Id;
                }
            }
            return o_IdCurrency;
        }

        private void CollPartBankUpdate(Partner item, Servers sr)
        {
            //if (item.CollectionUcet.Count > 0)
            //{
            List<PartnerBank> li_pb_old = PartnerBank.GetList(sr, item.Base, item.IcoBase, item.Id);
            Dictionary<string, PartnerBank> di_pb_del = new Dictionary<string, PartnerBank>();
            foreach (PartnerBank pb in li_pb_old) di_pb_del.Add(pb.Ids, pb);
            List<PartnerBank> li_edit = new List<PartnerBank>();
            for (int n1 = item.CollectionUcet.Count - 1; n1 >= 0; n1--)
            {
                PartnerBank pb_1;
                if (di_pb_del.TryGetValue(item.CollectionUcet[n1].Ids, out pb_1))
                {
                    PartnerBank pb_2 = item.CollectionUcet[n1];
                    pb_2.Id = pb_1.Id;
                    li_edit.Add(pb_2);
                    di_pb_del.Remove(pb_1.Ids);
                    item.CollectionUcet.RemoveAt(n1);
                }
            }
            foreach (PartnerBank pr in di_pb_del.Values)
            {
                pr.IdPartner = item.Id;
                pr.Srv = sr;
                pr.Base = item.Base;
                pr.IcoBase = item.IcoBase;
                pr.Delete();
            }
            foreach (PartnerBank pr in item.CollectionUcet)
            {
                pr.IdPartner = item.Id;
                pr.Srv = sr;
                pr.Base = item.Base;
                pr.IcoBase = item.IcoBase;
                try
                {
                    pr.Create();
                }
                catch (Exception)
                {
                    string s1 = string.Format("Create ucet. Partner: {0}, ICO: {1}, Ucet: {2}, Name: {3}", item.Name, item.Ids, pr.Ids, pr.Name);
                    FileEventLog.WriteWarting(s1);
                }
            }
            foreach (PartnerBank pr in li_edit)
            {
                pr.IdPartner = item.Id;
                pr.Srv = sr;
                pr.Base = item.Base;
                pr.IcoBase = item.IcoBase;
                pr.Update();
            }
            //}
        }

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список 
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<Company> GetList(Servers Srv, string BaseName)
        {
            List<Company> li = new List<Company>();
            Company bn = new Company(0, Srv, BaseName, "");
            foreach (var item in bn.CollectionCompany)
            {
                if (item.Id == 0) continue;
                li.Add(item);
            }
            return li;
        }

        /// <summary>
        /// Получить информацию о компании по ID
        /// </summary>
        /// <param name="Id">Id компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Company GetCompany(int Id, Servers Srv, string BaseName)
        {
            Company com = new Company(Id, Srv, BaseName, "");
            return com;
        }

        /// <summary>
        /// Получить информацию о компании по Ico 
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Company GetCompany(string Ico, Servers Srv, string BaseName)
        {
            Company com = new Company(Ico, Srv, BaseName, "");
            return com;
        }

        /// <summary>
        /// Кеширование компаний по ICO
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Dictionary<string, Company> GetChashCompanyIco(Servers Srv, string BaseName)
        {
            Company com = new Company(0, Srv, BaseName, "");
            Dictionary<string, Company> di = new Dictionary<string, Company>();
            foreach (Company item in com.CollectionCompany)
            {
                if(!di.TryGetValue(item.Ids, out Company com1))
                {
                    di.Add(item.Ids, com1);
                }
            }
            return di;
        }

        /// <summary>
        /// Кеширование компаний по ICO
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Dictionary<int, Company> GetChashCompanyId(Servers Srv, string BaseName)
        {
            Company com = new Company(0, Srv, BaseName, "");
            Dictionary<int, Company> di = new Dictionary<int, Company>();
            foreach (Company item in com.CollectionCompany)
            {
                di.Add(item.Id, item);
            }
            return di;
        }

        /// <summary>
        /// Быстрый способ получить ICO компании по ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static string GetIcoCompany(int Id, Servers Srv, string BaseName)
        {
            Company com = new Company();
            com.Srv = Srv;
            com.Base = BaseName;
            return com.Load(Id);
        }

        /// <summary>
        /// Быстрый способ получить ID компании по ICO
        /// </summary>
        /// <param name="Ico"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static int GetIdCompany(string Ico, Servers Srv, string BaseName)
        {
            Company com = new Company();
            com.Srv = Srv;
            com.Base = BaseName;
            return com.Load(Ico);
        }

        #endregion
    }
}
