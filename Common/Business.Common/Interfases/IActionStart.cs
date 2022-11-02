using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfases
{
    public interface IActionStart
    {
        [NumFunction(1)]
        bool RunTaskTriggers(Models.Tasks.TaskAction.ParamActior pa);
        [NumFunction(2)]
        bool RunTaskSchedule(Models.Tasks.TaskAction.ParamActior pa);
    }
}
