using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Eet
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelAg { get; set; }
        public int? RelId { get; set; }
        public string Cislo { get; set; }
        public DateTime? DatTrzby { get; set; }
        public decimal? CelkovaTrzba { get; set; }
        public DateTime? DatOdeslani { get; set; }
        public DateTime? DatPrijeti { get; set; }
        public int? RelStavEet { get; set; }
        public bool Overeni { get; set; }
        public int? RelRezim { get; set; }
        public string Dicpoplat { get; set; }
        public string Dicpover { get; set; }
        public int? Provozovna { get; set; }
        public string Zarizeni { get; set; }
        public string Pkp { get; set; }
        public string Bkp { get; set; }
        public string Fik { get; set; }
        public bool ZmenaDokladu { get; set; }
        public string Uuid { get; set; }
        public int? DatTrzbyPosun { get; set; }
        public bool PrvniZaslani { get; set; }
        public int? KodChyby { get; set; }
        public string PopisChyby { get; set; }
        public int? VerzeProt { get; set; }
        public decimal? ZakladNepodlDph { get; set; }
        public decimal? ZakladDan1 { get; set; }
        public decimal? Dan1 { get; set; }
        public decimal? ZakladDan2 { get; set; }
        public decimal? Dan2 { get; set; }
        public decimal? ZakladDan3 { get; set; }
        public decimal? Dan3 { get; set; }
        public decimal? CestovniSluzba { get; set; }
        public decimal? PouziteZbozi1 { get; set; }
        public decimal? PouziteZbozi2 { get; set; }
        public decimal? PouziteZbozi3 { get; set; }
        public decimal? UrcenoCerpZuct { get; set; }
        public decimal? CerpZuct { get; set; }
        public int? RefCert { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string HistorieLog { get; set; }
        public string Pozn { get; set; }
    }
}
