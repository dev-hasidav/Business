using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ScheduleReturn
    {
        /// <summary>
        /// Возможно ли вообще рассчитать расписание True = да, False = нет
        /// </summary>
        public TimeRange StatusRun { set; get; }
        /// <summary>
        /// Рассчитанная дата если IsRun = True
        /// </summary>
        public DateTimeOffset Date { set; get; }
        /// <summary>
        /// Сообщение о причине невозможности рассчитать расписание
        /// </summary>
        public string Message { set; get; }
    }
}
