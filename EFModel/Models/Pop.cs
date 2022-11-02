using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Pop
    {
        public Pop()
        {
            Poppol = new HashSet<Poppol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RelTpPop { get; set; }
        public int? RefZeme { get; set; }
        public int? ZaokrFv { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public bool Polozky { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public string Stext { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatDo { get; set; }
        public bool HistSzDph { get; set; }
        public string DicregDpheu { get; set; }
        public string Moss { get; set; }
        public string Mossdukaz { get; set; }
        public int? RelZpVypDph { get; set; }
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
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public decimal? Cm0 { get; set; }
        public decimal? CmCelkem { get; set; }
        public decimal? CmZaokr { get; set; }
        public bool Vyrizeno { get; set; }
        public bool TrvalyDok { get; set; }
        public bool Bprenes { get; set; }
        public int? RefAd { get; set; }
        public int? RefAddod { get; set; }
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
        public string CenyIds { get; set; }
        public string Tel { get; set; }
        public string Gsm { get; set; }
        public string Fax { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string PoznPred { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<Poppol> Poppol { get; set; }
    }
}
