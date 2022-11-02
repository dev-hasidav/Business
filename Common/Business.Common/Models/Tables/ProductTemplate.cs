using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Продукт - шаблон
    /// </summary>
    [NumClass(59)]
    [Serializable]
    public class ProductTemplate : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public ProductTemplate() : base(Actions.SyncProductTemplate) { }
        public ProductTemplate(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncProductTemplate) { }
        public ProductTemplate(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncProductTemplate) { }

        #endregion

        #region  ==========  Property  ==========

        public string Type { set; get; }
        public int IdCateg { set; get; }
        public string Categ { set; get; }
        public int IdUom { set; get; }
        public string Uom { set; get; }
        public int IdUomPo { set; get; }
        public string UomPo { set; get; }
        public string SaleLineWarn { set; get; }
        public string PurchaseLineWarn { set; get; }
        public int IdResponsible { set; get; }
        public string Responsible { set; get; }
        public string Tracking { set; get; }
        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Name)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                    this.Id = 0;
                throw new Exception("function not implemented 'ProductTemplate - LoadSql'");
                //cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                //cn.Open();
                //System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                //{
                //    Connection = cn,
                //    CommandText = string.Format(@"SELECT ID, Pouzit, Kod, IDS FROM {0} where ID = @ID", this.PrAction.TableSql)
                //};
                //if (Id > 0)
                //{
                //    cm.CommandText = string.Format(@"SELECT ID, Pouzit, Kod, IDS FROM {0} where ID = @ID", this.PrAction.TableSql);
                //    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                //    pr_Id.Value = Id;
                //}
                //else if (!string.IsNullOrWhiteSpace(Name))
                //{
                //    cm.CommandText = string.Format(@"SELECT ID, Pouzit, Kod, IDS FROM {0} where Kod = @Kod", this.PrAction.TableSql);
                //    System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                //    pr_Kod.Value = Name;
                //}
                //else { throw new Exception("Input values 'Currency' are NULL"); }
                //System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                //if (dr.Read())
                //{
                //    this.Id = (int)dr["ID"];
                //    this.Name = dr["Kod"] == DBNull.Value ? "" : dr["Kod"].ToString().Trim();
                //    this.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                //    this.Active = (bool)dr["Pouzit"];
                //}
                //dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }
        [NumFunction(2)]
        protected override void CreateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                throw new Exception("function not implemented 'ProductTemplate - CreateSql'");
                //cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                //cn.Open();
                //System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                //{
                //    Connection = cn,
                //    CommandText = string.Format(@"INSERT INTO {0} (Pouzit, Kod, IDS) VALUES (@Pouzit, @Kod, @IDS)" +
                //        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                //};
                //System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                //pr_Kod.Value = this.Name;
                //System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                //if (string.IsNullOrWhiteSpace(this.Ids)) pr_IDS.Value = DBNull.Value;
                //else pr_IDS.Value = this.Ids;
                //System.Data.SqlClient.SqlParameter pr_Active = cm.Parameters.Add("Pouzit", System.Data.SqlDbType.Bit);
                //pr_Active.Value = this.Active;
                //this.Id = 0;
                //this.Id = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                throw new Exception("function not implemented 'ProductTemplate - UpdateSql'");
                //cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                //cn.Open();
                //System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                //{
                //    Connection = cn,
                //    CommandText = string.Format(@"UPDATE {0} SET Pouzit = @Pouzit, IDS = @IDS WHERE (ID = @ID) ", this.PrAction.TableSql)
                //};
                //System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                //if (string.IsNullOrWhiteSpace(this.Ids)) pr_IDS.Value = DBNull.Value;
                //else pr_IDS.Value = this.Ids;
                //System.Data.SqlClient.SqlParameter pr_Active = cm.Parameters.Add("Pouzit", System.Data.SqlDbType.Bit);
                //pr_Active.Value = this.Active;
                //System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                //pr_Id.Value = this.Id;
                //cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                throw new Exception("function not implemented 'ProductTemplate - DeleteSql'");
                //cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                //cn.Open();
                //System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                //{
                //    Connection = cn,
                //    CommandText = string.Format(@"DELETE FROM {0} WHERE (ID = @ID)", this.PrAction.TableSql)
                //};
                //System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                //pr_Id.Value = this.Id;
                //cm.ExecuteNonQuery();
                //this.Id = 0;
                //this.Name = "";
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
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
        protected override void LoadOdoo(int Id, string Name)
        {
            try
            {
                List<string> li_pole = new List<string>
                {
                        "id",
                        "name",
                        "type",
                        "categ_id",
                        "uom_id",
                        "uom_po_id",
                        "sale_line_warn",
                        "purchase_line_warn",
                        "responsible_id",
                        "tracking"
                };
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id > 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    odoFiltr.Filter("name", "=", Name);
                }
                else { throw new Exception("Input values 'ProductTemplate' are NULL"); }
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    this.Id = int.Parse(Datas[0]["id"]);
                    this.Name = Datas[0]["name"] == "False" ? "" : Datas[0]["name"].Trim();
                    this.Type = Datas[0]["type"] == "False" ? "" : Datas[0]["type"].Trim();
                    this.IdCateg = Datas[0]["categ_id"] == "False" ? 0 : int.Parse(Datas[0]["categ_id"]);
                    this.IdUom = Datas[0]["uom_id"] == "False" ? 0 : int.Parse(Datas[0]["uom_id"]);
                    this.IdUomPo = Datas[0]["uom_po_id"] == "False" ? 0 : int.Parse(Datas[0]["uom_po_id"]);
                    this.SaleLineWarn = Datas[0]["sale_line_warn"] == "False" ? "" : Datas[0]["sale_line_warn"].Trim();
                    this.PurchaseLineWarn = Datas[0]["purchase_line_warn"] == "False" ? "" : Datas[0]["purchase_line_warn"].Trim();
                    this.IdResponsible = Datas[0]["responsible_id"] == "False" ? 0 : int.Parse(Datas[0]["responsible_id"]);
                    this.Tracking = Datas[0]["tracking"] == "False" ? "" : Datas[0]["tracking"].Trim();
                    ConvertIdToName();
                }
                else
                {
                    this.Id = 0;
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
                ConvertNameToId();
                OdooScripts odScr = new OdooScripts();
                Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "type", this.Type },
                            { "categ_id", this.IdCateg },
                            { "uom_id", this.IdUom },
                            { "uom_po_id", this.IdUomPo },
                            { "sale_line_warn", this.SaleLineWarn },
                            { "purchase_line_warn", this.PurchaseLineWarn },
                            { "responsible_id", this.IdResponsible },
                            { "tracking", this.Tracking }
                        };
                this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
                this.UpdateOdoo();
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
                ConvertNameToId();
                Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "name", this.Name },
                            { "type", this.Type },
                            { "categ_id", this.IdCateg },
                            { "uom_id", this.IdUom },
                            { "uom_po_id", this.IdUomPo },
                            { "sale_line_warn", this.SaleLineWarn },
                            { "purchase_line_warn", this.PurchaseLineWarn },
                            { "responsible_id", this.IdResponsible },
                            { "tracking", this.Tracking }
                    };
                OdooScripts odScr = new OdooScripts();
                odScr.UpdateRow(Srv, this.PrAction.TableOdoo, this.Id, di);
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
        protected override void LoadPostgre(int Id, string Name)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where name = @name", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_name.Value = Name;
                }
                else { throw new Exception("Input values 'ProductTemplate' are NULL"); }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["id"];
                    this.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    this.Type = dr["type"] == DBNull.Value ? "" : dr["type"].ToString().Trim();
                    this.IdCateg = dr["categ_id"] == DBNull.Value ? 0 : (int) dr["categ_id"];
                    this.IdUom = dr["uom_id"] == DBNull.Value ? 0 : (int)dr["uom_id"];
                    this.IdUomPo = dr["uom_po_id"] == DBNull.Value ? 0 : (int)dr["uom_po_id"];
                    this.SaleLineWarn = dr["sale_line_warn"] == DBNull.Value ? "" : dr["sale_line_warn"].ToString().Trim();
                    this.PurchaseLineWarn = dr["purchase_line_warn"] == DBNull.Value ? "" : dr["purchase_line_warn"].ToString().Trim();
                    this.IdResponsible = dr["responsible_id"] == DBNull.Value ? 0 : (int)dr["responsible_id"];
                    this.Tracking = dr["tracking"] == DBNull.Value ? "" : dr["tracking"].ToString().Trim();
                    ConvertIdToName();
                }
                else
                {
                    this.Id = 0;
                }
                dr.Close();
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
                ConvertNameToId();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (name, type, categ_id, uom_id, uom_po_id, sale_line_warn, purchase_line_warn, responsible_id, tracking) " +
                        @" VALUES (@name, @type, @categ_id, @uom_id, @uom_po_id, @sale_line_warn, @purchase_line_warn, @responsible_id, @tracking)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_type = cm.Parameters.Add("type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_type.Value = this.Type;
                Npgsql.NpgsqlParameter pr_categ_id = cm.Parameters.Add("categ_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_categ_id.Value = this.IdCateg;
                Npgsql.NpgsqlParameter pr_uom_id = cm.Parameters.Add("uom_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_uom_id.Value = this.IdUom;
                Npgsql.NpgsqlParameter pr_uom_po_id = cm.Parameters.Add("uom_po_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_uom_po_id.Value = this.IdUomPo;
                Npgsql.NpgsqlParameter pr_sale_line_warn = cm.Parameters.Add("sale_line_warn", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_sale_line_warn.Value = this.SaleLineWarn;
                Npgsql.NpgsqlParameter pr_purchase_line_warn = cm.Parameters.Add("purchase_line_warn", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_purchase_line_warn.Value = this.PurchaseLineWarn;
                Npgsql.NpgsqlParameter pr_responsible_id = cm.Parameters.Add("responsible_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_responsible_id.Value = this.IdResponsible;
                Npgsql.NpgsqlParameter pr_tracking = cm.Parameters.Add("tracking", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_tracking.Value = this.Tracking;
                this.Id = (int)cm.ExecuteScalar();
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
                ConvertNameToId();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, type = @type, categ_id = @categ_id, uom_id = @uom_id, uom_po_id = @uom_po_id, " +
                        @" sale_line_warn = @sale_line_warn, purchase_line_warn = @purchase_line_warn, responsible_id = @responsible_id, tracking = @tracking " +
                        @" WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_type = cm.Parameters.Add("type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_type.Value = this.Type;
                Npgsql.NpgsqlParameter pr_categ_id = cm.Parameters.Add("categ_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_categ_id.Value = this.IdCateg;
                Npgsql.NpgsqlParameter pr_uom_id = cm.Parameters.Add("uom_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_uom_id.Value = this.IdUom;
                Npgsql.NpgsqlParameter pr_uom_po_id = cm.Parameters.Add("uom_po_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_uom_po_id.Value = this.IdUomPo;
                Npgsql.NpgsqlParameter pr_sale_line_warn = cm.Parameters.Add("sale_line_warn", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_sale_line_warn.Value = this.SaleLineWarn;
                Npgsql.NpgsqlParameter pr_purchase_line_warn = cm.Parameters.Add("purchase_line_warn", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_purchase_line_warn.Value = this.PurchaseLineWarn;
                Npgsql.NpgsqlParameter pr_responsible_id = cm.Parameters.Add("responsible_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_responsible_id.Value = this.IdResponsible;
                Npgsql.NpgsqlParameter pr_tracking = cm.Parameters.Add("tracking", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_tracking.Value = this.Tracking;
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

        #region  ==========  Prepare  ==========

        private void ConvertIdToName()
        {
            Tables.ProductCategory cat = Tables.ProductCategory.GetProductCategoryOrDefault(this.IdCateg, Srv, Base);
            this.Categ = cat.Name;
            this.IdCateg = cat.Id;

            Tables.Uom uo = Tables.Uom.GetUomOrDefault(this.IdUom, Srv, Base);
            this.Uom = uo.Name;
            this.IdUom = uo.Id;

            uo = Tables.Uom.GetUomOrDefault(this.IdUomPo, Srv, Base);
            this.UomPo = uo.Name;
            this.IdUomPo = uo.Id;

            //Tables.User use = Tables.User.GetUserOrDefault(this.IdResponsible, Srv, Base);
            //this.Responsible = use.Name;
            //this.IdResponsible = use.Id;
        }
        private void ConvertNameToId()
        {
            Tables.ProductCategory cat = Tables.ProductCategory.GetProductCategoryOrDefault(this.Name, Srv, Base);
            this.Categ = cat.Name;
            this.IdCateg = cat.Id;

            Tables.Uom uo = Tables.Uom.GetUomOrDefault(this.Name, Srv, Base);
            this.Uom = uo.Name;
            this.IdUom = uo.Id;

            uo = Tables.Uom.GetUomOrDefault(this.Name, Srv, Base);
            this.UomPo = uo.Name;
            this.IdUomPo = uo.Id;

            //Tables.User use = Tables.User.GetUserOrDefault(this.Name, Srv, Base);
            //this.Responsible = use.Name;
            //this.IdResponsible = use.Id;
        }

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список ProductTemplate
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<ProductTemplate> GetList(Servers Srv, string BaseName)
        {
            List<ProductTemplate> li = new List<ProductTemplate>();
            List<int> li_id = ProductTemplate.GetId(Srv, BaseName, Actions.SyncProductTemplate);
            Dictionary<string, ProductTemplate> di = new Dictionary<string, ProductTemplate>();
            List<ProductTemplate> li_l = new List<ProductTemplate>();
            foreach (int item in li_id)
            {
                ProductTemplate bn1 = new ProductTemplate(item, Srv, BaseName, "");
                if (bn1.Id != 0)
                {
                    if (!di.ContainsKey(bn1.Name)) di.Add(bn1.Name, bn1);
                }
            }
            foreach (var item in di)
            {
                li.Add(item.Value);
            }
            di.Clear();
            return li;
        }

        /// <summary>
        /// Получить информацию о ProductTemplate или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ProductTemplate GetProductTemplateOrDefault(int id, Servers Srv, string BaseName)
        {
            ProductTemplate com = new ProductTemplate(id, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultProductTemplate(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о ProductTemplate  или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Name">Name</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ProductTemplate GetProductTemplateOrDefault(string Name, Servers Srv, string BaseName)
        {
            ProductTemplate com = new ProductTemplate(Name, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultProductTemplate(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о default ProductTemplate. Если нет - создать
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ProductTemplate GetDefaultProductTemplate(Servers Srv, string BaseName)
        {
            ProductTemplateDefault dcom = new ProductTemplateDefault();
            ProductTemplate com = new ProductTemplate(dcom.Name, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com.Name = dcom.Name;
                com.Type = dcom.Type;
                com.SaleLineWarn = dcom.SaleLineWarn;
                com.PurchaseLineWarn = dcom.PurchaseLineWarn;
                com.Tracking = dcom.Tracking;
                com.Create();
                com = new ProductTemplate(com.Id, Srv, BaseName, "");
            }
            return com;
        }
        #endregion
    }
    public class ProductTemplateDefault
    {
        public string Name { private set; get; } = "Sinchro product";
        public string Type { private set; get; } = "service";
        public string SaleLineWarn { private set; get; } = "no-nessage";
        public string PurchaseLineWarn { private set; get; } = "no-nessage";
        public string Tracking { private set; get; } = "none";
    }

}
