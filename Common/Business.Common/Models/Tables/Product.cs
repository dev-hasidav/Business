using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Продукт
    /// </summary>
    [NumClass(58)]
    [Serializable]
    public class Product : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Product() : base(Actions.SyncProduct) { }
        public Product(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncProduct) { }
        public Product(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncProduct) { }

        #endregion

        #region  ==========  Property  ==========

        public int IdProductTmpl { set; get; }
        public string ProductTmpl { set; get; }
        public string DefaultCode { set; get; }
        public string Barcode { set; get; }
        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Name)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                    this.Id = 0;
                throw new Exception("function not implemented 'Product - LoadSql'");
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
                throw new Exception("function not implemented 'Product - CreateSql'");
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
                throw new Exception("function not implemented 'Product - UpdateSql'");
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
                throw new Exception("function not implemented 'Product - DeleteSql'");
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
                        "product_tmpl_id",
                        "default_code",
                        "barcode"
                };
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id > 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                //else if (!string.IsNullOrWhiteSpace(Name))
                //{
                //    odoFiltr.Filter("name", "=", Name);
                //}
                else { throw new Exception("Input values 'Product' are NULL"); }
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    this.Id = int.Parse(Datas[0]["id"]);
                    this.IdProductTmpl = int.Parse(Datas[0]["product_tmpl_id"]);
                    this.DefaultCode = Datas[0]["default_code"] == "False" ? "" : Datas[0]["default_code"].Trim();
                    this.Barcode = Datas[0]["barcode"] == "False" ? "" : Datas[0]["barcode"].Trim();
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
                            { "product_tmpl_id", this.IdProductTmpl },
                            { "default_code", this.DefaultCode },
                            { "barcode", this.Barcode }
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
                            { "product_tmpl_id", this.IdProductTmpl },
                            { "default_code", this.DefaultCode },
                            { "barcode", this.Barcode }
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
                else { throw new Exception("Input values 'Product' are NULL"); }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["id"];
                    this.IdProductTmpl = dr["product_tmpl_id"] == DBNull.Value ? 0 : (int)dr["product_tmpl_id"];
                    this.DefaultCode = dr["default_code"] == DBNull.Value ? "" : dr["default_code"].ToString().Trim();
                    this.Barcode = dr["barcode"] == DBNull.Value ? "" : dr["barcode"].ToString().Trim();
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
                    CommandText = string.Format(@"INSERT INTO {0} (product_tmpl_id, default_code, barcode) " +
                        @" VALUES (@product_tmpl_id, @default_code, @barcode)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_product_tmpl_id = cm.Parameters.Add("product_tmpl_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_product_tmpl_id.Value = this.IdProductTmpl;
                Npgsql.NpgsqlParameter pr_default_code = cm.Parameters.Add("default_code", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_default_code.Value = this.DefaultCode;
                Npgsql.NpgsqlParameter pr_barcode = cm.Parameters.Add("barcode", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_barcode.Value = this.Barcode;
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
                    CommandText = string.Format(@"UPDATE {0} SET product_tmpl_id = @product_tmpl_id, default_code = @default_code, barcode = @barcode " +
                        @" WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_product_tmpl_id = cm.Parameters.Add("product_tmpl_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_product_tmpl_id.Value = this.IdProductTmpl;
                Npgsql.NpgsqlParameter pr_default_code = cm.Parameters.Add("default_code", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_default_code.Value = this.DefaultCode;
                Npgsql.NpgsqlParameter pr_barcode = cm.Parameters.Add("barcode", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_barcode.Value = this.Barcode;
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
            this.ProductTmpl = Tables.ProductTemplate.GetProductTemplateOrDefault(this.IdProductTmpl, Srv, Base).Name;
        }
        private void ConvertNameToId()
        {
            this.IdProductTmpl = Tables.ProductTemplate.GetProductTemplateOrDefault(this.ProductTmpl, Srv, Base).Id;
        }

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список Product
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<Product> GetList(Servers Srv, string BaseName)
        {
            List<Product> li = new List<Product>();
            List<int> li_id = Product.GetId(Srv, BaseName, Actions.SyncProduct);
            Dictionary<string, Product> di = new Dictionary<string, Product>();
            List<Product> li_l = new List<Product>();
            foreach (int item in li_id)
            {
                Product bn1 = new Product(item, Srv, BaseName, "");
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
        /// Получить информацию о Product или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Product GetProductOrDefault(int id, Servers Srv, string BaseName)
        {
            Product com = new Product(id, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultProduct(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о Product  или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Name">Name</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Product GetProductOrDefault(string Name, Servers Srv, string BaseName)
        {
            Product com = new Product(Name, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultProduct(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о default Product. Если нет - создать
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Product GetDefaultProduct(Servers Srv, string BaseName)
        {
            Product prd = new Product();
            prd.IdProductTmpl = Tables.ProductTemplate.GetDefaultProductTemplate(Srv, BaseName).Id;
            return prd;
        }
        #endregion
    }
}
