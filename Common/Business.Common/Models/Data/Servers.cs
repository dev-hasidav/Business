using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    [Serializable]
    [NumClass(5)]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Name: {Name}, Type:{Type}, IsEn: {IsEnable}, IsRem: {IsRemote}")]
    public class Servers
    {
        #region  ==========  Constructors  ==========

        /// <summary>
        /// Создать пустой класс
        /// </summary>
        public Servers() { }
        /// <summary>
        /// Создать и загрузить класс с указанным Id
        /// </summary>
        /// <param name="Id"></param>
        public Servers(int Id)
        {
            Load(Id);
        }
        /// <summary>
        /// Создать и загрузить класс с указанным Name
        /// </summary>
        /// <param name="Name"></param>
        public Servers(string Name)
        {
            Load(Name);
        }

        #endregion

        #region  ==========  Property  ==========

        #region  ==========  Общие
        public int Id { set; get; }
        public string Name { set; get; }
        public TypeServers Type { set; get; } = TypeServers.None;
        public string PublicPath { set; get; }
        public bool IsEnable { set; get; }
        public bool IsRemote { set; get; }
        public string Remark { set; get; }
        private ServerDop Params { set; get; } = new ServerDop();
        public System.Drawing.Image StatusImage { set; get; }
        #endregion

        #region  ==========  SQL
        public string SqlHostIp { set { Params.Sql.NameServerOrIp = value; } get { return Params.Sql.NameServerOrIp; } }
        public int SqlPort { set { Params.Sql.Port = value; } get { return Params.Sql.Port; } }
        public string SqlUser { set { Params.Sql.User = value; } get { return Params.Sql.User; } }
        public string SqlPassword { set { Params.Sql.Password = value; } get { return Params.Sql.Password; } }
		public string SqlDataSource { get; set; }
		#endregion

		#region  ==========  Rem
		public string RemHostIp { set { Params.Rem.NameServerOrIp = value; } get { return Params.Rem.NameServerOrIp; } }
        public int RemPort { set { Params.Rem.Port = value; } get { return Params.Rem.Port; } }
        #endregion

        #region  ==========  Pohoda
        public string PohodaPath { set { Params.Pohoda.PathExe = value; } get { return Params.Pohoda.PathExe; } }
        public string PohodaUser { set { Params.Pohoda.Login = value; } get { return Params.Pohoda.Login; } }
        public string PohodaPassword { set { Params.Pohoda.Password = value; } get { return Params.Pohoda.Password; } }
        public string PohodaSqlHostIp { set { Params.Sql.NameServerOrIp = value; } get { return Params.Sql.NameServerOrIp; } }
        public int PohodaSqlPort { set { Params.Sql.Port = value; } get { return Params.Sql.Port; } }
        public string PohodaSqlUser { set { Params.Sql.User = value; } get { return Params.Sql.User; } }
        public string PohodaSqlPassword { set { Params.Sql.Password = value; } get { return Params.Sql.Password; } }
        #endregion

        #region  ==========  Odoo
        public string OdooHostIp { set { Params.Odoo.NameServerOrIp = value; } get { return Params.Odoo.NameServerOrIp; } }
        public int OdooPort { set { Params.Odoo.Port = value; } get { return Params.Odoo.Port; } }
        public string OdooUser { set { Params.Odoo.User = value; } get { return Params.Odoo.User; } }
        public string OdooBase { set { Params.Odoo.Base = value; } get { return Params.Odoo.Base; } }
        public string OdooPassword { set { Params.Odoo.Password = value; } get { return Params.Odoo.Password; } }
        public string OdooSqlHostIp { set { Params.Postgre.NameServerOrIp = value; } get { return Params.Postgre.NameServerOrIp; } }
        public int OdooSqlPort { set { Params.Postgre.Port = value; } get { return Params.Postgre.Port; } }
        public string OdooSqlUser { set { Params.Postgre.User = value; } get { return Params.Postgre.User; } }
        public string OdooSqlPassword { set { Params.Postgre.Password = value; } get { return Params.Postgre.Password; } }
        public string OdooSqlBase { set { Params.Postgre.Base = value; } get { return Params.Postgre.Base; } }
        #endregion

        #region  ==========  Postgre
        public string PostgreHostIp { set { Params.Postgre.NameServerOrIp = value; } get { return Params.Postgre.NameServerOrIp; } }
        public int PostgrePort { set { Params.Postgre.Port = value; } get { return Params.Postgre.Port; } }
        public string PostgreUser { set { Params.Postgre.User = value; } get { return Params.Postgre.User; } }
        public string PostgrePassword { set { Params.Postgre.Password = value; } get { return Params.Postgre.Password; } }
        public string PostgreBase { set { Params.Postgre.Base = value; } get { return Params.Postgre.Base; } }
        public bool PostgreIntegratedSecurity { set { Params.Postgre.IntegratedSecurity = value; } get { return Params.Postgre.IntegratedSecurity; } }
        public bool PostgreUseSslStream { set { Params.Postgre.UseSslStream = value; } get { return Params.Postgre.UseSslStream; } }
        #endregion

        #endregion

        #region  ==========  Function  ==========

        /// <summary>
        /// Использует Id свойства класса для загрузки (перезагрузки) свойств
        /// </summary>
        /// <returns></returns>
        [NumFunction(1)]
        public Servers Load()
        {
            return Load(0, null);
        }
        /// <summary>
        /// Загружает запись с указанным Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public Servers Load(int Id)
        {
            return Load(Id, null);
        }
        /// <summary>
        /// Загружает запись с указанным именем
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [NumFunction(3)]
        public Servers Load(string Name)
        {
            return Load(0, Name);
        }
        /// <summary>
        /// Общая процедура загрузки
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        [NumFunction(4)]
        private Servers Load(int Id, string Name)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT * FROM sServers ORDER BY [Name]";
                if (Id != 0)
                {
                    cm.CommandText = @"SELECT * FROM sServers WHERE (Id = @Id) ORDER BY [Name]";
                    System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                    pr.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = @"SELECT * FROM sServers WHERE ([Name] = @Name) ORDER BY [Name]";
                    System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                    pr.Value = Name;
                }
                else
                {
                    cm.CommandText = @"SELECT * FROM sServers WHERE (Id = @Id) ORDER BY [Name]";
                    System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                    pr.Value = this.Id;
                }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["Id"];
                    this.Name = dr["Name"].ToString();
                    this.Type = (TypeServers)dr["TypeServer"];
                    this.IsEnable = (bool)dr["IsEnable"];
                    this.IsRemote = (bool)dr["IsRemote"];
                    this.PublicPath = dr["PublicPath"] == DBNull.Value ? "" : dr["PublicPath"].ToString();
                    this.Remark = dr["Remark"] == DBNull.Value ? "" : dr["Remark"].ToString();
                    byte[] bb = (byte[])dr["DopClass"];
                    this.Params = (ServerDop)Funcs.Conver.ConverByteToClass(bb, typeof(ServerDop));
                }
                else
                {
                    this.Id = Id;
                    this.Name = Name;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Создать новую запись в базе
        /// </summary>
        /// <returns></returns>
        [NumFunction(5)]
        public Servers Create()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"INSERT INTO sServers " +
                    @"(Name, TypeServer, IsEnable, IsRemote, PublicPath, Remark, DopClass) " +
                    @" VALUES (@Name, @TypeServer, @IsEnable, @IsRemote, @PublicPath, @Remark, @DopClass)" +
                    @" ;SELECT Id FROM sServers WHERE (Id = SCOPE_IDENTITY())";
                System.Data.SqlClient.SqlParameter pr_Name = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr_Name.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_TypeServer = cm.Parameters.Add("TypeServer", System.Data.SqlDbType.Int);
                pr_TypeServer.Value = (int)this.Type;
                System.Data.SqlClient.SqlParameter pr_IsEnable = cm.Parameters.Add("IsEnable", System.Data.SqlDbType.Bit);
                pr_IsEnable.Value = this.IsEnable;
                System.Data.SqlClient.SqlParameter pr_IsRemote = cm.Parameters.Add("IsRemote", System.Data.SqlDbType.Bit);
                pr_IsRemote.Value = this.IsRemote;
                System.Data.SqlClient.SqlParameter pr_PublicPath = cm.Parameters.Add("PublicPath", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.PublicPath)) pr_PublicPath.Value = DBNull.Value;
                else pr_PublicPath.Value = this.PublicPath;
                System.Data.SqlClient.SqlParameter pr_Remark = cm.Parameters.Add("Remark", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Remark)) pr_Remark.Value = DBNull.Value;
                else pr_Remark.Value = this.Remark;
                System.Data.SqlClient.SqlParameter pr_sServers = cm.Parameters.Add("DopClass", System.Data.SqlDbType.VarBinary);
                pr_sServers.Value = Funcs.Conver.ConverClassToByte(this.Params);
                int n1 = (int)cm.ExecuteScalar();
                Load(n1);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Изменить существующую запись 
        /// </summary>
        /// <returns></returns>
        [NumFunction(6)]
        public Servers Update()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"UPDATE sServers " +
                    @" SET Name = @Name, TypeServer = @TypeServer, IsEnable = @IsEnable, IsRemote = @IsRemote, " +
                    @" PublicPath = @PublicPath, Remark = @Remark, DopClass = @DopClass" +
                    @" WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_Name = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr_Name.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_TypeServer = cm.Parameters.Add("TypeServer", System.Data.SqlDbType.Int);
                pr_TypeServer.Value = (int)this.Type;
                System.Data.SqlClient.SqlParameter pr_IsEnable = cm.Parameters.Add("IsEnable", System.Data.SqlDbType.Bit);
                pr_IsEnable.Value = this.IsEnable;
                System.Data.SqlClient.SqlParameter pr_IsRemote = cm.Parameters.Add("IsRemote", System.Data.SqlDbType.Bit);
                pr_IsRemote.Value = this.IsRemote;
                System.Data.SqlClient.SqlParameter pr_PublicPath = cm.Parameters.Add("PublicPath", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.PublicPath)) pr_PublicPath.Value = DBNull.Value;
                else pr_PublicPath.Value = this.PublicPath;
                System.Data.SqlClient.SqlParameter pr_Remark = cm.Parameters.Add("Remark", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Remark)) pr_Remark.Value = DBNull.Value;
                else pr_Remark.Value = this.Remark;
                System.Data.SqlClient.SqlParameter pr_sServers = cm.Parameters.Add("DopClass", System.Data.SqlDbType.VarBinary);
                pr_sServers.Value = Funcs.Conver.ConverClassToByte(this.Params);
                cm.ExecuteNonQuery();
                Load();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Удалить существующую запись 
        /// </summary>
        /// <returns></returns>
        [NumFunction(7)]
        public Servers Delete()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"DELETE FROM sServers WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
                this.Name = "";
                this.Params = new ServerDop();
                this.PublicPath = "";
                this.Remark = "";
                this.Type = TypeServers.None;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return this;
        }

        #endregion

        #region  ==========  Дополнительные функции внутри класса  ==========
        public string GetSqlConnectionString()
        {
            return $"Data Source={SqlHostIp};Initial Catalog={SqlDataSource};User ID={SqlUser};Password={SqlPassword}";
        }
        #endregion

        #region  ==========  Static Function  ==========

        /// <summary>
        /// Список всех записей серверов в базе
        /// </summary>
        /// <param name="IsEnable">True - только включённых</param>
        /// <returns></returns>
        [NumFunction(40)]
        public static List<Servers> GetServers(bool IsEnable = false)
        {
            List<Servers> li = new List<Servers>();
            System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
            cn.Open();
            System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
            cm.Connection = cn;
            if (IsEnable)
            {
                cm.CommandText = @"SELECT Id FROM sServers WHERE IsEnable = @IsEnable  ORDER BY Name";
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("IsEnable", System.Data.SqlDbType.Bit);
                pr.Value = true;
            }
            else
            {
                cm.CommandText = @"SELECT Id FROM sServers ORDER BY Name";
            }
            System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                li.Add(new Servers((int)dr["Id"]));
            }
            return li;
        }
        #endregion
    }

    [Serializable]
    [NumClass(21)]
    public class ServerDop
    {
        public InfoSql Sql { set; get; } = new InfoSql();
        public InfoPohoda Pohoda { set; get; } = new InfoPohoda();
        public InfoRem Rem { set; get; } = new InfoRem();
        public InfoOdoo Odoo { set; get; } = new InfoOdoo();
        public InfoPostgre Postgre { set; get; } = new InfoPostgre();
    }
}
