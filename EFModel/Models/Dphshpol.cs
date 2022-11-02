using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphshpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? UsrOrder { get; set; }
        public bool Storno { get; set; }
        public string Dic { get; set; }
        public string Kod { get; set; }
        public int? Pocet { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? KcDph1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? KcDph2 { get; set; }
        public decimal? Kc3 { get; set; }
        public decimal? KcDph3 { get; set; }
        public decimal? KcCelkem { get; set; }

        public Dphsh RefAgNavigation { get; set; }
    }
}
