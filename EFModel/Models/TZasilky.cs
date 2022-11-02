using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TZasilky
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefDopravci { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RelStavEz { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatExport { get; set; }
        public int? RefAd { get; set; }
        public int? RefAddod { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public string Email { get; set; }
        public string Firma2 { get; set; }
        public string Utvar2 { get; set; }
        public string Jmeno2 { get; set; }
        public string Ulice2 { get; set; }
        public string Psc2 { get; set; }
        public string Obec2 { get; set; }
        public int? RefZeme2 { get; set; }
        public string Tel2 { get; set; }
        public string Email2 { get; set; }
        public string Tel { get; set; }
        public string Gsm { get; set; }
        public string Fax { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public int? RelAg { get; set; }
        public int? RelId { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Ttext { get; set; }
    }
}
