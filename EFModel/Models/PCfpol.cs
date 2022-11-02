using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PCfpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefCftyp { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string Defin { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcP { get; set; }
        public bool ProcCf { get; set; }
        public int? OrderFld { get; set; }

        public PCf RefAgNavigation { get; set; }
    }
}
