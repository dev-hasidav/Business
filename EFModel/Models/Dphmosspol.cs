using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphmosspol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Dodavatel { get; set; }
        public string Zeme { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public decimal? VatBase { get; set; }
        public decimal? Vat { get; set; }
        public int? RelMosstyp { get; set; }

        public Dphmoss RefAgNavigation { get; set; }
    }
}
