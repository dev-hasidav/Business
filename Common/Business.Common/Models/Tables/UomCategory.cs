using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Unit of Measure. Единица измерения - категория
    /// </summary>
    [NumClass(55)]
    [Serializable]
    public class UomCategory : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public UomCategory() : base(Actions.SyncUomCategory) { }
        public UomCategory(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncUomCategory) { }
        public UomCategory(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncUomCategory) { }

        #endregion

        #region  ==========  Property  ==========


        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ids)
        {
            try
            {
                throw new Exception(string.Format("Data request error 'UomCategory' SQL"));
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(2)]
        protected override void CreateSql()
        {
            try
            {
                throw new Exception(string.Format("Data request error 'UomCategory' SQL"));
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            try
            {
                throw new Exception(string.Format("Data request error 'UomCategory' SQL"));
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            try
            {
                throw new Exception(string.Format("Data request error 'UomCategory' SQL"));
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }

        #endregion

        #region  ==========  Pohoda  ==========
        [NumFunction(5)]
        protected override void LoadPohoda(int Id, string Ids)
        {
            LoadSql(Id, Ids);
        }
        [NumFunction(6)]
        protected override void CreatePohoda()
        {
            CreateSql();
        }
        [NumFunction(7)]
        protected override void UpdatePohoda()
        {
            UpdateSql();
        }
        [NumFunction(8)]
        protected override void DeletePohoda()
        {
            DeleteSql();
        }
        #endregion

        #region  ==========  Odoo  ==========
        [NumFunction(9)]
        protected override void LoadOdoo(int Id, string Ids)
        {
            try
            {
                List<string> li_pole = new List<string> { "id", "name", "measure_type" };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    odoFiltr.Filter("measure_type", "=", Ids);
                }
                else { throw new Exception("Input values 'UomCategory' are NULL"); }
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    this.Id = int.Parse(Datas[0]["id"]);
                    this.Name = Datas[0]["name"] == "False" ? "" : Datas[0]["name"];
                    this.Ids = Datas[0]["measure_type"] == "False" ? "" : Datas[0]["measure_type"];
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            return;
        }
        [NumFunction(10)]
        protected override void CreateOdoo()
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", this.Name },
                            { "measure_type", this.Ids }
                        };
                this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(11)]
        protected override void UpdateOdoo()
        {
            try
            {
                Dictionary<string, object> di = new Dictionary<string, object>
                    {
                        { "name", this.Name },
                        { "measure_type", this.Ids }
                    };
                OdooScripts odScr = new OdooScripts();
                odScr.UpdateRow(Srv, this.PrAction.TableOdoo, this.Id, di);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        [NumFunction(12)]
        protected override void DeleteOdoo()
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                odScr.DeleteRow(Srv, this.PrAction.TableOdoo, this.Id);
                this.Id = 0;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        #endregion

        #region  ==========  PostgreSQL  ==========
        [NumFunction(13)]
        protected override void LoadPostgre(int Id, string Ids)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                if (Id != 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ids))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where measure_type = @measure_type", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_measure_type = cm.Parameters.Add("measure_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_measure_type.Value = Ids;
                }
                else { throw new Exception("Input values 'UomCategory' are NULL"); }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["id"];
                    this.Ids = dr["measure_type"] == DBNull.Value ? "" : dr["measure_type"].ToString().Trim();
                    this.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(14)]
        protected override void CreatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (name, measure_type) VALUES (@name, @measure_type)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_measure_type = cm.Parameters.Add("measure_type", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_measure_type.Value = Ids;
                this.Id = (int)((long)cm.ExecuteScalar());
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(15)]
        protected override void UpdatePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET name = @name WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_SText = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_SText.Value = this.Name;
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        [NumFunction(16)]
        protected override void DeletePostgre()
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"DELETE FROM {0} WHERE (id = @id)", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
                this.Id = 0;
                this.Ids = "";
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Получить Единица измерения - категория по ID
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public static UomCategory GetUomCategoryIdOrName(Servers Srv, string NameBase, int Id)
        {
            UomCategory cou = new UomCategory(Id, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Получить Единица измерения - категория по measure_type (ids)
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameBase">База</param>
        /// <param name="Code">measure_type</param>
        /// <returns></returns>
        public static UomCategory GetUomCategoryIdOrName(Servers Srv, string NameBase, string Ids)
        {
            UomCategory cou = new UomCategory(Ids, Srv, NameBase, "");
            return cou;
        }

        /// <summary>
        /// Список или одна Единица измерения - категория
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="Id">id = 0 - список,  id != 0 - информация о Единица измерения - категория</param>
        /// <returns></returns>
        public static List<UomCategory> GetList(Servers Srv, string BaseName, int Id = 0)
        {
            List<UomCategory> li = new List<UomCategory>();
            if (Id == 0)
            {
                List<int> li_id = UomCategory.GetId(Srv, BaseName, Actions.SyncUomCategory);
                Dictionary<string, UomCategory> di = new Dictionary<string, UomCategory>();
                List<UomCategory> li_l = new List<UomCategory>();
                foreach (int item in li_id)
                {
                    UomCategory bn1 = new UomCategory(item, Srv, BaseName, "");
                    if (bn1.Id != 0)
                    {
                        if (bn1.Ids.Length > 2)
                        {
                            li_l.Add(bn1);
                        }
                        else if (!di.ContainsKey(bn1.Ids)) di.Add(bn1.Ids, bn1);
                    }
                }
                foreach (var item in li_l)
                {
                    item.Ids = item.Ids.Substring(0, 2);
                    if (!di.ContainsKey(item.Ids)) di.Add(item.Ids, item);
                }
                foreach (var item in di)
                {
                    li.Add(item.Value);
                }
                di.Clear();
            }
            else
            {
                UomCategory bn1 = new UomCategory(Id, Srv, BaseName, "");
                if (bn1.Id != 0) li.Add(bn1);
            }
            return li;
        }

        /// <summary>
        /// Получить информацию о Единица измерения - категория или если нет то информацию о default (Syncho) Единица измерения - категория. Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static UomCategory GetUomCategoryOrDefault(string measure_type, Servers Srv, string BaseName)
        {
            UomCategory com = new UomCategory(measure_type, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultUomCategory(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о Единица измерения - категория или если нет то информацию о default (Syncho) Единица измерения - категория. Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static UomCategory GetUomCategoryOrDefault(int id, Servers Srv, string BaseName)
        {
            UomCategory com = new UomCategory(id, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com = GetDefaultUomCategory(Srv, BaseName);
            }
            return com;
        }

        /// <summary>
        /// Получить информацию о default (Syncho) Единица измерения - категория. Если нет - создать
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static UomCategory GetDefaultUomCategory(Servers Srv, string BaseName)
        {
            UomCategoryDefault dcom = new UomCategoryDefault();
            UomCategory com = new UomCategory(dcom.MeasureType, Srv, BaseName, "");
            if (com.Id == 0)
            {
                com.Name = dcom.Name;
                com.Ids = dcom.MeasureType;
                com.Create();
                com = new UomCategory(com.Id, Srv, BaseName, "");
            }
            return com;
        }

        #endregion
    }
    public class UomCategoryDefault
    {
        public string Name { private set; get; } = "Unit";
        public string MeasureType { private set; get; } = "unit";
    }
}
