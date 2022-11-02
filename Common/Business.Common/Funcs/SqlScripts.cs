using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [NumClass(4)]
    public class SqlScripts
    {
        #region  ==========  Свойства  ==========

        public static ulong NumTask { set; get; } = 0;

        /// <summary>
        /// Имя SQL сервера
        /// </summary>
        public static string NameMainSql { set; get; } = "SQL";

        /// <summary>
        /// Служебная база содержащая логи и служебную информацию
        /// </summary>
        public static string NameMainBase { set; get; } = "ASynchro";

        /// <summary>
        /// Имя юзера подключения в служебной базе. Берётся из настроик сервера
        /// </summary>
        public static string UserSqlMain { set; get; } = "User";

        /// <summary>
        /// Пароль подключения в служебной базе. Берётся из настроик сервера
        /// </summary>
        public static string PasswordSqlMain { set; get; } = "Password";

        /// <summary>
        /// Изменилось значение или нет
        /// </summary>
        public static bool IsSave { set; get; } = false;

        /// <summary>
        /// Внешний IP-address сервера
        /// </summary>
        public static string MainIPSql { set; get; } = "";

        /// <summary>
        /// Порт основного сервера
        /// </summary>
        public static int Port { set; get; }

        /// <summary>
        /// Имя основного пространства имён соединения с сервером
        /// </summary>
        public static string NameScope { set; get; } = "";

        /// <summary>
        /// Имя пользователя для изменений в SQL
        /// </summary>
        public static string NameUserUcetni { set; get; } = "SY";
        /// <summary>
        /// Имя пользователя для создания в SQL
        /// </summary>
        public static string NameUserCreator { set; get; } = "SY";
        /// <summary>
        /// Для поля POZN
        /// </summary>
        public static string SynchPozn { set; get; } = "Synchronisation";

        #endregion

        #region  ==========  статические функции  ==========

        #region  ==========  Получить строку соединения  ==========

        /// <summary>
        /// Получить подключение к SQL и служебной базе ASynchro
        /// </summary>
        /// <returns></returns>
        [NumFunction(1)]
        public static string GetConnectSQLMain()
        {
            return GetConnectSQL(NameMainSql, UserSqlMain, PasswordSqlMain, NameMainBase);
        }

        /// <summary>
        /// Получить подключение к SQL без базы
        /// </summary>
        /// <param name="NameBase">Если null, то подключение к самому SQL серверу</param>
        /// <returns></returns>
        [NumFunction(2)]
        public static string GetConnectSQLMainNull()
        {
            return GetConnectSQL(NameMainSql, UserSqlMain, PasswordSqlMain);
        }

        /// <summary>
        /// Получить подключение к SQL и базе
        /// </summary>
        /// <param name="infSer">Информация о сервере подключения</param>
        /// <returns></returns>
        [NumFunction(3)]
        public static string GetConnectSQL(Models.Servers infSer, string Base)
        {
            if (infSer.Type == TypeServers.MsSql)
            {
                return GetConnectSQL(infSer.SqlHostIp, infSer.SqlUser, infSer.SqlPassword, Base);
            }
            else if (infSer.Type == TypeServers.PohodaXml)
            {
                return GetConnectSQL(infSer.PohodaSqlHostIp, infSer.PohodaSqlUser, infSer.PohodaSqlPassword, Base);
            }
            else return "";
        }

        /// <summary>
        /// Получить подключение к SQL к указанной базе - общая финкция
        /// </summary>
        /// <param name="Sql">SQL сервер</param>
        /// <param name="NameBase">База или null</param>
        /// <param name="User">Логин</param>
        /// <param name="Pass">Пароль</param>
        /// <returns></returns>
        [NumFunction(4)]
        public static string GetConnectSQL(string Sql, string User, string Pass, string NameBase = null)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder();
            sb.DataSource = Sql;
            if (!string.IsNullOrWhiteSpace(NameBase))
            {
                sb.InitialCatalog = NameBase;
            }
            sb.UserID = User;
            sb.Password = Pass;
            sb.MultiSubnetFailover = true;
            sb.IntegratedSecurity = false;
            return sb.ConnectionString;
        }

        #endregion

        #endregion

        #region  ==========  Функции проверки и создания  ==========

        /// <summary>
        /// Проверка и создание на MAIN-server: базы, таблиц, сборки(assembler) и триггера CLR
        /// </summary>
        /// <returns></returns>
        [NumFunction(5)]
        public bool CheckOrCreateTable()
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMainNull());
                cn.Open();
                if (!CheckConnectSqlBase(SqlScripts.NameMainBase, cn))
                {
                    CreateBase(cn);
                }
                cn.Close();
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                if (!CheckTable(NameLogMessage, cn))
                {
                    CreateTableLogMessage(cn);
                }
                if (!CheckTable(NameServer, cn))
                {
                    CreateTableServer(cn);
                }
                if (!CheckTable(NameTask, cn))
                {
                    CreateTableTask(cn);
                    Models.Task tsk = new Models.Task();
                    tsk.IdParent = 0;
                    tsk.Name = "Scheduled Tasks";
                    tsk.Id = 1;
                    tsk.ServerSource = new Models.Servers();
                    tsk.ServerReceiver = new Models.Servers();
                    tsk.Message = "Scheduled Tasks";
                    tsk.CreateId();
                    tsk.Id = 2;
                    tsk.Name = "Trigger tasks";
                    tsk.Message = "Trigger tasks";
                    tsk.CreateId();
                }
                if (!CheckTable(NameTasksLog, cn))
                {
                    CreateTableTasksLog(cn);
                }
                //  Проверка наличия, создание и перезапись сборки (Assembler) и триггера CLR
                Models.SQLTriggers sql_Tr = new Models.SQLTriggers(SqlScripts.NameMainBase);
                sql_Tr.CreateOrUpdate();
                b1 = true;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }

        /// <summary>
        /// Проверка и создание на агентах: базы, таблицы 
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(14)]
        public bool CheckOrCreateTableAgent(Models.Servers srv)
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, null));
                cn.Open();
                if (!CheckConnectSqlBase(SqlScripts.NameMainBase, cn))
                {
                    CreateBase(cn);
                }
                cn.Close();
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, NameMainBase));
                cn.Open();
                Models.SQLTriggers sql_Tr = new Models.SQLTriggers(SqlScripts.NameMainBase);
                sql_Tr.CreateOrUpdateAgent(cn);
                b1 = true;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }

        /// <summary>
        /// Проверка подключения и наличия базы в SQL
        /// </summary>
        /// <param name="str_connect">Строка подключения к серверу</param>
        /// <param name="NameBase">База для проверки</param>
        /// <returns></returns>
        [NumFunction(6)]
        public bool CheckConnectSqlBase(string NameBase, System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            bool b2 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(GetConnectSQLMainNull());
                    cn.Open();
                    b2 = true;
                }
                string s1 = @"select COUNT(*) from sys.databases where name = @Base";
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand(s1, cn);
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Base", System.Data.SqlDbType.VarChar);
                pr.Value = NameBase;
                int m1 = (int)cm.ExecuteScalar();
                b1 = m1 == 1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { if(b2) cn?.Close(); }
            return b1;
        }

        /// <summary>
        /// Проверка наличия таблицы в базе данных
        /// </summary>
        /// <param name="NameBasa">Имя базы данных</param>
        /// <param name="NameTable">Имя проверяемой таблицы</param>
        /// <returns>True - таблица сушествует</returns>
        [NumFunction(7)]
        public bool CheckTable(string NameTable, System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b = false;
            bool b2 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b2 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = @"select COUNT(*) from sys.tables where name = @Name";
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr.Value = NameTable;
                int n1 = (int)cm.ExecuteScalar();
                b = n1 == 1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if (b2) cn?.Close();
            }
            return b;
        }

        #region  ==========  Создание базы ASynchro  ==========

        [NumFunction(8)]
        public void CreateBase(System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b1 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = ScriptCreateBase
                };
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if(b1) cn?.Close();
            }
        }
        private string ScriptCreateBase = @"CREATE DATABASE [" + NameMainBase + "]";

        #endregion

        #region  ==========  Создание таблицы sLogMessage в базе ASynchro  ==========

        [NumFunction(9)]
        public void CreateTableLogMessage(System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b1 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = ScriptCreateTablesLogMessage
                };
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if(b1) cn?.Close();
            }
        }
        private string NameLogMessage = "sLogMessage";
        private string ScriptCreateTablesLogMessage = @"
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[sLogMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](max) NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[Host] [varchar](max) NULL,
	[IPHost] [varchar](max) NULL,
	[Status] [int] NOT NULL,
	[Func] [varchar](max) NULL,
	[Rw] [int] NOT NULL,
	[Cl] [int] NOT NULL,
	[Cs] [int] NOT NULL,
	[Fn] [int] NOT NULL,
	[Nu] [int] NOT NULL,
	[ChainOfFunctions] [varchar](max) NULL,
	[DateCreate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_sLogMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_Status]  DEFAULT ((0)) FOR [Status]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_Rw]  DEFAULT ((0)) FOR [Rw]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_Cl]  DEFAULT ((0)) FOR [Cl]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_Cs]  DEFAULT ((0)) FOR [Cs]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_Fn]  DEFAULT ((0)) FOR [Fn]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_Nu]  DEFAULT ((0)) FOR [Nu]
ALTER TABLE [dbo].[sLogMessage] ADD  CONSTRAINT [DF_sLogMessage_DateCreate]  DEFAULT (getutcdate()) FOR [DateCreate]
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'тип сообщения No = 0, Ok = 1, Wa = 2, Er = 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sLogMessage', @level2type=N'COLUMN',@level2name=N'Status'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата создания' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sLogMessage', @level2type=N'COLUMN',@level2name=N'DateCreate'
";

        #endregion

        #region  ==========  Создание таблицы sServer в базе ASynchro  ==========

        [NumFunction(10)]
        public void CreateTableServer(System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b1 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = ScriptCreateTablesServer
                };
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if(b1) cn?.Close();
            }
        }
        private string NameServer = "sServers";
        private string ScriptCreateTablesServer = @"
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[sServers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[TypeServer] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[IsRemote] [bit] NOT NULL,
	[PublicPath] [varchar](max) NULL,
	[Remark] [varchar](max) NULL,
	[DopClass] [varbinary](max) NULL,
 CONSTRAINT [PK_sServers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [dbo].[sServers] ADD  CONSTRAINT [DF_sServers_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
ALTER TABLE [dbo].[sServers] ADD  CONSTRAINT [DF_sServers_IsRemote]  DEFAULT ((0)) FOR [IsRemote]

SET ANSI_PADDING ON
CREATE UNIQUE NONCLUSTERED INDEX [Ind_Name] ON [dbo].[sServers]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
";

        #endregion

        #region  ==========  Создание таблицы sTask в базе ASynchro  ==========

        [NumFunction(11)]
        public void CreateTableTask(System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b1 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = ScriptCreateTablesTask
                };
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if(b1) cn?.Close();
            }
        }
        private string NameTask = "sTasks";
        private string ScriptCreateTablesTask = @"
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[sTasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdParent] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ServerSource] [int] NOT NULL,
	[ServerReceiver] [int] NOT NULL,
	[IsRun] [bit] NOT NULL,
	[IsTrigers] [int] NOT NULL,
	[IsWorks] [bit] NOT NULL,
	[IsError] [bit] NOT NULL,
	[DateRun] [datetimeoffset](7) NOT NULL,
	[Message] [varchar](max) NULL,
	[Param] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_sTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [dbo].[sTasks] ADD  CONSTRAINT [DF_sTasks_ServerSource]  DEFAULT ((0)) FOR [ServerSource]
ALTER TABLE [dbo].[sTasks] ADD  CONSTRAINT [DF_sTasks_ServerReceiver]  DEFAULT ((0)) FOR [ServerReceiver]
ALTER TABLE [dbo].[sTasks] ADD  CONSTRAINT [DF_sTasks_IsRun]  DEFAULT ((0)) FOR [IsRun]
ALTER TABLE [dbo].[sTasks] ADD  CONSTRAINT [DF_sTasks_IsTrigers]  DEFAULT ((0)) FOR [IsTrigers]
ALTER TABLE [dbo].[sTasks] ADD  CONSTRAINT [DF_sTasks_IsWorks]  DEFAULT ((0)) FOR [IsWorks]
ALTER TABLE [dbo].[sTasks] ADD  CONSTRAINT [DF_sTasks_DateRun]  DEFAULT (getutcdate()) FOR [DateRun]

SET ANSI_PADDING ON
CREATE UNIQUE NONCLUSTERED INDEX [Ind_Name] ON [dbo].[sTasks]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

";

        #endregion

        #region  ==========  Создание таблицы sTasksLog в базе ASynchro  ==========

        [NumFunction(12)]
        public void CreateTableTasksLog(System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b1 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = ScriptCreateTablesTasksLog
                };
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if(b1) cn?.Close();
            }
        }
        private string NameTasksLog = "sTasksLog";
        private string ScriptCreateTablesTasksLog = @"
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[sTasksLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTask] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[Date] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_sTasksLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [dbo].[sTasksLog] ADD  CONSTRAINT [DF_sTasksLog_Status]  DEFAULT ((0)) FOR [Status]
ALTER TABLE [dbo].[sTasksLog] ADD  CONSTRAINT [DF_sTasksLog_Date]  DEFAULT (getutcdate()) FOR [Date]
ALTER TABLE [dbo].[sTasksLog]  WITH CHECK ADD  CONSTRAINT [FK_sTasksLog_sTasks] FOREIGN KEY([IdTask])
REFERENCES [dbo].[sTasks] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[sTasksLog] CHECK CONSTRAINT [FK_sTasksLog_sTasks]
";

        #endregion

        #region  ==========  Создание таблицы EventTriggers в базе ASynchro  ==========

        [NumFunction(13)]
        public void CreateTableEventTriggers(string Name, System.Data.SqlClient.SqlConnection cn = null)
        {
            bool b1 = false;
            try
            {
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    b1 = true;
                }
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(ScriptCreateTablesEventTriggers, Name)
                };
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if(b1) cn?.Close();
            }
        }
        public static readonly string NameEventTriggers = "sEventTriggers";
        public static readonly string NameEventTriggersAgent = "sEventTriggersAgent";
        private string ScriptCreateTablesEventTriggers = @"
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[{0}](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsTask] [int] NOT NULL,
	[DateCreate] [datetimeoffset](7) NOT NULL,
	[DateTrigger] [datetimeoffset](7) NOT NULL,
	[DateClose] [datetimeoffset](7) NOT NULL,
	[GuidTask] [varchar](100) NOT NULL,
	[AddressMain] [nchar](100) NOT NULL,
	[IdRecord] [int] NOT NULL,
	[ActionTrigger] [varchar](2) NOT NULL,
	[NameTrigger] [varchar](100) NOT NULL,
	[NameTable] [varchar](100) NOT NULL,
	[NameBase] [varchar](100) NOT NULL,
	[NameServer] [varchar](100) NOT NULL,
 CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [DF_{0}_IsTask]  DEFAULT ((0)) FOR [IsTask]
ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [DF_{0}_Create]  DEFAULT (getutcdate()) FOR [DateCreate]
ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [DF_{0}_DateTrigger]  DEFAULT (getutcdate()) FOR [DateTrigger]
ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [DF_{0}_DateCloce]  DEFAULT (getutcdate()) FOR [DateClose]
ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [DF_{0}_IdRecord]  DEFAULT ((0)) FOR [IdRecord]
";

        #endregion

        #endregion

    }
}
