using Business.Atributes;
using System;

namespace Business.Models
{
    [NumClass(29)]
    public class SQLTriggers
    {

        private readonly string NameBase = "ASynchro";
        private readonly string NameAssembly = "CLRTaskSynchro";
        private readonly string NameFile = "PlaginSql.dll";
        private readonly string NameClass = "MyTriggers";
        private readonly string NameFunction = "EventTablePohoda";
        private readonly string NameTable = "sEventTriggers";
        private readonly string NameTrigerClr = "TrgClr_TaskSynchro";
        /// <summary>
        /// format Trg_TABLE_GUID
        /// </summary>
        private readonly string NameTrigerDml = "Trg_{0}_{1}";  //  

        public SQLTriggers() { }
        public SQLTriggers(string Base)
        {
            NameBase = Base;
        }

        /// <summary>
        /// Проверка и установка - базы, таблицы и сборки
        /// </summary>
        /// <param name="cn"></param>
        [NumFunction(1)]
        public void CreateOrUpdate(System.Data.SqlClient.SqlConnection cn = null)
        {
            bool IsConn = false;
            System.IO.FileStream fs = null;
            try
            {
                FileEventLog.WriteOk(this, "Начало проверки сборки", System.Reflection.MethodInfo.GetCurrentMethod());
                if (cn == null)
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                    cn.Open();
                    IsConn = true;
                }
                SqlScripts ss = new SqlScripts();
                //  Проверка базы
                if (!ss.CheckConnectSqlBase(SqlScripts.NameMainBase, cn))
                {
                    ss.CreateBase(cn);
                }
                //  Проверка таблицы
                if (!ss.CheckTable(SqlScripts.NameEventTriggers, cn))
                {
                    ss.CreateTableEventTriggers(SqlScripts.NameEventTriggers, cn );
                }
                //  Загрузка настроек тригера
                string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                s1 = System.IO.Path.GetDirectoryName(s1);
                System.IO.FileInfo fi_prop = new System.IO.FileInfo(s1 + @"\srvtrg.oml");
                TrigersProp tt = new TrigersProp();
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(TrigersProp));
                if (fi_prop.Exists)
                {
                    fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    tt = (TrigersProp)xs.Deserialize(fs);
                    fs.Close();
                }
                //System.Threading.Thread.Sleep(30 * 1000);
                //  Проверка сборки
                System.IO.FileInfo fi_ass = new System.IO.FileInfo(s1 + @"\" + NameFile);
                if (fi_ass.Exists)
                {
                    if (GetAssembly(cn) == 0)
                    {
                        //  Сборка отсуствует
                        SetAssembly(cn, fi_ass.FullName);
                        FileEventLog.WriteOk(this, string.Format("New assembly '{0}' installed", NameAssembly),
                            System.Reflection.MethodInfo.GetCurrentMethod());
                    }
                    else if (fi_ass.LastWriteTime.CompareTo(tt.DateCreateCrl) > 0)
                    {
                        //  Сборка есть но дата не соответствует
                        if (UpdateAssembly(cn, fi_ass.FullName))
                        {
                            FileEventLog.WriteOk(this, string.Format("Assembly '{0}' changed", NameAssembly),
                                System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                        else
                        {
                            FileEventLog.WriteWarting(this, string.Format("Assembly '{0}' попытка перезаписи.", NameAssembly),
                                System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                    }
                    else
                    {
                        //  сборка не изменилась
                        FileEventLog.WriteOk(this, string.Format("Assembly '{0}' not changed", NameAssembly),
                            System.Reflection.MethodInfo.GetCurrentMethod());
                    }
                    //  меняем дату и перезаписываем
                    tt.DateCreateCrl = fi_ass.LastWriteTime;
                    fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    xs.Serialize(fs, tt);
                    fs.Close();
                    //  вычисляем хеш тригера
                    System.Security.Cryptography.SHA512 sha = System.Security.Cryptography.SHA512.Create();
                    byte[] bb = System.Text.Encoding.Default.GetBytes(strTriggersClr());
                    byte[] bb_sha = sha.ComputeHash(bb);
                    //  проверяем тригер
                    if (GetTrigger(cn) == 0)
                    {
                        //  тригер отсутсвует в базе
                        SetTrigger(cn);
                        FileEventLog.WriteOk(this, string.Format("New trigger '{0}' installed", NameTrigerClr),
                            System.Reflection.MethodInfo.GetCurrentMethod());
                    }
                    else
                    {
                        //  получаем хеш тригера для проверки на изменение
                        bool IsE = true;
                        if (tt.CreateCrl.Length == bb_sha.Length)
                        {
                            for (int n1 = 0; n1 < bb_sha.Length; n1++)
                            {
                                if (bb_sha[n1] == tt.CreateCrl[n1]) continue;
                                IsE = false;
                                break;
                            }
                        }
                        else IsE = false;
                        if (IsE)
                        {
                            //  хеш равен, перезапись тригера не производится
                            FileEventLog.WriteOk(this, string.Format("Trigger '{0}' not changed", NameTrigerClr),
                               System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                        else
                        {
                            //  хеш НЕ равен и производим перезапись тригера
                            UpdateTrigger(cn);
                            FileEventLog.WriteOk(this, string.Format("Trigger '{0}' changed", NameTrigerClr),
                                System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                    }
                    //  меняем дату и перезаписываем
                    tt.CreateCrl = bb_sha;
                    fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    xs.Serialize(fs, tt);
                    fs.Close();
                }
                else
                {
                    throw new Exception("Assembly file not found");
                }
                FileEventLog.WriteOk(this, "Проверка сборки и тригера закончилась", System.Reflection.MethodInfo.GetCurrentMethod());
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { if (IsConn) { cn?.Close(); } fs?.Close(); }
        }

        [NumFunction(14)]
        public void CreateOrUpdateAgent(System.Data.SqlClient.SqlConnection cn)
        {
            try
            {
                SqlScripts ss = new SqlScripts();
                //  Проверка базы
                if (!ss.CheckConnectSqlBase(SqlScripts.NameMainBase, cn))
                {
                    FileEventLog.WriteOk(this, "Создание базы", System.Reflection.MethodInfo.GetCurrentMethod());
                    ss.CreateBase(cn);
                }
                //  Проверка таблицы
                if (!ss.CheckTable(SqlScripts.NameEventTriggersAgent, cn))
                {
                    FileEventLog.WriteOk(this, "Создание таблицы", System.Reflection.MethodInfo.GetCurrentMethod());
                    ss.CreateTableEventTriggers(SqlScripts.NameEventTriggersAgent, cn);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { }
        }


        #region  ==========  Assembly  ==========

        /// <summary>
        /// Проверка надичие сборки. 0 - отсуствие сборки в базе
        /// </summary>
        /// <param name="infSer"></param>
        [NumFunction(2)]
        public int GetAssembly(System.Data.SqlClient.SqlConnection cn)
        {
            int rez = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    CommandText = @"select count(*) from sys.assemblies where [name] = @Name",
                    Connection = cn
                };
                System.Data.SqlClient.SqlParameter pr_Name = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr_Name.Value = NameAssembly;
                rez = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return rez;
        }

        /// <summary>
        /// Проверка надичие сборки
        /// </summary>
        /// <param name="infSer"></param>
        [NumFunction(3)]
        public void SetAssembly(System.Data.SqlClient.SqlConnection cn, string FullName)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = CreateAssemblys(FullName, NameBase, SqlScripts.UserSqlMain);
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(4)]
        public bool UpdateAssembly(System.Data.SqlClient.SqlConnection cn, string FullName)
        {
            bool b1 = false;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = AlterAssemblys(FullName, NameBase);
                cm.ExecuteNonQuery();
                b1 = true;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                //throw e1;
            }
            finally
            {
            }
            return b1;
        }

        /// <summary>
        /// Проверка надичие сборки. False - отсуствие сборки в базе
        /// </summary>
        /// <param name="infSer"></param>
        [NumFunction(5)]
        public int DeleteAssembly(System.Data.SqlClient.SqlConnection cn)
        {
            int rez = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    CommandText = string.Format(@"DROP ASSEMBLY {0}", NameAssembly),
                    Connection = cn
                };
                rez = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return rez;
        }

        private string CreateAssemblys(string FullName, string NameBase, string Login)
        {
            string rez = string.Format(@"ALTER DATABASE [{2}] SET TRUSTWORTHY ON; " +
                @" ALTER AUTHORIZATION ON DATABASE::{2} TO {3}; " +
                @" EXEC sp_configure 'clr enabled', 1; " +
                @" CREATE ASSEMBLY {0} FROM {1} " +
                @" WITH PERMISSION_SET = EXTERNAL_ACCESS;",
                NameAssembly, ConvectFileToByte(FullName), NameBase, Login);

            ;
            return rez;
        }
        private string AlterAssemblys(string FullName, string NameBase)
        {
            string rez = string.Format(@"ALTER DATABASE [{2}] SET TRUSTWORTHY ON; " +
                @" EXEC sp_configure 'clr enabled', 1; " +
                @" ALTER ASSEMBLY {0} FROM {1}; ",
                NameAssembly, ConvectFileToByte(FullName), NameBase);

            return rez;
        }
        private string ConvectFileToByte(string FullName)
        {
            string s2 = "0x";
            System.IO.FileStream fs = null;
            System.IO.BufferedStream bs = null;
            System.IO.BinaryReader br = null;
            System.IO.FileInfo fi = new System.IO.FileInfo(FullName);
            if (fi.Exists)
            {
                fs = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                bs = new System.IO.BufferedStream(fs);
                br = new System.IO.BinaryReader(bs);
                byte[] bb = new byte[fi.Length];
                br.Read(bb, 0, bb.Length);
                for (int n2 = 0; n2 < bb.Length; n2++)
                {
                    s2 += string.Format("{0:X2}", bb[n2]);
                }
            }
            return s2;
        }

        #endregion

        #region  ==========  Trigger CLR  ==========

        /// <summary>
        /// Получить количество тригеров в MAIN базе.
        /// </summary>
        [NumFunction(6)]
        public int GetTrigger(System.Data.SqlClient.SqlConnection cn)
        {
            int rez = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    CommandText = @"select count(*) from sys.triggers where object_id = object_id(@Triger) ",
                    Connection = cn
                };
                System.Data.SqlClient.SqlParameter pr_Triger = cm.Parameters.Add("Triger", System.Data.SqlDbType.VarChar);
                pr_Triger.Value = NameTrigerClr;
                rez = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return rez;
        }

        /// <summary>
        /// Установка или перезапись тригера
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(7)]
        public void SetTrigger(System.Data.SqlClient.SqlConnection cn)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = CreateTriggersClr();
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Установка или перезапись тригера
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(8)]
        public void UpdateTrigger(System.Data.SqlClient.SqlConnection cn)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = AlterTriggersClr();
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Удаление тригера.
        /// </summary>
        /// <param name="infSer"></param>
        [NumFunction(9)]
        public void DeleteTrigger(System.Data.SqlClient.SqlConnection cn)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = string.Format("DROP TRIGGER {0}", NameTrigerClr);
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return;
        }

        private string CreateTriggersClr()
        {
            string rez = string.Format(strTriggersClr(),
                "CREATE",
                NameTrigerClr,
                NameTable,
                NameAssembly,
                NameClass,
                NameFunction
                );
            return rez;
        }
        private string AlterTriggersClr()
        {
            string rez = string.Format(strTriggersClr(),
                "ALTER",
                NameTrigerClr,
                NameTable,
                NameAssembly,
                NameClass,
                NameFunction
                );
            return rez;
        }
        private string strTriggersClr()
        {
            string s1 = @"{0} TRIGGER {1} ON {2} AFTER INSERT AS EXTERNAL NAME {3}.{4}.{5} ";
            return s1;
        }

        #endregion

        #region  ==========  Trigger  DML  ==========

        /// <summary>
        /// Получить количество -DM- тригеров в заданной базе.
        /// </summary>
        [NumFunction(10)]
        public int GetTriggerDML(System.Data.SqlClient.SqlConnection cn, string Table, string GuidTask)
        {
            int rez = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    CommandText = @"select count(*) from sys.triggers where object_id = object_id(@Triger) ",
                    Connection = cn
                };
                System.Data.SqlClient.SqlParameter pr_Triger = cm.Parameters.Add("Triger", System.Data.SqlDbType.VarChar);
                pr_Triger.Value = string.Format(NameTrigerDml, Table, GuidTask);
                rez = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return rez;
        }

        /// <summary>
        /// Установка или перезапись тригера -DM- в заданной базе
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(11)]
        public int SetTriggerDML(System.Data.SqlClient.SqlConnection cn, string NameTable, string GuidTask, string IPAdd, string NameTableAgent)
        {
            int n1 = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = CreateTriggers(string.Format(NameTrigerDml, NameTable, GuidTask), NameTable, GuidTask, IPAdd, NameTableAgent);
                n1 = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return n1;
        }

        /// <summary>
        /// Установка или перезапись тригера -DM- в заданной базе
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(12)]
        public int UpdateTriggerDML(System.Data.SqlClient.SqlConnection cn, string NameTable, string GuidTask, string IPAdd, string NameTableAgent)
        {
            int n1 = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = AlterTriggers(string.Format(NameTrigerDml, NameTable, GuidTask), NameTable, GuidTask, IPAdd, NameTableAgent);
                n1 = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return n1;
        }

        /// <summary>
        /// Удаление тригера -DM- в заданной базе
        /// </summary>
        /// <param name="infSer"></param>
        [NumFunction(13)]
        public int DeleteTriggerDML(System.Data.SqlClient.SqlConnection cn, string NameTrigger)
        {
            int n1 = 0;
            try
            {
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = string.Format("DROP TRIGGER {0}", NameTrigger);
                n1 = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return n1;
        }

        private string CreateTriggers(string NameTriger, string NameTable, string GuidTask, string IPAdd, string NameTableAgent)
        {
            ;
            string rez = string.Format(strTriggers(),
                NameTriger,
                NameTable,
                GuidTask,
                IPAdd,
                "CREATE",
                NameTableAgent
                );
            return rez;
        }
        private string AlterTriggers(string NameTriger, string NameTable, string GuidTask, string IPAdd, string NameTableAgent)
        {
            string rez = string.Format(strTriggers(),
                 NameTriger,
                NameTable,
                GuidTask,
                IPAdd,
               "ALTER",
                NameTableAgent
                );
            return rez;
        }
        private static string strTriggers()
        {
            //  0 - имя триггера
            //  1 - имя таблицы в которую вставляется данный тригер
            //  2 - GUID задачи
            //  3 - IP сервера
            //  4 - CREATE или ALTER
            //  5 - Имя EVENT (agent) таблицы в которую будем делать запись
            string s1 = @"
{4} TRIGGER {0}
   ON  {1}
   AFTER INSERT, UPDATE    
AS
BEGIN
	SET NOCOUNT ON;
	declare @IdRecord as integer = (SELECT ID FROM inserted);
	declare @GuidTask as varchar(max) = '{2}';
	declare @AddressMain as varchar(max) = '{3}';
	declare @NameServer as varchar(max) = @@SERVERNAME;
	declare @NameBase as varchar(max) = DB_NAME();
	declare @NameTable as varchar(max) = OBJECT_NAME((select parent_object_id from sys.objects where object_id = @@PROCID));
	declare @NameTrigger as varchar(max) = OBJECT_NAME(@@PROCID);
    declare @Act as varchar(2) = ( select case when i.Id is null then 'D' when d.Id is null then 'I' else 'U' end
	    from inserted i	full join deleted d on d.Id = i.Id )
	INSERT INTO ASynchro.dbo.{5}
        (GuidTask, ActionTrigger, NameTrigger, NameTable, NameBase, NameServer, AddressMain, IdRecord, IsTask)
	    VALUES  ( @GuidTask,  @Act,  @NameTrigger,  @NameTable,  @NameBase,  @NameServer, @AddressMain, @IdRecord, 1)
END
";
            return s1;
        }
        public static byte[] GetHashTriggerDml()
        {
            System.Security.Cryptography.SHA512 sha = System.Security.Cryptography.SHA512.Create();
            byte[] bb = System.Text.Encoding.Default.GetBytes(strTriggers());
            byte[] bb_sha = sha.ComputeHash(bb);
            return bb_sha;
        }
        private string strTriggerOrderFirst(string NameTable)
        {
            string s1 = @"sp_settriggerorder @triggername= '{0}.{1}', @order='First'";
            //s1 = string.Format(s1, NameTable, NameTriger);
            return s1;
        }
        private string strTriggerOrderLast(string NameTable)
        {
            string s1 = @"sp_settriggerorder @triggername= '{0}_{1}', @order='Last', @stmttype = 'UPDATE'";
            s1 = string.Format(s1, NameTrigerClr, NameTable);
            return s1;
        }
        #endregion
    }
}
