using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TPh
    {
        public TPh()
        {
            TPhpol = new HashSet<TPhpol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefZeme { get; set; }
        public int? ZaokrPh { get; set; }
        public int? RelForUh { get; set; }
        public int? RelPk { get; set; }
        public int? RelDruh { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public bool Polozky { get; set; }
        public int? RelTpPh { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public string Stext { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatZauct { get; set; }
        public bool HistSzDph { get; set; }
        public string DicregDpheu { get; set; }
        public int? RelTpCalcDph { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? KcDph1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? KcDph2 { get; set; }
        public decimal? Kc3 { get; set; }
        public decimal? KcDph3 { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcZaokr { get; set; }
        public decimal? KcPrijato { get; set; }
        public decimal? KcVratit { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string CenyIds { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public bool TiskPh { get; set; }
        public int? RelStorn { get; set; }
        public bool TpStorn { get; set; }
        public DateTime? DatStorn { get; set; }
        public int? PackNum { get; set; }
        public int? RefKasa { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public bool TiskFm { get; set; }
        public int? PrintCount { get; set; }
        public bool BezZauct { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public int? RelStavEet { get; set; }
        public bool StornoEet { get; set; }
        public int? RefEetprofil { get; set; }
        public string Ttext { get; set; }

        public ICollection<TPhpol> TPhpol { get; set; }
    }
}
