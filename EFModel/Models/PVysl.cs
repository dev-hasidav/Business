using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PVysl
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Umd { get; set; }
        public string Ud { get; set; }
        public decimal? Kc { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
