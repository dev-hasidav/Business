using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ElArchiv
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public bool Zapnuto { get; set; }
        public int? RelElArchiv { get; set; }
        public DateTime? DatOd { get; set; }
        public int? RelTrackTyp { get; set; }
        public byte[] Settings { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
