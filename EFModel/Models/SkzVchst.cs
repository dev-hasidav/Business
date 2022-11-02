using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzVchst
    {
        public int Id { get; set; }
        public int? RefVc { get; set; }
        public int? RelSkzpAg { get; set; }
        public int? Rok { get; set; }
        public DateTime? Datum { get; set; }
        public string Cislo { get; set; }
        public int? RelOp { get; set; }
        public double? PohPmj { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public int? Zaruka { get; set; }
        public int? RelZaruka { get; set; }

        public SkzVc RefVcNavigation { get; set; }
    }
}
