using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SZak
    {
        public SZak()
        {
            SZakplan = new HashSet<SZakplan>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public string Stext { get; set; }
        public int? RefPzdJ { get; set; }
        public DateTime? PlZahaj { get; set; }
        public DateTime? PlPredani { get; set; }
        public DateTime? Zahajeni { get; set; }
        public DateTime? Predani { get; set; }
        public DateTime? Zaruka { get; set; }
        public int? RefOsoba { get; set; }
        public int? RefStav { get; set; }
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
        public string Ost1 { get; set; }
        public string Ost2 { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<SZakplan> SZakplan { get; set; }
    }
}
