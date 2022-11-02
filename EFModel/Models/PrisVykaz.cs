using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PrisVykaz
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? Rok { get; set; }
        public int? RelMesic { get; set; }
        public int? RelTp { get; set; }
        public DateTime? DatSestav { get; set; }
        public DateTime? DatExport { get; set; }
        public int? RelTisice { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
