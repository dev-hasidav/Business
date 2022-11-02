using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SAnalytika
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefTpAn { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? RelTypCin { get; set; }
        public string RadekPd { get; set; }
        public string RadekPv { get; set; }
        public DateTime? PlatneOd { get; set; }
        public DateTime? PlatneDo { get; set; }
        public string Pozn { get; set; }
        public bool ObratDph { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
