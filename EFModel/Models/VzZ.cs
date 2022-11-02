using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class VzZ
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public int? RefUcet { get; set; }
        public int? RefZeme { get; set; }
        public int? RelPk { get; set; }
        public int? RelTpFak { get; set; }
        public int? RelForUh { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public string Cislo { get; set; }
        public string Pdoklad { get; set; }
        public string VarSym { get; set; }
        public string ParSym { get; set; }
        public string Stext { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatSplat { get; set; }
        public string CisloObj { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? KcDph1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? KcDph2 { get; set; }
        public decimal? Kc3 { get; set; }
        public decimal? KcDph3 { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcLikv { get; set; }
        public decimal? KcU { get; set; }
        public decimal? Kzapoctu { get; set; }
        public decimal? KcP { get; set; }
        public DateTime? DatPrik { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public decimal? Cm0 { get; set; }
        public decimal? CmZaloha { get; set; }
        public decimal? CmCelkem { get; set; }
        public decimal? CmLikv { get; set; }
        public decimal? CmU { get; set; }
        public decimal? CmP { get; set; }
        public DateTime? DatSplatPozas { get; set; }
        public decimal? KcPozas { get; set; }
        public decimal? KcLikvPozas { get; set; }
        public decimal? CmPozas { get; set; }
        public decimal? CmLikvPozas { get; set; }
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
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Gsm { get; set; }
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
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string SpecSym { get; set; }
        public string KonstSym { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string User { get; set; }
    }
}
