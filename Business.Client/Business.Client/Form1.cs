using Business.Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business.Client
{
    public partial class Form1 : Form
    {
        private string s_BkPc = "\r\n";
        private int NumCheck = 1;
        private bool bStatusError = false;
        private bool bFirstStart = true;
        private int Interval_Start = 2000;
        private int Interval_Rab = 1000 * 60;
        private System.Timers.Timer tm = null;
        private System.Timers.Timer tm_curDate = null;
        private Color cl_Error = Color.Coral;
        private Color cl_Ok = Color.GreenYellow;
        private List<Models.Servers> li_srv = new List<Models.Servers>();
        private BindingSource bin_Srv = new BindingSource();
        private BindingSource bin_TaskLog = new BindingSource();
        private BindingSource bin_Task = new BindingSource();
        private List<Models.Task> li_tsk = new List<Models.Task>();
        private bool IsTime = true;

        public Setup SetupSettings { get; set; }

        #region  ==========  Constructor +  ==========
        public Form1()
        {
            InitializeComponent();
            btnServerAdd.Enabled = btnServerDelete.Enabled = btnServerReload.Enabled = btnServerUpdate.Enabled =
                btnReloadTask.Enabled = btnTaskCreate.Enabled = btnTaskUpdate.Enabled = btnTaskDelete.Enabled = false;
            treViewTasks.Nodes.Clear();
            dtgViewTaskLog.AutoGenerateColumns = dtgServers.AutoGenerateColumns = false;
            MainError();
            SqlError();
            ServersError();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!InitAll())
            {
                return;
            }
            BindingTask();
            RunTimers();
            lblCurrentDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            tm_curDate = new System.Timers.Timer(1000);
            tm_curDate.AutoReset = true;
            tm_curDate.Elapsed += Tm_curDate_Elapsed;
            tm_curDate.Enabled = true;
            tm_curDate.Start();
            btnServerAdd.Enabled = btnServerDelete.Enabled = btnServerReload.Enabled = btnServerUpdate.Enabled =
                            btnReloadTask.Enabled = btnTaskCreate.Enabled = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            IsTime = false;
            if (tm_curDate != null)
            {
                tm_curDate.Enabled = false;
                tm_curDate.Stop();
            }
            System.Threading.Thread.Sleep(1000);
        }

        private void Tm_curDate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (IsTime) Invoke(new dEntry(ChangCurrentDate));
            }
            catch (Exception)
            {
            }
        }
        private void ChangCurrentDate()
        {
            lblCurrentDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        private bool InitAll()
        {
            bool b1 = false;
            InitClient();
            if (!InitMainSql())
            {
                MessageBox.Show("Нет соединения с MAIN сервером");
                return b1;
            }
            if (!InitServers())
            {
                MessageBox.Show("Нет соединения с SQL сервером");
                return b1;
            }
            if (!InitTasks())
            {
                MessageBox.Show("Невозможно проверить список задач");
                return b1;
            }
            return true;
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void BindingTask()
        {

            Binding bndTs = new Binding("Text", bin_Task, "Id")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtId.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "Name")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtTaskName.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "Param.Action")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            bndTs.Format += Bnd_ActionFormat;
            txtTaskAction.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "Param.DateLastRun")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            bndTs.Format += Bnd_DateFormat;
            txtTaskDateLast.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "DateRun")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            bndTs.Format += Bnd_DateFormat;
            txtTaskDateNext.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "ServerSource.Name")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtTaskDataSource.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "ServerReceiver.Name")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtTaskDectination.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "Param.Schedule.Interval")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtTaskPeriod.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "Param.IdGuid")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtTaskMessage.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", bin_Task, "MessageSchedule")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtTaskIntervalTimer.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", bin_Task, "IsRun")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            chkRaskIsRun.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", bin_Task, "IsError")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            chkTaskIsError.DataBindings.Add(bndTs);

        }

        private void Bnd_DateFormat(object sender, ConvertEventArgs e)
        {
            DateTimeOffset dt = (DateTimeOffset)e.Value;
            e.Value = dt.ToLocalTime().DateTime;
        }
        private void Bnd_ActionFormat(object sender, ConvertEventArgs e)
        {
            ActionProperty ap = new ActionProperty((Actions)e.Value);
            e.Value = ap.ViewName;
        }
        #endregion

        #region  ==========  Tasks  ==========

        private bool InitTasks()
        {
            bool b1 = false;
            try
            {
                ResponseResult rr = Setup.cl_Connect.GetTasks();
                if (rr.IsError)
                {
                    MessageBox.Show(rr.Message);
                    return b1;
                }
                li_tsk = (List<Models.Task>)rr.Sender;
                if (li_tsk == null)
                {
                    li_tsk = new List<Models.Task>();
                }
                treViewTasks.Nodes.Clear();
                foreach (Models.Task tsk in li_tsk)
                {
                    TreeNode tn = new TreeNode();
                    if(tsk.ListChilden.Count==0) tn.Text = string.Format("{0}", tsk.Name);
                    else tn.Text = string.Format("({0}) {1}", tsk.ListChilden.Count, tsk.Name);
                    tn.Tag = tsk;
                    treViewTasks.Nodes.Add(tn);
                    _InitTree(tn, tsk);
                }
                if (treViewTasks.Nodes.Count != 0)
                {
                    treViewTasks.SelectedNode = treViewTasks.Nodes[0];
                    //treViewTasks_Click(null, null);
                }
                b1 = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
                    return b1;
        }
        private void _InitTree(TreeNode tn, Models.Task tsk)
        {
            foreach (Models.Task tsk_1 in tsk.ListChilden)
            {
                TreeNode tn_1 = new TreeNode();
                if (tsk_1.ListChilden.Count == 0) tn_1.Text = string.Format("{0}", tsk_1.Name);
                else tn_1.Text = string.Format("({0}) {1}", tsk_1.ListChilden.Count, tsk_1.Name);
                tn_1.Tag = tsk_1;
                tn.Nodes.Add(tn_1);
                _InitTree(tn_1, tsk_1);
            }
        }
        private void btnTaskReload_Click(object sender, EventArgs e)
        {
            treViewTasks.Nodes.Clear();
            InitTasks();
        }
        private void btnTaskCreate_Click(object sender, EventArgs e)
        {
            Models.Task tsk = treViewTasks.SelectedNode.Tag as Models.Task;
            if (tsk == null) return;

            Forms.CreateTaskYear ctYear = new Forms.CreateTaskYear();
            ctYear.SetupSettings = this.SetupSettings;
            if (ctYear.ShowDialog(this) == DialogResult.OK) {
               
            }
            

            Forms.CreateTask ct = new Forms.CreateTask();
            ct.IsNew = true;
            ct.Parentt = tsk;
            try
            {
                if (ct.ShowDialog(this) == DialogResult.OK)
                {
                    ResponseResult rr = Setup.cl_Connect.AddTask(ct.Ts);
                    if (rr.IsError)
                    {
                        MessageBox.Show(rr.Message);
                    }
                    else
                    {
                        Models.Task tsk_1 = rr.Sender as Models.Task;
                        if (tsk_1 != null)
                        {
                            TreeNode tn = new TreeNode();
                            if (tsk_1.ListChilden.Count == 0) tn.Text = string.Format("{0}", tsk_1.Name);
                            else tn.Text = string.Format("({0}) {1}", tsk_1.ListChilden.Count, tsk_1.Name);
                            tn.Tag = tsk_1;
                            treViewTasks.SelectedNode.Nodes.Add(tn);
                            treViewTasks.SelectedNode = tn;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void btnTaskUpdate_Click(object sender, EventArgs e)
        {
            Models.Task tsk = treViewTasks.SelectedNode.Tag as Models.Task;
            if (tsk == null) return;
            Forms.CreateTask ct = new Forms.CreateTask(tsk);
            ct.IsNew = false;
            ct.Parentt = tsk.Parent;
            try
            {
                if (ct.ShowDialog(this) == DialogResult.OK)
                {
                    ResponseResult rr = Setup.cl_Connect.UpdateTask(ct.Ts);
                    if (rr.IsError)
                    {
                        MessageBox.Show(rr.Message);
                    }
                    else
                    {
                        treViewTasks_AfterSelect(this, new TreeViewEventArgs(treViewTasks.SelectedNode));
                        //Models.Task tsk_1 = rr.Sender as Models.Task;
                        //if (tsk_1 != null)
                        //{
                        //    TreeNode tn = new TreeNode();
                        //    tn.Text = string.Format("({0}) {1}", tsk_1.Id, tsk_1.Name);
                        //    tn.Tag = tsk_1;
                        //    treViewTasks.SelectedNode = tn;
                        //    this.Focus();
                        //}
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void btnTaskDelete_Click(object sender, EventArgs e)
        {
            Models.Task tsk = treViewTasks.SelectedNode.Tag as Models.Task;
            if (tsk == null) return;
            try
            {
                string s1 = string.Format("Are you sure you want to delete the task '{0}' ???", tsk.Name);
                if (MessageBox.Show(s1, "Delete task", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ResponseResult rr = Setup.cl_Connect.DelTask(tsk);
                    if (rr.IsError)
                    {
                        MessageBox.Show(rr.Message);
                    }
                    else
                    {
                        Models.Task tsk_1 = rr.Sender as Models.Task;
                        if (tsk_1 != null)
                        {
                            treViewTasks.Nodes.Remove(treViewTasks.SelectedNode);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void treViewTasks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Models.Task tsk1 = e.Node.Tag as Models.Task;
            ResponseResult rr = Setup.cl_Connect.GetTask(tsk1.Id);
            if (rr == null)
            {
                MessageBox.Show("Error get Task");
                return;
            }
            if (rr.IsError)
            {
                MessageBox.Show(rr.Message);
                return;
            }
            Models.Task tsk = (Models.Task)rr.Sender;
            tsk.Parent = tsk1.Parent;
            e.Node.Tag = tsk;

            if (tsk.IdParent == 0)
            {
                btnTaskDelete.Enabled = btnTaskUpdate.Enabled = false;
                splitContainer2.Panel1Collapsed = true;
            }
            else
            {
                btnTaskDelete.Enabled = btnTaskUpdate.Enabled = true;
                splitContainer2.Panel1Collapsed = false;
            }
            DateTimeOffset dtP = DateTimeOffset.Now.AddDays(-1).ToUniversalTime();
            List<Models.TasksLog> li_TLog = Setup.cl_Connect.GetTasksLog(tsk.Id, dtP);
            bin_TaskLog.DataSource = li_TLog;
            dtgViewTaskLog.DataSource = bin_TaskLog;
            bin_Task.DataSource = tsk;
        }

        #endregion

        #region  =========  Property main  ==========

        #region  ===================  Client  =======
        private void InitClient()
        {
            txtClientIP.Text = Setup.cl_Stpsrv.NameHost;
            numClientPort.Value = Setup.cl_Stpsrv.Port;
        }
        private void btnClientUpdate_Click(object sender, EventArgs e)
        {
            MainError();
            InitClient();
            if (tm != null)
            {
                tm.Interval = Interval_Start;
                tm.Enabled = true;
                tm.Start();
            }
        }
        private void btnClientSave_Click(object sender, EventArgs e)
        {
            Setup.cl_Connect = null;
            Setup.cl_Stpsrv.IsSave = true;
            Setup.SaveSetup();
            if (tm != null)
            {
                tm.Interval = Interval_Start;
                tm.Enabled = true;
                tm.Start();
            }
        }
        private void btnClientCheck_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try
            {
                sw.Reset();
                sw.Start();
                int n2 = 43340;
                int n1 = Setup.cl_Connect.TestServer(n2++);
                if (n2 == n1)
                {
                    Setup.cl_Stpsrv.IsSave = true;
                    Setup.SaveSetup();
                    sw.Stop();
                    MessageBox.Show(string.Format("Соединение с MAIN-server установленно.\r  OK.  Time: {0}", sw.Elapsed), "Проверка соединения",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sw.Stop();
                    MessageBox.Show("При попытки проверки соединения с MAIN-server возникла ошибка. " +
                        "\rПроверьте правельность введённых данных." + string.Format("\rTime: {0}", sw.Elapsed),
                        "Проверка соединения",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                sw.Stop();
                MessageBox.Show("При попытки проверки соединения с MAIN-server возникла ошибка.\r" +
                    e1.Message +
                    "\rПроверьте правельность введённых данных." + string.Format("\rTime: {0}", sw.Elapsed),
                    "Проверка соединения",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtClientIP_TextChanged(object sender, EventArgs e)
        {
            Setup.cl_Stpsrv.NameHost = txtClientIP.Text;
        }
        private void numClientPort_ValueChanged(object sender, EventArgs e)
        {
            Setup.cl_Stpsrv.Port = (int)numClientPort.Value;
        }

        #endregion

        #region  ===================  SQL main  =======

        private bool InitMainSql()
        {
            bool b1 = false;
            try
            {
                InfoSql inf = Setup.cl_Connect.GetPropertySqlMain();
                txtSqlIpOrHost.Text = inf.NameServerOrIp;
                txtSqlUser.Text = inf.User;
                txtSqlPass.Text = inf.Password;
                b1 = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            return b1;
        }
        private void btnSqlUpdate_Click(object sender, EventArgs e)
        {
            SqlError();
            InitMainSql();
            if (tm != null)
            {
                tm.Interval = Interval_Start;
                tm.Enabled = true;
                tm.Start();
            }
        }
        private void btnSqlSave_Click(object sender, EventArgs e)
        {
            try
            {
                InfoSql inf = new InfoSql
                {
                    NameServerOrIp = txtSqlIpOrHost.Text,
                    User = txtSqlUser.Text,
                    Password = txtSqlPass.Text
                };
                inf = Setup.cl_Connect.SetPropertySqlMain(inf);
                txtSqlIpOrHost.Text = inf.NameServerOrIp;
                txtSqlUser.Text = inf.User;
                txtSqlPass.Text = inf.Password;
                if (tm != null)
                {
                    tm.Interval = Interval_Start;
                    tm.Enabled = true;
                    tm.Start();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void btnSqlViewPass_Click(object sender, EventArgs e)
        {
            if (txtSqlPass.PasswordChar == char.MinValue)
            {
                txtSqlPass.PasswordChar = char.Parse("*");
            }
            else
            {
                txtSqlPass.PasswordChar = char.MinValue;
            }
        }

        #endregion

        #region  ===================  Server-s  =======

        private bool InitServers()
        {
            bool b1 = false;
            try
            {
                ResponseResult rr = Setup.cl_Connect.GetServers();
                if (rr.IsError)
                {
                    MessageBox.Show(rr.Message);
                    return b1;
                }
                li_srv = (List<Models.Servers>)rr.Sender;
                if (li_srv == null)
                {
                    li_srv = new List<Models.Servers>();
                }
                foreach (Models.Servers srv in li_srv)
                {
                    srv.StatusImage = iglStatus.Images[1];
                }
                bin_Srv.DataSource = li_srv;
                dtgServers.DataSource = bin_Srv;
                SetupSettings.ConnectedServers = li_srv;
                b1 = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            return b1;
        }
        private void btnServerReload_Click(object sender, EventArgs e)
        {
            bFirstStart = true;
            NumCheck = 1;
            ServersError();
            InitServers();
            if (tm != null)
            {
                tm.Interval = Interval_Start;
                tm.Enabled = true;
                tm.Start();
            }
        }
        private void btnServerAdd_Click_1(object sender, EventArgs e)
        {
            Forms.CreateServers cs = new Forms.CreateServers();
            cs.IsNew = true;
            try
            {
                if (cs.ShowDialog(this) == DialogResult.OK)
                {
                    ResponseResult rr = Setup.cl_Connect.AddServer(cs.Srv);
                    if (rr.IsError)
                    {
                        MessageBox.Show(rr.Message);
                    }
                    else
                    {
                        Models.Servers srv = rr.Sender as Models.Servers;
                        if (srv != null)
                        {
                            srv.StatusImage= iglStatus.Images[0];
                            li_srv.Add(srv);
                        }
                    }
                    bin_Srv.ResetBindings(false);
                    tm.Interval = Interval_Start;
                    tm.Enabled = true;
                    tm.Start();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void btnServerUpdate_Click(object sender, EventArgs e)
        {
            if (bin_Srv.Current == null)
            {
                MessageBox.Show("Select row");
                return;
            }
            Models.Servers srv = bin_Srv.Current as Models.Servers;
            if (srv == null)
            {
                MessageBox.Show("Select row");
                return;
            }
            try
            {
                Forms.CreateServers cs = new Forms.CreateServers(srv);
                cs.IsNew = false;
                if (cs.ShowDialog(this) == DialogResult.OK)
                {
                    ResponseResult rr = Setup.cl_Connect.UpdateServer(cs.Srv);
                    if (rr.IsError)
                    {
                        MessageBox.Show(rr.Message);
                    }
                    else
                    {
                        Models.Servers srv1 = rr.Sender as Models.Servers;
                        if (srv1 != null)
                        {
                            for (int n1 = 0; n1 < li_srv.Count; n1++)
                            {
                                if (li_srv[n1].Id != srv1.Id) continue;
                                li_srv[n1] = srv1;
                                bin_Srv.ResetBindings(false);
                                break;
                            }
                        }
                    }
                    tm.Interval = Interval_Start;
                    tm.Enabled = true;
                    tm.Start();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void btnServerDelete_Click(object sender, EventArgs e)
        {
            if (bin_Srv.Current == null)
            {
                MessageBox.Show("Select row");
                return;
            }
            Models.Servers srv = bin_Srv.Current as Models.Servers;
            if (srv == null)
            {
                MessageBox.Show("Select row");
                return;
            }
            try
            {
                string s1 = string.Format("Are you sure you want to delete the server '{0}' ???", srv.Name);
                if (MessageBox.Show(s1, "Delete row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                ResponseResult rr = Setup.cl_Connect.DelServer(srv);
                if (rr.IsError)
                {
                    MessageBox.Show(rr.Message);
                }
                else
                {
                    Models.Servers srv1 = rr.Sender as Models.Servers;
                    if (srv1 != null)
                    {
                        for (int n1 = 0; n1 < li_srv.Count; n1++)
                        {
                            if (li_srv[n1].Id != srv1.Id) continue;
                            li_srv.Remove(li_srv[n1]);
                            bin_Srv.ResetBindings(false);
                            break;
                        }
                    }
                }
                tm.Interval = Interval_Start;
                tm.Enabled = true;
                tm.Start();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        #endregion

        #endregion

        #region  ==========  Проверка соединения  ==========
        private void RunTimers()
        {
            tm = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = Interval_Start
            };
            tm.Elapsed += Tm_Elapsed;
            tm.Enabled = true;
            tm.Start();
        }
        private void Tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tm.Stop();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            try
            {
                System.Net.NetworkInformation.Ping pn = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply pr = pn.Send(Setup.cl_Stpsrv.NameHost);
                if (pr.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    string s_buf = System.Text.Encoding.UTF8.GetString(pr.Buffer);
                    string s_mes = string.Format("Status: {0}, Times: {1}, IP: {2}, Byffer: {3}", pr.Status, pr.RoundtripTime, pr.Address, s_buf);
                    this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
                    notifyIcon1.ShowBalloonTip(10, "Check server", s_mes, ToolTipIcon.Error);
                    return;
                }

                int n2 = 14956;
                int n1 = Setup.cl_Connect.TestServer(n2++);
                if (n2 == n1++)
                {
                    Invoke(new dEntry(MainOk));
                    if (Setup.cl_Connect.TestSql())
                    {
                        Invoke(new dEntry(SqlOk));
                        FileEventLog.IsSql = true;
                    }
                    else
                    {
                        FileEventLog.IsSql = false;
                        Invoke(new dEntry(SqlError));
                        this.notifyIcon1.Icon = new System.Drawing.Icon(@"Images\mainiconRed.ico");
                        notifyIcon1.ShowBalloonTip(10, "Check server", "Error connect main SQL.", ToolTipIcon.Error);
                    }
                    bool b1 = false;
                    n1 = 1;
                    int CountErr = 0;
                    List<string> li_err = new List<string>();
                    Invoke(new dEntry(ServersChecking));
                    foreach (Models.Servers srv in li_srv)
                    {
                        if (!srv.IsEnable)
                        {
                            srv.StatusImage = iglStatus.Images[1];
                            continue;
                        }
                        ResponseResult rr = Setup.cl_Connect.CheckServers(srv);
                        if (rr == null)
                        {
                            srv.StatusImage = iglStatus.Images[0];
                            Invoke(new dIntString(ServersToolTip), srv.Id, "Return 'NULL'");
                            b1 = true;
                            li_err.Add(string.Format("{0} )  Return 'NULL'{1}", ++CountErr, s_BkPc));
                        }
                        else if (rr.IsError)
                        {
                            srv.StatusImage = iglStatus.Images[0];
                            Invoke(new dIntString(ServersToolTip), srv.Id, rr.Message);
                            li_err.Add(string.Format("{0} )  {1}{2}", ++CountErr, rr.Message, s_BkPc));
                            b1 = true;
                        }
                        else
                        {
                            srv.StatusImage = iglStatus.Images[2];
                            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"-\d*-\d*");
                            System.Text.RegularExpressions.Match mt = rg.Match(srv.Remark);
                            string s2 = string.Format("-{0}-{1}", NumCheck, n1++);
                            if (mt.Success)
                            {
                                srv.Remark = rg.Replace(srv.Remark, s2);
                            }
                            else
                            {
                                srv.Remark += s2;
                            }
                            b1 |= false;
                            Invoke(new dIntString(ServersToolTip), srv.Id, "Ok");
                        }
                    }
                    if (b1)
                    {
                        if ((bStatusError != b1) || bFirstStart)
                        {
                            string s1 = string.Format("Found {1} errors{0}", s_BkPc, CountErr);
                            foreach (string item in li_err)
                            {
                                s1 += item;
                            }
                            notifyIcon1.ShowBalloonTip(10, "Check server", s1, ToolTipIcon.Error);
                            this.notifyIcon1.Icon = new System.Drawing.Icon(@"Images\mainiconRed.ico");
                            bFirstStart = false;
                        }
                        Invoke(new dEntry(ServersError));
                    }
                    else
                    {
                        if ((bStatusError != b1) || bFirstStart)
                        {
                            this.notifyIcon1.Icon = new System.Drawing.Icon(@"Images\mainicon.ico");
                            notifyIcon1.ShowBalloonTip(10, "Check server", "Ok", ToolTipIcon.Info);
                            bFirstStart = false;
                        }
                        Invoke(new dEntry(ServersOk));
                    }
                    bStatusError = b1;
                    Invoke(new dEntry(ServersFocus));
                }
                else
                {
                    Invoke(new dEntry(MainError));
                    this.notifyIcon1.Icon = new System.Drawing.Icon(@"Images\mainiconRed.ico");
                    notifyIcon1.ShowBalloonTip(10, "Check server", "Error connect main server.", ToolTipIcon.Error);
                }
            }
            catch (Exception e1)
            {
                Invoke(new dEntry(SqlError));
                Invoke(new dEntry(MainError));
                Invoke(new dEntry(ServersError));
                this.notifyIcon1.Icon = new System.Drawing.Icon(@"Images\mainiconRed.ico");
                notifyIcon1.ShowBalloonTip(10, "Check server", e1.Message, ToolTipIcon.Error);
            }
            finally
            {
                if (tm.Interval == Interval_Start)
                {
                    tm.Interval = Interval_Rab;
                }
                NumCheck++;
                if (IsTime) tm.Start();
            }
        }

        private void MainOk()
        {
            tolStatusMainServer.Image = iglStatus.Images[2];
            tolStatusText.Text = "Ok";
        }
        private void MainError()
        {
            tolStatusMainServer.Image = iglStatus.Images[0];
            tolStatusText.Text = "Connect main-server ERROR";
        }
        private void SqlOk()
        {
            tolStatusSqlServer.Image = iglStatus.Images[2];
            tolStatusText.Text = "Ok";
        }
        private void SqlError()
        {
            tolStatusSqlServer.Image = iglStatus.Images[0];
            tolStatusText.Text = "Connect server-SQL ERROR";
        }
        private void ServersOk()
        {
            tolStatusServers.Image = iglStatus.Images[2];
            tolStatusText.Text = "Ok";
        }
        private void ServersChecking()
        {
            tolStatusServers.Image = iglStatus.Images[1];
            tolStatusText.Text = "Checking......";
        }
        private void ServersError()
        {
            tolStatusServers.Image = iglStatus.Images[0];
            tolStatusText.Text = "Connect servers - ERROR";
        }
        private void ServersFocus()
        {
            dtgServers.Refresh();
        }
        private void ServersToolTip(int Id, string Message)
        {
            for (int n1 = 0; n1 < dtgServers.Rows.Count; n1++)
            {
                if ((int)dtgServers.Rows[n1].Cells["clSId"].Value != Id)
                {
                    continue;
                }
                bin_Srv.ResetItem(n1);
                dtgServers.Rows[n1].Cells[0].ToolTipText = Message;
                break;
            }
        }


        #endregion

        private void btnMainTest_Click(object sender, EventArgs e)
        {
            int nErr = 0;
            Pohoda.Xml.ReturnDocXml rp = new Pohoda.Xml.ReturnDocXml();
            //Pohoda.Xml.Packet.Test.responsePack rp = null;
            System.IO.FileStream fs = null;
            try
            {
                nErr = 1;
                string s_xml = @"S:\DevSoft\Business\XmlPohoda\Documents\XML\All\RFullLinks.xml";
                //string s_xml = @"S:\DevSoft\Business\XmlPohoda\Documents\XML\All\RFullGet.xml";
                //string s_xml = @"S:\DevSoft\Business\XmlPohoda\Documents\XML\All\RFv.xml";
                System.IO.FileInfo fi = new System.IO.FileInfo(s_xml);
                if (fi.Exists)
                {
                    nErr = 2;
                    fs = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    nErr = 3;
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Pohoda.Xml.Packet.responsePack));
                    nErr = 4;
                    rp.Packet = (Pohoda.Xml.Packet.responsePack)xs.Deserialize(fs);
                    nErr = 5;

                    bool b1 = rp.IsSuccess;
                    rthTest.Text = "OK";
                    rthTest.AppendText(string.Format("{0}{1}", s_BkPc, rp.Message));
                    foreach (string item in rp.CollectionMessage)
                    {
                        rthTest.AppendText(string.Format("{0}{1}", s_BkPc, item));
                    }
                    //MessageBox.Show("OK ---- OK");
                    nErr = 6;
                }
            }
            catch (Exception e1)
            {
                //MessageBox.Show(nErr.ToString() + " --- " + e1.Message);
                rthTest.Text = e1.Message;
            }
            finally
            {
                fs?.Close();
                nErr++;
            }
        }

        private void dtgViewTaskLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int n1 = dtgViewTaskLog.Columns.IndexOf(dtgViewTaskLog.Columns["clDate"]);
            if (n1 != e.ColumnIndex) return;
            DateTimeOffset dt = (DateTimeOffset)e.Value;
            e.Value = dt.ToLocalTime().DateTime;
        }
    }
}
