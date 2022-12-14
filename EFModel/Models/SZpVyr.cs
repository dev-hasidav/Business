using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SZpVyr
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? RefUznana { get; set; }
        public int? RefPohyb { get; set; }
        public int? RefTypUzn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }
    }
}
