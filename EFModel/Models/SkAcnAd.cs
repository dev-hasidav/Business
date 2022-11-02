using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkAcnAd
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Ico { get; set; }
        public string Cislo { get; set; }
        public string Smlouva { get; set; }
        public int? OrderFld { get; set; }

        public SkAcn RefAgNavigation { get; set; }
    }
}
