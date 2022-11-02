using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks
{
    [NumClass(34)]
    public class ActionAll
    {
        /// <summary>
        /// Принимает запрос на выполнения действий триггера
        /// </summary>
        /// <param name="tsk">Задача</param>
        /// <param name="ret">Парамметры триггера</param>
        [NumFunction(1)]
        public void RunTaskTriggers(Models.Task tsk, RetTriggers ret)
        {
            TaskAction.ParamActior pa = new Models.Tasks.TaskAction.ParamActior();
            pa.retSql = ret;
            pa.Tsk = tsk;
            pa.LevelTask = 0;
            pa.NumTask = ++SqlScripts.NumTask;

            string s1 = string.Format("({0:n0}:{1}) Reading task tsk-Trigger. Name task: {2}, Event: {3}, Srv: {4}, Db: {5}, Tb: {6}, Rc: {7}",
                pa.NumTask, pa.LevelTask, tsk.Name, ret.Id, ret.NameServer, ret.NameBase, ret.NameTable, ret.IdRecord
                );
            tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());

            System.Threading.ParameterizedThreadStart pts = new System.Threading.ParameterizedThreadStart(_RunTask);
            System.Threading.Thread th = new System.Threading.Thread(pts);
            th.Name = string.Format("Tr_{0}_{1}", tsk.Name, ret.Id);
            th.Start(pa);

            s1 = string.Format("({0:n0}:{1}) Task read tsk-Trigger. Name task: {2}, Event: {3}, Srv: {4}, Db: {5}, Tb: {6}, Rc: {7}",
                pa.NumTask, pa.LevelTask, tsk.Name, ret.Id, ret.NameServer, ret.NameBase, ret.NameTable, ret.IdRecord
                );
            tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
        }

        /// <summary>
        /// Принимает запрос действия задачи по рассписанию
        /// </summary>
        /// <param name="tsk">Задача</param>
        [NumFunction(2)]
        public void RunTaskSchedule(Models.Task tsk)
        {
            TaskAction.ParamActior pa = new Models.Tasks.TaskAction.ParamActior();
            pa.Tsk = tsk;
            pa.LevelTask = 0;
            pa.NumTask = ++SqlScripts.NumTask;

            string s1 = string.Format("({0:n0}:{1})  Launch stream tsk-Schedule. Name task: {2}, ", pa.NumTask, pa.LevelTask, tsk.Name);
            tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());

            System.Threading.ParameterizedThreadStart pts = new System.Threading.ParameterizedThreadStart(_RunTask);
            System.Threading.Thread th = new System.Threading.Thread(pts);
            th.Name = string.Format("Sh_{0}_{1}", tsk.Name, tsk.Id);
            th.Start(pa);

            s1 = string.Format("({0:n0}:{1}) Task read tsk-Schedule.  Name: {2}", pa.NumTask, pa.LevelTask, tsk.Name);
            tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
        }

        /// <summary>
        /// Запуск родительской задачи
        /// </summary>
        /// <param name="sender">Параметры задачи</param>
        [NumFunction(50)]
        private void _RunTask(object sender)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            TaskAction.ParamActior pa = (TaskAction.ParamActior)sender;
            string s1 = "";
            try
            {
                //  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //  
                //  запуск функции выполнения задачи
                Interfases.IActionStart i_AS = GetAction(pa.Tsk);
                if (i_AS == null)
                {
                    string s2 = string.Format("({0:n0}:{1}) Failed to get action for task.. Id: {2}, Name: {3}", 
                        pa.NumTask, pa.LevelTask, pa.Tsk.Id, pa.Tsk.Name);
                    pa.Tsk.WriteMessageInfo(s2);
                    FileEventLog.WriteErr(this, new Exception(s2), System.Reflection.MethodInfo.GetCurrentMethod());
                    return;
                }
                if (pa.Tsk.IsTrigers == TypeTasks.Schedule)
                {
                    s1 = string.Format("({0:n0}:{1}) Launch tsk-Schedule. Task: {2}", pa.NumTask, pa.LevelTask, pa.Tsk.Name);
                }
                else
                {
                    s1 = string.Format("({0:n0}:{1}) Launch Trigger-task. Name task: {2}, Event: {3}, Srv: {4}, Db: {5}, Tb: {6}, Rc: {7}",
                       pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.retSql.Id, pa.retSql.NameServer, pa.retSql.NameBase,
                       pa.retSql.NameTable, pa.retSql.IdRecord);
                }
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());

                pa.Tsk.IsWorks = true;
                if (pa.Tsk.Param.Schedule.Interval == Period.None)
                {
                    pa.Tsk.IsRun = false;
                    return;
                }
                else if ((pa.Tsk.Param.Schedule.Interval == Period.Once) && (pa.Tsk.IsTrigers == TypeTasks.Schedule))
                {
                    pa.Tsk.IsRun = false;
                }
                pa.Tsk.UpdateDateRun();
                if (pa.Tsk.IsTrigers == TypeTasks.Trigger) pa.Tsk.Param.DateLastRun = DateTimeOffset.Now;
                else pa.Tsk.Param.DateLastRun = pa.Tsk.DateRun;

                //  Запускаем задачу
                if (pa.Tsk.IsTrigers == TypeTasks.Trigger) i_AS.RunTaskTriggers(pa);
                else if (pa.Tsk.IsTrigers == TypeTasks.Schedule) i_AS.RunTaskSchedule(pa);
                else
                {
                    s1 = string.Format("({0:n0}:{1}) Incomprehensible task type. Task: {2}", pa.NumTask, pa.LevelTask, pa.Tsk.Name);
                    pa.Tsk.WriteMessageInfo(s1);
                    FileEventLog.WriteWarting(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    return;
                }

                //  Запуск дочерних задач
                sw.Stop();
                s1 = string.Format("({0:n0}:{1}) Task: {2} ended. Time: {4}. Testing and starting child tasks. Childer-Task: {3} ",
                    pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.Tsk.ListChilden.Count, sw.Elapsed);
                sw.Start();
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                if (pa.Tsk.ListChilden.Count != 0)     
                {
                    List<TaskAction.ParamActior> li_pa = new List<TaskAction.ParamActior>();
                    System.Action<TaskAction.ParamActior> act = new Action<TaskAction.ParamActior>(_RunTaskBarrier);
                    ulong n1 = 1;
                    foreach (Models.Task tsk_ch in pa.Tsk.ListChilden)
                    {
                        if (tsk_ch.IsRun)
                        {
                            li_pa.Add(new TaskAction.ParamActior()
                            {
                                Tsk = tsk_ch,
                                retSql = pa.retSql,
                                LevelTask = pa.LevelTask + 1,
                                NumTask = pa.NumTask * 1000 + n1++
                            });
                        }
                    }
                    System.Threading.Barrier brr = new System.Threading.Barrier(li_pa.Count, (b) =>
                    {
                        s1 = string.Format("({0:n0}:{1}) Child ({3}) tasks completed. Task: {2} ",
                           pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_pa.Count);
                        pa.Tsk.WriteMessageInfo(s1);
                        FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    });
                    foreach (TaskAction.ParamActior pa1 in li_pa) { pa1.brr = brr; }
                    ParallelLoopResult pr_rez = Parallel.ForEach<TaskAction.ParamActior>(li_pa, act);
                    brr.Dispose();
                }
                
                if (pa.Tsk.IsTrigers == TypeTasks.Trigger) pa.Tsk.Param.DateLastRunOk = DateTimeOffset.Now;
                else pa.Tsk.Param.DateLastRunOk = pa.Tsk.DateRun;
            }
            catch (Exception e1)
            {
                pa.Tsk.Message = e1.Message;
                pa.Tsk.IsError = true;
                pa.Tsk.WriteMessageError(e1.Message);
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                if (pa.Tsk.IsTrigers == TypeTasks.Trigger)
                {
                    string s_main = string.Format(@"http://{0}:{1}/{2}", "localhost", SqlScripts.Port, SqlScripts.NameScope);
                    Type tt = typeof(Interfases.IConnectMainSyncAgent);
                    object cl_Connect = Activator.GetObject(tt, s_main);
                    tt.GetMethod("UpdateRemTriggers").Invoke(cl_Connect, new object[] { pa.Tsk.ServerSource, pa.retSql, Enums.StTriggers.EndTask });
                }

                pa.Tsk.DateRun = pa.Tsk.ReCalculateDateRun(DateTimeOffset.Now.ToUniversalTime());
                if ((pa.Tsk.Param.Schedule.Interval == Period.Once) && (pa.Tsk.IsTrigers == TypeTasks.Schedule)) pa.Tsk.IsRun = false;
                pa.Tsk.IsWorks = false;
                pa.Tsk.UpdateDateRun();
                sw.Stop();
                if (pa.Tsk.IsTrigers == TypeTasks.Schedule)
                {
                    s1 = string.Format("({0:n0}:{1}) End of main thread execution. Time: {2}, Task: {3}",
                        pa.NumTask, pa.LevelTask, sw.Elapsed, pa.Tsk.Name);
                }
                else
                {
                    s1 = string.Format("({0:n0}:{1}) End of main thread execution Triggers-task. Event: {8}, Time: {6}, Name task: {2}, Srv: {4}, Db: {5}, Tb: {6}, Rc: {7}",
                       pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.retSql.Id, pa.retSql.NameServer, pa.retSql.NameBase,
                       pa.retSql.NameTable, pa.retSql.IdRecord, sw.Elapsed);
                }
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        /// <summary>
        /// Запуск дочерних задач
        /// </summary>
        /// <param name="pa"></param>
        [NumFunction(51)]
        private void _RunTaskBarrier(TaskAction.ParamActior pa)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            string s1 = "";
            try
            {
                if (!pa.Tsk.IsRun)
                {
                    pa.Tsk.Message = string.Format("({0:n0}:{1}) Task Name: {2}, Id: {3} disconnected. Aborted",
                        pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.Tsk.Id);
                    return;
                }
                //  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //  
                //  запуск функции выполнения задачи
                Interfases.IActionStart i_AS = GetAction(pa.Tsk);
                if (i_AS == null)
                {
                    string s2 = string.Format("({0:n0}:{1}) Failed to get action for task.. Id: {2}, Name: {3}",
                        pa.NumTask, pa.LevelTask, pa.Tsk.Id, pa.Tsk.Name);
                    pa.Tsk.WriteMessageInfo(s2);
                    FileEventLog.WriteErr(this, new Exception(s2), System.Reflection.MethodInfo.GetCurrentMethod());
                    return;
                }
                if (pa.Tsk.IsTrigers == TypeTasks.Schedule)
                {
                    s1 = string.Format("({0:n0}:{1}) Start tsk-Schedule. Level: {2} Task: {3}",
                        pa.NumTask, pa.LevelTask, pa.LevelTask, pa.Tsk.Name);
                }
                else
                {
                    s1 = string.Format("({0:n0}:{1}) Start tsk-Trigger. Event: {3}, Task: {2}, Srv: {4}, Db: {5}, Tb: {6}, Rc: {7}",
                       pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.retSql.Id, pa.retSql.NameServer, pa.retSql.NameBase,
                       pa.retSql.NameTable, pa.retSql.IdRecord);
                }
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                if (pa.Tsk.IsTrigers == TypeTasks.Trigger) pa.Tsk.Param.DateLastRun = DateTimeOffset.Now;
                else pa.Tsk.Param.DateLastRun = pa.Tsk.DateRun;

                if (pa.Tsk.IsTrigers == TypeTasks.Trigger) i_AS.RunTaskTriggers(pa);
                else if (pa.Tsk.IsTrigers == TypeTasks.Schedule) i_AS.RunTaskSchedule(pa);
                else
                {
                    s1 = string.Format("({0:n0}:{1}) Incomprehensible task type. Task: {2}",
                        pa.NumTask, pa.LevelTask, pa.Tsk.Name);
                    pa.Tsk.WriteMessageInfo(s1);
                    FileEventLog.WriteWarting(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());               //
                }

                //  Запуск дочерних задач
                sw.Stop();
                s1 = string.Format("({0:n0}:{1}) Task: {2}, ended. Time: {4}. Testing and starting child tasks. Childer-Task: {3} ",
                    pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.Tsk.ListChilden.Count, sw.Elapsed);
                sw.Start();
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                if (pa.Tsk.ListChilden.Count != 0)
                {
                    List<TaskAction.ParamActior> li_pa = new List<TaskAction.ParamActior>();
                    System.Action<TaskAction.ParamActior> act = new Action<TaskAction.ParamActior>(_RunTaskBarrier);
                    ulong n1 = 1;
                    foreach (Models.Task tsk_ch in pa.Tsk.ListChilden)
                    {
                        if (tsk_ch.IsRun)
                        {
                            li_pa.Add(new TaskAction.ParamActior()
                            {
                                Tsk = tsk_ch,
                                retSql = pa.retSql,
                                LevelTask = pa.LevelTask + 1,
                                NumTask = pa.NumTask * 1000 + n1++
                            });
                        }
                    }
                    System.Threading.Barrier brr = new System.Threading.Barrier(li_pa.Count, (b) =>
                    {
                        s1 = string.Format("({0:n0}:{1}) Child-{3} tasks completed. Task: {2} ",
                           pa.NumTask, pa.LevelTask, pa.Tsk.Name, li_pa.Count);
                        pa.Tsk.WriteMessageInfo(s1);
                        FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                    });
                    foreach (TaskAction.ParamActior pa1 in li_pa) { pa1.brr = brr; }
                    ParallelLoopResult pr_rez = Parallel.ForEach<TaskAction.ParamActior>(li_pa, act);
                    brr.Dispose();
                }
                if (pa.Tsk.IsTrigers == TypeTasks.Trigger) pa.Tsk.Param.DateLastRunOk = DateTimeOffset.Now;
                else pa.Tsk.Param.DateLastRunOk = pa.Tsk.DateRun;
            }
            catch (Exception e1)
            {
                pa.Tsk.Message = e1.Message;
                pa.Tsk.IsError = true;
                pa.Tsk.WriteMessageError(e1.Message);
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                pa.brr.SignalAndWait();
                pa.Tsk.DateRun = pa.Tsk.ReCalculateDateRun(DateTimeOffset.Now.ToUniversalTime());
                if ((pa.Tsk.Param.Schedule.Interval == Period.Once) && (pa.Tsk.IsTrigers == TypeTasks.Schedule)) pa.Tsk.IsRun = false;
                pa.Tsk.UpdateDateRun();
                sw.Stop();
                if (pa.Tsk.IsTrigers == TypeTasks.Schedule)
                {
                    s1 = string.Format("({0:n0}:{1}) End of child thread execution. Time: {2}, Task: {3}",
                        pa.NumTask, pa.LevelTask, sw.Elapsed, pa.Tsk.Name, pa.NumTask);
                }
                else
                {
                    s1 = string.Format("({0:n0}:{1}) End of child thread execution tsk-trigger. Event: {2}, Time: {8}, Task: {3}, Srv: {4}, Db: {5}, Tb: {6}, Rc: {7}",
                       pa.NumTask, pa.LevelTask, pa.Tsk.Name, pa.retSql.Id, pa.retSql.NameServer, pa.retSql.NameBase,
                       pa.retSql.NameTable, pa.retSql.IdRecord, sw.Elapsed);
                }
                pa.Tsk.WriteMessageInfo(s1);
                FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        [NumFunction(100)]
        private Interfases.IActionStart GetAction(Models.Task tsk)
        {
            Interfases.IActionStart i_AS = null;
            try
            {
                switch (tsk.Param.Action)
                {
                    case Actions.SyncBank:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskBank(); 
                        break;
                    case Actions.SyncCountry:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskCountry(); 
                        break;
                    case Actions.SyncCurrency:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskCurrency();
                        break;
                    case Actions.SyncPartner:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskPartner(); 
                        break;
                    case Actions.SyncZakazka:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskZakazka(); 
                        break;
                    case Actions.CreateFvToFp:
                        i_AS = new Models.Tasks.TaskAction.ActionTriggerTest(); 
                        //i_AS =  at_FvFp = new mod.Tasks.TaskAction.ActionTriggerFvToFp();
                        break;
                    case Actions.SyncObjednavky:
                        i_AS=new Models.Tasks.TaskAction.ActionTaskObjednalky();
                        break;
#if DEBUG
                    case Actions.SyncCompany:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskCompany(); 
                        break;
                    case Actions.SyncUser:
                        i_AS = new Models.Tasks.TaskAction.ActionTaskUser(); 
                        break;
                    case Actions.TestTask:
                        i_AS = new Models.Tasks.TaskAction.ActionTriggerTest(); 
                        break;
#endif
                    case Actions.None:
                        string s1 = string.Format("Task. Id: {0}, Name: {1} - NOT running. Established: 'None'", tsk.Id, tsk.Name);
                        tsk.WriteMessageInfo(s1);
                        FileEventLog.WriteWarting(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
                        break;
                    default:
                        string s2 = string.Format("Task. Id: {0}, Name: {1} - NOT running. Established: {2}", tsk.Id, tsk.Name, tsk.Param.Action);
                        tsk.WriteMessageInfo(s2);
                        FileEventLog.WriteWarting(this, s2, System.Reflection.MethodInfo.GetCurrentMethod());
                        break;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return i_AS;
        }
    }
}

