using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Деталировка Zakazky
    /// </summary>
    [NumClass(57)]
    [Serializable]
    public class ZakazkaPlanning : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        public ZakazkaPlanning() : base(Actions.SyncZakazkaPlanning) { }
        public ZakazkaPlanning(int Id, Models.Servers Server, string BaseData, string Ico) : base(Id, Server, BaseData, Ico, Actions.SyncZakazkaPlanning) { }
        public ZakazkaPlanning(string Name, Models.Servers Server, string BaseData, string Ico) : base(Name, Server, BaseData, Ico, Actions.SyncZakazkaPlanning) { }

        #endregion

        #region  ==========  Property  ==========
        /// <summary>
        /// родитель полозки
        /// </summary>
        public Zakazka Parent { set; get; }
        /// <summary>
        /// поле связи в POHODA
        /// </summary>
        public int RefAg { set; get; }
        /// <summary>
        /// Цена без DPH. o-price_unit, p-Kc
        /// </summary>
        public decimal PriceUnit { set; get; }
        /// <summary>
        /// Количество  o-product_uom_qty, p-Mnozstvi
        /// </summary>
        public decimal ProductUomQty { set; get; }
        /// <summary>
        /// Время выполнения поставки (сроки).  o-customer_lead, p-
        /// </summary>
        public decimal CustomerLead { set; get; }
        /// <summary>
        /// ID продукта.  o-product_id, p-
        /// </summary>
        public int IdProduct { set; get; }
        /// <summary>
        /// Дата создания.  o-create_date, p-Datum
        /// </summary>
        public DateTime? CreateDate { set; get; }
        /// <summary>
        /// Последнее обновление.  o-write_date,  p-
        /// </summary>
        public DateTime? WriteDate { set; get; }
        /// <summary>
        /// ID - Единица измерения.  o-product_uom(int),  p-MJ(string)
        /// </summary>
        public int IdProductUom { set; get; }
        /// <summary>
        /// Единица измерения.  o-product_uom(int),  p-MJ(string)
        /// </summary>
        public string ProductUom { set; get; }
        /// <summary>
        /// Категория продукта
        /// </summary>
        public int RelDruhOper { set; get; }
        /// <summary>
        /// порядок документа в списке
        /// </summary>
        public int OrderFld { set; get; }
        /// <summary>
        /// Примечание.  p-Pozn, o-
        /// </summary>
        public string Remark { set; get; }

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Name)
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
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where ID = @ID", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where Nazev = @Nazev", this.PrAction.TableSql);
                    System.Data.SqlClient.SqlParameter pr_Nazev = cm.Parameters.Add("Nazev", System.Data.SqlDbType.VarChar);
                    pr_Nazev.Value = Name;
                }
                else { throw new Exception("Input values 'ZakazkaPolozky' are NULL"); }
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["ID"];
                    this.RefAg = (int)dr["RefAg"];
                    this.Name = dr["Nazev"] == DBNull.Value ? "" : dr["Nazev"].ToString().Trim();
                    this.PriceUnit = dr["Kc"] == DBNull.Value ? 0 : (decimal)dr["Kc"];
                    this.ProductUomQty = dr["Mnozstvi"] == DBNull.Value ? 0 : (decimal)((double)dr["Mnozstvi"]);
                    this.CustomerLead = 0;
                    this.IdProduct = 0;
                    if (dr["Datum"] != DBNull.Value)
                    {
                        this.CreateDate = (DateTime)dr["Datum"];
                        this.WriteDate = (DateTime)dr["Datum"];
                    }
                    this.ProductUom = dr["MJ"] == DBNull.Value ? "" : dr["MJ"].ToString().Trim();
                    this.RelDruhOper = dr["RelDruhOper"] == DBNull.Value ? 0 : (int)dr["RelDruhOper"];
                    this.OrderFld = dr["OrderFld"] == DBNull.Value ? 0 : (int)dr["OrderFld"];
                    this.Remark = dr["Pozn"] == DBNull.Value ? "" : dr["Pozn"].ToString().Trim();
                    ConvertNameToId();
                }
                else
                {
                    this.Id = 0;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }
        [NumFunction(2)]
        protected override void CreateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                ConvertIdToName();
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (RefAg, Nazev, Kc, Mnozstvi, Datum, MJ, RelDruhOper, OrderFld, Pozn) " +
                        @" VALUES (@RefAg, @Nazev, @Kc, @Mnozstvi, @Datum, @MJ, @RelDruhOper, @OrderFld, @Pozn)" +
                        " ; SELECT ID FROM {0} WHERE(ID = SCOPE_IDENTITY()) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_RefAg = cm.Parameters.Add("RefAg", System.Data.SqlDbType.Int);
                pr_RefAg.Value = this.Parent.Id;
                System.Data.SqlClient.SqlParameter pr_Nazev = cm.Parameters.Add("Nazev", System.Data.SqlDbType.VarChar);
                pr_Nazev.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_Kc = cm.Parameters.Add("Kc", System.Data.SqlDbType.Money);
                pr_Kc.Value = this.PriceUnit;
                System.Data.SqlClient.SqlParameter pr_Mnozstvi = cm.Parameters.Add("Mnozstvi", System.Data.SqlDbType.Float);
                pr_Mnozstvi.Value = this.ProductUomQty;
                System.Data.SqlClient.SqlParameter pr_Datum = cm.Parameters.Add("Datum", System.Data.SqlDbType.DateTime);
                pr_Datum.Value = this.WriteDate;
                System.Data.SqlClient.SqlParameter pr_MJ = cm.Parameters.Add("MJ", System.Data.SqlDbType.VarChar);
                pr_MJ.Value = this.ProductUom;
                System.Data.SqlClient.SqlParameter pr_RelDruhOper = cm.Parameters.Add("RelDruhOper", System.Data.SqlDbType.Int);
                pr_RelDruhOper.Value = this.RelDruhOper;
                System.Data.SqlClient.SqlParameter pr_OrderFld = cm.Parameters.Add("OrderFld", System.Data.SqlDbType.Int);
                pr_OrderFld.Value = this.OrderFld;
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                pr_Pozn.Value = this.Remark;
                this.Id = (int)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                ConvertIdToName();
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET RefAg = @RefAg, Nazev = @Nazev, Kc = @Kc, Mnozstvi = @Mnozstvi, Datum = @Datum, " +
                        @" MJ = @MJ, RelDruhOper = @RelDruhOper, OrderFld = @OrderFld, Pozn = @Pozn WHERE (ID = @ID) ", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_RefAg = cm.Parameters.Add("RefAg", System.Data.SqlDbType.Int);
                pr_RefAg.Value = this.Parent.Id;
                System.Data.SqlClient.SqlParameter pr_Nazev = cm.Parameters.Add("Nazev", System.Data.SqlDbType.VarChar);
                pr_Nazev.Value = this.Name;
                System.Data.SqlClient.SqlParameter pr_Kc = cm.Parameters.Add("Kc", System.Data.SqlDbType.Money);
                pr_Kc.Value = this.PriceUnit;
                System.Data.SqlClient.SqlParameter pr_Mnozstvi = cm.Parameters.Add("Mnozstvi", System.Data.SqlDbType.Float);
                pr_Mnozstvi.Value = this.ProductUomQty;
                System.Data.SqlClient.SqlParameter pr_Datum = cm.Parameters.Add("Datum", System.Data.SqlDbType.DateTime);
                pr_Datum.Value = this.WriteDate;
                System.Data.SqlClient.SqlParameter pr_MJ = cm.Parameters.Add("MJ", System.Data.SqlDbType.VarChar);
                pr_MJ.Value = this.ProductUom;
                System.Data.SqlClient.SqlParameter pr_RelDruhOper = cm.Parameters.Add("RelDruhOper", System.Data.SqlDbType.Int);
                pr_RelDruhOper.Value = this.RelDruhOper;
                System.Data.SqlClient.SqlParameter pr_OrderFld = cm.Parameters.Add("OrderFld", System.Data.SqlDbType.Int);
                pr_OrderFld.Value = this.OrderFld;
                System.Data.SqlClient.SqlParameter pr_Pozn = cm.Parameters.Add("Pozn", System.Data.SqlDbType.VarChar);
                pr_Pozn.Value = this.Remark;
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
        }
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"DELETE FROM {0} WHERE (ID = @ID)", this.PrAction.TableSql)
                };
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
                this.Id = 0;
                this.Name = "";
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }
        #endregion

        #region  ==========  Pohoda  ==========

        [NumFunction(5)]
        protected override void LoadPohoda(int Id, string Name)
        {
            LoadSql(Id, Name);
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
        protected override void LoadOdoo(int Id, string Name)
        {
            try
            {
                List<string> li_pole = new List<string>
                {
                        "id",
                        "order_id",
                        "name",
                        "price_unit",
                        "product_uom_qty",
                        "customer_lead",
                        "product_id",
                        "create_date",
                        "write_date",
                        "product_uom"
                };
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id > 0)
                {
                    odoFiltr.Filter("id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    odoFiltr.Filter("name", "=", Name);
                }
                else { throw new Exception("Input values 'ZakazkaPolozky' are NULL"); }
                OdooScripts odScr = new OdooScripts();
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    this.Id = int.Parse(Datas[0]["id"]);
                    this.Name = Datas[0]["name"] == "False" ? "" : Datas[0]["name"].Trim();
                    this.PriceUnit = decimal.Parse(Datas[0]["price_unit"]);
                    this.ProductUomQty = decimal.Parse(Datas[0]["product_uom_qty"]);
                    this.CustomerLead = decimal.Parse(Datas[0]["customer_lead"]);
                    this.IdProduct = int.Parse(Datas[0]["product_id"]);
                    this.CreateDate = DateTime.Parse(Datas[0]["create_date"]);
                    this.WriteDate = DateTime.Parse(Datas[0]["write_date"]);
                    this.IdProductUom = int.Parse(Datas[0]["product_uom"]);
                    ConvertIdToName();
                }
                else
                {
                    this.Id = 0;
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
                ConvertNameToId();
                OdooScripts odScr = new OdooScripts();
                Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "order_id", this.Parent.Id },
                            { "name", this.Name },
                            { "price_unit", this.PriceUnit },
                            { "product_uom_qty", this.ProductUomQty },
                            { "customer_lead", this.CustomerLead },
                            { "product_id", this.IdProduct },
                            { "create_date", this.CreateDate },
                            { "write_date", this.WriteDate },
                            { "product_uom", this.IdProductUom }
                        };
                this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
                this.UpdateOdoo();
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
                ConvertNameToId();
                Dictionary<string, object> di = new Dictionary<string, object>
                    {
                            { "order_id", this.Parent.Id },
                            { "name", this.Name },
                            { "price_unit", this.PriceUnit },
                            { "product_uom_qty", this.ProductUomQty },
                            { "customer_lead", this.CustomerLead },
                            { "product_id", this.IdProduct },
                            { "create_date", this.CreateDate },
                            { "write_date", this.WriteDate },
                            { "product_uom", this.IdProductUom }
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
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
        }
        #endregion

        #region  ==========  Postgre  ==========
        [NumFunction(13)]
        protected override void LoadPostgre(int Id, string Name)
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
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where id = @id", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Name))
                {
                    cm.CommandText = string.Format(@"SELECT * FROM {0} where name = @name", this.PrAction.TablePostgreSql);
                    Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_name.Value = Name;
                }
                else { throw new Exception("Input values 'ZakazkaPolozky' are NULL"); }
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["id"];

                    this.Name = dr["name"] == DBNull.Value ? "" : dr["name"].ToString().Trim();
                    this.PriceUnit = dr["price_unit"] == DBNull.Value ? 0 : (decimal)dr["price_unit"];
                    this.ProductUomQty = dr["product_uom_qty"] == DBNull.Value ? 0 : (decimal)dr["product_uom_qty"];
                    this.CustomerLead = dr["customer_lead"] == DBNull.Value ? 0 : (decimal)dr["customer_lead"];
                    this.IdProduct = dr["product_id"] == DBNull.Value ? 0 : (int)dr["product_id"];
                    if(dr["create_date"] == DBNull.Value) this.CreateDate =  (DateTime)dr["create_date"];
                    if (dr["write_date"] == DBNull.Value) this.WriteDate = (DateTime)dr["write_date"];
                    this.IdProductUom = dr["product_uom"] == DBNull.Value ? 0 : (int)dr["product_uom"];
                    ConvertIdToName();
                }
                else
                {
                    this.Id = 0;
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
                ConvertNameToId();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"INSERT INTO {0} (name, price_unit, product_uom_qty, customer_lead, product_id, create_date, write_date, product_uom) " +
                        @" VALUES (@name, @price_unit, @product_uom_qty, @customer_lead, @product_id, @create_date, @write_date, @product_uom)" +
                        " ; SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_price_unit = cm.Parameters.Add("price_unit", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_price_unit.Value = this.PriceUnit;
                Npgsql.NpgsqlParameter pr_product_uom_qty = cm.Parameters.Add("product_uom_qty", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_product_uom_qty.Value = this.ProductUomQty;
                Npgsql.NpgsqlParameter pr_customer_lead = cm.Parameters.Add("customer_lead", NpgsqlTypes.NpgsqlDbType.Double);
                pr_customer_lead.Value = this.CustomerLead;
                Npgsql.NpgsqlParameter pr_product_id = cm.Parameters.Add("product_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_product_id.Value = this.IdProduct;
                Npgsql.NpgsqlParameter pr_create_date = cm.Parameters.Add("create_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                pr_create_date.Value = this.CreateDate;
                Npgsql.NpgsqlParameter pr_write_date = cm.Parameters.Add("write_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                pr_write_date.Value = this.WriteDate;
                Npgsql.NpgsqlParameter pr_product_uom = cm.Parameters.Add("product_uom", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_product_uom.Value = this.IdProductUom;
                this.Id = (int)cm.ExecuteScalar();
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
                ConvertNameToId();
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"UPDATE {0} SET name = @name, price_unit = @price_unit, product_uom_qty = @product_uom_qty, customer_lead = @customer_lead, " +
                        @" product_id = @product_id, create_date = @create_date, write_date = @write_date, product_uom = @product_uom " +
                        @" WHERE (id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_name = cm.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text);
                pr_name.Value = this.Name;
                Npgsql.NpgsqlParameter pr_price_unit = cm.Parameters.Add("price_unit", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_price_unit.Value = this.PriceUnit;
                Npgsql.NpgsqlParameter pr_product_uom_qty = cm.Parameters.Add("product_uom_qty", NpgsqlTypes.NpgsqlDbType.Numeric);
                pr_product_uom_qty.Value = this.ProductUomQty;
                Npgsql.NpgsqlParameter pr_customer_lead = cm.Parameters.Add("customer_lead", NpgsqlTypes.NpgsqlDbType.Double);
                pr_customer_lead.Value = this.CustomerLead;
                Npgsql.NpgsqlParameter pr_product_id = cm.Parameters.Add("product_id", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_product_id.Value = this.IdProduct;
                Npgsql.NpgsqlParameter pr_create_date = cm.Parameters.Add("create_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                pr_create_date.Value = this.CreateDate;
                Npgsql.NpgsqlParameter pr_write_date = cm.Parameters.Add("write_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                pr_write_date.Value = this.WriteDate;
                Npgsql.NpgsqlParameter pr_product_uom = cm.Parameters.Add("product_uom", NpgsqlTypes.NpgsqlDbType.Integer);
                pr_product_uom.Value = this.IdProductUom;
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
                this.Name = "";
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

        #region  ==========  Prepare  ==========

        private void ConvertIdToName()
        {
            if(string.IsNullOrWhiteSpace(this.ProductUom))
            {
                if (this.IdProductUom != 0) this.ProductUom = Uom.GetUomOrDefault(this.IdProductUom, Srv, Base).Name;
            }
        }
        private void ConvertNameToId()
        {
            if (string.IsNullOrWhiteSpace(this.ProductUom))
            {
                this.IdProductUom = Uom.GetUomOrDefault(this.ProductUom, Srv, Base).Id;
            }
        }

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список ZakazkaPolozky
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <returns></returns>
        public static List<ZakazkaPlanning> GetList(Servers Srv, string BaseName, int RelAg = 0)
        {
            List<ZakazkaPlanning> li = new List<ZakazkaPlanning>();
            List<int> li_id = ZakazkaPlanning.GetId(Srv, BaseName, Actions.SyncZakazkaPlanning);
            foreach (int item in li_id)
            {
                ZakazkaPlanning bn1 = new ZakazkaPlanning(item, Srv, BaseName, "");
                if (bn1.Id != 0)
                {
                    if (RelAg != 0) if (bn1.RefAg != RelAg) continue;
                    li.Add(bn1);
                }
            }
            return li;
        }

        /// <summary>
        /// Получить информацию о ZakazkaPolozky или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Ico">Ico компании</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ZakazkaPlanning GetZakazkaPolozky(int id, Servers Srv, string BaseName)
        {
            ZakazkaPlanning com = new ZakazkaPlanning(id, Srv, BaseName, "");
            return com;
        }

        /// <summary>
        /// Получить информацию о ZakazkaPolozky  или если нет то информацию о default  . Если нет - создать
        /// </summary>
        /// <param name="Name">Name</param>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <returns></returns>
        public static ZakazkaPlanning GetZakazkaPolozky(string Name, Servers Srv, string BaseName)
        {
            ZakazkaPlanning com = new ZakazkaPlanning(Name, Srv, BaseName, "");
            return com;
        }

        #endregion
    }
}
