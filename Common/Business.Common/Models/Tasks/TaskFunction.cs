using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public partial class Task
    {
        #region  ==========  Constructor  ==========
        public Task()
        {
            this.ServerSource = new Servers();
            this.ServerReceiver = new Servers();
        }
        public Task(int Id)
        {
            Load(Id);
        }
        public Task(string Name)
        {
            Load(Name);
        }
        #endregion

        #region  ==========  private function  ==========
        [NumFunction(1)]
        private void Load(int Id, string Name)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT * FROM sTasks ORDER BY [Name]";
                if (Id != 0)
                {
                    cm.CommandText = @"SELECT * FROM sTasks WHERE (Id = @Id) ORDER BY [Name]";
                    System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                    pr.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = @"SELECT * FROM sTasks WHERE ([Name] = @Name) ORDER BY [Name]";
                    System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                    pr.Value = Name;
                }
                else
                {
                    cm.CommandText = @"SELECT * FROM sTasks WHERE (Id = @Id) ORDER BY [Name]";
                    System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                    pr.Value = this.Id;
                }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["Id"];
                    this.IdParent = (int)dr["IdParent"];
                    this.Name = dr["Name"].ToString();
                    int n1 = (int)dr["ServerSource"];
                    if (n1 == 0) this.ServerSource = new Servers();
                    else this.ServerSource = new Servers(n1);
                    n1 = (int)dr["ServerReceiver"];
                    if (n1 == 0) this.ServerReceiver = new Servers();
                    else this.ServerReceiver = new Servers(n1);
                    this.IsRun = (bool)dr["IsRun"];
                    this.IsTrigers = (TypeTasks)dr["IsTrigers"];
                    this.IsWorks = (bool)dr["IsWorks"];
                    this.IsError = (bool)dr["IsError"];
                    this.DateRun = (DateTimeOffset)dr["DateRun"];
                    this.Message = dr["Message"] == DBNull.Value ? "" : dr["Message"].ToString();
                    byte[] bb = (byte[])dr["Param"];
                    this.Param = (TaskDop)Funcs.Conver.ConverByteToClass(bb, typeof(TaskDop));
                }
                else
                {
                    this.Id = Id;
                    this.Name = Name;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
            return;
        }

        #endregion

        #region  ==========  public function  ==========

        #region  ==========  запись, чтение, изменение и удаление

        [NumFunction(4)]
        public void Load()
        {
            Load(this.Id, null);
        }

        [NumFunction(5)]
        public void Load(int Id)
        {
            Load(Id, null);
        }

        [NumFunction(6)]
        public void Load(string Name)
        {
            Load(0, Name);
        }

        /// <summary>
        /// Создать новую запись в базе
        /// </summary>
        /// <returns></returns>
        [NumFunction(7)]
        public Task Create()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"INSERT INTO sTasks " +
                    @" (IdParent, [Name], ServerSource, ServerReceiver, IsRun, IsTrigers, IsWorks, IsError, DateRun, Message, Param) " +
                    @" VALUES (@IdParent, @Name, @ServerSource, @ServerReceiver, @IsRun, @IsTrigers, @IsWorks, @IsError, @DateRun, @Message, @Param)" +
                    @" ;SELECT Id FROM sTasks WHERE (Id = SCOPE_IDENTITY())";
                System.Data.SqlClient.SqlParameter pr_IdParent = cm.Parameters.Add("IdParent", System.Data.SqlDbType.VarChar);
                pr_IdParent.Value = this.IdParent;
                System.Data.SqlClient.SqlParameter pr_Name = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr_Name.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_ServerSource = cm.Parameters.Add("ServerSource", System.Data.SqlDbType.Int);
                if (this.ServerSource.Id == 0)
                {
                    if (string.IsNullOrWhiteSpace(this.ServerSource.Name))
                    {
                        throw new Exception("Source not defined");
                    }
                    else
                    {
                        this.ServerSource = new Servers(this.ServerSource.Name);
                    }
                }
                pr_ServerSource.Value = this.ServerSource.Id;
                System.Data.SqlClient.SqlParameter pr_ServerReceiver = cm.Parameters.Add("ServerReceiver", System.Data.SqlDbType.Int);
                if (this.ServerReceiver.Id == 0)
                {
                    if (string.IsNullOrWhiteSpace(this.ServerReceiver.Name))
                    {
                        throw new Exception("Receiver not defined");
                    }
                    else
                    {
                        this.ServerReceiver = new Servers(this.ServerReceiver.Name);
                    }
                }
                pr_ServerReceiver.Value = this.ServerReceiver.Id;
                System.Data.SqlClient.SqlParameter pr_IsRun = cm.Parameters.Add("IsRun", System.Data.SqlDbType.Bit);
                pr_IsRun.Value = this.IsRun;
                System.Data.SqlClient.SqlParameter pr_IsTrigers = cm.Parameters.Add("IsTrigers", System.Data.SqlDbType.Int);
                pr_IsTrigers.Value = (int)this.IsTrigers;
                System.Data.SqlClient.SqlParameter pr_IsWorks = cm.Parameters.Add("IsWorks", System.Data.SqlDbType.Bit);
                pr_IsWorks.Value = this.IsWorks;
                System.Data.SqlClient.SqlParameter pr_IsError = cm.Parameters.Add("IsError", System.Data.SqlDbType.Bit);
                pr_IsError.Value = this.IsError;
                System.Data.SqlClient.SqlParameter pr_DateRun = cm.Parameters.Add("DateRun", System.Data.SqlDbType.DateTimeOffset);
                pr_DateRun.Value = this.DateRun.ToUniversalTime();
                System.Data.SqlClient.SqlParameter pr_Message = cm.Parameters.Add("Message", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Message)) pr_Message.Value = DBNull.Value;
                else pr_Message.Value = this.Message;
                System.Data.SqlClient.SqlParameter pr_Param = cm.Parameters.Add("Param", System.Data.SqlDbType.VarBinary);
                pr_Param.Value = Funcs.Conver.ConverClassToByte(this.Param);
                CreateMessage(this, string.Format("Start created task name {0}", this.Name), StatusMessage.Ok, true);
                this.Id = (int)cm.ExecuteScalar();
                CreateMessage(this, string.Format("Created task name {0}", this.Name), StatusMessage.Ok, true);
                CreateMessage(this, string.Format("Created task name {0}", this.Name), StatusMessage.Ok);
                Load();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Создать новую запись в базе и записывает Id
        /// </summary>
        /// <returns></returns>
        [NumFunction(14)]
        public Task CreateId()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SET IDENTITY_INSERT [dbo].[sTasks] ON " +
                    @"INSERT INTO sTasks " +
                    @" (Id, IdParent, [Name], ServerSource, ServerReceiver, IsRun, IsTrigers, IsWorks, IsError, DateRun, Message, Param) " +
                    @" VALUES (@Id, @IdParent, @Name, @ServerSource, @ServerReceiver, @IsRun, @IsTrigers, @IsWorks, @IsError, @DateRun, @Message, @Param)" +
                    @" SET IDENTITY_INSERT [dbo].[sTasks] OFF ";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.VarChar);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_IdParent = cm.Parameters.Add("IdParent", System.Data.SqlDbType.VarChar);
                pr_IdParent.Value = this.IdParent;
                System.Data.SqlClient.SqlParameter pr_Name = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr_Name.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_ServerSource = cm.Parameters.Add("ServerSource", System.Data.SqlDbType.Int);
                pr_ServerSource.Value = this.ServerSource.Id;
                System.Data.SqlClient.SqlParameter pr_ServerReceiver = cm.Parameters.Add("ServerReceiver", System.Data.SqlDbType.Int);
                pr_ServerReceiver.Value = this.ServerReceiver.Id;
                System.Data.SqlClient.SqlParameter pr_IsRun = cm.Parameters.Add("IsRun", System.Data.SqlDbType.Bit);
                pr_IsRun.Value = this.IsRun;
                System.Data.SqlClient.SqlParameter pr_IsTrigers = cm.Parameters.Add("IsTrigers", System.Data.SqlDbType.Int);
                pr_IsTrigers.Value = (int)this.IsTrigers;
                System.Data.SqlClient.SqlParameter pr_IsWorks = cm.Parameters.Add("IsWorks", System.Data.SqlDbType.Bit);
                pr_IsWorks.Value = this.IsWorks;
                System.Data.SqlClient.SqlParameter pr_IsError = cm.Parameters.Add("IsError", System.Data.SqlDbType.Bit);
                pr_IsError.Value = this.IsError;
                System.Data.SqlClient.SqlParameter pr_DateRun = cm.Parameters.Add("DateRun", System.Data.SqlDbType.DateTimeOffset);
                pr_DateRun.Value = this.DateRun;
                System.Data.SqlClient.SqlParameter pr_Message = cm.Parameters.Add("Message", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Message)) pr_Message.Value = DBNull.Value;
                else pr_Message.Value = this.Message;
                System.Data.SqlClient.SqlParameter pr_Param = cm.Parameters.Add("Param", System.Data.SqlDbType.VarBinary);
                pr_Param.Value = Funcs.Conver.ConverClassToByte(this.Param);
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Изменить существующую запись 
        /// </summary>
        /// <returns></returns>
        [NumFunction(8)]
        public Task Update()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"UPDATE sTasks " +
                    @" SET Name = @Name, IsRun = @IsRun, DateRun = @DateRun, Message = @Message, Param = @Param, " +
                    @" ServerSource = @ServerSource, ServerReceiver = @ServerReceiver, IsError = @IsError " +
                    @" WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_Name = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr_Name.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_ServerSource = cm.Parameters.Add("ServerSource", System.Data.SqlDbType.Int);
                if (this.ServerSource.Id == 0)
                {
                    if (string.IsNullOrWhiteSpace(this.ServerSource.Name))
                    {
                        throw new Exception("Source not defined");
                    }
                    else
                    {
                        this.ServerSource = new Servers(this.ServerSource.Name);
                    }
                }
                pr_ServerSource.Value = this.ServerSource.Id;
                System.Data.SqlClient.SqlParameter pr_ServerReceiver = cm.Parameters.Add("ServerReceiver", System.Data.SqlDbType.Int);
                if (this.ServerReceiver.Id == 0)
                {
                    if (string.IsNullOrWhiteSpace(this.ServerReceiver.Name))
                    {
                        throw new Exception("Source not defined");
                    }
                    else
                    {
                        this.ServerReceiver = new Servers(this.ServerReceiver.Name);
                    }
                }
                pr_ServerReceiver.Value = this.ServerReceiver.Id;
                System.Data.SqlClient.SqlParameter pr_IsRun = cm.Parameters.Add("IsRun", System.Data.SqlDbType.Bit);
                pr_IsRun.Value = this.IsRun;
                System.Data.SqlClient.SqlParameter pr_IsError = cm.Parameters.Add("IsError", System.Data.SqlDbType.Bit);
                pr_IsError.Value = false;
                System.Data.SqlClient.SqlParameter pr_DateRun = cm.Parameters.Add("DateRun", System.Data.SqlDbType.DateTimeOffset);
                pr_DateRun.Value = this.DateRun;
                System.Data.SqlClient.SqlParameter pr_Message = cm.Parameters.Add("Message", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Message)) pr_Message.Value = DBNull.Value;
                else pr_Message.Value = this.Message;
                System.Data.SqlClient.SqlParameter pr_Param = cm.Parameters.Add("Param", System.Data.SqlDbType.VarBinary);
                pr_Param.Value = Funcs.Conver.ConverClassToByte(this.Param);
                CreateMessage(this, string.Format("Start update task name {0}", this.Name), StatusMessage.Ok);
                cm.ExecuteNonQuery();
                CreateMessage(this, string.Format("Update task name {0}", this.Name), StatusMessage.Ok);
                Load();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Удалить существующую запись 
        /// </summary>
        /// <returns></returns>
        [NumFunction(9)]
        public Task Delete()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                CreateMessage(this, string.Format("Start uninstall task name {0}", this.Name), StatusMessage.Ok, true);
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"DELETE FROM sTasks WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                List<Task> li = GetTasksAndChilden(this);
                foreach (Task tsk in li)
                {
                    _Delete(cm, pr_Id, tsk, this.Id);
                    pr_Id.Value = tsk.Id;
                    CreateMessage(this, string.Format("Start uninstall task name {0}", tsk.Name), StatusMessage.Ok, true);
                    cm.ExecuteNonQuery();
                    CreateMessage(this, string.Format("Task name {0} deleted", tsk.Name), StatusMessage.Ok, true);
                }
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
                CreateMessage(this, string.Format("Task name {0} deleted", this.Name), StatusMessage.Ok, true);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }
        private void _Delete(System.Data.SqlClient.SqlCommand cm, System.Data.SqlClient.SqlParameter pr, Task tsk, int IdParent)
        {
            foreach (Task tsk1 in tsk.ListChilden)
            {
                _Delete(cm, pr, tsk1, IdParent);
                pr.Value = tsk1.Id;
                CreateMessage(this, string.Format("Start uninstall task name {0}", tsk1.Name), StatusMessage.Ok, true);
                cm.ExecuteNonQuery();
                CreateMessage(this, string.Format("Task name {0} deleted", tsk1.Name), StatusMessage.Ok, true);
            }
        }

        /// <summary>
        /// Изменить DateRun, IsRun, IsWorks, IsError, Message, Param
        /// </summary>
        /// <returns></returns>
        [NumFunction(10)]
        public Task UpdateDateRun()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"UPDATE sTasks " +
                    @" SET IsWorks = @IsWorks, IsRun = @IsRun, DateRun = @DateRun, IsError = @IsError, Message = @Message, Param = @Param " +
                    @" WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_IsWorks = cm.Parameters.Add("IsWorks", System.Data.SqlDbType.Bit);
                pr_IsWorks.Value = this.IsWorks;
                System.Data.SqlClient.SqlParameter pr_IsRun = cm.Parameters.Add("IsRun", System.Data.SqlDbType.Bit);
                pr_IsRun.Value = this.IsRun;
                System.Data.SqlClient.SqlParameter pr_IsError = cm.Parameters.Add("IsError", System.Data.SqlDbType.Bit);
                pr_IsError.Value = false;
                System.Data.SqlClient.SqlParameter pr_DateRun = cm.Parameters.Add("DateRun", System.Data.SqlDbType.DateTimeOffset);
                pr_DateRun.Value = this.DateRun;
                System.Data.SqlClient.SqlParameter pr_Message = cm.Parameters.Add("Message", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Message)) pr_Message.Value = DBNull.Value;
                else pr_Message.Value = this.Message;
                System.Data.SqlClient.SqlParameter pr_Param = cm.Parameters.Add("Param", System.Data.SqlDbType.VarBinary);
                pr_Param.Value = Funcs.Conver.ConverClassToByte(this.Param);
                //CreateMessage(this, string.Format("Update date run name {0}", this.Name), StatusMessage.Ok);
                cm.ExecuteNonQuery();
                //CreateMessage(this, string.Format("Update date run name {0}", this.Name), StatusMessage.Ok);
                Load();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }

        [NumFunction(19)]
        public Task ResetTask()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"UPDATE sTasks  SET IsWorks = @IsWorks  WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_IsWorks = cm.Parameters.Add("IsWorks", System.Data.SqlDbType.Bit);
                pr_IsWorks.Value = false;
                CreateMessage(this, string.Format("Start reset task {0}", this.Name), StatusMessage.Ok);
                cm.ExecuteNonQuery();
                CreateMessage(this, string.Format("Reset task {0} - end", this.Name), StatusMessage.Ok);
                Load();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }


        #endregion

        #region  ==========  Schedule  ==========

        [NumFunction(18)]
        public DateTimeOffset ReCalculateDateRun(DateTimeOffset dt)
        {
            bool b1 = false;
            DateTimeOffset dt1;
            //ScheduleReturn sr = new ScheduleReturn();
            switch (this.Param.Schedule.Interval)
            {
                case Period.None:
                case Period.TimeParent:
                    break;
                case Period.Once:
                    dt = this.Param.Schedule.Once.Once;
                    break;
                case Period.Minute:
                    dt = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, new TimeSpan(0, 0, 0));
                    do
                    {
                        b1 = false;
                        switch (_CheckDateRun(dt))
                        {
                            case TimeRange.DateLessCurrent:
                                dt = dt.AddMinutes(this.Param.Schedule.Minute.Minute);
                                b1 = true;
                                break;
                            case TimeRange.Ok:
                                b1 = false;
                                break;
                            case TimeRange.DateNoRange:
                                dt = dt.AddMinutes(this.Param.Schedule.Minute.Minute);
                                b1 = true;
                                break;
                            case TimeRange.TaskOver:
                                b1 = false;
                                break;
                        }
                    } while (b1);
                    break;
                case Period.Hour:
                    dt = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, this.Param.Schedule.Hour.Hour.Minute, 0, new TimeSpan(0, 0, 0));
                    do
                    {
                        b1 = false;
                        switch (_CheckDateRun(dt))
                        {
                            case TimeRange.DateLessCurrent:
                                dt = dt.AddHours(this.Param.Schedule.Hour.Hour.Hour);
                                b1 = true;
                                break;
                            case TimeRange.Ok:
                                b1 = false;
                                break;
                            case TimeRange.DateNoRange:
                                dt = dt.AddHours(this.Param.Schedule.Hour.Hour.Hour);
                                b1 = true;
                                break;
                            case TimeRange.TaskOver:
                                b1 = false;
                                break;
                        }
                    } while (b1);
                    break;
                case Period.Day:
                    dt1 = this.Param.Schedule.Day.Day.ToUniversalTime();
                    dt = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0, new TimeSpan(0, 0, 0));
                    do
                    {
                        b1 = false;
                        switch (_CheckDateRun(dt))
                        {
                            case TimeRange.DateLessCurrent:
                                dt = dt.AddDays(dt1.Day);
                                b1 = true;
                                break;
                            case TimeRange.Ok:
                                b1 = false;
                                break;
                            case TimeRange.DateNoRange:
                                dt = dt.AddDays(dt1.Day);
                                b1 = true;
                                break;
                            case TimeRange.TaskOver:
                                b1 = false;
                                break;
                        }
                    } while (b1);
                    break;
                case Period.Week:
                    int iWeek = (int)dt.DayOfWeek;
                    int iWeekEnd = iWeek + 7;
                    for (int n1 = iWeek; n1 < iWeekEnd; n1++)
                    {
                        dt1 = dt.ToUniversalTime().AddDays(n1 - iWeek);
                        DayOfWeek week = (DayOfWeek)(n1 < 7 ? n1 : n1 - 7);
                        WeekElem we = this.Param.Schedule.Week[week];
                        if (we.Enable)
                        {

                            dt = new DateTimeOffset(dt1.Year, dt1.Month, dt1.Day, we.Time.ToUniversalTime().Hour,
                                we.Time.ToUniversalTime().Minute, 0, new TimeSpan(0, 0, 0));
                            if (_CheckDateRun(dt) == TimeRange.Ok)
                            {
                                break;
                            }
                        }
                    }
                    break;
                case Period.Month:
                    dt1 = this.Param.Schedule.Month.Month.ToUniversalTime();
                    dt = new DateTimeOffset(dt.Year, dt.Month, dt1.Day, dt1.Hour, dt1.Minute, 0, new TimeSpan(0, 0, 0));
                    do
                    {
                        b1 = false;
                        switch (_CheckDateRun(dt))
                        {
                            case TimeRange.DateLessCurrent:
                                dt = dt.AddMonths(dt1.Month);
                                b1 = true;
                                break;
                            case TimeRange.Ok:
                                b1 = false;
                                break;
                            case TimeRange.DateNoRange:
                                dt = dt.AddMonths(dt1.Month);
                                b1 = true;
                                break;
                            case TimeRange.TaskOver:
                                b1 = false;
                                break;
                        }
                    } while (b1);
                    break;
            }
            return dt;
        }


        [NumFunction(17)]
        private TimeRange _CheckDateRun(DateTimeOffset dt)
        {
            TimeRange sr = TimeRange.Err;
            DateTimeOffset dt_cur = DateTimeOffset.Now.ToUniversalTime();
            if (dt.CompareTo(dt_cur) < 0)
            {
                sr = TimeRange.DateLessCurrent;
            }
            //  закончилась ли задача ввобще
            else if (dt.CompareTo(this.Param.Schedule.DateEndTask.ToUniversalTime()) >= 0)     //  да - уже закончилась
            {
                sr = TimeRange.TaskOver;
            }
            else if (this.Param.Schedule.IsStartEnd)
            {
                TimeSpan ts_check = dt.TimeOfDay;
                TimeSpan ts_sch_start = this.Param.Schedule.DataStart.ToUniversalTime().TimeOfDay;
                TimeSpan ts_sch_stop = this.Param.Schedule.DataEnd.ToUniversalTime().TimeOfDay;
                if ((ts_sch_start.CompareTo(ts_check) <= 0) && (ts_sch_stop.CompareTo(ts_check) >= 0))
                {
                    sr = TimeRange.Ok;
                }
                else
                {
                    sr = TimeRange.DateNoRange;
                }
            }
            else
            {
                sr = TimeRange.Ok;
            }
            return sr;
        }


        //[NumFunction(11)]
        //public bool GetNextRun()
        //{
        //    bool b_run = false;
        //    ScheduleReturn sr = new ScheduleReturn();

        //    this.Param.DateLastRun = this.DateRun;
        //    if (!this.IsError) this.Param.DateLastRunOk = this.DateRun;
        //    this.IsError = false;
        //    switch (this.Param.Schedule.Interval)
        //    {
        //        case Period.None:
        //            this.IsRun = false;
        //            this.IsError = true;
        //            this.Message = "Расписание задачи НЕ установленно";
        //            break;
        //        case Period.Once:
        //            this.IsRun = false;
        //            break;
        //        case Period.TimeParent:
        //            break;
        //        case Period.Minute:
        //            _CheckEnd_02();
        //            break;
        //        case Period.Hour:
        //            _CheckEnd_02();
        //            break;
        //        case Period.Day:
        //            _CheckEnd_02();
        //            break;
        //        case Period.Week:
        //            _CheckEnd_02();
        //            break;
        //        case Period.Month:
        //            _CheckEnd_02();
        //            break;
        //    }

        //    return b_run;
        //}

        //[NumFunction(11)]
        //public ScheduleReturn GetNextRun()
        //{ 
        //    DateTimeOffset dt_cur = DateTimeOffset.Now;
        //    //  Проверяем - рассчитанна следующая дата вообще
        //    ScheduleReturn sr = _CheckEnd_01(this.DateRun);
        //    bool b1 = true;
        //    while (b1)
        //    {
        //        switch (sr.StatusRun)
        //        {
        //            case TimeRange.DateLessCurrent:     // дата меньше текушей
        //            case TimeRange.DateNoRange:         // дата не в диапозоне
        //                sr = _CheckEnd_02(this.DateRun);
        //                this.DateRun = sr.Date.ToUniversalTime();
        //                CreateMessage(this, string.Format("дата не в диапозоне"), StatusMessage.Wa);
        //                break;
        //            case TimeRange.Err:                 // возникла непонятная ошибка
        //                FileEventLog.WriteErr(this, System.Reflection.MethodInfo.GetCurrentMethod(),
        //                    "TimeTask", "Error calculating next date. " + sr.Message, "local", StatusMessage.Er);
        //                this.IsError = true;
        //                this.IsRun = false;
        //                CreateMessage(this, string.Format("возникла непонятная ошибка"), StatusMessage.Er);
        //                b1 = false;
        //                break;
        //            case TimeRange.Ok:                  // всё хорошо - время получено
        //                this.DateRun = sr.Date.ToUniversalTime();
        //                this.IsError = false;
        //                b1 = false;
        //                CreateMessage(this, string.Format("Начинаем изменение даты"), StatusMessage.Wa);
        //                this.UpdateDateRun();
        //                CreateMessage(this, string.Format("Дата изменена"), StatusMessage.Wa);
        //                break;
        //            case TimeRange.TaskOver:            // задача закончилась
        //                this.IsRun = false;
        //                CreateMessage(this, string.Format("задача закончилась"), StatusMessage.Wa);
        //                b1 = false;
        //                break;
        //        }
        //    }
        //    return sr;
        //}

        //[NumFunction(12)]
        //private ScheduleReturn _CheckEnd_01(DateTimeOffset dt_Check)
        //{
        //    ScheduleReturn sr = new ScheduleReturn();
        //    DateTimeOffset dt_cur = DateTimeOffset.Now.ToUniversalTime();
        //    DateTimeOffset dt_Check1 = dt_Check.ToUniversalTime();
        //    if (dt_cur.CompareTo(dt_Check1) > 0)
        //    {
        //        sr.StatusRun = TimeRange.DateLessCurrent;
        //        sr.Message = "Дата меньше текущей";
        //    }
        //    //  закончилась ли задача ввобще
        //    else if (dt_Check1.CompareTo(this.Param.Schedule.DateEndTask.ToUniversalTime()) >= 0)     //  да - уже закончилась
        //    {
        //        sr.StatusRun = TimeRange.TaskOver;
        //        sr.Message = "Задача закончилась";
        //    }
        //    else if(this.Param.Schedule.IsStartEnd)
        //    {
        //        TimeSpan ts_check = dt_Check1.TimeOfDay;
        //        TimeSpan ts_sch_start = this.Param.Schedule.DataStart.ToUniversalTime().TimeOfDay;
        //        TimeSpan ts_sch_stop = this.Param.Schedule.DataEnd.ToUniversalTime().TimeOfDay;
        //        if ((ts_sch_start.CompareTo(ts_check) <= 0) && (ts_sch_stop.CompareTo(ts_check) >= 0))
        //        {
        //            sr.StatusRun = TimeRange.Ok;
        //            sr.Message = "Задача во временных рамках запуска";
        //        }
        //        else
        //        {
        //            sr.StatusRun = TimeRange.DateNoRange;
        //            sr.Message = "Задача не во временном диапозоме ";
        //        }
        //    }
        //    return sr;
        //}

        //[NumFunction(13)]
        //private void _CheckEnd_02()
        //{
        //    ScheduleReturn sr = new ScheduleReturn();
        //    DateTimeOffset dt_cur = DateTimeOffset.Now.ToUniversalTime();
        //    bool b1 = false;
        //    if (this.DateRun.CompareTo(dt_cur) >= 0) return;
        //    switch (this.Param.Schedule.Interval)
        //    {
        //        case Period.Minute:
        //            this.DateRun = dt_cur.AddMinutes(this.Param.Schedule.Minute.Minute);
        //            break;
        //        case Period.Hour:
        //            do
        //            {
        //                b1 = false;
        //                sr = _CheckEnd_01(this.DateRun);
        //                switch (sr.StatusRun)
        //                {
        //                    case TimeRange.DateLessCurrent:
        //                        this.DateRun = this.DateRun.AddHours(this.Param.Schedule.Hour.Hour.Hour);
        //                        b1 = true;
        //                        break;
        //                    case TimeRange.Ok:
        //                        b1 = false;
        //                        break;
        //                    case TimeRange.DateNoRange:
        //                        this.DateRun = this.DateRun.AddHours(this.Param.Schedule.Hour.Hour.Hour);
        //                        b1 = true;
        //                        break;
        //                    case TimeRange.TaskOver:
        //                        b1 = false;
        //                        break;
        //                }
        //            } while (b1);
        //            break;
        //        case Period.Day:
        //            do
        //            {
        //                b1 = false;
        //                sr = _CheckEnd_01(this.DateRun);
        //                switch (sr.StatusRun)
        //                {
        //                    case TimeRange.DateLessCurrent:
        //                        this.DateRun = this.DateRun.AddDays(this.Param.Schedule.Day.Day.Day);
        //                        b1 = true;
        //                        break;
        //                    case TimeRange.Ok:
        //                        b1 = false;
        //                        break;
        //                    case TimeRange.DateNoRange:
        //                        this.DateRun = this.DateRun.AddDays(this.Param.Schedule.Day.Day.Day);
        //                        b1 = true;
        //                        break;
        //                    case TimeRange.TaskOver:
        //                        b1 = false;
        //                        break;
        //                }
        //            } while (b1);
        //            break;
        //        case Period.Week:
        //            int iWeek = (int)dt_cur.DayOfWeek;
        //            int iWeekEnd = iWeek + 7;
        //            for (int n1 = iWeek; n1 < iWeekEnd; n1++)
        //            {
        //                DateTimeOffset dt1 = dt_cur.AddDays(n1 - iWeek);
        //                DayOfWeek week = (DayOfWeek)(n1 < 7 ? n1 : n1 - 7);
        //                WeekElem we = this.Param.Schedule.Week[week];
        //                if (we.Enable)
        //                {
        //                    this.DateRun = new DateTimeOffset(dt1.Year, dt1.Month, dt1.Day, we.Time.Hour, we.Time.Minute, 0, new TimeSpan(0, 0, 0));
        //                    sr = _CheckEnd_01(this.DateRun);
        //                    if (sr.StatusRun == TimeRange.Ok)
        //                    {
        //                        break;
        //                    }
        //                }
        //            }
        //            break;
        //        case Period.Month:
        //            do
        //            {
        //                b1 = false;
        //                sr = _CheckEnd_01(this.DateRun);
        //                switch (sr.StatusRun)
        //                {
        //                    case TimeRange.DateLessCurrent:
        //                        this.DateRun = this.DateRun.AddMonths(this.Param.Schedule.Month.Month.Month);
        //                        b1 = true;
        //                        break;
        //                    case TimeRange.Ok:
        //                        b1 = false;
        //                        break;
        //                    case TimeRange.DateNoRange:
        //                        this.DateRun = this.DateRun.AddMonths(this.Param.Schedule.Month.Month.Month);
        //                        b1 = true;
        //                        break;
        //                    case TimeRange.TaskOver:
        //                        b1 = false;
        //                        break;
        //                }
        //            } while (b1);
        //            break;
        //    }
        //    return;
        //}

        #endregion

        #region  ==========  Message  ==========

        /// <summary>
        /// Отправка информационного сообщение для задачи (SQL)
        /// </summary>
        /// <param name="Mess"></param>
        [NumFunction(15)]
        public void WriteMessageInfo(string Mess)
        {
            Task.CreateMessage(this, Mess, StatusMessage.In);
        }

        /// <summary>
        /// Отправка сообщение об ошибки для задачи (SQL)
        /// </summary>
        /// <param name="Mess"></param>
        [NumFunction(16)]
        public void WriteMessageError(string Mess)
        {
            Task.CreateMessage(this, Mess, StatusMessage.Er);
        }

        /// <summary>
        /// Отправка предупреждающего сообщение для задачи (SQL)
        /// </summary>
        /// <param name="Mess"></param>
        [NumFunction(17)]
        public void WriteMessageWarting(string Mess)
        {
            Task.CreateMessage(this, Mess, StatusMessage.Wa);
        }

        #endregion

        #endregion

        #region  ==========  static function  ==========

        /// <summary>
        /// Получить список (дерево) всех задач начиная с корневых
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetTasks()
        {
            List<Task> li = GetTasksAndChilden(0);
            return li;
        }

        /// <summary>
        /// Получить 1 задачу
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Task GetTask(int Id)
        {
            Task li = new Task(Id);
            return li;
        }

        /// <summary>
        /// Список задач по рассписанию
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetTasksSchedule()
        {
            List<Task> li = GetTasksAndChilden(1);
            return li;
        }

        /// <summary>
        /// Список триггерных задач
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetTasksTriggers(bool IsAll = true)
        {
            List<Task> li = GetTasksAndChilden(2, IsAll);
            return li;
        }

        /// <summary>
        /// Получить список всех дочерних задач для заданной задачи
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static List<Task> GetTasksAndChilden(Task tsk, bool IsAll = true)
        {
            return GetTasksAndChilden(tsk.Id, IsAll);
        }

        /// <summary>
        /// Получить список (дерево) всех дочерних задач начиная с заданной параметром IdParent
        /// </summary>
        /// <param name="IdParent"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static List<Task> GetTasksAndChilden(int IdParent, bool IsAll = true)
        {
            System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
            cn.Open();
            System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
            cm.Connection = cn;
            cm.CommandText = @"SELECT Id FROM sTasks WHERE (IdParent = @IdParent) ORDER BY Name";
            System.Data.SqlClient.SqlParameter pr_IdParent = cm.Parameters.Add("IdParent", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            da.SelectCommand = cm;
            List<Task> li = _GetTasksAndChilden(IdParent, da, pr_IdParent, null, IsAll);
            cn?.Close();
            return li;
        }

        /// <summary>
        /// Цикл выборки дочерних задач
        /// </summary>
        /// <param name="IdParent"></param>
        /// <param name="da"></param>
        /// <param name="pr_IdParent"></param>
        /// <param name="tsk_Parent"></param>
        /// <returns></returns>
        private static List<Task> _GetTasksAndChilden(int IdParent, System.Data.SqlClient.SqlDataAdapter da,
            System.Data.SqlClient.SqlParameter pr_IdParent, Task tsk_Parent, bool IsAll = true)
        {
            pr_IdParent.Value = IdParent;
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            List<Task> li = new List<Task>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                Task tsk = new Task((int)dr["Id"]);
                li.Add(tsk);
                tsk.Parent = tsk_Parent;
                if (IsAll) tsk.ListChilden = _GetTasksAndChilden(tsk.Id, da, pr_IdParent, tsk, IsAll);
            }
            return li;
        }

        /// <summary>
        /// Получить список (дерево) всех запускаемых задач
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetTasksRun()
        {
            List<Task> li = new List<Task>();
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT Id FROM sTasks " +
                    @" WHERE (IdParent = @IdParent) AND (IsRun = @IsRun) AND (IsTrigers = @IsTrigers) AND (IsWorks = @IsWorks) AND (DateRun <= @DateRun)";
                System.Data.SqlClient.SqlParameter pr_IdParent = cm.Parameters.Add("IdParent", System.Data.SqlDbType.Int);
                pr_IdParent.Value = 1;
                System.Data.SqlClient.SqlParameter pr_IsRun = cm.Parameters.Add("IsRun", System.Data.SqlDbType.Bit);
                pr_IsRun.Value = true;
                System.Data.SqlClient.SqlParameter pr_IsTrigers = cm.Parameters.Add("IsTrigers", System.Data.SqlDbType.Int);
                pr_IsTrigers.Value = 1;
                System.Data.SqlClient.SqlParameter pr_IsWorks = cm.Parameters.Add("IsWorks", System.Data.SqlDbType.Bit);
                pr_IsWorks.Value = false;
                System.Data.SqlClient.SqlParameter pr_DateRun = cm.Parameters.Add("DateRun", System.Data.SqlDbType.DateTimeOffset);
                pr_DateRun.Value = DateTimeOffset.Now.ToUniversalTime(); ;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    li.Add(new Task((int)dr["Id"]));
                }
                dr.Close();
                foreach (Task tsk in li)
                {
                    tsk.ListChilden = GetTasksAndChilden(tsk.Id);
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return li;
        }

        /// <summary>
        /// Записать сообщение для задачи
        /// </summary>
        /// <param name="tsk">Задача</param>
        /// <param name="Mess">Сообщение</param>
        /// <param name="St">Статус сообщения</param>
        /// <param name="IsRoot">Если True то сообщение записывается корневой задачи</param>
        public static void CreateMessage(Task tsk, string Mess, StatusMessage St, bool IsRoot = false)
        {
            Task Prn = tsk;
            if (IsRoot)
            {
                while (Prn.IdParent != 0)
                {
                    Prn = Prn.Parent;
                }
            }
            TasksLog tl = new TasksLog();
            tl.IdTask = Prn.Id;
            tl.Status = St;
            tl.Message = Mess;
            tl.Create();
        }

        /// <summary>
        /// Получить задачу по GOID-у
        /// </summary>
        /// <param name="GuigTask"></param>
        /// <returns></returns>
        public static Task GetTask(string GuigTask)
        {
            Task tsk = null;
            List<Task> li = Task.GetTasksTriggers();
            foreach (Task item in li)
            {
                if (GuigTask.Trim().CompareTo(item.Param.IdGuid.Trim()) != 0) continue;
                tsk = item;
                break;
            }

            return tsk;
        }

        public static int TaskReset()
        {
            List<Task> li = new List<Task>();
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT Id FROM sTasks  WHERE (IsWorks = @IsWorks) ";
                System.Data.SqlClient.SqlParameter pr_IsWorks = cm.Parameters.Add("IsWorks", System.Data.SqlDbType.Bit);
                pr_IsWorks.Value = true;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    li.Add(new Task((int)dr["Id"]));
                }
                dr.Close();
                foreach (Task tsk in li)
                {
                    tsk.ResetTask();
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return li.Count;
        }
        #endregion

    }
}
