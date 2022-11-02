using Business.Atributes;
using mod = Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models.Tables;

namespace Business.Sync.Main
{
    [NumClass(17)]
    public class MainSync
    {
        #region  ==========  Только локально  ==========

        #region  ==========  Test-запросы-l  ==========

        /// <summary>
        /// Тестирование соединения Client-server
        /// </summary>
        /// <param name="n1"></param>
        /// <returns></returns>
        [NumFunction(1)]
        public int TestServer(int n1)
        {
            return ++n1;
        }

        /// <summary>
        /// Тестирование соединения Client-server-SQL
        /// </summary>
        /// <param name="n1"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public bool TestSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMainNull());
                cn.Open();
                string s1 = @"select COUNT(*) from sys.databases where name = @Base";
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand(s1, cn);
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Base", System.Data.SqlDbType.VarChar);
                pr.Value = SqlScripts.NameMainBase;
                int m1 = (int)cm.ExecuteScalar();
                FileEventLog.IsSql = m1 == 1;
            }
            catch (Exception e1)
            {
                FileEventLog.IsSql = false;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return FileEventLog.IsSql;
        }

        /// <summary>
        /// Пока не работает
        /// </summary>
        [NumFunction(3)]
        public void TestListener(RetTriggers ret)
        {
            System.Threading.Thread.Sleep(10000);
            int n1 = 0;
            n1++;
            n1--;
        }

        #endregion

        #region  ==========  Info MAIN SQL-l  ==========

        /// <summary>
        /// Получить информацию о подключению MAIN SQL
        /// </summary>
        /// <returns></returns>
        [NumFunction(5)]
        public InfoSql GetPropertySqlMain()
        {
            InfoSql sr = new InfoSql();
            sr.Id = 0;
            sr.NameServerOrIp = SqlScripts.NameMainSql;
            sr.Base = SqlScripts.NameMainBase;
            sr.User = SqlScripts.UserSqlMain;
            sr.Password = SqlScripts.PasswordSqlMain;
            return sr;
        }

        /// <summary>
        /// Сохранить информацию о подключению MAIN SQL
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        [NumFunction(6)]
        public InfoSql SetPropertySqlMain(InfoSql sr)
        {
            SqlScripts.NameMainSql = sr.NameServerOrIp;
            SqlScripts.UserSqlMain = sr.User;
            SqlScripts.PasswordSqlMain = sr.Password;
            SqlScripts.IsSave = true;
            return sr;
        }

        #endregion

        #region  ==========  Servers-l  ==========

        /// <summary>
        /// Добавить сервер в Main-базу
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(8)]
        public ResponseResult AddServer(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = srv.Create();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Обновить сервер в Main-базе
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(9)]
        public ResponseResult UpdateServer(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = srv.Update();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Удалить сервер в Main-базе
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(10)]
        public ResponseResult DelServer(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = srv.Delete();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        #endregion

        #region  ==========  Tasks-l  ==========

        /// <summary>
        /// Получить список задач из Main-базы
        /// </summary>
        /// <returns></returns>
        [NumFunction(11)]
        public ResponseResult GetTasks()
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = mod.Task.GetTasks();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Получить 1 задачу
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NumFunction(33)]
        public ResponseResult GetTask(int Id)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = mod.Task.GetTask(Id);
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Добавить задачу в Main-базу
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(12)]
        public ResponseResult AddTask(mod.Task tsk)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = tsk.Create();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Обновить задачу в Main-базе
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(13)]
        public ResponseResult UpdateTask(mod.Task tsk)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = tsk.Update();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Удалить задачу в Main-базе
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(14)]
        public ResponseResult DelTask(mod.Task tsk)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = tsk.Delete();
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        #endregion

        #region  ==========  TasksLog  ==========

        public List<mod.TasksLog> GetTasksLog(int IdTask, DateTimeOffset? dt = null)
        {
            return mod.TasksLog.GetTasksLog(IdTask, dt);
        }

        #endregion

        #region  ============  Assembly  ==========

        [NumFunction(16)]
        public ResponseResult GetAssembly(mod.Servers infSer)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case Enums.TypeServers.PohodaXml:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.GetAssembly(infSer, Base);
                //        break;
                //    case Enums.TypeServers.MsSql:
                //    case Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.GetAssembly(infSer, Base);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(17)]
        public ResponseResult CheckAssembly(mod.Servers infSer)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.CheckAssembly(infSer);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.CheckAssembly(infSer);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(18)]
        public ResponseResult SetAssembly(mod.Servers infSer)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.SetAssembly(infSer);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.SetAssembly(infSer);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(19)]
        public ResponseResult DeleteAssembly(mod.Servers infSer, string Base)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.DeleteAssembly(infSer, Base);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.DeleteAssembly(infSer, Base);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(20)]
        public ResponseResult GetTrigger(mod.Servers infSer, string TableName)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.GetTrigger(infSer, Base, TableName);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.GetTrigger(infSer, Base, TableName);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(21)]
        public ResponseResult CheckTrigger(mod.Servers infSer, List<string> ListTable)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.CheckTrigger(infSer, ListTable);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.CheckTrigger(infSer, ListTable);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(22)]
        public ResponseResult SetTrigger(mod.Servers infSer, List<string> ListTable)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.SetTrigger(infSer, ListTable);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.SetTrigger(infSer, ListTable);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        [NumFunction(23)]
        public ResponseResult DeleteTrigger(mod.Servers infSer, string Base, List<string> ListTable)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                //switch (infSer.Type)
                //{
                //    case com.Enums.TypeServers.PohodaXmlRemote:
                //        poh.Pohoda.exPohoda ph_rem = new poh.Pohoda.exPohoda();
                //        rez = ph_rem.DeleteTrigger(infSer, Base, ListTable);
                //        break;
                //    case com.Enums.TypeServers.MsSql:
                //    case com.Enums.TypeServers.PohodaXml:
                //        poh.Sql.exMsSqlMain sql = new poh.Sql.exMsSqlMain();
                //        rez = sql.DeleteTrigger(infSer, Base, ListTable);
                //        break;
                //    default:
                //        return rez;
                //}
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        #endregion

        #region  ==========  Run task triggers  ==========

        /// <summary>
        /// Общее действие на срабатывание триггера в базе
        /// </summary>
        /// <param name="ret"></param>
        [NumFunction(31)]
        public void RunTaskTriggers(RetTriggers ret)
        {
            try
            {
                mod.Task tsk = mod.Task.GetTask(ret.GuidTask);
                if (tsk == null)
                {
                    string s1 = string.Format("Не найденна задача для триггера Id: {0}", ret.Id);
                    FileEventLog.WriteErr(this, new Exception(s1), System.Reflection.MethodInfo.GetCurrentMethod());
                    return;
                }
                if (tsk.IsRun)
                {
                    mod.Tasks.ActionAll aa = new mod.Tasks.ActionAll();
                    aa.RunTaskTriggers(tsk, ret);
                    UpdateReadTriggers(tsk.ServerSource, ret);
                }
                else
                {
                    tsk.Message = string.Format("Задача Name: {0}, Id: {1} отключенна. Выполнение прервано", tsk.Name, tsk.Id);
                    tsk.DateRun = tsk.Param.DateLastRun = tsk.Param.DateLastRunOk = DateTimeOffset.Now.ToUniversalTime();
                    tsk.UpdateDateRun();
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        /// <summary>
        /// Общее действие при срабатывании задачи по расписанию
        /// </summary>
        /// <param name="tsk"></param>
        [NumFunction(32)]
        public void RunTaskSchedule()
        {
            try
            {
                List<mod.Task> li_tsk = mod.Task.GetTasksRun();
                foreach (mod.Task tsk in li_tsk)
                {
                    string s1 = string.Format("Найденна Schedule-задача Name: {0}", tsk.Name);
                    FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    mod.Tasks.ActionAll aa = new mod.Tasks.ActionAll();
                    aa.RunTaskSchedule(tsk);
                }
                List<mod.Servers> li_srv = mod.Servers.GetServers(true);
                foreach (mod.Servers srv in li_srv)
                {
                    if ((srv.Type == TypeServers.MsSql) || (srv.Type == TypeServers.PohodaXml))
                    {
                        if (!srv.IsRemote) continue;
                        List<RetTriggers> li_trg = GetTriggers(srv, Enums.StTriggers.DmlTrigger);
                        foreach (RetTriggers trg in li_trg)
                        {
                            RunTaskTriggers(trg);
                        }
                    }
                    else if ((srv.Type == TypeServers.Odoo) || (srv.Type == TypeServers.PostgreSQL))
                    {
                        List<RetTriggers> li_trg = GetTriggers(srv, Enums.StTriggers.DmlTrigger);
                        foreach (RetTriggers trg in li_trg)
                        {
                            RunTaskTriggers(trg);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        /// <summary>
        /// Получить с сервера триггера для обработки 
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="St"></param>
        /// <returns></returns>
        [NumFunction(34)]
        public List<RetTriggers> GetTriggers(mod.Servers Srv, Enums.StTriggers St = Enums.StTriggers.ClrTrigger)
        {
            List<RetTriggers> rr = new List<RetTriggers>();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    rr = cl.GetTriggers(Srv, St);
                    Srv.IsRemote = true;
                }
                else
                {
                    switch (Srv.Type)
                    {
                        case TypeServers.MsSql:
                        case TypeServers.PohodaXml:
                            rr = RetTriggers.GetEventTriggersSql(Srv, St);
                            break;
                        case TypeServers.Odoo:
                        case TypeServers.PostgreSQL:
                            rr = RetTriggers.GetEventTriggersOdoo(Srv, St);
                            break;
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { }
            return rr;
        }

        /// <summary>
        /// Обновить статус и дату END сборщику тригеров
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="St"></param>
        /// <returns></returns>
        [NumFunction(35)]
        public void UpdateRemTriggers(mod.Servers Srv, RetTriggers reT, Enums.StTriggers St)
        {
            System.Data.SqlClient.SqlConnection cnSql = null;
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    cl.UpdateRemTriggers(Srv, reT, St);
                    Srv.IsRemote = true;
                }
                else
                {
                    reT.UpdateEnd(Srv, Enums.StTriggers.EndTask, reT.Status);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                cnSql?.Close();
            }
            return;
        }

        #endregion

        #endregion  

        #region  ==========  Local + Agent  ==========

        #region  ==========  Action Task  ==========

        #region  ==========  Bank  ==========

        /// <summary>
        /// Получить список или одну запись о банке
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(39)]
        public ResponseResult GetListBank(mod.Servers Srv, string NameBase, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListBank(Srv, NameBase, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Bank> li = ret.Sender as List<mod.Tables.Bank>;
                    if (li != null) foreach (mod.Tables.Bank item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    if (Id == 0)
                    {
                        ret.Sender = mod.Tables.Bank.GetList(Srv, NameBase);
                    }
                    else
                    {
                        ret.Sender = Bank.GetBank(Srv, NameBase, Id).CollectionBank;
                    }
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи в Bank
        /// </summary>
        /// <param name="Bnk"></param>
        /// <returns></returns>
        [NumFunction(40)]
        public ResponseResult CreateBank(mod.Tables.Bank Bnk)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Bnk.Srv.IsRemote)
                {
                    Bnk.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Bnk.Srv.RemHostIp);
                    ret = cl.CreateBank(Bnk);
                    Bnk.Srv.IsRemote = true;
                }
                else
                {
                    Bnk.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи в Bank
        /// </summary>
        /// <param name="Bnk"></param>
        /// <returns></returns>
        [NumFunction(41)]
        public ResponseResult UpdateBank(mod.Tables.Bank Bnk)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Bnk.Srv.IsRemote)
                {
                    Bnk.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Bnk.Srv.RemHostIp);
                    ret = cl.UpdateBank(Bnk);
                    Bnk.Srv.IsRemote = true;
                }
                else
                {
                    Bnk.Update();
                    ret.Sender = true;
                }
                ret.IsError = false;
                ret.Message = "Ok";
                ret.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  Country  ==========

        /// <summary>
        /// Получить список или одну запись о стране
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(42)]
        public ResponseResult GetListCountry(mod.Servers Srv, string NameBase, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListCountry(Srv, NameBase, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Country> li = ret.Sender as List<mod.Tables.Country>;
                    if (li != null) foreach (mod.Tables.Country item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    if (Id == 0)
                    {
                        ret.Sender = mod.Tables.Country.GetList(Srv, NameBase);
                    }
                    else
                    {
                        ret.Sender = Country.GetCountry(Srv, NameBase, Id).CollectionCountry;
                    }
                }
                ret.IsError = false;
                ret.Message = "Ok";
                ret.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи в Country
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(43)]
        public ResponseResult CreateCountry(mod.Tables.Country Cnt)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreateCountry(Cnt);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                }
                ret.IsError = false;
                ret.Message = "Ok";
                ret.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи в Country
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(44)]
        public ResponseResult UpdateCountry(mod.Tables.Country Cnt)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdateCountry(Cnt);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  Currency  ==========

        /// <summary>
        /// Получить список или одну запись о валюте
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(45)]
        public ResponseResult GetListCurrency(mod.Servers Srv, string NameBase, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListCurrency(Srv, NameBase, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Currency> li = ret.Sender as List<mod.Tables.Currency>;
                    if (li != null) foreach (mod.Tables.Currency item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    if (Id == 0)
                    {
                        ret.Sender = mod.Tables.Currency.GetList(Srv, NameBase);
                    }
                    else
                    {
                        ret.Sender = Currency.GetCurrency(Srv, NameBase, Id).CollectionCurrency;
                    }
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи о валюте
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(46)]
        public ResponseResult CreateCurrency(mod.Tables.Currency Cnt)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreateCurrency(Cnt);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи о валюте
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(47)]
        public ResponseResult UpdateCurrency(mod.Tables.Currency Cnt)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdateCurrency(Cnt);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  Partner  ==========

        /// <summary>
        /// Получить список или одну запись о Partner
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(48)]
        public ResponseResult GetListPartner(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListPartner(Srv, NameBase, Ico, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Partner> li = ret.Sender as List<mod.Tables.Partner>;
                    if (li != null)
                    {
                        foreach (mod.Tables.Partner item in li)
                        {
                            item.Srv = Srv;
                            item.Base = NameBase;
                            item.IcoBase = Ico;
                            item.Srv.IsRemote = true;
                        }
                    }
                }
                else
                {
                    if (Id == 0)
                    {
                        ret.Sender = mod.Tables.Partner.GetList(Srv, NameBase, Ico);
                    }
                    else
                    {
                        ret.Sender = Partner.GetPartner(Srv, NameBase, Id, Ico).CollectionPartner;
                    }
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи о Partner
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(49)]
        public ResponseResult CreatePartner(mod.Tables.Partner Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreatePartner(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи о Partner
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(50)]
        public ResponseResult UpdatePartner(mod.Tables.Partner Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdatePartner(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  Company  ==========

        /// <summary>
        /// Получить список или одну запись о Company
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(54)]
        public ResponseResult GetListCompany(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote) 
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListCompany(Srv, NameBase, Ico, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Company> li = ret.Sender as List<mod.Tables.Company>;
                    if (li != null) foreach (mod.Tables.Company item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    if (Id == 0)
                    {
                        ret.Sender = mod.Tables.Company.GetList(Srv, NameBase);
                    }
                    else
                    {
                        ret.Sender = Company.GetCompany(0, Srv, NameBase).CollectionCompany;
                    }
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи о Company
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(55)]
        public ResponseResult CreateCompany(mod.Tables.Company Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreateCompany(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи о Company
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(56)]
        public ResponseResult UpdateCompany(mod.Tables.Company Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdateCompany(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  User  ==========

        /// <summary>
        /// Получить список или одну запись о User
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(57)]
        public ResponseResult GetListUser(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListUser(Srv, NameBase, Ico, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.User> li = ret.Sender as List<mod.Tables.User>;
                    if (li != null) foreach (mod.Tables.User item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    if (Id == 0)
                    {
                        ret.Sender = mod.Tables.User.GetList(Srv, NameBase);
                    }
                    else
                    {
                        ret.Sender = User.GetUser(0, Srv, NameBase).CollectionUser;
                    }
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи о User
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(58)]
        public ResponseResult CreateUser(mod.Tables.User Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreateUser(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи о User
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(59)]
        public ResponseResult UpdateUser(mod.Tables.User Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdateUser(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  Zakazka  ==========

        /// <summary>
        /// Получить список или одну запись о Zakazka
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(51)]
        public ResponseResult GetListZakazka(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListZakazka(Srv, NameBase, Ico, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Zakazka> li = ret.Sender as List<mod.Tables.Zakazka>;
                    if (li != null) foreach (mod.Tables.Zakazka item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    ret.Sender = mod.Tables.Zakazka.GetList(Srv, NameBase, Ico);
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи о Zakazka
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(52)]
        public ResponseResult CreateZakazka(mod.Tables.Zakazka Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreateZakazka(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи о Zakazka
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(53)]
        public ResponseResult UpdateZakazka(mod.Tables.Zakazka Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdateZakazka(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        #endregion

        #region  ==========  Objednalky  ==========

        /// <summary>
        /// Получить список или одну запись о Objednalky
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(51)]
        public ResponseResult GetListObjednalky(mod.Servers Srv, string NameBase, string Ico, int Id)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    ret = cl.GetListObjednalky(Srv, NameBase, Ico, Id);
                    Srv.IsRemote = true;
                    List<mod.Tables.Objednalky> li = ret.Sender as List<mod.Tables.Objednalky>;
                    if (li != null) foreach (mod.Tables.Objednalky item in li) item.Srv.IsRemote = true;
                }
                else
                {
                    ret.Sender = mod.Tables.Objednalky.GetList(Srv, NameBase, Ico);
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Создание новой записи о Objednalky
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(52)]
        public ResponseResult CreateObjednalky(mod.Tables.Objednalky Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.CreateObjednalky(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Create();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

        /// <summary>
        /// Обновление записи о Objednalky
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(53)]
        public ResponseResult UpdateObjednalky(mod.Tables.Objednalky Cnt, string Ico)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                Cnt.IcoBase = Ico;
                if (Cnt.Srv.IsRemote)
                {
                    Cnt.Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Cnt.Srv.RemHostIp);
                    ret = cl.UpdateObjednalky(Cnt, Ico);
                    Cnt.Srv.IsRemote = true;
                }
                else
                {
                    Cnt.Update();
                    ret.Sender = true;
                    ret.IsError = false;
                    ret.Message = "Ok";
                    ret.Status = StatusMessage.Ok;
                }
            }
            catch (Exception e1)
            {
                ret.Message = e1.Message;
                ret.Status = StatusMessage.Er;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return ret;
        }

		#endregion

		#region ========== Factura =========
		public async Task<ResponseResult> GetListFactura(mod.Servers Srv)
        {
            var result = new ResponseResult() { IsError = false, Status = StatusMessage.Ok, Message = ""};
            var data = await EFModel.Base.GetListFactura(Srv.GetSqlConnectionString());
            Factura factura;
            var fl = new List<Factura>();   
            foreach (var item in data)
            {
                factura = new Factura(Actions.SyncFactura) {
                    CompanyIco = item.Ico,
                    Name = item.Stext
                };
                fl.Add(factura);
			}
            result.Sender = fl;
			return await Task.FromResult(result);
		}
		#endregion
		#endregion

		#region  ==========  Test-запросы-r  ==========

		/// <summary>
		/// Проверка подключения серверов
		/// </summary>
		/// <param name="srv"></param>
		/// <returns></returns>
		[NumFunction(7)]
        public ResponseResult CheckServers(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            System.Data.SqlClient.SqlConnection cnSql = null;
            try
            {
                if (srv.IsRemote)
                {
                    //System.Net.NetworkInformation.Ping pn = new System.Net.NetworkInformation.Ping();
                    //System.Net.NetworkInformation.PingReply pr = pn.Send(srv.RemHostIp);
                    //if (pr.Status != System.Net.NetworkInformation.IPStatus.Success)
                    //{
                    //    string s_buf = System.Text.Encoding.UTF8.GetString(pr.Buffer);
                    //    string s_mes = string.Format("Status: {0}, Times: {1}, IP: {2}, Byffer: {3}",
                    //        pr.Status, pr.RoundtripTime, pr.Address, s_buf);
                    //    rr.Status = StatusMessage.Er;
                    //    rr.Message = s_mes;
                    //    return rr;
                    //}
                    srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(srv.RemHostIp);
                    rr = cl.CheckServers(srv);
                    rr.ListMessage.Insert(0, string.Format("Connection to the remote server is verified - OK"));
                    srv.IsRemote = true;
                }
                else
                {
                    switch (srv.Type)
                    {
                        case TypeServers.MsSql:
                            rr = InfoSql.CheckSql(srv);
                            break;
                        case TypeServers.PohodaXml:
                            rr = InfoPohoda.CheckPohoda(srv);
                            break;
                        case TypeServers.Odoo:
                            rr = InfoBaseOdoo.CheckOdoo(srv).Result;
                            break;
                        case TypeServers.PostgreSQL:
                            rr = InfoBaseOdoo.CheckPostGerSQL(srv);
                            break;
                        default:
                            rr.Status = StatusMessage.Er;
                            rr.Message = string.Format("Invalid server type: {0}", srv.Type);
                            break;
                    }
                } 
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                cnSql?.Close();
            }
            return rr;
        }

        #endregion

        #region  ==========  работа с базой(сервером)  ==========

        /// <summary>
        /// Получить список серверов из Main-базы
        /// </summary>
        /// <param name="IsEnable">True - только включённых</param>
        /// <returns></returns>
        [NumFunction(4)]
        public ResponseResult GetServers(bool IsEnable = false)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr.Sender = mod.Servers.GetServers(IsEnable);
                rr.IsError = false;
                rr.Message = "Ok";
                rr.Status = StatusMessage.Ok;
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return rr;
        }

        /// <summary>
        /// Получить список баз 'pohoda' с сервера
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(15)]
        public ResponseResult GetListBase(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            System.Data.SqlClient.SqlConnection cnSql = null;
            try
            {
                if (srv.IsRemote)
                {
                    srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(srv.RemHostIp);
                    rr = cl.GetListBase(srv);
                    srv.IsRemote = true;
                    rr.ListMessage.Insert(0, string.Format("Connection to the remote server is verified - OK"));
                }
                else
                {
                    switch (srv.Type)
                    {
                        case TypeServers.MsSql:
                            rr.Sender = mod.InfoBasePohoda.GetBasePohoda(srv);
                            rr.IsError = false;
                            rr.Status = StatusMessage.Ok;
                            break;
                        case TypeServers.PohodaXml:
                            rr.Sender = mod.InfoBasePohoda.GetBasePohoda(srv);
                            rr.IsError = false;
                            rr.Status = StatusMessage.Ok;
                            break;
                        case TypeServers.Odoo:
                            rr.Status = StatusMessage.Er;
                            rr.Message = string.Format("Invalid server type: {0}", srv.Type);
                            break;
                        case TypeServers.PostgreSQL:
                            rr.Status = StatusMessage.Er;
                            rr.Message = string.Format("Invalid server type: {0}", srv.Type);
                            break;
                        default:
                            rr.Status = StatusMessage.Er;
                            rr.Message = string.Format("Invalid server type: {0}", srv.Type);
                            break;
                    }
                }
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                cnSql?.Close();
            }
            return rr;
        }

        /// <summary>
        /// Проверка SQL и если надо создание базы и таблицы на агенте
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(29)]
        public ResponseResult CheckOrCreateTableAgent(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                if (srv.IsRemote)
                {
                    srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(srv.RemHostIp);
                    rr = cl.CheckOrCreateTableAgent(srv);
                    srv.IsRemote = true;
                }
                else
                {
                    SqlScripts ss = new SqlScripts();
                    rr.Sender = ss.CheckOrCreateTableAgent(srv);
                    rr.IsError = false;
                }
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return rr;
        }

        /// <summary>
        /// Проверка Odoo и создание таблицы ASynchro и полей в таблицах
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(36)]
        public ResponseResult CheckingOrCreateOdoo(mod.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                if (srv.IsRemote)
                {
                    srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(srv.RemHostIp);
                    rr = cl.CheckingOrCreateOdoo(srv);
                    srv.IsRemote = true;
                }
                else
                {
                    OdooScripts os = new OdooScripts();
                    rr.Sender = os.CheckingOrCreateOdoo(srv);
                    rr.IsError = false;
                }
            }
            catch (Exception e1)
            {
                rr.Status = StatusMessage.Er;
                rr.Message = e1.Message;
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return rr;
        }

        /// <summary>
        /// Перевод event-trigger в состояние - ПРОЧИТАННО
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="ret"></param>
        [NumFunction(38)]
        public void UpdateReadTriggers(mod.Servers Srv, RetTriggers ret)
        {
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    cl.UpdateReadTriggers(Srv, ret);
                    Srv.IsRemote = true;
                }
                else
                {
                    ret.UpdateRead(Srv, ret.Status);
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
            }
            return;
        }

        #endregion

        #region  ==========  Trigers Dml  ==========

        /// <summary>
        /// Получить список всех тригеров по формату на указанном сервере (в том числе и через агента)
        /// </summary>
        /// <param name="Srv"></param>
        /// <returns></returns>
        [NumFunction(24)]
        public Dictionary<string, Models.ListTrigger> GetDictionaryTriggers(mod.Servers Srv)
        {
            Dictionary<string, Models.ListTrigger> di = new Dictionary<string, Models.ListTrigger>();
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (Srv.IsRemote)
                {
                    Srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(Srv.RemHostIp);
                    di = cl.GetDictionaryTriggers(Srv);
                    foreach (var item in di)
                    {
                        item.Value.IsRemote = true;
                    }
                    Srv.IsRemote = true;
                }
                else
                {
                    switch (Srv.Type)
                    {
                        case TypeServers.MsSql:
                        case TypeServers.PohodaXml:
                            di = Models.InfoBasePohoda.GetTriggersPohoda(Srv);
                            break;
                        case TypeServers.Odoo:
                        case TypeServers.PostgreSQL:
                            OdooScripts os = new OdooScripts();
                            di = os.GetTriggerDML(Srv);
                            break;
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return di;
        }

        /// <summary>
        /// Проверить наличие тригера на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(25)]
        public bool CheckTriggersDml(mod.Task tsk, string Base, string NameTrigger)
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (tsk.ServerSource.IsRemote)
                {
                    tsk.ServerSource.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(tsk.ServerSource.RemHostIp);
                    b1 = cl.CheckTriggersDml(tsk, Base, NameTrigger);
                    tsk.ServerSource.IsRemote = true;
                }
                else
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(tsk.ServerSource, Base));
                    cn.Open();
                    mod.SQLTriggers sql_trg = new mod.SQLTriggers();
                    b1 = sql_trg.GetTriggerDML(cn, tsk.Param.ActionProp.TableSql, tsk.Param.IdGuid) != 0;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }

        /// <summary>
        /// Создать тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <returns></returns>
        [NumFunction(26)]
        public bool CreateTriggersDml(mod.Task tsk, string Base, string NameTableAgent)
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (tsk.ServerSource.IsRemote)
                {
                    tsk.ServerSource.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(tsk.ServerSource.RemHostIp);
                    b1 = cl.CreateTriggersDml(tsk, Base, NameTableAgent);
                    tsk.ServerSource.IsRemote = true;
                }
                else
                {
                    switch (tsk.ServerSource.Type)
                    {
                        case TypeServers.MsSql:
                        case TypeServers.PohodaXml:
                            cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(tsk.ServerSource, Base));
                            cn.Open();
                            mod.SQLTriggers sql_trg = new mod.SQLTriggers();
                            b1 = sql_trg.SetTriggerDML(cn, tsk.Param.ActionProp.TableSql, tsk.Param.IdGuid, SqlScripts.MainIPSql, NameTableAgent) != 0;
                            break;
                        case TypeServers.Odoo:
                        case TypeServers.PostgreSQL:
                            OdooScripts odoo_trg = new OdooScripts();
                            odoo_trg.CreateTriggerDML(tsk);
                            break;
                    }
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }

        /// <summary>
        /// Обновить тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(27)]
        public bool UpdateTriggersDml(mod.Task tsk, string Base, string NameTrigger, string NameTableAgent)
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (tsk.ServerSource.IsRemote)
                {
                    tsk.ServerSource.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(tsk.ServerSource.RemHostIp);
                    b1 = cl.UodateTriggersDml(tsk, Base, NameTrigger, NameTableAgent);
                    tsk.ServerSource.IsRemote = true;
                }
                else
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(tsk.ServerSource, Base));
                    cn.Open();
                    mod.SQLTriggers sql_trg = new mod.SQLTriggers();
                    b1 = sql_trg.UpdateTriggerDML(cn, tsk.Param.ActionProp.TableSql, tsk.Param.IdGuid, SqlScripts.MainIPSql, NameTableAgent) != 0;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }

        /// <summary>
        /// Удалить тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="srv"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(28)]
        public bool DeleteTriggersDml(mod.Servers srv, string Base, string NameTrigger, string NameTable)
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (srv.IsRemote)
                {
                    srv.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(srv.RemHostIp);
                    b1 = cl.DeleteTriggersDml(srv, Base, NameTrigger, NameTable);
                    srv.IsRemote = true;
                }
                else
                {
                    switch (srv.Type)
                    {
                        case TypeServers.MsSql:
                        case TypeServers.PohodaXml:
                            cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, Base));
                            cn.Open();
                            mod.SQLTriggers sql_trg = new mod.SQLTriggers();
                            b1 = sql_trg.DeleteTriggerDML(cn, NameTrigger) != 0;
                            break;
                        case TypeServers.Odoo:
                        case TypeServers.PostgreSQL:
                            OdooScripts odoo_trg = new OdooScripts();
                            odoo_trg.DeleteTriggerDML(srv, NameTable, NameTrigger);
                            break;
                    }


                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }


        /// <summary>
        /// Обновить тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(27)]
        public bool UpdateTriggersOdooDml(mod.Task tsk, string Base, string NameTrigger)
        {
            bool b1 = false;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                if (tsk.ServerSource.IsRemote)
                {
                    tsk.ServerSource.IsRemote = false;
                    Interfases.IConnectMainSyncAgent cl = Setup.RemAssecc.GetConnectAgent(tsk.ServerSource.RemHostIp);
                    b1 = cl.UpdateTriggersOdooDml(tsk, Base, NameTrigger);
                    tsk.ServerSource.IsRemote = true;
                }
                else
                {
                    OdooScripts sql_trg = new OdooScripts();
                    b1 = sql_trg.UpdateTrigger(tsk, Base, NameTrigger) != 0;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return b1;
        }

        #endregion

        #endregion

        #region  ==========  Внутренние функции  ==========

        public void aaa()
        {
            mod.Tables.Country cc = new mod.Tables.Country();

        }

        #endregion



    }
}
