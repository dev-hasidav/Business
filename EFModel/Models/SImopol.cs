using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SImopol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? Roku { get; set; }
        public double? Odpis { get; set; }
        public int? OrderFld { get; set; }

        public SImo RefAgNavigation { get; set; }
    }
}
