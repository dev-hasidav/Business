using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzCnPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkCeny { get; set; }
        public decimal? ProdejC { get; set; }
        public int? RelTpFix { get; set; }
        public double? Marze { get; set; }
        public double? Rabat { get; set; }
        public double? Sleva { get; set; }

        public SkzPol RefAgNavigation { get; set; }
    }
}
