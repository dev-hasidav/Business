using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Atributes;

namespace Business.Models.Tables
{
    [NumClass(69)]
    [Serializable]
    public class Cinnost : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public Cinnost() : base(Actions.SyncCin) { }
        public Cinnost(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncCin) { }
        public Cinnost(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncCin) { }

        #endregion

        #region  ==========  Property  ==========

        public string Remark { set; get; }

        private List<Cinnost> _CollectionCinnost = new List<Cinnost>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<Cinnost> CollectionCinnost { get { return _CollectionCinnost; } set { _CollectionCinnost = value; IsRecord = NumberRecord.Many; } }
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
                    Cinnost cr = new Cinnost();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = (int)dr["ID"];
                    cr.Name = dr["Stext"] == DBNull.Value ? "" : dr["Stext"].ToString().Trim();
                    cr.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    cr.Remark = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    this.CollectionCinnost.Add(cr);
                    cr.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionCinnost.Count != 0)
                {
                    this.Id = this.CollectionCinnost[0].Id;
                    this.Name = this.CollectionCinnost[0].Name;
                    this.Ids = this.CollectionCinnost[0].Ids;
                    this.Remark = this.CollectionCinnost[0].Remark;
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
                    CommandText = string.Format(@"INSERT INTO {0} (IDS, sText, Pozn) VALUES (@IDS, @sText, @Pozn)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText = cm.Parameters.Add("sText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);

                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCinnost)
                    {
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_sText.Value = DBNull.Value;
                        else pr_sText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_Pozn.Value = DBNull.Value;
                        else pr_Pozn.Value = item.Remark;
                        item.Id = (int)cm.ExecuteScalar();
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_sText.Value = DBNull.Value;
                    else pr_sText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_Pozn.Value = DBNull.Value;
                    else pr_Pozn.Value = this.Remark;
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
                    CommandText = string.Format(@"UPDATE {0} SET IDS = @IDS, sText = @sText, Pozn = @Pozn WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_IDS = cm.Parameters.Add("IDS", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_sText = cm.Parameters.Add("sText", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCinnost)
                    {
                        pr_IDS.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_sText.Value = DBNull.Value;
                        else pr_sText.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_Pozn.Value = DBNull.Value;
                        else pr_Pozn.Value = item.Remark;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_IDS.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_sText.Value = DBNull.Value;
                    else pr_sText.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_Pozn.Value = DBNull.Value;
                    else pr_Pozn.Value = this.Remark;
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
            this.Id = 0;
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
                        "x_remark"
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
                    Cinnost cr = new Cinnost();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = int.Parse(item["id"]);
                    cr.Ids = item["x_ids"] == "False" ? "" : item["x_ids"];
                    cr.Name = item["x_name"] == "False" ? "" : item["x_name"];
                    cr.Remark = item["x_remark"] == "False" ? "" : item["x_remark"];
                    this.CollectionCinnost.Add(cr);
                }
                if (IsSelect && this.CollectionCinnost.Count != 0)
                {
                    this.Id = this.CollectionCinnost[0].Id;
                    this.Name = this.CollectionCinnost[0].Name;
                    this.Ids = this.CollectionCinnost[0].Ids;
                    this.Remark = this.CollectionCinnost[0].Remark;
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
                OdooScripts odScr = new OdooScripts();
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCinnost)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "symbol", item.Ids },
                            { "active", item.Name },
                            { "x_mnozstvi", item.Remark }
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
                            { "active", this.Name },
                            { "x_mnozstvi", this.Remark }
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
                    foreach (var item in this.CollectionCinnost)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", item.Name },
                            { "symbol", item.Ids },
                            { "active", item.Name },
                            { "x_mnozstvi", item.Remark }
                        };
                        odScr.UpdateRow(Srv, item.PrAction.TableOdoo, item.Id, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "name", this.Name },
                            { "symbol", this.Ids },
                            { "active", this.Name },
                            { "x_mnozstvi", this.Remark }
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
                    Cinnost cr = new Cinnost();
                    cr.Srv = this.Srv;
                    cr.Base = this.Base;
                    cr.Id = (int)dr["id"];
                    cr.Name = dr["x_name"] == DBNull.Value ? "" : dr["x_name"].ToString().Trim();
                    cr.Ids = dr["x_ids"] == DBNull.Value ? "" : dr["x_ids"].ToString().Trim();
                    cr.Remark = dr["x_remark"] == DBNull.Value ? "" : dr["x_remark"].ToString().Trim();
                    this.CollectionCinnost.Add(cr);
                }
                dr.Close();
                if (IsSelect && this.CollectionCinnost.Count != 0)
                {
                    this.Id = this.CollectionCinnost[0].Id;
                    this.Name = this.CollectionCinnost[0].Name;
                    this.Ids = this.CollectionCinnost[0].Ids;
                    this.Remark = this.CollectionCinnost[0].Remark;
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
                this.Id = 0;
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (x_ids, x_name, x_remark) VALUES (@x_ids, @x_name, @x_remark)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_x_ids = cm.Parameters.Add("x_ids", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_name = cm.Parameters.Add("x_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_remark = cm.Parameters.Add("x_remark", NpgsqlTypes.NpgsqlDbType.Varchar);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCinnost)
                    {
                        pr_x_ids.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_x_name.Value = DBNull.Value;
                        else pr_x_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_x_remark.Value = DBNull.Value;
                        else pr_x_remark.Value = item.Remark;
                        item.Id = (int)((long)cm.ExecuteScalar());
                    }
                }
                else
                {
                    pr_x_ids.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_x_name.Value = DBNull.Value;
                    else pr_x_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_x_remark.Value = DBNull.Value;
                    else pr_x_remark.Value = this.Remark;
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
                Npgsql.NpgsqlParameter pr_x_ids = cm.Parameters.Add("x_ids", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_name = cm.Parameters.Add("x_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_x_remark = cm.Parameters.Add("x_remark", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionCinnost)
                    {
                        pr_x_ids.Value = item.Ids;
                        if (string.IsNullOrWhiteSpace(item.Name)) pr_x_name.Value = DBNull.Value;
                        else pr_x_name.Value = item.Name;
                        if (string.IsNullOrWhiteSpace(item.Remark)) pr_x_remark.Value = DBNull.Value;
                        else pr_x_remark.Value = item.Remark;
                        pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                    }
                }
                else
                {
                    pr_x_ids.Value = this.Ids;
                    if (string.IsNullOrWhiteSpace(this.Name)) pr_x_name.Value = DBNull.Value;
                    else pr_x_name.Value = this.Name;
                    if (string.IsNullOrWhiteSpace(this.Remark)) pr_x_remark.Value = DBNull.Value;
                    else pr_x_remark.Value = this.Remark;
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

        #region  ==========  Разное  ==========

        public void GetIdOrCreate(Servers Srv)
        {
            if (string.IsNullOrWhiteSpace(this.Ids))
            {
                this.Id = 0;
            }
            else
            {
                this.Srv = Srv;
                this.Load(0, this.Ids);
                if (this.Id == 0)
                {
                    this.Create();
                }
            }
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
        public static Cinnost GetCinnost(Servers Srv, string NameBase, int Id)
        {
            Cinnost cou = new Cinnost(Id, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Получить валюту по Коду (Name)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">Код страны (например: UA)</param>
        /// <returns></returns>
        public static Cinnost GetCinnost(Servers Srv, string NameBase, string Ids)
        {
            Cinnost cou = new Cinnost(Ids, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Список или одна валюта
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о стране</param>
        /// <returns></returns>
        public static List<Cinnost> GetList(Servers Srv, string BaseName)
        {
            List<Cinnost> li = new List<Cinnost>();
            Cinnost bn1 = new Cinnost(0, Srv, BaseName, "");
            foreach (var item in bn1.CollectionCinnost)
            {
                if (item.Id != 0) li.Add(item);
            }
            return li;
        }

        public static Dictionary<string, Cinnost> GetChashCinnostIds(Servers Srv, string BaseName)
        {
            Dictionary<string, Cinnost> di_id = new Dictionary<string, Cinnost>();
            Cinnost bn = new Cinnost(0, Srv, BaseName, null);
            foreach (Cinnost pb in bn.CollectionCinnost)
            {
                if (string.IsNullOrWhiteSpace(pb.Ids)) continue;
                if (di_id.ContainsKey(pb.Ids)) continue;
                di_id.Add(pb.Ids, pb);
            }
            return di_id;
        }

        public static Dictionary<int, Cinnost> GetChashPartnerId(Servers Srv, string BaseName)
        {
            Dictionary<int, Cinnost> di_id = new Dictionary<int, Cinnost>();
            Cinnost bn = new Cinnost(0, Srv, BaseName, null);
            foreach (Cinnost pb in bn.CollectionCinnost)
            {
                di_id.Add(pb.Id, pb);
            }
            return di_id;
        }

        #endregion
    }
}
