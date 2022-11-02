using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkRekl
    {
        public SkRekl()
        {
            SkReklpol = new HashSet<SkReklpol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public int? RelTpRekl { get; set; }
        public string CisloZak { get; set; }
        public int? RefSklad { get; set; }
        public int? RefZeme { get; set; }
        public int? RefPrijem { get; set; }
        public int? ZaokrFv { get; set; }
        public bool Sel { get; set; }
        public bool Polozky { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public string ParSym { get; set; }
        public string Stext { get; set; }
        public string Spopis { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatumDokl { get; set; }
        public string CisDokl { get; set; }
        public int? RelStorn { get; set; }
        public bool TpStorn { get; set; }
        public DateTime? DatObj { get; set; }
        public string CisloObj { get; set; }
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
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
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
        public string Aucet { get; set; }
        public string Kjmeno { get; set; }
        public string Kutvar { get; set; }
        public string Ktel { get; set; }
        public string Kemail { get; set; }
        public int? RefZpVyr { get; set; }
        public string ZpVyr { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public DateTime? DatumP { get; set; }
        public DateTime? DatumO { get; set; }
        public string SerText { get; set; }
        public string SerPopis { get; set; }
        public int? SerRefAd { get; set; }
        public int? SerRefZeme { get; set; }
        public string SerFirma { get; set; }
        public string SerUtvar { get; set; }
        public string SerJmeno { get; set; }
        public string SerUlice { get; set; }
        public string SerPsc { get; set; }
        public string SerObec { get; set; }
        public string SerIco { get; set; }
        public string SerDic { get; set; }
        public string SerIcdph { get; set; }
        public string SerKjmeno { get; set; }
        public string SerKutvar { get; set; }
        public string SerKtel { get; set; }
        public string SerKemail { get; set; }
        public int? RelSerZpVyr { get; set; }
        public string SerZpVyr { get; set; }
        public string SerZpPosl { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<SkReklpol> SkReklpol { get; set; }
    }
}
