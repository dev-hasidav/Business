using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    [NumClass(43)]
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Ids: {Ids}, Name: {Name}, SWIFT: {SWIFT}, Type: {Srv.Type}")]
    public class Bank : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Bank() : base(Actions.SyncBank) { }
        public Bank(int Id, Models.Servers Server, string BaseData, string Ico ) : base(Id, Server, BaseData, Ico, Actions.SyncBank) { }
        public Bank(string KodBanky, Models.Servers Server, string BaseData, string Ico ) : base(KodBanky, Server, BaseData, Ico, Actions.SyncBank) { }

        #endregion

        #region  ==========  Property  ==========

        public string SWIFT { set; get; } = "";
        public string Country { set; get; }
        public string Www { set; get; }
        public int IdCountry { set; get; }

        private List<Bank> _CollectionBank = new List<Bank>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Bank> CollectionBank { get { return _CollectionBank; } set { _CollectionBank = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; }
        [NonSerialized]
        public OdooRpc.CoreCLR.Client.OdooRpcClient Client = null;

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string KodBanky)
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
                    CommandText = string.Format(@"SELECT ID, Sel, IDS, SText, WWW, SWIFT, KodZeme FROM {0} order by IDS ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT ID, Sel, IDS, SText, WWW, SWIFT, KodZeme FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(KodBanky))
                {
                    string s_q = @"ID, Sel, IDS, SText, WWW, SWIFT, KodZeme";
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} where IDS = @IDS " +
                        @" union " +
                        @" SELECT {1} FROM {0} where SWIFT = @IDS", this.PrAction.TableSql, s_q);
                    System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                    pr_IDS.Value = KodBanky;
                }
                else { IsSelect = false; }

                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Bank bk = new Bank();
                    bk.Srv = this.Srv;
                    bk.Base = this.Base;
                    bk.Id = (int)dr["ID"];
                    bk.Active = (bool)dr["Sel"];
                    bk.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    bk.Name = dr["SText"] == DBNull.Value ? "" : dr["SText"].ToString().Trim();
                    bk.SWIFT = dr["SWIFT"] == DBNull.Value ? "" : dr["SWIFT"].ToString().Trim();
                    bk.Country = dr["KodZeme"] == DBNull.Value ? "" : dr["KodZeme"].ToString().Trim();
                    bk.Www = dr["WWW"] == DBNull.Value ? "" : dr["WWW"].ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(this.Country)) bk.IdCountry = Tables.Country.GetCountry(Srv, Base, this.Country).Id;
                    else bk.IdCountry = 0;
                    this.CollectionBank.Add(bk);
                    this.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if(IsSelect && this.CollectionBank.Count != 0)
                {
                    this.Id = this.CollectionBank[0].Id;
                    this.Active = this.CollectionBank[0].Active;
                    this.Ids = this.CollectionBank[0].Ids;
                    this.Name = this.CollectionBank[0].Name;
                    this.SWIFT = this.CollectionBank[0].SWIFT;
                    this.Country = this.CollectionBank[0].Country;
                    this.Www = this.CollectionBank[0].Www;
                    this.IdCountry = this.CollectionBank[0].IdCountry;
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
                    CommandText = string.Format(@"INSERT INTO {0} (Sel, SText, SWIFT, KodZeme, IDS, WWW, Ucetni, Creator, Pozn) 
                        VALUES (@Sel, @SText, @SWIFT, @KodZeme, @IDS, @WWW, @Ucetni, @Creator, @Pozn)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Sel = cm.Parameters.Add("Sel", System.Data.SqlDbType.Bit);
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_SWIFT = cm.Parameters.Add("SWIFT", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_KodZeme = cm.Parameters.Add("KodZeme", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_WWW = cm.Parameters.Add("WWW", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_Creator = cm.Parameters.Add("Creator", System.Data.SqlDbType.VarChar);
                pr_Creator.Value = SqlScripts.NameUserCreator;
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                pr_Pozn.Value = SqlScripts.SynchPozn;
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionBank)
                    {
                        pr_Sel.Value = item.Active;
                        pr_SText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.SWIFT)) pr_SWIFT.Value = DBNull.Value;
                        else pr_SWIFT.Value = item.SWIFT;
                        if (string.IsNullOrWhiteSpace(item.Country)) pr_KodZeme.Value = DBNull.Value;
                        else pr_KodZeme.Value = item.Country;
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_WWW.Value = DBNull.Value;
                        else pr_WWW.Value = item.Www.Length > 32 ? item.Www.Substring(0, 32) : item.Www;
                        item.Id = (int)cm.ExecuteScalar();
                    }
                }
                else
                {
                    pr_Sel.Value = this.Active;
                    pr_SText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.SWIFT)) pr_SWIFT.Value = DBNull.Value;
                    else pr_SWIFT.Value = this.SWIFT;
                    if (string.IsNullOrWhiteSpace(this.Country)) pr_KodZeme.Value = DBNull.Value;
                    else pr_KodZeme.Value = this.Country;
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_WWW.Value = DBNull.Value;
                    else pr_WWW.Value = this.Www.Length > 32 ? this.Www.Substring(0, 32) : this.Www;
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
                    CommandText = string.Format(@"UPDATE {0} 
                        SET Sel = @Sel, SText = @SText, SWIFT = @SWIFT, KodZeme = @KodZeme, WWW = @WWW, Ucetni = @Ucetni
                        WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Sel = cm.Parameters.Add("Sel", System.Data.SqlDbType.Bit);
                System.Data.SqlClient.SqlParameter pr_SText = cm.Parameters.Add("SText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_SWIFT = cm.Parameters.Add("SWIFT", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_WWW = cm.Parameters.Add("WWW", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_KodZeme = cm.Parameters.Add("KodZeme", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionBank)
                    {
                        pr_Sel.Value = item.Active;
                        pr_SText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.SWIFT)) pr_SWIFT.Value = DBNull.Value;
                        else pr_SWIFT.Value = item.SWIFT;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_WWW.Value = DBNull.Value;
                        else pr_WWW.Value = item.Www.Length > 32 ? item.Www.Substring(0, 32) : item.Www;
                        if (string.IsNullOrWhiteSpace(item.Country)) pr_KodZeme.Value = DBNull.Value;
                        else pr_KodZeme.Value = item.Country;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_Sel.Value = this.Active;
                    pr_SText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.SWIFT)) pr_SWIFT.Value = DBNull.Value;
                    else pr_SWIFT.Value = this.SWIFT;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_WWW.Value = DBNull.Value;
                    else pr_WWW.Value = this.Www.Length > 32 ? this.Www.Substring(0, 32) : this.Www;
                    if (string.IsNullOrWhiteSpace(this.Country)) pr_KodZeme.Value = DBNull.Value;
                    else pr_KodZeme.Value = this.Country;
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
        protected override void LoadOdoo(int Id, string KodBanky)
        {
            bool IsSelect = true;
            List<Dictionary<string, string>> Datas = null;
            try
            {
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
                List<string> li_pole = new List<string>
                {
                    "id",
                    "name",
                    "country",
                    "active",
                    "bic",
                    "city",
                    "x_idsb"
                };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0) odoFiltr.Filter("id", "=", Id);
                else if (!string.IsNullOrWhiteSpace(KodBanky))
                {
                    odoFiltr.Filter("x_idsb", "=", KodBanky);
                    odoFiltr.Or();
                    odoFiltr.Filter("bic", "=", KodBanky);
                }
                else { IsSelect = false; }
                odoFiltr.Filter("active", "!=", null);
                Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                foreach (var item in Datas)
                {
                    Bank bk = new Bank();
                    bk.Srv = this.Srv;
                    bk.Base = this.Base;
                    bk.Id = int.Parse(item["id"]);
                    bk.Name = item["name"] == "False" ? "" : item["name"];
                    bk.Active = bool.Parse(item["active"]);
                    bk.SWIFT = item["bic"] == "False" ? "" : item["bic"];
                    bk.Www = item["city"] == "False" ? "" : item["city"];
                    bk.Ids = item["x_idsb"] == "False" ? "" : item["x_idsb"];
                    string s1 = item["country"] == "False" ? "0" : item["country"];
                    System.Text.RegularExpressions.Match mt = rg.Match(s1);
                    if (mt.Success)
                    {
                        bk.IdCountry = int.Parse(mt.Value);
                    }
                    else
                    {
                        bk.IdCountry = 0;
                    }
                    if (bk.IdCountry != 0) bk.Country = Tables.Country.GetCountry(Srv, Base, bk.IdCountry).Ids;
                    else bk.Country = "";
                    this.CollectionBank.Add(bk);
                    this.IsRecord = NumberRecord.Many;
                }
                if (IsSelect && this.CollectionBank.Count != 0)
                {
                    this.Id = this.CollectionBank[0].Id;
                    this.Name = this.CollectionBank[0].Name;
                    this.Active = this.CollectionBank[0].Active;
                    this.SWIFT = this.CollectionBank[0].SWIFT;
                    this.Www = this.CollectionBank[0].Www;
                    this.Ids = this.CollectionBank[0].Ids;
                    this.IdCountry = this.CollectionBank[0].IdCountry;
                    this.Country = this.CollectionBank[0].Country;
                    this.IsRecord = NumberRecord.One;
                }
            }
            catch (Exception e1)
            {
                Exception e2 = new Exception(string.Format("Id: {0}, IDS: {1}", Id, KodBanky), e1);
                FileEventLog.WriteErr(this, e2, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e2;
            }
            return;
        }
        [NumFunction(10)]
        protected override void CreateOdoo()
        {
            try
            {
                if (this.IdCountry == 0)
                {
                    if (!string.IsNullOrWhiteSpace(this.Country))
                    {
                        this.IdCountry = Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                }
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionBank)
                    {
                        item.IdCountry = 0;
                        if (!string.IsNullOrWhiteSpace(item.Country))
                        {
                            item.IdCountry = Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "bic", item.SWIFT },
                            { "city", item.Www },
                            { "active", item.Active },
                            { "country", item.IdCountry },
                            { "x_idsb", item.Ids },
                        };
                        if (this.Client == null) item.Id = (int)odScr.InsertRow(Srv, item.PrAction.TableOdoo, di);
                        else item.Id = (int)odScr.InsertRowPacket(this.Client, item.PrAction.TableOdoo, di);
                    }
                }
                else
                {
                    this.IdCountry = 0;
                    if (!string.IsNullOrWhiteSpace(this.Country))
                    {
                        this.IdCountry = Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "bic", this.SWIFT },
                            { "city", this.Www },
                            { "active", this.Active },
                            { "country", this.IdCountry },
                            { "x_idsb", this.Ids },
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
                    foreach (var item in this.CollectionBank)
                    {
                        item.IdCountry = 0;
                        if (!string.IsNullOrWhiteSpace(item.Country))
                        {
                            item.IdCountry = Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "bic", item.SWIFT },
                            { "city", item.Www },
                            { "active", item.Active },
                            { "country", item.IdCountry }
                        };
                        odScr.UpdateRow(Srv, item.PrAction.TableOdoo, item.Id, di);
                    }
                }
                else
                {
                    this.IdCountry = 0;
                        if (!string.IsNullOrWhiteSpace(this.Country))
                    {
                        this.IdCountry = Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "name", this.Name },
                            { "bic", this.SWIFT },
                            { "city", this.Www },
                            { "active", this.Active },
                            { "country", this.IdCountry }
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
        protected override void LoadPostgre(int Id, string KodBanky)
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
                    CommandText = string.Format(@"SELECT id, name, country, active, bic, city, x_idsb FROM {0} order by bic ", this.PrAction.TablePostgreSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT id, name, country, active, bic, city, x_idsb FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(KodBanky))
                {
                    string s_q = @"id, name, country, active, bic, city, x_idsb";
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} where x_idsb = @x_idsb " +
                        @" union " +
                        @" SELECT {1} FROM {0} where bic = @x_idsb", this.PrAction.TablePostgreSql, s_q);
                    Npgsql.NpgsqlParameter pr_Ids = cm.Parameters.Add("x_idsb", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_Ids.Value = KodBanky;
                }
                else { IsSelect = false; }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Bank bk = new Bank();
                    bk.Srv = this.Srv;
                    bk.Base = this.Base;
                    bk.Id = (int)dr["id"];
                    bk.Active = (bool)dr["active"];
                    bk.Ids = dr["x_idsb"] == DBNull.Value ? "" : dr["x_idsb"].ToString().Trim();
                    bk.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    bk.SWIFT = dr["bic"] == DBNull.Value ? "" : dr["bic"].ToString().Trim();
                    bk.IdCountry = dr["country"] == DBNull.Value ? 0 : (int)dr["country"];
                    bk.Www = dr["city"] == DBNull.Value ? "" : dr["city"].ToString().Trim();
                    if (bk.IdCountry != 0) bk.Country = Tables.Country.GetCountry(Srv, Base, bk.IdCountry).Ids;
                    else bk.Country = "";
                    this.CollectionBank.Add(bk);
                    this.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionBank.Count != 0)
                {
                    this.Id = this.CollectionBank[0].Id;
                    this.Active = this.CollectionBank[0].Active;
                    this.Ids = this.CollectionBank[0].Ids;
                    this.Name = this.CollectionBank[0].Name;
                    this.SWIFT = this.CollectionBank[0].SWIFT;
                    this.Country = this.CollectionBank[0].Country;
                    this.Www = this.CollectionBank[0].Www;
                    this.IdCountry = this.CollectionBank[0].IdCountry;
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
                    CommandText = string.Format(@"INSERT INTO {0} (name, country, active, bic, city, x_idsb ) VALUES ( @name, @country, @active, @bic, @city, @x_idsb ); " +
                        " SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                Npgsql.NpgsqlParameter pr_country = cm.Parameters.Add("country", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_bic = cm.Parameters.Add("bic", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_city = cm.Parameters.Add("city", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ids = cm.Parameters.Add("x_idsb", NpgsqlTypes.NpgsqlDbType.Varchar);

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionBank)
                    {
                        if (!string.IsNullOrWhiteSpace(item.Country))
                        {
                            item.IdCountry = Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        pr_name.Value = this.Name;
                        pr_active.Value = item.Active;
                        if (item.IdCountry == 0) pr_country.Value = DBNull.Value;
                        else pr_country.Value = item.IdCountry;
                        if (string.IsNullOrWhiteSpace(item.SWIFT)) pr_bic.Value = DBNull.Value;
                        else pr_bic.Value = item.SWIFT;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_city.Value = DBNull.Value;
                        else pr_city.Value = item.Www;
                        pr_Ids.Value = item.Ids;
                        object o1 = cm.ExecuteScalar();
                        item.Id = (int)((long)o1);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(this.Country))
                    {
                        this.IdCountry = Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    pr_name.Value = this.Name;
                    pr_active.Value = this.Active;
                    if (this.IdCountry == 0) pr_country.Value = DBNull.Value;
                    else pr_country.Value = this.IdCountry;
                    if (string.IsNullOrWhiteSpace(this.SWIFT)) pr_bic.Value = DBNull.Value;
                    else pr_bic.Value = this.SWIFT;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_city.Value = DBNull.Value;
                    else pr_city.Value = this.Www;
                    pr_Ids.Value = this.Ids;
                    object o1 = cm.ExecuteScalar();
                    this.Id = (int)((long)o1);
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
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, country = @country, active = @active, bic = @bic, city = @city, x_idsb = @x_idsb WHERE (id = @id) ",
                    this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                Npgsql.NpgsqlParameter pr_country = cm.Parameters.Add("country", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_bic = cm.Parameters.Add("bic", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_city = cm.Parameters.Add("city", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Ids = cm.Parameters.Add("x_idsb", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionBank)
                    {
                        if (!string.IsNullOrWhiteSpace(item.Country))
                        {
                            item.IdCountry = Tables.Country.GetCountry(item.Srv, item.Base, item.Country).Id;
                        }
                        pr_name.Value = string.IsNullOrWhiteSpace(this.Name) ? "Bank " + this.Ids : this.Name;
                        pr_active.Value = item.Active;
                        if (item.IdCountry == 0) pr_country.Value = DBNull.Value;
                        else pr_country.Value = item.IdCountry;
                        if (string.IsNullOrWhiteSpace(item.SWIFT)) pr_bic.Value = DBNull.Value;
                        else pr_bic.Value = item.SWIFT;
                        if (string.IsNullOrWhiteSpace(item.Www)) pr_city.Value = DBNull.Value;
                        else pr_city.Value = item.Www;
                        pr_Ids.Value = item.Ids;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(this.Country))
                    {
                        this.IdCountry = Tables.Country.GetCountry(this.Srv, this.Base, this.Country).Id;
                    }
                    pr_name.Value = string.IsNullOrWhiteSpace(this.Name) ? "Bank " + this.Ids : this.Name;
                    pr_active.Value = this.Active;
                    if (this.IdCountry == 0) pr_country.Value = DBNull.Value;
                    else pr_country.Value = this.IdCountry;
                    if (string.IsNullOrWhiteSpace(this.SWIFT)) pr_bic.Value = DBNull.Value;
                    else pr_bic.Value = this.SWIFT;
                    if (string.IsNullOrWhiteSpace(this.Www)) pr_city.Value = DBNull.Value;
                    else pr_city.Value = this.Www;
                    pr_Ids.Value = this.Ids;
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

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список или один банк
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о банке</param>
        /// <returns></returns>
        public static List<Bank> GetList(Servers Srv, string BaseName)
        {
            List<Bank> li = new List<Bank>();
            Bank bn1 = new Bank(0, Srv, BaseName, "");
            foreach (var item in bn1.CollectionBank)
            {
                if (string.IsNullOrWhiteSpace(item.Ids)) continue;
                if (item.Id != 0) li.Add(item);
            }
            return li;
        }

        /// <summary>
        /// Получить информайию о банке по IDS или x_idsb
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <param name="Ids">IDS или KodBanky</param>
        /// <returns></returns>
        public static Bank GetBank(Servers Srv, string BaseName, string Ids)
        {
            Bank bn = new Bank(Ids, Srv, BaseName, "");
            return bn;
        }
        public static Bank GetBank(Servers Srv, string BaseName, int Id)
        {
            Bank bn = new Bank(Id, Srv, BaseName, "");
            return bn;
        }
        /// <summary>
        /// Загрузка словаря по KodBanky (ids + swift)
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Dictionary<string, Bank> GetChashBankIds(Servers Srv, string BaseName)
        {
            Dictionary<string, Bank> di_id = new Dictionary<string, Bank>();
            Bank bn1 = new Bank(0, Srv, BaseName, "");
            foreach (Bank bn in bn1.CollectionBank)
            {
                if (!string.IsNullOrWhiteSpace(bn.Ids))
                {
                    if (!di_id.ContainsKey(bn.Ids))
                    {
                        di_id.Add(bn.Ids, bn);
                    }
                }
                if (!string.IsNullOrWhiteSpace(bn.SWIFT))
                {
                    if (!di_id.ContainsKey(bn.SWIFT))
                    {
                        di_id.Add(bn.SWIFT, bn);
                    }
                }
            }
            return di_id;
        }
        /// <summary>
        /// Загрузка словаря по ID
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static Dictionary<int, Bank> GetChashBankId(Servers Srv, string BaseName)
        {
            Dictionary<int, Bank> di_id = new Dictionary<int, Bank>();
            Bank bn1 = new Bank(0, Srv, BaseName, "");
            foreach (Bank bn in bn1.CollectionBank)
            {
                di_id.Add(bn.Id, bn);
            }
            return di_id;
        }

        #endregion
    }
}
