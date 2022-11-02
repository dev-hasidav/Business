using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TCpvydaje
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public int? RelTpVyd { get; set; }
        public string Popis { get; set; }
        public string Misto { get; set; }
        public int? RefCm { get; set; }
        public double? Mnozstvi { get; set; }
        public decimal? KcJedn { get; set; }
        public bool Sdph { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDph { get; set; }
        public decimal? KcCena { get; set; }
        public int? RelPlatb { get; set; }
        public int? OrderFld { get; set; }
        public string Ttext { get; set; }
    }
}
