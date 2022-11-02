using Business.Atributes;
using Business.Pohoda.Xml.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    [NumClass(65)]
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Ids: {Ids}, Name: {Name}, Coll-PartBank: {CollectionPartnerBank.Count}, IdPartner: {IdPartner}, Type: {Srv.Type}")]
    public class PartnerBank : Interfases.BaseModelTable
    {
        #region  ==========  Constructor  ==========

        private void PartnerBank_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

        public PartnerBank() : base(Actions.SyncPartnerBank) { }
        public PartnerBank(int Id, Models.Servers Server, string BaseData, string IcoBase) : base(Id, Server, BaseData, IcoBase, Actions.SyncPartnerBank)
        {
        }
        /// <summary>
        /// Создать по Ucet
        /// </summary>
        /// <param name="Ucet">Расчётный счёт фирмы (партнёра, компании)</param>
        /// <param name="Server"></param>
        /// <param name="BaseData"></param>
        /// <param name="IcoBase">Ico базы с которой работаем</param>
        public PartnerBank(string Ucet, Models.Servers Server, string BaseData, string IcoBase) : base(Ucet, Server, BaseData, IcoBase, Actions.SyncPartnerBank)
        {
        }
        /// <summary>
        /// Создать по имени компании. Для этого надо
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="BaseData"></param>
        /// <param name="PartnerBankBankName">Имя компании</param>
        /// <param name="Ico"></param>
        public PartnerBank(Models.Servers Server, string BaseData, string IcoBase, string PartnerBankName) : base("", Server, BaseData, IcoBase, Actions.SyncPartnerBank, PartnerBankName)
        {
        }

        #endregion

        #region  ==========  Property  ==========

        public Bank Banky { set; get; }
        public string CurrencyKod { set; get; }
        public int IdPartner { set; get; }
        public int IdCompany { set; get; }

        private List<PartnerBank> _CollectionPartnerBank = new List<PartnerBank>();
        /// <summary>
        /// Коллекция для чтения и записи блока данных. Про клмманде 'SET' устанавливает 'IsRecord = NumberRecord.Many'
        /// </summary>
        public List<PartnerBank> CollectionPartnerBank { get { return _CollectionPartnerBank; } set { _CollectionPartnerBank = value; IsRecord = NumberRecord.Many; } }
        /// <summary>
        /// Указывает программе что использовать - сам класс или коллекцию
        /// </summary>
        public NumberRecord IsRecord { set; get; }
        [NonSerialized]
        public OdooRpc.CoreCLR.Client.OdooRpcClient Client = null;

        #endregion

        #region  ==========  SQL  ==========
        [NumFunction(1)]
        protected override void LoadSql(int Id, string Ico)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                this.IsRecord = NumberRecord.One;
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Srv, Base));
                cn.Open();
                string s_pole = @" a.ID, a.Ucet, a.KodBanky, au.ID AS cID, au.Ucet AS sUcet, au.KodBanky AS sKodBanky ";
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT {2} " +
                        @" FROM {0} AS a LEFT OUTER JOIN {1} AS au ON a.ID = au.RefAg order by a.ID, au.ID ", this.PrAction.TableSql, this.PrAction.TableSqlDop1, s_pole)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT {2} " +
                        @" FROM {0} AS a LEFT OUTER JOIN {1} AS au ON a.ID = au.RefAg " +
                        @" WHERE (a.ID = @ID)", this.PrAction.TableSql, this.PrAction.TableSqlDop1, s_pole);
                    System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("ID", System.Data.SqlDbType.Int);
                    pr_Id.Value = Id;
                }
                else { this.IsRecord = NumberRecord.Many; }
                string s_ucet = null, s_KodBanky = null;
                Dictionary<string, PartnerBank> di = new Dictionary<string, PartnerBank>();
                this.CollectionPartnerBank.Clear();
                Dictionary<string, Bank> di_bank = Bank.GetChashBankIds(this.Srv, this.Base);
                Bank bn;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                int n_Id_1 = 0;
                while (dr.Read())
                {
                    int n_Id_2 = (int)dr["ID"];
                    if (n_Id_1 != n_Id_2)
                    {
                        n_Id_1 = n_Id_2;
                        s_ucet = dr["Ucet"] == DBNull.Value ? "" : dr["Ucet"].ToString().Trim();
                        if (this.IsRecord == NumberRecord.One) if (di.ContainsKey(s_ucet)) continue;
                        if (!string.IsNullOrWhiteSpace(s_ucet))
                        {
                            PartnerBank pr = new PartnerBank();
                            pr.Id = (int)dr["ID"];
                            pr.IdPartner = pr.Id;
                            pr.Ids = s_ucet;
                            s_KodBanky = dr["KodBanky"] == DBNull.Value ? "" : dr["KodBanky"].ToString().Trim();
                            if (!string.IsNullOrWhiteSpace(s_KodBanky))
                            {
                                if(di_bank.TryGetValue(s_KodBanky, out bn)) pr.Banky = bn;
                                else
                                {
                                    pr.Banky = new Bank();
                                    pr.Banky.Ids = s_KodBanky;
                                    pr.Banky.Name = "Bank " + s_KodBanky;
                                    pr.Banky.SWIFT = "";
                                }
                            }
                            if (this.IsRecord == NumberRecord.One) di.Add(s_ucet, pr);
                            else this.CollectionPartnerBank.Add(pr);
                        }
                    }
                    s_ucet = dr["sUcet"] == DBNull.Value ? "" : dr["sUcet"].ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(s_ucet))
                    {
                        if (di.ContainsKey(s_ucet)) continue;
                        PartnerBank pr = new PartnerBank();
                        pr.Id = (int)dr["ID"];
                        pr.IdPartner = pr.Id;
                        pr.Ids = s_ucet;
                        s_KodBanky = dr["sKodBanky"] == DBNull.Value ? "" : dr["sKodBanky"].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(s_KodBanky))
                        {
                            if (di_bank.TryGetValue(s_KodBanky, out bn)) pr.Banky = bn;
                            else
                            {
                                pr.Banky = new Bank();
                                pr.Banky.Ids = s_KodBanky;
                                pr.Banky.Name = "Bank " + s_KodBanky;
                                pr.Banky.SWIFT = "";
                            }
                        }
                        if (this.IsRecord == NumberRecord.One) di.Add(s_ucet, pr);
                        else this.CollectionPartnerBank.Add(pr);
                    }
                }
                dr.Close();
                if (this.IsRecord == NumberRecord.One) this.CollectionPartnerBank.AddRange(di.Values);
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
            throw new Exception(string.Format("Function 'CreateSql' not implemented"));
        }
        [NumFunction(3)]
        protected override void UpdateSql()
        {
            throw new Exception(string.Format("Function 'UpdateSql' not implemented"));
        }
        [NumFunction(4)]
        protected override void DeleteSql()
        {
            throw new Exception(string.Format("Function 'DeleteSql' not implemented"));
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
        protected override void LoadOdoo(int Id, string Ucet)
        {
            bool IsSelect = true;
            try
            {
                this.Id = 0;
                this.IsRecord = NumberRecord.One;
                List<string> li_pole = new List<string>
                {
                    "id",  "acc_number", "acc_holder_name", "bank_id",
                    "x_idspb", "bank_bic", "bank_name", "currency_id", "partner_id"

                };
                OdooScripts odScr = new OdooScripts();
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                if (Id != 0)
                {
                    odoFiltr.Filter("partner_id", "=", Id);
                }
                else if (!string.IsNullOrWhiteSpace(Ucet))
                {
                    odoFiltr.Filter("acc_number", "=", Ucet);
                }
                else
                {
                    this.IsRecord = NumberRecord.Many;
                    IsSelect = false;
                }
                //  загружаем партнёров
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, this.PrAction.TableOdoo, li_pole, odoFiltr);
                this.CollectionPartnerBank.Clear();
                Dictionary<string, int> di = new Dictionary<string, int>();
                foreach (var item in Datas)
                {
                    PartnerBank pr = new PartnerBank();
                    pr.Id = int.Parse(item["id"]);
                    pr.Ids = item["acc_number"] == "False" ? "" : item["acc_number"];
                    pr.Name = item["acc_holder_name"] == "False" ? "Ucet " + pr.Ids : item["acc_holder_name"];
                    string s1 = item["currency_id"] == "False" ? "0" : item["currency_id"];
                    pr.CurrencyKod = "";
                    int IdCurrency = Funcs.ConvertStringToInt.StringOdooToInt(s1);
                    if (IdCurrency != 0)
                    {
                        Currency cur = Currency.GetCurrency(this.Srv, this.Base, IdCurrency);
                        pr.CurrencyKod = cur.Ids;
                    }
                    s1 = item["partner_id"] == "False" ? "0" : item["partner_id"]; 
                    pr.IdPartner = Funcs.ConvertStringToInt.StringOdooToInt(s1);
                    s1 = item["bank_id"] == "False" ? "0" : item["bank_id"];
                    int IdBank = Funcs.ConvertStringToInt.StringOdooToInt(s1);
                    if (IdBank != 0)
                    {
                        pr.Banky = new Bank();
                        pr.Banky.Id = IdBank;
                        pr.Banky.Ids = item["x_idspb"] == "False" ? "" : item["x_idspb"];
                        pr.Banky.SWIFT = item["bank_bic"] == "False" ? "" : item["bank_bic"];
                        pr.Banky.Name = item["bank_name"] == "False" ? "" : item["bank_name"];
                    }
                    this.CollectionPartnerBank.Add(pr);
                }
                di.Clear();
                //  если запрос по фильтру
                if (IsSelect && this.CollectionPartnerBank.Count != 0)
                {
                    this.Id = this.CollectionPartnerBank[0].Id;
                    this.Ids = this.CollectionPartnerBank[0].Ids;
                    this.Name = this.CollectionPartnerBank[0].Name;
                    this.Banky = this.CollectionPartnerBank[0].Banky;
                    this.CurrencyKod = this.CollectionPartnerBank[0].CurrencyKod;
                    this.IdPartner = this.CollectionPartnerBank[0].IdPartner;
                    this.IsRecord = NumberRecord.One;
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
                int IdCurrency = 0;
                if (!string.IsNullOrWhiteSpace(this.CurrencyKod))
                {
                    IdCurrency = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.CurrencyKod).Id;
                }
                Dictionary<string, object> di = new Dictionary<string, object>
                    {
                        { "acc_number", this.Ids },
                        { "acc_holder_name", string.IsNullOrWhiteSpace(this.Name) ? this.Ids : this.Name },
                        { "partner_id", this.IdPartner }

                    };
                if (this.Banky != null)
                {
                    Bank bn = Bank.GetBank(this.Srv, this.Base, this.Banky.Ids);
                    if (bn.Id == 0)
                    {
                        this.Banky.Srv = this.Srv;
                        this.Banky.Base = this.Base;
                        this.Banky.IcoBase = this.IcoBase;
                        this.Banky.Client = this.Client;
                        this.Banky.Create();
                    }
                    else this.Banky.Id = bn.Id;
                    di.Add("bank_id", this.Banky.Id);
                    di.Add("x_idspb", this.Banky.Ids);
                    di.Add("bank_bic", this.Banky.SWIFT);
                    di.Add("bank_name", this.Banky.Name);
                }
                if (IdCurrency != 0) di.Add("currency_id", IdCurrency);
                if (this.IdCompany != 0) di.Add("company_id", this.IdCompany);
                if (this.Client == null) this.Id = (int)odScr.InsertRow(Srv, this.PrAction.TableOdoo, di);
                else this.Id = (int)odScr.InsertRowPacket(Client, this.PrAction.TableOdoo, di);
            }
            catch (Exception e1)
            {
                Exception e2 = new Exception(string.Format("Isd: {0}, Name: {1}, IdPartner: {2}, Banky: {3}", this.Ids, this.Name, this.IdPartner, this.Banky), e1);
                FileEventLog.WriteErr(this, e2, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e2;
            }
        }
        [NumFunction(11)]
        protected override void UpdateOdoo()
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                int IdCurrency = 0;
                if (!string.IsNullOrWhiteSpace(this.CurrencyKod))
                {
                    IdCurrency = Models.Tables.Country.GetCountry(this.Srv, this.Base, this.CurrencyKod).Id;
                }
                Dictionary<string, object> di = new Dictionary<string, object>
                            {
                                { "acc_number", this.Ids },
                                { "acc_holder_name", string.IsNullOrWhiteSpace(this.Name) ? this.Ids : this.Name },
                                { "partner_id", this.IdPartner }

                            };
                if (this.Banky != null)
                {
                    Bank bn = Bank.GetBank(this.Srv, this.Base, this.Banky.Ids);
                    if (bn.Id == 0)
                    {
                        this.Banky.Srv = this.Srv;
                        this.Banky.Base = this.Base;
                        this.Banky.IcoBase = this.IcoBase;
                        this.Banky.Create();
                    }
                    else this.Banky.Id = bn.Id;
                    di.Add("bank_id", this.Banky.Id);
                    di.Add("x_idspb", this.Banky.Ids);
                    di.Add("bank_bic", this.Banky.SWIFT);
                    di.Add("bank_name", this.Banky.Name);
                }
                if (IdCurrency != 0) di.Add("currency_id", IdCurrency);
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
        protected override void LoadPostgre(int Id, string Ucet)
        {
            bool IsSelect = true;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                this.IsRecord = NumberRecord.One;
                cn = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv)); 
                cn.Open();
                string s_pola = @"id, acc_number, acc_holder_name, bank_id, x_idspb, currency_id, partner_id";
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn,
                    CommandText = string.Format(@"SELECT {1} FROM {0} order by partner_id, id ", this.PrAction.TablePostgreSql, s_pola)
                };
                if (Id > 0)
                {
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} where partner_id = @partner_id", this.PrAction.TablePostgreSql, s_pola);
                    Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                    pr_Id.Value = Id;
                }
                else if (!string.IsNullOrWhiteSpace(Ucet))
                {
                    cm.CommandText = string.Format(@"SELECT {1} FROM {0} where acc_number = @acc_number ", this.PrAction.TablePostgreSql, s_pola);
                    Npgsql.NpgsqlParameter pr_Ids = cm.Parameters.Add("acc_number", NpgsqlTypes.NpgsqlDbType.Varchar);
                    pr_Ids.Value = Ucet;
                }
                else { IsSelect = false; this.IsRecord = NumberRecord.Many; }
                this.CollectionPartnerBank.Clear();
                Dictionary<int, Bank> di_bank = Bank.GetChashBankId(this.Srv, this.Base);
                Bank bn;
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    PartnerBank pb = new PartnerBank();
                    pb.Srv = this.Srv;
                    pb.Base = this.Base;
                    pb.IcoBase = this.IcoBase;
                    pb.Id = (int)dr["id"];
                    pb.Ids = dr["acc_number"] == DBNull.Value ? "" : dr["acc_number"].ToString().Trim();
                    pb.Name = dr["acc_holder_name"] == DBNull.Value ? "" : dr["acc_holder_name"].ToString().Trim();
                    int IdCurrency = dr["currency_id"] == DBNull.Value ? 0 : (int)dr["currency_id"];
                    if (IdCurrency != 0)
                    {
                        Currency cur = Currency.GetCurrency(this.Srv, this.Base, IdCurrency);
                        pb.CurrencyKod = cur.Ids;
                    }
                    pb.IdPartner = dr["partner_id"] == DBNull.Value ? 0 : (int)dr["partner_id"];
                    int IdBank = dr["bank_id"] == DBNull.Value ? 0 : (int)dr["bank_id"];
                    if (IdBank != 0)
                    {
                        if (di_bank.TryGetValue(IdBank, out bn)) pb.Banky = bn;
                    }
                    this.CollectionPartnerBank.Add(pb);
                }
                dr.Close();
                if (IsSelect && this.CollectionPartnerBank.Count != 0)
                {
                    this.Id = this.CollectionPartnerBank[0].Id;
                    this.Ids = this.CollectionPartnerBank[0].Ids;
                    this.Name = this.CollectionPartnerBank[0].Name;
                    this.CurrencyKod = this.CollectionPartnerBank[0].CurrencyKod;
                    this.IdPartner = this.CollectionPartnerBank[0].IdPartner;
                    this.Banky = this.CollectionPartnerBank[0].Banky;
                    this.IsRecord = NumberRecord.One;
                }
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
                    CommandText = string.Format(@"INSERT INTO {0} (acc_number, acc_holder_name, partner_id, bank_id, currency_id) " +
                        @" VALUES ( @acc_number, @acc_holder_name, @partner_id, @bank_id, @currency_id); " +
                        " SELECT currval(pg_get_serial_sequence('{0}','id')); ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_acc_number = cm.Parameters.Add("acc_number", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_acc_holder_name = cm.Parameters.Add("acc_holder_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_bank_id = cm.Parameters.Add("bank_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_currency_id = cm.Parameters.Add("currency_id", NpgsqlTypes.NpgsqlDbType.Integer);

                int IdCurrency = 0;
                if (!string.IsNullOrWhiteSpace(this.CurrencyKod))
                {
                    IdCurrency = Tables.Country.GetCountry(this.Srv, this.Base, this.CurrencyKod).Id;
                }
                pr_acc_number.Value = this.Ids;
                pr_acc_holder_name.Value = string.IsNullOrWhiteSpace(this.Name) ? this.Ids : this.Name;
                pr_partner_id.Value = this.IdPartner;
                if (this.Banky != null)
                {
                    Bank bk = Bank.GetBank(this.Srv, this.Base, this.Banky.Ids);
                    if (bk.Id == 0)
                    {
                        this.Banky.Srv = this.Srv;
                        this.Banky.Base = this.Base;
                        this.Banky.IcoBase = this.IcoBase;
                        this.Banky.Create();
                    }
                    else this.Banky.Id = bk.Id;
                    pr_bank_id.Value = this.Banky.Id;
                }
                else pr_bank_id.Value = DBNull.Value;
                if (IdCurrency == 0) pr_currency_id.Value = DBNull.Value;
                else pr_currency_id.Value = IdCurrency;
                object o1 = cm.ExecuteScalar();
                this.Id = (int)((long)o1);
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
                    CommandText = string.Format(@"UPDATE {0} " +
                        @" SET acc_number = @acc_number, acc_holder_name = @acc_holder_name, partner_id = @partner_id, bank_id = @bank_id, currency_id = @currency_id" +
                        @" WHERE(id = @id) ", this.PrAction.TablePostgreSql)
                };
                Npgsql.NpgsqlParameter pr_acc_number = cm.Parameters.Add("acc_number", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_acc_holder_name = cm.Parameters.Add("acc_holder_name", NpgsqlTypes.NpgsqlDbType.Varchar);
                Npgsql.NpgsqlParameter pr_partner_id = cm.Parameters.Add("partner_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_bank_id = cm.Parameters.Add("bank_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_currency_id = cm.Parameters.Add("currency_id", NpgsqlTypes.NpgsqlDbType.Integer);
                Npgsql.NpgsqlParameter pr_Id = cm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);

                int IdCurrency = 0;
                if (!string.IsNullOrWhiteSpace(this.CurrencyKod))
                {
                    IdCurrency = Tables.Country.GetCountry(this.Srv, this.Base, this.CurrencyKod).Id;
                }
                pr_acc_number.Value = this.Ids;
                pr_acc_holder_name.Value = string.IsNullOrWhiteSpace(this.Name) ? this.Ids : this.Name;
                pr_partner_id.Value = this.IdPartner;
                if (this.Banky != null)
                {
                    Bank bk = Bank.GetBank(this.Srv, this.Base, this.Banky.Ids);
                    if (bk.Id == 0)
                    {
                        this.Banky.Srv = this.Srv;
                        this.Banky.Base = this.Base;
                        this.Banky.IcoBase = this.IcoBase;
                        this.Banky.Create();
                    }
                    else
                    {
                        this.Banky.Srv = this.Srv;
                        this.Banky.Base = this.Base;
                        this.Banky.IcoBase = this.IcoBase;
                        this.Banky.Id = bk.Id;
                        this.Banky.Update();
                    }
                    pr_bank_id.Value = this.Banky.Id;
                }
                else pr_bank_id.Value = DBNull.Value;
                if (IdCurrency == 0) pr_currency_id.Value = DBNull.Value;
                else pr_currency_id.Value = IdCurrency;
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

        #region  ==========  Разное  ==========

        #endregion

        #region  ==========  Static  ==========

        /// <summary>
        /// Список банковские реквизиты
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="BaseName">База</param>
        /// <param name="BaseIco"></param>
        /// <returns></returns>
        public static List<PartnerBank> GetList(Servers Srv, string BaseName, string BaseIco)
        {
            PartnerBank bn = new PartnerBank(0, Srv, BaseName, BaseIco);
            return bn.CollectionPartnerBank;
        }
        /// <summary>
        /// Загрузка данных по счетам для партнёра
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <param name="BaseIco"></param>
        /// <param name="IdPattner">ID партнёра в таблицах AD и res_partner</param>
        /// <returns></returns>
        public static List<PartnerBank> GetList(Servers Srv, string BaseName, string BaseIco, int IdPattner)
        {
            PartnerBank bn = new PartnerBank(IdPattner, Srv, BaseName, BaseIco);
            return bn.CollectionPartnerBank;
        }
        /// <summary>
        /// Получение кеша по ID партнёра
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <param name="BaseIco"></param>
        /// <returns></returns>
        public static Dictionary<int, List<PartnerBank>> GetChashBankPartner(Servers Srv, string BaseName, string BaseIco)
        {
            Dictionary<int, List<PartnerBank>> di_id = new Dictionary<int, List<PartnerBank>>();
            Dictionary<string, int> di_out = new Dictionary<string, int>();
            List<PartnerBank> li_pb_id;
            PartnerBank bn = new PartnerBank(0, Srv, BaseName, BaseIco);
            foreach (PartnerBank pb in bn.CollectionPartnerBank)
            {
                if (!di_id.TryGetValue(pb.IdPartner, out li_pb_id))
                {
                    li_pb_id = new List<PartnerBank>();
                    di_id.Add(pb.IdPartner, li_pb_id);
                }
                //if (!di_out.ContainsKey(pb.Ids))
                //{
                li_pb_id.Add(pb);
                //    di_out.Add(pb.Ids, pb.Id);
                //}
            }
            di_out.Clear();
            bn.CollectionPartnerBank.Clear();
            return di_id;
        }
        /// <summary>
        /// Кеш по Ids (Р/C - acc_number), значение - PartnerBank
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="BaseName"></param>
        /// <param name="BaseIco"></param>
        /// <returns></returns>
        public static Dictionary<string, PartnerBank> GetChashBankIds(Servers Srv, string BaseName, string BaseIco)
        {
            Dictionary<string, PartnerBank> di_id = new Dictionary<string, PartnerBank>();
            PartnerBank bn = new PartnerBank(0, Srv, BaseName, BaseIco);
            foreach (PartnerBank pb in bn.CollectionPartnerBank)
            {
                if (!di_id.ContainsKey(pb.Ids)) di_id.Add(pb.Ids, pb);
            }
            return di_id;
        }

        #endregion

    }
}
