using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// через какую переменную передаются данные зля записи и обновления
    /// </summary>
    [Serializable]
    public enum NumberRecord
    {
        /// <summary>
        /// Не определено
        /// </summary>
        None = 0, 
        /// <summary>
        /// Через класс
        /// </summary>
        One = 1, 
        /// <summary>
        /// Через коллекцию класса
        /// </summary>
        Many = 2, 
    }
}
