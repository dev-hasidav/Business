using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    #region  ==========  File login  ==========

    /// <summary>
    /// 
    /// </summary>
    [NumClass(11)]
    public class FileEventLog
    {
        private string _SourceEvent = null;
        private static System.Diagnostics.EventLog el = null;
        private static System.Diagnostics.TextWriterTraceListener tl;
        private static string _Path;
        private static string _File;
        private static string _Pref;
        private int Day = 0;
        private System.Timers.Timer tm;
        public static bool IsEventLog { set; get; } = false;
        public static bool IsTrace { set; get; } = false;
        public static bool IsSql { set; get; } = false;

        public FileEventLog(string Path, string Pref, string SourceEvent)
        {
            _SourceEvent = SourceEvent;
            _Pref = Pref;
            _Path = Path + @"\Log";
            _File = string.Format("{3}_{0:0000}{1:00}{2:00}.log", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _Pref);
            Day = DateTime.Now.Day;
            LoadEventSystem();
            StartLogin();
            tm = new System.Timers.Timer(1000 * 120);
            tm.AutoReset = true;
            tm.Elapsed += Tm_Elapsed;
            tm.Enabled = true;
            tm.Start();
        }

        private void Tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Day == Day) return;
            try
            {
                tm.Stop();
                EndLogin();
                _File = string.Format("{3}_{0:0000}{1:00}{2:00}.log", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _Pref);
                StartLogin();
                Day = DateTime.Now.Day;
            }
            catch (Exception e1)
            {
                el.WriteEntry(e1.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally { tm.Start(); }
        }
        private void LoadEventSystem()
        {
            if (!System.Diagnostics.EventLog.Exists(_SourceEvent))
            {
                if (System.Diagnostics.EventLog.SourceExists(_SourceEvent))
                {
                    System.Diagnostics.EventLog.DeleteEventSource(_SourceEvent);
                }
                System.Diagnostics.EventLog.CreateEventSource(_SourceEvent, _SourceEvent);
            }
            el = new System.Diagnostics.EventLog(_SourceEvent);
            el.Source = _SourceEvent;
            el.WriteEntry(string.Format("Test '{0}' - event", _SourceEvent), System.Diagnostics.EventLogEntryType.Information);
            IsEventLog = true;
        }

        private void StartLogin()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_Path);
            if (!di.Exists) di.Create();
            System.IO.FileInfo[] li_fi = di.GetFiles();
            int n1 = 0;
            foreach (System.IO.FileInfo fi in li_fi)
            {
                if (fi.CreationTime.CompareTo(DateTime.Now.AddDays(-30)) > 0) continue;
                fi.Delete();
                n1++;
            }
            string s1 = _Path + @"\" + _File;
            tl = new System.Diagnostics.TextWriterTraceListener(s1);
            System.Diagnostics.Trace.Listeners.Add(tl);
            System.Diagnostics.Trace.AutoFlush = true;
            IsTrace = true;
            WriteOk(this, "", System.Reflection.MethodInfo.GetCurrentMethod());
            WriteOk(this, string.Format("=====  Trace Maim start - time: {0}", DateTimeOffset.Now),
                System.Reflection.MethodInfo.GetCurrentMethod());
            WriteOk(this, string.Format(@"====  Dir: {1}, Delete {0} log-file.", n1, di.FullName),
                System.Reflection.MethodInfo.GetCurrentMethod());
        }

        /// <summary>
        /// Проверка подключения и наличия базы в SQL
        /// </summary>
        /// <param name="str_connect">Строка подключения к серверу</param>
        /// <param name="NameBase">База для проверки</param>
        /// <returns></returns>
        public bool CheckConnectSqlBase()
        {
            try
            {
                SqlScripts cSQL = new SqlScripts();
                IsSql = cSQL.CheckOrCreateTable();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally {  }
            return IsSql;
        }

        public void EndLogin()
        {
            WriteOk(this, string.Format("Trace Maim End   - time: {0}", DateTime.Now),
                System.Reflection.MethodInfo.GetCurrentMethod());
            IsTrace = false;
            System.Diagnostics.Trace.Listeners.Remove(tl);
            tl.Flush();
            tl.Close();
        }


        #region  ==========  Static function  ==========

        public static void WriteOk(string Text)
        {
            Write("Server", Text, "LocalHost", StatusMessage.Ok);
        }
        public static void WriteOk(UserLog us, string Text)
        {
            Write(us.Name, Text, us.Host, StatusMessage.Ok);
        }
        public static void WriteOk(object sender, string Text, System.Reflection.MethodBase mb)
        {
            Write("Server", Text, "LocalHost", StatusMessage.Ok, sender, mb);
        }

        //public static void WriteInformation(string Text)
        //{
        //    Write("Server", Text, "LocalHost", StatusMessage.In);
        //}
        //public static void WriteInformation(UserLog us, string Text)
        //{
        //    Write(us.Name, Text, us.Host, StatusMessage.In);
        //}
        //public static void WriteInformation(object sender, string Text, System.Reflection.MethodBase mb)
        //{
        //    Write("Server", Text, "LocalHost", StatusMessage.Ok, sender, mb);
        //}

        public static void WriteWarting(string Text)
        {
            Write("Server", Text, "LocalHost", StatusMessage.Wa);
        }
        public static void WriteWarting(UserLog us, string Text)
        {
            Write(us.Name, Text, us.Host, StatusMessage.Wa);
        }
        public static void WriteWarting(object sender, string Text, System.Reflection.MethodBase mb)
        {
            Write("Server", Text, "LocalHost", StatusMessage.Wa, sender, mb);
        }

        public static void Write(string Login, string Text, string Host,
            StatusMessage Status, object sender = null, System.Reflection.MethodBase mb = null)
        {
            LogMessage Mess = new LogMessage();
            Mess.Login = Login;
            Mess.Text = Text;
            Mess.Host = Host;
            Mess.Status = Status;
            if (sender != null)
            {
                LogWrite lw = new LogWrite(sender, (System.Reflection.MethodInfo)mb);
                Mess.Func = mb.Name;
                Mess.Cs = lw.NumClass;
                Mess.Fn = lw.NumFunction;
            }
            if (IsSql)
            {
                Mess.Create();
            }
            if (IsTrace)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0} - {1} - {2}", Status, DateTime.Now, Mess.ToString()));
            }
            if (IsEventLog)
            {
                el.WriteEntry(Mess.ToString(), Status == StatusMessage.Ok ? System.Diagnostics.EventLogEntryType.Information :
                    Status == StatusMessage.In ? System.Diagnostics.EventLogEntryType.Information :
                    Status == StatusMessage.Wa ? System.Diagnostics.EventLogEntryType.Warning :
                    System.Diagnostics.EventLogEntryType.Error, Mess.Fn, (short)Mess.Cs);
            }
        }

        public static void WriteErr(object sender, Exception ex, System.Reflection.MethodBase mb)
        {
            WriteErr(sender, mb, "Server", ex.Message, "LocalHost", StatusMessage.Er);
        }
        public static void WriteErr(Exception ex, System.Reflection.MethodBase mb)
        {
            char[] cc = new char[] { '\r', '\n' };
            string[] ss = ex.StackTrace.Split(cc, StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length == 0)
            {
                WriteErr(null, mb, "Server", ex.Message, "LocalHost", StatusMessage.Er);
            }
            else if (ss.Length == 1)
            {
                string s1 = string.Format("{0} - {1}", ex.Message, ss[ss.Length - 1]);
                WriteErr(null, mb, "Server", s1, "LocalHost", StatusMessage.Er);
            }
            else
            {
                string s1 = string.Format("{0} - {1} - {2}", ex.Message, ss[ss.Length - 2], ss[ss.Length - 1]);
                WriteErr(null, mb, "Server", s1, "LocalHost", StatusMessage.Er);
            }
        }
        public static void WriteErr(object sender, System.Reflection.MethodBase mb, UserLog us, string Text)
        {
            WriteErr(sender, mb, us.Name, Text, us.Host, StatusMessage.Er);
        }
        public static void WriteErr(object sender, System.Reflection.MethodBase mb,
            string Login, string Text, string Host, StatusMessage Status)
        {
            LogMessage Mess = new LogMessage();
            Mess.Login = Login;
            Mess.Text = Text;
            Mess.Host = Host;
            Mess.Status = Status;
            Mess.Func = mb.Name;
            if (sender != null)
            {
                LogWrite lw = new LogWrite(sender, (System.Reflection.MethodInfo)mb);
                Mess.Rw = lw.NumRow;
                Mess.Cl = lw.NumCol;
                Mess.Cs = lw.NumClass;
                Mess.Fn = lw.NumFunction;
                Mess.Nu = lw.NumError;
                Mess.ChainOfFunctions = lw.ChainOfFunctions;
            }
            if (IsSql)
            {
                Mess.Create();
            }
            if (IsTrace)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0} - {1} - {2}", Status, DateTime.Now, Mess.ToString()));
            }
            if (IsEventLog)
            {
                el.WriteEntry(Mess.ToString(), Status == StatusMessage.Ok ? System.Diagnostics.EventLogEntryType.Information :
                    Status == StatusMessage.In ? System.Diagnostics.EventLogEntryType.Information :
                    Status == StatusMessage.Wa ? System.Diagnostics.EventLogEntryType.Warning :
                    System.Diagnostics.EventLogEntryType.Error, Mess.Fn, (short)Mess.Cs);
            }
        }

        #endregion

    }

    #endregion
}
