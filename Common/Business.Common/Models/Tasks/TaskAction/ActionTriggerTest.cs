using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    [NumClass(33)]
    [Serializable]
    public class ActionTriggerTest : Interfases.IActionStart
    {

        [NumFunction(1)]
        public bool RunTaskTriggers(ParamActior sender)
        {
            bool b1 = true;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            ParamActior pa = (ParamActior)sender;
            try
            {
                Random r = new Random(DateTime.Now.Millisecond);
                int n_timer_sec = r.Next(1, 300);
                System.Threading.Thread.Sleep(n_timer_sec * 1000);
                b1 = false;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                sw.Stop();
            }
            return b1;
        }

        [NumFunction(2)]
        public bool RunTaskSchedule(ParamActior sender)
        {
            bool b1 = true;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            try
            {
                Random r = new Random(DateTime.Now.Millisecond);
                int n_timer_sec = r.Next(1, 300);
                System.Threading.Thread.Sleep(n_timer_sec * 1000);
                b1 = false;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                sw.Stop();
            }
            return b1;
        }
    }
}
