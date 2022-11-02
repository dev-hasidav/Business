using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Business.Client.Forms
{
    public partial class CreateTask : System.Windows.Forms.Form
    {
        public bool IsNew { set; get; } = true;
        public bool IsParent { set; get; } = true;
        public bool IsNewFirst { set; get; } = true;
        public TypeTasks IsTrigger { set; get; } = TypeTasks.None;
        public Models.Task Parentt { set; get; }
        public Business.Models.Task Ts { set; get; }
        private List<Models.Servers> li_srvS;
        private List<Models.Servers> li_srvD;
        private BindingSource binTs = new BindingSource();
        private BindingSource binServerSource = new BindingSource();
        private BindingSource binServerReceiver = new BindingSource();
        private BindingSource binParam = new BindingSource();

        #region  ==========  Конструктор  ==========
        public CreateTask()
        {
            InitializeComponent();
            Ts = new Business.Models.Task();
        }
        public CreateTask(Models.Task Tsk)
        {
            InitializeComponent();
            Ts = Tsk;
        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            DateTimeOffset dt_cur = DateTimeOffset.Now.ToUniversalTime();
            if (IsNew)
            {
                Text = "Create task";
                Ts.Id = 100000;
                Ts.Parent = Parentt;
                Ts.IdParent = Parentt.Id;
                Ts.Param.Schedule.Interval = Period.Once;
            }
            else
            {
                Text = "Edit task";
                Parentt = Ts.Parent;
            }
            Models.Task tsk_1 = Ts;
            while (tsk_1.Parent != null)
            {
                tsk_1 = tsk_1.Parent;
            }
            IsTrigger = tsk_1.Id == 2 ? TypeTasks.Trigger : TypeTasks.Schedule;
            IsParent = Parentt.Parent == null;
            if (IsParent)
            {
                if (IsTrigger == TypeTasks.Trigger)
                {
                    lblTypeTask.Text = string.Format("{0} a parent trigger task",
                        IsNew ? "Creating" : "Editing");
                }
                else
                {
                    lblTypeTask.Text = string.Format("Scheduled parent task {0}",
                        IsNew ? "creation" : "editing");
                }
                lblChilden.Text = "";
            }
            else
            {
                if (IsTrigger == TypeTasks.Trigger)
                {
                    lblTypeTask.Text = string.Format("{0} a child trigger task",
                        IsNew ? "Creating" : "Editing");
                }
                else
                {
                    lblTypeTask.Text = string.Format("Scheduled child task {0}",
                        IsNew ? "creation" : "editing");
                }
                lblChilden.Text = string.Format("Parent task: {0} ({1})", Parentt.Name, Parentt.Id);
                if (IsNew) Ts.Param.Schedule.Interval = Period.TimeParent;
            }
            Ts.IsTrigers = IsTrigger;
            if (IsTrigger == TypeTasks.Trigger)
            {
                lnkSchedule.Visible = false;
            }
            _TaskBinding();
            IsNewFirst = false;
        }
        private void _TaskBinding()
        {

            #region  ==========  Ts

            binTs.DataSource = Ts;

            Binding bndTs = new Binding("Text", binTs, "Name")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtCreateTaskName.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", binTs, "IsRun")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskRun.DataBindings.Add(bndTs);

            bndTs = new Binding("Text", binTs, "MessageSchedule")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.Never
            };
            txtSchedule.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Server

            binServerSource.DataSource = binTs;
            binServerSource.DataMember = "ServerSource";
            binServerReceiver.DataSource = binTs;
            binServerReceiver.DataMember = "ServerReceiver";

            ResponseResult rr = Setup.cl_Connect.GetServers(true);
            if (!rr.IsError)
            {
                li_srvS = (List<Models.Servers>)rr.Sender;
                cmbCreateTaskDataSource.ValueMember = "Id";
                cmbCreateTaskDataSource.DisplayMember = "Name";
                cmbCreateTaskDataSource.DataSource = li_srvS;
                if ((IsNew) && (li_srvS.Count != 0))
                {
                    Ts.ServerSource = li_srvS[0];
                }
                bndTs = new Binding("Text", binServerSource, "Name")
                {
                    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                    DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                };
                cmbCreateTaskDataSource.DataBindings.Add(bndTs);
            }

            rr = Setup.cl_Connect.GetServers(true);
            if (!rr.IsError)
            {
                li_srvD = (List<Models.Servers>)rr.Sender;
                cmbCreateTaskDestimation.ValueMember = "Id";
                cmbCreateTaskDestimation.DisplayMember = "Name";
                cmbCreateTaskDestimation.DataSource = li_srvD;
                if ((IsNew) && (li_srvD.Count != 0))
                {
                    Ts.ServerReceiver = li_srvD[0];
                }
                bndTs = new Binding("Text", binServerReceiver, "Name")
                {
                    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                    DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                };
                cmbCreateTaskDestimation.DataBindings.Add(bndTs);
            }

            #endregion

            #region  ==========  Ts Param
            binParam.DataSource = Ts.Param;

            cmbCreateTaskAction.DisplayMember = "ViewName";
            cmbCreateTaskAction.ValueMember = "Action";
            if (IsTrigger == TypeTasks.Schedule) cmbCreateTaskAction.DataSource = ActionProperty.ListSchedule();
            else cmbCreateTaskAction.DataSource = ActionProperty.ListTrigger();
            bndTs = new Binding("SelectedValue", binParam, "Action")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += Bnd_FormatAction;
            bndTs.Parse += Bnd_ParseAction;
            cmbCreateTaskAction.DataBindings.Add(bndTs);

            //cmbCreateTaskAction.DataSource = Funcs.EnumsFn.GetCollectionEnum(typeof(Actions));
            //bndTs = new Binding("Text", binParam, "Action")
            //{
            //    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
            //    DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            //};
            //bndTs.Format += Bnd_FormatAction;
            //bndTs.Parse += Bnd_ParseAction;
            //cmbCreateTaskAction.DataBindings.Add(bndTs);
            #endregion

            binTs.ResetBindings(false);
        }


        #region  ==========  bin event  ==========
        private void Bnd_ParseAction(object sender, ConvertEventArgs e)
        {
            object o1 = e.Value;
            Actions ac = (Actions)Funcs.EnumsFn.GetIdEnum(typeof(Actions), e.Value.ToString());
            e.Value = ac;
        }

        private void Bnd_FormatAction(object sender, ConvertEventArgs e)
        {
            e.Value = (int)e.Value;
        }

        #endregion

        #endregion


        #region  ==========  Exit  ==========
        private void btnOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Ts.Name))
            {
                MessageBox.Show("Enter 'Name");
                txtCreateTaskName.Focus();
                return;
            }
            if((Ts.ServerSource.Type== TypeServers.MsSql)||(Ts.ServerSource.Type== TypeServers.PohodaXml))
            {
                if (Ts.Param.CollectionBaseSource.Count == 0)
                {
                    MessageBox.Show("You must select a database(s) of data source data");
                    lstSServer.Focus();
                    return;
                }
            }
            if((Ts.ServerReceiver.Type== TypeServers.MsSql)||(Ts.ServerReceiver.Type== TypeServers.PohodaXml))
            {
                if (Ts.Param.CollectionBaseReceiver.Count == 0)
                {
                    MessageBox.Show("You must select the data receiver database(s)");
                    lstDServer.Focus();
                    return;
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        private void cmbCreateTaskDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n1 = int.Parse(cmbCreateTaskDataSource.SelectedValue.ToString());
            foreach (Models.Servers srv in li_srvS)
            {
                if (srv.Id != n1) continue;
                Ts.ServerSource = srv;
                break;
            }
            _LoadBasePohodaS(Ts.ServerSource, true);
        }
        private void cmbCreateTaskDestimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n1 = int.Parse(cmbCreateTaskDestimation.SelectedValue.ToString());
            foreach (Models.Servers srv in li_srvD)
            {
                if (srv.Id != n1) continue;
                Ts.ServerReceiver = srv;
                break;
            }
            _LoadBasePohodaS(Ts.ServerReceiver, false);
        }
        private void _LoadBasePohodaS(Models.Servers srv, bool IsSource)
        {
            if ((srv.Type == TypeServers.MsSql) || (srv.Type == TypeServers.PohodaXml))
            {
                ResponseResult rr = Setup.cl_Connect.GetListBase(srv);
                if (!rr.IsError)
                {
                    ListView lvS = null;
                    ListView lvD = null;
                    List<Models.InfoBasePohoda> li_D = null;
                    List<Models.InfoBasePohoda> li_S = (List<Models.InfoBasePohoda>)rr.Sender;

                    if (IsSource)
                    {
                        lvS = lstSServer;
                        lvD = lstSList;
                        li_D = Ts.Param.CollectionBaseSource;
                    }
                    else
                    {
                        lvS = lstDServer;
                        lvD = lstDList;
                        li_D = Ts.Param.CollectionBaseReceiver;
                    }
                    lvS.Enabled = lvD.Enabled = true;
                    lvS.Items.Clear();
                    lvD.Items.Clear();
                    if (IsNew || !IsNewFirst)
                    {
                        li_D.Clear();
                    }
                    foreach (Models.InfoBasePohoda ibp in li_D)
                    {
                        for (int n1 = li_S.Count - 1; n1 >= 0; n1--)
                        {
                            if (li_S[n1].Id != ibp.Id) continue;
                            li_S.RemoveAt(n1);
                            break;
                        }
                    }
                    foreach (Models.InfoBasePohoda ibp in li_S)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = ibp.Rok.ToString();
                        lvi.SubItems.Add(ibp.Soubor);
                        lvi.SubItems.Add(ibp.Firma);
                        lvi.Tag = ibp;
                        lvS.Items.Add(lvi);
                    }
                    foreach (Models.InfoBasePohoda ibp in li_D)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = ibp.Rok.ToString();
                        lvi.SubItems.Add(ibp.Soubor);
                        lvi.SubItems.Add(ibp.Firma);
                        lvi.Tag = ibp;
                        lvD.Items.Add(lvi);
                    }
                }
            }
            else
            {
                if (IsSource)
                {
                    lstSList.Items.Clear();
                    lstSServer.Items.Clear();
                    lstSServer.Enabled = lstSList.Enabled = false;
                }
                else
                {
                    lstDServer.Items.Clear();
                    lstDList.Items.Clear();
                    lstDServer.Enabled = lstDList.Enabled = false;
                }
            }
        }
        private void btnAddS_Click(object sender, EventArgs e)
        {
            if (lstSServer.SelectedItems == null) return;
            if (lstSServer.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lst_ibp in lstSServer.SelectedItems)
                {
                    bool b1 = true;
                    Models.InfoBasePohoda ibp = lst_ibp.Tag as Models.InfoBasePohoda;
                    if (ibp == null) continue;
                    for (int n1 = Ts.Param.CollectionBaseSource.Count - 1; n1 >= 0; n1--)
                    {
                        if (Ts.Param.CollectionBaseSource[n1].Id != ibp.Id) continue;
                        Ts.Param.CollectionBaseSource.RemoveAt(n1);
                        b1 = false;
                        break;
                    }
                    if (b1)
                    {
                        Ts.Param.CollectionBaseSource.Add(ibp);
                        lstSServer.Items.Remove(lst_ibp);
                        lstSList.Items.Add(lst_ibp);
                    }
                }
            }
        }
        private void btnDelS_Click(object sender, EventArgs e)
        {
            if (lstSList.SelectedItems == null) return;
            if (lstSList.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lst_ibp in lstSList.SelectedItems)
                {
                    Models.InfoBasePohoda ibp = lst_ibp.Tag as Models.InfoBasePohoda;
                    if (ibp == null) continue;
                    for (int n1 = Ts.Param.CollectionBaseSource.Count - 1; n1 >= 0; n1--)
                    {
                        if (Ts.Param.CollectionBaseSource[n1].Id != ibp.Id) continue;
                        Ts.Param.CollectionBaseSource.RemoveAt(n1);
                        lstSList.Items.Remove(lst_ibp);
                        lstSServer.Items.Add(lst_ibp);
                        break;
                    }
                }
            }
        }
        private void btnAddD_Click(object sender, EventArgs e)
        {
            if (lstDServer.SelectedItems == null) return;
            if (lstDServer.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lst_ibp in lstDServer.SelectedItems)
                {
                    bool b1 = true;
                    Models.InfoBasePohoda ibp = lst_ibp.Tag as Models.InfoBasePohoda;
                    if (ibp == null) continue;
                    for (int n1 = Ts.Param.CollectionBaseReceiver.Count - 1; n1 >= 0; n1--)
                    {
                        if (Ts.Param.CollectionBaseReceiver[n1].Id != ibp.Id) continue;
                        Ts.Param.CollectionBaseReceiver.RemoveAt(n1);
                        b1 = false;
                        break;
                    }
                    if (b1)
                    {
                        Ts.Param.CollectionBaseReceiver.Add(ibp);
                        lstDServer.Items.Remove(lst_ibp);
                        lstDList.Items.Add(lst_ibp);
                    }
                }
            }
        }
        private void btnDelD_Click(object sender, EventArgs e)
        {
            if (lstDList.SelectedItems == null) return;
            if (lstDList.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lst_ibp in lstDList.SelectedItems)
                {
                    Models.InfoBasePohoda ibp = lst_ibp.Tag as Models.InfoBasePohoda;
                    if (ibp == null) continue;
                    for (int n1 = Ts.Param.CollectionBaseReceiver.Count - 1; n1 >= 0; n1--)
                    {
                        if (Ts.Param.CollectionBaseReceiver[n1].Id != ibp.Id) continue;
                        Ts.Param.CollectionBaseReceiver.RemoveAt(n1);
                        lstDList.Items.Remove(lst_ibp);
                        lstDServer.Items.Add(lst_ibp);
                        break;
                    }
                }
            }
        }
        private void lnkSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateSchedule cs = new CreateSchedule();
            cs.Ts = Ts;
            cs.IsParent = IsParent;
            if (cs.ShowDialog(this) == DialogResult.OK)
            {
                Ts = cs.Ts;
                binTs.ResetBindings(false);
            }
        }

    }
}
