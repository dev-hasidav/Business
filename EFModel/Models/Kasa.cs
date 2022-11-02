using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Kasa
    {
        public Kasa()
        {
            SKasaMonitorySettings = new HashSet<SKasaMonitorySettings>();
            SKasaSkzButton = new HashSet<SKasaSkzButton>();
            SKasaUcty = new HashSet<SKasaUcty>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string Slozka { get; set; }
        public int? RefPzdJ { get; set; }
        public int? RefSklad { get; set; }
        public string Sklady { get; set; }
        public int? RefFormUh { get; set; }
        public bool SelFormUh { get; set; }
        public int? RefSkCeny { get; set; }
        public int? RefProvozovna { get; set; }
        public int? RefStr { get; set; }
        public int? RefEetprofil { get; set; }
        public bool Zip { get; set; }
        public bool Adresar { get; set; }
        public int? RefFilter { get; set; }
        public int? RelKasaTyp { get; set; }
        public string TextPh { get; set; }
        public string Paticka { get; set; }
        public bool SlevaPol { get; set; }
        public bool Sdph { get; set; }
        public bool ProdPlu { get; set; }
        public bool ImpSkpv { get; set; }
        public bool ImpHo { get; set; }
        public bool ImPoDnech { get; set; }
        public bool ClientTs { get; set; }
        public string AllowedPc { get; set; }
        public string AllowedTs { get; set; }
        public bool TouchScreen { get; set; }
        public bool PouzivatUcty { get; set; }
        public bool KasaMonitor { get; set; }
        public int? RefKasaMonitor { get; set; }
        public string SwKeyboard { get; set; }
        public byte[] Settings { get; set; }
        public bool AutSyncPhOff { get; set; }
        public bool NexportData { get; set; }
        public int? RefCrskpv { get; set; }
        public int? RefFormUhSkpv { get; set; }
        public string TextSkpv { get; set; }
        public bool MServer { get; set; }
        public string MKasaGuid { get; set; }
        public string GuidJ { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SKasaMonitorySettings> SKasaMonitorySettings { get; set; }
        public ICollection<SKasaSkzButton> SKasaSkzButton { get; set; }
        public ICollection<SKasaUcty> SKasaUcty { get; set; }
    }
}
