using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [NumClass(35)]
    [Serializable]
    public class RetTriggers
    {
        #region  ==========  Property  ==========

        /// <summary>
        /// Id записи в таблице sEventTriggers
        /// </summary>
        public int Id { set; get; } = 0;
        /// <summary>
        /// Стадия триггерной задачи
        /// </summary>
        public Enums.StTriggers IsTask { set; get; } = 0;
        /// <summary>
        /// GUID задачи создавшей триггер
        /// </summary>
        public string GuidTask { set; get; } = "";
        /// <summary>
        /// Id записи вызвавший срабатывания задачи
        /// </summary>
        public int IdRecord { set; get; } = 0;
        /// <summary>
        /// Действие в таблице вызвавший срабатывания задачи
        /// </summary>
        public string TriggerAction { set; get; } = "";
        /// <summary>
        /// Имя триггера вызвавший срабатывания задачи
        /// </summary>
        public string NameTrigger { set; get; } = "";
        /// <summary>
        /// Имя таблицы вызвавший срабатывания задачи
        /// </summary>
        public string NameTable { set; get; } = "";
        /// <summary>
        /// Имя базы вызвавший срабатывания задачи
        /// </summary>
        public string NameBase { set; get; } = "";
        /// <summary>
        /// Имя сервера вызвавший срабатывания задачи
        /// </summary>
        public string NameServer { set; get; } = "";
        /// <summary>
        /// Данные верны ???
        /// </summary>
        public bool IsOk { set; get; } = false;
        /// <summary>
        /// Тип сообшения - End = 5, Sen = 6
        /// </summary>
        public StatusMessage Status { set; get; } = StatusMessage.No;
        /// <summary>
        /// Код сообщения.     _ok = 5683562   _end = -1396247
        /// </summary>
        public int CodeMess { set; get; } = 0;
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset DateCreate { set; get; } = DateTimeOffset.Now.ToUniversalTime();
        /// <summary>
        /// Дата обработки CLR - trigger
        /// </summary>
        public DateTimeOffset DateTrigger { set; get; } = DateTimeOffset.Now.ToUniversalTime();
        /// <summary>
        /// Дата окончательной обработки
        /// </summary>
        public DateTimeOffset DateClose { set; get; } = DateTimeOffset.Now.ToUniversalTime();
        /// <summary>
        /// IP адрес сервера
        /// </summary>
        public System.Net.IPAddress AddressMain { set; get; }

        #endregion

        #region  ==========  public function  ==========

        /// <summary>
        /// Создать запись
        /// </summary>
        public RetTriggers() { }

        /// <summary>
        /// Создать и загрузить запись по Id 
        /// </summary>
        /// <param name="Id"></param>
        public RetTriggers(int Id, Models.Servers Srv) { Load(Id, Srv); }

        /// <summary>
        /// Перезагрузить (обновить) данные с текущим ID
        /// </summary>
        [NumFunction(1)]
        public void ReLoad(Models.Servers Srv) { Load(this.Id, Srv); }

        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <param name="iD"></param>
        [NumFunction(2)]
        public void Load(int Id, Models.Servers Srv)
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    _LoadSql(Id, Srv);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    _LoadOdoo(Id, Srv);
                    break;
            }
        }

        /// <summary>
        /// Обновить дату окончания обработки триггера
        /// </summary>
        [NumFunction(10)]
        public void UpdateEnd(Models.Servers Srv, Enums.StTriggers StTask, StatusMessage Status)
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    _UpdateEndSql(Srv, StTask, Status);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    _UpdateEndOdoo(Srv, StTask);
                    break;
            }
        }

        [NumFunction(9)]
        public void UpdateRead(Models.Servers Srv, StatusMessage Status)
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                case TypeServers.PohodaXml:
                    _UpdateReadSql(Srv, Status);
                    break;
                case TypeServers.Odoo:
                case TypeServers.PostgreSQL:
                    _UpdateReadOdoo(Srv);
                    break;
            }
        }

        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <param name="iD"></param>
        [NumFunction(3)]
        private void _LoadSql(int Id, Models.Servers Srv)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, SqlScripts.NameMainBase));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = string.Format("SELECT * FROM {0} WHERE(Id = @Id)", SqlScripts.NameEventTriggersAgent);
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr.Value = Id == 0 ? this.Id : Id;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["Id"];
                    this.IsTask = (Enums.StTriggers)dr["IsTask"];
                    this.DateCreate = (DateTimeOffset)dr["DateCreate"];
                    this.DateTrigger = (DateTimeOffset)dr["DateTrigger"];
                    this.DateClose = (DateTimeOffset)dr["DateClose"];
                    this.GuidTask = dr["GuidTask"].ToString().Trim();
                    string s_ip = dr["AddressMain"] == DBNull.Value ? "" : dr["AddressMain"].ToString().Trim();
                    if (string.IsNullOrWhiteSpace(s_ip)) this.AddressMain = null;
                    else this.AddressMain = System.Net.IPAddress.Parse(dr["AddressMain"].ToString().Trim());
                    this.IdRecord = (int)dr["IdRecord"];
                    this.TriggerAction = dr["ActionTrigger"] == DBNull.Value ? "" : dr["ActionTrigger"].ToString().Trim();
                    this.NameTrigger = dr["NameTrigger"] == DBNull.Value ? "" : dr["NameTrigger"].ToString().Trim();
                    this.NameTable = dr["NameTable"] == DBNull.Value ? "" : dr["NameTable"].ToString().Trim();
                    this.NameBase = dr["NameBase"] == DBNull.Value ? "" : dr["NameBase"].ToString().Trim();
                    this.NameServer = dr["NameServer"] == DBNull.Value ? "" : dr["NameServer"].ToString().Trim();
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }
        /// <summary>
        /// Обновить дату окончания обработки триггера
        /// </summary>
        [NumFunction(4)]
        private void _UpdateEndSql(Models.Servers Srv, Enums.StTriggers StTask, StatusMessage Status)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, SqlScripts.NameMainBase));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = string.Format("UPDATE {0} SET DateClose = @DateClose, IsTask = @IsTask WHERE(Id = @Id)",
                    Status == StatusMessage.Sen ? SqlScripts.NameEventTriggers : SqlScripts.NameEventTriggersAgent);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_DateClose = cm.Parameters.Add("DateClose", System.Data.SqlDbType.DateTimeOffset);
                pr_DateClose.Value = DateTimeOffset.Now.ToUniversalTime();
                System.Data.SqlClient.SqlParameter pr_IsTask = cm.Parameters.Add("IsTask", System.Data.SqlDbType.Int);
                pr_IsTask.Value = (int)StTask;
                cm.ExecuteNonQuery();
                Load(this.Id, Srv);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }
        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <param name="iD"></param>
        [NumFunction(5)]
        private void _LoadOdoo(int Id, Models.Servers Srv)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                OdooScripts os = new OdooScripts();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand();
                cm.Connection = cn;
                cm.CommandText = string.Format("SELECT * FROM {0} WHERE(Id = @Id)", os.scrNameEventTable);
                Npgsql.NpgsqlParameter pr = cm.Parameters.Add("Id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr.Value = Id == 0 ? this.Id : Id;
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["Id"];
                    this.IsTask = (Enums.StTriggers)dr["IsTask"];
                    this.DateCreate = new DateTimeOffset((DateTime)dr["DateCreate"]);
                    this.DateTrigger = new DateTimeOffset((DateTime)dr["DateTrigger"]);
                    this.DateClose = new DateTimeOffset((DateTime)dr["DateClose"]);
                    this.GuidTask = dr["GuidTask"].ToString().Trim();
                    string s_ip = dr["AddressMain"] == DBNull.Value ? "" : dr["AddressMain"].ToString().Trim();
                    if (string.IsNullOrWhiteSpace(s_ip)) this.AddressMain = null;
                    else this.AddressMain = System.Net.IPAddress.Parse(dr["AddressMain"].ToString().Trim());
                    this.IdRecord = (int)dr["IdRecord"];
                    this.TriggerAction = dr["ActionTrigger"] == DBNull.Value ? "" : dr["ActionTrigger"].ToString().Trim();
                    this.NameTrigger = dr["NameTrigger"] == DBNull.Value ? "" : dr["NameTrigger"].ToString().Trim();
                    this.NameTable = dr["NameTable"] == DBNull.Value ? "" : dr["NameTable"].ToString().Trim();
                    this.NameBase = dr["NameBase"] == DBNull.Value ? "" : dr["NameBase"].ToString().Trim();
                    this.NameServer = dr["NameServer"] == DBNull.Value ? "" : dr["NameServer"].ToString().Trim();
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }
        /// <summary>
        /// Обновить дату окончания обработки триггера
        /// </summary>
        [NumFunction(6)]
        private void _UpdateEndOdoo(Models.Servers Srv, Enums.StTriggers StTask)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                OdooScripts os = new OdooScripts();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand();
                cm.Connection = cn;
                cm.CommandText = string.Format("UPDATE {0} SET DateClose = @DateClose, IsTask = @IsTask WHERE(Id = @Id)", os.scrNameEventTable);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("Id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = this.Id;
                Npgsql.NpgsqlParameter pr_DateClose = cm.Parameters.Add("DateClose", NpgsqlTypes.NpgsqlDbType.TimestampTZ);
                pr_DateClose.Value = DateTimeOffset.Now.ToUniversalTime();
                Npgsql.NpgsqlParameter pr_IsTask = cm.Parameters.Add("IsTask", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_IsTask.Value = (int)StTask;
                cm.ExecuteNonQuery();
                Load(this.Id, Srv);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }

        /// <summary>
        /// Обновление после чтения события в SQL
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="StTask"></param>
        [NumFunction(7)]
        private void _UpdateReadSql(Models.Servers Srv, StatusMessage Status)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, SqlScripts.NameMainBase));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = string.Format("UPDATE {0} SET DateClose = @DateClose, DateTrigger = @DateTrigger, IsTask = @IsTask WHERE(Id = @Id)",
                    Status == StatusMessage.Sen ? SqlScripts.NameEventTriggers : SqlScripts.NameEventTriggersAgent);
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_DateTrigger = cm.Parameters.Add("DateTrigger", System.Data.SqlDbType.DateTimeOffset);
                pr_DateTrigger.Value = DateTimeOffset.Now.ToUniversalTime();
                System.Data.SqlClient.SqlParameter pr_DateClose = cm.Parameters.Add("DateClose", System.Data.SqlDbType.DateTimeOffset);
                pr_DateClose.Value = DateTimeOffset.Now.ToUniversalTime();
                System.Data.SqlClient.SqlParameter pr_IsTask = cm.Parameters.Add("IsTask", System.Data.SqlDbType.Int);
                pr_IsTask.Value = (int)Enums.StTriggers.StartTask;
                cm.ExecuteNonQuery();
                Load(this.Id, Srv);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }

        /// <summary>
        /// Обновление после чтения события в postgreSQL
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="StTask"></param>
        [NumFunction(8)]
        private void _UpdateReadOdoo(Models.Servers Srv)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                OdooScripts os = new OdooScripts();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand();
                cm.Connection = cn;
                cm.CommandText = string.Format("UPDATE {0} SET DateClose = @DateClose, DateTrigger = @DateTrigger, IsTask = @IsTask WHERE(Id = @Id)", os.scrNameEventTable);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("Id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = this.Id;
                Npgsql.NpgsqlParameter pr_DateTrigger = cm.Parameters.Add("DateTrigger", NpgsqlTypes.NpgsqlDbType.TimestampTZ);
                pr_DateTrigger.Value = DateTimeOffset.Now.ToUniversalTime();
                Npgsql.NpgsqlParameter pr_DateClose = cm.Parameters.Add("DateClose", NpgsqlTypes.NpgsqlDbType.TimestampTZ);
                pr_DateClose.Value = DateTimeOffset.Now.ToUniversalTime();
                Npgsql.NpgsqlParameter pr_IsTask = cm.Parameters.Add("IsTask", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_IsTask.Value = (int)Enums.StTriggers.StartTask;
                cm.ExecuteNonQuery();
                Load(this.Id, Srv);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }

        #endregion

        #region  ==========  static function  ==========

        /// <summary>
        /// Получить все сообщения с сервера SQL
        /// </summary>
        /// <param name="IsTask">Только определённую группу</param>
        /// <returns></returns>
        public static List<RetTriggers> GetEventTriggersSql(Models.Servers Srv, Enums.StTriggers IsTask = Enums.StTriggers.None)
        {
            List<RetTriggers> li = new List<RetTriggers>();
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, SqlScripts.NameMainBase));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"select COUNT(*) from sys.tables where name = @Name";
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr.Value = SqlScripts.NameEventTriggersAgent;
                int n1 = (int)cm.ExecuteScalar();
                if (n1 == 0)
                {
                    FileEventLog.WriteWarting("No table to 'SQL' " + SqlScripts.NameEventTriggersAgent);
                }
                else
                {
                    if (IsTask != Enums.StTriggers.None)
                    {
                        cm.CommandText = string.Format(@"SELECT Id FROM {0} WHERE (IsTask = @IsTask) ORDER BY DateCreate", SqlScripts.NameEventTriggersAgent);
                        cm.Parameters.Clear();
                        pr = cm.Parameters.Add("IsTask", System.Data.SqlDbType.Int);
                        pr.Value = (int)IsTask;
                    }
                    else
                    {
                        cm.CommandText = string.Format(@"SELECT Id FROM sEventTriggers WHERE ORDER BY DateCreate", SqlScripts.NameEventTriggersAgent);
                    }
                    System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        li.Add(new RetTriggers((int)dr["Id"], Srv));
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { cn?.Close(); }
            return li;
        }

        /// <summary>
        /// Получить все сообщения с сервера Postgre SQL
        /// </summary>
        /// <param name="IsTask">Только определённую группу</param>
        /// <returns></returns>
        public static List<RetTriggers> GetEventTriggersOdoo(Models.Servers Srv, Enums.StTriggers IsTask = Enums.StTriggers.None)
        {
            List<RetTriggers> li = new List<RetTriggers>();
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                OdooScripts os = new OdooScripts();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand() { Connection = cn };
                cm.CommandText = @"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = @Table";
                Npgsql.NpgsqlParameter pr = cm.Parameters.Add("Table", NpgsqlTypes.NpgsqlDbType.Varchar);
                //SqlScripts ss = new SqlScripts();
                pr.Value = os.scrNameEventTable.ToLower();
                //object o1 = cm.ExecuteScalar();
                long n1 = (long)cm.ExecuteScalar();
                if (n1 == 0)
                {
                    FileEventLog.WriteWarting("No table to 'ODOO' " + os.scrNameEventTable);
                }
                else
                {
                    cm = new Npgsql.NpgsqlCommand();
                    cm.Connection = cn;
                    if (IsTask != Enums.StTriggers.None)
                    {
                        cm.CommandText = string.Format(@"SELECT Id FROM res_{0} WHERE (IsTask = @IsTask) ORDER BY DateCreate", SqlScripts.NameEventTriggersAgent);
                        pr = cm.Parameters.Add("IsTask", NpgsqlTypes.NpgsqlDbType.Integer);
                        pr.Value = (int)IsTask;
                    }
                    else
                    {
                        cm.CommandText = string.Format(@"SELECT Id FROM res_{0} WHERE ORDER BY DateCreate", SqlScripts.NameEventTriggersAgent);
                    }
                    Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        li.Add(new RetTriggers((int)dr["Id"], Srv));
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { cn?.Close(); }
            return li;
        }

        #endregion
    }
}
