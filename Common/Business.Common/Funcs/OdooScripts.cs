using Business.Atributes;
using Business.Pohoda.Xml.Packet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [NumClass(37)]
    public class OdooScripts
    {
        #region  ==========  Select row from table  ===========

        /// <summary>
        /// Использует функцию GetAll
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="NameTable"></param>
        /// <param name="odoParFieldr"></param>
        /// <param name="odoPag"></param>
        /// <param name="SortValue"></param>
        /// <returns></returns>
        [NumFunction(1)]
        public Newtonsoft.Json.Linq.JObject[] SelectRowFromTable(Models.Servers Srv,
            string NameTable,
            OdooRpc.CoreCLR.Client.Models.Parameters.OdooFieldParameters odoParFieldr,
            OdooRpc.CoreCLR.Client.Models.Parameters.OdooPaginationParameters odoPag)
        {
            OdooRpc.CoreCLR.Client.OdooRpcClient client = GetConnectOdoo(Srv).Result;
            Newtonsoft.Json.Linq.JObject[] Datas =
                client.GetAll<Newtonsoft.Json.Linq.JObject[]>(NameTable, odoParFieldr, odoPag).Result;
            return Datas;
        }

        /// <summary>
        /// Использует функцию  Search
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="Table"></param>
        /// <param name="li_pole"></param>
        /// <param name="odoFiltr"></param>
        /// <param name="SortValue"></param>
        /// <param name="Offset"></param>
        /// <param name="Limit"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public List<Dictionary<string, string>> SelectRowFromTable(Models.Servers Srv,
            string Table, List<string> li_pole,
            OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = null, string SortValue = null, int Offset = 0, int Limit = 0
            )
        {
            OdooRpc.CoreCLR.Client.Models.Parameters.OdooFieldParameters odoParFieldr =
                new OdooRpc.CoreCLR.Client.Models.Parameters.OdooFieldParameters(li_pole);
            OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters odoSearchParam =
                new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters(Table, odoFiltr);
            OdooRpc.CoreCLR.Client.Models.Parameters.OdooPaginationParameters odoPag =
                            new OdooRpc.CoreCLR.Client.Models.Parameters.OdooPaginationParameters(Offset, Limit);
            Newtonsoft.Json.Linq.JObject[] Datas = new Newtonsoft.Json.Linq.JObject[0];
			List<Dictionary<string, string>> li_di = new List<Dictionary<string, string>>();

			string odooSearchParamSerial = Table;
			string odooParFieldrSerial = JsonConvert.SerializeObject(odoParFieldr);
			string odooPagSerial = JsonConvert.SerializeObject(odoPag);

			var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"S:\DevSoft\Business\ConsOdooNet6Client\bin\Debug\net6.0\ConsOdooNet6Client.exe",
                    Arguments = $"OdooQuery {odooSearchParamSerial} {odooParFieldrSerial} {odooPagSerial}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = @"S:\DevSoft\Business\ConsOdooNet6Client\bin\Debug\net6.0\"
				}
            };
            try
            {
                proc.Start();
                //proc.WaitForExit();
                var jsonString = proc.StandardOutput.ReadToEnd();
				Datas = JsonConvert.DeserializeObject<JObject[]>(jsonString);
				li_di = CollectionJsonToDictionary(Datas, li_pole, SortValue);
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //OdooRpc.CoreCLR.Client.OdooRpcClient client = GetConnectOdoo(Srv).Result;
			//Newtonsoft.Json.Linq.JObject[] Datas = client.Get<Newtonsoft.Json.Linq.JObject[]>(odoSearchParam, odoParFieldr, odoPag).Result;
            //List<Dictionary<string, string>> li_di = CollectionJsonToDictionary(Datas, li_pole, SortValue);

            return li_di;

        }

        #endregion

        #region ==========  Insert  ==========

        /// <summary>
        /// Вставить строку данных в Odoo
        /// </summary>
        /// <param name="infSer">Сервер для операции</param>
        /// <param name="NameTable">Имя таблицы в формате xxx.xxxxxxx </param>
        /// <param name="di">Словарь поле-данные для вставки</param>
        /// <returns></returns>
        [NumFunction(3)]
        public long InsertRow(Models.Servers infSer, string NameTable, Dictionary<string, object> di)
        {
			long l1 = -1;
			string serializedData = JsonConvert.SerializeObject(di);
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"S:\DevSoft\Business\ConsOdooNet6Client\bin\Debug\net6.0\ConsOdooNet6Client.exe",
                    Arguments = $"OdooCreate {NameTable} {serializedData}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = @"S:\DevSoft\Business\ConsOdooNet6Client\bin\Debug\net6.0\"
                }
            };
            try
            {
                proc.Start();
                var result = proc.StandardOutput.ReadToEnd();
                l1 = long.Parse(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //OdooRpc.CoreCLR.Client.OdooRpcClient client = GetConnectOdoo(infSer).Result;
            //l1 = (int)client.Create<Dictionary<string, object>>(NameTable, di).Result;
            return l1;
        }
        [NumFunction(4)]
        public long InsertRowPacket(OdooRpc.CoreCLR.Client.OdooRpcClient client, string NameTable, Dictionary<string, object> di)
        {
            long l1 = -1;
			// l1 = (int)client.Create<Dictionary<string, object>>(NameTable, di).Result;
            string serializedData = JsonConvert.SerializeObject(di);
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = @"S:\DevSoft\Business\ConsOdooNet6Client\bin\Debug\net6.0\ConsOdooNet6Client.exe",
					Arguments = $"OdooCreate {NameTable} {serializedData}",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					WorkingDirectory = @"S:\DevSoft\Business\ConsOdooNet6Client\bin\Debug\net6.0\"
				}
			};
			try
			{
				proc.Start();
				//proc.WaitForExit();
				var result = proc.StandardOutput.ReadToEnd();
				l1 = long.Parse(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return l1;
        }
        public object InsertRowPacket(OdooRpc.CoreCLR.Client.OdooRpcClient client, string NameTable, List<Dictionary<string, object>> di)
        {
            System.Threading.Tasks.Task ts = null;
            Dictionary<string, Dictionary<string, object>> di_t = new Dictionary<string, Dictionary<string, object>>();
            try
            {
                ts = client.Create<List<Dictionary<string, object>>>(NameTable, di);
                ts.Wait();
            }
            catch (OdooRpc.CoreCLR.Client.Models.RpcCallException e1)
            {
            }
            catch (Exception e2)
            {
            }
            return ts;
        }
        #endregion

        #region ==========  Update  ==========

        /// <summary>
        /// Изменение указанной записи
        /// </summary>
        /// <param name="infSer">Сервер для операции</param>
        /// <param name="NameTable">Имя таблицы в формате xxx.xxxxxxx </param>
        /// <param name="Id">Id изменяемой записи</param>
        /// <param name="di">Словарь поле-данные для вставки</param>
        [NumFunction(5)]
        public void UpdateRow(Models.Servers infSer, string NameTable, int Id, Dictionary<string, object> di)
        {
            OdooRpc.CoreCLR.Client.OdooRpcClient client = GetConnectOdoo(infSer).Result;
            System.Threading.Tasks.Task ts = client.Update<Dictionary<string, object>>(NameTable, Id, di);
            ts.Wait();
        }
        [NumFunction(6)]
        public void UpdateRowPacket(OdooRpc.CoreCLR.Client.OdooRpcClient client, string NameTable, int Id, Dictionary<string, object> di)
        {
            System.Threading.Tasks.Task ts = client.Update<Dictionary<string, object>>(NameTable, Id, di);
            ts.Wait();
        }
        [NumFunction(6)]
        public void UpdateRowPacket(OdooRpc.CoreCLR.Client.OdooRpcClient client, string NameTable, List<long> li_id, List<Dictionary<string, object>> li_value)
        {
            OdooRpc.CoreCLR.Client.Models.Parameters.OdooUpdateParameters<List<Dictionary<string, object>>> pr =
                new OdooRpc.CoreCLR.Client.Models.Parameters.OdooUpdateParameters<List<Dictionary<string, object>>>(NameTable, li_id, li_value);
            System.Threading.Tasks.Task ts = client.Update<List<Dictionary<string, object>>>(pr);
            ts.Wait();
        }

        #endregion

        #region ==========  Delect  ==========

        /// <summary>
        /// Удаление строки из таблице
        /// </summary>
        /// <param name="infSer">Сервер для операции</param>
        /// <param name="NameTable">Имя таблицы в формате xxx.xxxxxxx </param>
        /// <param name="Id">Id удаляемой записи</param>
        [NumFunction(7)]
        public void DeleteRow(Models.Servers Srv, string NameTable, int Id)
        {
            OdooRpc.CoreCLR.Client.OdooRpcClient client = GetConnectOdoo(Srv).Result;
            System.Threading.Tasks.Task ts = client.Delete(NameTable, Id);
            ts.Wait();
        }
        [NumFunction(8)]
        public void DeleteRowPacket(OdooRpc.CoreCLR.Client.OdooRpcClient client, string NameTable, int Id, Dictionary<string, object> di)
        {
            System.Threading.Tasks.Task ts = client.Delete(NameTable, Id);
            ts.Wait();
        }

        #endregion

        #region  ==========  Дополнительные фукции  ==========

        public OdooRpc.CoreCLR.Client.OdooRpcClient OpenConnectOdoo(Models.Servers infSer)
        {
            OdooRpc.CoreCLR.Client.OdooRpcClient client = GetConnectOdoo(infSer).Result;
            return client;
        }
        /// <summary>
        /// Открыть и получить соединение с Odoo
        /// </summary>
        /// <param name="infSer"></param>
        /// <returns></returns>
        [NumFunction(9)]
        public async System.Threading.Tasks.Task<OdooRpc.CoreCLR.Client.OdooRpcClient> GetConnectOdoo(Models.Servers Srv)
        {
            OdooRpc.CoreCLR.Client.Models.OdooConnectionInfo cn;
            OdooRpc.CoreCLR.Client.OdooRpcClient client;
            try
            {
                cn = new OdooRpc.CoreCLR.Client.Models.OdooConnectionInfo
                {
                    Host = Srv.OdooHostIp,
                    Port = Srv.OdooPort,
                    IsSSL = false,
                    Database = Srv.OdooBase,
                    Username = Srv.OdooUser,
                    Password = Srv.OdooPassword
                };
                client = new OdooRpc.CoreCLR.Client.OdooRpcClient(cn);
                try
                {
                    await client.Authenticate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (System.Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally {
                Console.WriteLine();
            }
            return client;
        }

        /// <summary>
        /// Преобразование Json в Dictionary
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="SortValue">Поле сортировки (NULL нет сортировки)</param>
        /// <returns></returns>
        [NumFunction(10)]
        private List<Dictionary<string, string>> CollectionJsonToDictionary(Newtonsoft.Json.Linq.JObject[] Value,
            List<string> Fieldrs, string SortValue = null)
        {
            List<Dictionary<string, string>> li_dic = new List<Dictionary<string, string>>();

            foreach (Newtonsoft.Json.Linq.JObject item in Value)
            {
                Dictionary<string, string> li_dic1 = JsonToDictionary(item, Fieldrs);
                li_dic.Add(li_dic1);
            }
            li_dic = Sort(li_dic, SortValue);
            return li_dic;
        }

        /// <summary>
        /// Преобразование Json в Dictionary
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        [NumFunction(11)]
        private Dictionary<string, string> JsonToDictionary(Newtonsoft.Json.Linq.JObject Value, List<string> Fieldrs)
        {
            Dictionary<string, string> li_dic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item in Value)
            {
                string s_Key = item.Key;
                string s_Val = "";
                List<string> li_dic1 = new List<string>();
                if (!(item.Value is Newtonsoft.Json.Linq.JValue val))
                {
                    Newtonsoft.Json.Linq.JArray val1 = item.Value as Newtonsoft.Json.Linq.JArray;
                    foreach (Newtonsoft.Json.Linq.JValue item1 in val1)
                    {
                        li_dic1.Add(item1.Value.ToString());
                    }
                    if (li_dic1.Count == 0)
                    {
                        s_Val = "";
                    }
                    else
                    {
                        if (li_dic1.Count == 1)
                        {
                            s_Val = string.Format("{0}", li_dic1[0]);
                        }
                        else if (li_dic1.Count == 2)
                        {
                            s_Val = string.Format("{0} ->( {1} )", li_dic1[0], li_dic1[1].Trim());
                        }
                        else
                        {
                            foreach (string item2 in li_dic1)
                            {
                                if (string.IsNullOrWhiteSpace(s_Val)) s_Val = item2;
                                else s_Val += ";" + item2;
                            }
                        }
                    }
                }
                else
                {
                    s_Val = val.Value.ToString();
                }
                li_dic.Add(s_Key, s_Val);
            }
            return li_dic;
        }

        /// <summary>
        /// Сортировка
        /// </summary>
        /// <param name="li_dic"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        [NumFunction(12)]
        private List<Dictionary<string, string>> Sort(List<Dictionary<string, string>> li_dic, string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                return li_dic;
            }

            if (li_dic.Count == 0)
            {
                return li_dic;
            }
            else if (li_dic.Count == 1)
            {
                return li_dic;
            }

            string s_Key2;
            if (!li_dic[0].TryGetValue(Value, out string s_Key1))
            {
                return li_dic;
            }

            if (int.TryParse(s_Key1, out int n_Key1))
            {
                bool b1 = false;
                do
                {
                    b1 = false;
                    for (int n1 = 0; n1 < li_dic.Count - 1; n1++)
                    {
                        li_dic[n1].TryGetValue(Value, out s_Key1);
                        li_dic[n1 + 1].TryGetValue(Value, out s_Key2);
                        int.TryParse(s_Key1, out n_Key1);
                        int.TryParse(s_Key2, out int n_Key2);
                        if (n_Key1 <= n_Key2)
                        {
                            continue;
                        }

                        Dictionary<string, string> di_t = li_dic[n1];
                        li_dic[n1] = li_dic[n1 + 1];
                        li_dic[n1 + 1] = di_t;
                        b1 = true;
                    }
                } while (b1);
            }
            else
            {
                bool b1 = false;
                do
                {
                    b1 = false;
                    for (int n1 = 0; n1 < li_dic.Count - 1; n1++)
                    {
                        li_dic[n1].TryGetValue(Value, out s_Key1);
                        li_dic[n1 + 1].TryGetValue(Value, out s_Key2);

                        if (s_Key1.CompareTo(s_Key2) <= 0)
                        {
                            continue;
                        }

                        Dictionary<string, string> di_t = li_dic[n1];
                        li_dic[n1] = li_dic[n1 + 1];
                        li_dic[n1 + 1] = di_t;
                        b1 = true;
                    }
                } while (b1);
            }
            return li_dic;
        }

        #endregion

        #region  ==========  PostgreSql  ==========

        [NumFunction(13)]
        public static string GetConnect(Models.Servers Srv)
        {
            Npgsql.NpgsqlConnectionStringBuilder cb = new Npgsql.NpgsqlConnectionStringBuilder();
            if (Srv.Type == TypeServers.Odoo)
            {
                if (!string.IsNullOrWhiteSpace(Srv.OdooSqlBase)) cb.Database = Srv.OdooSqlBase;
                cb.Host = Srv.OdooSqlHostIp;
                cb.IntegratedSecurity = false;
                cb.Password = Srv.OdooSqlPassword;
                cb.Port = Srv.OdooSqlPort;
                cb.Username = Srv.OdooSqlUser;
                //cb.UseSslStream = true;
            }
            else if (Srv.Type == TypeServers.PostgreSQL)
            {
                if (!string.IsNullOrWhiteSpace(Srv.PostgreBase)) cb.Database = Srv.PostgreBase;
                cb.Host = Srv.PostgreHostIp;
                cb.IntegratedSecurity = Srv.PostgreIntegratedSecurity;
                cb.Password = Srv.PostgrePassword;
                cb.Port = Srv.PostgrePort;
                cb.Username = Srv.PostgreUser;
                //cb.UseSslStream = Srv.PostgreUseSslStream;
            }
            return cb.ConnectionString;
        }

        #endregion

        #region  ==========  Добавление полей в таблицы  ==========

        /// <summary>
        /// Добавление полей в таблицы ODOO
        /// </summary>
        /// <param name="Srv">Сервер</param>
        /// <param name="NameTable">Имя таблицы</param>
        /// <param name="li_NamePoles">Поля для добавления. Name - имя поля, Name1 - тип данных</param>
        [NumFunction(14)]
        public void CheckOrAddColumnsPostgreSql(Models.Servers Srv, string NameTable, List<List12> li_NamePoles)
        {
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm_sx = new Npgsql.NpgsqlCommand() { Connection = cn };
                cm_sx.CommandText = string.Format(@"SELECT * FROM {0}", NameTable);
                Npgsql.NpgsqlDataAdapter da = new Npgsql.NpgsqlDataAdapter();
                da.SelectCommand = cm_sx;
                System.Data.DataTable dt = new System.Data.DataTable();
                da.FillSchema(dt, System.Data.SchemaType.Mapped);
                string s_par = @"ALTER TABLE {0} ADD COLUMN {1} {2};";
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand() { Connection = cn };
                int n_rez = 0;
                foreach (List12 item in li_NamePoles)
                {
                    bool b1 = true;
                    foreach (System.Data.DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.ToLower().CompareTo(item.Name.ToLower()) != 0) continue;
                        b1 = false;
                        break;
                    }
                    if (b1)
                    {
                        cm.CommandText = string.Format(s_par, NameTable, item.Name, item.Name1);
                        n_rez = cm.ExecuteNonQuery();
                        FileEventLog.WriteOk(this, string.Format("Field '{1}' added to table '{0}'", NameTable, item.Name), 
                            System.Reflection.MethodInfo.GetCurrentMethod());
                    }
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

        [NumFunction(15)]
        public void AddColumnsOdoo(Models.Servers Srv, string NameTable, string NamePoles, string TypePole, bool Readonly = false, string Related = null, bool IsState = false)
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                //  находим id модели
                List<string> li_pole = new List<string>
                {
                    "id"
                };
                string s_TableModel = "ir.model";
                string s_TableModelFields = "ir.model.fields";
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                odoFiltr.Filter("model", "=", NameTable);
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, s_TableModel, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    int id_Model = int.Parse(Datas[0]["id"]);
                    //  создаём
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", NamePoles },
                            { "model", NameTable },
                            { "model_id", id_Model },
                            { "field_description", NamePoles },
                            { "ttype", TypePole },
                            { "readonly", Readonly }
                        };
                    if (!string.IsNullOrWhiteSpace(Related)) di.Add("related", Related);
                    if (IsState) di.Add("state", "base");
                    else di.Add("state", "manual");
                    odScr.InsertRow(Srv, s_TableModelFields, di);
                }
                else
                {
                    FileEventLog.WriteErr(this, new Exception(string.Format("Model: '{0}' not found", NameTable)), System.Reflection.MethodInfo.GetCurrentMethod());
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { }

            return;
        }

        [NumFunction(31)]
        public void AddColumnsOdooRel(Models.Servers Srv, string NameTable, string NamePoles, string TypePole, string Related, bool Readonly = false, bool IsState = false)
        {
            try
            {
                OdooScripts odScr = new OdooScripts();
                //  находим id модели
                List<string> li_pole = new List<string>
                {
                    "id"
                };
                string s_TableModel = "ir.model";
                string s_TableModelFields = "ir.model.fields";
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                odoFiltr.Filter("model", "=", NameTable);
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, s_TableModel, li_pole, odoFiltr);
                if (Datas.Count != 0)
                {
                    int id_Model = int.Parse(Datas[0]["id"]);
                    //  создаём
                    Dictionary<string, object> di = new Dictionary<string, object>
                        {
                            { "name", NamePoles },
                            { "model", NameTable },
                            { "model_id", id_Model },
                            { "field_description", NamePoles },
                            { "ttype", TypePole },
                            { "readonly", Readonly },
                            { "relation", Related }
                        };
                    if (IsState) di.Add("state", "base");
                    else di.Add("state", "manual");
                    odScr.InsertRow(Srv, s_TableModelFields, di);
                }
                else
                {
                    FileEventLog.WriteErr(this, new Exception(string.Format("Model: '{0}' not found", NameTable)), System.Reflection.MethodInfo.GetCurrentMethod());
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { }

            return;
        }

        [NumFunction(16)]
        public bool CheckColumnsOdoo(Models.Servers Srv, string NameTable, string NamePoles)
        {
            bool b1 = false;
            try
            {
                if (Srv.Type == TypeServers.PostgreSQL) return true;
                OdooScripts odScr = new OdooScripts();
                List<string> li_pole = new List<string>
                {
                    "id"
                };
                string s_Table = "ir.model.fields";
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                odoFiltr.Filter("name", "=", NamePoles);
                odoFiltr.Filter("model", "=", NameTable);
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, s_Table, li_pole, odoFiltr);
                b1 = Datas.Count == 1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { }
            return b1;
        }

        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="NameModel">например: Account Journal Report </param>
        /// <param name="Model">например: report.account.report_journal</param>
        /// <param name="IsState">Frue: base или False: manual</param>
        [NumFunction(31)]
        public void AddModelsOdoo(Models.Servers Srv, string NameModel, ActionProperty act, bool IsState)
        {
            if (Srv.Type != TypeServers.Odoo) return;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                //string s_com = string.Format("CREATE TABLE {0} ( " +
                //    "id SERIAL,     " +
                //    "ids character varying, " +
                //    "name character varying );", act.TablePostgreSql);
                //cn = new Npgsql.NpgsqlConnection(GetConnect(Srv));
                //cn.Open();
                ////  Проверка и создание таблицы
                //Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand(s_com, cn);
                //cm.ExecuteNonQuery();
                OdooScripts odScr = new OdooScripts();
                Dictionary<string, object> di = new Dictionary<string, object>
                {
                    { "name", NameModel },
                    { "transient", false },
                    { "model", act.TableOdoo }
                };
                if (IsState) di.Add("state", "base");
                else di.Add("state", "manual");
                int n1 = (int)odScr.InsertRow(Srv, "ir.model", di);
                di = new Dictionary<string, object>
                {
                    { "model_id", n1 },
                    { "name", "Cinnost all" },
                    { "display_name", "Cinnost all" },
                    { "active", true },
                    { "group_id", null },
                    { "perm_create", true },
                    { "perm_read", true },
                    { "perm_unlink", true },
                    { "perm_write", true }
                };
                odScr.InsertRow(Srv, "ir.model.access", di);
                di = new Dictionary<string, object>
                {
                    { "model_id", n1 },
                    { "name", "Cinnost all" },
                    { "display_name", "Cinnost Access Rights" },
                    { "active", true },
                    { "group_id", 2 },
                    { "perm_create", true },
                    { "perm_read", true },
                    { "perm_unlink", true },
                    { "perm_write", true }
                };
                odScr.InsertRow(Srv, "ir.model.access", di);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }

            return;
        }

        /// <summary>
        /// Проверка наличия модели в базе
        /// </summary>
        /// <param name="Srv"></param>
        /// <param name="NameModel">например res.model</param>
        /// <returns></returns>
        [NumFunction(30)]
        public bool CheckModelsOdoo(Models.Servers Srv, string NameModel)
        {
            bool b1 = false;
            try
            {
                if (Srv.Type == TypeServers.PostgreSQL) return true;
                if (string.IsNullOrWhiteSpace(NameModel)) return true;
                OdooScripts odScr = new OdooScripts();
                List<string> li_pole = new List<string>
                {
                    "id"
                };
                string s_Table = "ir.model";
                OdooRpc.CoreCLR.Client.Models.OdooDomainFilter odoFiltr = new OdooRpc.CoreCLR.Client.Models.OdooDomainFilter();
                odoFiltr.Filter("model", "=", NameModel);
                List<Dictionary<string, string>> Datas = odScr.SelectRowFromTable(Srv, s_Table, li_pole, odoFiltr);
                b1 = Datas.Count >= 1;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { }
            return b1;
        }

        /// <summary>
        /// Проверка наличия и создания ВСЕХ полей и моделей в ODOO
        /// </summary>
        /// <param name="Srv"></param>
        [NumFunction(29)]
        public void CheckAndCreateModelsColumns(Models.Servers Srv)
        {
            //
            #region  ==========  res_bank
            ActionProperty act = new ActionProperty(Actions.SyncBank);
            string NamePole = "x_idsb";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            #endregion
            //
            #region  ==========  res_partner_bank
            act = new ActionProperty(Actions.SyncPartnerBank);
            NamePole = "x_idspb";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "bank_id.x_idsb");
            }
            #endregion
            //
            #region  ==========  res_partner
            act = new ActionProperty(Actions.SyncPartner);
            NamePole = "x_dic";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //ileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            NamePole = "x_jmeno";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            #endregion
            //
            #region  ==========  res_country
            act = new ActionProperty(Actions.SyncCountry);
            NamePole = "x_kod";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            NamePole = "x_relzeme";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "integer");
            }
            #endregion
            //
            #region  ==========  res_currency
            act = new ActionProperty(Actions.SyncCurrency);
            NamePole = "x_zeme";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            NamePole = "x_mnozstvi";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TablePostgreSql)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            #endregion
            //
            #region  ==========  res_company
            act = new ActionProperty(Actions.SyncCompany);
            NamePole = "x_ico";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            NamePole = "x_jmeno";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "partner_id.x_jmeno");
            }
            NamePole = "x_comment";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            NamePole = "x_dic";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "partner_id.x_dic");
            }
            NamePole = "mobile";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "partner_id.mobile", true);
            }
            #endregion
            //
            #region  ==========  res_users
            act = new ActionProperty(Actions.SyncUser);
            NamePole = "x_jmeno";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
            }
            #endregion
            //
            #region  ==========  x_ph_cin
            //System.Threading.Thread.Sleep(1000 * 60);
            act = new ActionProperty(Actions.SyncCin);
            if (!CheckModelsOdoo(Srv, act.TableOdoo))
            {
                //FileEventLog.WriteWarting(string.Format("No model '{0}' in the bases ODOO", act.TableOdoo)); 
                AddModelsOdoo(Srv, "Cinnost", act, false);
            }
            NamePole = "x_ids";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
               //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, null, false);
            }
            NamePole = "x_name";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, null, false);
            }
            NamePole = "x_remark";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, null, false);
            }

            #endregion
            //
            #region  ==========  x_ph_str
            act = new ActionProperty(Actions.SyncStr);
            if (!CheckModelsOdoo(Srv, act.TableOdoo))
            {
                //FileEventLog.WriteWarting(string.Format("No model '{0}' in the bases ODOO", act.TableOdoo));
                AddModelsOdoo(Srv, "Stredisko", act, false);
            }
            NamePole = "x_ids";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_name";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_remark";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            #endregion
            //
            #region  ==========  x_ph_formuh
            act = new ActionProperty(Actions.SyncFornUh);
            if (!CheckModelsOdoo(Srv, act.TableOdoo))
            {
                //FileEventLog.WriteWarting(string.Format("No model '{0}' in the bases ODOO", act.TableOdoo));
                AddModelsOdoo(Srv, "Form uhrada", act, false);
            }
            NamePole = "x_ids";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_name";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_remark";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            #endregion
            //
            #region  ==========  x_ph_ppk
            act = new ActionProperty(Actions.SyncPk);
            if (!CheckModelsOdoo(Srv, act.TableOdoo))
            {
                //FileEventLog.WriteWarting(string.Format("No model '{0}' in the bases ODOO", act.TableOdoo));
                AddModelsOdoo(Srv, "P-Pk", act, false);
            }
            NamePole = "x_ids";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_name";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_umd";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_ud";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_name1";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_umd1";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
               // FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_ud1";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
                //FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
                AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_name2";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
				//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
				AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_umd2";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
				//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
				AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_ud2";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
				//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
				AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_name3";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
				//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
				AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_umd3";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
				//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
				AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            NamePole = "x_ud3";
            if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
            {
				//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo));
				AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", true, null, false);
            }
            #endregion
            //
            #region  ==========  crm_lead
            act = new ActionProperty(Actions.SyncZakazka);
            if (CheckModelsOdoo(Srv, act.TableOdoo))
            {
                NamePole = "x_ico_cislo";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
                    FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                    AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
                NamePole = "x_ost1";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
                    FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                    AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
                NamePole = "x_ost2";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
                    FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                    AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
                NamePole = "x_remark";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
                    FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
                    AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
            }
            #endregion
            //
            #region  ==========  sale_order
            act = new ActionProperty(Actions.SyncObjednavky);
            if (CheckModelsOdoo(Srv, act.TableOdoo))
            {
                NamePole = "x_ico_cislo";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
                NamePole = "x_pdoklad";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
                NamePole = "x_cin_id";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdooRel(Srv, act.TableOdoo, NamePole, "many2one", "x_ph.cin");
                }
                NamePole = "x_cin_ids";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "x_cin_id.x_ids");
                }
                NamePole = "x_str_id";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdooRel(Srv, act.TableOdoo, NamePole, "many2one", "x_ph.str");
                }
                NamePole = "x_str_ids";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "x_str_id.x_ids");
                }
                NamePole = "x_formuh_id";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdooRel(Srv, act.TableOdoo, NamePole, "many2one", "x_ph.formuh");
                }
                NamePole = "x_formuh_ids";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char", false, "x_formuh_id.x_ids");
                }
                NamePole = "x_remark";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
                NamePole = "x_remark2";
                if (!CheckColumnsOdoo(Srv, Srv.Type == TypeServers.Odoo ? act.TableOdoo : act.TablePostgreSql, NamePole))
                {
					//FileEventLog.WriteWarting(string.Format("No field '{0}' in the model '{1}'", NamePole, act.TableOdoo)); // No field 'x_ids' in the model
					AddColumnsOdoo(Srv, act.TableOdoo, NamePole, "char");
                }
            }
            #endregion
        }

        #endregion

        #region  ==========  Таблица для триггера  ==========

        [NumFunction(17)]
        public bool CheckingOrCreateOdoo(Models.Servers Srv)
        {
            bool b1 = false;
            Npgsql.NpgsqlConnection cn = null;
            System.IO.FileStream fs = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(GetConnect(Srv));
                cn.Open();
                //  Проверка и создание таблицы
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand() { Connection = cn };
                cm.CommandText = @"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = @Table";
                Npgsql.NpgsqlParameter pr = cm.Parameters.Add("Table", NpgsqlTypes.NpgsqlDbType.Varchar);
                //SqlScripts ss = new SqlScripts();
                pr.Value = scrNameEventTable.ToLower();
                //object o1 = cm.ExecuteScalar();
                long n1 = (long)cm.ExecuteScalar();
                if (n1 == 0)
                {
                    cm.CommandText = scrCreateEventTriggers;
                    cm.Parameters.Clear();
                    cm.ExecuteNonQuery();
                }
                //  Проверка и создание функции в базе PostgreSQL

                //  вычисляем хеш функции тригера
                //  проверяем функции тригера
                if (GetFuncTrigger(cn) == 0)
                {
                    //  функции тригера отсутсвует в базе
                    SetFuncTrigger(cn);
                    FileEventLog.WriteOk(this, string.Format("New trigger Odoo '{0}' installed", _NameFuncOdoo),
                        System.Reflection.MethodInfo.GetCurrentMethod());
                }
                else
                {
                    System.Security.Cryptography.SHA512 sha = System.Security.Cryptography.SHA512.Create();
                    byte[] bb = System.Text.Encoding.Default.GetBytes(_strCreateFuncTrigger);
                    byte[] bb_sha = sha.ComputeHash(bb);
                    string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    s1 = System.IO.Path.GetDirectoryName(s1);
                    System.IO.FileInfo fi_prop = new System.IO.FileInfo(s1 + @"\srvtrg.oml");
                    Models.TrigersProp tt = new Models.TrigersProp();
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Models.TrigersProp));
                    if (fi_prop.Exists)
                    {
                        fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                        tt = (Models.TrigersProp)xs.Deserialize(fs);
                        fs.Close();
                    }

                    //  получаем хеш функции тригера для проверки на изменение
                    bool IsE = true;
                    if (tt.CreateFuncOdoo.Length == bb_sha.Length)
                    {
                        for (int n2 = 0; n2 < bb_sha.Length; n2++)
                        {
                            if (bb_sha[n2] == tt.CreateFuncOdoo[n2]) continue;
                            IsE = false;
                            break;
                        }
                    }
                    else IsE = false;
                    if (!IsE)
                    {
                        //  хеш НЕ равен и производим перезапись функции тригера
                        UpdateFuncTrigger(cn);
                        FileEventLog.WriteOk(this, string.Format("Trigger '{0}' changed", _NameFuncOdoo),
                            System.Reflection.MethodInfo.GetCurrentMethod());
                        //  меняем хеш и перезаписываем
                        tt.CreateFuncOdoo = bb_sha;
                        fs = new System.IO.FileStream(fi_prop.FullName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                        xs.Serialize(fs, tt);
                        fs.Close();
                    }
                }

                #region  ==========  Проверка и создание полей в таблице  ==========
                CheckAndCreateModelsColumns(Srv);
                #endregion

                b1 = true;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); fs?.Close(); }
            return b1;
        }

        /// <summary>
        /// Таблица для Odoo
        /// </summary>
        public string scrNameEventTable
        {
            get
            {
                return string.Format("{0}_{1}", "res", SqlScripts.NameEventTriggersAgent);
            }
        }
        private string scrCreateEventTriggers
        {
            get
            {
                return string.Format(_scrCreateEventTriggers, scrNameEventTable);
            }
        }
        private readonly string _scrCreateEventTriggers = @"
CREATE TABLE {0} (
    Id SERIAL,
    IsTask integer,
    DateCreate timestamp with time zone DEFAULT statement_timestamp(),
    DateTrigger timestamp with time zone DEFAULT statement_timestamp(),
    DateClose timestamp with time zone DEFAULT statement_timestamp(),
    GuidTask character varying,
    AddressMain character varying,
    IdRecord integer,
    ActionTrigger character varying,
    NameTrigger character varying,
    NameTable character varying,
    NameBase character varying,
    NameServer character varying
);
";

        #endregion

        #region  ==========  Function triggers  ==========

        /// <summary>
        /// Получить количество Function trigger в MAIN базе.
        /// </summary>
        [NumFunction(18)]
        public long GetFuncTrigger(Npgsql.NpgsqlConnection cn)
        {
            long rez = 0;
            try
            {
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    CommandText = @"SELECT COUNT(*) FROM information_schema.routines 
                        WHERE routine_name like @Triger",
                    Connection = cn
                };
                Npgsql.NpgsqlParameter pr_Triger = cm.Parameters.Add("Triger", NpgsqlTypes.NpgsqlDbType.Varchar);
                pr_Triger.Value = _NameFuncOdoo;
                rez = (long)cm.ExecuteScalar();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return rez;
        }

        /// <summary>
        /// Установка или перезапись Function trigger
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(19)]
        public void SetFuncTrigger(Npgsql.NpgsqlConnection cn)
        {
            try
            {
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = CreateFuncTriggers();
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Установка или перезапись Function trigger
        /// </summary>
        /// <param name="infSer"></param>
        /// <param name="NameTable"></param>
        [NumFunction(20)]
        public void UpdateFuncTrigger(Npgsql.NpgsqlConnection cn)
        {
            try
            {
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = CreateFuncTriggers();
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Удаление Function trigger.
        /// </summary>
        /// <param name="infSer"></param>
        [NumFunction(21)]
        public void DeleteFuncTrigger(Npgsql.NpgsqlConnection cn)
        {
            try
            {
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = string.Format("DROP TRIGGER {0}", _NameFuncOdoo);
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return;
        }

        /// <summary>
        /// Функция для Odoo
        /// </summary>
        private string CreateFuncTriggers()
        {
            ;
            string rez = string.Format(_strCreateFuncTrigger,
                scrNameEventTable, _NameFuncOdoo, "CREATE"
                );
            return rez;
        }
        private readonly string _NameFuncOdoo = "func_trigger_sync";
        private readonly string _strCreateFuncTrigger = @"
{2} OR REPLACE FUNCTION {1}() RETURNS TRIGGER as $$
DECLARE
    id integer;
    trg varchar(100);
    tbl varchar(100);
    srv varchar(254);
    act varchar(30);
    guid varchar(100);
BEGIN
    IF    TG_OP = 'INSERT' THEN
        act = 'I';
        id = NEW.id;
    ELSIF TG_OP = 'UPDATE' THEN
        act = 'U';
        id = NEW.id;
    ELSIF TG_OP = 'DELETE' THEN
        act = 'D';
        id = OLD.id;
    END IF;
    guid  =  TG_ARGV[0];
    trg = TG_NAME;
    tbl = TG_TABLE_NAME;
    srv = current_database();
    INSERT INTO {0} (IsTask, GuidTask , IdRecord, ActionTrigger, NameTrigger, NameTable, NameBase) 
        values (1, guid , id, act , trg , tbl , srv );
    RETURN NULL;
END;
$$ LANGUAGE plpgsql;
";

        #endregion

        #region  ==========  DML Triggers  ==========
        [NumFunction(22)]
        public Dictionary<string, Models.ListTrigger> GetTriggerDML(Models.Servers Srv)
        {
            Dictionary<string, Models.ListTrigger> di = new Dictionary<string, Models.ListTrigger>();
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(GetConnect(Srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = @"SELECT * FROM information_schema.triggers WHERE trigger_name like 'trg_%'";
                Npgsql.NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    string s1 = dr["trigger_name"].ToString();
                    int n1 = s1.IndexOf("_", 0);
                    s1 = s1.Insert(n1, "_" + Srv.PostgreBase);
                    if (!di.ContainsKey(s1))
                    {
                        Models.ListTrigger item = new Models.ListTrigger();
                        item.NameTrigger = dr["trigger_name"].ToString();
                        item.NameBase = dr["trigger_catalog"].ToString();
                        item.NameTable = dr["event_object_table"].ToString();
                        item.IsRemote = false;
                        di.Add(s1, item);
                    }
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return di;
        }

        /// <summary>
        /// Создать триггер
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(23)]
        public int CreateTriggerDML(Models.Task tsk)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(GetConnect(tsk.ServerSource));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                string Name = string.Format("trg_{0}_{1}", tsk.Param.ActionProp.TablePostgreSql, tsk.Param.IdGuid);
                cm.CommandText = CreateTriggers(Name, tsk.Param.ActionProp.TablePostgreSql, tsk.Param.IdGuid);
                n1 = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return n1;
        }

        /// <summary>
        /// Обновление триггета на Odoo
        /// </summary>
        /// <param name="tsk"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(24)]
        public int UpdateTrigger(Models.Task tsk, string Base, string NameTrigger)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(SqlScripts.GetConnectSQL(tsk.ServerSource, Base));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                {
                    Connection = cn
                };
                cm.CommandText = AlterTriggers(NameTrigger, tsk.Param.ActionProp.TableOdoo, tsk.Param.IdGuid);
                n1 = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return n1;
        }

        /// <summary>
        /// Удалить триггер
        /// </summary>
        /// <param name="srv"></param>
        /// <param name="Base"></param>
        /// <param name="NameTrigger"></param>
        /// <returns></returns>
        [NumFunction(25)]
        public int DeleteTriggerDML(Models.Servers srv, string NameTable, string NameTrigger)
        {
            int n1 = 0;
            Npgsql.NpgsqlConnection cn = null;
            try
            {
                cn = new Npgsql.NpgsqlConnection(GetConnect(srv));
                cn.Open();
                Npgsql.NpgsqlCommand cm = new Npgsql.NpgsqlCommand
                { 
                    Connection = cn
                };
                cm.CommandText = string.Format("DROP TRIGGER {0} on {1}", NameTrigger, NameTable);
                n1 = cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally
            {
                cn?.Close();
            }
            return n1;
        }

        /// <summary>
        /// Триггер для таблиц Odoo
        /// </summary>
        /// <param name="NameTriger"></param>
        /// <param name="NameTable"></param>
        /// <param name="GuidTask"></param>
        /// <returns></returns>
        [NumFunction(26)]
        private string CreateTriggers(string NameTriger, string NameTable, string GuidTask)
        {
            string rez = string.Format(_strCreateTrigger,
                NameTriger,
                NameTable,
                GuidTask,
                _NameFuncOdoo,
                "CREATE"
                );
            return rez;
        }
        [NumFunction(27)]
        private string AlterTriggers(string NameTriger, string NameTable, string GuidTask)
        {
            string rez = string.Format(_strCreateTrigger,
                NameTriger,
                NameTable,
                GuidTask,
                _NameFuncOdoo,
               "ALTER"
                );
            return rez;
        }
        //  0 - имя триггера
        //  1 - имя таблицы в которую вставляется данный тригер
        //  2 - GUID задачи
        //  3 - Имя функции триггера
        //  4 - CREATE или ALTER
        //  5 - 
        private static readonly string _strCreateTrigger = @"
{4} TRIGGER {0} 
AFTER INSERT OR UPDATE OR DELETE 
ON {1}
FOR EACH ROW 
EXECUTE PROCEDURE {3}('{2}');
";
        /// <summary>
        /// Хеш триггера DML
        /// </summary>
        /// <returns></returns>
        [NumFunction(28)]
        public static byte[] GetHashTriggerOdoo()
        {
            System.Security.Cryptography.SHA512 sha = System.Security.Cryptography.SHA512.Create();
            byte[] bb_sha = System.Text.Encoding.Default.GetBytes(_strCreateTrigger);
            bb_sha = sha.ComputeHash(bb_sha);
            return bb_sha;
        }
        #endregion

    }
}
