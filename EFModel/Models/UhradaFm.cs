using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class UhradaFm
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RelForUh { get; set; }
        public DateTime? Datum { get; set; }
        public string Stext { get; set; }
        public decimal? KcPrijato { get; set; }
        public int? RefUcet { get; set; }
        public decimal? Prijato { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public bool PlatTerm { get; set; }
        public string VarSym { get; set; }
        public int? EkasaParNum { get; set; }
        public DateTime? EkasaDatPar { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
    }
}
