using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkParam
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? RelTyp { get; set; }
        public int? Delka { get; set; }
        public string Mj { get; set; }
        public int? RefCm { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
