using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Партнёр
    /// </summary>
    [NumClass(41)]
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Ids: {Ids}, Name: {Name}, Coll-Ucet: {CollectionUcet.Count}, Type: {Srv.Type}")]
    public class Partner : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        //public Partner() { }
        public Partner() : base(Actions.SyncPartner) { }
        public Partner(int Id, Models.Servers Server, string BaseData, string IcoBase) : base(Id, Server, BaseData, IcoBase, Actions.SyncPartner)
        {
        }
        /// <summary>
        /// Создать по Cislo
        /// </summary>
        /// <param name="Name">Ids или Cislo</param>
        /// <param name="Server"></param>
        /// <param name="BaseData"></param>
        /// <param name="Ico">Ico базы с которой работаем</param>
        public Partner(string Ico, Models.Servers Server, string BaseData, string IcoBase) : base(Ico, Server, BaseData, IcoBase, Actions.SyncPartner)
        {
        }
        /// <summary>
        /// Создать по имени компании. Для этого надо
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="BaseData"></param>
        /// <param name="PartnerName">Имя компании</param>
        /// <param name="Ico"></param>
        public Partner( Models.Servers Server, string BaseData, string IcoBase, string PartnerName) : base("", Server, BaseData, IcoBase, Actions.SyncPartner, PartnerName)
        {
        }

        #endregion

        #region  ==========  Property  ==========
        /// <summary>
        /// P-DIC , O-x_dic
        /// </summary>
        public string DIC { set; get; }
        /// <summary>
        /// P-Ico , O-vat
        /// </summary>
        public string Cislo { set; get; }
        /// <summary>
        /// P-Jmeno , O-x_jmeno
        /// </summary>
        public string Jmeno { set; get; }
        /// <summary>
        /// P-Ulice , O-street
        /// </summary>
        public string Ulice { set; get; }
        /// <summary>
        /// P-PSC , O-zip  индекс
        /// </summary>
        public string Psc { set; get; }
        /// <summary>
        /// P-Obec , O-city  город
        /// </summary>
        public string Obec { set; get; }
        /// <summary>
        /// P-Tel , O-phone
        /// </summary>
        public string Tel { set; get; }
        /// <summary>
        /// P-GSM , O-mobile  тел. мобильный
        /// </summary>
        public string Gsm { set; get; }
        /// <summary>
        /// P-Email , O-email
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// P-WWW , O-website
        /// </summary>
        public string Www { set; get; }
        /// <summary>
        /// P-Pozn , O-comment
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// P-RefZeme , O-country_id
        /// </summary>
        public int IdCountry { set; get; }
        /// <summary>
        /// P-RefZeme , O-country_id
        /// </summary>
        public string Country { set; get; }
        /// <summary>
        /// P-RelCR , O-
        /// </summary>
        public int RelCR { set; get; }
        public bool IsCompany { set; get; } = false;
        public bool Customer { set; get; } = true;
        public int IdCompany { set; get; } = 0;

        private List<Partner> _CollectionPartner = new List<Partner>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Partner> CollectionPartner { get { return _CollectionPartner; } set { _CollectionPartner = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; }

        /// <summary>
        /// Коллекция дополнительных банков в ODOO. Name = Ucet, Name1 = KodBanky, Id = bank_id
        /// </summary>
        public List<PartnerBank> CollectionUcet { set; get; } = new List<PartnerBank>();

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ico)
        {
            bool IsSelect = true;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                this.Id = 0;
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT a.ID, a.Cislo, a.RelCR, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, " +
                        @" a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme, c.IDS as Country, " +
                        @" a.DIC, a.Ucet, a.KodBanky " +
                        @" FROM {0} AS a LEFT OUTER JOIN sZeme AS c ON a.RefZeme = c.ID order by a.ICO ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT a.ID, a.Cislo, a.RelCR, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, " +
                        @" a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme, c.IDS as Country, " +
                        @" a.DIC, a.Ucet, a.KodBanky " +
                        @" FROM {0} AS a LEFT OUTER JOIN sZeme AS c ON a.RefZeme = c.ID " +
                        @" WHERE (a.ID = @ID)", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ico))
                {
                    cm.CommandText = string.Format(@"SELECT a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, " +
                        @" a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme, c.IDS as Country, " +
                        @" a.RelCR, a.DIC, a.Ucet, a.KodBanky " +
                        @" FROM {0} AS a LEFT OUTER JOIN sZeme AS c ON a.RefZeme = c.ID " +
                        @" WHERE (a.ICO = @ICO)", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                    pr_Kod.Value = Ico;
                }
                else if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    cm.CommandText = string.Format(@"SELECT a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, " +
                        @" a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme, c.IDS as Country, " +
                        @" a.RelCR, a.DIC, a.Ucet, a.KodBanky " +
                        @" FROM {0} AS a LEFT OUTER JOIN sZeme AS c ON a.RefZeme = c.ID " +
                        @" WHERE (a.Firma = @Firma)", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
                    pr_Kod.Value = this.Name;
                }
                else { IsSelect = false; }
                Dictionary<int, List<PartnerBank>> di_pb = PartnerBank.GetChashBankPartner(this.Srv, this.Base, this.IcoBase);
                List<PartnerBank> li_pb;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Partner pr = new Partner();
                    pr.Srv = this.Srv;
                    pr.Base = this.Base;
                    pr.Id = (int)dr["ID"];
                    pr.Cislo = dr["Cislo"] == DBNull.Value ? "" : dr["Cislo"].ToString().Trim();
                    pr.Name = dr["Firma"] == DBNull.Value ? "" : dr["Firma"].ToString().Trim();
                    pr.Jmeno = dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim();
                    pr.Ids = dr["ICO"] == DBNull.Value ? "" : dr["ICO"].ToString().Trim();
                    pr.DIC = dr["DIC"] == DBNull.Value ? "" : dr["DIC"].ToString().Trim();
                    pr.Ulice = dr["Ulice"] == DBNull.Value ? "" : dr["Ulice"].ToString().Trim();
                    pr.Psc = dr["PSC"] == DBNull.Value ? "" : dr["PSC"].ToString().Trim();
                    pr.Obec = dr["Obec"] == DBNull.Value ? "" : dr["Obec"].ToString().Trim();
                    pr.Tel = dr["Tel"] == DBNull.Value ? "" : dr["Tel"].ToString().Trim();
                    pr.Gsm = dr["GSM"] == DBNull.Value ? "" : dr["GSM"].ToString().Trim();
                    pr.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString().Trim();
                    pr.Www = dr["WWW"] == DBNull.Value ? "" : dr["WWW"].ToString().Trim();
                    pr.Remark = dr["Pozn"] == DBNull.Value ? "" : dr["Pozn"].ToString().Trim();
                    string s_Ucet = dr["Ucet"] == DBNull.Value ? "" : dr["Ucet"].ToString().Trim();
                    string s_Kb = dr["KodBanky"] == DBNull.Value ? "" : dr["KodBanky"].ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(s_Ucet))
                    {
                        if (di_pb.TryGetValue(pr.Id, out li_pb)) pr.CollectionUcet = li_pb;
                    }
                    pr.Active = (bool)dr["Sel"];
                    pr.IdCountry = dr["RefZeme"] == DBNull.Value ? 0 : (int)dr["RefZeme"];
                    pr.Country = dr["Country"] == DBNull.Value ? "" : dr["Country"].ToString().Trim();
                    this.CollectionPartner.Add(pr);
                    this.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionPartner.Count != 0)
                {
                    this.Id = this.CollectionPartner[0].Id;
                    this.Ids = this.CollectionPartner[0].Ids;
                    this.Name = this.CollectionPartner[0].Name;
                    this.Jmeno = this.CollectionPartner[0].Jmeno;
                    this.Cislo = this.CollectionPartner[0].Cislo;
                    this.DIC = this.CollectionPartner[0].DIC;
                    this.Ulice = this.CollectionPartner[0].Ulice;
                    this.Psc = this.CollectionPartner[0].Psc;
                    this.Obec = this.CollectionPartner[0].Obec;
                    this.Tel = this.CollectionPartner[0].Tel;
                    this.Gsm = this.CollectionPartner[0].Gsm;
                    this.Email = this.CollectionPartner[0].Email;
                    this.Www = this.CollectionPartner[0].Www;
                    this.Remark = this.CollectionPartner[0].Remark;
                    this.CollectionUcet = this.CollectionPartner[0].CollectionUcet;
                    this.Active = this.CollectionPartner[0].Active;
                    this.IdCountry = this.CollectionPartner[0].IdCountry;
                    this.Country = this.CollectionPartner[0].Country;
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
        [NumFunction(20)]
        protected override string LoadSql(int Id)
        {
            string Ico = "";
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT ICO FROM {0} where ID = @ID", this.PrAction.TableSql)
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
        [NumFunction(21)]
        protected override int LoadSql(string Name)
        {
            int Id = 0;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT ID  FROM {0} where  ICO = @ICO", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Prijmeni = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                pr_Prijmeni.Value = Name;
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
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                this.Id = 0;
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} " +
                        @" (Cislo, Firma, Jmeno, ICO, Ulice, PSC, Obec, Tel, GSM, Email, WWW, Pozn, Sel, RefZeme, " +
                        @" RelCR, DIC, Ucet, KodBanky, Ucetni, Creator) " +
                        @" VALUES (@Cislo, @Firma, @Jmeno, @ICO, @Ulice, @PSC, @Obec, @Tel, @GSM, @Email, @WWW, @Pozn, @Sel, @RefZeme, " +
                        @" @RelCR, @DIC, @Ucet, @KodBanky, @Ucetni, @Creator) ;" +
                        " SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Cislo = cm.Parameters.Add("Cislo", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Firma = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Jmeno = cm.Parameters.Add("Jmeno", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_ICO = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ulice = cm.Parameters.Add("Ulice", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_PSC = cm.Parameters.Add("PSC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Obec = cm.Parameters.Add("Obec", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Tel = cm.Parameters.Add("Tel", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_GSM = cm.Parameters.Add("GSM", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Email = cm.Parameters.Add("Email", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_WWW = cm.Parameters.Add("WWW", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Active = cm.Parameters.Add("Sel", System.Data.SqlDbType.Bit);
                System.Data.SqlClient.SqlParameter pr_RefZeme = cm.Parameters.Add("RefZeme", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RelCR = cm.Parameters.Add("RelCR", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_DIC = cm.Parameters.Add("DIC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucet = cm.Parameters.Add("Ucet", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_KodBanky = cm.Parameters.Add("KodBanky", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_Creator = cm.Parameters.Add("Creator", System.Data.SqlDbType.VarChar);
                pr_Creator.Value = SqlScripts.NameUserCreator;

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPartner)
                    {
                        Cislo cis = Tables.Cislo.GetCislo(Actions.SyncPartner, Srv, Base, IcoBase);
                        pr_Cislo.Value = cis.NewValue;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_Firma.Value = DBNull.Value;
                        else pr_Firma.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                        else pr_Jmeno.Value = item.Jmeno;
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_ICO.Value = DBNull.Value;
                        else pr_ICO.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Ulice)) pr_Ulice.Value = DBNull.Value;
                        else pr_Ulice.Value = item.Ulice;
                        if (string.IsNullOrWhiteSpace(item.Psc)) pr_PSC.Value = DBNull.Value;
                        else pr_PSC.Value = item.Psc;
                        if (string.IsNullOrWhiteSpace(item.Obec)) pr_Obec.Value = DBNull.Value;
                        else pr_Obec.Value = item.Obec;
                        if (string.IsNullOrWhiteSpace(item.Tel)) pr_Tel.Value = DBNull.Value;
                        else pr_Tel.Value = item.Tel;
                        if (string.IsNullOrWhiteSpace(item.Gsm)) pr_GSM.Value = DBNull.Value;
                        else pr_GSM.Value = item.Gsm;
                        if (string.IsNullOrWhiteSpace(item.Email)) pr_Email.Value = DBNull.Value;
                        else pr_Email.Value = item.Email;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_WWW.Value = DBNull.Value;
                        else pr_WWW.Value = item.Www;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_Pozn.Value = DBNull.Value;
                        else pr_Pozn.Value = item.Remark;
                        pr_Active.Value = item.Active;
                        if (item.IdCountry == 0)
                        {
                            if (string.IsNullOrWhiteSpace(item.Country)) pr_RefZeme.Value = DBNull.Value;
                            else pr_RefZeme.Value = Models.Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        else pr_RefZeme.Value = item.IdCountry;
                        pr_RelCR.Value = cis.Id;
                        if (string.IsNullOrWhiteSpace(item.DIC)) pr_DIC.Value = DBNull.Value;
                        else pr_DIC.Value = item.DIC;
                        if (item.CollectionUcet.Count != 0)
                        {
                            if (string.IsNullOrWhiteSpace(item.CollectionUcet[0].Ids)) pr_Ucet.Value = DBNull.Value;
                            else pr_Ucet.Value = item.CollectionUcet[0].Ids;
                            if (string.IsNullOrWhiteSpace(item.CollectionUcet[0].Banky.Ids)) pr_KodBanky.Value = DBNull.Value;
                            else pr_KodBanky.Value = item.CollectionUcet[0].Banky.Ids;
                        }
                        else
                        {
                            pr_Ucet.Value = DBNull.Value;
                            pr_KodBanky.Value = DBNull.Value;
                        }
                        item.Id = (int)cm.ExecuteScalar();
                        cis.Update();
                    }
                }
                else
                {
                    Cislo cis =Tables.Cislo.GetCislo(Actions.SyncPartner, Srv, Base, IcoBase);
                    pr_Cislo.Value = cis.NewValue;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_Firma.Value = DBNull.Value;
                    else pr_Firma.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                    else pr_Jmeno.Value = this.Jmeno;
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_ICO.Value = DBNull.Value;
                    else pr_ICO.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Ulice)) pr_Ulice.Value = DBNull.Value;
                    else pr_Ulice.Value = this.Ulice;
                    if (string.IsNullOrWhiteSpace(this.Psc)) pr_PSC.Value = DBNull.Value;
                    else pr_PSC.Value = this.Psc;
                    if (string.IsNullOrWhiteSpace(this.Obec)) pr_Obec.Value = DBNull.Value;
                    else pr_Obec.Value = this.Obec;
                    if (string.IsNullOrWhiteSpace(this.Tel)) pr_Tel.Value = DBNull.Value;
                    else pr_Tel.Value = this.Tel;
                    if (string.IsNullOrWhiteSpace(this.Gsm)) pr_GSM.Value = DBNull.Value;
                    else pr_GSM.Value = this.Gsm;
                    if (string.IsNullOrWhiteSpace(this.Email)) pr_Email.Value = DBNull.Value;
                    else pr_Email.Value = this.Email;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_WWW.Value = DBNull.Value;
                    else pr_WWW.Value = this.Www;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_Pozn.Value = DBNull.Value;
                    else pr_Pozn.Value = this.Remark;
                    pr_Active.Value = this.Active;
                    if (this.IdCountry == 0)
                    {
                        if (string.IsNullOrWhiteSpace(this.Country)) pr_RefZeme.Value = DBNull.Value;
                        else pr_RefZeme.Value = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    else pr_RefZeme.Value = this.IdCountry;
                    pr_RelCR.Value = cis.Id;
                    if (string.IsNullOrWhiteSpace(this.DIC)) pr_DIC.Value = DBNull.Value;
                    else pr_DIC.Value = this.DIC;
                    if (this.CollectionUcet.Count != 0)
                    {
                        if (string.IsNullOrWhiteSpace(this.CollectionUcet[0].Ids)) pr_Ucet.Value = DBNull.Value;
                        else pr_Ucet.Value = this.CollectionUcet[0].Ids;
                        if (string.IsNullOrWhiteSpace(this.CollectionUcet[0].Banky.Ids)) pr_KodBanky.Value = DBNull.Value;
                        else pr_KodBanky.Value = this.CollectionUcet[0].Banky.Ids;
                    }
                    else
                    {
                        pr_Ucet.Value = DBNull.Value;
                        pr_KodBanky.Value = DBNull.Value;
                    }
                    this.Id = (int)cm.ExecuteScalar();
                    cis.Update();
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
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} " +
                        @" SET Firma = @Firma, Jmeno = @Jmeno, ICO = @ICO, Ulice = @Ulice, PSC = @PSC, Obec = @Obec, " +
                        @" Tel = @Tel, GSM = @GSM, Email = @Email, WWW = @WWW, Pozn = @Pozn, Sel = @Sel, RefZeme = @RefZeme, " +
                        @" DIC = @DIC, Ucet = @Ucet, KodBanky = @KodBanky " +
                        @" WHERE (ID = @ID) ", this.PrAction.TableSql)
                };

                System.Data.SqlClient.SqlParameter pr_Firma = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Jmeno = cm.Parameters.Add("Jmeno", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_ICO = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ulice = cm.Parameters.Add("Ulice", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_PSC = cm.Parameters.Add("PSC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Obec = cm.Parameters.Add("Obec", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Tel = cm.Parameters.Add("Tel", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_GSM = cm.Parameters.Add("GSM", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Email = cm.Parameters.Add("Email", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_WWW = cm.Parameters.Add("WWW", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Active = cm.Parameters.Add("Sel", System.Data.SqlDbType.Bit);
                System.Data.SqlClient.SqlParameter pr_RefZeme = cm.Parameters.Add("RefZeme", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_DIC = cm.Parameters.Add("DIC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucet = cm.Parameters.Add("Ucet", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_KodBanky = cm.Parameters.Add("KodBanky", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPartner)
                    {
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_Firma.Value = DBNull.Value;
                        else pr_Firma.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                        else pr_Jmeno.Value = item.Jmeno;
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_ICO.Value = DBNull.Value;
                        else pr_ICO.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Ulice)) pr_Ulice.Value = DBNull.Value;
                        else pr_Ulice.Value = item.Ulice;
                        if (string.IsNullOrWhiteSpace(item.Psc)) pr_PSC.Value = DBNull.Value;
                        else pr_PSC.Value = item.Psc;
                        if (string.IsNullOrWhiteSpace(item.Obec)) pr_Obec.Value = DBNull.Value;
                        else pr_Obec.Value = item.Obec;
                        if (string.IsNullOrWhiteSpace(item.Tel)) pr_Tel.Value = DBNull.Value;
                        else pr_Tel.Value = item.Tel;
                        if (string.IsNullOrWhiteSpace(item.Gsm)) pr_GSM.Value = DBNull.Value;
                        else pr_GSM.Value = item.Gsm;
                        if (string.IsNullOrWhiteSpace(item.Email)) pr_Email.Value = DBNull.Value;
                        else pr_Email.Value = item.Email;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_WWW.Value = DBNull.Value;
                        else pr_WWW.Value = item.Www;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_Pozn.Value = DBNull.Value;
                        else pr_Pozn.Value = item.Remark;
                        pr_Active.Value = item.Active;
                        if (item.IdCountry == 0)
                        {
                            if (string.IsNullOrWhiteSpace(item.Country)) pr_RefZeme.Value = DBNull.Value;
                            else pr_RefZeme.Value = Models.Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        else pr_RefZeme.Value = item.IdCountry;
                        if (string.IsNullOrWhiteSpace(item.DIC)) pr_DIC.Value = DBNull.Value;
                        else pr_DIC.Value = item.DIC;
                        if (item.CollectionUcet.Count != 0)
                        {
                            if (string.IsNullOrWhiteSpace(item.CollectionUcet[0].Ids)) pr_Ucet.Value = DBNull.Value;
                            else pr_Ucet.Value = item.CollectionUcet[0].Ids;
                            if (string.IsNullOrWhiteSpace(item.CollectionUcet[0].Banky.Ids)) pr_KodBanky.Value = DBNull.Value;
                            else pr_KodBanky.Value = item.CollectionUcet[0].Banky.Ids;
                        }
                        else
                        {
                            pr_Ucet.Value = DBNull.Value;
                            pr_KodBanky.Value = DBNull.Value;
                        }
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_Firma.Value = DBNull.Value;
                    else pr_Firma.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                    else pr_Jmeno.Value = this.Jmeno;
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_ICO.Value = DBNull.Value;
                    else pr_ICO.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Ulice)) pr_Ulice.Value = DBNull.Value;
                    else pr_Ulice.Value = this.Ulice;
                    if (string.IsNullOrWhiteSpace(this.Psc)) pr_PSC.Value = DBNull.Value;
                    else pr_PSC.Value = this.Psc;
                    if (string.IsNullOrWhiteSpace(this.Obec)) pr_Obec.Value = DBNull.Value;
                    else pr_Obec.Value = this.Obec;
                    if (string.IsNullOrWhiteSpace(this.Tel)) pr_Tel.Value = DBNull.Value;
                    else pr_Tel.Value = this.Tel;
                    if (string.IsNullOrWhiteSpace(this.Gsm)) pr_GSM.Value = DBNull.Value;
                    else pr_GSM.Value = this.Gsm;
                    if (string.IsNullOrWhiteSpace(this.Email)) pr_Email.Value = DBNull.Value;
                    else pr_Email.Value = this.Email;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_WWW.Value = DBNull.Value;
                    else pr_WWW.Value = this.Www;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_Pozn.Value = DBNull.Value;
                    else pr_Pozn.Value = this.Remark;
                    pr_Active.Value = this.Active;
                    if (this.IdCountry == 0)
                    {
                        if (string.IsNullOrWhiteSpace(this.Country)) pr_RefZeme.Value = DBNull.Value;
                        else pr_RefZeme.Value = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    else pr_RefZeme.Value = this.IdCountry;
                    if (string.IsNullOrWhiteSpace(this.DIC)) pr_DIC.Value = DBNull.Value;
                    else pr_DIC.Value = this.DIC;
                    if (this.CollectionUcet.Count != 0)
                    {
                        if (string.IsNullOrWhiteSpace(this.CollectionUcet[0].Ids)) pr_Ucet.Value = DBNull.Value;
                        else pr_Ucet.Value = this.CollectionUcet[0].Ids;
                        if (string.IsNullOrWhiteSpace(this.CollectionUcet[0].Banky.Ids)) pr_KodBanky.Value = DBNull.Value;
                        else pr_KodBanky.Value = this.CollectionUcet[0].Banky.Ids;
                    }
                    else
                    {
                        pr_Ucet.Value = DBNull.Value;
                        pr_KodBanky.Value = DBNull.Value;
                    }
                    pr_Id.Value = this.Id;
                    cm.ExecuteNonQuery();
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
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"DELETE FROM {0} WHERE (ID = @ID)", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
                this.Id = 0;
                this.Name = "";
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
        #endregion

        #region  ==========  Pohoda  ==========
        [NumFunction(5)]
        protected override void LoadPohoda(int Id, string Ico)
        {
            try
            {
                Pohoda.Xml.FilterGet flt = new Pohoda.Xml.FilterGet();
                flt.Id = Id;
                flt.Company = this.Name;
                flt.Ico = Ico;
                Pohoda.Xml.Document doc = new Pohoda.Xml.Document(this.Base, this.IcoBase, Srv.PohodaPath, Srv.PublicPath, Srv.PohodaUser, Srv.PohodaPassword);
                Pohoda.Xml.ReturnDocXml rp = doc.GetAddressBook(flt);
                GetMessage(rp);
                if (rp.State == Pohoda.Xml.enumState.error)
                {
                    throw new Exception(rp.Message);
                }
                if (this.CollectionPartner == null) this.CollectionPartner = new List<Partner>();
                Dictionary<int, List<PartnerBank>> di_pb = PartnerBank.GetChashBankPartner(this.Srv, this.Base, this.IcoBase);
                List<PartnerBank> li_pb;
                foreach (var item in rp.Packet.responsePackItem)
                {
                    foreach (var item1 in item.Items)
                    {
                        Pohoda.Xml.Packet.ListAddressBook li_adr = item1 as Pohoda.Xml.Packet.ListAddressBook;
                        if (li_adr != null)
                        {
                            foreach (var item2 in li_adr.addressbook)
                            {
                                Partner pr = ConvertToPartner(item2);
                                if (di_pb.TryGetValue(pr.Id, out li_pb)) pr.CollectionUcet = li_pb;
                                this.CollectionPartner.Add(pr);
                            }
                        }
                    }
                }
                this.IsRecord = NumberRecord.Many;
                if (CollectionPartner.Count == 1)
                {
                    this.Id = this.CollectionPartner[0].Id;
                    this.Jmeno = this.CollectionPartner[0].Jmeno;
                    this.Cislo = this.CollectionPartner[0].Cislo;
                    this.Ulice = this.CollectionPartner[0].Ulice;
                    this.Psc = this.CollectionPartner[0].Psc;
                    this.Obec = this.CollectionPartner[0].Obec;
                    this.Tel = this.CollectionPartner[0].Tel;
                    this.Gsm = this.CollectionPartner[0].Gsm;
                    this.Email = this.CollectionPartner[0].Email;
                    this.Www = this.CollectionPartner[0].Www;
                    this.Remark = this.CollectionPartner[0].Remark;
                    this.IdCountry = this.CollectionPartner[0].IdCountry;
                    this.Country = this.CollectionPartner[0].Country;
                    this.Active = this.CollectionPartner[0].Active;
                    this.Ids = this.CollectionPartner[0].Ids;
                    this.Name = this.CollectionPartner[0].Name;
                    this.CollectionUcet = this.CollectionPartner[0].CollectionUcet;
                    this.IsRecord = NumberRecord.One;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(6)]
        protected override void CreatePohoda()
        {
            try
            {
                List<Pohoda.Xml.Packet.Addressbook> li = new List<Pohoda.Xml.Packet.Addressbook>();
                foreach (var item in this.CollectionPartner)
                {
                    //if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrWhiteSpace(item.Obec)) continue;
                    //if (string.IsNullOrWhiteSpace(item.Obec)) continue;
                    Pohoda.Xml.Packet.Addressbook adr = item.ConvertToPohoda();
                    li.Add(adr);
                }
                if (li.Count != 0)
                {
                    Pohoda.Xml.Document doc = new Pohoda.Xml.Document(this.Base, this.IcoBase, Srv.PohodaPath, Srv.PublicPath, Srv.PohodaUser, Srv.PohodaPassword);
                    Pohoda.Xml.ReturnDocXml rp = doc.SetAddressBook(li);
                    SetMessage(rp);
                    if (rp.IsSuccess)
                    {
                        object o1 = rp.Packet.responsePackItem[0].Items[0];
                        Pohoda.Xml.Packet.AddressbookResponse abr = rp.Packet.responsePackItem[0].Items[0] as Pohoda.Xml.Packet.AddressbookResponse;
                        if (abr != null)
                        {
                            this.Id = abr.producedDetails.id;
                            this.Ids = abr.producedDetails.number;
                        }
                    }
                    else
                    {
                        throw new Exception(rp.Message);
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(7)]
        protected override void UpdatePohoda()
        {
            try
            {
                List<Pohoda.Xml.Packet.Addressbook> li = new List<Pohoda.Xml.Packet.Addressbook>();
                foreach (var item in this.CollectionPartner)
                {
                    //if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrWhiteSpace(item.Obec)) continue;
                    Pohoda.Xml.Packet.Addressbook adr = item.ConvertToPohoda();
                    li.Add(adr);
                }
                Pohoda.Xml.Document doc = new Pohoda.Xml.Document(this.Base, this.IcoBase, Srv.PohodaPath, Srv.PublicPath, Srv.PohodaUser, Srv.PohodaPassword);
                Pohoda.Xml.ReturnDocXml rp = doc.ChangeAddressBook(Pohoda.Xml.EnumActionType.update, li);
                SetMessage(rp);
                if (rp.IsSuccess)
                {
                    object o1 = rp.Packet.responsePackItem[0].Items[0];
                    Pohoda.Xml.Packet.AddressbookResponse abr = rp.Packet.responsePackItem[0].Items[0] as Pohoda.Xml.Packet.AddressbookResponse;
                    if (abr != null)
                    {
                        this.Id = abr.producedDetails.id;
                        this.Ids = abr.producedDetails.number;
                    }
                }
                else
                {
                    throw new Exception(rp.Message);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(8)]
        protected override void DeletePohoda()
        {
            try
            {
                List<Pohoda.Xml.Packet.Addressbook> li = new List<Pohoda.Xml.Packet.Addressbook>();
                foreach (var item in this.CollectionPartner)
                {
                    Pohoda.Xml.Packet.Addressbook adr = item.ConvertToPohoda();
                    li.Add(adr);
                }
                Pohoda.Xml.Document doc = new Pohoda.Xml.Document(this.Base, this.IcoBase, Srv.PohodaPath, Srv.PublicPath, Srv.PohodaUser, Srv.PohodaPassword);
                Pohoda.Xml.ReturnDocXml rp = doc.ChangeAddressBook(Pohoda.Xml.EnumActionType.delete, li);
                SetMessage(rp);
                if (rp.IsSuccess)
                {
                    object o1 = rp.Packet.responsePackItem[0].Items[0];
                    Pohoda.Xml.Packet.AddressbookResponse abr = rp.Packet.responsePackItem[0].Items[0] as Pohoda.Xml.Packet.AddressbookResponse;
                    if (abr != null)
                    {
                        this.Id = abr.producedDetails.id;
                        this.Ids = abr.producedDetails.number;
                    }
                }
                else
                {
                    throw new Exception(rp.Message);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        #endregion

        #region  ==========  Odoo  ==========
        [NumFunction(9)]
        protected override void LoadOdoo(int Id, string Ico)
        {
            bool IsSelect = true;
            try
            {
                this.Id = 0;
                List<string> li_pole = new List<string> {
                    "id", "country_id", "name", "display_name", "x_jmeno", "vat", "street", "zip",
                    "city", "phone", "mobile", "email", "website", 
                    "comment", 
                    "active",
                    "x_dic",
                    //"bank_account_count", 
                    //"bank_ids"
                         };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ico))
                {
                    odoFiltr.Filter("vat", "=", Ico);
                }
                else if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    odoFiltr.Filter("name", "=", this.Name);
                }
                else { IsSelect = false; }
                odoFiltr.Filter("active", "!=", null);
                this.IsRecord = NumberRecord.Many;
                //  загружаем партнёров
                if (this.CollectionPartner == null) this.CollectionPartner = new List<Partner>();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                Dictionary<int, List<PartnerBank>> di_pb = PartnerBank.GetChashBankPartner(this.Srv, this.Base, this.IcoBase);
                List<PartnerBank> li_pb;
                foreach (var item in Datas)
                {
                    Partner pr = new Partner();
                    pr.PrAction = this.PrAction;
                    pr.Id = int.Parse(item["id"]);
                    pr.Name = item["name"] == "False" ?
                        item["display_name"] == "False" ? "" : item["display_name"].ToString().Trim() :
                        item["name"].ToString().Trim();
                    pr.Jmeno = item["x_jmeno"] == "False" ? "" : item["x_jmeno"].ToString().Trim();
                    pr.Ids = item["vat"] == "False" ? "" : item["vat"].ToString().Trim();
                    pr.DIC = item["x_dic"] == "False" ? "" : item["x_dic"].ToString().Trim();
                    pr.Ulice = item["street"] == "False" ? "" : item["street"].ToString().Trim();
                    pr.Psc = item["zip"] == "False" ? "" : item["zip"].ToString().Trim();
                    pr.Obec = item["city"] == "False" ? "" : item["city"].ToString().Trim();
                    pr.Tel = item["phone"] == "False" ? "" : item["phone"].ToString().Trim();
                    pr.Gsm = item["mobile"] == "False" ? "" : item["mobile"].ToString().Trim();
                    pr.Email = item["email"] == "False" ? "" : item["email"].ToString().Trim();
                    pr.Www = item["website"] == "False" ? "" : item["website"].ToString().Trim();
                    pr.Remark = item["comment"] == "False" ? "" : item["comment"].ToString().Trim();
                    pr.Active = bool.Parse(item["active"]);
                    string s1 = item["country_id"] == "False" ? "0" : item["country_id"];
                    pr.IdCountry = Funcs.ConvertStringToInt.StringOdooToInt(s1);
                    if (pr.IdCountry != 0) pr.Country = Tables.Country.GetCountry(Srv, Base, pr.IdCountry).Ids;
                    else pr.Country = "";
                    s1 = "0";
                    try
                    {
						s1 = item["bank_ids"] == "False" ? "0" : item["bank_ids"];
					}
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    int IdPartnerBank = Funcs.ConvertStringToInt.StringOdooToInt(s1);

                    // s1 = item["bank_ids"] == "False" ? "0" : item["bank_ids"];
                    int BankAccountCount = Funcs.ConvertStringToInt.StringOdooToInt(s1);
                    if (BankAccountCount != 0)
                    {
                        if (di_pb.TryGetValue(pr.Id, out li_pb)) pr.CollectionUcet = li_pb;
                        //pr.CollectionUcet = PartnerBank.GetList(this.Srv, this.Base, this.IcoBase, pr.Id);
                    }
                    this.CollectionPartner.Add(pr);
                }
                if(IsSelect && this.CollectionPartner.Count != 0)
                {
                    Copy(this.CollectionPartner[0]);
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
            string s_firma = "";
            string s_ico = "";
            try
            {
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                    List<Dictionary<string, object>> li_create = new List<Dictionary<string, object>>();
                    foreach (var item in this.CollectionPartner)
                    {
                        s_firma = item.Name;
                        s_ico = item.Ids;
                        if (!string.IsNullOrWhiteSpace(item.Country))
                        {
                            item.IdCountry = Models.Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "display_name", item.Name },
                            { "x_jmeno", item.Jmeno },
                            { "vat", item.Ids },
                            { "street", item.Ulice },
                            { "zip", item.Psc },
                            { "city", item.Obec },
                            { "phone", item.Tel },
                            { "mobile", item.Gsm },
                            { "email", item.Email },
                            { "website", item.Www },
                            { "comment", item.Remark },
                            { "active", true },
                            { "is_company", item.IsCompany },
                            { "x_dic", item.DIC }
                        };
                        if (item.IdCountry != 0) di.Add("country_id", item.IdCountry);
                        ///
                        li_create.Add(di);
                    }
                    odScr.InsertRowPacket(Client, this.PrAction.TableOdoo, li_create);

                    Dictionary<string, PartnerBank> di_ids = PartnerBank.GetChashBankIds(this.Srv, this.Base, this.IcoBase);
                    Dictionary<string, Partner> di_new = Partner.GetChashPartnerIds(this.Srv, this.Base, this.IcoBase);
                    Dictionary<int, List<PartnerBank>> di_bank = PartnerBank.GetChashBankPartner(this.Srv, this.Base, this.IcoBase);
                    foreach (Partner pr in this.CollectionPartner)
                    {
                        if (string.IsNullOrWhiteSpace(pr.Ids)) continue;
                        Partner pr_new;
                        if (di_new.TryGetValue(pr.Ids, out pr_new))
                        {
                            foreach (PartnerBank pb in pr.CollectionUcet)
                            {
                                if (di_ids.ContainsKey(pb.Ids)) continue;
                                pb.IdPartner = pr_new.Id;
                                pb.Srv = this.Srv;
                                pb.Base = this.Base;
                                pb.IcoBase = this.IcoBase;
                                pb.Client = Client;
                                pb.Create();
                                di_ids.Add(pb.Ids, pb);
                            }
                        }
                    }
                }
                else
                {
                    s_firma = this.Name;
                    s_ico = this.Ids;
                    object o1 = null;
                    if (this.IdCountry == 0)
                    {
                        if (!string.IsNullOrWhiteSpace(this.Country))
                        {
                            this.IdCountry = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                            if (this.IdCountry == 0)
                            {
                                FileEventLog.WriteWarting(string.Format("Country not found. Kod: {0}, id: {1} ", this.Country, this.IdCountry));
                            }
                            else o1 = this.IdCountry;
                        }
                    }
                    else o1 = this.IdCountry;
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "display_name", this.Name },
                            { "x_jmeno", this.Jmeno },
                            { "vat", this.Ids },
                            { "street", this.Ulice },
                            { "zip", this.Psc },
                            { "city", this.Obec },
                            { "phone", this.Tel },
                            { "mobile", this.Gsm },
                            { "email", this.Email },
                            { "website", this.Www },
                            { "comment", this.Remark },
                            { "active", this.Active },
                            { "country_id", o1 },
                            { "is_company", this.IsCompany },
                            { "x_dic", this.DIC }
                        };
                    this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
                    // поиск банка
                    //this.PassUcet.IdPartner = this.Id;
                    //this.PassUcet.Create();
                }
            }
            catch (Exception e1)
            {
                Exception e2 = new Exception(string.Format("Firma: {0}, Ico: {1}, Mess: {2}", s_firma, s_ico, e1.Message), e1);
                FileEventLog.WriteErr(this, e2, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e2;
            }
        }
        [NumFunction(11)]
        protected override void UpdateOdoo()
        {
            string s_firma = "";
            string s_ico = "";
            try
            {
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    OdooRpc.CoreCLR.Client.OdooRpcClient client = odScr.OpenConnectOdoo(Srv);
                    foreach (var item in this.CollectionPartner)
                    {
                        s_firma = item.Name;
                        s_ico = item.Ids;
                        if (!string.IsNullOrWhiteSpace(item.Country))
                        {
                            item.IdCountry = Models.Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "display_name", item.Name },
                            { "x_jmeno", item.Jmeno },
                            { "vat", item.Ids },
                            { "street", item.Ulice },
                            { "zip", item.Psc },
                            { "city", item.Obec },
                            { "phone", item.Tel },
                            { "mobile", item.Gsm },
                            { "email", item.Email },
                            { "website", item.Www },
                            { "comment", item.Remark },
                            { "active", true },
                            { "customer", true },
                            { "x_dic", item.DIC }
                        };
                        if (item.IdCountry != 0) di.Add("country_id", item.IdCountry);
                        odScr.UpdateRowPacket(client, item.PrAction.TableOdoo, item.Id, di);
                        // обновление реквизитов
                        CollPartBankUpdate(item);
                    }
                }
                else
                {
                    s_firma = this.Name;
                    s_ico = this.Ids;
                    if (!string.IsNullOrWhiteSpace(this.Country))
                    {
                        this.IdCountry = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "display_name", this.Name },
                            { "x_jmeno", this.Jmeno },
                            { "vat", this.Ids },
                            { "street", this.Ulice },
                            { "zip", this.Psc },
                            { "city", this.Obec },
                            { "phone", this.Tel },
                            { "mobile", this.Gsm },
                            { "email", this.Email },
                            { "website", this.Www },
                            { "comment", this.Remark },
                            { "active", true },
                            { "customer", true },
                            { "x_dic", this.DIC }
                        };
                    if (this.IdCountry != 0) di.Add("country_id", this.IdCountry);
                    odScr.UpdateRow(Srv, this.PrAction.TableOdoo, this.Id, di);
                    // обновление реквизитов
                    CollPartBankUpdate(this);
                }
            }
            catch (Exception e1)
            {
                Exception e2 = new Exception(string.Format("Firma: {0}, Ico: {1}, Mess: {2}", s_firma, s_ico, e1.Message), e1);
                FileEventLog.WriteErr(this, e2, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e2;
            }
        }
        //[NumFunction(17)]
        //public void UpdateOdooCompany(int IdCompany)
        //{
        //    try
        //    {
        //        OdooScripts odScr = new OdooScripts();
        //        Dictionary<string, object> di = new Dictionary<string, object>
        //            {
        //                { "company_id", IdCompany }
        //            };
        //        odScr.UpdateRow(Srv, this.PrAction.TableOdoo, this.Id, di);
        //    }
        //    catch (Exception e1)
        //    {
        //        FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
        //        throw e1;
        //    }
        //}
        [NumFunction(12)]
        protected override void DeleteOdoo()
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                odScr.DeleteRow(Srv, this.PrAction.TableOdoo, this.Id);
                this.Id = 0;
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
                string s_pole = @"p.id, p.country_id, c.code AS country, p.name, p.display_name, p.x_jmeno, p.vat, p.street, p.zip, " +
                        @" p.city, p.phone, p.mobile, p.email, p.website, p.comment, p.active, p.x_dic";
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT {1} FROM {0} p " +
                        @" LEFT OUTER JOIN res_country c ON p.country_id = c.ID " +
                        @" order by p.name", this.PrAction.TablePostgreSql, s_pole)
                };
                if (Id != 0)
                {
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} p " +
                        @" LEFT OUTER JOIN res_country c ON p.country_id = c.ID " +
                        @" WHERE (p.id = @id) ", this.PrAction.TablePostgreSql, s_pole);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ico))
                {
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} p " +
                        @" LEFT OUTER JOIN res_country c ON p.country_id = c.ID " +
                        @" where (p.vat = @vat) ", this.PrAction.TablePostgreSql, s_pole);
                    Npgsql.NpgsqlParameter pr_vat = cm.Parameters.Add("vat", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_vat.Value = Ico;
                }
                else if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} p " +
                        @" LEFT OUTER JOIN res_country c ON p.country_id = c.ID " +
                        @" where (p.name = @Name) ", this.PrAction.TablePostgreSql, s_pole);
                    Npgsql.NpgsqlParameter pr_code = cm.Parameters.Add("Name", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_code.Value = this.Name;
                }
                else { IsSelect = false; }
                Dictionary<int, List<PartnerBank>> di_pb = PartnerBank.GetChashBankPartner(this.Srv, this.Base, this.IcoBase);
                List<PartnerBank> li_pb;
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Partner pr = new Partner();
                    pr.Base = this.Base;
                    pr.IcoBase = this.IcoBase;
                    pr.Srv = this.Srv;
                    pr.Id = (int)dr["id"];
                    pr.Name = dr["name"] == DBNull.Value ?
                        dr["display_name"] == DBNull.Value ? "" : dr["display_name"].ToString().Trim() :
                        dr["name"].ToString().Trim();
                    pr.Jmeno = dr["x_jmeno"] == DBNull.Value ? "" : dr["x_jmeno"].ToString().Trim();
                    pr.Ids = dr["vat"] == DBNull.Value ? "" : dr["vat"].ToString().Trim();
                    pr.DIC = dr["x_dic"] == DBNull.Value ? "" : dr["x_dic"].ToString().Trim();
                    pr.Ulice = dr["street"] == DBNull.Value ? "" : dr["street"].ToString().Trim();
                    pr.Psc = dr["zip"] == DBNull.Value ? "" : dr["zip"].ToString().Trim();
                    pr.Obec = dr["city"] == DBNull.Value ? "" : dr["city"].ToString().Trim();
                    pr.Tel = dr["phone"] == DBNull.Value ? "" : dr["phone"].ToString().Trim();
                    pr.Gsm = dr["mobile"] == DBNull.Value ? "" : dr["mobile"].ToString().Trim();
                    pr.Email = dr["email"] == DBNull.Value ? "" : dr["email"].ToString().Trim();
                    pr.Www = dr["website"] == DBNull.Value ? "" : dr["website"].ToString().Trim();
                    pr.Remark = dr["comment"] == DBNull.Value ? "" : dr["comment"].ToString().Trim();
                    pr.Active = (bool)dr["active"];
                    pr.IdCountry = dr["country_id"] == DBNull.Value ? 0 : (int)dr["country_id"];
                    pr.Country = dr["country"] == DBNull.Value ? "" : dr["Country"].ToString().Trim();
                    if (di_pb.TryGetValue(pr.Id, out li_pb)) pr.CollectionUcet = li_pb;
                    this.CollectionPartner.Add(pr);
                }
                dr.Close();
                if (IsSelect && this.CollectionPartner.Count != 0)
                {
                    this.Id = this.CollectionPartner[0].Id;
                    this.Ids = this.CollectionPartner[0].Ids;
                    this.Name = this.CollectionPartner[0].Name;
                    this.Jmeno = this.CollectionPartner[0].Jmeno;
                    this.Cislo = this.CollectionPartner[0].Cislo;
                    this.DIC = this.CollectionPartner[0].DIC;
                    this.Ulice = this.CollectionPartner[0].Ulice;
                    this.Psc = this.CollectionPartner[0].Psc;
                    this.Obec = this.CollectionPartner[0].Obec;
                    this.Tel = this.CollectionPartner[0].Tel;
                    this.Gsm = this.CollectionPartner[0].Gsm;
                    this.Email = this.CollectionPartner[0].Email;
                    this.Www = this.CollectionPartner[0].Www;
                    this.Remark = this.CollectionPartner[0].Remark;
                    this.Active = this.CollectionPartner[0].Active;
                    this.IdCountry = this.CollectionPartner[0].IdCountry;
                    this.Country = this.CollectionPartner[0].Country;
                    this.CollectionUcet = this.CollectionPartner[0].CollectionUcet;
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
        [NumFunction(22)]
        protected override string LoadPostgre(int Id)
        {
            string Name = "";
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT vat FROM {0} where id = @id", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = Id;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Name = o1.ToString().Trim();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Name;
        }
        [NumFunction(23)]
        protected override int LoadPostgre(string Name)
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
                    CommandText = string.Format(@"SELECT id FROM {0} where vat = @vat", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("vat", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_Id.Value = Name;
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
            string s_Id = "";
            try
            {
                this.Id = 0;
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                string s1 = @"INSERT INTO {0} " +
                        @" (name, display_name, x_jmeno, vat, street, zip, city, phone, mobile, email, website, comment, active, country_id, customer, x_dic, is_company, company_id) " +
                        @" VALUES (@name, @display_name, @jmeno, @vat, @street, @zip, @city, @phone, @mobile, @email, @website, @comment, @active, @country_id, @customer, @x_dic, @is_company , @company_id) " +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ";
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(s1, this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_display_name = cm.Parameters.Add("display_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_jmeno = cm.Parameters.Add("jmeno", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_vat = cm.Parameters.Add("vat", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_street = cm.Parameters.Add("street", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_zip = cm.Parameters.Add("zip", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_city = cm.Parameters.Add("city", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_phone = cm.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_mobile = cm.Parameters.Add("mobile", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_email = cm.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_website = cm.Parameters.Add("website", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_comment = cm.Parameters.Add("comment", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                pr_Active.Value = true;
                Npgsql.NpgsqlParameter pr_country_id = cm.Parameters.Add("country_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_customer = cm.Parameters.Add("customer", NpgsqlTypes.NpgsqlDbType.Boolean);
                Npgsql.NpgsqlParameter pr_x_dic = cm.Parameters.Add("x_dic", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_is_company = cm.Parameters.Add("is_company", NpgsqlTypes.NpgsqlDbType.Boolean);
                Npgsql.NpgsqlParameter pr_company_id = cm.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Dictionary<string, PartnerBank> di_ids = PartnerBank.GetChashBankIds(this.Srv, this.Base, this.IcoBase);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPartner)
                    {
                        s_Id = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_name.Value = DBNull.Value;
                        else pr_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_display_name.Value = DBNull.Value;
                        else pr_display_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Jmeno)) pr_jmeno.Value = DBNull.Value;
                        else pr_jmeno.Value = item.Jmeno;
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_vat.Value = DBNull.Value;
                        else pr_vat.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Ulice)) pr_street.Value = DBNull.Value;
                        else pr_street.Value = item.Ulice;
                        if (string.IsNullOrWhiteSpace(item.Psc)) pr_zip.Value = DBNull.Value;
                        else pr_zip.Value = item.Psc;
                        if (string.IsNullOrWhiteSpace(item.Obec)) pr_city.Value = DBNull.Value;
                        else pr_city.Value = item.Obec;
                        if (string.IsNullOrWhiteSpace(item.Tel)) pr_phone.Value = DBNull.Value;
                        else pr_phone.Value = item.Tel;
                        if (string.IsNullOrWhiteSpace(item.Gsm)) pr_mobile.Value = DBNull.Value;
                        else pr_mobile.Value = item.Gsm;
                        if (string.IsNullOrWhiteSpace(item.Email)) pr_email.Value = DBNull.Value;
                        else pr_email.Value = item.Email;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_website.Value = DBNull.Value;
                        else pr_website.Value = item.Www;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_comment.Value = DBNull.Value;
                        else pr_comment.Value = item.Remark;
                        if (string.IsNullOrWhiteSpace(item.DIC)) pr_x_dic.Value = DBNull.Value;
                        else pr_x_dic.Value = item.DIC;
                        pr_is_company.Value = item.IsCompany;
                        pr_customer.Value = item.Customer;
                        if (item.IdCompany == 0) pr_company_id.Value = DBNull.Value;
                        else pr_company_id.Value = item.IdCompany;
                        if(!string.IsNullOrWhiteSpace(item.Country)) item.IdCountry = Models.Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        if (item.IdCountry == 0) pr_country_id.Value = DBNull.Value;
                        else pr_country_id.Value = item.IdCountry;
                        item.Id = (int)((long)cm.ExecuteScalar());
                        // запись реквизитов
                        foreach (PartnerBank pr in item.CollectionUcet)
                        {
                            if (di_ids.ContainsKey(pr.Ids)) continue;
                            pr.IdPartner = item.Id;
                            pr.Srv = item.Srv;
                            pr.Base = item.Base;
                            pr.IcoBase = item.IcoBase;
                            pr.Create();
                            di_ids.Add(pr.Ids, pr);
                        }
                    }
                }
                else
                {
                    s_Id = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_name.Value = DBNull.Value;
                    else pr_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_display_name.Value = DBNull.Value;
                    else pr_display_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Jmeno)) pr_jmeno.Value = DBNull.Value;
                    else pr_jmeno.Value = this.Jmeno;
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_vat.Value = DBNull.Value;
                    else pr_vat.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Ulice)) pr_street.Value = DBNull.Value;
                    else pr_street.Value = this.Ulice;
                    if (string.IsNullOrWhiteSpace(this.Psc)) pr_zip.Value = DBNull.Value;
                    else pr_zip.Value = this.Psc;
                    if (string.IsNullOrWhiteSpace(this.Obec)) pr_city.Value = DBNull.Value;
                    else pr_city.Value = this.Obec;
                    if (string.IsNullOrWhiteSpace(this.Tel)) pr_phone.Value = DBNull.Value;
                    else pr_phone.Value = this.Tel;
                    if (string.IsNullOrWhiteSpace(this.Gsm)) pr_mobile.Value = DBNull.Value;
                    else pr_mobile.Value = this.Gsm;
                    if (string.IsNullOrWhiteSpace(this.Email)) pr_email.Value = DBNull.Value;
                    else pr_email.Value = this.Email;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_website.Value = DBNull.Value;
                    else pr_website.Value = this.Www;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_comment.Value = DBNull.Value;
                    else pr_comment.Value = this.Remark;
                    if (string.IsNullOrWhiteSpace(this.DIC)) pr_x_dic.Value = DBNull.Value;
                    else pr_x_dic.Value = this.DIC;
                    pr_is_company.Value = this.IsCompany;
                    if (this.IdCompany == 0) pr_company_id.Value = DBNull.Value;
                    else pr_company_id.Value = this.IdCompany;
                    if (!string.IsNullOrWhiteSpace(this.Country)) this.IdCountry = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    if (this.IdCountry == 0) pr_country_id.Value = DBNull.Value;
                    else pr_country_id.Value = this.IdCountry;
                    this.Id = (int)((long)cm.ExecuteScalar());
                    // запись реквизитов
                    foreach (PartnerBank pr in this.CollectionUcet)
                    {
                        if (di_ids.ContainsKey(pr.Ids)) continue;
                        pr.IdPartner = this.Id;
                        pr.Srv = this.Srv;
                        pr.Base = this.Base;
                        pr.IcoBase = this.IcoBase;
                        pr.Create();
                        di_ids.Add(pr.Ids, pr);
                    }
                }
            }
            catch (Exception e1)
            {
                Exception e2 = new Exception("Ico: " + s_Id, e1);
                FileEventLog.WriteErr(this, e2, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e2;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(15)]
        protected override void UpdatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            string s_Id = "";
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} " +
                        @" SET name = @name, display_name = @display_name, x_jmeno = @jmeno, vat = @vat, street = @street, zip = @zip, city = @city, " +        // x_cislo = @cislo, 
                        @" phone = @phone, mobile = @mobile, email = @email, website = @website, comment = @comment, active = @active, " +
                        @" country_id = @country_id, x_dic = @x_dic " +   //  customer = @customer, 
                        @" WHERE(id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_display_name = cm.Parameters.Add("display_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_jmeno = cm.Parameters.Add("jmeno", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_vat = cm.Parameters.Add("vat", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_street = cm.Parameters.Add("street", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_zip = cm.Parameters.Add("zip", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_city = cm.Parameters.Add("city", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_phone = cm.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_mobile = cm.Parameters.Add("mobile", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_email = cm.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_website = cm.Parameters.Add("website", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_comment = cm.Parameters.Add("comment", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                pr_Active.Value = true;
                Npgsql.NpgsqlParameter pr_country_id = cm.Parameters.Add("country_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //Npgsql.NpgsqlParameter pr_customer = cm.Parameters.Add("customer", NpgsqlTypes.NpgsqlDbType.Boolean);
                //pr_customer.Value = true;
                Npgsql.NpgsqlParameter pr_x_dic = cm.Parameters.Add("x_dic", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPartner)
                    {
                        s_Id = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_name.Value = DBNull.Value;
                        else pr_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_display_name.Value = DBNull.Value;
                        else pr_display_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Jmeno)) pr_jmeno.Value = DBNull.Value;
                        else pr_jmeno.Value = item.Jmeno;
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_vat.Value = DBNull.Value;
                        else pr_vat.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Ulice)) pr_street.Value = DBNull.Value;
                        else pr_street.Value = item.Ulice;
                        if (string.IsNullOrWhiteSpace(item.Psc)) pr_zip.Value = DBNull.Value;
                        else pr_zip.Value = item.Psc;
                        if (string.IsNullOrWhiteSpace(item.Obec)) pr_city.Value = DBNull.Value;
                        else pr_city.Value = item.Obec;
                        if (string.IsNullOrWhiteSpace(item.Tel)) pr_phone.Value = DBNull.Value;
                        else pr_phone.Value = item.Tel;
                        if (string.IsNullOrWhiteSpace(item.Gsm)) pr_mobile.Value = DBNull.Value;
                        else pr_mobile.Value = item.Gsm;
                        if (string.IsNullOrWhiteSpace(item.Email)) pr_email.Value = DBNull.Value;
                        else pr_email.Value = item.Email;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_website.Value = DBNull.Value;
                        else pr_website.Value = item.Www;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_comment.Value = DBNull.Value;
                        else pr_comment.Value = item.Remark;
                        if (string.IsNullOrWhiteSpace(item.DIC)) pr_x_dic.Value = DBNull.Value;
                        else pr_x_dic.Value = item.DIC;
                        if (!string.IsNullOrWhiteSpace(item.Country)) item.IdCountry = Models.Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        if (item.IdCountry == 0) pr_country_id.Value = DBNull.Value;
                        else pr_country_id.Value = item.IdCountry;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                        // обновление реквизитов
                        CollPartBankUpdate(item);
                    }
                }
                else
                {
                    s_Id = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_name.Value = DBNull.Value;
                    else pr_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_display_name.Value = DBNull.Value;
                    else pr_display_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Jmeno)) pr_jmeno.Value = DBNull.Value;
                    else pr_jmeno.Value = this.Jmeno;
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_vat.Value = DBNull.Value;
                    else pr_vat.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Ulice)) pr_street.Value = DBNull.Value;
                    else pr_street.Value = this.Ulice;
                    if (string.IsNullOrWhiteSpace(this.Psc)) pr_zip.Value = DBNull.Value;
                    else pr_zip.Value = this.Psc;
                    if (string.IsNullOrWhiteSpace(this.Obec)) pr_city.Value = DBNull.Value;
                    else pr_city.Value = this.Obec;
                    if (string.IsNullOrWhiteSpace(this.Tel)) pr_phone.Value = DBNull.Value;
                    else pr_phone.Value = this.Tel;
                    if (string.IsNullOrWhiteSpace(this.Gsm)) pr_mobile.Value = DBNull.Value;
                    else pr_mobile.Value = this.Gsm;
                    if (string.IsNullOrWhiteSpace(this.Email)) pr_email.Value = DBNull.Value;
                    else pr_email.Value = this.Email;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_website.Value = DBNull.Value;
                    else pr_website.Value = this.Www;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_comment.Value = DBNull.Value;
                    else pr_comment.Value = this.Remark;
                    if (string.IsNullOrWhiteSpace(this.DIC)) pr_x_dic.Value = DBNull.Value;
                    else pr_x_dic.Value = this.DIC;
                    if (!string.IsNullOrWhiteSpace(this.Country)) this.IdCountry = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    if (this.IdCountry == 0) pr_country_id.Value = DBNull.Value;
                    else pr_country_id.Value = this.IdCountry;
                    pr_Id.Value = this.Id;
                    cm.ExecuteNonQuery();
                    // обновление реквизитов
                    CollPartBankUpdate(this);
                }
            }
            catch (Exception e1)
            {
                Exception e2 = new Exception("Ico: " + s_Id, e1);
                FileEventLog.WriteErr(this, e2, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e2;
            }
            finally { cn?.Close(); }
            return;
        }
        //[NumFunction(18)]
        //public void UpdatePostgreCompany(int IdCompany)
        //{
        //    Npgsql.NpgsqlConnection cn = null;
        //    try
        //    {
        //        cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
        //        cn.Open();
        //        Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
        //        {
        //            Connection = cn,
        //            CommandText = string.Format(@"UPDATE {0} " +
        //                @" SET company_id = @company_id " +
        //                @" WHERE(id = @id) ", this.PrAction.TablePostgreSql)
        //        };
        //        Npgsql.NpgsqlParameter pr_company_id = cm.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Varchar);
        //        pr_company_id.Value = IdCompany;
        //        Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
        //        pr_Id.Value = this.Id;
        //    }
        //    catch (Exception e1)
        //    {
        //        FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
        //        throw e1;
        //    }
        //}
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
                this.Name = "";
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        #endregion

        #region  ==========  Разное  ==========

        [NumFunction(17)]
        private Pohoda.Xml.Packet.Addressbook ConvertToPohoda()
        {
            Pohoda.Xml.Packet.Addressbook adr = new Pohoda.Xml.Packet.Addressbook();
            Pohoda.Xml.Packet.AddressBookHeader ah = adr.addressbookHeader;
            ah.id = this.Id;
            ah.number.numberRequested = this.Ids == null ? "" : this.Ids.Trim();
            ah.identity.address.company = this.Name.Trim();
            ah.identity.address.country.ids = this.Country.Trim();
            ah.identity.address.country.id = this.IdCountry;
            ah.email = this.Email.Trim();
            ah.mobil = this.Gsm.Trim();
            ah.identity.address.ico = this.Ids.Trim();
            ah.identity.address.dic = this.DIC.Trim();
            ah.identity.address.name = this.Jmeno.Trim();
            ah.identity.address.city = this.Obec.Trim();
            ah.identity.address.zip = this.Psc.Trim();
            ah.note = this.Remark.Trim();
            ah.phone = this.Tel.Trim();
            ah.identity.address.street = this.Ulice.Trim();
            ah.web = this.Www.Trim();
            foreach (PartnerBank item in this.CollectionUcet)
            {
                adr.addressbookAccount.Add(new Pohoda.Xml.Packet.AccountItem() { accountNumber = item.Ids, bankCode = item.Banky.Ids });
            }
            return adr;
        }

        [NumFunction(18)]
        private Partner ConvertToPartner(Pohoda.Xml.Packet.Addressbook Ab)
        {
            Partner adr = new Partner();
            Pohoda.Xml.Packet.AddressBookHeader ah = Ab.addressbookHeader;
            adr.Id = ah.id;
            adr.Ids = string.IsNullOrWhiteSpace(ah.number.numberRequested) ? "" : ah.number.numberRequested.Trim();
            adr.Name = string.IsNullOrWhiteSpace(ah.identity.address.company) ? "" : ah.identity.address.company.Trim();
            adr.Jmeno = string.IsNullOrWhiteSpace(ah.identity.address.name) ? "" : ah.identity.address.name.Trim();
            adr.Ids = string.IsNullOrWhiteSpace(ah.identity.address.ico) ? "" : ah.identity.address.ico.Trim();
            adr.DIC = string.IsNullOrWhiteSpace(ah.identity.address.dic) ? "" : ah.identity.address.dic.Trim();
            adr.Ulice = string.IsNullOrWhiteSpace(ah.identity.address.street) ? "" : ah.identity.address.street.Trim();
            adr.Psc = string.IsNullOrWhiteSpace(ah.identity.address.zip) ? "" : ah.identity.address.zip.Trim();
            adr.Obec = string.IsNullOrWhiteSpace(ah.identity.address.city) ? "" : ah.identity.address.city.Trim();
            adr.Tel = string.IsNullOrWhiteSpace(ah.phone) ? "" : ah.phone.Trim();
            adr.Gsm = string.IsNullOrWhiteSpace(ah.mobil) ? "" : ah.mobil.Trim();
            adr.Email = string.IsNullOrWhiteSpace(ah.email) ? "" : ah.email.Trim();
            adr.Www = string.IsNullOrWhiteSpace(ah.web) ? "" : ah.web.Trim();
            adr.Remark = string.IsNullOrWhiteSpace(ah.note) ? "" : ah.note.Trim();
            adr.Country = string.IsNullOrWhiteSpace(ah.identity.address.country.ids) ? "" : ah.identity.address.country.ids.Trim();
            adr.IdCountry = ah.identity.address.country.id;
            return adr;
        }

        [NumFunction(19)]
        private void Copy(Partner pr)
        {
            this.Id = pr.Id;
            this.Ids = pr.Ids;
            this.Name = pr.Name;
            this.Jmeno = pr.Jmeno;
            this.Cislo = pr.Cislo;
            this.DIC = pr.DIC;
            this.Ulice = pr.Ulice;
            this.Psc = pr.Psc;
            this.Obec = pr.Obec;
            this.Tel = pr.Tel;
            this.Gsm = pr.Gsm;
            this.Email = pr.Email;
            this.Www = pr.Www;
            this.Remark = pr.Remark;
            this.Active = pr.Active;
            this.IdCountry = pr.IdCountry;
            this.Country = pr.Country;
            this.CollectionUcet = pr.CollectionUcet;
        }

        private void CollPartBankUpdate(Partner item)
        {
            //if (item.CollectionUcet.Count > 0)
            //{
            List<PartnerBank> li_pb_old = PartnerBank.GetList(item.Srv, item.Base, item.IcoBase, item.Id);
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
                pr.Srv = item.Srv;
                pr.Base = item.Base;
                pr.IcoBase = item.IcoBase;
                pr.Delete();
            }
            foreach (PartnerBank pr in item.CollectionUcet)
            {
                pr.IdPartner = item.Id;
                pr.Srv = item.Srv;
                pr.Base = item.Base;
                pr.IcoBase = item.IcoBase;
                try
                {
                    pr.Create();
                }
                catch (Exception e1)
                {
                    string s1 = string.Format("Create ucet. Partner: {0}, ICO: {1}, Ucet: {2}, Name: {3}", item.Name, item.Ids, pr.Ids, pr.Name);
                    FileEventLog.WriteWarting(s1);
                }
            }
            foreach (PartnerBank pr in li_edit)
            {
                pr.IdPartner = item.Id;
                pr.Srv = item.Srv;
                pr.Base = item.Base;
                pr.IcoBase = item.IcoBase;
                pr.Update();
            }
            //}
        }
        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список партнёров
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<Partner> GetList(Servers Srv, string BaseName, string BaseIco = null)
        {
            List<Partner> li = new List<Partner>();
            List<Partner> li_1 = new List<Partner>();
            Dictionary<string, Partner> di = new Dictionary<string, Partner>();
            Partner bn = new Partner(0, Srv, BaseName, BaseIco);
            foreach (var item in bn.CollectionPartner)
            {
                if (item.Id == 0) continue;
                if (string.IsNullOrWhiteSpace(item.Ids)) continue;
                if (!di.ContainsKey(item.Ids)) di.Add(item.Ids, item);
            }
            foreach (var item in di)
            {
                li.Add(item.Value);
            }
            di.Clear();
            foreach (var item in li)
            {
                if (string.IsNullOrWhiteSpace(item.Obec)) continue;
                li_1.Add(item);
            }
            return li_1;
        }

        /// <summary>
        /// Получить партнёра по ID
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public static Partner GetPartner(Servers Srv, string NameBase, int Id, string IcoBase)
        {
            Partner cou = new Partner(Id, Srv, NameBase, IcoBase);
            return cou;
        }
        /// <summary>
        /// Получить партнёра по ICO
        /// </summary>
        /// <param name="Ico">ID</param>
        /// <param name="Srv"></param>
        /// <param name="NameBase">База</param>
        /// <returns></returns>
        public static Partner GetPartner(string Ico, Servers Srv, string NameBase, string IcoBase)
        {
            Partner cou = new Partner(Ico, Srv, NameBase, IcoBase);
            return cou;
        }

        /// <summary>
        /// Получить партнёра по Name (Name)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="PartnerName">Код страны (например: UA)</param>
        /// <returns></returns>
        public static Partner GetPartner(Servers Srv, string NameBase, string IcoBase, string PartnerName)
        {
            Partner cou = new Partner(Srv, NameBase, IcoBase, PartnerName);
            return cou;
        }

        public static Dictionary<string, Partner> GetChashPartnerIds(Servers Srv, string BaseName, string BaseIco)
        {
            Dictionary<string, Partner> di_id = new Dictionary<string, Partner>();
            Partner bn = new Partner(0, Srv, BaseName, BaseIco);
            foreach (Partner pb in bn.CollectionPartner)
            {
                if (string.IsNullOrWhiteSpace(pb.Ids)) continue;
                if (di_id.ContainsKey(pb.Ids)) continue;
                di_id.Add(pb.Ids, pb);
            }
            return di_id;
        }

        public static Dictionary<int, Partner> GetChashPartnerId(Servers Srv, string BaseName, string BaseIco)
        {
            Dictionary<int, Partner> di_id = new Dictionary<int, Partner>();
            Partner bn = new Partner(0, Srv, BaseName, BaseIco);
            foreach (Partner pb in bn.CollectionPartner)
            {
                //if (di_id.ContainsKey(pb.Id)) continue;
                di_id.Add(pb.Id, pb);
            }
            return di_id;
        }

        /// <summary>
        /// Быстрый способ получить ICO Partner по ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static string GetIcoPartner(int Id, Servers Srv, string BaseName)
        {
            Partner com = new Partner();
            com.Srv = Srv;
            com.Base = BaseName;
            return com.Load(Id);
        }

        /// <summary>
        /// Быстрый способ получить ID Partner по ICO
        /// </summary>
        /// <param name="ICO"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static int GetIdPartner(string ICO, Servers Srv, string BaseName)
        {
            Partner com = new Partner();
            com.Srv = Srv;
            com.Base = BaseName;
            return com.Load(ICO);
        }

        /// <summary>
        /// Быстрый способ получить ID Partner по ICO
        /// </summary>
        /// <param name="ICO"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static int GetIdPartnerOrCreate(Partner prt, Servers Srv, string BaseName, string IcoBase)
        {
            int n1;
            if (prt == null)
            {
                return 0;
			}
            else
            {
				n1 = prt.Load(prt.Ids);
				if (n1 == 0)
				{
					prt.Create();
					n1 = prt.Id;
				}
				else prt.Id = n1;
			}
            prt.Srv = Srv;
            prt.Base = BaseName;
            prt.IcoBase = IcoBase;

           
            return n1;
        }

        #endregion
    }
    public class DefaultPartner
    {
        public string Name { private set; get; } = "Synchro partner";
        public string Cislo { private set; get; } = "1-0-0-0";
    }
}
