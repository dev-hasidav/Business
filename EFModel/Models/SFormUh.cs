using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SFormUh
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelTyp { get; set; }
        public int? RelTypFm { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool UseInAgOt { get; set; }
        public bool UseInAgPh { get; set; }
        public bool Bpuhr { get; set; }
        public int? RefCm { get; set; }
        public double? CmKurs { get; set; }
        public int? CmMnoz { get; set; }
        public bool KurzAutomat { get; set; }
        public bool KurzVcerejsi { get; set; }
        public decimal? Hodnota { get; set; }
        public bool ForEet { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Oznacil { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }
    }
}
