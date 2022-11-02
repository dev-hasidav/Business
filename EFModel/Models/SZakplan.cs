using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SZakplan
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public int? RelDruhOper { get; set; }
        public string Nazev { get; set; }
        public string Zdroj { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public decimal? Kc { get; set; }
        public string Pozn { get; set; }
        public int? OrderFld { get; set; }

        public SZak RefAgNavigation { get; set; }
    }
}
