using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Класс - описывающий действие автомата
    /// </summary>
    [Serializable]
    public class ActionProperty
    {
        /// <summary>
        /// Действие
        /// </summary>
        public Actions Action { set; get; }
        /// <summary>
        /// Действие в строковом варианте
        /// </summary>
        public string sAction { get { return Action.ToString(); } }
        /// <summary>
        /// Действие в числовом варианте
        /// </summary>
        public int nAction { get { return (int)Action; } }
        /// <summary>
        /// На какие задачи (Тригер или расписание) распространяется данное действие 
        /// </summary>
        public TypeTasks TypeTask { set; get; }
        /// <summary>
        /// На какие сервера распространяется данное действие 
        /// </summary>
        public TypeServers TypeServer { set; get; }
        /// <summary>
        /// Таблица в SQL
        /// </summary>
        public string TableSql { set; get; }
        /// <summary>
        /// Дополнительная таблица в SQL
        /// </summary>
        public string TableSqlDop1 { set; get; }
        /// <summary>
        /// Таблица в ODOO
        /// </summary>
        public string TableOdoo { set; get; }
        /// <summary>
        /// Таблица в ODOO дополнительная
        /// </summary>
        public string TableOdooDop1 { set; get; }
        /// <summary>
        /// Таблица в PostgreSQL
        /// </summary>
        public string TablePostgreSql { set; get; }
        /// <summary>
        /// Таблица в PostgreSQL дополнительная
        /// </summary>
        public string TablePostgreSqlDop1 { set; get; }
        /// <summary>
        /// Таблица в PostgreSQL дополнительная 2
        /// </summary>
        public string TablePostgreSqlDop2 { set; get; }
        /// <summary>
        /// Имя задачи
        /// </summary>
        public string ViewName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int RelCrAg { set; get; } = 0;

        public ActionProperty(Actions atc)
        {
            Action = atc;
            TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
            RelCrAg = 0;
            switch (Action)
            {
                case Actions.SyncBank:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sBanky";
                    TableOdoo = "res.bank";
                    TablePostgreSql = "res_bank";
                    ViewName = "Bank synchronization";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PohodaXml | TypeServers.PostgreSQL;
                    break;
                case Actions.SyncCountry:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sZeme";
                    TableOdoo = "res.country";
                    TablePostgreSql = "res_country";
                    ViewName = "Country synchronization";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PohodaXml | TypeServers.PostgreSQL;
                    break;
                case Actions.SyncCurrency:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sCMeny";
                    TableOdoo = "res.currency";
                    TablePostgreSql = "res_currency";
                    ViewName = "Currency synchronization";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PohodaXml | TypeServers.PostgreSQL;
                    break;
                case Actions.SyncPartner:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    TableSql = "AD";
                    TableOdoo = "res.partner";
                    TablePostgreSql = "res_partner";
                    ViewName = "Partner synchronization";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PohodaXml | TypeServers.PostgreSQL;
                    RelCrAg = 37;
                    break;
                case Actions.SyncPartnerBank:
                    TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "AD";
                    TableSqlDop1 = "ADucet";
                    TableOdoo = "res.partner.bank";
                    TablePostgreSql = "res_partner_bank";
                    ViewName = "Partner-bank synchronization";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PohodaXml | TypeServers.PostgreSQL;
                    break;
                case Actions.SyncCompany:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "Firma";
                    TableOdoo = "res.company";
                    TablePostgreSql = "res_company";
                    ViewName = "Company synchronization";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PostgreSQL | TypeServers.PostgreSQL;
                    break;
                case Actions.SyncUser:
                    TableSqlDop1 = "";
                    RelCrAg = 0;
                    TableSql = "sOdpOsoby";
                    TableOdoo = "res.users";
                    TableOdooDop1 = "res.groups";
                    TablePostgreSql = "res_users";
                    TablePostgreSqlDop1 = "res_groups_users_rel";
                    TablePostgreSqlDop2 = "res_company_users_rel";
                    ViewName = "User(s) synchronization";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PostgreSQL | TypeServers.PostgreSQL;
                    break;
                case Actions.SyncZakazka:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    TableSql = "sZAK";
                    TableOdoo = "project.project";//"crm.lead";
                    TablePostgreSql = "project_project"; //"crm_lead";
                    ViewName = "Zakazky synchronization";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.MsSql | TypeServers.Odoo | TypeServers.PohodaXml | TypeServers.PostgreSQL;
                    RelCrAg = 20;
                    break;
                case Actions.SyncObjednavky:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    TableSql = "OBJ";
                    TableOdoo = "sale.order";
                    TablePostgreSql = "sale_order";
                    ViewName = "Objednalky synchronization";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.None;
                    RelCrAg = 10;
                    RelCrAg = 21;
                    break;
                case Actions.TestTask:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "AD";
                    TableOdoo = "res.partner";
                    TablePostgreSql = "res_partner";
                    ViewName = "Test task";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.CreateFvToFp:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "FA";
                    TableOdoo = "";
                    TablePostgreSql = "";
                    ViewName = "aaaaa";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncUom:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sMJ";
                    TableOdoo = "uom.uom";
                    TablePostgreSql = "uom_uom";
                    ViewName = "Unit of Measure";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncUomCategory:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "";
                    TableOdoo = "uom.category";
                    TablePostgreSql = "uom_category";
                    ViewName = "Unit of Measure categpry";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncProductCategory:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "";
                    TableOdoo = "product.category";
                    TablePostgreSql = "product_category";
                    ViewName = "Продукт - категория";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncProductTemplate:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "";
                    TableOdoo = "product.template";
                    TablePostgreSql = "product_template";
                    ViewName = "Продукт - шаблон";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncProduct:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "";
                    TableOdoo = "product.product";
                    TablePostgreSql = "product_product";
                    ViewName = "Продукт";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncZakazkaPlanning:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sZAKplan";
                    TableOdoo = "sale.order.line";
                    TablePostgreSql = "sale_order_line";
                    ViewName = "Планирование Zakazky";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.None:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "";
                    TableOdoo = "";
                    TablePostgreSql = "";
                    ViewName = "None";
                    TypeTask = TypeTasks.Schedule | TypeTasks.Trigger;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncCislo:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sCRady";
                    TableOdoo = "";
                    TablePostgreSql = "";
                    ViewName = "None";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncCin:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sCIN";
                    TableOdoo = "x_ph.cin";
                    TablePostgreSql = "x_ph_cin";
                    ViewName = "None";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncStr:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sSTR";
                    TableOdoo = "x_ph.str";
                    TablePostgreSql = "x_ph_str";
                    ViewName = "None";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncFornUh:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "sFormUh";
                    TableOdoo = "x_ph.formuh";
                    TablePostgreSql = "x_ph_formuh";
                    ViewName = "None";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                case Actions.SyncPk:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "pPK";
                    TableOdoo = "x_ph.ppk";
                    TablePostgreSql = "x_ph_ppk";
                    ViewName = "None";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
                default:
                    TableSqlDop1 = TableOdooDop1 = TablePostgreSqlDop1 = TablePostgreSqlDop2 = "";
                    RelCrAg = 0;
                    TableSql = "";
                    TableOdoo = "";
                    TablePostgreSql = "";
                    ViewName = "None";
                    TypeTask = TypeTasks.None;
                    TypeServer = TypeServers.None;
                    break;
            }
        }
        /// <summary>
        /// Проверка, действия - задачи
        /// </summary>
        /// <param name="Tsk"></param>
        /// <returns></returns>
        public bool CheckTypeTask(TypeTasks Tsk)
        {
            return TypeTask.HasFlag(Tsk);
        }

        /// <summary>
        /// Проверка, действия - сервера
        /// </summary>
        /// <param name="Srv"></param>
        /// <returns></returns>
        public bool CheckTypeServer(TypeServers Srv)
        {
            return TypeServer.HasFlag(Srv);
        }

        /// <summary>
        /// Получить список действий по расписанию
        /// </summary>
        /// <returns></returns>
        public static List<ActionProperty> ListSchedule()
        {
            List<ActionProperty> li = new List<ActionProperty>();
            Type enm = typeof(Actions);
            Actions[] ss = (Actions[])enm.GetEnumValues();
            foreach (Actions item in ss)
            {
                ActionProperty ap = new ActionProperty(item);
                if (ap.CheckTypeTask(TypeTasks.Schedule))
                {
                    li.Add(ap);
                }
            }
            return li;
        }

        /// <summary>
        /// Получить список триггерных действий
        /// </summary>
        /// <returns></returns>
        public static List<ActionProperty> ListTrigger()
        {
            List<ActionProperty> li = new List<ActionProperty>();
            Type enm = typeof(Actions);
            Actions[] ss = (Actions[])enm.GetEnumValues();
            foreach (Actions item in ss)
            {
                ActionProperty ap = new ActionProperty(item);
                if (ap.CheckTypeTask(TypeTasks.Trigger))
                {
                    li.Add(ap);
                }
            }
            return li;
        }
    }
}
