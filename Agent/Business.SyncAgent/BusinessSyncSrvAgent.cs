using Business.Atributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Business.SyncAgent
{
    [NumClass(18)]
    public partial class BusinessSyncSrvAgent : ServiceBase
    {
        private FileEventLog el = null;
        public static int NumError { set; get; } = 0;
        public BusinessSyncSrvAgent()
        {
            InitializeComponent();
        }

        [NumFunction(1)]
        protected override void OnStart(string[] args)
        {
            NumError = 1;
            // System.Threading.Thread.Sleep(30 * 1000);

            string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Setup.StartPath = System.IO.Path.GetDirectoryName(s1);

            NumError = 2;
            #region  ==========  Загрузка настроик для программы  ==========

            try
            {
                Setup set = new Setup(Setup.StartPath, "agsnsrv.oml");
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                return;
            }

            #endregion

            NumError = 3;
            #region  ==========  Включение логов  ==========

            el = new FileEventLog(Setup.StartPath, "sna", "AgentBusinessSyncSrv");

            #endregion

            NumError = 4;
            #region  ==========  Настройка подключения к програмному серверу  ========== 

            FileEventLog.WriteOk(this, "Начало подключения к програмному серверу", System.Reflection.MethodInfo.GetCurrentMethod());
            Business.Setup.RemAssecc ra = new Business.Setup.RemAssecc();
            if (!ra.SetupConnectServer(Setup.NameAgentPort, Setup.NameAgentScope, Setup.PortAgent, typeof(Connect.ConnectMainSyncAgent)))
            {
                Exception ex = new Exception("При настройки подключения к програмному серверу возникла ошибка.");
                FileEventLog.WriteErr(this, ex, System.Reflection.MethodInfo.GetCurrentMethod());
                return;
            }
            FileEventLog.WriteOk(this, "Подключение к програмному серверу - УСПЕШНО", System.Reflection.MethodInfo.GetCurrentMethod());

            #endregion
        }

        [NumFunction(2)]
        protected override void OnStop()
        {
            FileEventLog.WriteOk(this, "Остановка сервера", System.Reflection.MethodInfo.GetCurrentMethod());
            Setup.SaveSetup();
            el?.EndLogin();
        }
    }
}
