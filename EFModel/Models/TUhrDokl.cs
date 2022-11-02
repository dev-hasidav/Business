using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TUhrDokl
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgIdDokl { get; set; }
        public int? RefFormUh { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? KcDph1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? KcDph2 { get; set; }
        public decimal? Kc3 { get; set; }
        public decimal? KcDph3 { get; set; }
        public decimal? KcZaokr { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcPrijato { get; set; }
        public decimal? KcVraceno { get; set; }
        public decimal? Prijato { get; set; }
        public double? CmKurs { get; set; }
        public int? CmMnoz { get; set; }
        public decimal? StravHodnota { get; set; }
        public bool PlatTerm { get; set; }
        public string VarSym { get; set; }
        public int? RefUcet { get; set; }
        public int? OrderFld { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public string Creator { get; set; }
        public DateTime? DatSave { get; set; }
        public string Ucetni { get; set; }
    }
}
