using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    [NumClass(51)]
    [Serializable]
    public class Cislo : Interfases.BaseModelTable
    {
        public Cislo() : base(Actions.SyncCislo) { }
        public Cislo(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncCislo) { }
        public Cislo(Actions act, Models.Servers Server, string BaseData, string Ico) : base(0, Server, BaseData, Ico, Actions.SyncCislo)
        {
            LoadSql(act);
        }

        #region  ==========  Property  ==========
        /// <summary>
        /// Год 
        /// </summary>
        public int Rok { private set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int RelCrAg { private set; get; }
        /// <summary>
        /// Полное значение Cislo для вставки в запись
        /// </summary>
        public string NewValue { get { return this.Ids + this.Name; } }
        /// <summary>
        /// Новое значение для обновления
        /// </summary>
        public int NowCislo { get { return int.Parse(this.Name.Trim()) + 1; } }
        /// <summary>
        /// Длина числового ряда
        /// </summary>
        public int LengthCislo { get { return this.Name.Length; } }
        /// <summary>
        /// Новое значение в строковом виде
        /// </summary>
        public string NowCisloString { get { return this.NowCislo.ToString(string.Format("D{0}", this.LengthCislo)); } }
        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ids)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = string.Format(@"SELECT * FROM sCRady WHERE (ID = @ID) ", this.PrAction.TableSql);
                System.Data.SqlClient.SqlParameter pr_RelCrAg = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                pr_RelCrAg.Value = Id;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["ID"];
                    this.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    this.Name = dr["Cislo"] == DBNull.Value ? "" : dr["Cislo"].ToString().Trim();
                    this.Rok = dr["Rok"] == DBNull.Value ? 0 : (int)dr["Rok"];
                    this.RelCrAg = dr["RelCrAg"] == DBNull.Value ? 0 : (int)dr["RelCrAg"];
                }
                else
                {
                    this.Id = 0;
                    this.Ids = this.Name = "";
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
        [NumFunction(17)]
        public void LoadSql(Actions act)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = string.Format(@"SELECT ID, Rok, IDS, Cislo, RelCrAg " +
                    @" FROM sCRady WHERE (RelCrAg = @RelCrAg) AND (Rok = @Rok) " +
                    @" ORDER BY Rok DESC", this.PrAction.TableSql);
                ActionProperty ap = new ActionProperty(act);
                System.Data.SqlClient.SqlParameter pr_RelCrAg = cm.Parameters.Add("RelCrAg", System.Data.SqlDbType.Int);
                pr_RelCrAg.Value = ap.RelCrAg;
                System.Data.SqlClient.SqlParameter pr_Rok = cm.Parameters.Add("Rok", System.Data.SqlDbType.Int);
                pr_Rok.Value = DateTime.Now.Year;

                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["ID"];
                    this.Rok = dr["Rok"] == DBNull.Value ? 0 : (int)dr["Rok"];
                    this.Ids = dr["IDS"] == DBNull.Value ? "" : dr["IDS"].ToString().Trim();
                    this.Name = dr["Cislo"] == DBNull.Value ? "" : dr["Cislo"].ToString().Trim();
                    this.RelCrAg = dr["RelCrAg"] == DBNull.Value ? 0 : (int)dr["RelCrAg"];
                }
                else
                {
                    this.Id = 0;
                    this.Ids = this.Name = "";
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
        [NumFunction(2)]
        protected override void CreateSql()
        {
            throw new NotImplementedException();
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET Cislo = @Cislo, Ucetni = @Ucetni, DatSave = @DatSave " +
                        @" WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Cislo = cm.Parameters.Add("Cislo", System.Data.SqlDbType.VarChar);
                pr_Cislo.Value = this.NowCisloString;
                System.Data.SqlClient.SqlParameter pr_DatSave = cm.Parameters.Add("DatSave", System.Data.SqlDbType.DateTime);
                pr_DatSave.Value = DateTime.Now;
                System.Data.SqlClient.SqlParameter pr_Ucetni = cm.Parameters.Add("Ucetni", System.Data.SqlDbType.VarChar);
                pr_Ucetni.Value = SqlScripts.NameUserUcetni;
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
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
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  ==========  Pohoda  ==========
        [NumFunction(5)]
        protected override void LoadPohoda(int Id, string Ids)
        {
            this.LoadSql(Id, Ids);
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
            throw new NotImplementedException();
        }
        [NumFunction(10)]
        protected override void CreateOdoo()
        {
            throw new NotImplementedException();
        }
        [NumFunction(11)]
        protected override void UpdateOdoo()
        {
            throw new NotImplementedException();
        }
        [NumFunction(12)]
        protected override void DeleteOdoo()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  ==========  PostgreSQL  ==========
        [NumFunction(13)]
        protected override void LoadPostgre(int Id, string Ids)
        {
            throw new NotImplementedException();
        }
        [NumFunction(14)]
        protected override void CreatePostgre()
        {
            throw new NotImplementedException();
        }
        [NumFunction(15)]
        protected override void UpdatePostgre()
        {
            throw new NotImplementedException();
        }
        [NumFunction(16)]
        protected override void DeletePostgre()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  ==========  Static  ==========

        public static Cislo GetCislo(Actions act, Models.Servers Server, string BaseData, string Ico)
        {
            Cislo cs = new Cislo(act, Server, BaseData, Ico);
            return cs;
        }

        #endregion
    }
}
