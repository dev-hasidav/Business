using Business.Atributes;
using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Business.Main.Timers
{
    /// <summary>
    /// Таймер задач
    /// </summary>
    [NumClass(3)]
    [Serializable]
    public partial class Timer : Component
    {
        public static int NumError { set; get; } = 0;
        private int FirstStart = 1000 * 60 * 3;
        private int Interval = 60000;
        private bool IsStart = true;
        private int _PortBase;
        private string _NameScopeBase;

        #region  ==========  Конструктор  ==========
        public Timer(int PortBase, string NameScopeBase)
        {
            _PortBase = PortBase;
            _NameScopeBase = NameScopeBase;
            InitializeComponent();
        }

        public Timer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region  ==========  Инициализация и остановка  ==========

        [NumFunction(1)]
        public void Start(int Interval)
        {
            this.Interval = Interval;
            IsStart = tm.AutoReset = true;
            tm.Interval = FirstStart;
            tm.Enabled = true;
            tm.Start();
            FileEventLog.WriteOk(this, "Timer started.", System.Reflection.MethodInfo.GetCurrentMethod());
        }

        [NumFunction(2)]
        public void Stop()
        {
            IsStart = false;
            tm.Stop();
            tm.Enabled = false;
            tm.Dispose();
            FileEventLog.WriteOk(this, "Timer stopped.", System.Reflection.MethodInfo.GetCurrentMethod());
        }

        #endregion

        #region  ==========  Событие таймера и запуск задач  ==========
        private int nCountDiag = 0;
        private int nTimeDiag = 60;

        [NumFunction(3)]
        private void Tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            try
            {
                tm.Stop();
                if (!IsStart)
                {
                    return;
                }
#if DEBUG
                if ((nCountDiag % nTimeDiag) == 0) FileEventLog.WriteOk(this, "Timer task stopped.", System.Reflection.MethodInfo.GetCurrentMethod());
#endif
                NumError = 2;

                string s1 = string.Format(@"http://{0}:{1}/{2}", "localhost", _PortBase, _NameScopeBase);
                Type tt = typeof(Interfases.IConnectMainSync);
                object cl_Connect = Activator.GetObject(tt, s1);
                tt.GetMethod("RunTaskSchedule").Invoke(cl_Connect, null /*new object[] { null }*/);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                sw.Stop();
                //  Проверяем Tm.Interval
                if (tm.Interval != Interval * 60 * 1000)
                {
                    tm.Interval = Interval * 60 * 1000;
                }
                if (IsStart)
                {
                    tm.Start();
#if DEBUG
                    if ((nCountDiag++ % nTimeDiag) == 0) FileEventLog.WriteOk(this, "Timer task started.", System.Reflection.MethodInfo.GetCurrentMethod());
#endif
                }
            }
        }
        #endregion
    }
}
