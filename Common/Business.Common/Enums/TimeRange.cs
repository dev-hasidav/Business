using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public enum TimeRange
    {
        /// <summary>
        /// Задача закончилась
        /// </summary>
        TaskOver = 0,
        /// <summary>
        /// Дата меньше текушей
        /// </summary>
        DateLessCurrent = 1,
        /// <summary>
        /// Всё хорошо, изменений не требуется
        /// </summary>
        Ok = 2,
        /// <summary>
        /// Дата вне диапозона
        /// </summary>
        DateNoRange = 3,
        /// <summary>
        /// Непонятное состояние
        /// </summary>
        Err = 4
    }
}
