using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PRozv
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelRozTp { get; set; }
        public int? RadekOld { get; set; }
        public int? Radek { get; set; }
        public decimal? KcHaler { get; set; }
        public decimal? KcTisic { get; set; }
        public decimal? KcHaler2 { get; set; }
        public decimal? KcTisic2 { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
