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

namespace Business.Sync
{
    /// <summary>
    /// Старт основного сервиса
    /// </summary>
    [NumClass(1)]
    public partial class BusinessSyncSrv : ServiceBase
    {
        private FileEventLog el = null;
        private Business.Main.Timers.TimerTrigger tt_trigger;
        private Business.Main.Timers.Timer tm_Tasks;
        public static int NumError { set; get; } = 0;
        public BusinessSyncSrv()
        {
            InitializeComponent();
        }

        [NumFunction(1)]
        protected override void OnStart(string[] args)
        {
            NumError = 1;
            //System.Threading.Thread.Sleep(30 * 1000);

            string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Setup.StartPath = System.IO.Path.GetDirectoryName(s1);

            NumError = 2;
            #region  ==========  Загрузка настроик для программы  ==========

            try
            {
                Setup set = new Setup(Setup.StartPath, "snsrv.oml");
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                return;
            }

            #endregion

            SqlScripts.NameMainSql = Setup.cl_Stpsrv.IPSql;
            SqlScripts.NameMainBase = Setup.NameMainBase;
            SqlScripts.UserSqlMain = Setup.cl_Stpsrv.User;
            SqlScripts.PasswordSqlMain = Setup.cl_Stpsrv.Password;
            SqlScripts.MainIPSql = Setup.cl_Stpsrv.MainIPSql;
            StaticProperty.PortBase = SqlScripts.Port = Setup.Port;
            StaticProperty.NameScopeBase = SqlScripts.NameScope = Setup.NameScope;
            Business.Setup.RemAssecc.NameAgentScope = Setup.NameAgentScope;
            Business.Setup.RemAssecc.PortAgent = Setup.PortAgent;

            NumError = 3;
            #region  ==========  Включение логов  ==========

            el = new FileEventLog(Setup.StartPath, "sny", "BusinessSyncSrv");

            #endregion

            NumError = 4;
            #region  ==========  Настройка подключения к програмному серверу  ========== 

            FileEventLog.WriteOk(this, "Начало подключения к програмному серверу", System.Reflection.MethodInfo.GetCurrentMethod());
            Business.Setup.RemAssecc ra = new Business.Setup.RemAssecc();
            if (!ra.SetupConnectServer(Setup.NamePort, Setup.NameScope, Setup.Port, typeof(Sync.Main.ConnectMainSync)))
            {
                Exception ex = new Exception("При настройки подключения к програмному серверу возникла ошибка.");
                FileEventLog.WriteErr(this, ex, System.Reflection.MethodInfo.GetCurrentMethod());
                return;
            }
            FileEventLog.WriteOk(this, "Подключение к програмному серверу - УСПЕШНО", System.Reflection.MethodInfo.GetCurrentMethod());

            #endregion

            NumError = 5;
            #region  ==========  Проверка и создание базы  ==========
            FileEventLog.WriteOk(this, "Начало проверки подключения и наличия базы и таблиц",
                System.Reflection.MethodInfo.GetCurrentMethod());
            if (!el.CheckConnectSqlBase())
            {
                Exception ex = new Exception("Проверка и создание базы. - Возникла ошибка.");
                FileEventLog.WriteErr(this, ex, System.Reflection.MethodInfo.GetCurrentMethod());
                return;
            }
            FileEventLog.WriteOk(this, "Проверка подключения и наличия базы и таблиц - УСПЕШНО",
                System.Reflection.MethodInfo.GetCurrentMethod());

            #endregion

            NumError = 6;
            #region  ==========  Запуск TcpListener-Tcp прослушки ==========

            FileEventLog.WriteOk(this, "Начало запуска TcpListener-Tcp прослушки", System.Reflection.MethodInfo.GetCurrentMethod());
            Business.Setup.ListenerByte lb = new Business.Setup.ListenerByte(Setup.PortListener, Setup.Port,
                Setup.NameScope, typeof(Interfases.IConnectMainSync), "RunTaskTriggers");
            lb.StartListener();

            #endregion

            NumError = 7;
            #region  ==========  Запуск таймера задач  ==========
            FileEventLog.WriteOk(this, "Начало запуска таймера задач", System.Reflection.MethodInfo.GetCurrentMethod());
            if (tm_Tasks == null)
            {
                tm_Tasks = new Business.Main.Timers.Timer(Setup.Port, Setup.NameScope);
                tm_Tasks.Start(Setup.cl_Stpsrv.Interval);
            }
            #endregion

            NumError = 8;
            #region  ==========  Запуск таймера триггеров  ==========

            FileEventLog.WriteOk(this, "Начало запуска таймера триггеров", System.Reflection.MethodInfo.GetCurrentMethod());
            tt_trigger = new Business.Main.Timers.TimerTrigger(Setup.Port, Setup.NameScope);
            tt_trigger.Start();

            #endregion

            NumError = 9;
            int n1 = Models.Task.TaskReset();
            if (n1 != 0)
            {
                FileEventLog.WriteOk(this, string.Format("Reset {0} task.", n1),
                    System.Reflection.MethodInfo.GetCurrentMethod());
            }

            NumError = 10;
            FileEventLog.WriteOk(this, "Все узлы службы запущены успешно.", System.Reflection.MethodInfo.GetCurrentMethod());
        }

        [NumFunction(2)]
        protected override void OnStop()
        {
            NumError = 1;
            FileEventLog.WriteOk(this, "Остановка сервера", System.Reflection.MethodInfo.GetCurrentMethod());
            tm_Tasks.Stop();
            tt_trigger.Stop();
            Business.Setup.ListenerByte lb = new Business.Setup.ListenerByte(Setup.PortListener,
                Setup.Port,Setup.NameScope, typeof(Interfases.IConnectMainSync), "");
            lb.StopListener();
            Setup.SaveSetup();
            el?.EndLogin();
            //System.Threading.Thread.Sleep(5 * 1000);
        }
    }
}
