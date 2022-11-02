using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class AdhistVaz
    {
        public int Id { get; set; }
        public int? RefAd { get; set; }
        public int? RefHist { get; set; }

        public Adhist RefHistNavigation { get; set; }
    }
}
