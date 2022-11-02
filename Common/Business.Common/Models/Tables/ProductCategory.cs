using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Продукт - категория
    /// </summary>
    [NumClass(60)]
    [Serializable]
    public class ProductCategory : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public ProductCategory() : base(Actions.SyncProductCategory) { }
        public ProductCategory(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncProductCategory) { }
        public ProductCategory(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncProductCategory) { }

        #endregion

        #region  ==========  Property  ==========

        public string ParentPath { set; get; }
        public int ParentId { set; get; }
        public string CompleteName { set; get; }
        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Name)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                    this.Id = 0;
                throw new Exception("function not implemented 'ProductCategory - LoadSql'");
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
                throw new Exception("function not implemented 'ProductCategory - CreateSql'");
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
                throw new Exception("function not implemented 'ProductCategory - UpdateSql'");
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
                throw new Exception("function not implemented 'ProductCategory - DeleteSql'");
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
                        "parent_path",
                        "parent_id",
                        "complete_name"
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
                else { throw new Exception("Input values 'ProductCategory' are NULL"); }
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    this.Id = int.Parse(Datas[0]["id"]);
                    this.Name = Datas[0]["name"] == "False" ? "" : Datas[0]["name"].Trim();
                    this.ParentPath = Datas[0]["parent_path"] == "False" ? "" : Datas[0]["parent_path"].Trim();
                    this.ParentId = Datas[0]["parent_id"] == "False" ? 0 : int.Parse(Datas[0]["parent_id"]);
                    this.CompleteName = Datas[0]["complete_name"] == "False" ? "" : Datas[0]["complete_name"].Trim();
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
                OdooScripts odScr = new OdooScripts();
                Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "parent_path", this.ParentPath },
                            { "parent_id", this.ParentId },
                            { "complete_name", this.CompleteName }
                        };
                this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
                this.ParentPath = string.Format(@"1/{0}/", this.Id);
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
                Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "name", this.Name },
                            { "parent_path", this.ParentPath },
                            { "parent_id", this.ParentId },
                            { "complete_name", this.CompleteName }
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
                    cm.CommandText = string.Format(@"SELECT* FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where name = @name", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_name.Value = Name;
                }
                else { throw new Exception("Input values 'ProductCategory' are NULL"); }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["id"];
                    this.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    this.ParentPath = dr["parent_path"] == DBNull.Value ? "" : dr["parent_path"].ToString().Trim();
                    this.ParentId = dr["parent_id"] == DBNull.Value ? 0 :( int) dr["parent_id"];
                    this.CompleteName = dr["complete_name"] == DBNull.Value ? "" : dr["complete_name"].ToString().Trim();
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
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (name, parent_path, parent_id, complete_name) VALUES (@name, @parent_path, @parent_id, @complete_name)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_parent_path = cm.Parameters.Add("parent_path", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_parent_path.Value = this.ParentPath;
                Npgsql.NpgsqlParameter pr_parent_id = cm.Parameters.Add("parent_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_parent_id.Value = this.ParentId;
                Npgsql.NpgsqlParameter pr_complete_name = cm.Parameters.Add("complete_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_complete_name.Value = this.CompleteName;
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
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, parent_path = @parent_path, parent_id = @parent_id, complete_name = @complete_name " +
                        @" WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_parent_path = cm.Parameters.Add("parent_path", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_parent_path.Value = this.ParentPath;
                Npgsql.NpgsqlParameter pr_parent_id = cm.Parameters.Add("parent_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_parent_id.Value = this.ParentId;
                Npgsql.NpgsqlParameter pr_complete_name = cm.Parameters.Add("complete_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_complete_name.Value = this.CompleteName;
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

        #region  ==========  Static  ==========

        /// <summary>
        /// Список ProductCategory
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<ProductCategory> GetList(Servers Srv, string BaseName)
        {
            List<ProductCategory> li = new List<ProductCategory>();
            List<int> li_id = ProductCategory.GetId(Srv, BaseName, Actions.SyncProductCategory);
            Dictionary<string, ProductCategory> di = new Dictionary<string, ProductCategory>();
            List<ProductCategory> li_l = new List<ProductCategory>();
            foreach (int item in li_id)
            {
                ProductCategory bn1 = new ProductCategory(item, Srv, BaseName, "");
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
        /// Получить информацию о ProductCategory или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ProductCategory GetProductCategoryOrDefault(int id, Servers Srv, string BaseName)
        {
            ProductCategory com = new ProductCategory(id, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultProductCategory(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о ProductCategory  или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ProductCategory GetProductCategoryOrDefault(string Name, Servers Srv, string BaseName)
        {
            ProductCategory com = new ProductCategory(Name, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultProductCategory(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о default ProductCategory. Если нет - создать
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ProductCategory GetDefaultProductCategory(Servers Srv, string BaseName)
        {
            ProductCategoryDefault dcom = new ProductCategoryDefault();
            ProductCategory com = new ProductCategory(dcom.Name, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com.Name = dcom.Name;
                com.ParentId = dcom.ParentId;
                com.ParentPath = "";
                com.CompleteName = string.Format(@"All/{0}", com.Name);
                com.Create();
                com = new ProductCategory(com.Id, Srv, BaseName, "");
            }
            return com;
        }


        #endregion
    }
    public class ProductCategoryDefault
    {
        public string Name { private set; get; } = "All";
        public int ParentId { private set; get; } = 1;
    }

}
