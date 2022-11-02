using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tasks.TaskAction
{
    public class ParamActior
    {
        /// <summary>
        /// Ответ от сервера - триггера
        /// </summary>
        public RetTriggers retSql { set; get; }
        /// <summary>
        /// Задача вызвавшая выполнения
        /// </summary>
        public Task Tsk { set; get; }
        /// <summary>
        /// Барьер
        /// </summary>
        public System.Threading.Barrier brr { set; get; }
        /// <summary>
        /// Уровень задачи
        /// </summary>
        public int LevelTask { set; get; }
        /// <summary>
        /// Номер задачи во временни
        /// </summary>
        public ulong NumTask { set; get; }
    }
}
