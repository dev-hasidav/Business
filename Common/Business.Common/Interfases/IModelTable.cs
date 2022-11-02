using Business.Atributes;
using Business.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfases
{
    public interface IModelPropertyTable
    {
        int Id { set; get; }
        string Name { set; get; }
        string Ids { set; get; }
        bool Active { set; get; }

        void Load(int Id, string Name);
        void Create();
        void Update();
        void Delete();

    }
    public interface ICompanyUser
    {
        string CompanyIco { set; get; }
        Partner Partners { set; get; }
        string UserName { set; get; }
    }
    [NumClass(44)]
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Ids: {Ids}, Name: {Name}, Srv: {Srv.Name}, Type: {Srv.Type}, Base: {Base}")]
    public abstract class BaseModelTable : IModelPropertyTable
    {
        /// <summary>
        /// Цифровой идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя элемента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// строковой идентификатор
        /// </summary>
        public string Ids { get; set; }
        /// <summary>
        /// Свойства действия
        /// </summary>
        public ActionProperty PrAction { get; protected set; }
        /// <summary>
        /// Данные о сервере
        /// </summary>
        public Models.Servers Srv { set; get; }
        /// <summary>
        /// База данных
        /// </summary>
        public string Base { set; get; }
        /// <summary>
        /// ICO для текущей базы
        /// </summary>
        public string IcoBase { set; get; }
        /// <summary>
        /// Включённая запись или нет
        /// </summary>
        public bool Active { set; get; }

        public BaseModelTable(Actions act) { this.PrAction = new ActionProperty(act); }
        public BaseModelTable(int Id, Models.Servers Server, string BaseData, string IcoBase, Actions act)
        {
            this.PrAction = new ActionProperty(act);
            this.Srv = Server;
            this.Base = BaseData;
            this.IcoBase = IcoBase;
            this.Load(Id, null);
        }
        public BaseModelTable(string Ids, Models.Servers Server, string BaseData, string IcoBase, Actions act, string DopName = null)
        {
            this.PrAction = new ActionProperty(act);
            this.Srv = Server;
            this.Base = BaseData;
            this.IcoBase = IcoBase;
            this.Name = DopName;
            this.Load(0, Ids);
        }

        #region  ==========  All Load-Create-Update-Delete  ==========

        /// <summary>
        /// Загрузить данные из указанного сервера (Srv)
        /// </summary>
        /// <param name="Id">ID</param>
        /// <param name="Ids">ID string</param>
        [NumFunction(17)]
        public void Load(int Id, string Ids)
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                    LoadSql(Id, Ids);
                    break;
                case TypeServers.PohodaXml:
                    LoadPohoda(Id, Ids);
                    break;
                case TypeServers.Odoo:
                    LoadOdoo(Id, Ids);
                    break;
                case TypeServers.PostgreSQL:
                    LoadPostgre(Id, Ids);
                    break;
                case TypeServers.None:
                    break;
            }
        }

        /// <summary>
        /// Создать запись на указанном сервере (Srv)
        /// </summary>
        [NumFunction(18)]
        public void Create()
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                    CreateSql();
                    break;
                case TypeServers.PohodaXml:
                    CreatePohoda();
                    break;
                case TypeServers.Odoo:
                    CreateOdoo();
                    break;
                case TypeServers.PostgreSQL:
                    CreatePostgre();
                    break;
                case TypeServers.None:
                    break;
            }
        }

        /// <summary>
        /// Обновить запись на указанном сервере (Srv)
        /// </summary>
        [NumFunction(19)]
        public void Update()
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                    UpdateSql();
                    break;
                case TypeServers.PohodaXml:
                    UpdatePohoda();
                    break;
                case TypeServers.Odoo:
                    UpdateOdoo();
                    break;
                case TypeServers.PostgreSQL:
                    UpdatePostgre();
                    break;
                case TypeServers.None:
                    break;
            }
        }

        /// <summary>
        /// Удалить запись на указанном сервере (Srv)
        /// </summary>
        [NumFunction(20)]
        public void Delete()
        {
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                    DeleteSql();
                    break;
                case TypeServers.PohodaXml:
                    DeletePohoda();
                    break;
                case TypeServers.Odoo:
                    DeleteOdoo();
                    break;
                case TypeServers.PostgreSQL:
                    DeletePostgre();
                    break;
                case TypeServers.None:
                    break;
            }
        }

        /// <summary>
        /// Быстрый способ получить Ids, Cislo и т.д. по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NumFunction(22)]
        public string Load(int Id)
        {
            string Ico = "";
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                    Ico = LoadSql(Id);
                    break;
                case TypeServers.PohodaXml:
                    Ico = LoadPohoda(Id);
                    break;
                case TypeServers.Odoo:
                    Ico = LoadOdoo(Id);
                    break;
                case TypeServers.PostgreSQL:
                    Ico = LoadPostgre(Id);
                    break;
                case TypeServers.None:
                    break;
            }
            return Ico;
        }

        /// <summary>
        /// Быстрый способ получить Id  по Ids, Cislo и т.д.
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [NumFunction(23)]
        public int Load(string Ids)
        {
            int Id = 0;
            switch (Srv.Type)
            {
                case TypeServers.MsSql:
                    Id = LoadSql(Ids);
                    break;
                case TypeServers.PohodaXml:
                    Id = LoadPohoda(Ids);
                    break;
                case TypeServers.Odoo:
                    Id = LoadOdoo(Ids);
                    break;
                case TypeServers.PostgreSQL:
                    Id = LoadPostgre(Ids);
                    break;
                case TypeServers.None:
                    break;
            }
            return Id;
        }

        #endregion

        #region  ==========  SQL  ==========

        /// <summary>
        /// Загрузить данные из SQL
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="Ids">Id строчный записи</param>
        [NumFunction(1)]
        protected abstract void LoadSql(int Id, string Ids);

        [NumFunction(24)]
        protected virtual string LoadSql(int Id)
        {
            return "";
        }

        [NumFunction(25)]
        protected virtual int LoadSql(string Ids)
        {
            return 0;
        }

        /// <summary>
        /// Создать новую запись в SQL
        /// </summary>
        [NumFunction(2)]
        protected abstract void CreateSql();

        /// <summary>
        /// Обновить запись SQL
        /// </summary>
        [NumFunction(3)]
        protected abstract void UpdateSql();

        /// <summary>
        /// Удалить запись SQL
        /// </summary>
        [NumFunction(4)]
        protected abstract void DeleteSql();

        #endregion

        #region  ==========  Pohoda  ==========

        /// <summary>
        /// Загрузить данные из Pohoda
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="Ids">Id строчный записи</param>
        [NumFunction(5)]
        protected abstract void LoadPohoda(int Id, string Ids);

        [NumFunction(26)]
        protected virtual string LoadPohoda(int Id)
        {
            return LoadSql(Id);
        }

        [NumFunction(27)]
        protected virtual int LoadPohoda(string Ids)
        {
            return LoadSql(Ids);
        }

        /// <summary>
        /// Создать новую запись в Pohoda
        /// </summary>
        [NumFunction(6)]
        protected abstract void CreatePohoda();

        /// <summary>
        /// Обновить запись Pohoda
        /// </summary>
        [NumFunction(7)]
        protected abstract void UpdatePohoda();

        /// <summary>
        /// Удалить запись Pohoda
        /// </summary>
        [NumFunction(8)]
        protected abstract void DeletePohoda();

        protected void GetMessage(Pohoda.Xml.ReturnDocXml doc)
        {
            if (doc.IsSuccess)
            {
                FileEventLog.WriteOk(this, doc.Message, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            else
            {
                FileEventLog.WriteErr(this, new Exception(doc.Message), System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }
        protected void SetMessage(Pohoda.Xml.ReturnDocXml doc)
        {
            if (doc.IsSuccess)
            {
                FileEventLog.WriteOk(this, doc.Message, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            else
            {
                FileEventLog.WriteErr(this, new Exception(doc.Message), System.Reflection.MethodInfo.GetCurrentMethod());
            }
            foreach (string item in doc.CollectionMessage)
            {
                FileEventLog.WriteWarting(this, item, System.Reflection.MethodInfo.GetCurrentMethod());
            }
        }

        #endregion

        #region  ==========  Odoo  ==========

        /// <summary>
        /// Загрузить данные из Odoo
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="Ids">Id строчный записи</param>
        [NumFunction(9)]
        protected abstract void LoadOdoo(int Id, string Ids);

        [NumFunction(28)]
        protected virtual string LoadOdoo(int Id)
        {
            return LoadPostgre(Id);
        }

        [NumFunction(29)]
        protected virtual int LoadOdoo(string Ids)
        {
            return LoadPostgre(Ids);
        }

        /// <summary>
        /// Создать новую запись в Odoo
        /// </summary>
        [NumFunction(10)]
        protected abstract void CreateOdoo();

        /// <summary>
        /// Обновить запись Odoo
        /// </summary>
        [NumFunction(11)]
        protected abstract void UpdateOdoo();

        /// <summary>
        /// Удалить запись Odoo
        /// </summary>
        [NumFunction(12)]
        protected abstract void DeleteOdoo();

        #endregion

        #region  ==========  PostgreSQL  ==========

        /// <summary>
        /// Загрузить данные из PostgreSQL
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="Ids">Id строчный записи</param>
        [NumFunction(13)]
        protected abstract void LoadPostgre(int Id, string Ids);

        [NumFunction(30)]
        protected virtual string LoadPostgre(int Id)
        {
            return "";
        }

        [NumFunction(31)]
        protected virtual int LoadPostgre(string Ids)
        {
            return 0;
        }

        /// <summary>
        /// Создать новую запись в PostgreSQL
        /// </summary>
        [NumFunction(14)]
        protected abstract void CreatePostgre();

        /// <summary>
        /// Обновить запись PostgreSQL
        /// </summary>
        [NumFunction(15)]
        protected abstract void UpdatePostgre();

        /// <summary>
        /// Удалить запись PostgreSQL
        /// </summary>
        [NumFunction(16)]
        protected abstract void DeletePostgre();

        #endregion

        [NumFunction(21)]
        public static List<int> GetId(Models.Servers Srv, string BaseName, Actions act)
        {
            List<int> li = new List<int>();
            ActionProperty p_act = new ActionProperty(act);
            System.Data.SqlClient.SqlConnection cn_sql = null;
            Npgsql.NpgsqlConnection cn_psSql = null;
            try
            {
                switch (Srv.Type)
                {
                    case TypeServers.MsSql:
                    case TypeServers.PohodaXml:
                        cn_sql = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, BaseName));
                        cn_sql.Open();
                        System.Data.SqlClient.SqlCommand cm_s = new System.Data.SqlClient.SqlCommand();
                        cm_s.Connection = cn_sql;
                        cm_s.CommandText = string.Format(@"SELECT ID FROM {0} order by ID", p_act.TableSql);
                        System.Data.SqlClient.SqlDataReader dr_s = cm_s.ExecuteReader();
                        while (dr_s.Read())
                        {
                            li.Add((int)dr_s["ID"]);
                        }
                        dr_s.Close();
                        break;
                    case TypeServers.Odoo:
                        List<string> li_pole = new List<string>
                            {
                                "id"
                            };
                        OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                        OdooScripts odScr = new OdooScripts();
                        List<Dictionary<string, string>> Datas = null;
                        switch (act)
                        {
                            case Actions.SyncBank:
                            case Actions.SyncCurrency:
                                //odoFiltr.Filter("active", "=", false);
                                //Datas = odScr.SelectRowFromTable(Srv, p_act.TableOdoo, li_pole, odoFiltr);
                                //foreach (var item in Datas)
                                //{
                                //    int Idn = int.Parse(item["id"]);
                                //    li.Add(Idn);
                                //}
                                //odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                                //odoFiltr.Filter("active", "=", true);
                                //break;
                            case Actions.SyncPartner:
                                odoFiltr.Filter("active", "=", false);
                                Datas = odScr.SelectRowFromTable(Srv, p_act.TableOdoo, li_pole, odoFiltr);
                                foreach (var item in Datas)
                                {
                                    int Idn = int.Parse(item["id"]);
                                    li.Add(Idn);
                                }
                                odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                                odoFiltr.Filter("active", "=", true);
                                break;
                            default:
                                break;
                        }
                        Datas = odScr.SelectRowFromTable(Srv, p_act.TableOdoo, li_pole, odoFiltr);
                        foreach (var item in Datas)
                        {
                            int Idn = int.Parse(item["id"]);
                            li.Add(Idn);
                        }
                        break;
                    case TypeServers.PostgreSQL:
                        cn_psSql = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                        cn_psSql.Open();
                        Npgsql.NpgsqlCommand cm_ps = new Npgsql.NpgsqlCommand();
                        cm_ps.Connection = cn_psSql;
                        cm_ps.CommandText = string.Format(@"SELECT id FROM {0} order by id", p_act.TablePostgreSql);
                        Npgsql.NpgsqlDataReader dr_ps = cm_ps.ExecuteReader();
                        while (dr_ps.Read())
                        {
                            li.Add((int)dr_ps["id"]);
                        }
                        dr_ps.Close();
                        break;
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                cn_sql?.Close();
                cn_psSql?.Close();
            }
            return li;
        }
    }
}
