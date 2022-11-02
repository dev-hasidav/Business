using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Страны
    /// </summary>
    [NumClass(36)]
    [Serializable]
    public class Country : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Country() : base(Actions.SyncCountry) { }
        public Country(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncCountry) { }
        public Country(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncCountry) { }

        #endregion

        #region  ==========  Property  ==========

        public string Kod { set; get; }
        public int IdCurrency { set; get; } = 0;
        public int RelZeme { set; get; }
        private List<Country> _CollectionCountry = new List<Country>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Country> CollectionCountry { get { return _CollectionCountry; } set { _CollectionCountry = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; }

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ids)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            bool IsSelect = true;
            try
            {
                this.Id = 0;
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT ID, SText, Kod, IDS, RelZeme FROM {0} ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT ID, SText, Kod, IDS, RelZeme FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT ID, SText, Kod, IDS, RelZeme FROM {0} where IDS = @IDS", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                    pr_IDS.Value = Ids;
                }
                else { IsSelect = false; }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Country cnt = new Country();
                    cnt.Srv = this.Srv;
                    cnt.Base = this.Base;
                    cnt.Id = (int)dr["ID"];
                    cnt.Kod = dr["Kod"] == DBNull.Value ? "" : dr["Kod"].ToString().Trim();
                    cnt.Name = dr["SText"] == DBNull.Value ? "" : dr["SText"].ToString().Trim();
                    cnt.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    cnt.RelZeme = dr["RelZeme"] == DBNull.Value ? 0 : (int)dr["RelZeme"];
                    this.CollectionCountry.Add(cnt);
                    this.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionCountry.Count != 0)
                {
                    this.Id = this.CollectionCountry[0].Id;
                    this.Kod = this.CollectionCountry[0].Kod;
                    this.Name = this.CollectionCountry[0].Name;
                    this.Ids = this.CollectionCountry[0].Ids;
                    this.RelZeme = this.CollectionCountry[0].RelZeme;
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
                    CommandText = string.Format(@"INSERT INTO {0} (IDS, SText, Kod, Ucetni, Creator, Pozn, RelZeme) VALUES (@IDS, @SText, @Kod, @Ucetni, @Creator, @Pozn, @RelZeme)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Creator = cm.Parameters.Add("Creator", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_RelZeme = cm.Parameters.Add("RelZeme", System.Data.SqlDbType.VarChar);
                    pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                    pr_Creator.Value = SqlScripts.NameUserCreator;
                    pr_Pozn.Value = SqlScripts.SynchPozn;
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCountry)
                    {
                        pr_IDS.Value = item.Ids;
                        pr_SText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Kod)) pr_Kod.Value = DBNull.Value;
                        else pr_Kod.Value = item.Kod;
                        if (item.RelZeme == 0) pr_RelZeme.Value = DBNull.Value;
                        else pr_RelZeme.Value = item.RelZeme;
                        item.Id = (int)cm.ExecuteScalar();
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    pr_SText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Kod)) pr_Kod.Value = DBNull.Value;
                    else pr_Kod.Value = this.Kod;
                    if (this.RelZeme == 0) pr_RelZeme.Value = DBNull.Value;
                    else pr_RelZeme.Value = this.RelZeme;
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
                    CommandText = string.Format(@"UPDATE {0} SET SText = @SText, Kod = @Kod, Ucetni = @Ucetni, RelZeme = @RelZeme WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Kod = cm.Parameters.Add("Kod", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_RelZeme = cm.Parameters.Add("RelZeme", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many) 
                {
                    foreach (var item in this.CollectionCountry)
                    {
                        pr_SText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Kod)) pr_Kod.Value = DBNull.Value;
                        else pr_Kod.Value = item.Kod;
                        if (item.RelZeme == 0) pr_RelZeme.Value = DBNull.Value;
                        else pr_RelZeme.Value = item.RelZeme;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_SText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Kod)) pr_Kod.Value = DBNull.Value;
                    else pr_Kod.Value = this.Kod;
                    if (this.RelZeme == 0) pr_RelZeme.Value = DBNull.Value;
                    else pr_RelZeme.Value = this.RelZeme;
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
            bool IsSelect = true;
            try
            {
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
                this.Id = 0;
                List<string> li_pole = new List<string> { "id", "name", "code", "x_kod", "x_relzeme", "currency_id" };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    odoFiltr.Filter("code", "=", Ids);
                }
                else { IsSelect = false; }
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                foreach (var item in Datas)
                {
                    Country cnt = new Country();
                    cnt.Srv = this.Srv;
                    cnt.Base = this.Base;
                    cnt.Id = int.Parse(item["id"]);
                    cnt.Name = item["name"] == "False" ? "" : item["name"];
                    cnt.Ids = item["code"] == "False" ? "" : item["code"];
                    cnt.Kod = item["x_kod"] == "False" ? "" : item["x_kod"];
                    cnt.RelZeme = item["x_relzeme"] == "False" ? 0 : int.Parse(item["x_relzeme"]);
                    cnt.IdCurrency = 0;
                    string s1 = item["currency_id"] == "False" ? "0" : item["currency_id"];
                    System.Text.RegularExpressions.Match mt = rg.Match(s1);
                    if (mt.Success)
                    {
                        cnt.IdCurrency = int.Parse(mt.Value);
                    }
                    this.CollectionCountry.Add(cnt);
                    this.IsRecord = NumberRecord.Many;
                }
                if (IsSelect && this.CollectionCountry.Count != 0)
                {
                    this.Id = this.CollectionCountry[0].Id;
                    this.Name = this.CollectionCountry[0].Name;
                    this.Ids = this.CollectionCountry[0].Ids;
                    this.Kod = this.CollectionCountry[0].Kod;
                    this.RelZeme = this.CollectionCountry[0].RelZeme;
                    this.IdCurrency = this.CollectionCountry[0].IdCurrency;
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
                    foreach (var item in this.CollectionCountry)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "code", item.Ids },
                            { "x_kod", item.Kod },
                            { "x_relzeme", item.RelZeme }
                        };
                        this.Id = (int)odScr.InsertRow(Srv, item.PrAction.TableOdoo, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "code", this.Ids },
                            { "x_kod", this.Kod },
                            { "x_relzeme", this.RelZeme }
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
                    foreach (var item in this.CollectionCountry)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "code", item.Ids },
                            { "x_kod", item.Kod },
                            { "x_relzeme", item.RelZeme }
                        };
                        odScr.UpdateRow(Srv, item.PrAction.TableOdoo, item.Id, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                    {
                        { "name", this.Name },
                        { "code", this.Ids },
                        { "x_kod", this.Kod },
                        { "x_relzeme", this.RelZeme }
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
            bool IsSelect = true;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT id, name, code, x_kod, x_relzeme, currency_id FROM {0} ", this.PrAction.TablePostgreSql)
                };
                if (Id != 0)
                {
                    cm.CommandText = string.Format(@"SELECT id, name, code, x_kod, x_relzeme, currency_id FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT id, name, code, x_kod, x_relzeme, currency_id FROM {0} where code = @code", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_code = cm.Parameters.Add("code", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_code.Value = Ids;
                }
                else { IsSelect = false; }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Country cnt = new Country();
                    cnt.Srv = this.Srv;
                    cnt.Base = this.Base;
                    cnt.Id = (int)dr["id"];
                    cnt.Kod = dr["x_kod"] == DBNull.Value ? "" : dr["x_kod"].ToString().Trim();
                    cnt.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    cnt.Ids = dr["code"] == DBNull.Value ? "" : dr["code"].ToString().Trim();
                    cnt.RelZeme = dr["x_relzeme"] == DBNull.Value ? 0 : (int)dr["x_relzeme"];
                    cnt.IdCurrency = dr["currency_id"] == DBNull.Value ? 0 : (int)dr["currency_id"];
                    this.CollectionCountry.Add(cnt);
                    this.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionCountry.Count != 0)
                {
                    this.Id = this.CollectionCountry[0].Id;
                    this.Kod = this.CollectionCountry[0].Kod;
                    this.Name = this.CollectionCountry[0].Name;
                    this.Ids = this.CollectionCountry[0].Ids;
                    this.RelZeme = this.CollectionCountry[0].RelZeme;
                    this.IdCurrency = this.CollectionCountry[0].IdCurrency;
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
                    CommandText = string.Format(@"INSERT INTO {0} (name, code, x_kod, x_relzeme) VALUES (@name, @code, @x_kod, @x_relzeme)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Kod = cm.Parameters.Add("code", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_kod = cm.Parameters.Add("x_kod", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_relzeme = cm.Parameters.Add("x_relzeme", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCountry)
                    {
                        pr_x_relzeme.Value = item.RelZeme;
                        pr_x_kod.Value = item.Kod;
                        pr_Kod.Value = item.Ids;
                        pr_name.Value = item.Name;
                        item.Id = (int)((long)cm.ExecuteScalar());
                    }
                }
                else
                {
                    pr_x_relzeme.Value = this.RelZeme;
                    pr_x_kod.Value = this.Kod;
                    pr_Kod.Value = this.Ids;
                    pr_name.Value = this.Name;
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
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, x_kod = @x_kod, x_relzeme = @x_relzeme WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_SText = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_kod = cm.Parameters.Add("x_kod", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_relzeme = cm.Parameters.Add("x_relzeme", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCountry)
                    {
                        pr_SText.Value = item.Name;
                        pr_x_kod.Value = item.Kod;
                        pr_x_relzeme.Value = item.RelZeme;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_SText.Value = this.Name;
                    pr_x_kod.Value = this.Kod;
                    pr_x_relzeme.Value = this.RelZeme;
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

        #region  ==========  Static  ==========

        /// <summary>
        /// Получить страну по ID
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public static Country GetCountry(Servers Srv, string NameBase, int Id)
        {
            Country cou = new Country(Id, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Получить страну по Коду (ids)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">Код страны (например: UA)</param>
        /// <returns></returns>
        public static Country GetCountry(Servers Srv, string NameBase, string Ids)
        {
            Country cou = new Country(Ids, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Список или одна страна
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о стране</param>
        /// <returns></returns>
        public static List<Country> GetList(Servers Srv, string BaseName)
        {
            List<Country> li = new List<Country>();
            Dictionary<string, Country> di = new Dictionary<string, Country>();
            Country bn1 = new Country(0, Srv, BaseName, "");
            foreach (var item in bn1.CollectionCountry)
            {
                if (string.IsNullOrWhiteSpace(item.Ids)) continue;
                item.Ids = item.Ids.Substring(0, 2);
                if (!di.ContainsKey(item.Ids)) di.Add(item.Ids, item);
            }
            foreach (var item in di)
            {
                li.Add(item.Value);
            }
            di.Clear();
            return li;
        }

        #endregion
    }
}
