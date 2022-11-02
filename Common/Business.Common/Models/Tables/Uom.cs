using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Unit of Measure. Единица измерения
    /// </summary>
    [NumClass(54)]
    [Serializable]
    public class Uom : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Uom() : base(Actions.SyncUom) { }
        public Uom(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncUom) { }
        public Uom(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncUom) { }

        #endregion

        #region  ==========  Property  ==========

        public int IdCategory { set; get; }
        public string Category { set; get; }
        public double Factor { set; get; }
        /// <summary>
        /// MJKoef - Rounding.  RoundingPohoda = 1 / RoundingOdoo
        /// </summary>
        public float RoundingPohoda { set; get; }
        /// <summary>
        /// MJKoef - Rounding.  RoundingOdoo = 1 / RoundingPohoda
        /// </summary>
        public float RoundingOdoo { set; get; }
        public string UomType { set; get; }
        public string MeasureType { set; get; }

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ids)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
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
                    System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                    pr_IDS.Value = Ids;
                }
                else { throw new Exception("Input values 'Uom' are NULL"); }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["ID"];
                    this.Name = dr["SText"] == DBNull.Value ? "" : dr["SText"].ToString().Trim();
                    this.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    this.RoundingPohoda = dr["MJKoef"] == DBNull.Value ? 1 : (float)((double)dr["MJKoef"]);
                    if (this.RoundingPohoda == 0)
                    {
                        this.RoundingPohoda = this.RoundingOdoo = 1;
                    }
                    else this.RoundingOdoo = 1 / this.RoundingPohoda;
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
        [NumFunction(2)]
        protected override void CreateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (IDS, SText, MJKoef) VALUES (@IDS, @SText, @MJKoef)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                pr_IDS.Value = this.Ids;
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                pr_SText.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_MJKoef = cm.Parameters.Add("MJKoef", System.Data.SqlDbType.Float);
                pr_MJKoef.Value = this.RoundingPohoda;
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
                    CommandText = string.Format(@"UPDATE {0} SET SText = @SText, MJKoef = @MJKoef WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                pr_SText.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_MJKoef = cm.Parameters.Add("MJKoef", System.Data.SqlDbType.Float);
                pr_MJKoef.Value = this.RoundingPohoda;
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
            try
            {
                List<string> li_pole = new List<string> {
                    "id",
                    "name",
                    "category_id",
                    "factor",
                    "rounding",
                    "uom_type",
                    "measure_type"
                };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    odoFiltr.Filter("name", "=", Ids);
                }
                else { throw new Exception("Input values 'Uom' are NULL"); }
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    this.Id = int.Parse(Datas[0]["id"]);
                    this.Ids = Datas[0]["name"] == "False" ? "" : Datas[0]["name"];
                    this.IdCategory = Datas[0]["category_id"] == "False" ? 0 : int.Parse(Datas[0]["category_id"]);
                    this.Factor = Datas[0]["factor"] == "False" ? 1 : double.Parse(Datas[0]["factor"]);
                    this.RoundingOdoo = Datas[0]["rounding"] == "False" ? 1 : float.Parse(Datas[0]["rounding"]);
                    this.UomType = Datas[0]["uom_type"] == "False" ? "" : Datas[0]["uom_type"];
                    this.MeasureType = Datas[0]["measure_type"] == "False" ? "" : Datas[0]["measure_type"];
                    if (this.RoundingOdoo == 0)
                    {
                        this.RoundingOdoo = this.RoundingPohoda = 1;
                    }
                    else this.RoundingPohoda = 1 / this.RoundingOdoo;
                    this.Category = UomCategory.GetUomCategoryOrDefault(this.IdCategory, Srv, this.Base).Ids;
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
                if (this.IdCategory == 0)
                {
                    if (!string.IsNullOrWhiteSpace(this.Category))
                    {
                        this.IdCategory = Tables.UomCategory.GetUomCategoryOrDefault(this.Category, this.Srv, this.Base).Id;
                    }
                }
                OdooScripts odScr = new OdooScripts();
                Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Ids },
                            { "category_id", this.IdCategory },
                            { "factor", this.Factor },
                            { "rounding", this.RoundingOdoo },
                            { "uom_type", this.UomType },
                            { "measure_type", this.MeasureType }
                        };
                this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
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
                            { "name", this.Ids },
                            { "category_id", this.IdCategory },
                            { "factor", this.Factor },
                            { "rounding", this.RoundingOdoo },
                            { "uom_type", this.UomType },
                            { "measure_type", this.MeasureType }
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
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                if (Id != 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where code = @code", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_code = cm.Parameters.Add("code", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_code.Value = Ids;
                }
                else { throw new Exception("Input values 'Uom' are NULL"); }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["id"];
                    this.Ids = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    this.IdCategory = dr["category_id"] == DBNull.Value ? 0 : (int)dr["category_id"];
                    this.Factor = dr["factor"] == DBNull.Value ? 1 : (double)dr["factor"];
                    this.RoundingOdoo = dr["rounding"] == DBNull.Value ? 1 : (float)dr["rounding"];
                    this.UomType = dr["uom_type"] == DBNull.Value ? "" : dr["uom_type"].ToString().Trim();
                    this.MeasureType = dr["measure_type"] == DBNull.Value ? "" : dr["measure_type"].ToString().Trim();
                    if (this.RoundingOdoo == 0)
                    {
                        this.RoundingOdoo = this.RoundingPohoda = 1;
                    }
                    else this.RoundingPohoda = 1 / this.RoundingOdoo;
                    this.Category = UomCategory.GetUomCategoryOrDefault(this.IdCategory, Srv, this.Base).Ids;
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
                if (this.IdCategory == 0)
                {
                    if (!string.IsNullOrWhiteSpace(this.Category))
                    {
                        this.IdCategory = Tables.UomCategory.GetUomCategoryOrDefault(this.Category, this.Srv, this.Base).Id;
                    }
                }
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (name, category_id, factor, rounding, uom_type, measure_type) " +
                        @" VALUES (@name, @category_id, @factor, @rounding, @uom_type, @measure_type)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_category_id = cm.Parameters.Add("category_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_category_id.Value = this.IdCategory;
                Npgsql.NpgsqlParameter pr_factor = cm.Parameters.Add("factor", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_factor.Value = this.Factor;
                Npgsql.NpgsqlParameter pr_rounding = cm.Parameters.Add("rounding", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_rounding.Value = this.RoundingOdoo;
                Npgsql.NpgsqlParameter pr_uom_type = cm.Parameters.Add("uom_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_uom_type.Value = this.UomType;
                Npgsql.NpgsqlParameter pr_measure_type = cm.Parameters.Add("measure_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_measure_type.Value = this.MeasureType;
                this.Id = (int)((long)cm.ExecuteScalar());
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
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, category_id = @category_id, factor = @factor, rounding = @rounding, uom_type = @uom_type, measure_type = @measure_type " +
                        @" WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_category_id = cm.Parameters.Add("category_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_category_id.Value = this.IdCategory;
                Npgsql.NpgsqlParameter pr_factor = cm.Parameters.Add("factor", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_factor.Value = this.Factor;
                Npgsql.NpgsqlParameter pr_rounding = cm.Parameters.Add("rounding", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_rounding.Value = this.RoundingOdoo;
                Npgsql.NpgsqlParameter pr_uom_type = cm.Parameters.Add("uom_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_uom_type.Value = this.UomType;
                Npgsql.NpgsqlParameter pr_measure_type = cm.Parameters.Add("measure_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_measure_type.Value = this.MeasureType;
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
        /// Получить Единица измерения по ID
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public static Uom GetUomIdOrName(Servers Srv, string NameBase, int Id)
        {
            Uom cou = new Uom(Id, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Получить Единица измерения по Коду (ids)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">Код - Единица измерения</param>
        /// <returns></returns>
        public static Uom GetUomIdOrName(Servers Srv, string NameBase, string Ids)
        {
            Uom cou = new Uom(Ids, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Список или одна Единица измерения
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о Единица измерения</param>
        /// <returns></returns>
        public static List<Uom> GetList(Servers Srv, string BaseName, int Id = 0)
        {
            List<Uom> li = new List<Uom>();
            if (Id == 0)
            {
                List<int> li_id = Uom.GetId(Srv, BaseName, Actions.SyncUom);
                Dictionary<string, Uom> di = new Dictionary<string, Uom>();
                List<Uom> li_l = new List<Uom>();
                foreach (int item in li_id)
                {
                    Uom bn1 = new Uom(item, Srv, BaseName, "");
                    if (bn1.Id != 0)
                    {
                        if (bn1.Ids.Length > 2)
                        {
                            li_l.Add(bn1);
                        }
                        else if (!di.ContainsKey(bn1.Ids)) di.Add(bn1.Ids, bn1);
                    }
                }
                foreach (var item in li_l)
                {
                    item.Ids = item.Ids.Substring(0, 2);
                    if (!di.ContainsKey(item.Ids)) di.Add(item.Ids, item);
                }
                foreach (var item in di)
                {
                    li.Add(item.Value);
                }
                di.Clear();
            }
            else
            {
                Uom bn1 = new Uom(Id, Srv, BaseName, "");
                if (bn1.Id != 0) li.Add(bn1);
            }
            return li;
        }

        /// <summary>
        /// Получить информацию о Единица измерения  или если нет то информацию о default (Syncho) Единица измерения . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Uom GetUomOrDefault(int id, Servers Srv, string BaseName)
        {
            Uom com = new Uom(id, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultUom(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о Единица измерения  или если нет то информацию о default (Syncho) Единица измерения . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Uom GetUomOrDefault(string Ids, Servers Srv, string BaseName)
        {
            if (string.IsNullOrWhiteSpace(Ids))
            {
                return GetDefaultUom(Srv, BaseName);
            }
            Uom com = new Uom(Ids, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultUom(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о default (Syncho) Единица измерения. Если нет - создать
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Uom GetDefaultUom(Servers Srv, string BaseName)
        {
            UomDefault dcom = new UomDefault();
            Uom com = new Uom(dcom.MeasureType, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com.Name = dcom.Name;
                com.Ids = dcom.MeasureType;
                com.Factor = dcom.Factor;
                com.RoundingOdoo = dcom.Rounding;
                com.RoundingPohoda = 1 / dcom.Rounding;
                com.UomType = dcom.UomType;
                switch (Srv.Type)
                {
                    case TypeServers.MsSql:
                    case TypeServers.PohodaXml:
                        com.IdCategory = 0;
                        com.Category = "";
                        break;
                    case TypeServers.Odoo:
                    case TypeServers.PostgreSQL:
                        UomCategory uc = UomCategory.GetUomCategoryOrDefault(dcom.Category.MeasureType, Srv, BaseName);
                        com.IdCategory = uc.Id;
                        com.Category = uc.Ids;
                        break;
                    default:
                        break;
                }
                com.Create();
                com = new Uom(com.Id, Srv, BaseName, "");
            }
            return com;
        }

        #endregion
    }
    public class UomDefault
    {
        public string Name { private set; get; } = "Unit(s)";
        public float Factor { private set; get; } = 1;
        public float Rounding { private set; get; } = 0.001F;
        public string UomType { private set; get; } = "reference";
        public string MeasureType { private set; get; } = "unit";
        public UomCategoryDefault Category { private set; get; } = new UomCategoryDefault();
    }
}
