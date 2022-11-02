using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SCin
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RelTypDp { get; set; }
        public int? RefPzdJ { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }
    }
}
