using EFModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EFModel
{
	public static class Base
	{
		public static int SanityTest(string connectionString)
		{	
			var DbContext = new StwPh_07333803_2022Context(connectionString);
			var facturaTotal = DbContext.Fa.Count();
			return facturaTotal;
		}

		public static async Task<Fa[]> GetListFactura(string connectionString)
		{
			var result = new Fa[0];
			try
			{	
				using (var ctx = new StwPh_07333803_2022Context(connectionString))
				{
					result = ctx.Fa.ToArray();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return await Task.FromResult(result); 
		}
	}
}
