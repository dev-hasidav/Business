using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SRp
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Nazev { get; set; }
        public string StextDoc { get; set; }
        public decimal? KcRp { get; set; }
        public string Mj { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }
    }
}
