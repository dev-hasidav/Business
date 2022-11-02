using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Rekl
    {
        public Rekl()
        {
            ReklKomp = new HashSet<ReklKomp>();
            ReklPredm = new HashSet<ReklPredm>();
            ReklStav = new HashSet<ReklStav>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RelTpRekl { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RelTpCalcDph { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public string Pdoklad { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatVyrDo { get; set; }
        public DateTime? DatVyrizeno { get; set; }
        public int? RefRekl { get; set; }
        public int? RefOsoba { get; set; }
        public string Stext { get; set; }
        public string DicregDpheu { get; set; }
        public bool Uzavreno { get; set; }
        public int? RefSkz { get; set; }
        public string SkzNazev { get; set; }
        public string SkzStext { get; set; }
        public string CisReklList { get; set; }
        public int? RelReklStav { get; set; }
        public int? RefStavDod { get; set; }
        public string StavFirma { get; set; }
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
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<ReklKomp> ReklKomp { get; set; }
        public ICollection<ReklPredm> ReklPredm { get; set; }
        public ICollection<ReklStav> ReklStav { get; set; }
    }
}
