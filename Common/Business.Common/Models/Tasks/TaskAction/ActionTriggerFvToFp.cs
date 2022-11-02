using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    [NumClass(32)]
    [Serializable]
    public class ActionTriggerFvToFp : Interfases.IActionStart
    {

        [NumFunction(1)]
        public bool RunTaskTriggers(ParamActior pa)
        {
            bool b1 = false;
            string s1 = string.Format("Действие для задачи. Id: {0}, Name: {1}  ----  НЕ РЕАЛИЗОВАННО", pa.Tsk.Id, pa.Tsk.Name);
            pa.Tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            return b1;
        }
        [NumFunction(2)]
        public bool RunTaskSchedule(ParamActior pa)
        {
            bool b1 = false;
            string s1 = string.Format("Действие для задачи. Id: {0}, Name: {1}  ----  НЕ РЕАЛИЗОВАННО", pa.Tsk.Id, pa.Tsk.Name);
            pa.Tsk.WriteMessageInfo(s1);
            FileEventLog.WriteOk(this, s1, System.Reflection.MethodInfo.GetCurrentMethod());
            return b1;
        }

    }
}
