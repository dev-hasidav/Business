using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Smlouvy
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefSmlouvy { get; set; }
        public bool Sel { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RefZeme { get; set; }
        public DateTime? DatPlatOd { get; set; }
        public DateTime? DatPlatDo { get; set; }
        public int? RelTpSml { get; set; }
        public int? RelZaObd { get; set; }
        public int? RelKateg { get; set; }
        public string Stext { get; set; }
        public decimal? Kc { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCislo { get; set; }
    }
}
