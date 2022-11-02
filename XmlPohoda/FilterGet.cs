using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    /// <summary>
    /// Данные для фильтра запроса данных. Приоритет от 0 (высокий) до 3 (низкий). Значение '0' или 'null' или 'пусто' означает 'не используется' 
    /// </summary>
    public class FilterGet
    {
        /// <summary>
        /// Поиск по ID записи. Приоритет = 0
        /// </summary>
        public int Id { set; get; } = 0;
        /// <summary>
        /// Поиск по Cislo (Ids) записи. Приоритет = 1
        /// </summary>
        public string Ids { set; get; }
        /// <summary>
        /// Поиск по имени компании записи. Приоритет = 3
        /// </summary>
        public string Company { set; get; }
        /// <summary>
        /// Поиск по ICO компании записи. Приоритет = 2
        /// </summary>
        public string Ico { set; get; }
    }
}
