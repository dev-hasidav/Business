using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Impredm
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcZust { get; set; }
        public int? RelZpVyr { get; set; }
        public int? RelTpLik { get; set; }
        public decimal? KcLikv { get; set; }
        public decimal? KcRucne { get; set; }
        public bool Upraveno { get; set; }
        public bool Uzavreno { get; set; }
        public int? OrderFld { get; set; }

        public Im RefAgNavigation { get; set; }
    }
}
