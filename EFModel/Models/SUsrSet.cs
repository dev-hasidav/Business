using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SUsrSet
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? Rok { get; set; }
        public string Ids { get; set; }
        public string SettingsXml { get; set; }
        public byte[] Settings { get; set; }
        public byte[] Stamp { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
