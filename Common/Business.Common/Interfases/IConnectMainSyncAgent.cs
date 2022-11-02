using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = Business.Models;

namespace Business.Interfases
{
    public interface IConnectMainSyncAgent
    {
        #region  ==========  Test-запросы-r  ==========

        /// <summary>
        /// Проверка подключения серверов
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(7)]
        ResponseResult CheckServers(mod.Servers srv);

        #endregion

        #region  ==========  работа с базой(сервером)  ==========

        /// <summary>
        /// Получить список серверов из Main-базы
        /// </summary>
        /// <returns></returns>
        [NumFunction(4)]
        ResponseResult GetServers(bool IsEnable = false);

        /// <summary>
        /// Получить список баз 'pohoda' с сервера
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(15)]
        ResponseResult GetListBase(mod.Servers srv);

        /// <summary>
        /// Проверка и если надо создание базы и таблицы на агенте
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(29)]
        ResponseResult CheckOrCreateTableAgent(mod.Servers srv);

        /// <summary>
        /// Проверка и создание таблицы ASynchro и полей в таблицах
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(36)]
        ResponseResult CheckingOrCreateOdoo(mod.Servers srv);

        /// <summary>
        /// Перевод event-trigger в состояние - ПРОЧИТАННО
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="ret"></param>
        [NumFunction(36)]
        void UpdateReadTriggers(mod.Servers Srv, RetTriggers ret);
        #endregion


        #region  ==========  Action Task  ==========

        #region  ==========  Bank  ==========

        /// <summary>
        /// Получить список или одну запись о банке
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(39)]
        ResponseResult GetListBank(mod.Servers Srv, string NameBase, int Id = 0);

        /// <summary>
        /// Создание новой записи в Bank
        /// </summary>
        /// <param name="Bnk"></param>
        /// <returns></returns>
        [NumFunction(40)]
        ResponseResult CreateBank(mod.Tables.Bank Bnk);

        /// <summary>
        /// Обновление записи в Bank
        /// </summary>
        /// <param name="Bnk"></param>
        /// <returns></returns>
        [NumFunction(41)]
        ResponseResult UpdateBank(mod.Tables.Bank Bnk);

        #endregion

        #region  ==========  Country  ==========

        /// <summary>
        /// Получить список или одну запись о стране
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(42)]
        ResponseResult GetListCountry(mod.Servers Srv, string NameBase, int Id);

        /// <summary>
        /// Создание новой записи в Country
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(43)]
        ResponseResult CreateCountry(mod.Tables.Country Cnt);

        /// <summary>
        /// Обновление записи в Country
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(44)]
        ResponseResult UpdateCountry(mod.Tables.Country Cnt);

        #endregion

        #region  ==========  Currency  ==========

        /// <summary>
        /// Получить список или одну запись о валюте
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(45)]
        ResponseResult GetListCurrency(mod.Servers Srv, string NameBase, int Id);

        /// <summary>
        /// Создание новой записи о валюте
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(46)]
        ResponseResult CreateCurrency(mod.Tables.Currency Cnt);

        /// <summary>
        /// Обновление записи о валюте
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(47)]
        ResponseResult UpdateCurrency(mod.Tables.Currency Cnt);

        #endregion

        #region  ==========  Partner  ==========

        /// <summary>
        /// Получить список или одну запись о Partner
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(48)]
        ResponseResult GetListPartner(mod.Servers Srv, string NameBase, string Ico, int Id);

        /// <summary>
        /// Создание новой записи о Partner
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(49)]
        ResponseResult CreatePartner(mod.Tables.Partner Cnt, string Ico);

        /// <summary>
        /// Обновление записи о Partner
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(50)]
        ResponseResult UpdatePartner(mod.Tables.Partner Cnt, string Ico);

        #endregion

        #region  ==========  Company  ==========

        /// <summary>
        /// Получить список или одну запись о Company
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(54)]
        ResponseResult GetListCompany(mod.Servers Srv, string NameBase, string Ico, int Id);

        /// <summary>
        /// Создание новой записи о Company
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(55)]
        ResponseResult CreateCompany(mod.Tables.Company Cnt, string Ico);

        /// <summary>
        /// Обновление записи о Company
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(56)]
        ResponseResult UpdateCompany(mod.Tables.Company Cnt, string Ico);

        #endregion

        #region  ==========  User  ==========

        /// <summary>
        /// Получить список или одну запись о User
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(54)]
        ResponseResult GetListUser(mod.Servers Srv, string NameBase, string Ico, int Id);

        /// <summary>
        /// Создание новой записи о User
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(55)]
        ResponseResult CreateUser(mod.Tables.User Cnt, string Ico);

        /// <summary>
        /// Обновление записи о User
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(56)]
        ResponseResult UpdateUser(mod.Tables.User Cnt, string Ico);

        #endregion

        #region  ==========  Zakazka  ==========

        /// <summary>
        /// Получить список или одну запись о Zakazka
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(51)]
        ResponseResult GetListZakazka(mod.Servers Srv, string NameBase, string Ico, int Id);

        /// <summary>
        /// Создание новой записи о Zakazka
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(52)]
        ResponseResult CreateZakazka(mod.Tables.Zakazka Cnt, string Ico);

        /// <summary>
        /// Обновление записи о Zakazka
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(53)]
        ResponseResult UpdateZakazka(mod.Tables.Zakazka Cnt, string Ico);

        #endregion

        #region  ==========  Objednalky  ==========

        /// <summary>
        /// Получить список или одну запись о Objednalky
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">если = 0 - то список всех записей</param>
        /// <returns></returns>
        [NumFunction(51)]
        ResponseResult GetListObjednalky(mod.Servers Srv, string NameBase, string Ico, int Id);

        /// <summary>
        /// Создание новой записи о Objednalky
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(52)]
        ResponseResult CreateObjednalky(mod.Tables.Objednalky Cnt, string Ico);

        /// <summary>
        /// Обновление записи о Objednalky
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        [NumFunction(53)]
        ResponseResult UpdateObjednalky(mod.Tables.Objednalky Cnt, string Ico);

        #endregion

        #endregion

        #region  ==========  Trigers  ==========

        /// <summary>
        /// Получить список всех тригеров по формату на указанном сервере (в том числе и через агента)
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(24)]
        Dictionary<string, Models.ListTrigger> GetDictionaryTriggers(mod.Servers srv);

        /// <summary>
        /// Проверить наличие тригера на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(25)]
        bool CheckTriggersDml(mod.Task tsk, string Base, string NameTrigger);

        /// <summary>
        /// Создать тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTableAgent"></param>
        /// <returns></returns>
        [NumFunction(26)]
        bool CreateTriggersDml(mod.Task tsk, string Base, string NameTableAgent);

        /// <summary>
        /// Обновить тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <param name="NameTableAgent"></param>
        /// <returns></returns>
        [NumFunction(27)]
        bool UodateTriggersDml(mod.Task tsk, string Base, string NameTrigger, string NameTableAgent);

        /// <summary>
        /// Удалить тригер на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="srv"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(28)]
        bool DeleteTriggersDml(mod.Servers srv, string Base, string NameTrigger, string NameTable);

        /// <summary>
        /// Обновить тригер Odoo на указанном сервере и базе (в том числе и через агента)
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(37)]
        bool UpdateTriggersOdooDml(mod.Task tsk, string Base, string NameTrigger);

        #endregion

        #region  ==========  Run task triggers  ==========

        /// <summary>
        /// Получить с сервера триггера для обработки
        /// </summary>
        /// <param name="Srv"></param>
        /// <returns></returns>
        [NumFunction(34)]
        List<RetTriggers> GetTriggers(mod.Servers Srv, Enums.StTriggers St = Enums.StTriggers.ClrTrigger);

        /// <summary>
        /// Обновить статус и дату END сборщику тригеров
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="reT"></param>
        /// <param name="St"></param>
        /// <returns></returns>
        [NumFunction(35)]
        void UpdateRemTriggers(mod.Servers Srv, RetTriggers reT, Enums.StTriggers St);

        #endregion
    }
}
