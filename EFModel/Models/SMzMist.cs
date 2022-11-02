using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SMzMist
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Misto { get; set; }
        public string Obec { get; set; }
        public string Cislo { get; set; }
        public string Okres { get; set; }
        public string Stat { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
