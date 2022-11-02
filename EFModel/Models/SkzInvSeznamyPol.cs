using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzInvSeznamyPol
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefInvPol { get; set; }
        public int? RefSkz { get; set; }
        public int? RefSkz0 { get; set; }
        public string Nazev { get; set; }
        public string Stext { get; set; }
        public string Pozn { get; set; }
        public string Kod { get; set; }
        public string Vcislo { get; set; }
        public int? SkzVc { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public bool Bprenes { get; set; }
        public int? OrderFld { get; set; }

        public SkzInvSeznamy RefAgNavigation { get; set; }
    }
}
