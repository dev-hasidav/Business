using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzObj
    {
        public int Id { get; set; }
        public int? RefSkz { get; set; }
        public int? RelSkTyp { get; set; }
        public int? RelTp { get; set; }
        public int? RefStruct { get; set; }
        public int? RelSzDph { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Kod { get; set; }
        public string Nazev { get; set; }
        public string ObjKod { get; set; }
        public string ObjNazev { get; set; }
        public string Stext { get; set; }
        public decimal? NakupC { get; set; }
        public int? RefCm { get; set; }
        public double? CmKurs { get; set; }
        public bool Sdph { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public double? Rezer { get; set; }
        public double? Reklam { get; set; }
        public double? ObjedP { get; set; }
        public double? ObjedV { get; set; }
        public double? Servis { get; set; }
        public double? StavZ { get; set; }
        public int? RefSkzNc { get; set; }
        public string User { get; set; }
    }
}
