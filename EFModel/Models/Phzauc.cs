using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Phzauc
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefStr { get; set; }
        public int? RefFormUh { get; set; }
        public int? RelAgIdZauc { get; set; }
        public int? RefUcet { get; set; }
        public bool SamostZauct { get; set; }
        public int? RelPk { get; set; }
        public string Umd { get; set; }
        public string Ud { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
