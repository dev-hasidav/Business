using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TServ
    {
        public TServ()
        {
            TServPredm = new HashSet<TServPredm>();
            TServStav = new HashSet<TServStav>();
            TServpol = new HashSet<TServpol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RelTpServ { get; set; }
        public int? RelServStav { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RelTpCalcDph { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatVyrDo { get; set; }
        public DateTime? DatUkonceno { get; set; }
        public DateTime? DatVyrizeno { get; set; }
        public int? RefOsoba { get; set; }
        public string Stext { get; set; }
        public int? RefSkz { get; set; }
        public string SkzNazev { get; set; }
        public string SkzStext { get; set; }
        public decimal? PredpCena { get; set; }
        public decimal? Zaloha { get; set; }
        public decimal? PredpCenaCm { get; set; }
        public decimal? ZalohaCm { get; set; }
        public bool HistSzDph { get; set; }
        public string DicregDpheu { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? KcDph1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? KcDph2 { get; set; }
        public decimal? Kc3 { get; set; }
        public decimal? KcDph3 { get; set; }
        public decimal? KcZaokr { get; set; }
        public decimal? KcCelkem { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public decimal? Cm0 { get; set; }
        public decimal? CmZaokr { get; set; }
        public decimal? CmCelkem { get; set; }
        public bool Vyrizeno { get; set; }
        public bool Bprenes { get; set; }
        public int? RefAd { get; set; }
        public int? RefAddod { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public string Firma2 { get; set; }
        public string Utvar2 { get; set; }
        public string Jmeno2 { get; set; }
        public string Ulice2 { get; set; }
        public string Psc2 { get; set; }
        public string Obec2 { get; set; }
        public int? RefZeme2 { get; set; }
        public string Tel2 { get; set; }
        public string Email2 { get; set; }
        public string Kjmeno { get; set; }
        public string Kutvar { get; set; }
        public string Ktel { get; set; }
        public string Kemail { get; set; }
        public string CisDokl { get; set; }
        public DateTime? DatDokl { get; set; }
        public int? RefZpPrij { get; set; }
        public int? RefZpVydej { get; set; }
        public int? ZaokrFv { get; set; }
        public DateTime? DatCreate { get; set; }
        public bool Polozky { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public string CenyIds { get; set; }
        public bool Uzavreno { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string PopZavady { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public string Ttext { get; set; }

        public ICollection<TServPredm> TServPredm { get; set; }
        public ICollection<TServStav> TServStav { get; set; }
        public ICollection<TServpol> TServpol { get; set; }
    }
}
