using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class OverDphHistDat
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }

        public OverDphHist RefAgNavigation { get; set; }
    }
}
