using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable]
    public enum Actions
    {
        /// <summary>
        /// Не определено
        /// </summary>
        None = 0,
        /// <summary>
        /// Тестовый режим
        /// </summary>
        TestTask = 4,
        /// <summary>
        /// Синхронизация партнёра
        /// </summary>
        SyncPartner = 1,
        /// <summary>
        /// Синхронизация валюты
        /// </summary>
        SyncCurrency = 2,
        /// <summary>
        /// Синхронизация стран
        /// </summary>
        SyncCountry = 3,
        /// <summary>
        /// Синхронизация банков
        /// </summary>
        SyncBank = 5,
        /// <summary>
        /// Создание FP из FV
        /// </summary>
        CreateFvToFp = 6,
        /// <summary>
        /// Синхронизация обьедналок
        /// </summary>
        SyncObjednavky = 7,
        /// <summary>
        /// Синхронизация заказки
        /// </summary>
        SyncZakazka = 8,
        /// <summary>
        /// Компания
        /// </summary>
        SyncCompany = 9,
        /// <summary>
        /// Unit of Measure. Единица измерения
        /// </summary>
        SyncUom = 10,
        /// <summary>
        /// Unit of Measure. Единица измерения
        /// </summary>
        SyncUomCategory = 11,
        /// <summary>
        /// User
        /// </summary>
        SyncUser = 12,
        /// <summary>
        /// Продукт - категория
        /// </summary>
        SyncProductCategory = 13,
        /// <summary>
        /// Продукт - шаблон
        /// </summary>
        SyncProductTemplate = 14,
        /// <summary>
        /// Продукт
        /// </summary>
        SyncProduct = 15,
        /// <summary>
        /// Деталировка Zakazky
        /// </summary>
        SyncZakazkaPlanning = 16,
        /// <summary>
        /// Деталировка Zakazky
        /// </summary>
        SyncCislo = 17,
        /// <summary>
        /// Банковские счета
        /// </summary>
        SyncPartnerBank = 18,
        /// <summary>
        /// Cinnost
        /// </summary>
        SyncCin = 19,
        /// <summary>
        /// Stredisco
        /// </summary>
        SyncStr = 20,
        /// <summary>
        /// Form Uhrada
        /// </summary>
        SyncFornUh = 21,
        /// <summary>
        /// Predpontacia
        /// </summary>
        SyncPk = 22,
		SyncFactura = 23
	}
}
