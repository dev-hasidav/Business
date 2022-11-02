using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaOdlozPh
    {
        public SKasaOdlozPh()
        {
            SKasaOdlozPhpol = new HashSet<SKasaOdlozPhpol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public DateTime? DatSave { get; set; }
        public int? RefKasa { get; set; }
        public int? RefUcet { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? KcDph1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? KcDph2 { get; set; }
        public decimal? Kc3 { get; set; }
        public decimal? KcDph3 { get; set; }
        public decimal? KcCelkem { get; set; }
        public int? ZaokrPh { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Utvar { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public int? RefCin { get; set; }
        public int? IdcnZ { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }

        public ICollection<SKasaOdlozPhpol> SKasaOdlozPhpol { get; set; }
    }
}
