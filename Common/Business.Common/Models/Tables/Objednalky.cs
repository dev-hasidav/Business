using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    [NumClass(50)]
    [Serializable]
    public class Objednalky : Interfases.BaseModelTable, Interfases.ICompanyUser
    {
        #region  ==========  Constructor  ==========

        public Objednalky() : base(Actions.SyncObjednavky) { }
        public Objednalky(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncObjednavky) { }
        public Objednalky(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncObjednavky) { }

        #endregion

        #region  ==========  Property  ==========

        public string CompanyIco { get; set; }
        public Partner Partners { get; set; }
        public string UserName { get; set; }
        public string CisloZak { set; get; }
        public Cinnost Cin { set; get; }
        public Stredisko Str { set; get; }
        public FormUhrada FormUh { set; get; }
        public string PDoklad { get; set; }
        public DateTime? Datum { set; get; }
        public DateTime? DatOd { set; get; }
        public DateTime? DatDo { set; get; }
        public int RelTpObj { set; get; }
        public Celkems Celkem { set; get; } = new Celkems();
        public string Remark { set; get; }
        public string Remark2 { set; get; }

        private List<Objednalky> _CollectionObjednalky = new List<Objednalky>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Objednalky> CollectionObjednalky { get { return _CollectionObjednalky; } set { _CollectionObjednalky = value; IsRecord = NumberRecord.Many; } }
        public NumberRecord IsRecord { set; get; }

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ids)
        {
            bool IsSelect = true;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT * FROM {0} order by Datum", this.PrAction.TableSql)
            };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM sBanky where IDS = @IDS", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                    pr_IDS.Value = Ids;
                }
                else { IsSelect = false; }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    string s_Cislo = dr["Cislo"] == DBNull.Value ? "" : dr["Cislo"].ToString().Trim();
                    if (string.IsNullOrWhiteSpace(s_Cislo)) continue;
                    Objednalky els = new Objednalky();
                    els.Srv = this.Srv;
                    els.Base = this.Base;
                    els.IcoBase = this.IcoBase;
                    els.Id = (int)dr["ID"];
                    els.Ids = string.Format("{0}_{1}", this.IcoBase, s_Cislo);
                    els.CompanyIco = this.IcoBase;
                    els.UserName = "";
                    els.CisloZak = dr["CisloZAK"] == DBNull.Value ? "" : dr["CisloZAK"].ToString().Trim();
                    els.PDoklad = dr["PDoklad"] == DBNull.Value ? "" : dr["PDoklad"].ToString().Trim();
                    els.Name = dr["SText"] == DBNull.Value ? "" : dr["SText"].ToString().Trim();
                    if (dr["Datum"] != DBNull.Value) els.Datum = (DateTime)dr["Datum"];
                    if (dr["DatOd"] != DBNull.Value) els.DatOd = (DateTime)dr["DatOd"];
                    if (dr["DatDo"] != DBNull.Value) els.DatDo = (DateTime)dr["DatDo"];
                    els.RelTpObj = dr["RelTpObj"] == DBNull.Value ? 0 : (int)dr["RelTpObj"];
                    int n_Cin = dr["RefCin"] == DBNull.Value ? 0 : (int)dr["RefCin"];
                    if (n_Cin != 0) els.Cin = new Cinnost(n_Cin, this.Srv, this.Base, this.IcoBase);
                    int n_Str = dr["RefStr"] == DBNull.Value ? 0 : (int)dr["RefStr"];
                    if (n_Str != 0) els.Str = new Stredisko(n_Str, this.Srv, this.Base, this.IcoBase);
                    int n_FormUh = dr["RelForUh"] == DBNull.Value ? 0 : (int)dr["RelForUh"];
                    if (n_FormUh != 0) els.FormUh = new FormUhrada(n_FormUh, this.Srv, this.Base, this.IcoBase);
                    els.Celkem.Kc0 = dr["Kc0"] == DBNull.Value ? 0 : (decimal)dr["Kc0"];
                    els.Celkem.Kc1 = dr["Kc1"] == DBNull.Value ? 0 : (decimal)dr["Kc1"];
                    els.Celkem.KcDPH1 = dr["KcDPH1"] == DBNull.Value ? 0 : (decimal)dr["KcDPH1"];
                    els.Celkem.Kc2 = dr["Kc2"] == DBNull.Value ? 0 : (decimal)dr["Kc2"];
                    els.Celkem.KcDPH2 = dr["KcDPH2"] == DBNull.Value ? 0 : (decimal)dr["KcDPH2"];
                    els.Celkem.Kc3 = dr["Kc3"] == DBNull.Value ? 0 : (decimal)dr["Kc3"];
                    els.Celkem.KcDPH3 = dr["KcDPH3"] == DBNull.Value ? 0 : (decimal)dr["KcDPH3"];
                    els.Celkem.KcCelkem = dr["KcCelkem"] == DBNull.Value ? 0 : (decimal)dr["KcCelkem"];
                    els.Remark = dr["Pozn"] == DBNull.Value ? "" : dr["Pozn"].ToString().Trim();
                    els.Remark2 = dr["Pozn2"] == DBNull.Value ? "" : dr["Pozn2"].ToString().Trim();
                    int n_Partner = dr["RefAD"] == DBNull.Value ? 0 : (int)dr["RefAD"];
                    if (n_Partner != 0) els.Partners = new Partner(n_Partner, this.Srv, this.Base, this.IcoBase);
                    else
                    {
                        if (els.Partners == null)
                        {
                            els.Partners = new Partner();
                        }
                        els.Partners.Name = dr["Firma"] == DBNull.Value ? "" : dr["Firma"].ToString().Trim();
                        els.Partners.Jmeno = dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim();
                        els.Partners.Ulice = dr["Ulice"] == DBNull.Value ? "" : dr["Ulice"].ToString().Trim();
                        els.Partners.Psc = dr["PSC"] == DBNull.Value ? "" : dr["PSC"].ToString().Trim();
                        els.Partners.Obec = dr["Obec"] == DBNull.Value ? "" : dr["Obec"].ToString().Trim();
                        int n_Zeme = dr["RefZeme"] == DBNull.Value ? 0 : (int)dr["RefZeme"];
                        if (n_Zeme != 0) els.Partners.Country = new Country(n_Zeme, this.Srv, this.Base, this.IcoBase).Ids;
                        els.Partners.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString().Trim();
                        els.Partners.Tel = dr["Tel"] == DBNull.Value ? "" : dr["Tel"].ToString().Trim();
                        els.Partners.Ids = dr["ICO"] == DBNull.Value ? "" : dr["ICO"].ToString().Trim();
                        els.Partners.DIC = dr["DIC"] == DBNull.Value ? "" : dr["DIC"].ToString().Trim();
                        els.Partners.Gsm = dr["GSM"] == DBNull.Value ? "" : dr["GSM"].ToString().Trim();
                    }
                    this.CollectionObjednalky.Add(els);
                }
                dr.Close();
                if (IsSelect && this.CollectionObjednalky.Count != 0)
                {
                    CopyOnly(this.CollectionObjednalky[0]);
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
                        @" (Cislo, RelCR, CisloZAK, PDoklad, SText, Datum, DatOd, DatDo, RelTpObj, RefCin, RefStr, RelForUh, " +
                        @" Kc0, Kc1, KcDPH1, Kc2, KcDPH2, Kc3, KcDPH3, KcCelkem, Pozn, Pozn2, " +
                        @" RefAD, Firma, Jmeno, Ulice, PSC, Obec, RefZeme, Email, Tel, ICO, DIC, GSM) " +
                        @" VALUES (@Cislo, @RelCR, @CisloZAK, @PDoklad, @SText, @Datum, @DatOd, @DatDo, @RelTpObj, @RefCin, @RefStr, @RelForUh, " +
                        @" @Kc0, @Kc1, @KcDPH1, @Kc2, @KcDPH2, @Kc3, @KcDPH3, @KcCelkem, @Pozn, @Pozn2, " +
                        @" @RefAD, @Firma, @Jmeno, @Ulice, @PSC, @Obec, @RefZeme, @Email, @Tel, @ICO, @DIC, @GSM)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Cislo = cm.Parameters.Add("Cislo", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_RelCR = cm.Parameters.Add("RelCR", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_CisloZAK = cm.Parameters.Add("CisloZAK", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_PDoklad = cm.Parameters.Add("PDoklad", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Datum = cm.Parameters.Add("Datum", System.Data.SqlDbType.DateTime);
                System.Data.SqlClient.SqlParameter pr_DatOd = cm.Parameters.Add("DatOd", System.Data.SqlDbType.DateTime);
                System.Data.SqlClient.SqlParameter pr_DatDo = cm.Parameters.Add("DatDo", System.Data.SqlDbType.DateTime);
                System.Data.SqlClient.SqlParameter pr_RelTpObj = cm.Parameters.Add("RelTpObj", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RefCin = cm.Parameters.Add("RefCin", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RefStr = cm.Parameters.Add("RefStr", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RelForUh = cm.Parameters.Add("RelForUh", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Kc0 = cm.Parameters.Add("Kc0", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Kc1 = cm.Parameters.Add("Kc1", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcDPH1 = cm.Parameters.Add("KcDPH1", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Kc2 = cm.Parameters.Add("Kc2", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcDPH2 = cm.Parameters.Add("KcDPH2", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Kc3 = cm.Parameters.Add("Kc3", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcDPH3 = cm.Parameters.Add("KcDPH3", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcCelkem = cm.Parameters.Add("KcCelkem", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn2 = cm.Parameters.Add("Pozn2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_RefAD = cm.Parameters.Add("RefAD", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Firma = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Jmeno = cm.Parameters.Add("Jmeno", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ulice = cm.Parameters.Add("Ulice", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_PSC = cm.Parameters.Add("PSC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Obec = cm.Parameters.Add("Obec", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_RefZeme = cm.Parameters.Add("RefZeme", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Email = cm.Parameters.Add("Email", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Tel = cm.Parameters.Add("Tel", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_ICO = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_DIC = cm.Parameters.Add("DIC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_GSM = cm.Parameters.Add("GSM", System.Data.SqlDbType.VarChar);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionObjednalky)
                    {
                        Cislo cis = Tables.Cislo.GetCislo(item.PrAction.Action, this.Srv, this.Base, this.IcoBase);
                        pr_Cislo.Value = cis.NewValue;
                        pr_RelCR.Value = cis.NowCislo;
                        pr_CisloZAK.Value = item.CisloZak;
                        pr_PDoklad.Value = item.PDoklad;
                        pr_SText.Value = item.Name;
                        if (item.Datum == null) pr_Datum.Value = DBNull.Value;
                        else pr_Datum.Value = item.Datum.Value;
                        if (item.DatOd == null) pr_DatOd.Value = DBNull.Value;
                        else pr_DatOd.Value = item.DatOd.Value;
                        if (item.DatDo == null) pr_DatDo.Value = DBNull.Value;
                        else pr_DatDo.Value = item.DatDo.Value;
                        pr_RelTpObj.Value = item.RelTpObj;
                        item.Cin.GetIdOrCreate(this.Srv);
                        if (item.Cin.Id == 0) pr_RefCin.Value = DBNull.Value;
                        else pr_RefCin.Value = item.Cin.Id;
                        item.Str.GetIdOrCreate(this.Srv);
                        if (item.Str.Id == 0) pr_RefStr.Value = DBNull.Value;
                        else pr_RefStr.Value = item.Str.Id;
                        item.FormUh.GetIdOrCreate(this.Srv);
                        if (item.FormUh.Id == 0) pr_RelForUh.Value = DBNull.Value;
                        else pr_RelForUh.Value = item.FormUh.Id;
                        pr_Kc0.Value = item.Celkem.Kc0;
                        pr_Kc1.Value = item.Celkem.Kc1;
                        pr_KcDPH1.Value = item.Celkem.KcDPH1;
                        pr_Kc2.Value = item.Celkem.Kc2;
                        pr_KcDPH2.Value = item.Celkem.KcDPH2;
                        pr_Kc3.Value = item.Celkem.Kc3;
                        pr_KcDPH3.Value = item.Celkem.KcDPH3;
                        pr_KcCelkem.Value = item.Celkem.KcCelkem;
                        pr_Pozn.Value = item.Remark;
                        pr_Pozn2.Value = item.Remark2;
                        int n_partner = Partner.GetPartner(this.Srv, this.Base, item.Partners.Ids, this.IcoBase).Id;
                        if (n_partner == 0) pr_RefAD.Value = DBNull.Value;
                        else pr_RefAD.Value = n_partner;
                        if (string.IsNullOrWhiteSpace(item.Partners.Name)) pr_Firma.Value = DBNull.Value;
                        else pr_Firma.Value = item.Partners.Name;
                        if (string.IsNullOrWhiteSpace(item.Partners.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                        else pr_Jmeno.Value = item.Partners.Jmeno;
                        if (string.IsNullOrWhiteSpace(item.Partners.Ulice)) pr_Ulice.Value = DBNull.Value;
                        else pr_Ulice.Value = item.Partners.Ulice;
                        if (string.IsNullOrWhiteSpace(item.Partners.Psc)) pr_PSC.Value = DBNull.Value;
                        else pr_PSC.Value = item.Partners.Psc;
                        if (string.IsNullOrWhiteSpace(item.Partners.Obec)) pr_Obec.Value = DBNull.Value;
                        else pr_Obec.Value = item.Partners.Obec;
                        if (string.IsNullOrWhiteSpace(item.Partners.Email)) pr_Email.Value = DBNull.Value;
                        else pr_Email.Value = item.Partners.Email;
                        if (string.IsNullOrWhiteSpace(item.Partners.Tel)) pr_Tel.Value = DBNull.Value;
                        else pr_Tel.Value = item.Partners.Tel;
                        if (string.IsNullOrWhiteSpace(item.Partners.Ids)) pr_ICO.Value = DBNull.Value;
                        else pr_ICO.Value = item.Partners.Ids;
                        if (string.IsNullOrWhiteSpace(item.Partners.DIC)) pr_DIC.Value = DBNull.Value;
                        else pr_DIC.Value = item.Partners.DIC;
                        if (string.IsNullOrWhiteSpace(item.Partners.Gsm)) pr_GSM.Value = DBNull.Value;
                        else pr_GSM.Value = item.Partners.Gsm;
                        if (string.IsNullOrWhiteSpace(item.Partners.Country))
                        {
                            pr_RefZeme.Value = Country.GetCountry(this.Srv, this.Base, item.Partners.Country).Id;
                        }
                        else pr_RefZeme.Value = DBNull.Value;
                        this.Id = (int)cm.ExecuteScalar();
                        cis.Update();
                    }
                }
                else
                {
                    Cislo cis = Tables.Cislo.GetCislo(this.PrAction.Action, this.Srv, this.Base, this.IcoBase);
                    pr_Cislo.Value = cis.NewValue;
                    pr_RelCR.Value = cis.NowCislo;
                    pr_CisloZAK.Value = this.CisloZak;
                    pr_PDoklad.Value = this.PDoklad;
                    pr_SText.Value = this.Name;
                    if (this.Datum == null) pr_Datum.Value = DBNull.Value;
                    else pr_Datum.Value = this.Datum.Value;
                    if (this.DatOd == null) pr_DatOd.Value = DBNull.Value;
                    else pr_DatOd.Value = this.DatOd.Value;
                    if (this.DatDo == null) pr_DatDo.Value = DBNull.Value;
                    else pr_DatDo.Value = this.DatDo.Value;
                    pr_RelTpObj.Value = this.RelTpObj;
                    int n_cin = Cinnost.GetCinnost(this.Srv, this.Base, this.Cin.Ids).Id;
                    if (n_cin == 0) pr_RefCin.Value = DBNull.Value;
                    else pr_RefCin.Value = n_cin;
                    int n_str = Stredisko.GetStredisko(this.Srv, this.Base, this.Str.Ids).Id;
                    if (n_str == 0) pr_RefStr.Value = DBNull.Value;
                    else pr_RefStr.Value = n_str;
                    int n_formuh = FormUhrada.GetFormUhrada(this.Srv, this.Base, this.FormUh.Ids).Id;
                    if (n_formuh == 0) pr_RelForUh.Value = DBNull.Value;
                    else pr_RelForUh.Value = n_formuh;
                    pr_Kc0.Value = this.Celkem.Kc0;
                    pr_Kc1.Value = this.Celkem.Kc1;
                    pr_KcDPH1.Value = this.Celkem.KcDPH1;
                    pr_Kc2.Value = this.Celkem.Kc2;
                    pr_KcDPH2.Value = this.Celkem.KcDPH2;
                    pr_Kc3.Value = this.Celkem.Kc3;
                    pr_KcDPH3.Value = this.Celkem.KcDPH3;
                    pr_KcCelkem.Value = this.Celkem.KcCelkem;
                    pr_Pozn.Value = this.Remark;
                    pr_Pozn2.Value = this.Remark2;
                    int n_partner = Partner.GetPartner(this.Srv, this.Base, this.Partners.Ids, this.IcoBase).Id;
                    if (n_partner == 0) pr_RefAD.Value = DBNull.Value;
                    else pr_RefAD.Value = n_partner;
                    if (string.IsNullOrWhiteSpace(this.Partners.Name)) pr_Firma.Value = DBNull.Value;
                    else pr_Firma.Value = this.Partners.Name;
                    if (string.IsNullOrWhiteSpace(this.Partners.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                    else pr_Jmeno.Value = this.Partners.Jmeno;
                    if (string.IsNullOrWhiteSpace(this.Partners.Ulice)) pr_Ulice.Value = DBNull.Value;
                    else pr_Ulice.Value = this.Partners.Ulice;
                    if (string.IsNullOrWhiteSpace(this.Partners.Psc)) pr_PSC.Value = DBNull.Value;
                    else pr_PSC.Value = this.Partners.Psc;
                    if (string.IsNullOrWhiteSpace(this.Partners.Obec)) pr_Obec.Value = DBNull.Value;
                    else pr_Obec.Value = this.Partners.Obec;
                    if (string.IsNullOrWhiteSpace(this.Partners.Email)) pr_Email.Value = DBNull.Value;
                    else pr_Email.Value = this.Partners.Email;
                    if (string.IsNullOrWhiteSpace(this.Partners.Tel)) pr_Tel.Value = DBNull.Value;
                    else pr_Tel.Value = this.Partners.Tel;
                    if (string.IsNullOrWhiteSpace(this.Partners.Ids)) pr_ICO.Value = DBNull.Value;
                    else pr_ICO.Value = this.Partners.Ids;
                    if (string.IsNullOrWhiteSpace(this.Partners.DIC)) pr_DIC.Value = DBNull.Value;
                    else pr_DIC.Value = this.Partners.DIC;
                    if (string.IsNullOrWhiteSpace(this.Partners.Gsm)) pr_GSM.Value = DBNull.Value;
                    else pr_GSM.Value = this.Partners.Gsm;
                    if (string.IsNullOrWhiteSpace(this.Partners.Country))
                    {
                        pr_RefZeme.Value = Country.GetCountry(this.Srv, this.Base, this.Partners.Country).Id;
                    }
                    else pr_RefZeme.Value = DBNull.Value;
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
                        @" SET CisloZAK = @CisloZAK, PDoklad = @PDoklad, SText = @SText, Datum = @Datum, DatOd = @DatOd, DatDo = @DatDo, " +
                        @" RelTpObj = @RelTpObj, RefCin = @RefCin, RefStr = @RefStr, RelForUh = @RelForUh, Pozn = @Pozn, Pozn2 = @Pozn2, " +
                        @" Kc0 = @Kc0, Kc1 = @Kc1, KcDPH1 = @KcDPH1, Kc2 = @Kc2, KcDPH2 = @KcDPH2, Kc3 = @Kc3, KcDPH3 = @KcDPH3, KcCelkem = @KcCelkem, " +
                        @" RefAD = @RefAD, Firma = @Firma, Jmeno = @Jmeno, Ulice = @Ulice, PSC = @PSC, Obec = @Obec, RefZeme = @RefZeme, " +
                        @" Email = @Email, Tel = @Tel, ICO = @ICO, DIC = @DIC, GSM = @GSM " +
                        @" WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_CisloZAK = cm.Parameters.Add("CisloZAK", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_PDoklad = cm.Parameters.Add("PDoklad", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Datum = cm.Parameters.Add("Datum", System.Data.SqlDbType.DateTime);
                System.Data.SqlClient.SqlParameter pr_DatOd = cm.Parameters.Add("DatOd", System.Data.SqlDbType.DateTime);
                System.Data.SqlClient.SqlParameter pr_DatDo = cm.Parameters.Add("DatDo", System.Data.SqlDbType.DateTime);
                System.Data.SqlClient.SqlParameter pr_RelTpObj = cm.Parameters.Add("RelTpObj", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RefCin = cm.Parameters.Add("RefCin", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RefStr = cm.Parameters.Add("RefStr", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_RelForUh = cm.Parameters.Add("RelForUh", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Kc0 = cm.Parameters.Add("Kc0", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Kc1 = cm.Parameters.Add("Kc1", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcDPH1 = cm.Parameters.Add("KcDPH1", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Kc2 = cm.Parameters.Add("Kc2", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcDPH2 = cm.Parameters.Add("KcDPH2", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Kc3 = cm.Parameters.Add("Kc3", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcDPH3 = cm.Parameters.Add("KcDPH3", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_KcCelkem = cm.Parameters.Add("KcCelkem", System.Data.SqlDbType.Decimal);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn2 = cm.Parameters.Add("Pozn2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_RefAD = cm.Parameters.Add("RefAD", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Firma = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Jmeno = cm.Parameters.Add("Jmeno", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ulice = cm.Parameters.Add("Ulice", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_PSC = cm.Parameters.Add("PSC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Obec = cm.Parameters.Add("Obec", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_RefZeme = cm.Parameters.Add("RefZeme", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Email = cm.Parameters.Add("Email", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Tel = cm.Parameters.Add("Tel", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_ICO = cm.Parameters.Add("ICO", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_DIC = cm.Parameters.Add("DIC", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_GSM = cm.Parameters.Add("GSM", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionObjednalky)
                    {
                        pr_CisloZAK.Value = item.CisloZak;
                        pr_PDoklad.Value = item.PDoklad;
                        pr_SText.Value = item.Name;
                        if (item.Datum == null) pr_Datum.Value = DBNull.Value;
                        else pr_Datum.Value = item.Datum.Value;
                        if (item.DatOd == null) pr_DatOd.Value = DBNull.Value;
                        else pr_DatOd.Value = item.DatOd.Value;
                        if (item.DatDo == null) pr_DatDo.Value = DBNull.Value;
                        else pr_DatDo.Value = item.DatDo.Value;
                        pr_RelTpObj.Value = item.RelTpObj;
                        int n_cin = Cinnost.GetCinnost(this.Srv, this.Base, item.Cin.Ids).Id;
                        if (n_cin == 0) pr_RefCin.Value = DBNull.Value;
                        else pr_RefCin.Value = n_cin;
                        int n_str = Stredisko.GetStredisko(this.Srv, this.Base, item.Str.Ids).Id;
                        if (n_str == 0) pr_RefStr.Value = DBNull.Value;
                        else pr_RefStr.Value = n_str;
                        int n_formuh = FormUhrada.GetFormUhrada(this.Srv, this.Base, item.FormUh.Ids).Id;
                        if (n_formuh == 0) pr_RelForUh.Value = DBNull.Value;
                        else pr_RelForUh.Value = n_formuh;
                        pr_Kc0.Value = item.Celkem.Kc0;
                        pr_Kc1.Value = item.Celkem.Kc1;
                        pr_KcDPH1.Value = item.Celkem.KcDPH1;
                        pr_Kc2.Value = item.Celkem.Kc2;
                        pr_KcDPH2.Value = item.Celkem.KcDPH2;
                        pr_Kc3.Value = item.Celkem.Kc3;
                        pr_KcDPH3.Value = item.Celkem.KcDPH3;
                        pr_KcCelkem.Value = item.Celkem.KcCelkem;
                        pr_Pozn.Value = item.Remark;
                        pr_Pozn2.Value = item.Remark2;
                        int n_partner = Partner.GetPartner(this.Srv, this.Base, item.Partners.Ids, this.IcoBase).Id;
                        if (n_partner == 0) pr_RefAD.Value = DBNull.Value;
                        else pr_RefAD.Value = n_partner;
                        if (string.IsNullOrWhiteSpace(item.Partners.Name)) pr_Firma.Value = DBNull.Value;
                        else pr_Firma.Value = item.Partners.Name;
                        if (string.IsNullOrWhiteSpace(item.Partners.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                        else pr_Jmeno.Value = item.Partners.Jmeno;
                        if (string.IsNullOrWhiteSpace(item.Partners.Ulice)) pr_Ulice.Value = DBNull.Value;
                        else pr_Ulice.Value = item.Partners.Ulice;
                        if (string.IsNullOrWhiteSpace(item.Partners.Psc)) pr_PSC.Value = DBNull.Value;
                        else pr_PSC.Value = item.Partners.Psc;
                        if (string.IsNullOrWhiteSpace(item.Partners.Obec)) pr_Obec.Value = DBNull.Value;
                        else pr_Obec.Value = item.Partners.Obec;
                        if (string.IsNullOrWhiteSpace(item.Partners.Email)) pr_Email.Value = DBNull.Value;
                        else pr_Email.Value = item.Partners.Email;
                        if (string.IsNullOrWhiteSpace(item.Partners.Tel)) pr_Tel.Value = DBNull.Value;
                        else pr_Tel.Value = item.Partners.Tel;
                        if (string.IsNullOrWhiteSpace(item.Partners.Ids)) pr_ICO.Value = DBNull.Value;
                        else pr_ICO.Value = item.Partners.Ids;
                        if (string.IsNullOrWhiteSpace(item.Partners.DIC)) pr_DIC.Value = DBNull.Value;
                        else pr_DIC.Value = item.Partners.DIC;
                        if (string.IsNullOrWhiteSpace(item.Partners.Gsm)) pr_GSM.Value = DBNull.Value;
                        else pr_GSM.Value = item.Partners.Gsm;
                        if (string.IsNullOrWhiteSpace(item.Partners.Country))
                        {
                            pr_RefZeme.Value = Country.GetCountry(this.Srv, this.Base, item.Partners.Country).Id;
                        }
                        else pr_RefZeme.Value = DBNull.Value;
                        pr_Id.Value = Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_CisloZAK.Value = this.CisloZak;
                    pr_PDoklad.Value = this.PDoklad;
                    pr_SText.Value = this.Name;
                    if (this.Datum == null) pr_Datum.Value = DBNull.Value;
                    else pr_Datum.Value = this.Datum.Value;
                    if (this.DatOd == null) pr_DatOd.Value = DBNull.Value;
                    else pr_DatOd.Value = this.DatOd.Value;
                    if (this.DatDo == null) pr_DatDo.Value = DBNull.Value;
                    else pr_DatDo.Value = this.DatDo.Value;
                    pr_RelTpObj.Value = this.RelTpObj;
                    int n_cin = Cinnost.GetCinnost(this.Srv, this.Base, this.Cin.Ids).Id;
                    if (n_cin == 0) pr_RefCin.Value = DBNull.Value;
                    else pr_RefCin.Value = n_cin;
                    int n_str = Stredisko.GetStredisko(this.Srv, this.Base, this.Str.Ids).Id;
                    if (n_str == 0) pr_RefStr.Value = DBNull.Value;
                    else pr_RefStr.Value = n_str;
                    int n_formuh = FormUhrada.GetFormUhrada(this.Srv, this.Base, this.FormUh.Ids).Id;
                    if (n_formuh == 0) pr_RelForUh.Value = DBNull.Value;
                    else pr_RelForUh.Value = n_formuh;
                    pr_Kc0.Value = this.Celkem.Kc0;
                    pr_Kc1.Value = this.Celkem.Kc1;
                    pr_KcDPH1.Value = this.Celkem.KcDPH1;
                    pr_Kc2.Value = this.Celkem.Kc2;
                    pr_KcDPH2.Value = this.Celkem.KcDPH2;
                    pr_Kc3.Value = this.Celkem.Kc3;
                    pr_KcDPH3.Value = this.Celkem.KcDPH3;
                    pr_KcCelkem.Value = this.Celkem.KcCelkem;
                    pr_Pozn.Value = this.Remark;
                    pr_Pozn2.Value = this.Remark2;
                    int n_partner = Partner.GetPartner(this.Srv, this.Base, this.Partners.Ids, this.IcoBase).Id;
                    if (n_partner == 0) pr_RefAD.Value = DBNull.Value;
                    else pr_RefAD.Value = n_partner;
                    if (string.IsNullOrWhiteSpace(this.Partners.Name)) pr_Firma.Value = DBNull.Value;
                    else pr_Firma.Value = this.Partners.Name;
                    if (string.IsNullOrWhiteSpace(this.Partners.Jmeno)) pr_Jmeno.Value = DBNull.Value;
                    else pr_Jmeno.Value = this.Partners.Jmeno;
                    if (string.IsNullOrWhiteSpace(this.Partners.Ulice)) pr_Ulice.Value = DBNull.Value;
                    else pr_Ulice.Value = this.Partners.Ulice;
                    if (string.IsNullOrWhiteSpace(this.Partners.Psc)) pr_PSC.Value = DBNull.Value;
                    else pr_PSC.Value = this.Partners.Psc;
                    if (string.IsNullOrWhiteSpace(this.Partners.Obec)) pr_Obec.Value = DBNull.Value;
                    else pr_Obec.Value = this.Partners.Obec;
                    if (string.IsNullOrWhiteSpace(this.Partners.Email)) pr_Email.Value = DBNull.Value;
                    else pr_Email.Value = this.Partners.Email;
                    if (string.IsNullOrWhiteSpace(this.Partners.Tel)) pr_Tel.Value = DBNull.Value;
                    else pr_Tel.Value = this.Partners.Tel;
                    if (string.IsNullOrWhiteSpace(this.Partners.Ids)) pr_ICO.Value = DBNull.Value;
                    else pr_ICO.Value = this.Partners.Ids;
                    if (string.IsNullOrWhiteSpace(this.Partners.DIC)) pr_DIC.Value = DBNull.Value;
                    else pr_DIC.Value = this.Partners.DIC;
                    if (string.IsNullOrWhiteSpace(this.Partners.Gsm)) pr_GSM.Value = DBNull.Value;
                    else pr_GSM.Value = this.Partners.Gsm;
                    if (string.IsNullOrWhiteSpace(this.Partners.Country))
                    {
                        pr_RefZeme.Value = Country.GetCountry(this.Srv, this.Base, this.Partners.Country).Id;
                    }
                    else pr_RefZeme.Value = DBNull.Value;
                    pr_Id.Value = Id;
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
                pr_Id.Value = Id;
                cm.ExecuteNonQuery();
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
        protected override void LoadOdoo(int Id, string Ids)
        {
            bool IsSelect = true;
            try
            {
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
                List<string> li_pole = new List<string>
                {
                    "id", "name", "x_ico_cislo", "company_id", "user_id", "opportunity_id", "x_pdoklad", "date_order",
                    "x_cin_id", "x_str_id", "x_formuh_id", "amount_total", "x_remark", "x_remark2", "partner_id"
                };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0) odoFiltr.Filter("id", "=", Id);
                else if (!string.IsNullOrWhiteSpace(Ids)) odoFiltr.Filter("x_ico_cislo", "=", Ids);
                else { IsSelect = false; }
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                this.IsRecord = NumberRecord.Many;
                foreach (var item in Datas)
                {
                    string s_Cislo = item["ico_cislo"] == "False" ? "" : item["ico_cislo"].ToString().Trim();
                    if (string.IsNullOrWhiteSpace(s_Cislo)) continue;
                    Objednalky obj = new Objednalky();
                    obj.Srv = this.Srv;
                    obj.Base = this.Base;
                    obj.IcoBase = this.IcoBase;
                    obj.Id = int.Parse(Datas[0]["id"]);
                    obj.Ids = s_Cislo;
                    int n_comp = int.Parse(Datas[0]["company_id"] == "False" ? "0" : Datas[0]["company_id"]);
                    obj.CompanyIco = Company.GetCompany(n_comp, this.Srv, this.Base).Ids;
                    int n_usr = Funcs.ConvertStringToInt.StringOdooToInt(Datas[0]["user_id"] == "False" ? "0" : Datas[0]["user_id"]);
                    obj.UserName = User.GetUser(n_usr, this.Srv, this.Base).Ids;
                    int n_zak = Funcs.ConvertStringToInt.StringOdooToInt(Datas[0]["opportunity_id"] == "False" ? "0" : Datas[0]["opportunity_id"]);
                    obj.CisloZak = Zakazka.GetZakazkaFindById(this.Srv, this.Base, n_zak).Ids;
                    obj.PDoklad = Datas[0]["x_pdoklad"] == "False" ? "" : Datas[0]["x_pdoklad"];
                    obj.Name = Datas[0]["name"] == "False" ? "" : Datas[0]["name"];
                    obj.Datum = DateTime.Parse(Datas[0]["active"]);
                    int n_Cin = Funcs.ConvertStringToInt.StringOdooToInt(Datas[0]["RefCin"] == "False" ? "0" : Datas[0]["RefCin"]);
                    if (n_Cin != 0) obj.Cin = new Cinnost(n_Cin, this.Srv, this.Base, this.IcoBase);
                    int n_Str = Funcs.ConvertStringToInt.StringOdooToInt(Datas[0]["RefStr"] == "False" ? "0" : Datas[0]["RefStr"]);
                    if (n_Str != 0) obj.Str = new Stredisko(n_Str, this.Srv, this.Base, this.IcoBase);
                    int n_FormUh = Funcs.ConvertStringToInt.StringOdooToInt(Datas[0]["RelForUh"] == "False" ? "0" : Datas[0]["RelForUh"]);
                    if (n_FormUh != 0) obj.FormUh = new FormUhrada(n_FormUh, this.Srv, this.Base, this.IcoBase);
                    obj.Celkem.KcCelkem= Funcs.ConvertStringToInt.StringOdooToDecimal(Datas[0]["amount_total"] == "False" ? "0" : Datas[0]["amount_total"]);
                    obj.Remark = Datas[0]["x_remark"] == "False" ? "" : Datas[0]["x_remark"];
                    obj.Remark2 = Datas[0]["x_remark2"] == "False" ? "" : Datas[0]["x_remark2"];
                    int n_Partner = Funcs.ConvertStringToInt.StringOdooToInt(Datas[0]["partner_id"] == "False" ? "0" : Datas[0]["partner_id"]);
                    obj.Partners = Partner.GetPartner(this.Srv, this.Base, n_Partner, this.IcoBase);
                    this.CollectionObjednalky.Add(obj);
                }
                if (IsSelect && this.CollectionObjednalky.Count != 0)
                {
                    CopyOnly(this.CollectionObjednalky[0]);
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
            try
            {
                this.Id = 0;
                object o_Company = null;
                object o_Cin = null;
                object o_Str = null;
                object o_FormUh = null;
                object o_Usr = null;
                object o_Zak = null;
                object o_Pr = null;
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                    List<Dictionary<string, object>> li_create = new List<Dictionary<string, object>>();
                    foreach (var item in this.CollectionObjednalky)
                    {
                        int n_comp = Company.GetCompany(item.CompanyIco, this.Srv, this.Base).Id;
                        if (n_comp != 0) o_Company = n_comp;
                        int n_Usr = User.GetUser(item.UserName, this.Srv, this.Base).Id;
                        if (n_Usr != 0) o_Usr = n_Usr;
                        int n_Zak = Zakazka.GetZakazkaFindByCislo(this.Srv, this.Base, item.CisloZak).Id;
                        if (n_Zak != 0) o_Zak = n_Zak;
                        item.Cin.GetIdOrCreate(this.Srv);
                        if (item.Cin.Id != 0) o_Cin = item.Cin.Id;
                        item.Str.GetIdOrCreate(this.Srv);
                        if (item.Str.Id != 0) o_Str = item.Str.Id;
                        item.FormUh.GetIdOrCreate(this.Srv);
                        if (item.FormUh.Id != 0) o_FormUh = item.FormUh.Id;
                        int n_Pr = Partner.GetPartner(item.Partners.Ids, this.Srv, this.Base, this.IcoBase).Id;
                        if (n_Pr != 0) o_Pr = n_Pr;
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico_cislo", item.Ids },
                            { "company_id", o_Company },
                            { "user_id", o_Usr },
                            { "opportunity_id", o_Zak },
                            { "x_pdoklad", item.PDoklad },
                            { "date_order", item.Datum },
                            { "x_cin_id", o_Cin },
                            { "x_str_id", o_Str },
                            { "x_formuh_id", o_FormUh },
                            { "amount_total", item.Celkem.KcCelkem },
                            { "x_remark", item.Remark },
                            { "x_remark2", item.Remark2 },
                            { "partner_id", o_Pr }
                        };
                        item.Id = (int)odScr.InsertRowPacket(Client, this.PrAction.TableOdoo, di);
                    }
                }
                else
                {
                    int n_comp = Company.GetCompany(this.CompanyIco, this.Srv, this.Base).Id;
                    if (n_comp != 0) o_Company = n_comp;
                    int n_Usr = User.GetUser(this.UserName, this.Srv, this.Base).Id;
                    if (n_Usr != 0) o_Usr = n_Usr;
                    int n_Zak = Zakazka.GetZakazkaFindByCislo(this.Srv, this.Base, this.CisloZak).Id;
                    if (n_Zak != 0) o_Zak = n_Zak;
                    if (this.Cin == null)
                    {
                        this.Cin = new Cinnost();
                    }
                    this.Cin.GetIdOrCreate(this.Srv);
                    if (this.Cin.Id != 0) o_Cin = this.Cin.Id;
					if (this.Str == null)
					{
                        this.Str = new Stredisko();
					}
					this.Str.GetIdOrCreate(this.Srv);
                    if (this.Str.Id != 0) o_Str = this.Str.Id;
                    this.FormUh.GetIdOrCreate(this.Srv);
                    if (this.FormUh.Id != 0) o_FormUh = this.FormUh.Id;
                    int n_Pr = Partner.GetPartner(this.Partners.Ids, this.Srv, this.Base, this.IcoBase).Id;
                    if (n_Pr != 0) o_Pr = n_Pr;
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico_cislo", this.Ids },
                            { "company_id", o_Company },
                            { "user_id", o_Usr },
                            { "opportunity_id", o_Zak },
                            { "x_pdoklad", this.PDoklad },
                            { "date_order", this.Datum },
                            { "x_cin_id", o_Cin },
                            { "x_str_id", o_Str },
                            { "x_formuh_id", o_FormUh },
                            { "amount_total", this.Celkem.KcCelkem },
                            { "x_remark", this.Remark },
                            { "x_remark2", this.Remark2 },
                            { "partner_id", o_Pr }
                        };
                    this.Id = (int)odScr.InsertRow(this.Srv, this.PrAction.TableOdoo, di);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(11)]
        protected override void UpdateOdoo()
        {
            try
            {
                this.Id = 0;
                object o_Company = null;
                object o_Cin = null;
                object o_Str = null;
                object o_FormUh = null;
                object o_Usr = null;
                object o_Zak = null;
                object o_Pr = null;
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                    List<Dictionary<string, object>> li_create = new List<Dictionary<string, object>>();
                    foreach (var item in this.CollectionObjednalky)
                    {
                        int n_comp = Company.GetCompany(item.CompanyIco, this.Srv, this.Base).Id;
                        if (n_comp != 0) o_Company = n_comp;
                        int n_Usr = User.GetUser(item.UserName, this.Srv, this.Base).Id;
                        if (n_Usr != 0) o_Usr = n_Usr;
                        int n_Zak = Zakazka.GetZakazkaFindByCislo(this.Srv, this.Base, item.CisloZak).Id;
                        if (n_Zak != 0) o_Zak = n_Zak;
                        item.Cin.GetIdOrCreate(this.Srv);
                        if (item.Cin.Id != 0) o_Cin = item.Cin.Id;
                        item.Str.GetIdOrCreate(this.Srv);
                        if (item.Str.Id != 0) o_Str = item.Str.Id;
                        item.FormUh.GetIdOrCreate(this.Srv);
                        if (item.FormUh.Id != 0) o_FormUh = item.FormUh.Id;
                        int n_Pr = Partner.GetPartner(item.Partners.Ids, this.Srv, this.Base, this.IcoBase).Id;
                        if (n_Pr != 0) o_Pr = n_Pr;
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico_cislo", item.Ids },
                            { "company_id", o_Company },
                            { "user_id", o_Usr },
                            { "opportunity_id", o_Zak },
                            { "x_pdoklad", item.PDoklad },
                            { "date_order", item.Datum },
                            { "x_cin_id", o_Cin },
                            { "x_str_id", o_Str },
                            { "x_formuh_id", o_FormUh },
                            { "amount_total", item.Celkem.KcCelkem },
                            { "x_remark", item.Remark },
                            { "x_remark2", item.Remark2 },
                            { "partner_id", o_Pr }
                        };
                        odScr.UpdateRowPacket(Client, this.PrAction.TableOdoo, item.Id, di);
                    }
                }
                else
                {
                    int n_comp = Company.GetCompany(this.CompanyIco, this.Srv, this.Base).Id;
                    if (n_comp != 0) o_Company = n_comp;
                    int n_Usr = User.GetUser(this.UserName, this.Srv, this.Base).Id;
                    if (n_Usr != 0) o_Usr = n_Usr;
                    int n_Zak = Zakazka.GetZakazkaFindByCislo(this.Srv, this.Base, this.CisloZak).Id;
                    if (n_Zak != 0) o_Zak = n_Zak;
                    this.Cin.GetIdOrCreate(this.Srv);
                    if (this.Cin.Id != 0) o_Cin = this.Cin.Id;
                    this.Str.GetIdOrCreate(this.Srv);
                    if (this.Str.Id != 0) o_Str = this.Str.Id;
                    this.FormUh.GetIdOrCreate(this.Srv);
                    if (this.FormUh.Id != 0) o_FormUh = this.FormUh.Id;
                    int n_Pr = Partner.GetPartner(this.Partners.Ids, this.Srv, this.Base, this.IcoBase).Id;
                    if (n_Pr != 0) o_Pr = n_Pr;
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico_cislo", this.Ids },
                            { "company_id", o_Company },
                            { "user_id", o_Usr },
                            { "opportunity_id", o_Zak },
                            { "x_pdoklad", this.PDoklad },
                            { "date_order", this.Datum },
                            { "x_cin_id", o_Cin },
                            { "x_str_id", o_Str },
                            { "x_formuh_id", o_FormUh },
                            { "amount_total", this.Celkem.KcCelkem },
                            { "x_remark", this.Remark },
                            { "x_remark2", this.Remark2 },
                            { "partner_id", o_Pr }
                        };
                    odScr.UpdateRow(this.Srv, this.PrAction.TableOdoo, this.Id, di);
                }
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
        protected override void LoadPostgre(int Id, string Ids)
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
                    CommandText = string.Format(@"SELECT * FROM {0} order by date_order desc", this.PrAction.TablePostgreSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where x_Ids = @x_Ids", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Ids = cm.Parameters.Add("x_Ids", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_Ids.Value = Ids;
                }
                else { IsSelect = false; }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    string s_Cislo = dr["x_ico_cislo"] == DBNull.Value ? "" : dr["x_ico_cislo"].ToString().Trim();
                    if (string.IsNullOrWhiteSpace(s_Cislo)) continue;
                    Objednalky els = new Objednalky();
                    els.Srv = this.Srv;
                    els.Base = this.Base;
                    els.IcoBase = this.IcoBase;
                    els.Id = (int)dr["ID"];
                    els.Ids = s_Cislo;
                    int n_comp = dr["company_id"] == DBNull.Value ? 0 : (int)dr["company_id"];
                    els.CompanyIco = Company.GetCompany(n_comp, this.Srv, this.Base).Ids;
                    int n_usr = dr["user_id"] == DBNull.Value ? 0 : (int)dr["user_id"];
                    els.UserName = User.GetUser(n_usr, this.Srv, this.Base).Ids;
                    int n_zak = dr["opportunity_id"] == DBNull.Value ? 0 : (int)dr["opportunity_id"];
                    els.CisloZak = Zakazka.GetZakazkaFindById(this.Srv, this.Base, n_zak).Ids;
                    els.PDoklad = dr["x_pdoklad"] == DBNull.Value ? "" : dr["x_pdoklad"].ToString();
                    els.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString();
                    if (dr["date_order"] != DBNull.Value) els.Datum = (DateTime)dr["date_order"];
                    int n_Cin = dr["RefCin"] == DBNull.Value ? 0 : (int)dr["RefCin"];
                    if (n_Cin != 0) els.Cin = new Cinnost(n_Cin, this.Srv, this.Base, this.IcoBase);
                    int n_Str = dr["RefStr"] == DBNull.Value ? 0 : (int)dr["RefStr"];
                    if (n_Str != 0) els.Str = new Stredisko(n_Str, this.Srv, this.Base, this.IcoBase);
                    int n_FormUh = dr["RelForUh"] == DBNull.Value ? 0 : (int)dr["RelForUh"];
                    if (n_FormUh != 0) els.FormUh = new FormUhrada(n_FormUh, this.Srv, this.Base, this.IcoBase);
                    els.Celkem.KcCelkem = dr["amount_total"] == DBNull.Value ? 0 : (decimal)dr["amount_total"];
                    els.Remark = dr["x_remark"] == DBNull.Value ? "" : dr["x_remark"].ToString();
                    els.Remark2 = dr["x_remark2"] == DBNull.Value ? "" : dr["x_remark2"].ToString();
                    int n_Partner = dr["partner_id"] == DBNull.Value ? 0 : (int)dr["partner_id"];
                    els.Partners = Partner.GetPartner(this.Srv, this.Base, n_Partner, this.IcoBase);
                    this.CollectionObjednalky.Add(els);
                }
                dr.Close();
                if (IsSelect && this.CollectionObjednalky.Count != 0)
                {
                    CopyOnly(this.CollectionObjednalky[0]);
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
        [NumFunction(14)]
        protected override void CreatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                this.Id = 0;
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (name, x_ico_cislo, company_id, user_id, opportunity_id, x_pdoklad, " +
                        @" date_order, x_cin_id, x_str_id, x_formuh_id, amount_total, x_remark, x_remark2, partner_id ) " +
                        @" VALUES ( @name, @x_ico_cislo, @company_id, @user_id, @opportunity_id, @x_pdoklad, " +
                        @" @date_order, @x_cin_id, @x_str_id, @x_formuh_id, @amount_total, @x_remark, @x_remark2, @partner_id ); " +
                        " SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_ico_cislo = cm.Parameters.Add("x_ico_cislo", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_company_id = cm.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_user_id = cm.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_opportunity_id = cm.Parameters.Add("opportunity_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_x_pdoklad = cm.Parameters.Add("x_pdoklad", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_date_order = cm.Parameters.Add("date_order", NpgsqlTypes.NpgsqlDbType.Date);
                Npgsql.NpgsqlParameter pr_x_cin_id = cm.Parameters.Add("x_cin_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_x_str_id = cm.Parameters.Add("x_str_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_x_formuh_id = cm.Parameters.Add("x_formuh_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_amount_total = cm.Parameters.Add("amount_total", NpgsqlTypes.NpgsqlDbType.Money);
                Npgsql.NpgsqlParameter pr_x_remark = cm.Parameters.Add("x_remark", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_remark2 = cm.Parameters.Add("x_remark2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Dictionary<string, Company> di_com = Company.GetChashCompanyIco(this.Srv, this.Base);
                Dictionary<int, User> di_usr = User.GetChashUserId(this.Srv, this.Base, this.IcoBase);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionObjednalky)
                    {
                        pr_x_ico_cislo.Value = item.Ids;
                        if (di_com.TryGetValue(item.CompanyIco, out Company com))
                        {
                            pr_company_id.Value = com.Id;
                        }
                        else pr_company_id.Value = DBNull.Value;
                        pr_user_id.Value = di_usr[0].Id;
                        pr_opportunity_id.Value = item.CisloZak;
                        pr_x_pdoklad.Value = item.PDoklad;
                        pr_name.Value = item.Name;
                        if (item.Datum == null) pr_date_order.Value = DBNull.Value;
                        else pr_date_order.Value = item.Datum.Value;
                        item.Cin.GetIdOrCreate(this.Srv);
                        if (item.Cin.Id == 0) pr_x_cin_id.Value = DBNull.Value;
                        else pr_x_cin_id.Value = item.Cin.Id;
                        item.Str.GetIdOrCreate(this.Srv);
                        if (item.Str.Id == 0) pr_x_str_id.Value = DBNull.Value;
                        else pr_x_str_id.Value = item.Str.Id;
                        item.FormUh.GetIdOrCreate(this.Srv);
                        if (item.FormUh.Id == 0) pr_x_formuh_id.Value = DBNull.Value;
                        else pr_x_formuh_id.Value = item.FormUh.Id;
                        pr_amount_total.Value = item.Celkem.KcCelkem;
                        pr_x_remark.Value = item.Remark;
                        pr_x_remark2.Value = item.Remark2;
                        int n_partner = Partner.GetPartner(this.Srv, this.Base, item.Partners.Ids, this.IcoBase).Id;
                        if (n_partner == 0) pr_partner_id.Value = DBNull.Value;
                        else pr_partner_id.Value = n_partner;
                        this.Id = (int)((long)cm.ExecuteScalar());
                    }
                }
                else
                {
                    pr_x_ico_cislo.Value = this.Ids;
                    if (di_com.TryGetValue(this.CompanyIco, out Company com))
                    {
                        pr_company_id.Value = com.Id;
                    }
                    else pr_company_id.Value = DBNull.Value;
                    pr_user_id.Value = di_usr[0].Id;
                    pr_opportunity_id.Value = this.CisloZak;
                    pr_x_pdoklad.Value = this.PDoklad;
                    pr_name.Value = this.Name;
                    if (this.Datum == null) pr_date_order.Value = DBNull.Value;
                    else pr_date_order.Value = this.Datum.Value;
                    this.Cin.GetIdOrCreate(this.Srv);
                    if (this.Cin.Id == 0) pr_x_cin_id.Value = DBNull.Value;
                    else pr_x_cin_id.Value = this.Cin.Id;
                    this.Str.GetIdOrCreate(this.Srv);
                    if (this.Str.Id == 0) pr_x_str_id.Value = DBNull.Value;
                    else pr_x_str_id.Value = this.Str.Id;
                    this.FormUh.GetIdOrCreate(this.Srv);
                    if (this.FormUh.Id == 0) pr_x_formuh_id.Value = DBNull.Value;
                    else pr_x_formuh_id.Value = this.FormUh.Id;
                    pr_amount_total.Value = this.Celkem.KcCelkem;
                    pr_x_remark.Value = this.Remark;
                    pr_x_remark2.Value = this.Remark2;
                    int n_partner = Partner.GetPartner(this.Srv, this.Base, this.Partners.Ids, this.IcoBase).Id;
                    if (n_partner == 0) pr_partner_id.Value = DBNull.Value;
                    else pr_partner_id.Value = n_partner;
                    this.Id = (int)((long)cm.ExecuteScalar());
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
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, country = @country, active = @active, bic = @bic, x_Ids = @x_Ids WHERE (id = @id) ",
                    this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_ico_cislo = cm.Parameters.Add("x_ico_cislo", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_company_id = cm.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_user_id = cm.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_opportunity_id = cm.Parameters.Add("opportunity_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_x_pdoklad = cm.Parameters.Add("x_pdoklad", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_date_order = cm.Parameters.Add("date_order", NpgsqlTypes.NpgsqlDbType.Date);
                Npgsql.NpgsqlParameter pr_x_cin_id = cm.Parameters.Add("x_cin_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_x_str_id = cm.Parameters.Add("x_str_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_x_formuh_id = cm.Parameters.Add("x_formuh_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_amount_total = cm.Parameters.Add("amount_total", NpgsqlTypes.NpgsqlDbType.Money);
                Npgsql.NpgsqlParameter pr_x_remark = cm.Parameters.Add("x_remark", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_remark2 = cm.Parameters.Add("x_remark2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Dictionary<string, Company> di_com = Company.GetChashCompanyIco(this.Srv, this.Base);
                Dictionary<int, User> di_usr = User.GetChashUserId(this.Srv, this.Base, this.IcoBase);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionObjednalky)
                    {
                        pr_x_ico_cislo.Value = item.Ids;
                        if (di_com.TryGetValue(item.CompanyIco, out Company com))
                        {
                            pr_company_id.Value = com.Id;
                        }
                        else pr_company_id.Value = DBNull.Value;
                        pr_user_id.Value = di_usr[0].Id;
                        pr_opportunity_id.Value = item.CisloZak;
                        pr_x_pdoklad.Value = item.PDoklad;
                        pr_name.Value = item.Name;
                        if (item.Datum == null) pr_date_order.Value = DBNull.Value;
                        else pr_date_order.Value = item.Datum.Value;
                        item.Cin.GetIdOrCreate(this.Srv);
                        if (item.Cin.Id == 0) pr_x_cin_id.Value = DBNull.Value;
                        else pr_x_cin_id.Value = item.Cin.Id;
                        item.Str.GetIdOrCreate(this.Srv);
                        if (item.Str.Id == 0) pr_x_str_id.Value = DBNull.Value;
                        else pr_x_str_id.Value = item.Str.Id;
                        item.FormUh.GetIdOrCreate(this.Srv);
                        if (item.FormUh.Id == 0) pr_x_formuh_id.Value = DBNull.Value;
                        else pr_x_formuh_id.Value = item.FormUh.Id;
                        pr_amount_total.Value = item.Celkem.KcCelkem;
                        pr_x_remark.Value = item.Remark;
                        pr_x_remark2.Value = item.Remark2;
                        int n_partner = Partner.GetPartner(this.Srv, this.Base, item.Partners.Ids, this.IcoBase).Id;
                        if (n_partner == 0) pr_partner_id.Value = DBNull.Value;
                        else pr_partner_id.Value = n_partner;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_x_ico_cislo.Value = this.Ids;
                    if (di_com.TryGetValue(this.CompanyIco, out Company com))
                    {
                        pr_company_id.Value = com.Id;
                    }
                    else pr_company_id.Value = DBNull.Value;
                    pr_user_id.Value = di_usr[0].Id;
                    pr_opportunity_id.Value = this.CisloZak;
                    pr_x_pdoklad.Value = this.PDoklad;
                    pr_name.Value = this.Name;
                    if (this.Datum == null) pr_date_order.Value = DBNull.Value;
                    else pr_date_order.Value = this.Datum.Value;
                    this.Cin.GetIdOrCreate(this.Srv);
                    if (this.Cin.Id == 0) pr_x_cin_id.Value = DBNull.Value;
                    else pr_x_cin_id.Value = this.Cin.Id;
                    this.Str.GetIdOrCreate(this.Srv);
                    if (this.Str.Id == 0) pr_x_str_id.Value = DBNull.Value;
                    else pr_x_str_id.Value = this.Str.Id;
                    this.FormUh.GetIdOrCreate(this.Srv);
                    if (this.FormUh.Id == 0) pr_x_formuh_id.Value = DBNull.Value;
                    else pr_x_formuh_id.Value = this.FormUh.Id;
                    pr_amount_total.Value = this.Celkem.KcCelkem;
                    pr_x_remark.Value = this.Remark;
                    pr_x_remark2.Value = this.Remark2;
                    int n_partner = Partner.GetPartner(this.Srv, this.Base, this.Partners.Ids, this.IcoBase).Id;
                    if (n_partner == 0) pr_partner_id.Value = DBNull.Value;
                    else pr_partner_id.Value = n_partner;
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
        #endregion

        #region  ==========  Разное  ==========

        [NumFunction(19)]
        private void CopyOnly(Objednalky zak)
        {
            this.Id = zak.Id;
            this.Ids = zak.Ids;
            this.CompanyIco = zak.CompanyIco;
            this.UserName = zak.UserName;
            this.PDoklad = zak.PDoklad;
            this.CisloZak = zak.CisloZak;
            this.Name = zak.Name;
            this.Datum = zak.Datum;
            this.DatDo = zak.DatDo;
            this.DatOd = zak.DatOd;
            this.RelTpObj = zak.RelTpObj;
            this.Cin = zak.Cin;
            this.Str = zak.Str;
            this.FormUh = zak.FormUh;
            this.Celkem = zak.Celkem;
            this.Remark = zak.Remark;
            this.Remark2 = zak.Remark2;
            this.Partners = zak.Partners;
        }

        [NumFunction(17)]
        private Pohoda.Xml.Packet.Contract ConvertToPohoda()
        {
            Pohoda.Xml.Packet.Contract adr = new Pohoda.Xml.Packet.Contract();
            //if (adr.contractDesc == null) adr.contractDesc = new Pohoda.Xml.Packet.ContractDesc();
            //adr.contractDesc.id = this.Id;
            ////adr.contractDesc.text = string.IsNullOrWhiteSpace(this.Name) ?
            ////    ((string.IsNullOrWhiteSpace(this.Partner) ? "zak" : this.Partner) + "- ucetnictvi") :
            ////    this.Name;
            //if (adr.contractDesc.number == null) adr.contractDesc.number = new Pohoda.Xml.Packet.Number();
            //adr.contractDesc.number.ids = this.Ids;
            //adr.contractDesc.note = this.Remark;
            //if (adr.contractDesc.partnerIdentity == null) adr.contractDesc.partnerIdentity = new Pohoda.Xml.Packet.PartnerIdentity();
            ////adr.contractDesc.partnerIdentity.id = this.IdPartner;
            //if (adr.contractDesc.responsiblePerson == null) adr.contractDesc.responsiblePerson = new Pohoda.Xml.Packet.ResponsiblePerson();
            ////adr.contractDesc.responsiblePerson.id = this.IdManager;
            //adr.contractDesc.contractState = this..StatusP;
            //adr.contractDesc.datePlanStart = this.DatesStatus.PlZahaj;
            //adr.contractDesc.datePlanDelivery = this.DatesStatus.PlPredani;
            //adr.contractDesc.dateStart = this.DatesStatus.Zahajeni;
            //adr.contractDesc.dateDelivery = this.DatesStatus.Predani;
            //adr.contractDesc.dateWarranty = this.DatesStatus.Zaruka;
            //adr.contractDesc.ost1 = "";
            //adr.contractDesc.ost2 = "";
            return adr;
        }

        [NumFunction(18)]
        private Zakazka ConvertToObjednalky(Pohoda.Xml.Packet.Contract Ab)
        {
            Zakazka zak = new Zakazka();
            //zak.Srv = this.Srv;
            //zak.Base = this.Base;
            //zak.IcoBase = this.IcoBase;
            //zak.Id = Ab.contractDesc.id;
            //if (Ab.contractDesc.number != null)
            //{
            //    zak.Ids = string.IsNullOrWhiteSpace(Ab.contractDesc.number.numberRequested) ? "" : Ab.contractDesc.number.numberRequested;
            //}
            //zak.Name = Ab.contractDesc.text;
            //zak.Ost1 = string.IsNullOrWhiteSpace(Ab.contractDesc.note) ? "" : Ab.contractDesc.ost1;
            //zak.Ost2 = string.IsNullOrWhiteSpace(Ab.contractDesc.note) ? "" : Ab.contractDesc.ost2;
            //zak.Remark = string.IsNullOrWhiteSpace(Ab.contractDesc.note) ? "" : Ab.contractDesc.note;
            //zak.KcCelkem = 0;
            //zak.Status = new StatusZakazka(Ab.contractDesc.contractState);
            //zak.DatesStatus.PlPredani = Ab.contractDesc.datePlanStart;
            //zak.DatesStatus.PlZahaj = Ab.contractDesc.datePlanDelivery;
            //zak.DatesStatus.Zahajeni = Ab.contractDesc.dateStart;
            //zak.DatesStatus.Predani = Ab.contractDesc.dateDelivery;
            //zak.DatesStatus.Zaruka = Ab.contractDesc.dateWarranty;
            //if (Ab.contractDesc.responsiblePerson != null)
            //{
            //    zak.UserName = User.GetUser(Ab.contractDesc.responsiblePerson.id, this.Srv, this.Base).Ids;
            //}

            //if (Ab.contractDesc.partnerIdentity != null)
            //{
            //    zak.Partners = new Partner();
            //    zak.Partners.Id = Ab.contractDesc.partnerIdentity.id;
            //}
            return zak;
        }

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список или один банк
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<Objednalky> GetList(Servers Srv, string BaseName, string IcoBasa)
        {
            Objednalky el = new Objednalky(0, Srv, BaseName, IcoBasa);
            return el.CollectionObjednalky;
        }

        #endregion
    }
}
