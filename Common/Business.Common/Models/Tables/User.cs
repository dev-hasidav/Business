using Business.Atributes;
using Business.Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// User(s)
    /// </summary>
    [NumClass(56)]
    [Serializable]
    public class User : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public User() : base(Actions.SyncUser) { }
        public User(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncUser) { }
        public User(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncUser) { }

        #endregion

        #region  ==========  Property  ==========

        public Partner Partner { set; get; }
        public int IdCompany { set; get; }
        //public string CompanyIco { set; get; }
        public string NotificationType { set; get; } = "email";
        public string OdoobotState { set; get; } = "onboarding_emoji";
        public string SidebarType { set; get; } = "small";
        public string ChatterPosition { set; get; } = "sided";

        private List<User> _CollectionUser = new List<User>();
        public List<User> CollectionUser { get { return _CollectionUser; } set { _CollectionUser = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; } = NumberRecord.One;
        [NonSerialized]
        public OdooRpc.CoreCLR.Client.OdooRpcClient Client = null;
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
                    CommandText = string.Format(@"SELECT * FROM {0} order by Prijmeni, Jmeno ", this.PrAction.TableSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    string[] ss = Name.Split(new char[] { ' ' });
                    System.Data.SqlClient.SqlParameter pr_Prijmeni = cm.Parameters.Add("Prijmeni", System.Data.SqlDbType.VarChar);
                    pr_Prijmeni.Value = ss[0];
                    string s_jmeno = "";
                    if(ss.Length > 1)
                    {
                        System.Data.SqlClient.SqlParameter pr_Jmeno = cm.Parameters.Add("Jmeno", System.Data.SqlDbType.VarChar);
                        pr_Jmeno.Value = ss[1];
                        s_jmeno = ", Jmeno = @Jmeno";
                    }
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where Prijmeni = @Prijmeni {1}", this.PrAction.TableSql, s_jmeno);
                }
                else { IsSelect = false; }
                this.IsRecord = NumberRecord.Many;
                Dictionary<string, User> di = new Dictionary<string, User>();
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    string s_ids = (dr["Prijmeni"] == DBNull.Value ? "" : dr["Prijmeni"].ToString().Trim()) + " " +
                        (dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim()).Trim();
                    if (di.ContainsKey(s_ids)) continue;
                    User us = new User();
                    us.Id = (int)dr["ID"];
                    us.Ids = s_ids;
                    us.Active = true;
                    us.Partner = new Partner();
                    us.Partner.Name = us.Ids;
                    us.Partner.Jmeno = dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim();
                    us.Partner.Tel = dr["Tel"] == DBNull.Value ? "" : dr["Tel"].ToString().Trim();
                    us.Partner.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString().Trim();
                    us.Partner.Remark = dr["Pozn"] == DBNull.Value ? "" : dr["Pozn"].ToString().Trim();
                    di.Add(s_ids, us);
                }
                dr.Close();
                this.CollectionUser = di.Values.ToList();
                if (IsSelect && this.CollectionUser.Count != 0)
                {
                    this.Id = this.CollectionUser[0].Id;
                    this.Ids = this.CollectionUser[0].Ids;
                    this.Partner = this.CollectionUser[0].Partner;
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
        [NumFunction(23)]
        protected override string LoadSql(int Id)
        {
            string Name = "";
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT Prijmeni, Jmeno FROM {0} where ID = @ID", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                pr_Id.Value = Id;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    Name = (dr["Prijmeni"] == DBNull.Value ? "" : dr["Prijmeni"].ToString().Trim()) + " " +
                        (dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString().Trim()).Trim();
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Name;
        }
        [NumFunction(24)]
        protected override int LoadSql(string Name)
        {
            int Id = 0;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                string[] ss = Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ids1 = "", ids2 = "";
                if (ss.Length == 0)
                {
                    return Id;
                }
                else if (ss.Length == 1)
                {
                    ids1 = ss[0];
                }
                else if (ss.Length == 2)
                {
                    ids1 = ss[0];
                    ids2 = ss[1];
                }
                else
                {
                    ids1 = string.Join(" ", ss, 0, ss.Length - 1);
                    ids2 = ss[ss.Length - 1];
                }
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT ID  FROM {0} where  Prijmeni = @Prijmeni AND Jmeno = @Jmeno", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Prijmeni = cm.Parameters.Add("Prijmeni", System.Data.SqlDbType.VarChar);
                pr_Prijmeni.Value = ids1;
                System.Data.SqlClient.SqlParameter pr_Jmeno = cm.Parameters.Add("Jmeno", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(ids2)) pr_Jmeno.Value = DBNull.Value;
                else pr_Jmeno.Value = ids2;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    Id =(int) dr["ID"];
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Id;
        }
        [NumFunction(2)]
        protected override void CreateSql()
        {
            throw new Exception(string.Format("You cannot create a new User in the '{0}' database", this.Base));
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            throw new Exception(string.Format("You cannot update a new User in the '{0}' database", this.Base));
        }
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            throw new Exception(string.Format("You cannot delete a new User in the '{0}' database", this.Base));
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
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
                this.IsRecord = NumberRecord.Many;
                List<string> li_pole = new List<string>
                {
                        "id",
                        "login",
                        "company_id",
                        "partner_id",
                        "notification_type",
                        //"odoobot_state",
                        //"sidebar_type",
                        "chatter_position"
                };
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id > 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    odoFiltr.Filter("login", "=", Name);
                }
                else { IsSelect = false; }
                odoFiltr.Filter("active", "!=", null);
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr, "login");
                foreach (var item in Datas)
                {
                    User us = new User();
                    us.Id = int.Parse(item["id"]);
                    us.Ids = item["login"] == "False" ? "" : item["login"].Trim();
                    us.IdCompany = ConvertStringToInt.StringOdooToInt(item["company_id"] == "False" ? "0" : item["company_id"]);
                    int IdPartner = ConvertStringToInt.StringOdooToInt(item["partner_id"] == "False" ? "0" : item["partner_id"]);
                    if (IdPartner != 0) us.Partner = Partner.GetPartner(this.Srv, this.Base, IdPartner, this.IcoBase);
                    us.NotificationType = item["notification_type"] == "False" ? "" : item["notification_type"].Trim();
                    //us.OdoobotState = item["odoobot_state"] == "False" ? "" : item["odoobot_state"].Trim();
                    //us.SidebarType = item["sidebar_type"] == "False" ? "" : item["sidebar_type"].Trim();
                    us.ChatterPosition = item["chatter_position"] == "False" ? "" : item["chatter_position"].Trim();
                    this.CollectionUser.Add(us);
                }
                if (IsSelect && this.CollectionUser.Count != 0)
                {
                    this.Id = this.CollectionUser[0].Id;
                    this.Ids = this.CollectionUser[0].Ids;
                    this.IdCompany = this.CollectionUser[0].IdCompany;
                    this.NotificationType = this.CollectionUser[0].NotificationType;
                    this.OdoobotState = this.CollectionUser[0].OdoobotState;
                    this.SidebarType = this.CollectionUser[0].SidebarType;
                    this.ChatterPosition = this.CollectionUser[0].ChatterPosition;
                    this.Partner = this.CollectionUser[0].Partner;
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
                    foreach (var item in this.CollectionUser)
                    {
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "login", item.Ids },
                            { "name", item.Ids },
                            { "x_jmeno", item.Partner.Jmeno },
                            { "phone", item.Partner.Tel },
                            { "email", item.Partner.Email },
                            { "comment", item.Partner.Remark },
                            { "active", true }
                           // { "customer", false },
                           // {"group_multi_company", true }
                       };
                        //if (item.IdCompany != 0) di.Add("company_id", item.IdCompany);
                        if (this.Client == null) item.Id = (int)odScr.InsertRow(Srv, item.PrAction.TableOdoo, di);
                        else item.Id = (int)odScr.InsertRowPacket(Client, item.PrAction.TableOdoo, di);
                    }
                }
                else
                {
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "login", this.Ids },
                            { "name", this.Ids },
                            { "x_jmeno", this.Partner.Jmeno },
                            { "phone", this.Partner.Tel },
                            { "email", this.Partner.Email },
                            { "comment", this.Partner.Remark },
                            { "active", true }
                           // { "customer", false },
                           // {"group_multi_company", true }
                        };
                    //if (this.IdCompany != 0) di.Add("company_id", this.IdCompany);
                    if (this.Client == null) this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
                    else this.Id = (int)odScr.InsertRowPacket(Client, this.PrAction.TableOdoo, di);
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
                Company com = Company.GetCompany(this.IcoBase, this.Srv, this.Base);
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionUser)
                    {
                        Partner pr = Partner.GetPartner(item.Ids, item.Srv, item.Base, item.IcoBase);
                        Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "login", item.Ids },
                            { "x_jmeno", item.Name },
                            { "active", true },
                            { "company_id", com.Id },
                            { "partner_id", pr.Id },
                            { "notification_type", item.NotificationType },
                            { "odoobot_state", item.OdoobotState }
                        };
                odScr.UpdateRow(Srv, this.PrAction.TableOdoo, this.Id, di);
                    }
                }
                else
                {
                    Partner pr = Partner.GetPartner(this.Ids, this.Srv, this.Base, this.IcoBase);
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "login", this.Ids },
                            { "x_jmeno", this.Name },
                            { "company_id", com.Id },
                            { "partner_id", pr.Id },
                            { "notification_type", this.NotificationType },
                            { "odoobot_state", this.OdoobotState }
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
        [NumFunction(17)]
        public void UpdateOdooUsers(Dictionary<int, Dictionary<int, int>> Users)
        {
            try
            {
                UpdatePostgreGroup(Users);
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
                    CommandText = string.Format(@"SELECT * FROM {0} order by login ", this.PrAction.TablePostgreSql)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where login = @login", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_login = cm.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_login.Value = Name;
                }
                else { IsSelect = false; }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    User us = new User();
                    us.Id = (int)dr["ID"];
                    us.Ids = dr["login"] == DBNull.Value ? "" : dr["login"].ToString().Trim();
                    us.IdCompany = dr["company_id"] == DBNull.Value ? 0 : (int)dr["company_id"];
                    int IdPartner = dr["partner_id"] == DBNull.Value ? 0 : (int)dr["partner_id"];
                    us.Partner = Partner.GetPartner(Srv, Base, IdPartner, this.IcoBase);
                    this.CollectionUser.Add(us);
                    this.IsRecord = NumberRecord.Many;
                }
                dr.Close();
                if (IsSelect && this.CollectionUser.Count != 0)
                {
                    this.Id = this.CollectionUser[0].Id;
                    this.Ids = this.CollectionUser[0].Ids;
                    this.IdCompany = this.CollectionUser[0].IdCompany;
                    this.Partner = this.CollectionUser[0].Partner;
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
        [NumFunction(29)]
        protected override string LoadPostgre(int Id)
        {
            string Name = "";
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT login FROM {0} where id = @id", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = Id;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Name = o1.ToString().Trim();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Name;
        }
        [NumFunction(30)]
        protected override int LoadPostgre(string Name)
        {
            int Id = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT id FROM {0} where login = @login", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_Id.Value = Name;
                object o1 = cm.ExecuteScalar();
                if (o1 != null) Id = (int)o1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return Id;
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
                    CommandText = string.Format(@"INSERT INTO {0} (login, active, company_id, partner_id, notification_type, create_date, write_date) " +    // odoobot_state, 
                        @" VALUES (@login, @company_id, @partner_id, @notification_type, @create_date, @write_date)" +  // @odoobot_state, 
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_login = cm.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                Npgsql.NpgsqlParameter pr_company_id = cm.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_notification_type = cm.Parameters.Add("notification_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                // Npgsql.NpgsqlParameter pr_odoobot_state = cm.Parameters.Add("odoobot_state", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_create_date = cm.Parameters.Add("create_date", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_write_date = cm.Parameters.Add("write_date", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_active.Value = true;
                pr_create_date.Value = pr_create_date.Value = DateTime.Now;
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionUser)
                    {
                        Partner pr = Partner.GetPartner(item.Ids, item.Srv, item.Base, item.IcoBase);
                        pr_login.Value = item.Ids;
                        //pr_company_id.Value = com.Id;
                        pr_partner_id.Value = pr.Id;
                        pr_notification_type.Value = item.NotificationType;
                        // pr_odoobot_state.Value = item.OdoobotState;
                        item.Id = (int)cm.ExecuteScalar();
                    }
                }
                else
                {
                    Partner pr = Partner.GetPartner(this.Ids, this.Srv, this.Base, this.IcoBase);
                    pr_login.Value = this.Ids;
                    //pr_company_id.Value = com.Id;
                    pr_partner_id.Value = pr.Id;
                    pr_notification_type.Value = this.NotificationType;
                    // pr_odoobot_state.Value = this.OdoobotState;
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
        [NumFunction(15)]
        protected override void UpdatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(this.Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET notification_type = @notification_type, " +        //  company_id = @company_id, partner_id = @partner_id, 
                        @" active = @active, write_date = @write_date " +   //  odoobot_state = @odoobot_state, 
                        @" WHERE (login = @login) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_login = cm.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_active = cm.Parameters.Add("active", NpgsqlTypes.NpgsqlDbType.Boolean);
                //Npgsql.NpgsqlParameter pr_company_id = cm.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_notification_type = cm.Parameters.Add("notification_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                // Npgsql.NpgsqlParameter pr_odoobot_state = cm.Parameters.Add("odoobot_state", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_write_date = cm.Parameters.Add("write_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                //Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_active.Value = true;
                pr_write_date.Value = DateTime.Now;
                if (this.IsRecord == NumberRecord.Many)
                {
                    foreach (var item in this.CollectionUser)
                    {
                        item.Partner.Id = GetPostgreIdPartner(this.Ids);
                        pr_login.Value = item.Ids;
                        //pr_company_id.Value = item.IdCompany;
                        //pr_partner_id.Value = pr.Id;
                        pr_notification_type.Value = item.NotificationType;
                        // pr_odoobot_state.Value = item.OdoobotState;
                        //pr_Id.Value = item.Id;
                        cm.ExecuteNonQuery();
                        item.Partner.Srv = this.Srv;
                        item.Partner.Update();
                    }
                }
                else
                {
                    this.Partner.Id = GetPostgreIdPartner(this.Ids);
                    pr_login.Value = this.Ids;
                    //pr_company_id.Value = this.IdCompany;
                    //pr_partner_id.Value = pr.Id;
                    pr_notification_type.Value = this.NotificationType;
                    // pr_odoobot_state.Value = this.OdoobotState;
                    //pr_Id.Value = this.Id;
                    cm.ExecuteNonQuery();
                    this.Partner.Srv = this.Srv;
                    this.Partner.Update();
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
        [NumFunction(18)]
        protected void UpdatePostgreGroup(Dictionary<int, Dictionary<int, int>> Users)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                int IdGroupMultiCompani = 4;
                //  check group-user
                Npgsql.NpgsqlCommand cm_s_res_groups_users_rel = new Npgsql.NpgsqlCommand();
                cm_s_res_groups_users_rel.Connection = cn;
                cm_s_res_groups_users_rel.CommandText = string.Format(@"select count(*) from {0} where (gid = @gid) and (uid = @uid)", this.PrAction.TablePostgreSqlDop1);
                Npgsql.NpgsqlParameter pr_s_gid = cm_s_res_groups_users_rel.Parameters.Add("gid", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_s_gid.Value = IdGroupMultiCompani;
                Npgsql.NpgsqlParameter pr_s_uid = cm_s_res_groups_users_rel.Parameters.Add("uid", NpgsqlTypes.NpgsqlDbType.Integer);
                //  write group-user
                Npgsql.NpgsqlCommand cm_i_res_groups_users_rel = new Npgsql.NpgsqlCommand();
                cm_i_res_groups_users_rel.Connection = cn;
                cm_i_res_groups_users_rel.CommandText = string.Format(@"INSERT INTO {0} (gid, uid) VALUES (@gid, @uid)", this.PrAction.TablePostgreSqlDop1);
                Npgsql.NpgsqlParameter pr_i_gid = cm_i_res_groups_users_rel.Parameters.Add("gid", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_i_gid.Value = IdGroupMultiCompani;
                Npgsql.NpgsqlParameter pr_i_uid = cm_i_res_groups_users_rel.Parameters.Add("uid", NpgsqlTypes.NpgsqlDbType.Integer);
                //  check company-user  res_company_users_rel
                Npgsql.NpgsqlCommand cm_d_res_company_users_rel = new Npgsql.NpgsqlCommand();
                cm_d_res_company_users_rel.Connection = cn;
                cm_d_res_company_users_rel.CommandText = string.Format(@"DELETE FROM {0} where (user_id = @user_id)", this.PrAction.TablePostgreSqlDop2);
                Npgsql.NpgsqlParameter pr_d_user_id = cm_d_res_company_users_rel.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //  update Partner -> Id Company
                Npgsql.NpgsqlCommand cm_u_partner_users_rel = new Npgsql.NpgsqlCommand();
                cm_u_partner_users_rel.Connection = cn;
                cm_u_partner_users_rel.CommandText = @"UPDATE res_users SET company_id = @IdCompany WHERE (ID = @IdUser )";
                Npgsql.NpgsqlParameter pr_u_IdCompany = cm_u_partner_users_rel.Parameters.Add("IdCompany", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_u_IdUser = cm_u_partner_users_rel.Parameters.Add("IdUser", NpgsqlTypes.NpgsqlDbType.Integer);
                //  write company-user
                Npgsql.NpgsqlCommand cm_i_res_company_users_rel = new Npgsql.NpgsqlCommand();
                cm_i_res_company_users_rel.Connection = cn;
                cm_i_res_company_users_rel.CommandText = string.Format(@"INSERT INTO {0} (cid, user_id) VALUES (@cid, @user_id)", this.PrAction.TablePostgreSqlDop2);
                Npgsql.NpgsqlParameter pr_i_cid = cm_i_res_company_users_rel.Parameters.Add("cid", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_i_user_id = cm_i_res_company_users_rel.Parameters.Add("user_id", NpgsqlTypes.NpgsqlDbType.Integer);
                //
                foreach (var item in Users)
                {
                    pr_s_uid.Value = item.Key;
                    long l1 = (long)cm_s_res_groups_users_rel.ExecuteScalar();
                    if (l1 == 0)
                    {
                        pr_i_uid.Value = item.Key;
                        cm_i_res_groups_users_rel.ExecuteNonQuery();
                    }
                    List<int> li = item.Value.Keys.ToList();
                    if (li.Count > 0)
                    {
                        pr_u_IdCompany.Value = li[0];
                        pr_u_IdUser.Value = item.Key;
                        cm_u_partner_users_rel.ExecuteNonQuery();
                    }

                    pr_d_user_id.Value = item.Key;
                    cm_d_res_company_users_rel.ExecuteNonQuery();
                    pr_i_user_id.Value = item.Key;
                    foreach (int idComp in li)
                    {
                        pr_i_cid.Value = idComp;
                        cm_i_res_company_users_rel.ExecuteNonQuery();
                        //}
                    }
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
        [NumFunction(19)]
        protected int GetPostgreIdPartner(int IdUser)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = "SELECT partner_id FROM res_users WHERE(ID = @id)"
                };
                Npgsql.NpgsqlParameter pr_id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_id.Value = IdUser;
                n1 = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return n1;
        }
        [NumFunction(21)]
        protected int GetPostgreIdPartner(string login)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = "SELECT partner_id FROM res_users WHERE(login = @login)"
                };
                Npgsql.NpgsqlParameter pr_id = cm.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_id.Value = login;
                n1 = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return n1;
        }
        [NumFunction(20)]
        protected int GetPostgreIdCompany(int IdUser)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = "SELECT company_id FROM res_users WHERE(ID = @id)"
                };
                Npgsql.NpgsqlParameter pr_id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_id.Value = IdUser;
                n1 = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return n1;
        }
        [NumFunction(22)]
        protected int GetPostgreIdCompany(string login)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = "SELECT company_id FROM res_users WHERE(login = @login)"
                };
                Npgsql.NpgsqlParameter pr_id = cm.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_id.Value = login;
                n1 = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return n1;
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

        #region  ==========  Доп функции  ==========

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список или одна user(s)
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о user(s)</param>
        /// <returns></returns>
        public static List<User> GetList(Servers Srv, string BaseName)
        {
            List<User> li = new List<User>();
            User bn = new User(0, Srv, BaseName, "");
            foreach (var item in bn.CollectionUser)
            {
                if (string.IsNullOrWhiteSpace(item.Ids)) continue;
                li.Add(item);
            }
            return li;
        }

        /// <summary>
        /// Получить информацию о user(s) по ID
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static User GetUser(int id, Servers Srv, string BaseName)
        {
            User com = new User(id, Srv, BaseName, "");
            return com;
        }

        /// <summary>
        /// Получить информацию о user(s)  по Prijmeni или Login
        /// </summary>
        /// <param name="Name">Prijmeni или Login</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static User GetUser(string Name, Servers Srv, string BaseName)
        {
            User com = new User(Name, Srv, BaseName, "");
            return com;
        }

        /// <summary>
        /// Получение кеша по ID oser-a
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <param name="BaseIco"></param>
        /// <returns></returns>
        public static Dictionary<int, User> GetChashUserId(Servers Srv, string BaseName, string BaseIco)
        {
            Dictionary<int, User> di_id = new Dictionary<int, User>();
            User bn = new User(0, Srv, BaseName, BaseIco);
            foreach (User pb in bn.CollectionUser)
            {
                if (!di_id.ContainsKey(pb.Id))
                {
                    di_id.Add(pb.Id, pb);
                }
            }
            return di_id;
        }

        /// <summary>
        /// Получение кеша по login oser-a
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <param name="BaseIco"></param>
        /// <returns></returns>
        public static Dictionary<string, User> GetChashUserLogin(Servers Srv, string BaseName, string BaseIco)
        {
            Dictionary<string, User> di_id = new Dictionary<string, User>();
            User bn = new User(0, Srv, BaseName, BaseIco);
            foreach (User pb in bn.CollectionUser)
            {
                if (!di_id.ContainsKey(pb.Ids))
                {
                    di_id.Add(pb.Ids, pb);
                }
            }
            return di_id;
        }

        /// <summary>
        /// Быстрый способ получить Name юзера по ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static string GetNameUser(int Id, Servers Srv, string BaseName)
        {
            User com = new User();
            com.Srv = Srv;
            com.Base = BaseName;
            return com.Load(Id);
        }

        /// <summary>
        /// Быстрый способ получить ID юзера по Name
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static int GetIdUser(string Name, Servers Srv, string BaseName)
        {
            User com = new User();
            com.Srv = Srv;
            com.Base = BaseName;
            return com.Load(Name);
        }

        #endregion

    }
}
