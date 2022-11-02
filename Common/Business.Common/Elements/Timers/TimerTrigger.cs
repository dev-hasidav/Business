using Business.Atributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Timers
{
    [NumClass(31)]
    [Serializable]
    public partial class TimerTrigger : Component
    {
        public bool IsStart = true;
        private int _PortBase;
        private string _NameScopeBase;
        private int _CountYes = 60;
        private int _Company = 0;
        private System.Threading.Thread th_cmp = null;
        private System.Timers.Timer tm_cmp = null;
        private Random r = new Random(DateTime.Now.Millisecond);
        private int nCountDiag = 0;
        private int nTimeDiag = 60;
        public TimerTrigger(int PortBase, string NameScopeBase)
        {
            _PortBase = PortBase;
            _NameScopeBase = NameScopeBase;
            InitializeComponent();
        }
        

        public TimerTrigger(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [NumFunction(1)]
        private void tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            System.Data.SqlClient.SqlConnection cn = null;
            System.IO.FileStream fs = null;
            try
            {
                tm.Stop();
                if (!IsStart)
                {
                    return;
                }
                if ((nCountDiag % nTimeDiag) == 0) FileEventLog.WriteOk(this, "Timer check stopped.", System.Reflection.MethodInfo.GetCurrentMethod());
                Dictionary<string, Models.ListTrigger> di_trg_all = new Dictionary<string, Models.ListTrigger>();
                Dictionary<string, Models.ListTrigger> di_trg_Task = new Dictionary<string, Models.ListTrigger>();
                List<Models.Task> li_task = Models.Task.GetTasksTriggers(false);
                string s1 = string.Format(@"http://{0}:{1}/{2}", "localhost", _PortBase, _NameScopeBase);
                Type tt = typeof(Interfases.IConnectMainSyncAgent);
                object cl_Connect = Activator.GetObject(tt, s1);

                ResponseResult rr = (ResponseResult)tt.GetMethod("GetServers").Invoke(cl_Connect, new object[] { false });
                if (rr.IsError)
                {
                    throw new Exception("Server access error");
                }
                List<Models.Servers> li_srv = (List<Models.Servers>)rr.Sender;

                #region ==========  проверяем и создаём базы на агентах и Odoo
                foreach (Models.Servers srv in li_srv)
                {
                    if (!srv.IsEnable) {; }
                    else if (srv.Type == TypeServers.Odoo || srv.Type == TypeServers.PostgreSQL)
                    {
                        rr = (ResponseResult)tt.GetMethod("CheckingOrCreateOdoo").Invoke(cl_Connect, new object[] { srv });
                        if (rr.IsError)
                        {
                            FileEventLog.WriteErr(this, new Exception(rr.Message), System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                        else if (!(bool)rr.Sender)
                        {
                            FileEventLog.WriteErr(this, new Exception(rr.Message), System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                    }
                    else if (srv.Type == TypeServers.MsSql || srv.Type == TypeServers.PohodaXml)
                    {
                        if (!srv.IsRemote) continue;
                        rr = (ResponseResult)tt.GetMethod("CheckOrCreateTableAgent").Invoke(cl_Connect, new object[] { srv });
                        if (rr.IsError)
                        {
                            FileEventLog.WriteErr(this, new Exception(rr.Message), System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                        else if (!(bool)rr.Sender)
                        {
                            FileEventLog.WriteErr(this, new Exception(rr.Message), System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                    }
                    else
                    {
                        FileEventLog.WriteErr(this, new Exception("Unrecognized server type"), System.Reflection.MethodInfo.GetCurrentMethod());
                    }
                }

                //  Проверяем - изменились ли триггера SQL DML и Odoo DML
                s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                s1 = System.IO.Path.GetDirectoryName(s1);
                System.IO.FileInfo fi_prop = new System.IO.FileInfo(s1 + @"\srvtrg.oml");
                Models.TrigersProp tr = new Models.TrigersProp();
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Models.TrigersProp));
                if (fi_prop.Exists)
                {
                    fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    tr = (Models.TrigersProp)xs.Deserialize(fs);
                    fs.Close();
                }
                bool b_ch_sql = false;
                byte[] bb_ch_sql = Models.SQLTriggers.GetHashTriggerDml();
                if (tr.ChangeSqlDml.Length == bb_ch_sql.Length)
                {
                    for (int n1 = 0; n1 < bb_ch_sql.Length; n1++)
                    {
                        if (bb_ch_sql[n1] == tr.ChangeSqlDml[n1]) continue;
                        b_ch_sql = true;
                        break;
                    }
                }
                else b_ch_sql = true;

                bool b_ch_odoo = false;
                byte[] bb_ch_odoo = OdooScripts.GetHashTriggerOdoo();
                if (tr.ChangeOdooDml.Length == bb_ch_odoo.Length)
                {
                    for (int n1 = 0; n1 < bb_ch_odoo.Length; n1++)
                    {
                        if (bb_ch_odoo[n1] == tr.ChangeOdooDml[n1]) continue;
                        b_ch_odoo = true;
                        break;
                    }
                }
                else b_ch_odoo = true;
                tr.ChangeSqlDml = bb_ch_sql;
                tr.ChangeOdooDml = bb_ch_odoo;
                fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                xs.Serialize(fs, tr);
                fs.Close();
                #endregion

                #region  ==========  находим все триггера в всех базах MAIN сервера
                foreach (Models.Servers srv in li_srv)
                {
                    if (!srv.IsEnable) continue;
                    Dictionary<string, Models.ListTrigger> di = (Dictionary<string, Models.ListTrigger>)
                        tt.GetMethod("GetDictionaryTriggers").Invoke(cl_Connect, new object[] { srv });
                    foreach (var item in di)
                    {
                        if (!di_trg_all.ContainsKey(item.Key))
                        {
                            item.Value.Srv = srv;
                            di_trg_all.Add(item.Key, item.Value);
                        }
                    }
                }
                #endregion

                #region  ==========  при необходимости обновляем триггера
                if (b_ch_sql)
                {
                    foreach (var item in di_trg_all)
                    {
                        if ((item.Value.Srv.Type == TypeServers.MsSql) || (item.Value.Srv.Type == TypeServers.PohodaXml))
                        {
                            tt.GetMethod("UpdateTriggersDml").Invoke(cl_Connect, new object[] { item.Value.Tsk, item.Value.NameBase,
                                item.Value.NameTrigger, item.Value.Srv.IsRemote? SqlScripts.NameEventTriggersAgent:SqlScripts.NameEventTriggers });
                        }
                    }
                }
                if (b_ch_odoo)
                {
                    foreach (var item in di_trg_all)
                    {
                        if ((item.Value.Srv.Type == TypeServers.Odoo) || (item.Value.Srv.Type == TypeServers.PostgreSQL))
                        {
                            tt.GetMethod("UpdateTriggersOdooDml").Invoke(cl_Connect, new object[] { item.Value.Tsk, item.Value.NameBase,
                                item.Value.NameTrigger, item.Value.Srv.IsRemote? SqlScripts.NameEventTriggersAgent:SqlScripts.NameEventTriggers });
                        }
                    }
                }
                #endregion

                #region  ==========  создаём список необходитых тригеров
                foreach (Models.Task tsk in li_task)
                {
                    if (!tsk.IsRun) continue;
                    if (!tsk.ServerSource.IsEnable) continue;
                    else if (tsk.ServerSource.Type == TypeServers.MsSql || tsk.ServerSource.Type == TypeServers.PohodaXml)
                    {
                        foreach (Models.InfoBasePohoda bs in tsk.Param.CollectionBaseSource)
                        {
                            s1 = string.Format("Trg_{0}_{1}_{2}", bs.Soubor, tsk.Param.ActionProp.TableSql, tsk.Param.IdGuid);
                            Models.ListTrigger item = new Models.ListTrigger();
                            item.NameTrigger = string.Format("Trg_{0}_{1}", tsk.Param.ActionProp.TableSql, tsk.Param.IdGuid); ;
                            item.NameBase = bs.Soubor;
                            item.NameTable = tsk.Param.ActionProp.TableSql;
                            item.IsRemote = tsk.ServerSource.IsRemote;
                            item.Tsk = tsk;
                            di_trg_Task.Add(s1, item);
                        }
                    }
                    else if (tsk.ServerSource.Type == TypeServers.Odoo || tsk.ServerSource.Type == TypeServers.PostgreSQL)
                    {
                        s1 = string.Format("trg_{0}_{1}_{2}", tsk.ServerSource.PostgreBase, tsk.Param.ActionProp.TablePostgreSql, tsk.Param.IdGuid);
                        Models.ListTrigger item = new Models.ListTrigger();
                        item.NameTrigger = string.Format("trg_{0}_{1}", tsk.Param.ActionProp.TablePostgreSql, tsk.Param.IdGuid);
                        item.NameBase = tsk.ServerSource.PostgreBase;
                        item.NameTable = tsk.Param.ActionProp.TablePostgreSql;
                        item.IsRemote = tsk.ServerSource.IsRemote;
                        item.Tsk = tsk;
                        di_trg_Task.Add(s1, item);
                    }
                }
                #endregion

                #region  ==========  Уже есть в базах
                string s_Yes = "Already in the databases\r\n";
                int n2 = 1;
                for (int n1 = di_trg_Task.Count - 1; n1 >= 0; n1--)
                {
                    KeyValuePair<string, Models.ListTrigger> el = di_trg_Task.ElementAt(n1);
                    int n3 = el.Value.NameTrigger.IndexOf("_", 0);
                    s1 = el.Value.NameTrigger.Insert(n3, "_" + el.Value.NameBase);
                    if (di_trg_all.ContainsKey(s1))
                    {
                        di_trg_all.Remove(s1);
                        di_trg_Task.Remove(s1);
                        s_Yes += string.Format("{2} ) Rem: {3}  Srv: {5}\t Base: {1}\t Table: {4}\t Trg: {0}\r\n",
                            el.Value.NameTrigger, el.Value.NameBase, n2++, el.Value.IsRemote,
                            el.Value.NameTable, el.Value.Tsk.ServerSource.Name);
                    }
                }
                if (++_CountYes > 20)
                {
                    _CountYes = 0;
                    FileEventLog.WriteOk(this, s_Yes, System.Reflection.MethodInfo.GetCurrentMethod());
                }
                #endregion

                #region  ==========  К удалению
                if (di_trg_all.Count != 0)
                {
                    string s_Del = "To deleter\n";
                    n2 = 1;
                    foreach (Models.ListTrigger item in di_trg_all.Values)
                    {
                        bool b1 = (bool)tt.GetMethod("DeleteTriggersDml").Invoke(cl_Connect,
                            new object[] { item.Srv, item.NameBase, item.NameTrigger, item.NameTable });
                        s_Del += string.Format("{2} ) Rem: {3}  Del: {6}  Srv: {5}\t Base: {1}\t Table: {4}\t Trg: {0}\r\n",
                            item.NameTrigger, item.NameBase, n2++, item.IsRemote, item.NameTable, item.Srv.Name, b1);
                        string[] ss = item.NameTrigger.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        if (ss.Length != 0) item.Tsk = Models.Task.GetTask(ss[ss.Length - 1]);
                        if (item.Tsk != null)
                        {
                            item.Tsk.WriteMessageInfo(string.Format("Delete trigger Trg: {0}, Table: {1}, Base: {2}, Server: {3}",
                                item.NameTrigger, item.NameTable, item.NameBase, item.Tsk.ServerSource.Name, b1));
                        }
                    }
                    FileEventLog.WriteOk(this, s_Yes, System.Reflection.MethodInfo.GetCurrentMethod());
                    FileEventLog.WriteOk(this, s_Del, System.Reflection.MethodInfo.GetCurrentMethod());
                    _CountYes = 0;
                }
                #endregion

                #region  ==========  К добавлению
                if (di_trg_Task.Count != 0)
                {
                    string s_Upd = "To addition\r\n";
                    n2 = 1;
                    foreach (Models.ListTrigger item in di_trg_Task.Values)
                    {
                        bool b1 = (bool)tt.GetMethod("CreateTriggersDml").Invoke(cl_Connect,
                            new object[] { item.Tsk, item.NameBase,
                                item.Tsk.ServerSource.IsRemote ? SqlScripts.NameEventTriggersAgent : SqlScripts.NameEventTriggers });
                        s_Upd += string.Format("{2} ) Rem: {3}  Ins: {6}  Srv: {5}\t Base: {1}\t Table: {4}\t Trg: {0}\r\n",
                            item.NameTrigger, item.NameBase, n2++, item.IsRemote, item.NameTable, item.Tsk.ServerSource.Name, b1);
                        item.Tsk.WriteMessageInfo(string.Format("Create trigger Trg: {0}, Table: {1}, Base: {2}, Server: {3}",
                            item.NameTrigger, item.NameTable, item.NameBase, item.Tsk.ServerSource.Name, b1));
                    }
                    FileEventLog.WriteOk(this, s_Yes, System.Reflection.MethodInfo.GetCurrentMethod());
                    FileEventLog.WriteOk(this, s_Upd, System.Reflection.MethodInfo.GetCurrentMethod());
                    _CountYes = 0;
                }
                #endregion

                #region  ==========  Запуск проверки и установки компаний и пользователей

                if ((--_Company < 0) && (th_cmp == null))
                {
                    if (tm_cmp == null)
                    {
                        tm_cmp = new System.Timers.Timer();
                        tm_cmp.AutoReset = false;
                        tm_cmp.Interval = 1000 * 60 * 15;       //  тайм-аут = 20 минут
                        tm_cmp.Elapsed += Tm_Elapsed_OnEndTask;
                    }
                    Models.Tasks.TaskAction.ActionTaskCompany act_company = new Models.Tasks.TaskAction.ActionTaskCompany();
                    act_company.OnEndTask += Act_company_OnEndTask;
                    act_company.NumberClass = r.Next(1, 100000000);
                    System.Threading.ThreadStart ts = new System.Threading.ThreadStart(act_company.RunTask);
                    th_cmp = new System.Threading.Thread(ts);
                    th_cmp.Name = string.Format("ActionTaskCompany_{0}", act_company.NumberClass);
                    th_cmp.Start();
                    tm_cmp.Enabled = true;
                    tm_cmp.Start();
                    _Company = 5;
                }
                #endregion
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                cn?.Close();
                fs?.Close();
                sw.Stop();
                if (tm.Interval != 60000) tm.Interval = 60000;
                if (IsStart)
                {
                    tm.Start();
                    if ((nCountDiag++ % nTimeDiag) == 0) FileEventLog.WriteOk(this, "Timer check started.", System.Reflection.MethodInfo.GetCurrentMethod());
                }
            }
        }
        #region  ==========  Event-s для задачи Company-User
        private void Tm_Elapsed_OnEndTask(object sender, System.Timers.ElapsedEventArgs e)
        {
            string s1 = string.Format(string.Format("Event WARTING - Tm_Elapsed_OnEndTask. Name th: {0}, Thread-Id: {1}, State: {2}",
                th_cmp.Name, th_cmp.ManagedThreadId.ToString("X4"), th_cmp.ThreadState));
            FileEventLog.WriteWarting(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            th_cmp.Abort();
            th_cmp = null;
            GC.Collect();
        }
        private void Act_company_OnEndTask(int Num, string Mess)
        {
            string s1 = string.Format(string.Format("Event OK - Act_company_OnEndTask. Class: {0}, Name th: {1}, Thread-Id: {2}, State: {3}",
                Num, th_cmp.Name, th_cmp.ManagedThreadId.ToString("X4"), th_cmp.ThreadState));
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            //th_cmp.Abort();
            th_cmp = null;
            tm_cmp.Stop();
            GC.Collect();
        }
        #endregion 

        #region  ==========  Запуск и остановка  ==========
        [NumFunction(2)]
        public void Start()
        {
            tm.AutoReset = true;
            tm.Interval = 90000;
            tm.Enabled = true;
            tm.Start();
            FileEventLog.WriteOk(this, "Trigger timer started.", System.Reflection.MethodInfo.GetCurrentMethod());
        }
        [NumFunction(3)]
        public void Stop()
        {
            IsStart = false;
            tm.Stop();
            tm.Enabled = false;
            tm.Dispose();
            FileEventLog.WriteOk(this, "Trigger timer stopped.", System.Reflection.MethodInfo.GetCurrentMethod());
        }
        #endregion
    }
}
