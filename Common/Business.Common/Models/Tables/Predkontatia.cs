using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Atributes;

namespace Business.Models.Tables
{
    [NumClass(73)]
    [Serializable]
    public class Predkontatia : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Predkontatia() : base(Actions.SyncPk) { }
        public Predkontatia(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncPk) { }
        public Predkontatia(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncPk) { }

        #endregion

        #region  ==========  Property  ==========

        public string Umd { set; get; }
        public string Ud { set; get; }
        public string Name1 { set; get; }
        public string Umd1 { set; get; }
        public string Ud1 { set; get; }
        public string Name2 { set; get; }
        public string Umd2 { set; get; }
        public string Ud2 { set; get; }
        public string Name3 { set; get; }
        public string Umd3 { set; get; }
        public string Ud3 { set; get; }

        private List<Predkontatia> _CollectionPredkontatia = new List<Predkontatia>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Predkontatia> CollectionPredkontatia { get { return _CollectionPredkontatia; } set { _CollectionPredkontatia = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
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
                    CommandText = string.Format(@"SELECT * FROM {0} ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where IDS = @IDS", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                    pr_Kod.Value = Ids;
                }
                else { IsSelect = false; }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Predkontatia cr = new Predkontatia();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = (int)dr["ID"];
                    cr.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    cr.Name = dr["Name"] == DBNull.Value ? "" : dr["Name"].ToString().Trim();
                    cr.Umd = dr["UMD"] == DBNull.Value ? "" : dr["UMD"].ToString().Trim();
                    cr.Ud = dr["UD"] == DBNull.Value ? "" : dr["UD"].ToString().Trim();
                    cr.Name1 = dr["Name1"] == DBNull.Value ? "" : dr["Name1"].ToString().Trim();
                    cr.Umd1 = dr["UMD1"] == DBNull.Value ? "" : dr["UMD1"].ToString().Trim();
                    cr.Ud1 = dr["UD1"] == DBNull.Value ? "" : dr["UD1"].ToString().Trim();
                    cr.Name2 = dr["Name2"] == DBNull.Value ? "" : dr["Name2"].ToString().Trim();
                    cr.Umd2 = dr["UMD2"] == DBNull.Value ? "" : dr["UMD2"].ToString().Trim();
                    cr.Ud2 = dr["UD2"] == DBNull.Value ? "" : dr["UD2"].ToString().Trim();
                    cr.Name3 = dr["Name3"] == DBNull.Value ? "" : dr["Name3"].ToString().Trim();
                    cr.Umd3 = dr["UMD3"] == DBNull.Value ? "" : dr["UMD3"].ToString().Trim();
                    cr.Ud3 = dr["UD3"] == DBNull.Value ? "" : dr["UD3"].ToString().Trim();
                    this.CollectionPredkontatia.Add(cr);
                    cr.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionPredkontatia.Count != 0)
                {
                    this.Id = this.CollectionPredkontatia[0].Id;
                    this.Ids = this.CollectionPredkontatia[0].Ids;
                    this.Name = this.CollectionPredkontatia[0].Name;
                    this.Umd = this.CollectionPredkontatia[0].Umd;
                    this.Ud = this.CollectionPredkontatia[0].Ud;
                    this.Name1 = this.CollectionPredkontatia[0].Name1;
                    this.Umd1 = this.CollectionPredkontatia[0].Umd1;
                    this.Ud1 = this.CollectionPredkontatia[0].Ud1;
                    this.Name2 = this.CollectionPredkontatia[0].Name2;
                    this.Umd2 = this.CollectionPredkontatia[0].Umd2;
                    this.Ud2 = this.CollectionPredkontatia[0].Ud2;
                    this.Name3 = this.CollectionPredkontatia[0].Name3;
                    this.Umd3 = this.CollectionPredkontatia[0].Umd3;
                    this.Ud3 = this.CollectionPredkontatia[0].Ud3;
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
                    CommandText = string.Format(@"INSERT INTO {0} (IDS, sText, UMD, UD, sText1, UMD1, UD1, sText2, UMD2, UD2, sText3, UMD3, UD3) " +
                        @" VALUES (@IDS, @sText, @UMD, @UD, @sText1, @UMD1, @UD1, @sText2, @UMD2, @UD2, @sText3, @UMD3, @UD3)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText = cm.Parameters.Add("sText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd = cm.Parameters.Add("UMD", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud = cm.Parameters.Add("UD", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText1 = cm.Parameters.Add("sText1", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd1 = cm.Parameters.Add("UMD1", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud1 = cm.Parameters.Add("UD1", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText2 = cm.Parameters.Add("sText2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd2 = cm.Parameters.Add("UMD2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud2 = cm.Parameters.Add("UD2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText3 = cm.Parameters.Add("sText3", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd3 = cm.Parameters.Add("UMD3", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud3 = cm.Parameters.Add("UD3", System.Data.SqlDbType.VarChar);

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPredkontatia)
                    {
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_sText.Value = DBNull.Value;
                        else pr_sText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Umd)) pr_Umd.Value = DBNull.Value;
                        else pr_Umd.Value = item.Umd;
                        if (string.IsNullOrWhiteSpace(item.Ud)) pr_Ud.Value = DBNull.Value;
                        else pr_Ud.Value = item.Ud;
                        if (string.IsNullOrWhiteSpace(item.Name1)) pr_sText1.Value = DBNull.Value;
                        else pr_sText1.Value = item.Name1;
                        if (string.IsNullOrWhiteSpace(item.Umd1)) pr_Umd1.Value = DBNull.Value;
                        else pr_Umd1.Value = item.Umd1;
                        if (string.IsNullOrWhiteSpace(item.Ud1)) pr_Ud1.Value = DBNull.Value;
                        else pr_Ud1.Value = item.Ud1;
                        if (string.IsNullOrWhiteSpace(item.Name2)) pr_sText2.Value = DBNull.Value;
                        else pr_sText2.Value = item.Name2;
                        if (string.IsNullOrWhiteSpace(item.Umd2)) pr_Umd2.Value = DBNull.Value;
                        else pr_Umd2.Value = item.Umd2;
                        if (string.IsNullOrWhiteSpace(item.Ud2)) pr_Ud2.Value = DBNull.Value;
                        else pr_Ud2.Value = item.Ud2;
                        if (string.IsNullOrWhiteSpace(item.Name3)) pr_sText3.Value = DBNull.Value;
                        else pr_sText3.Value = item.Name3;
                        if (string.IsNullOrWhiteSpace(item.Umd3)) pr_Umd3.Value = DBNull.Value;
                        else pr_Umd3.Value = item.Umd3;
                        if (string.IsNullOrWhiteSpace(item.Ud3)) pr_Ud3.Value = DBNull.Value;
                        else pr_Ud3.Value = item.Ud3;
                        item.Id = (int)cm.ExecuteScalar();
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_sText.Value = DBNull.Value;
                    else pr_sText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Umd)) pr_Umd.Value = DBNull.Value;
                    else pr_Umd.Value = this.Umd;
                    if (string.IsNullOrWhiteSpace(this.Ud)) pr_Ud.Value = DBNull.Value;
                    else pr_Ud.Value = this.Ud;
                    if (string.IsNullOrWhiteSpace(this.Name1)) pr_sText1.Value = DBNull.Value;
                    else pr_sText1.Value = this.Name1;
                    if (string.IsNullOrWhiteSpace(this.Umd1)) pr_Umd1.Value = DBNull.Value;
                    else pr_Umd1.Value = this.Umd1;
                    if (string.IsNullOrWhiteSpace(this.Ud1)) pr_Ud1.Value = DBNull.Value;
                    else pr_Ud1.Value = this.Ud1;
                    if (string.IsNullOrWhiteSpace(this.Name2)) pr_sText2.Value = DBNull.Value;
                    else pr_sText2.Value = this.Name2;
                    if (string.IsNullOrWhiteSpace(this.Umd2)) pr_Umd2.Value = DBNull.Value;
                    else pr_Umd2.Value = this.Umd2;
                    if (string.IsNullOrWhiteSpace(this.Ud2)) pr_Ud2.Value = DBNull.Value;
                    else pr_Ud2.Value = this.Ud2;
                    if (string.IsNullOrWhiteSpace(this.Name3)) pr_sText3.Value = DBNull.Value;
                    else pr_sText3.Value = this.Name3;
                    if (string.IsNullOrWhiteSpace(this.Umd3)) pr_Umd3.Value = DBNull.Value;
                    else pr_Umd3.Value = this.Umd3;
                    if (string.IsNullOrWhiteSpace(this.Ud3)) pr_Ud3.Value = DBNull.Value;
                    else pr_Ud3.Value = this.Ud3;
                    this.Id = (int)cm.ExecuteScalar();
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
                    CommandText = string.Format(@"UPDATE {0} SET IDS = @IDS, " +
                        @" SText = @sText, UMD = @UMD, UD = @UD, SText1 = @sText1, UMD1 = @UMD1, UD1 = @UD1, " +
                        @" SText2 = @sText2, UMD2 = @UMD2, UD2 = @UD2, SText3 = @sText3, UMD3 = @UMD3, UD3 = @UD3 " +
                        @" WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText = cm.Parameters.Add("sText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd = cm.Parameters.Add("UMD", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud = cm.Parameters.Add("UD", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText1 = cm.Parameters.Add("sText1", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd1 = cm.Parameters.Add("UMD1", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud1 = cm.Parameters.Add("UD1", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText2 = cm.Parameters.Add("sText2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd2 = cm.Parameters.Add("UMD2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud2 = cm.Parameters.Add("UD2", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText3 = cm.Parameters.Add("sText3", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Umd3 = cm.Parameters.Add("UMD3", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ud3 = cm.Parameters.Add("UD3", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPredkontatia)
                    {
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_sText.Value = DBNull.Value;
                        else pr_sText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Umd)) pr_Umd.Value = DBNull.Value;
                        else pr_Umd.Value = item.Umd;
                        if (string.IsNullOrWhiteSpace(item.Ud)) pr_Ud.Value = DBNull.Value;
                        else pr_Ud.Value = item.Ud;
                        if (string.IsNullOrWhiteSpace(item.Name1)) pr_sText1.Value = DBNull.Value;
                        else pr_sText1.Value = item.Name1;
                        if (string.IsNullOrWhiteSpace(item.Umd1)) pr_Umd1.Value = DBNull.Value;
                        else pr_Umd1.Value = item.Umd1;
                        if (string.IsNullOrWhiteSpace(item.Ud1)) pr_Ud1.Value = DBNull.Value;
                        else pr_Ud1.Value = item.Ud1;
                        if (string.IsNullOrWhiteSpace(item.Name2)) pr_sText2.Value = DBNull.Value;
                        else pr_sText2.Value = item.Name2;
                        if (string.IsNullOrWhiteSpace(item.Umd2)) pr_Umd2.Value = DBNull.Value;
                        else pr_Umd2.Value = item.Umd2;
                        if (string.IsNullOrWhiteSpace(item.Ud2)) pr_Ud2.Value = DBNull.Value;
                        else pr_Ud2.Value = item.Ud2;
                        if (string.IsNullOrWhiteSpace(item.Name3)) pr_sText3.Value = DBNull.Value;
                        else pr_sText3.Value = item.Name3;
                        if (string.IsNullOrWhiteSpace(item.Umd3)) pr_Umd3.Value = DBNull.Value;
                        else pr_Umd3.Value = item.Umd3;
                        if (string.IsNullOrWhiteSpace(item.Ud3)) pr_Ud3.Value = DBNull.Value;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_sText.Value = DBNull.Value;
                    else pr_sText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Umd)) pr_Umd.Value = DBNull.Value;
                    else pr_Umd.Value = this.Umd;
                    if (string.IsNullOrWhiteSpace(this.Ud)) pr_Ud.Value = DBNull.Value;
                    else pr_Ud.Value = this.Ud;
                    if (string.IsNullOrWhiteSpace(this.Name1)) pr_sText1.Value = DBNull.Value;
                    else pr_sText1.Value = this.Name1;
                    if (string.IsNullOrWhiteSpace(this.Umd1)) pr_Umd1.Value = DBNull.Value;
                    else pr_Umd1.Value = this.Umd1;
                    if (string.IsNullOrWhiteSpace(this.Ud1)) pr_Ud1.Value = DBNull.Value;
                    else pr_Ud1.Value = this.Ud1;
                    if (string.IsNullOrWhiteSpace(this.Name2)) pr_sText2.Value = DBNull.Value;
                    else pr_sText2.Value = this.Name2;
                    if (string.IsNullOrWhiteSpace(this.Umd2)) pr_Umd2.Value = DBNull.Value;
                    else pr_Umd2.Value = this.Umd2;
                    if (string.IsNullOrWhiteSpace(this.Ud2)) pr_Ud2.Value = DBNull.Value;
                    else pr_Ud2.Value = this.Ud2;
                    if (string.IsNullOrWhiteSpace(this.Name3)) pr_sText3.Value = DBNull.Value;
                    else pr_sText3.Value = this.Name3;
                    if (string.IsNullOrWhiteSpace(this.Umd3)) pr_Umd3.Value = DBNull.Value;
                    else pr_Umd3.Value = this.Umd3;
                    if (string.IsNullOrWhiteSpace(this.Ud3)) pr_Ud3.Value = DBNull.Value;
                    else pr_Ud3.Value = this.Ud3;
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
            LoadSql(Id, Ids);
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
            this.IsRecord = NumberRecord.Many;
            bool IsSelect = true;
            try
            {
                List<string> li_pole = new List<string>
                {
                        "id",
                        "x_ids",
                        "x_name",
                        "x_umd",
                        "x_ud",
                        "x_name1",
                        "x_umd1",
                        "x_ud1",
                        "x_name2",
                        "x_umd2",
                        "x_ud2",
                        "x_name3",
                        "x_umd3",
                        "x_ud3"
                };
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id > 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    odoFiltr.Filter("x_ids", "=", Ids);
                }
                else { IsSelect = false; }
                odoFiltr.Filter("active", "!=", null);
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                foreach (var item in Datas)
                {
                    Predkontatia cr = new Predkontatia();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = int.Parse(item["id"]);
                    cr.Ids = item["x_ids"] == "False" ? "" : item["x_ids"];
                    cr.Name = item["x_name"] == "False" ? "" : item["x_name"];
                    cr.Umd = item["x_umd"] == "False" ? "" : item["x_umd"];
                    cr.Ud = item["x_ud"] == "False" ? "" : item["x_ud"];
                    cr.Name1 = item["x_name1"] == "False" ? "" : item["x_name1"];
                    cr.Umd1 = item["x_umd1"] == "False" ? "" : item["x_umd1"];
                    cr.Ud1 = item["x_ud1"] == "False" ? "" : item["x_ud1"];
                    cr.Name2 = item["x_name2"] == "False" ? "" : item["x_name2"];
                    cr.Umd2 = item["x_umd2"] == "False" ? "" : item["x_umd2"];
                    cr.Ud2 = item["x_ud2"] == "False" ? "" : item["x_ud2"];
                    cr.Name3 = item["x_name3"] == "False" ? "" : item["x_name3"];
                    cr.Umd3 = item["x_umd3"] == "False" ? "" : item["x_umd3"];
                    cr.Ud3 = item["x_ud3"] == "False" ? "" : item["x_ud3"];
                    this.CollectionPredkontatia.Add(cr);
                }
                if (IsSelect && this.CollectionPredkontatia.Count != 0)
                {
                    this.Id = this.CollectionPredkontatia[0].Id;
                    this.Ids = this.CollectionPredkontatia[0].Ids;
                    this.Name = this.CollectionPredkontatia[0].Name;
                    this.Umd = this.CollectionPredkontatia[0].Umd;
                    this.Ud = this.CollectionPredkontatia[0].Ud;
                    this.Name1 = this.CollectionPredkontatia[0].Name1;
                    this.Umd1 = this.CollectionPredkontatia[0].Umd1;
                    this.Ud1 = this.CollectionPredkontatia[0].Ud1;
                    this.Name2 = this.CollectionPredkontatia[0].Name2;
                    this.Umd2 = this.CollectionPredkontatia[0].Umd2;
                    this.Ud2 = this.CollectionPredkontatia[0].Ud2;
                    this.Name3 = this.CollectionPredkontatia[0].Name3;
                    this.Umd3 = this.CollectionPredkontatia[0].Umd3;
                    this.Ud3 = this.CollectionPredkontatia[0].Ud3;
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
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPredkontatia)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ids", item.Ids },
                            { "x_name", item.Name },
                            { "x_umd", item.Umd },
                            { "x_ud", item.Ud },
                            { "x_name1", item.Name1 },
                            { "x_umd1", item.Umd1 },
                            { "x_ud1", item.Ud1 },
                            { "x_name2", item.Name2 },
                            { "x_umd2", item.Umd2 },
                            { "x_ud2", item.Ud2 },
                            { "x_name3", item.Name3 },
                            { "x_umd3", item.Umd3 },
                            { "x_ud3", item.Ud3 }
                        };
                        this.Id = (int)odScr.InsertRow(Srv, item.PrAction.TableOdoo, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ids", this.Ids },
                            { "x_name", this.Name },
                            { "x_umd", this.Umd },
                            { "x_ud", this.Ud },
                            { "x_name1", this.Name1 },
                            { "x_umd1", this.Umd1 },
                            { "x_ud1", this.Ud1 },
                            { "x_name2", this.Name2 },
                            { "x_umd2", this.Umd2 },
                            { "x_ud2", this.Ud2 },
                            { "x_name3", this.Name3 },
                            { "x_umd3", this.Umd3 },
                            { "x_ud3", this.Ud3 }
                        };
                    this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
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
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPredkontatia)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "x_ids", item.Ids },
                            { "x_name", item.Name },
                            { "x_umd", item.Umd },
                            { "x_ud", item.Ud },
                            { "x_name1", item.Name1 },
                            { "x_umd1", item.Umd1 },
                            { "x_ud1", item.Ud1 },
                            { "x_name2", item.Name2 },
                            { "x_umd2", item.Umd2 },
                            { "x_ud2", item.Ud2 },
                            { "x_name3", item.Name3 },
                            { "x_umd3", item.Umd3 },
                            { "x_ud3", item.Ud3 }
                        };
                        odScr.UpdateRow(Srv, item.PrAction.TableOdoo, item.Id, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "x_ids", this.Ids },
                            { "x_name", this.Name },
                            { "x_umd", this.Umd },
                            { "x_ud", this.Ud },
                            { "x_name1", this.Name1 },
                            { "x_umd1", this.Umd1 },
                            { "x_ud1", this.Ud1 },
                            { "x_name2", this.Name2 },
                            { "x_umd2", this.Umd2 },
                            { "x_ud2", this.Ud2 },
                            { "x_name3", this.Name3 },
                            { "x_umd3", this.Umd3 },
                            { "x_ud3", this.Ud3 }
                    };
                    odScr.UpdateRow(Srv, this.PrAction.TableOdoo, this.Id, di);
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
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        #endregion

        #region  ==========  Postgre  ==========
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
                    CommandText = string.Format(@"SELECT * FROM {0} ", this.PrAction.TablePostgreSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where x_ids = @x_ids", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_x_ids = cm.Parameters.Add("x_ids", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_x_ids.Value = Ids;
                }
                else { IsSelect = false; }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Predkontatia cr = new Predkontatia();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = (int)dr["id"];
                    cr.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    cr.Name = dr["Name"] == DBNull.Value ? "" : dr["Name"].ToString().Trim();
                    cr.Umd = dr["UMD"] == DBNull.Value ? "" : dr["UMD"].ToString().Trim();
                    cr.Ud = dr["UD"] == DBNull.Value ? "" : dr["UD"].ToString().Trim();
                    cr.Name1 = dr["Name1"] == DBNull.Value ? "" : dr["Name1"].ToString().Trim();
                    cr.Umd1 = dr["UMD1"] == DBNull.Value ? "" : dr["UMD1"].ToString().Trim();
                    cr.Ud1 = dr["UD1"] == DBNull.Value ? "" : dr["UD1"].ToString().Trim();
                    cr.Name2 = dr["Name2"] == DBNull.Value ? "" : dr["Name2"].ToString().Trim();
                    cr.Umd2 = dr["UMD2"] == DBNull.Value ? "" : dr["UMD2"].ToString().Trim();
                    cr.Ud2 = dr["UD2"] == DBNull.Value ? "" : dr["UD2"].ToString().Trim();
                    cr.Name3 = dr["Name3"] == DBNull.Value ? "" : dr["Name3"].ToString().Trim();
                    cr.Umd3 = dr["UMD3"] == DBNull.Value ? "" : dr["UMD3"].ToString().Trim();
                    cr.Ud3 = dr["UD3"] == DBNull.Value ? "" : dr["UD3"].ToString().Trim();
                    this.CollectionPredkontatia.Add(cr);
                }
                dr.Close();
                if (IsSelect && this.CollectionPredkontatia.Count != 0)
                {
                    this.Id = this.CollectionPredkontatia[0].Id;
                    this.Ids = this.CollectionPredkontatia[0].Ids;
                    this.Name = this.CollectionPredkontatia[0].Name;
                    this.Umd = this.CollectionPredkontatia[0].Umd;
                    this.Ud = this.CollectionPredkontatia[0].Ud;
                    this.Name1 = this.CollectionPredkontatia[0].Name1;
                    this.Umd1 = this.CollectionPredkontatia[0].Umd1;
                    this.Ud1 = this.CollectionPredkontatia[0].Ud1;
                    this.Name2 = this.CollectionPredkontatia[0].Name2;
                    this.Umd2 = this.CollectionPredkontatia[0].Umd2;
                    this.Ud2 = this.CollectionPredkontatia[0].Ud2;
                    this.Name3 = this.CollectionPredkontatia[0].Name3;
                    this.Umd3 = this.CollectionPredkontatia[0].Umd3;
                    this.Ud3 = this.CollectionPredkontatia[0].Ud3;
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
                    CommandText = string.Format(@"INSERT INTO {0} (IDS, sText, UMD, @UD, sText1, UMD1, @UD1, sText2, UMD2, @UD2, sText3, UMD3, @UD3) " +
                        @" VALUES (@IDS, @sText, @UMD, @UD, @sText1, @UMD1, @UD1, @sText2, @UMD2, @UD2, @sText3, @UMD3, @UD3)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_IDS = cm.Parameters.Add("IDS", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText = cm.Parameters.Add("sText", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd = cm.Parameters.Add("UMD", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud = cm.Parameters.Add("UD", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText1 = cm.Parameters.Add("sText1", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd1 = cm.Parameters.Add("UMD1", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud1 = cm.Parameters.Add("UD1", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText2 = cm.Parameters.Add("sText2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd2 = cm.Parameters.Add("UMD2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud2 = cm.Parameters.Add("UD2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText3 = cm.Parameters.Add("sText3", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd3 = cm.Parameters.Add("UMD3", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud3 = cm.Parameters.Add("UD3", NpgsqlTypes.NpgsqlDbType.Varchar);

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPredkontatia)
                    {
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_sText.Value = DBNull.Value;
                        else pr_sText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Umd)) pr_Umd.Value = DBNull.Value;
                        else pr_Umd.Value = item.Umd;
                        if (string.IsNullOrWhiteSpace(item.Ud)) pr_Ud.Value = DBNull.Value;
                        else pr_Ud.Value = item.Ud;
                        if (string.IsNullOrWhiteSpace(item.Name1)) pr_sText1.Value = DBNull.Value;
                        else pr_sText1.Value = item.Name1;
                        if (string.IsNullOrWhiteSpace(item.Umd1)) pr_Umd1.Value = DBNull.Value;
                        else pr_Umd1.Value = item.Umd1;
                        if (string.IsNullOrWhiteSpace(item.Ud1)) pr_Ud1.Value = DBNull.Value;
                        else pr_Ud1.Value = item.Ud1;
                        if (string.IsNullOrWhiteSpace(item.Name2)) pr_sText2.Value = DBNull.Value;
                        else pr_sText2.Value = item.Name2;
                        if (string.IsNullOrWhiteSpace(item.Umd2)) pr_Umd2.Value = DBNull.Value;
                        else pr_Umd2.Value = item.Umd2;
                        if (string.IsNullOrWhiteSpace(item.Ud2)) pr_Ud2.Value = DBNull.Value;
                        else pr_Ud2.Value = item.Ud2;
                        if (string.IsNullOrWhiteSpace(item.Name3)) pr_sText3.Value = DBNull.Value;
                        else pr_sText3.Value = item.Name3;
                        if (string.IsNullOrWhiteSpace(item.Umd3)) pr_Umd3.Value = DBNull.Value;
                        else pr_Umd3.Value = item.Umd3;
                        if (string.IsNullOrWhiteSpace(item.Ud3)) pr_Ud3.Value = DBNull.Value;
                        else pr_Ud3.Value = item.Ud3;
                        item.Id = (int)((long)cm.ExecuteScalar());
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_sText.Value = DBNull.Value;
                    else pr_sText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Umd)) pr_Umd.Value = DBNull.Value;
                    else pr_Umd.Value = this.Umd;
                    if (string.IsNullOrWhiteSpace(this.Ud)) pr_Ud.Value = DBNull.Value;
                    else pr_Ud.Value = this.Ud;
                    if (string.IsNullOrWhiteSpace(this.Name1)) pr_sText1.Value = DBNull.Value;
                    else pr_sText1.Value = this.Name1;
                    if (string.IsNullOrWhiteSpace(this.Umd1)) pr_Umd1.Value = DBNull.Value;
                    else pr_Umd1.Value = this.Umd1;
                    if (string.IsNullOrWhiteSpace(this.Ud1)) pr_Ud1.Value = DBNull.Value;
                    else pr_Ud1.Value = this.Ud1;
                    if (string.IsNullOrWhiteSpace(this.Name2)) pr_sText2.Value = DBNull.Value;
                    else pr_sText2.Value = this.Name2;
                    if (string.IsNullOrWhiteSpace(this.Umd2)) pr_Umd2.Value = DBNull.Value;
                    else pr_Umd2.Value = this.Umd2;
                    if (string.IsNullOrWhiteSpace(this.Ud2)) pr_Ud2.Value = DBNull.Value;
                    else pr_Ud2.Value = this.Ud2;
                    if (string.IsNullOrWhiteSpace(this.Name3)) pr_sText3.Value = DBNull.Value;
                    else pr_sText3.Value = this.Name3;
                    if (string.IsNullOrWhiteSpace(this.Umd3)) pr_Umd3.Value = DBNull.Value;
                    else pr_Umd3.Value = this.Umd3;
                    if (string.IsNullOrWhiteSpace(this.Ud3)) pr_Ud3.Value = DBNull.Value;
                    else pr_Ud3.Value = this.Ud3;
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
                    CommandText = string.Format(@"UPDATE {0} SET x_ids = @x_ids, x_name = @x_remark, x_remark = @x_zeme WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                this.Id = (int)((long)cm.ExecuteScalar());
                Npgsql.NpgsqlParameter pr_IDS = cm.Parameters.Add("IDS", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText = cm.Parameters.Add("sText", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd = cm.Parameters.Add("UMD", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud = cm.Parameters.Add("UD", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText1 = cm.Parameters.Add("sText1", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd1 = cm.Parameters.Add("UMD1", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud1 = cm.Parameters.Add("UD1", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText2 = cm.Parameters.Add("sText2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd2 = cm.Parameters.Add("UMD2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud2 = cm.Parameters.Add("UD2", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_sText3 = cm.Parameters.Add("sText3", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Umd3 = cm.Parameters.Add("UMD3", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ud3 = cm.Parameters.Add("UD3", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionPredkontatia)
                    {
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_sText.Value = DBNull.Value;
                        else pr_sText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Umd)) pr_Umd.Value = DBNull.Value;
                        else pr_Umd.Value = item.Umd;
                        if (string.IsNullOrWhiteSpace(item.Ud)) pr_Ud.Value = DBNull.Value;
                        else pr_Ud.Value = item.Ud;
                        if (string.IsNullOrWhiteSpace(item.Name1)) pr_sText1.Value = DBNull.Value;
                        else pr_sText1.Value = item.Name1;
                        if (string.IsNullOrWhiteSpace(item.Umd1)) pr_Umd1.Value = DBNull.Value;
                        else pr_Umd1.Value = item.Umd1;
                        if (string.IsNullOrWhiteSpace(item.Ud1)) pr_Ud1.Value = DBNull.Value;
                        else pr_Ud1.Value = item.Ud1;
                        if (string.IsNullOrWhiteSpace(item.Name2)) pr_sText2.Value = DBNull.Value;
                        else pr_sText2.Value = item.Name2;
                        if (string.IsNullOrWhiteSpace(item.Umd2)) pr_Umd2.Value = DBNull.Value;
                        else pr_Umd2.Value = item.Umd2;
                        if (string.IsNullOrWhiteSpace(item.Ud2)) pr_Ud2.Value = DBNull.Value;
                        else pr_Ud2.Value = item.Ud2;
                        if (string.IsNullOrWhiteSpace(item.Name3)) pr_sText3.Value = DBNull.Value;
                        else pr_sText3.Value = item.Name3;
                        if (string.IsNullOrWhiteSpace(item.Umd3)) pr_Umd3.Value = DBNull.Value;
                        else pr_Umd3.Value = item.Umd3;
                        if (string.IsNullOrWhiteSpace(item.Ud3)) pr_Ud3.Value = DBNull.Value;
                        else pr_Ud3.Value = item.Ud3;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_sText.Value = DBNull.Value;
                    else pr_sText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Umd)) pr_Umd.Value = DBNull.Value;
                    else pr_Umd.Value = this.Umd;
                    if (string.IsNullOrWhiteSpace(this.Ud)) pr_Ud.Value = DBNull.Value;
                    else pr_Ud.Value = this.Ud;
                    if (string.IsNullOrWhiteSpace(this.Name1)) pr_sText1.Value = DBNull.Value;
                    else pr_sText1.Value = this.Name1;
                    if (string.IsNullOrWhiteSpace(this.Umd1)) pr_Umd1.Value = DBNull.Value;
                    else pr_Umd1.Value = this.Umd1;
                    if (string.IsNullOrWhiteSpace(this.Ud1)) pr_Ud1.Value = DBNull.Value;
                    else pr_Ud1.Value = this.Ud1;
                    if (string.IsNullOrWhiteSpace(this.Name2)) pr_sText2.Value = DBNull.Value;
                    else pr_sText2.Value = this.Name2;
                    if (string.IsNullOrWhiteSpace(this.Umd2)) pr_Umd2.Value = DBNull.Value;
                    else pr_Umd2.Value = this.Umd2;
                    if (string.IsNullOrWhiteSpace(this.Ud2)) pr_Ud2.Value = DBNull.Value;
                    else pr_Ud2.Value = this.Ud2;
                    if (string.IsNullOrWhiteSpace(this.Name3)) pr_sText3.Value = DBNull.Value;
                    else pr_sText3.Value = this.Name3;
                    if (string.IsNullOrWhiteSpace(this.Umd3)) pr_Umd3.Value = DBNull.Value;
                    else pr_Umd3.Value = this.Umd3;
                    if (string.IsNullOrWhiteSpace(this.Ud3)) pr_Ud3.Value = DBNull.Value;
                    else pr_Ud3.Value = this.Ud3;
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

        #region  ==========  Static  ==========

        /// <summary>
        /// Получить валюту по ID
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public static Predkontatia GetPredkontatia(Servers Srv, string NameBase, int Id)
        {
            Predkontatia cou = new Predkontatia(Id, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Получить валюту по Коду (Name)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">Код страны (например: UA)</param>
        /// <returns></returns>
        public static Predkontatia GetPredkontatia(Servers Srv, string NameBase, string Ids)
        {
            Predkontatia cou = new Predkontatia(Ids, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Список или одна валюта
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о стране</param>
        /// <returns></returns>
        public static List<Predkontatia> GetList(Servers Srv, string BaseName)
        {
            List<Predkontatia> li = new List<Predkontatia>();
            Predkontatia bn1 = new Predkontatia(0, Srv, BaseName, "");
            foreach (var item in bn1.CollectionPredkontatia)
            {
                if (item.Id != 0) li.Add(item);
            }
            return li;
        }

        public static Dictionary<string, Predkontatia> GetChashPredkontatiaIds(Servers Srv, string BaseName)
        {
            Dictionary<string, Predkontatia> di_id = new Dictionary<string, Predkontatia>();
            Predkontatia bn = new Predkontatia(0, Srv, BaseName, null);
            foreach (Predkontatia pb in bn.CollectionPredkontatia)
            {
                if (string.IsNullOrWhiteSpace(pb.Ids)) continue;
                if (di_id.ContainsKey(pb.Ids)) continue;
                di_id.Add(pb.Ids, pb);
            }
            return di_id;
        }

        public static Dictionary<int, Predkontatia> GetChashPartnerId(Servers Srv, string BaseName)
        {
            Dictionary<int, Predkontatia> di_id = new Dictionary<int, Predkontatia>();
            Predkontatia bn = new Predkontatia(0, Srv, BaseName, null);
            foreach (Predkontatia pb in bn.CollectionPredkontatia)
            {
                di_id.Add(pb.Id, pb);
            }
            return di_id;
        }

        #endregion
    }
}
