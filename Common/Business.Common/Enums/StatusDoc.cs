using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Статус документа от Odoo
    /// </summary>
    [Serializable]
    public enum StatusDocOdoo
    {
        /// <summary>
        /// блокировка
        /// </summary>
        done = 0,
        /// <summary>
        /// Предложение цен
        /// </summary>
        draft = 1,
        /// <summary>
        /// Комерческое предложение отправленно
        /// </summary>
        send = 2,
        /// <summary>
        /// Заказ на продажу
        /// </summary>
        sale = 3,
        /// <summary>
        /// Отменить
        /// </summary>
        cansel = 4
    }
    /// <summary>
    /// Статус для crm.lead
    /// </summary>
    [Serializable]
    public enum StatusCrm
    {
        /// <summary>
        /// блокировка
        /// </summary>
        None = 0,
        /// <summary>
        /// Новый
        /// </summary>
        New = 1,
        /// <summary>
        /// Квалифицированный
        /// </summary>
        Qualified = 2,
        /// <summary>
        /// Предложение
        /// </summary>
        Proposition = 3,
        /// <summary>
        /// Выиграл
        /// </summary>
        Won = 4
    }
}
