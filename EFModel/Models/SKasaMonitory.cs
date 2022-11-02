using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaMonitory
    {
        public SKasaMonitory()
        {
            SKasaMonitoryObraz = new HashSet<SKasaMonitoryObraz>();
            SKasaMonitorySettings = new HashSet<SKasaMonitorySettings>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public int? RelMrezim { get; set; }
        public bool ShowLogo { get; set; }
        public int? RelFontSize { get; set; }
        public string Tema { get; set; }
        public int? RefPzdJ { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SKasaMonitoryObraz> SKasaMonitoryObraz { get; set; }
        public ICollection<SKasaMonitorySettings> SKasaMonitorySettings { get; set; }
    }
}
