using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkAcnPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public string Kod { get; set; }
        public string Nazev { get; set; }
        public int? RefSklad { get; set; }
        public int? RefStruct { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public bool Sdph { get; set; }
        public decimal? ProdejZpc { get; set; }
        public decimal? ZpckcbDph { get; set; }
        public decimal? ProdejC { get; set; }
        public decimal? PckcbDph { get; set; }
        public int? RelTpFix { get; set; }
        public double? Sleva { get; set; }
        public int? OrderFld { get; set; }

        public SkAcn RefAgNavigation { get; set; }
    }
}
