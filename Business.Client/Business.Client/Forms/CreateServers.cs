using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Business.Client.Forms
{
    public partial class CreateServers : System.Windows.Forms.Form
    {
        /// <summary>
        /// True - Создание новой записи, False - редактирование
        /// </summary>
        public bool IsNew { set; get; } = false;
        public Models.Servers Srv { private set; get; }

        private BindingSource binSrv = new BindingSource();
        private string s_BkPc = "\r\n";

        #region  ==========  Constructors  ==========
        public CreateServers()
        {
            InitializeComponent();
            splInfo.Panel1Collapsed = true;
            IsNew = true;
            binSrv.DataSource = Srv = new Models.Servers();
            Srv.IsEnable = true;
            chkEnable.Checked = true;
            BindingElement();
        }
        public CreateServers(Models.Servers srv)
        {
            InitializeComponent();
            splInfo.Panel1Collapsed = true;
            IsNew = false;
            binSrv.DataSource = Srv = srv;
            BindingElement();
        }
        private void CreateServers_Load(object sender, EventArgs e)
        {
            foreach (Control item in splInfo.Panel2.Controls["pnlAll"].Controls)
            {
                if (!item.Name.StartsWith("grpSrv"))
                {
                    continue;
                }
                item.Visible = false;
                item.Dock = DockStyle.Fill;
                item.Location = new System.Drawing.Point(0, 0);
            }
            if (IsNew)
            {
                Text = "Создагие новой записи о сервере";
                Srv.Type = TypeServers.MsSql;
                //    rbtMSSQL.Checked = true;
            }
            else
            {
                Text = "Редактирование существующей записи";
            }

            if (Srv.Type == TypeServers.MsSql)
            {
                rbtMSSQL.Checked = true;
            }
            else if (Srv.Type == TypeServers.PostgreSQL)
            {
                rbtPostgreSQL.Checked = true;
            }
            else if (Srv.Type == TypeServers.Odoo)
            {
                rbtServerOdoo.Checked = true;
            }
            else if (Srv.Type == TypeServers.PohodaXml)
            {
                rbtPohoda.Checked = true;
            }
            else
            {
                Srv.Type = TypeServers.MsSql;
                rbtMSSQL.Checked = true;
            }
            rbt_CheckedChanged(sender, e);
        }
        private void btnServerOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void btnServerCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void BindingElement()
        {
            #region  ==========  Общее  ==========
            //  Общие  -  IsRemote
            Binding bnd = new Binding("Checked", splInfo, "Panel1Collapsed")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bnd.Parse += Bnd_Inversion;
            bnd.Format += Bnd_Inversion;
            chkRemote.DataBindings.Add(bnd);
            bnd = new Binding("Panel1Collapsed", binSrv, "IsRemote")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bnd.Parse += Bnd_Inversion;
            bnd.Format += Bnd_Inversion;
            splInfo.DataBindings.Add(bnd);
            //  Общие  -  Name
            bnd = new Binding("Text", binSrv, "Name")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtName.DataBindings.Add(bnd);
            //  Общие  -  Enable
            bnd = new Binding("Checked", binSrv, "IsEnable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkEnable.DataBindings.Add(bnd);
            //  Общие  -  PublicPath
            bnd = new Binding("Text", binSrv, "PublicPath")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPublicPath.DataBindings.Add(bnd);
            //  Общие  -  Remark
            bnd = new Binding("Text", binSrv, "Remark")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtRemark.DataBindings.Add(bnd);
            #endregion

            #region  =========  SQL  ==========
            //  SQL  -  SqlHost
            bnd = new Binding("Text", binSrv, "SqlHostIp")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtSqlHost.DataBindings.Add(bnd);
            //  SQL  -  SqlPort
            bnd = new Binding("Value", binSrv, "SqlPort")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            numSqlPort.DataBindings.Add(bnd);
            //  SQL  -  SqlLogin
            bnd = new Binding("Text", binSrv, "SqlUser")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtSqlLogin.DataBindings.Add(bnd);
            //  SQL  -  SqlPassword
            bnd = new Binding("Text", binSrv, "SqlPassword")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtSqlPassword.DataBindings.Add(bnd);
            #endregion

            #region  =========  Rem  ==========
            //  Rem  -  Host
            bnd = new Binding("Text", binSrv, "RemHostIp")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtRemIpOrHost.DataBindings.Add(bnd);
            //  Rem  -  Port
            //bnd = new Binding("Value", binSrv, "RemPort")
            //{
            //    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
            //    DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            //};
            //bnd.Parse += Bnd_Parse;
            //bnd.Format += Bnd_Format;
            //numRemPort.DataBindings.Add(bnd);
            #endregion

            #region  =========  Pohoda  ==========
            //  Pohoda  -  Path
            bnd = new Binding("Text", binSrv, "PohodaPath")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPohodaPath.DataBindings.Add(bnd);
            //  Pohoda  -  User
            bnd = new Binding("Text", binSrv, "PohodaUser")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPohodaLogin.DataBindings.Add(bnd);
            //  Pohoda  -  Password
            bnd = new Binding("Text", binSrv, "PohodaPassword")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPohodaPassword.DataBindings.Add(bnd);
            //  Pohoda  -  SQL  -  SqlHost
            bnd = new Binding("Text", binSrv, "PohodaSqlHostIp")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPohodaHostSQL.DataBindings.Add(bnd);
            //  Pohoda  -  SQL  -  SqlPort
            bnd = new Binding("Value", binSrv, "PohodaSqlPort")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            numPohodaPortSQL.DataBindings.Add(bnd);
            //  Pohoda  -  SQL  -  SqlLogin
            bnd = new Binding("Text", binSrv, "PohodaSqlUser")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPohodaLoginSQL.DataBindings.Add(bnd);
            //  Pohoda  -  SQL  -  SqlPassword
            bnd = new Binding("Text", binSrv, "PohodaSqlPassword")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPohodaPassSQL.DataBindings.Add(bnd);
            #endregion

            #region  =========  Odoo  ==========
            //  Odoo  -  HostIp
            bnd = new Binding("Text", binSrv, "OdooHostIp")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooHost.DataBindings.Add(bnd);
            //  Odoo  -  Port
            bnd = new Binding("Value", binSrv, "OdooPort")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            numOdooPort.DataBindings.Add(bnd);
            //  Odoo  -  User
            bnd = new Binding("Text", binSrv, "OdooUser")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooLogin.DataBindings.Add(bnd);
            //  Odoo  -  Password
            bnd = new Binding("Text", binSrv, "OdooPassword")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooPassword.DataBindings.Add(bnd);
            //  Odoo  -  Base
            bnd = new Binding("Text", binSrv, "OdooBase")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooBase.DataBindings.Add(bnd);

            if (Srv.OdooSqlPort == 0) Srv.OdooSqlPort = 5432;
            //  Odoo  -  Base
            bnd = new Binding("Text", binSrv, "OdooSqlHostIp")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooSqlHost.DataBindings.Add(bnd);
            //  Odoo  -  Base
            bnd = new Binding("Value", binSrv, "OdooSqlPort")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            numOdooSqlPort.DataBindings.Add(bnd);
            //  Odoo  -  Base
            bnd = new Binding("Text", binSrv, "OdooSqlUser")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooSqlLogin.DataBindings.Add(bnd);
            //  Odoo  -  Base
            bnd = new Binding("Text", binSrv, "OdooSqlPassword")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooSqlPassword.DataBindings.Add(bnd);
            //  Odoo  -  Base
            bnd = new Binding("Text", binSrv, "OdooSqlBase")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtOdooSqlBase.DataBindings.Add(bnd);
            #endregion

            #region  =========  Postgre Sql  ==========
            if (Srv.PostgrePort == 0) Srv.PostgrePort = 5432;
            //  Postgre  -  HostIp
            bnd = new Binding("Text", binSrv, "PostgreHostIp")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPostgreHost.DataBindings.Add(bnd);
            //  Postgre  -  Port
            bnd = new Binding("Value", binSrv, "PostgrePort")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            numPostgrePort.DataBindings.Add(bnd);
            //  Postgre  -  User
            bnd = new Binding("Text", binSrv, "PostgreUser")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPostgreUser.DataBindings.Add(bnd);
            //  Postgre  -  Password
            bnd = new Binding("Text", binSrv, "PostgrePassword")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPostgrePassword.DataBindings.Add(bnd);
            //  Postgre  -  Base
            bnd = new Binding("Text", binSrv, "PostgreBase")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            txtPostgreBase.DataBindings.Add(bnd);
            //  Postgre  -  IntegratedSecurity
            bnd = new Binding("Checked", binSrv, "PostgreIntegratedSecurity")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkIntegratedSecurity.DataBindings.Add(bnd);
            //  Postgre  -  UseSslStream
            bnd = new Binding("Checked", binSrv, "PostgreUseSslStream")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkUseSslStream.DataBindings.Add(bnd);


            #endregion
        }
        private void Bnd_Inversion(object sender, ConvertEventArgs e)
        {
            e.Value = !(bool)e.Value;
        }

        #endregion

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            txtSqlPassword.PasswordChar = txtOdooPassword.PasswordChar = txtPohodaPassword.PasswordChar = char.Parse("*");
            foreach (Control item in splInfo.Panel2.Controls["pnlAll"].Controls)
            {
                if (!item.Name.StartsWith("grpSrv"))
                {
                    continue;
                }
                item.Visible = false;
            }
            if (rbtMSSQL.Checked)
            {
                Srv.Type = TypeServers.MsSql;
                grpSrvSql.Visible = true;
            }
            else if (rbtServerOdoo.Checked)
            {
                Srv.Type = TypeServers.Odoo;
                grpSrvOdoo.Visible = true;
            }
            else if (rbtPohoda.Checked)
            {
                Srv.Type = TypeServers.PohodaXml;
                grpSrvPohoda.Visible = true;
            }
            else if (rbtPostgreSQL.Checked)
            {
                Srv.Type = TypeServers.PostgreSQL;
                grpSrvPostgre.Visible = true;
            }
        }

        private void btnServerCheckConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Srv.Name))
            {
                string s1 = string.Format("You must enter a server name.");
                MessageBox.Show(s1);
                rthServerViewRezult.Text = s1;
                txtName.Focus();
                return;
            }
            rthServerViewRezult.Text = "";

            ResponseResult ret = Setup.cl_Connect.CheckServers(Srv);
            rthServerViewRezult.Text = string.Format("Date: {0}", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fff"));
            rthServerViewRezult.AppendText(string.Format("{1}Checking server connection {0}.", Srv.Type, s_BkPc));
            if (ret == null)
            {
                rthServerViewRezult.ForeColor = System.Drawing.Color.Red;
                rthServerViewRezult.AppendText(string.Format("{0}Return: {1}", s_BkPc, "Возвращён NULL"));
            }
            else
            {
                if (ret.IsError)
                {
                    rthServerViewRezult.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    rthServerViewRezult.ForeColor = System.Drawing.Color.Black;
                }
                rthServerViewRezult.AppendText(string.Format("{0}, Status: {1}, Number: {2}",
                    s_BkPc, ret.Status, ret.Number));
                rthServerViewRezult.AppendText(string.Format("{0}{1}", s_BkPc, ret.Message));
                int n1 = 1;
                foreach (string item in ret.ListMessage)
                {
                    rthServerViewRezult.AppendText(string.Format("{0}{1})  {2}",
                        s_BkPc, n1++, item));
                }
            }
            rthServerViewRezult.ScrollToCaret();
        }

        private void btnPohodaViewPass_Click(object sender, EventArgs e)
        {
            if (txtPohodaPassword.PasswordChar == char.MinValue)
            {
                txtPohodaPassword.PasswordChar = char.Parse("*");
            }
            else
            {
                txtPohodaPassword.PasswordChar =char.MinValue;
            }
        }
        private void btnSqlViewPass_Click(object sender, EventArgs e)
        {
            if (txtSqlPassword.PasswordChar == char.MinValue)
            {
                txtSqlPassword.PasswordChar = char.Parse("*");
            }
            else
            {
                txtSqlPassword.PasswordChar = char.MinValue;
            }
        }
        private void txtOdooViewPassword_Click(object sender, EventArgs e)
        {
            if (txtOdooPassword.PasswordChar == char.MinValue)
            {
                txtOdooPassword.PasswordChar = char.Parse("*");
            }
            else
            {
                txtOdooPassword.PasswordChar = char.MinValue;
            }
        }
        private void txtOdooSqlViewPassword_Click(object sender, EventArgs e)
        {
            if (txtOdooSqlPassword.PasswordChar == char.MinValue)
            {
                txtOdooSqlPassword.PasswordChar = char.Parse("*");
            }
            else
            {
                txtOdooSqlPassword.PasswordChar = char.MinValue;
            }
        }
        private void txtPostgreViewPassword_Click(object sender, EventArgs e)
        {
            if (txtPostgrePassword.PasswordChar == char.MinValue)
            {
                txtPostgrePassword.PasswordChar = char.Parse("*");
            }
            else
            {
                txtPostgrePassword.PasswordChar = char.MinValue;
            }
        }
    }
}
