using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Валюта
    /// </summary>
    [NumClass(42)]
    [Serializable]
    public class Currency : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Currency() : base(Actions.SyncCurrency) { }
        public Currency(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncCurrency) { }
        public Currency(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncCurrency) { }

        #endregion

        #region  ==========  Property  ==========

        public string Zeme { set; get; }
        public int Mnozstvi { set; get; }

        private List<Currency> _CollectionCurrency = new List<Currency>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Currency> CollectionCurrency { get { return _CollectionCurrency; } set { _CollectionCurrency = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; }

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Name)
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
                    CommandText = string.Format(@"SELECT ID, Pouzit, Kod, IDS, Zeme, Mnozstvi FROM {0} ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT ID, Pouzit, Kod, IDS, Zeme, Mnozstvi FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT ID, Pouzit, Kod, IDS, Zeme, Mnozstvi FROM {0} where Kod = @Kod", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                    pr_Kod.Value = Name;
                }
                else { IsSelect = false; }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Currency cr = new Currency();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = (int)dr["ID"];
                    cr.Name = dr["Kod"] == DBNull.Value ? "" : dr["Kod"].ToString().Trim();
                    cr.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    cr.Ids = cr.Ids.Length > 3 ? cr.Ids.Substring(0, 3) : cr.Ids;
                    cr.Zeme = dr["Zeme"] == DBNull.Value ? "" : dr["Zeme"].ToString().Trim();
                    cr.Mnozstvi = dr["Mnozstvi"] == DBNull.Value ? 0 : (int)dr["Mnozstvi"];
                    cr.Active = (bool)dr["Pouzit"];
                    this.CollectionCurrency.Add(cr);
                    cr.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionCurrency.Count != 0)
                {
                    this.Id = this.CollectionCurrency[0].Id;
                    this.Name = this.CollectionCurrency[0].Name;
                    this.Ids = this.CollectionCurrency[0].Ids;
                    this.Zeme = this.CollectionCurrency[0].Zeme;
                    this.Mnozstvi = this.CollectionCurrency[0].Mnozstvi;
                    this.Active = this.CollectionCurrency[0].Active;
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
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (Pouzit, Kod, IDS, Zeme, Mnozstvi, Ucetni, Creator, Pozn) " +
                    @" VALUES (@Pouzit, @Kod, @IDS, @Zeme, @Mnozstvi, @Ucetni, @Creator, @Pozn)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Zeme = cm.Parameters.Add("Zeme", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Mnozstvi = cm.Parameters.Add("Mnozstvi", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_Creator = cm.Parameters.Add("Creator", System.Data.SqlDbType.VarChar);
                pr_Creator.Value = SqlScripts.NameUserCreator;
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                pr_Pozn.Value = SqlScripts.SynchPozn;
                System.Data.SqlClient.SqlParameter pr_Active = cm.Parameters.Add("Pouzit", System.Data.SqlDbType.Bit);
                this.Id = 0;

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCurrency)
                    {
                        pr_Kod.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_IDS.Value = DBNull.Value;
                        else pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Zeme)) pr_Zeme.Value = DBNull.Value;
                        else pr_Zeme.Value = item.Zeme;
                        pr_Mnozstvi.Value = item.Mnozstvi;
                        pr_Active.Value = item.Active;
                        item.Id = (int)cm.ExecuteScalar();
                    }
                }
                else
                {
                    pr_Kod.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_IDS.Value = DBNull.Value;
                    else pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Zeme)) pr_Zeme.Value = DBNull.Value;
                    else pr_Zeme.Value = this.Zeme;
                    pr_Mnozstvi.Value = this.Mnozstvi;
                    pr_Active.Value = this.Active;
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
                    CommandText = string.Format(@"UPDATE {0} SET Pouzit = @Pouzit, IDS = @IDS, Zeme = @Zeme, Mnozstvi = @Mnozstvi, Ucetni = @Ucetni WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Zeme = cm.Parameters.Add("Zeme", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Mnozstvi = cm.Parameters.Add("Mnozstvi", System.Data.SqlDbType.Int);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_Active = cm.Parameters.Add("Pouzit", System.Data.SqlDbType.Bit);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCurrency)
                    {
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_IDS.Value = DBNull.Value;
                        else pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Zeme)) pr_Zeme.Value = DBNull.Value;
                        else pr_Zeme.Value = item.Zeme;
                        pr_Mnozstvi.Value = item.Mnozstvi;
                        pr_Active.Value = item.Active;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_IDS.Value = DBNull.Value;
                    else pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Zeme)) pr_Zeme.Value = DBNull.Value;
                    else pr_Zeme.Value = this.Zeme;
                    pr_Mnozstvi.Value = this.Mnozstvi;
                    pr_Active.Value = this.Active;
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
            bool IsSelect = true;
            try
            {
                List<string> li_pole = new List<string>
                {
                        "id",
                        "name",
                        "symbol",
                        "active",
                        "x_mnozstvi",
                        "x_zeme"
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
                else { IsSelect = false; }
                odoFiltr.Filter("active", "!=", null);
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                foreach (var item in Datas)
                {
                    Currency cr = new Currency();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = int.Parse(item["id"]);
                    cr.Name = item["name"] == "False" ? "" : item["name"];
                    cr.Ids = item["symbol"] == "False" ? "" : item["symbol"];
                    cr.Ids = cr.Ids.Length > 3 ? cr.Ids.Substring(0, 3) : cr.Ids;
                    cr.Mnozstvi = item["x_mnozstvi"] == "False" ? 0 : int.Parse(item["x_mnozstvi"]);
                    cr.Zeme = item["x_zeme"] == "False" ? "" : item["x_zeme"];
                    cr.Active = bool.Parse(item["active"]);
                    cr.IsRecord = NumberRecord.Many;
                    this.CollectionCurrency.Add(cr);
                    cr.IsRecord = NumberRecord.Many;
                }
                if (IsSelect && this.CollectionCurrency.Count != 0)
                {
                    this.Id = this.CollectionCurrency[0].Id;
                    this.Name = this.CollectionCurrency[0].Name;
                    this.Ids = this.CollectionCurrency[0].Ids;
                    this.Mnozstvi = this.CollectionCurrency[0].Mnozstvi;
                    this.Zeme = this.CollectionCurrency[0].Zeme;
                    this.Active = this.CollectionCurrency[0].Active;
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
                    foreach (var item in this.CollectionCurrency)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "symbol", item.Ids },
                            { "active", item.Active },
                            { "x_mnozstvi", item.Mnozstvi },
                            { "x_zeme", item.Zeme }
                        };
                        this.Id = (int)odScr.InsertRow(Srv, item.PrAction.TableOdoo, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "symbol", this.Ids },
                            { "active", this.Active },
                            { "x_mnozstvi", this.Mnozstvi },
                            { "x_zeme", this.Zeme }
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
                    foreach (var item in this.CollectionCurrency)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "symbol", item.Ids },
                            { "active", item.Active },
                            { "x_mnozstvi", item.Mnozstvi },
                            { "x_zeme", item.Zeme }
                        };
                        odScr.UpdateRow(Srv, item.PrAction.TableOdoo, item.Id, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "symbol", this.Ids },
                            { "active", this.Active },
                            { "x_mnozstvi", this.Mnozstvi },
                            { "x_zeme", this.Zeme }
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
        protected override void LoadPostgre(int Id, string Name)
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
                    CommandText = string.Format(@"SELECT id, name, symbol, active, x_mnozstvi, x_zeme FROM {0} ", this.PrAction.TablePostgreSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT id, name, symbol, active, x_mnozstvi, x_zeme FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT id, name, symbol, active, x_mnozstvi, x_zeme FROM {0} where name = @name", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_name.Value = Name;
                }
                else { IsSelect = false; }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Currency cr = new Currency();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = (int)dr["id"];
                    cr.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    cr.Ids = dr["symbol"] == DBNull.Value ? "" : dr["symbol"].ToString().Trim();
                    cr.Ids = cr.Ids.Length > 3 ? cr.Ids.Substring(0, 3) : cr.Ids;
                    cr.Zeme = dr["x_zeme"] == DBNull.Value ? "" : dr["x_zeme"].ToString().Trim();
                    cr.Mnozstvi = dr["x_mnozstvi"] == DBNull.Value ? 0 : (int)dr["x_mnozstvi"];
                    cr.Active = (bool)dr["active"];
                    this.CollectionCurrency.Add(cr);
                    cr.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionCurrency.Count != 0)
                {
                    this.Id = this.CollectionCurrency[0].Id;
                    this.Name = this.CollectionCurrency[0].Name;
                    this.Ids = this.CollectionCurrency[0].Ids;
                    this.Zeme = this.CollectionCurrency[0].Zeme;
                    this.Mnozstvi = this.CollectionCurrency[0].Mnozstvi;
                    this.Active = this.CollectionCurrency[0].Active;
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
                    CommandText = string.Format(@"INSERT INTO {0} (name, symbol, active, x_zeme, x_mnozstvi) VALUES (@name, @symbol, @active, @x_zeme, @x_mnozstvi)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_symbol = cm.Parameters.Add("symbol", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_zeme = cm.Parameters.Add("x_zeme", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_mnozstvi = cm.Parameters.Add("x_mnozstvi", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCurrency)
                    {
                        pr_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_symbol.Value = DBNull.Value;
                        else pr_symbol.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Zeme)) pr_x_zeme.Value = DBNull.Value;
                        else pr_x_zeme.Value = item.Zeme;
                        pr_x_mnozstvi.Value = item.Mnozstvi;
                        pr_active.Value = item.Active;
                        item.Id = (int)((long)cm.ExecuteScalar());
                    }
                }
                else
                {
                    pr_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_symbol.Value = DBNull.Value;
                    else pr_symbol.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Zeme)) pr_x_zeme.Value = DBNull.Value;
                    else pr_x_zeme.Value = this.Zeme;
                    pr_x_mnozstvi.Value = this.Mnozstvi;
                    pr_active.Value = this.Active;
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
                    CommandText = string.Format(@"UPDATE {0} SET symbol = @symbol, active = @active, x_zeme = @x_zeme, x_mnozstvi = @x_mnozstvi WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_symbol = cm.Parameters.Add("symbol", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                Npgsql.NpgsqlParameter pr_x_zeme = cm.Parameters.Add("x_zeme", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_mnozstvi = cm.Parameters.Add("x_mnozstvi", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCurrency)
                    {
                        if (string.IsNullOrWhiteSpace(item.Ids)) pr_symbol.Value = DBNull.Value;
                        else pr_symbol.Value = item.Ids;
                        pr_active.Value = item.Active;
                        if (string.IsNullOrWhiteSpace(item.Zeme)) pr_x_zeme.Value = DBNull.Value;
                        else pr_x_zeme.Value = item.Zeme;
                        pr_x_mnozstvi.Value = item.Mnozstvi;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.Ids)) pr_symbol.Value = DBNull.Value;
                    else pr_symbol.Value = this.Ids;
                    pr_active.Value = this.Active;
                    if (string.IsNullOrWhiteSpace(this.Zeme)) pr_x_zeme.Value = DBNull.Value;
                    else pr_x_zeme.Value = this.Zeme;
                    pr_x_mnozstvi.Value = this.Mnozstvi;
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
        public static Currency GetCurrency(Servers Srv, string NameBase, int Id)
        {
            Currency cou = new Currency(Id, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Получить валюту по Коду (Name)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">Код страны (например: UA)</param>
        /// <returns></returns>
        public static Currency GetCurrency(Servers Srv, string NameBase, string Ids)
        {
            Currency cou = new Currency(Ids, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Список или одна валюта
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о стране</param>
        /// <returns></returns>
        public static List<Currency> GetList(Servers Srv, string BaseName)
        {
            List<Currency> li = new List<Currency>();
            Currency bn1 = new Currency(0, Srv, BaseName, "");
            foreach (var item in bn1.CollectionCurrency)
            {
                if (item.Id != 0) li.Add(item);
            }
            return li;
        }

        /// <summary>
        /// Получить информацию о Валюта или если нет то информацию о default (EUR) Валюта . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Currency GetCurrencyOrDefault(int id, Servers Srv, string BaseName)
        {
            Currency com = new Currency(id, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultCurrency(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о Валюта  или если нет то информацию о default (EUR) Валюта . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Currency GetCurrencyOrDefault(string Ids, Servers Srv, string BaseName)
        {
            Currency com = new Currency(Ids, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultCurrency(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о default (EUR) Валюта. Если нет - создать
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Currency GetDefaultCurrency(Servers Srv, string BaseName)
        {
            CurrencyDefault dcom = new CurrencyDefault();
            Currency com = new Currency(dcom.Name, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com.Name = dcom.Name;
                com.Ids = dcom.Ids;
                com.Active = true;
                com.Create();
                com = new Currency(com.Id, Srv, BaseName, "");
            }
            return com;
        }


        #endregion
    }
    public class CurrencyDefault
    {
        public string Name { private set; get; } = "EUR";
        public string Ids { private set; get; } = "€";
    }
}
