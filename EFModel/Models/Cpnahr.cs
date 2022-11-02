using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Cpnahr
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public string Typ { get; set; }
        public string Stat { get; set; }
        public double? Km { get; set; }
        public decimal? KcSazba { get; set; }
        public bool UprSazba { get; set; }
        public int? RefCm { get; set; }
        public decimal? KcNahr { get; set; }
        public bool UprNahr { get; set; }
        public int? OrderFld { get; set; }

        public Cp RefAgNavigation { get; set; }
    }
}
