using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
	public class Factura : Interfases.BaseModelTable
	{
		public string CompanyIco { get; set; }
		public Factura(Actions act) : base(act)
		{
		}

		public List<Factura> _CollectionFactura = new List<Factura>();

		protected override void CreateOdoo()
		{
			throw new NotImplementedException();
		}

		protected override void CreatePohoda()
		{
			throw new NotImplementedException();
		}

		protected override void CreatePostgre()
		{
			throw new NotImplementedException();
		}

		protected override void CreateSql()
		{
			throw new NotImplementedException();
		}

		protected override void DeleteOdoo()
		{
			throw new NotImplementedException();
		}

		protected override void DeletePohoda()
		{
			throw new NotImplementedException();
		}

		protected override void DeletePostgre()
		{
			throw new NotImplementedException();
		}

		protected override void DeleteSql()
		{
			throw new NotImplementedException();
		}

		protected override void LoadOdoo(int Id, string Ids)
		{
			throw new NotImplementedException();
		}

		protected override void LoadPohoda(int Id, string Ids)
		{
			throw new NotImplementedException();
		}

		protected override void LoadPostgre(int Id, string Ids)
		{
			throw new NotImplementedException();
		}

		protected override void LoadSql(int Id, string Ids)
		{
			if (Id == 0 && String.IsNullOrWhiteSpace(Ids))
			{
				//_CollectionFactura = 
			}
		}

		protected override void UpdateOdoo()
		{
			throw new NotImplementedException();
		}

		protected override void UpdatePohoda()
		{
			throw new NotImplementedException();
		}

		protected override void UpdatePostgre()
		{
			throw new NotImplementedException();
		}

		protected override void UpdateSql()
		{
			throw new NotImplementedException();
		}
	}
}
