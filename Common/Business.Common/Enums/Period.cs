using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable]
    public enum Period
    {
        /// <summary>
        /// Не определено
        /// </summary>
        None = 0,
        /// <summary>
        /// Один раз
        /// </summary>
        Once = 1,
        /// <summary>
        /// Каждую минуту
        /// </summary>
        Minute = 2,
        /// <summary>
        /// Каждый час, учитывая и минуты
        /// </summary>
        Hour = 3,
        /// <summary>
        /// Каждый день, учитывая часы и минуты
        /// </summary>
        Day = 4,
        /// <summary>
        /// Каждый выбранный день недели, учитывая насы и минуты
        /// </summary>
        Week = 5,
        /// <summary>
        /// Каждый месяц, учитывая день, часы и минуты
        /// </summary>
        Month = 6,
        /// <summary>
        /// Согласно родительскому расписанию
        /// </summary>
        TimeParent = 7
    }
}
