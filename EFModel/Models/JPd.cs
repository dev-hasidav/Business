using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class JPd
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public string Cislo { get; set; }
        public int? RelTpPd { get; set; }
        public int? OrderFld { get; set; }
        public int? RelPdAg { get; set; }
        public int? RelAgId { get; set; }
        public int? RefUcet { get; set; }
        public int? RefAnal { get; set; }
        public DateTime? Datum { get; set; }
        public string Stext { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDph { get; set; }
        public decimal? KcCelkem { get; set; }
        public int? RelVlivDph { get; set; }
        public decimal? OrigKc1 { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string Pozn { get; set; }
    }
}
