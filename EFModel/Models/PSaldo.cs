using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PSaldo
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelUdAg { get; set; }
        public int? RelAgId { get; set; }
        public int? RefPozas { get; set; }
        public string Ucet { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatSplat { get; set; }
        public int? DoSplat { get; set; }
        public string Cislo { get; set; }
        public string ParSym { get; set; }
        public string ParIco { get; set; }
        public string Stext { get; set; }
        public decimal? KcMd { get; set; }
        public decimal? KcD { get; set; }
        public decimal? KcZust { get; set; }
        public int? RefCm { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public decimal? CmMd { get; set; }
        public decimal? CmD { get; set; }
        public decimal? CmZust { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public string Ico { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
