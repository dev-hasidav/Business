using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OdooRpc.CoreCLR.Client;
using OdooRpc.CoreCLR.Client.Models;
using OdooRpc.CoreCLR.Client.Models.Parameters;
using System.Reflection;

namespace OdooConnect
{
	public class OdooCommon
	{
		public static async Task<bool> CheckConnection(OdooConnectionInfo cn)
		{
			var result = true;
			
			var client = new OdooRpcClient(cn);
			try
			{
				await client.Authenticate();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				result = false;
			}
			return result;
		}

		private static async Task<JObject[]> SelectRowFromTable(
			OdooConnectionInfo cn,
			string TableName, 
			List<string> li_pole,
			OdooDomainFilter odoFiltr = null, 
			//string SortValue = null, 
			int Offset = 0, 
			int Limit = 0
			)
		{
			JObject[] Datas = new JObject[0];
			List<Dictionary<string, string>> li_di = new List<Dictionary<string, string>>();
			OdooFieldParameters odoParFieldr = new OdooFieldParameters(li_pole);
			OdooSearchParameters odoSearchParam = new OdooSearchParameters(TableName, odoFiltr);
			OdooPaginationParameters odoPag = new OdooPaginationParameters(Offset, Limit);

			OdooRpcClient client = new OdooRpcClient(cn);
			try
			{
				await client.Authenticate();
				Datas = await client.Get<JObject[]>(odoSearchParam, odoParFieldr, odoPag).ConfigureAwait(false);			
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
			return Datas;
		}
		
		public static async Task<JObject[]> GetZakazky(OdooConnectionInfo cn)
		{	
			List<string> li_pole = new List<string> {
					"id",
					"x_ico_cislo",
					"company_id",
					"user_id",
					"name",
					"date_open",
					"date_last_stage_update",
					"date_closed",
					"stage_id",
					"x_ost1",
					"x_ost2",
					"x_remark",
					//"planned_revenue",
					"partner_id"
			};
			OdooDomainFilter odoFiltr = new OdooDomainFilter();
			var data = await SelectRowFromTable(cn, "crm.lead", li_pole, odoFiltr);
			return data;
		}

		public static async Task<JObject[]> OdooQuery(OdooConnectionInfo cn, 
			string odooSearchParamSerial, 
			string odooParFieldrSerial, 
			string odooPagSerial)
		{
			JObject[] Datas = new JObject[0];
			OdooSearchParameters odoSearchParam = new OdooSearchParameters(odooSearchParamSerial);
			var fields = odooParFieldrSerial.TrimStart('[').TrimEnd(']');
			var split = fields.Split(",", StringSplitOptions.RemoveEmptyEntries);
			OdooFieldParameters odoParFieldr = new OdooFieldParameters(split);
			OdooPaginationParameters odoPag = JsonConvert.DeserializeObject<OdooPaginationParameters>(odooPagSerial);
			try
			{
				OdooRpcClient client = new OdooRpcClient(cn);
				await client.Authenticate();
				Datas = await client.Get<JObject[]>(odoSearchParam, odoParFieldr, odoPag).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return Datas;
		}

		public static async Task<long> OdooCreate(OdooConnectionInfo cn, string NameTable, string serialData)
		{
			long result;
			try
			{
				serialData = serialData.TrimStart('{').TrimEnd('}');
				Dictionary<string, object> di = new Dictionary<string, object>();//JsonConvert.DeserializeObject<Dictionary<string, object>>(serialData);
				var split = serialData.Split(',', StringSplitOptions.RemoveEmptyEntries);
				foreach (var kv in split)
				{
					var splitTag = kv.Split(':');
					if (splitTag[0].Contains("date"))
					{
						di.Add(splitTag[0], splitTag[1]);
					}
					else if (splitTag[0].Contains("_id"))
					{
						if (splitTag[1] != null && splitTag[1] != "null")
						{
							di.Add(splitTag[0], int.Parse(splitTag[1]));
						}						
					}
					else
					{
						di.Add(splitTag[0], splitTag[1]);
					}
					
				}
				OdooRpcClient client = new OdooRpcClient(cn);
				await client.Authenticate();
				
				result = await client.Create(NameTable, di);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				result = -1;
			}
			return await Task.FromResult(result);
		}
	}
}