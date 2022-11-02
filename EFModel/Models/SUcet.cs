using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SUcet
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelJeUcet { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string SpecSym { get; set; }
        public string KodBanky { get; set; }
        public string Banka { get; set; }
        public DateTime? Zrusen { get; set; }
        public string Swift { get; set; }
        public string Iban { get; set; }
        public string Aucet { get; set; }
        public bool Sepa { get; set; }
        public decimal? KcStav { get; set; }
        public int? RefCm { get; set; }
        public bool KcmPev { get; set; }
        public int? RefHb { get; set; }
        public int? RelTermHwTp { get; set; }
        public int? RefUsr { get; set; }
        public int? RefPzdJ { get; set; }
        public bool RegDoklFm { get; set; }
        public bool MPohoda { get; set; }
        public int? RelDruh { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }
    }
}
