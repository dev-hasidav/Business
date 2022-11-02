using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class OprPoloz
    {
        public OprPoloz()
        {
            OprPolozPol = new HashSet<OprPolozPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? UsrOrder { get; set; }
        public int? RelTpOpr { get; set; }
        public int? RelDrOpr { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public DateTime? Datum { get; set; }
        public string VarSym { get; set; }
        public string ParSym { get; set; }
        public string Stext { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcZust { get; set; }
        public int? RefCm { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public decimal? Cm0 { get; set; }
        public decimal? CmCelkem { get; set; }
        public decimal? CmZust { get; set; }
        public int? RefAd { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public int? RelAgId { get; set; }
        public int? RefId { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string Pozn { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<OprPolozPol> OprPolozPol { get; set; }
    }
}
