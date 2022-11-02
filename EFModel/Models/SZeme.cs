using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SZeme
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelZeme { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string Kod { get; set; }
        public string KodVateu { get; set; }
        public string KodOsn { get; set; }
        public bool Nabizet { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
