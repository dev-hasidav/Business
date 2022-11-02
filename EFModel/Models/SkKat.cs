using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkKat
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string SupNodeIds { get; set; }
        public int? RefNodeId { get; set; }
        public string Pozice { get; set; }
        public int? Poradi { get; set; }
        public bool Zobraz { get; set; }
        public string Obrazek { get; set; }
        public string FullTreeNode { get; set; }
        public int? Node { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
    }
}
