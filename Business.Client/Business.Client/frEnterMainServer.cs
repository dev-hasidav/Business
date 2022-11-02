using Business.Atributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business.Client
{
    [NumClass(20)]
    public partial class frEnterMainServer : System.Windows.Forms.Form
    {
        public frEnterMainServer()
        {
            InitializeComponent();
        }
        private void frEnterMainServer_Load(object sender, EventArgs e)
        {
            txtIP.Text = Setup.cl_Stpsrv.NameHost;
            numPort.Value = Setup.cl_Stpsrv.Port;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int n2 = 43690;
                Setup.cl_Connect = null;
                int n1 = Setup.cl_Connect.TestServer(n2++);
                if (n2 == n1)
                {
                    Setup.cl_Stpsrv.IsSave = true;
                    Setup.SaveSetup();
                    MessageBox.Show("Соединение с MAIN-server установленно", "Проверка соединения",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("При попытки проверки соединения с MAIN-server возникла ошибка. " +
                        "\rПроверьте правельность введённых данных.",
                        "Проверка соединения",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("При попытки проверки соединения с MAIN-server возникла ошибка. " +
                    e1.Message +
                    "\rПроверьте правельность введённых данных.",
                    "Проверка соединения",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            Setup.cl_Stpsrv.NameHost = txtIP.Text;
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            Setup.cl_Stpsrv.Port = (int)numPort.Value;
        }
    }
}
