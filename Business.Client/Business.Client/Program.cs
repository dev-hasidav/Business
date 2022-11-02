using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business.Client
{
    [NumClass(19)]
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        [NumFunction(1)]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Setup.StartPath = System.IO.Path.GetDirectoryName(s1);

            Setup set = new Setup(Setup.StartPath, "sncln.oml");
            int n2 = 43690;
            int n1 = 0;
            try
            {
                Business.Setup.RemAssecc ra = new Business.Setup.RemAssecc();
                ra.SetupConnectClient(Setup.cl_Stpsrv.Port, Setup.NameScope);
                n1 = Setup.cl_Connect.TestServer(n2++);
            }
            catch (Exception)
            {
            }
            if (n2 != n1)
            {
                frEnterMainServer fr_serv = new frEnterMainServer();
                fr_serv.ShowDialog();
                fr_serv.Dispose();
            }
            else
            {
                Setup.IsConnectServer = true;
            }

            Form1 fr = new Form1();
            fr.SetupSettings = set;
            Application.Run(fr);
        }
    }
}
