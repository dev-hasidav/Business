using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    [NumClass(51)]
    [Serializable]
    public class Zakazka : Interfases.BaseModelTable, Interfases.ICompanyUser
    {
        #region  ==========  Constructor  ==========

        //public Partner() { }
        public Zakazka() : base(Actions.SyncZakazka) { }
        public Zakazka(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncZakazka) { }
        /// <summary>
        /// Создать по Cislo
        /// </summary>
        /// <param name="Name">Ids или Cislo</param>
        /// <param name="Server"></param>
        /// <param name="BaseData"></param>
        /// <param name="Ico">Ico базы с которой работаем</param>
        public Zakazka(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncZakazka) { }

        #endregion

        #region  ==========  Property  ==========
        public string CompanyIco { get; set; }
        public Partner Partners { get; set; }
        public string UserName { get; set; }
        public decimal KcCelkem { set; get; }

        /// <summary>
        /// Даты заказки
        /// </summary>
        public PlansDates DatesStatus { set; get; } = new PlansDates();

        /// <summary>
        /// Статус заказки
        /// </summary>
        public StatusZakazka Status { set; get; } = new StatusZakazka(Pohoda.Xml.EnumContractState.None);

        /// <summary>
        /// P - Ost1, O - ost1
        /// </summary>
        public string Ost1 { set; get; }
        /// <summary>
        /// P - Ost2, O - ost2
        /// </summary>
        public string Ost2 { set; get; }
        /// <summary>
        /// P - Pozn, O - remark
        /// </summary>
        public string Remark { set; get; }


        public List<ZakazkaPlanning> Polizkys { set; get; } = new List<ZakazkaPlanning>();

        private List<Zakazka> _CollectionZakazka = new List<Zakazka>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Zakazka> CollectionZakazka { get { return _CollectionZakazka; } set { _CollectionZakazka = value; IsRecord = NumberRecord.Many; } }
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
                    CommandText = string.Format(@"SELECT * FROM {0} ORDER BY Cislo ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} WHERE (ID = @ID)", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} WHERE (Cislo = @Cislo)", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Cislo", System.Data.SqlDbType.VarChar);
                    pr_Kod.Value = Ids;
                }
                else { IsSelect = false; }
                Dictionary<int, Partner> di_Partner = Partner.GetChashPartnerId(this.Srv, this.Base, this.IcoBase);
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Zakazka zak = new Zakazka();
                    zak.Srv = this.Srv;
                    zak.Base = this.Base;
                    zak.IcoBase = this.IcoBase;
                    zak.Id = (int)dr["ID"];
                    zak.Ids = string.Format("{0}_{1}", this.IcoBase, dr["Cislo"] == DBNull.Value ? "" : dr["Cislo"].ToString().Trim()).Trim();
                    zak.Name = dr["SText"] == DBNull.Value ? "" : dr["SText"].ToString().Trim();
                    zak.Ost1 = dr["Ost1"] == DBNull.Value ? "" : dr["Ost1"].ToString().Trim();
                    zak.Ost2 = dr["Ost2"] == DBNull.Value ? "" : dr["Ost2"].ToString().Trim();
                    zak.Remark = dr["Pozn"] == DBNull.Value ? "" : dr["Pozn"].ToString().Trim();
                    zak.KcCelkem = 0;
                    zak.Status = new StatusZakazka(dr["RefStav"] == DBNull.Value ? Pohoda.Xml.EnumContractState.None : (Pohoda.Xml.EnumContractState)dr["RefStav"]);
                    if (dr["PlZahaj"] != DBNull.Value) zak.DatesStatus.PlZahaj = (DateTime)dr["PlZahaj"];
                    if (dr["PlPredani"] != DBNull.Value) zak.DatesStatus.PlPredani = (DateTime)dr["PlPredani"];
                    if (dr["Zahajeni"] != DBNull.Value) zak.DatesStatus.Zahajeni = (DateTime)dr["Zahajeni"];
                    if (dr["Predani"] != DBNull.Value) zak.DatesStatus.Predani = (DateTime)dr["Predani"];
                    if (dr["Zaruka"] != DBNull.Value) zak.DatesStatus.Zaruka = (DateTime)dr["Zaruka"];
                    int n_Osoba = dr["RefOsoba"] == DBNull.Value ? 0 : (int)dr["RefOsoba"];
                    zak.UserName = User.GetNameUser(n_Osoba, this.Srv, this.Base);
                    zak.CompanyIco = this.IcoBase;
                    int n_Partner = dr["RefAD"] == DBNull.Value ? 0 : (int)dr["RefAD"];
                    bool b_Partner = true;
                    if (n_Partner != 0)
                    {
                        if (di_Partner.TryGetValue(n_Partner, out Partner Pr))
                        {
                            zak.Partners = Pr;
                            b_Partner = false;
                        }
                    }
                    string s_ICO = dr["ICO"] == DBNull.Value ? "" : dr["ICO"].ToString().Trim();
                    if (b_Partner && !string.IsNullOrWhiteSpace(s_ICO))
                    {
                        zak.Partners = new Partner();
                        zak.Partners.Id = 0;
                        zak.Partners.Ids = s_ICO;
                        zak.Partners.Name = dr["Firma"] == DBNull.Value ? "" : dr["Firma"].ToString().Trim();
                        zak.Partners.Jmeno = dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim();
                        zak.Partners.Ulice = dr["Ulice"] == DBNull.Value ? "" : dr["Ulice"].ToString().Trim();
                        zak.Partners.Name = dr["PSC"] == DBNull.Value ? "" : dr["PSC"].ToString().Trim();
                        zak.Partners.Name = dr["Obec"] == DBNull.Value ? "" : dr["Obec"].ToString().Trim();
                        zak.Partners.Name = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString().Trim();
                        zak.Partners.Name = dr["Tel"] == DBNull.Value ? "" : dr["Tel"].ToString().Trim();
                        zak.Partners.Name = dr["DIC"] == DBNull.Value ? "" : dr["DIC"].ToString().Trim();
                        int n_Country = dr["RefZeme"] == DBNull.Value ? 0 : (int)dr["RefZeme"];
                        zak.Partners.Country = Country.GetCountry(this.Srv, this.Base, n_Country).Ids;
                    }
                    this.CollectionZakazka.Add(zak);
                }
                dr.Close();
                if (IsSelect && this.CollectionZakazka.Count != 0)
                {
                    CopyOnly(this.CollectionZakazka[0]);
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
            //System.Data.SqlClient.SqlConnection cn = null;
            //try
            //{
            //    ConvertNameToId();
            //    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
            //    cn.Open();
            //    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
            //    {
            //        Connection = cn,
            //        CommandText = string.Format(@"INSERT INTO {0} " +
            //            @" (Cislo, SText, Pozn, RefAD, Firma, RefOsoba, RefStav, PlZahaj, PlPredani, " +
            //            @" DatCreate, Creator, DatSave, Ucetni, RelCR) " +
            //            @" VALUES (@Cislo, @SText, @Pozn, @RefAD, @Firma, @RefOsoba, @RefStav, @PlZahaj, @PlPredani, " +
            //            @" @DatCreate, @Creator, @DatSave, @Ucetni, @RelCR) ;" +
            //            @" SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
            //    };

            //    Cislo csl = new Cislo(Actions.SyncZakazka, this.Srv, this.Base, this.IcoBase);
            //    this.Ids = csl.NewValue;

            //    System.Data.SqlClient.SqlParameter pr_Cislo = cm.Parameters.Add("Cislo", System.Data.SqlDbType.VarChar);
            //    pr_Cislo.Value = this.Ids;
            //    System.Data.SqlClient.SqlParameter pr_RelCR = cm.Parameters.Add("RelCR", System.Data.SqlDbType.Int);
            //    pr_RelCR.Value = csl.Id;
            //    System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
            //    if (string.IsNullOrWhiteSpace(this.Name)) pr_SText.Value = DBNull.Value;
            //    else pr_SText.Value = this.Name;
            //    System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
            //    if (string.IsNullOrWhiteSpace(this.Pozn)) pr_Pozn.Value = DBNull.Value;
            //    else pr_Pozn.Value = this.Pozn;
            //    System.Data.SqlClient.SqlParameter pr_RefAD = cm.Parameters.Add("RefAD", System.Data.SqlDbType.Int);
            //    //if (this.IdPartner == 0) pr_RefAD.Value = DBNull.Value;
            //    //else pr_RefAD.Value = this.IdPartner;
            //    //System.Data.SqlClient.SqlParameter pr_Firma = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
            //    //if (string.IsNullOrWhiteSpace(this.Partner)) pr_Firma.Value = DBNull.Value;
            //    //else pr_Firma.Value = this.Partner;
            //    //System.Data.SqlClient.SqlParameter pr_RefOsoba = cm.Parameters.Add("RefOsoba", System.Data.SqlDbType.Int);
            //    //if (this.IdManager == 0) pr_RefOsoba.Value = DBNull.Value;
            //    //else pr_RefOsoba.Value = this.IdManager;
            //    System.Data.SqlClient.SqlParameter pr_RefStav = cm.Parameters.Add("RefStav", System.Data.SqlDbType.Int);
            //    pr_RefStav.Value = (int)this.Status.StatusP;
            //    System.Data.SqlClient.SqlParameter pr_PlZahaj = cm.Parameters.Add("PlZahaj", System.Data.SqlDbType.DateTime);
            //    if (this.ConfirmationDate == null) pr_PlZahaj.Value = DBNull.Value;
            //    else pr_PlZahaj.Value = this.ConfirmationDate;
            //    System.Data.SqlClient.SqlParameter pr_PlPredani = cm.Parameters.Add("PlPredani", System.Data.SqlDbType.DateTime);
            //    if (this.CommitmentDate == null) pr_PlPredani.Value = DBNull.Value;
            //    else pr_PlPredani.Value = this.CommitmentDate;
            //    System.Data.SqlClient.SqlParameter pr_DatCreate = cm.Parameters.Add("DatCreate", System.Data.SqlDbType.DateTime);
            //    pr_DatCreate.Value = DateTime.Now;
            //    System.Data.SqlClient.SqlParameter pr_Creator = cm.Parameters.Add("Creator", System.Data.SqlDbType.VarChar);
            //    pr_Creator.Value = "@";
            //    System.Data.SqlClient.SqlParameter pr_DatSave = cm.Parameters.Add("DatSave", System.Data.SqlDbType.DateTime);
            //    pr_DatSave.Value = DateTime.Now;
            //    System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
            //    pr_Ucetni.Value = "@";
            //    this.Id = 0;
            //    this.Id = (int)cm.ExecuteScalar();
            //    csl.Update();
            //    foreach (ZakazkaPlanning item in this.Polizkys)
            //    {
            //        item.Create();
            //    }
            //}
            //catch (Exception e1)
            //{
            //    FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            //    throw e1;
            //}
            //finally { cn?.Close(); }
            //return;
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            //System.Data.SqlClient.SqlConnection cn = null;
            //try
            //{
            //    ConvertNameToId();
            //    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
            //    cn.Open();
            //    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
            //    {
            //        Connection = cn,
            //        CommandText = string.Format(@"UPDATE {0} " +
            //            @" SET Cislo = @Cislo, SText = @SText, Pozn = @Pozn, RefAD = @RefAD, Firma = @Firma, RefOsoba = @RefOsoba, RefStav = @RefStav, " +
            //                @" PlZahaj = @PlZahaj, PlPredani = @PlPredani, DatSave = @DatSave, Ucetni = @Ucetni " +
            //            @" WHERE (ID = @ID) ", this.PrAction.TableSql)
            //    };
            //    System.Data.SqlClient.SqlParameter pr_Cislo = cm.Parameters.Add("Cislo", System.Data.SqlDbType.VarChar);
            //    pr_Cislo.Value = this.Ids;
            //    System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
            //    if (string.IsNullOrWhiteSpace(this.Name)) pr_SText.Value = DBNull.Value;
            //    else pr_SText.Value = this.Name;
            //    System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
            //    if (string.IsNullOrWhiteSpace(this.Pozn)) pr_Pozn.Value = DBNull.Value;
            //    else pr_Pozn.Value = this.Pozn;
            //    //System.Data.SqlClient.SqlParameter pr_RefAD = cm.Parameters.Add("RefAD", System.Data.SqlDbType.Int);
            //    //if (this.IdPartner == 0) pr_RefAD.Value = DBNull.Value;
            //    //else pr_RefAD.Value = this.IdPartner;
            //    //System.Data.SqlClient.SqlParameter pr_Firma = cm.Parameters.Add("Firma", System.Data.SqlDbType.VarChar);
            //    //if (string.IsNullOrWhiteSpace(this.Partner)) pr_Firma.Value = DBNull.Value;
            //    //else pr_Firma.Value = this.Partner;
            //    //System.Data.SqlClient.SqlParameter pr_RefOsoba = cm.Parameters.Add("RefOsoba", System.Data.SqlDbType.Int);
            //    //if (this.IdManager == 0) pr_RefOsoba.Value = DBNull.Value;
            //    //else pr_RefOsoba.Value = this.IdManager;
            //    System.Data.SqlClient.SqlParameter pr_RefStav = cm.Parameters.Add("RefStav", System.Data.SqlDbType.Int);
            //    pr_RefStav.Value = (int)this.Status.StatusP;
            //    System.Data.SqlClient.SqlParameter pr_PlZahaj = cm.Parameters.Add("PlZahaj", System.Data.SqlDbType.DateTime);
            //    if (this.ConfirmationDate == null) pr_PlZahaj.Value = DBNull.Value;
            //    else pr_PlZahaj.Value = this.ConfirmationDate;
            //    System.Data.SqlClient.SqlParameter pr_PlPredani = cm.Parameters.Add("PlPredani", System.Data.SqlDbType.DateTime);
            //    if (this.CommitmentDate == null) pr_PlPredani.Value = DBNull.Value;
            //    else pr_PlPredani.Value = this.CommitmentDate;
            //    System.Data.SqlClient.SqlParameter pr_DatSave = cm.Parameters.Add("DatSave", System.Data.SqlDbType.DateTime);
            //    pr_DatSave.Value = DateTime.Now;
            //    System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
            //    pr_Ucetni.Value = "@";
            //    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
            //    pr_Id.Value = this.Id;
            //    cm.ExecuteNonQuery();
            //}
            //catch (Exception e1)
            //{
            //    FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            //    throw e1;
            //}
            //finally { cn?.Close(); }
            //return;
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
        protected override void LoadPohoda(int Id, string Ids)
        {
            bool IsSelect = true;
            try
            {
                //Pohoda.Xml.FilterGet flt = new Pohoda.Xml.FilterGet();
                //flt.Id = Id;
                //flt.Ids = Ids;
                //flt.Company = "";
                //flt.Ico = "";
                //Pohoda.Xml.Document doc = new Pohoda.Xml.Document(this.Base, this.IcoBase, Srv.PohodaPath, Srv.PublicPath, Srv.PohodaUser, Srv.PohodaPassword);
                //Pohoda.Xml.ReturnDocXml rp = doc.GetZakazka(flt);
                //GetMessage(rp);
                //if (rp.State == Pohoda.Xml.enumState.error)
                //{
                //    throw new Exception(rp.Message);
                //}
                //if (this.CollectionZakazka == null) this.CollectionZakazka = new List<Zakazka>();
                //string s_Company = Company.GetCompany(this.IcoBase, this.Srv, this.Base).Ids;
                //Dictionary<int, Partner> di_Partner = Partner.GetChashPartnerId(this.Srv, this.Base, this.IcoBase);
                //foreach (var item in rp.Packet.responsePackItem)
                //{
                //    foreach (var item1 in item.Items)
                //    {
                //        Pohoda.Xml.Packet.ListContract li_adr = item1 as Pohoda.Xml.Packet.ListContract;
                //        if (li_adr != null)
                //        {
                //            foreach (var item2 in li_adr.contract)
                //            {
                //                Zakazka zak = ConvertToZakazka(item2);
                //                if (zak.Partners.Id != 0)
                //                {
                //                    if (di_Partner.TryGetValue(zak.Partners.Id, out Partner Pr))
                //                    {
                //                        zak.Partners = Pr;
                //                    }
                //                }
                //                this.CollectionZakazka.Add(zak);
                //            }
                //        }
                //    }
                //}
                //if (this.CollectionZakazka.Count == 1)
                //{
                //    CopyOnly(this.CollectionZakazka[0]);
                //}
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
                //Pohoda.Xml.Packet.Contract zak = ConvertToPohoda();
                //Pohoda.Xml.Document doc = new Pohoda.Xml.Document(this.Base, this.IcoBase, Srv.PohodaPath, Srv.PublicPath, Srv.PohodaUser, Srv.PohodaPassword);
                //Pohoda.Xml.ReturnDocXml rp = doc.SetZakazka(zak);
                //SetMessage(rp);
                //if (rp.IsSuccess)
                //{
                //    object o1 = rp.Packet.responsePackItem[0].Items[0];
                //    Pohoda.Xml.Packet.ContractResponse abr = rp.Packet.responsePackItem[0].Items[0] as Pohoda.Xml.Packet.ContractResponse;
                //    if (abr != null)
                //    {
                //        this.Id = abr.producedDetails.id;
                //        this.Ids = abr.producedDetails.number;
                //        foreach (ZakazkaPlanning item in this.Polizkys)
                //        {
                //            item.Create();
                //        }
                //    }
                //}
                //else
                //{
                //    throw new Exception(rp.Message);
                //}
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
                //System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
                List<string> li_pole = new List<string> {
                    "id",
                    "x_ico_cislo",
                    "company_id",
                    "user_id",
                    "name",
                    "date_open",
                    "date_last_stage_update",
                    "date_closed",
                    "stage_id",
                    "x_ost1",
                    "x_ost2",
                    "x_remark",
                    //"planned_revenue",
                    "partner_id"
                };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    odoFiltr.Filter("x_ico_cislo", "=", Ids);
                }
                else { IsSelect = false; }
                odoFiltr.Filter("active", "!=", null);
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                Dictionary<int, Partner> di_Partner = Partner.GetChashPartnerId(this.Srv, this.Base, this.IcoBase);
                foreach (var item in Datas)
                {
                    Zakazka zak = new Zakazka();
                    zak.Srv = this.Srv;
                    zak.Base = this.Base;
                    zak.Id = int.Parse(item["id"]);
                    zak.Ids = item["x_ico_cislo"] == "False" ? "" : item["x_ico_cislo"];
                    zak.Name = item["name"] == "False" ? "" : item["name"].ToString().Trim();
                    zak.Status = new StatusZakazka((StatusCrm)(item["stage_id"] == "False" ? 0 : Funcs.ConvertStringToInt.StringOdooToInt(item["stage_id"])));
                    if (item["date_open"] != "False") zak.DatesStatus.PlZahaj = DateTime.Parse(item["date_open"].ToString().Trim());
                    switch (zak.Status.StatusO)
                    {
                        case StatusCrm.Won:
                            if (item["date_last_stage_update"] != "False")
                            {
                                zak.DatesStatus.PlPredani = DateTime.Parse(item["date_last_stage_update"].ToString().Trim());
                                zak.DatesStatus.Zahajeni = DateTime.Parse(item["date_last_stage_update"].ToString().Trim());
                                zak.DatesStatus.Predani = DateTime.Parse(item["date_last_stage_update"].ToString().Trim());
                            }
                            break;
                        case StatusCrm.Proposition:
                            if (item["date_last_stage_update"] != "False")
                            {
                                zak.DatesStatus.PlPredani = DateTime.Parse(item["date_last_stage_update"].ToString().Trim());
                                zak.DatesStatus.Zahajeni = DateTime.Parse(item["date_last_stage_update"].ToString().Trim());
                            }
                            break;
                        case StatusCrm.Qualified:
                            if (item["date_last_stage_update"] != "False")
                                zak.DatesStatus.PlPredani = DateTime.Parse(item["date_last_stage_update"].ToString().Trim());
                            break;
                        case StatusCrm.New:
                            break;
                    }
                    if (item["date_closed"] != "False") zak.DatesStatus.Zaruka = DateTime.Parse(item["date_closed"].ToString().Trim());
                    zak.Ost1 = item["x_ost1"] == "False" ? "" : item["x_ost1"].ToString().Trim();
                    zak.Ost2 = item["x_ost2"] == "False" ? "" : item["x_ost2"].ToString().Trim();
                    zak.Remark = item["x_remark"] == "False" ? "" : item["x_remark"].ToString().Trim();
                    zak.KcCelkem = decimal.Parse(item["planned_revenue"]);
                    int n_company = Funcs.ConvertStringToInt.StringOdooToInt(item["company_id"]);
                    zak.CompanyIco = Company.GetIcoCompany(n_company, this.Srv, this.Base);
                    int n_User = Funcs.ConvertStringToInt.StringOdooToInt(item["user_id"]);
                    zak.UserName = User.GetNameUser(n_User, this.Srv, this.Base);
                    int n_Partner = Funcs.ConvertStringToInt.StringOdooToInt(item["partner_id"]);
                    if(di_Partner.TryGetValue(n_Partner, out Partner Pr))
                    {
                        zak.Partners = Pr;
                    }
                    this.CollectionZakazka.Add(zak);
                }
                if (IsSelect && this.CollectionZakazka.Count != 0)
                {
                    CopyOnly(this.CollectionZakazka[0]);
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
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                    List<Dictionary<string, object>> li_create = new List<Dictionary<string, object>>();
                    foreach (var item in this.CollectionZakazka)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ico_cislo", item.Ids },
                            { "name", item.Name },
                            { "date_open", item.DatesStatus.s_PlZahaj },
                            { "date_last_stage_update", item.DatesStatus.s_LastDate },
                            { "stage_id",(int) item.Status.StatusO },
                            { "x_ost1", item.Ost1 },
                            { "x_ost2", item.Ost2 },
                            { "x_remark", item.Remark },
                            { "planned_revenue", item.KcCelkem }
                        };
                        if (item.DatesStatus.Zaruka != null) di.Add("date_closed", item.DatesStatus.s_Zaruka);
                        int n_comp = Company.GetIdCompany(item.CompanyIco, this.Srv, this.Base);
                        if (n_comp != 0) di.Add("company_id", n_comp);
                        int n_user = User.GetIdUser(item.UserName, this.Srv, this.Base);
                        if (n_user != 0) di.Add("user_id", n_user);
                        int n_partner = Partner.GetIdPartnerOrCreate(item.Partners, this.Srv, this.Base, this.IcoBase);
                        if (n_partner != 0) di.Add("partner_id", n_partner);
                        li_create.Add(di);
                    }
                    odScr.InsertRowPacket(Client, this.PrAction.TableOdoo, li_create);
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "id", null },
                            //{ "x_ico_cislo", this.Ids },
                            { "name", this.Name },
                            //{ "date_open", this.DatesStatus.s_PlZahaj },
                            //{ "date_last_stage_update", this.DatesStatus.s_LastDate },
                            //{ "stage_id",(int) this.Status.StatusO },
                            { "stage_id",1},
                            //{ "x_ost1", this.Ost1 },
                            //{ "x_ost2", this.Ost2 },
                            { "description", this.Remark },
                            //{ "x_remark", this.Remark },
                            //{ "planned_revenue", this.KcCelkem }
                        };
                    //if (this.DatesStatus.Zaruka != null) di.Add("date_closed", this.DatesStatus.s_Zaruka);
                    int n_comp = Company.GetIdCompany(this.CompanyIco, this.Srv, this.Base);
                    if (n_comp != 0) di.Add("company_id", n_comp);
                    int n_user = User.GetIdUser(this.UserName, this.Srv, this.Base);
                    if (n_user != 0) di.Add("user_id", n_user);
                    int n_partner = Partner.GetIdPartnerOrCreate(this.Partners, this.Srv, this.Base, this.IcoBase);
                    if (n_partner != 0) di.Add("partner_id", n_partner);
                    odScr.InsertRow(this.Srv, this.PrAction.TableOdoo, di);
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
            DateTime dt = DateTime.Now;
            try
            {
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.OdooRpcClient Client = odScr.OpenConnectOdoo(Srv);
                List<Dictionary<string, object>> li_create = new List<Dictionary<string, object>>();
                List<long> li_id = new List<long>();
                foreach (var item in this.CollectionZakazka)
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            //{ "date_open", item.DatesStatus.s_PlZahaj },
                            //{ "date_last_stage_update", item.DatesStatus.s_LastDate },
                            { "stage_id",(int) item.Status.StatusO },
                            { "x_ost1", item.Ost1 },
                            { "x_ost2", item.Ost2 },
                            { "x_remark", item.Remark },
                            { "planned_revenue", item.KcCelkem }
                        };
                    if (item.DatesStatus.PlZahaj != null) di.Add("date_open", item.DatesStatus.s_PlZahaj);
                    if (item.DatesStatus.LastDate != null) di.Add("date_last_stage_update", item.DatesStatus.s_LastDate);
                    if (item.DatesStatus.Zaruka != null) di.Add("date_closed", item.DatesStatus.s_Zaruka);
                    int n_comp = Company.GetIdCompany(item.CompanyIco, this.Srv, this.Base);
                    if (n_comp != 0) di.Add("company_id", n_comp);
                    int n_user = User.GetIdUser(item.UserName, this.Srv, this.Base);
                    if (n_user != 0) di.Add("user_id", n_user);
                    int n_partner = Partner.GetIdPartnerOrCreate(item.Partners, this.Srv, this.Base, this.IcoBase);
                    if (n_partner != 0) di.Add("partner_id", n_partner);
                    li_create.Add(di);
                    li_id.Add(item.Id);
                }
                odScr.UpdateRowPacket(Client, this.PrAction.TableOdoo, li_id, li_create);
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
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT * FROM {0} ORDER BY x_ico_cislo ", this.PrAction.TableSql)
                };
                if (Id != 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} WHERE (id = @id)", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where name = @name", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_name.Value = Ids;
                }
                else { IsSelect = false; }
                string s_Company = Company.GetCompany(this.IcoBase, this.Srv, this.Base).Ids;
                Dictionary<int, Partner> di_Partner = Partner.GetChashPartnerId(this.Srv, this.Base, this.IcoBase);
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Zakazka zak = new Zakazka();
                    zak.Srv = this.Srv;
                    zak.Base = this.Base;
                    zak.IcoBase = this.IcoBase;
                    zak.Id = (int)dr["id"];
                    zak.Ids = dr["x_ico_cislo"] == DBNull.Value ? "" : dr["x_ico_cislo"].ToString().Trim();
                    zak.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    zak.Ost1 = dr["x_ost1"] == DBNull.Value ? "" : dr["x_ost1"].ToString().Trim();
                    zak.Ost2 = dr["x_ost2"] == DBNull.Value ? "" : dr["x_ost2"].ToString().Trim();
                    zak.Remark = dr["x_remark"] == DBNull.Value ? "" : dr["x_remark"].ToString().Trim();
                    zak.KcCelkem = dr["planned_revenue"] == DBNull.Value ? 0 : (int)dr["planned_revenue"];
                    zak.Status = new StatusZakazka((StatusCrm)(dr["stage_id"] == DBNull.Value ? 0 : (int) dr["stage_id"]));
                    switch (zak.Status.StatusO)
                    {
                        case StatusCrm.Won:
                            if (dr["date_last_stage_update"] != DBNull.Value)
                            {
                                zak.DatesStatus.PlPredani = DateTime.Parse(dr["date_last_stage_update"].ToString().Trim());
                                zak.DatesStatus.Zahajeni = DateTime.Parse(dr["date_last_stage_update"].ToString().Trim());
                                zak.DatesStatus.Predani = DateTime.Parse(dr["date_last_stage_update"].ToString().Trim());
                            }
                            break;
                        case StatusCrm.Proposition:
                            if (dr["date_last_stage_update"] != DBNull.Value)
                            {
                                zak.DatesStatus.PlPredani = DateTime.Parse(dr["date_last_stage_update"].ToString().Trim());
                                zak.DatesStatus.Zahajeni = DateTime.Parse(dr["date_last_stage_update"].ToString().Trim());
                            }
                            break;
                        case StatusCrm.Qualified:
                            if (dr["date_last_stage_update"] != DBNull.Value)
                                zak.DatesStatus.PlPredani = DateTime.Parse(dr["date_last_stage_update"].ToString().Trim());
                            break;
                        case StatusCrm.New:
                            break;
                    }
                    int n_User = (int)dr["user_id"];
                    zak.UserName = User.GetNameUser(n_User, zak.Srv, zak.Base);
                    int n_Partner = (int)dr["partner_id"];
                    if (di_Partner.TryGetValue(n_Partner, out Partner Pr))
                    {
                        zak.Partners = Pr;
                    }
                    int n_Company= (int)dr["company_id"];
                    zak.CompanyIco = Company.GetIcoCompany(n_Company, this.Srv, this.Base);
                    this.CollectionZakazka.Add(zak);
                }
                dr.Close();
                if (IsSelect && this.CollectionZakazka.Count != 0)
                {
                    CopyOnly(this.CollectionZakazka[0]);
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
            DateTime dt = DateTime.Now;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} " +
                        @" (access_token, name, note, partner_id, user_id, state, confirmation_date, commitment_date, " +
                        @" create_date, write_date, opportunity_id) " +
                        @" VALUES (@access_token, @name, @note, @partner_id, @user_id, @state, @confirmation_date, @commitment_date, " +
                        @" @create_date, write_date, opportunity_id) " +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                //Npgsql.NpgsqlParameter pr_access_token = cm.Parameters.Add("access_token", NpgsqlTypes.NpgsqlDbType.Varchar);
                //if (string.IsNullOrWhiteSpace(this.AccessToken)) pr_access_token.Value = DBNull.Value;
                //else pr_access_token.Value = this.AccessToken;
                //Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                //if (string.IsNullOrWhiteSpace(this.Ids)) pr_name.Value = DBNull.Value;
                //else pr_name.Value = this.Ids;
                //Npgsql.NpgsqlParameter pr_note = cm.Parameters.Add("note", NpgsqlTypes.NpgsqlDbType.Varchar);
                //if (string.IsNullOrWhiteSpace(this.Name)) pr_note.Value = DBNull.Value;
                //else pr_note.Value = this.Name;
                ////Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                ////if (this.IdPartner == 0) pr_partner_id.Value = DBNull.Value;
                ////else pr_partner_id.Value = this.IdPartner;
                ////Npgsql.NpgsqlParameter pr_user_id = cm.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer);
                ////if (this.IdManager == 0) pr_user_id.Value = DBNull.Value;
                ////else pr_user_id.Value = this.IdManager;
                //Npgsql.NpgsqlParameter pr_state = cm.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Integer);
                //pr_state.Value =(int) this.Status.StatusO;
                //Npgsql.NpgsqlParameter pr_confirmation_date = cm.Parameters.Add("confirmation_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //if (this.ConfirmationDate == null) pr_confirmation_date.Value = DBNull.Value;
                //else pr_confirmation_date.Value = this.ConfirmationDate;
                //Npgsql.NpgsqlParameter pr_commitment_date = cm.Parameters.Add("commitment_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //if (this.CommitmentDate == null) pr_commitment_date.Value = DBNull.Value;
                //else pr_commitment_date.Value = this.CommitmentDate;
                //Npgsql.NpgsqlParameter pr_create_date = cm.Parameters.Add("create_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //pr_create_date.Value = dt;
                //Npgsql.NpgsqlParameter pr_write_date = cm.Parameters.Add("write_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //pr_write_date.Value = dt;
                //Npgsql.NpgsqlParameter pr_opportunity_id = cm.Parameters.Add("opportunity_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //pr_opportunity_id.Value = this.IdOpportunity;
                //this.Id = 0;
                //this.Id = (int)((long)cm.ExecuteScalar());
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
            DateTime dt = DateTime.Now;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} " +
                        @" SET access_token = @access_token, name = @name, note = @note, partner_id = @partner_id, user_id = @user_id, state = @state, " +
                            @" confirmation_date = @confirmation_date, commitment_date = @commitment_date, write_date = @write_date, opportunity_id = @opportunity_id " +
                        @" WHERE(id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                if (string.IsNullOrWhiteSpace(this.Ids)) pr_name.Value = DBNull.Value;
                else pr_name.Value = this.Ids;
                Npgsql.NpgsqlParameter pr_note = cm.Parameters.Add("note", NpgsqlTypes.NpgsqlDbType.Varchar);
                if (string.IsNullOrWhiteSpace(this.Name)) pr_note.Value = DBNull.Value;
                else pr_note.Value = this.Name;
                //Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //if (this.IdPartner == 0) pr_partner_id.Value = DBNull.Value;
                //else pr_partner_id.Value = this.IdPartner;
                //Npgsql.NpgsqlParameter pr_user_id = cm.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //if (this.IdManager == 0) pr_user_id.Value = DBNull.Value;
                //else pr_user_id.Value = this.IdManager;
                Npgsql.NpgsqlParameter pr_state = cm.Parameters.Add("state", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_state.Value = (int)this.Status.StatusO;
                Npgsql.NpgsqlParameter pr_confirmation_date = cm.Parameters.Add("confirmation_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //if (this.ConfirmationDate == null) pr_confirmation_date.Value = DBNull.Value;
                //else pr_confirmation_date.Value = this.ConfirmationDate;
                //Npgsql.NpgsqlParameter pr_commitment_date = cm.Parameters.Add("commitment_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //if (this.CommitmentDate == null) pr_commitment_date.Value = DBNull.Value;
                //else pr_commitment_date.Value = this.CommitmentDate;
                //Npgsql.NpgsqlParameter pr_write_date = cm.Parameters.Add("write_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //if (this.DateCreate == null) pr_write_date.Value = DBNull.Value;
                //else pr_write_date.Value = dt;
                //Npgsql.NpgsqlParameter pr_opportunity_id = cm.Parameters.Add("opportunity_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //pr_opportunity_id.Value = this.IdOpportunity;
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = this.Id;
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

        [NumFunction(19)]
        private void CopyOnly(Zakazka zak)
        {
            this.Id = zak.Id;
            this.Ids = zak.Ids;
            this.CompanyIco = zak.CompanyIco;
            this.UserName = zak.UserName;
            this.Name = zak.Name;
            this.DatesStatus = zak.DatesStatus;
            this.Status = zak.Status;
            this.Ost1 = zak.Ost1;
            this.Ost2 = zak.Ost2;
            this.Remark = zak.Remark;
            this.KcCelkem = zak.KcCelkem;
            this.Partners = zak.Partners;

        }

        [NumFunction(17)]
        private Pohoda.Xml.Packet.Contract ConvertToPohoda()
        {
            Pohoda.Xml.Packet.Contract adr = new Pohoda.Xml.Packet.Contract();
            if (adr.contractDesc == null) adr.contractDesc = new Pohoda.Xml.Packet.ContractDesc();
            adr.contractDesc.id = this.Id;
            //adr.contractDesc.text = string.IsNullOrWhiteSpace(this.Name) ?
            //    ((string.IsNullOrWhiteSpace(this.Partner) ? "zak" : this.Partner) + "- ucetnictvi") :
            //    this.Name;
            if (adr.contractDesc.number == null) adr.contractDesc.number = new Pohoda.Xml.Packet.Number();
            adr.contractDesc.number.ids = this.Ids;
            adr.contractDesc.note = this.Remark;
            if (adr.contractDesc.partnerIdentity == null) adr.contractDesc.partnerIdentity = new Pohoda.Xml.Packet.PartnerIdentity();
            //adr.contractDesc.partnerIdentity.id = this.IdPartner;
            if (adr.contractDesc.responsiblePerson == null) adr.contractDesc.responsiblePerson = new Pohoda.Xml.Packet.ResponsiblePerson();
            //adr.contractDesc.responsiblePerson.id = this.IdManager;
            adr.contractDesc.contractState = this.Status.StatusP;
            adr.contractDesc.datePlanStart = this.DatesStatus.PlZahaj;
            adr.contractDesc.datePlanDelivery = this.DatesStatus.PlPredani;
            adr.contractDesc.dateStart = this.DatesStatus.Zahajeni;
            adr.contractDesc.dateDelivery = this.DatesStatus.Predani;
            adr.contractDesc.dateWarranty = this.DatesStatus.Zaruka;
            adr.contractDesc.ost1 = "";
            adr.contractDesc.ost2 = "";
            return adr;
        }

        [NumFunction(18)]
        private Zakazka ConvertToZakazka(Pohoda.Xml.Packet.Contract Ab)
        {
            Zakazka zak = new Zakazka();
            zak.Srv = this.Srv;
            zak.Base = this.Base;
            zak.IcoBase = this.IcoBase;
            zak.Id = Ab.contractDesc.id;
            if (Ab.contractDesc.number != null)
            {
                zak.Ids = string.IsNullOrWhiteSpace(Ab.contractDesc.number.numberRequested) ? "" : Ab.contractDesc.number.numberRequested;
            }
            zak.Name = Ab.contractDesc.text;
            zak.Ost1 = string.IsNullOrWhiteSpace(Ab.contractDesc.note) ? "" : Ab.contractDesc.ost1;
            zak.Ost2 = string.IsNullOrWhiteSpace(Ab.contractDesc.note) ? "" : Ab.contractDesc.ost2;
            zak.Remark = string.IsNullOrWhiteSpace(Ab.contractDesc.note) ? "" : Ab.contractDesc.note;
            zak.KcCelkem = 0;
            zak.Status = new StatusZakazka(Ab.contractDesc.contractState);
            zak.DatesStatus.PlPredani = Ab.contractDesc.datePlanStart;
            zak.DatesStatus.PlZahaj = Ab.contractDesc.datePlanDelivery;
            zak.DatesStatus.Zahajeni = Ab.contractDesc.dateStart;
            zak.DatesStatus.Predani = Ab.contractDesc.dateDelivery;
            zak.DatesStatus.Zaruka = Ab.contractDesc.dateWarranty;
            if (Ab.contractDesc.responsiblePerson != null)
            {
                zak.UserName = User.GetUser(Ab.contractDesc.responsiblePerson.id, this.Srv, this.Base).Ids;
            }

            if (Ab.contractDesc.partnerIdentity != null)
            {
                zak.Partners = new Partner();
                zak.Partners.Id = Ab.contractDesc.partnerIdentity.id;
            }
            return zak;
        }

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Получить Zakazka по ID
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public static Zakazka GetZakazkaFindById(Servers Srv, string NameBase, int Id, string Ico = null)
        {
            Zakazka cou = new Zakazka(Id, Srv, NameBase, Ico);
            return cou;
        }

        /// <summary>
        /// Получить Zakazka по Коду (Name)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">Код страны (например: UA)</param>
        /// <returns></returns>
        public static Zakazka GetZakazkaFindByCislo(Servers Srv, string NameBase, string Cislo, string Ico = null)
        {
            Zakazka cou = new Zakazka(Cislo, Srv, NameBase, Ico);
            return cou;
        }

        /// <summary>
        /// Список или одна валюта
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о стране</param>
        /// <returns></returns>
        public static List<Zakazka> GetList(Servers Srv, string BaseName, string Ico = null)
        {
            Zakazka pr = new Zakazka(0, Srv, BaseName, Ico);
            return pr.CollectionZakazka;
        }


        #endregion
    }
}
