using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKonfig
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? Verze { get; set; }
        public int? Rok { get; set; }
        public int? RelRokTp { get; set; }
        public DateTime? DatRokOd { get; set; }
        public DateTime? DatRokDo { get; set; }
        public bool Prelom { get; set; }
        public int? RelUtyp { get; set; }
        public int? RelOsTyp { get; set; }
        public int? PzdAut { get; set; }
        public int? RelTpPzd { get; set; }
        public string Firma { get; set; }
        public string ObchDod { get; set; }
        public string Jmeno { get; set; }
        public string Prijm { get; set; }
        public string Titul { get; set; }
        public string VztahP { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Obec { get; set; }
        public string Psc { get; set; }
        public string Okres { get; set; }
        public int? RefZeme { get; set; }
        public string Firma2 { get; set; }
        public string Ulice2 { get; set; }
        public string Obec2 { get; set; }
        public string Psc2 { get; set; }
        public string Klic { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Www { get; set; }
        public string Registr { get; set; }
        public bool PodporaBi { get; set; }
        public bool OfferForBackup { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public byte[] Settings { get; set; }
        public int? LogoTp { get; set; }
        public byte[] Logo { get; set; }
        public bool LogoBgnd { get; set; }
        public byte[] Stamp { get; set; }
    }
}
