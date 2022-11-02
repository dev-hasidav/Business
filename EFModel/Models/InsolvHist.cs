using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class InsolvHist
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ico { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgId { get; set; }
        public string Status { get; set; }
        public string Stext { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Firma { get; set; }
        public string Creator { get; set; }
        public string Ucetni { get; set; }
        public string Oznacil { get; set; }
    }
}
