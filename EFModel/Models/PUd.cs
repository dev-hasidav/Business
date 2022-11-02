using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PUd
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public byte? TpUd { get; set; }
        public byte? RelDruhUd { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatZdPln { get; set; }
        public string Cislo { get; set; }
        public int? OrderFld { get; set; }
        public int? RelUdAg { get; set; }
        public int? RelAgId { get; set; }
        public int? RefPozas { get; set; }
        public int? RefUd { get; set; }
        public string Stext { get; set; }
        public string Umd { get; set; }
        public string Ud { get; set; }
        public decimal? Kc { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public decimal? Cm { get; set; }
        public decimal? OrigKc1 { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public int? RefCin { get; set; }
        public string UmducelZnak { get; set; }
        public string UducelZnak { get; set; }
        public string Umdodpa { get; set; }
        public string Udodpa { get; set; }
        public string Umdpol { get; set; }
        public string Udpol { get; set; }
        public string Umdzj { get; set; }
        public string Udzj { get; set; }
        public string Umdorj { get; set; }
        public string Udorj { get; set; }
        public string Umdorg { get; set; }
        public string Udorg { get; set; }
        public string ParSym { get; set; }
        public string ParSym2 { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string ParIco { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
