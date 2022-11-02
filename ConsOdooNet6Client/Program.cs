using ConsOdooNet6Client.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OdooConnect;
using OdooRpc.CoreCLR.Client.Models;

namespace ConsOdooNet6Client
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Usage: ConsOdooNet6Client -operation\n [CheckConnection|Get]");
				return;
			}
			var operation = args[0];
			JObject[] data = new JObject[0];
			// get configuration
			IConfiguration config = new ConfigurationBuilder()
									.AddJsonFile("appsettings.json")
									.Build();
			ProgramSettings settings = config.GetRequiredSection("Settings").Get<ProgramSettings>();

			var cn = new OdooConnectionInfo
			{
				Host = settings.Host,
				Port = settings.Port,
				IsSSL = settings.IsSSL,
				Database = settings.Database,
				Username = settings.Username,
				Password = settings.Password
			};

			if (operation == "CheckConnection")
			{
				var result = OdooCommon.CheckConnection(cn).ConfigureAwait(false).GetAwaiter().GetResult();
				Console.WriteLine(result);
			}
			if (operation == "Zakazky")
			{
				data = OdooCommon.GetZakazky(cn).ConfigureAwait(false).GetAwaiter().GetResult();
				string json = JsonConvert.SerializeObject(data);
				Console.WriteLine(json);
			}

			if (operation == "OdooQuery")
			{
				data = OdooCommon.OdooQuery(cn, args[1], args[2], args[3]).ConfigureAwait(false).GetAwaiter().GetResult();
				string json = JsonConvert.SerializeObject(data);
				Console.WriteLine(json);
			}

			if (operation == "OdooCreate")
			{
				var inserted = OdooCommon.OdooCreate(cn, args[1], args[2]).ConfigureAwait(false).GetAwaiter().GetResult();
				Console.WriteLine(inserted);
			}
		}
	}
}