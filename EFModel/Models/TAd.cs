using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TAd
    {
        public TAd()
        {
            TAdgdpr = new HashSet<TAdgdpr>();
            TAducet = new HashSet<TAducet>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RefAd { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public string Okres { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public int? RelTypDic { get; set; }
        public string Firma2 { get; set; }
        public string Utvar2 { get; set; }
        public string Jmeno2 { get; set; }
        public string Ulice2 { get; set; }
        public string Psc2 { get; set; }
        public string Obec2 { get; set; }
        public int? RefZeme2 { get; set; }
        public string Tel2 { get; set; }
        public string Email2 { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Www { get; set; }
        public string Skype { get; set; }
        public string Icq { get; set; }
        public string Gps { get; set; }
        public string DataBox { get; set; }
        public string CenyIds { get; set; }
        public int? RelForUh { get; set; }
        public short? Adsplat { get; set; }
        public int? Adtoler { get; set; }
        public decimal? Adkredit { get; set; }
        public decimal? KcObrat { get; set; }
        public decimal? KcObrat2 { get; set; }
        public string Skupina { get; set; }
        public string Klic { get; set; }
        public bool P1 { get; set; }
        public bool P2 { get; set; }
        public bool P3 { get; set; }
        public bool P4 { get; set; }
        public bool P5 { get; set; }
        public bool P6 { get; set; }
        public bool MPohoda { get; set; }
        public int? RelDruh { get; set; }
        public string Ost1 { get; set; }
        public string Ost2 { get; set; }
        public string Zprava { get; set; }
        public string Smlouva { get; set; }
        public string Funkce { get; set; }
        public string RodCisl { get; set; }
        public string Osloveni { get; set; }
        public DateTime? DatNar { get; set; }
        public int? RelPohl { get; set; }
        public int? RelTpIo { get; set; }
        public string IoId { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? RelPkFp { get; set; }
        public int? RelTpDphfp { get; set; }
        public int? RelPkFv { get; set; }
        public int? RelTpDphfv { get; set; }
        public int? RefUcetFv { get; set; }
        public int? RefOsoba { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public int? RefCm { get; set; }
        public int? RelSzDph { get; set; }
        public int? RelSzDphskz { get; set; }
        public DateTime? GdprDatPreAkt { get; set; }
        public DateTime? GdprDatPreHist { get; set; }
        public DateTime? GdprDatProAkt { get; set; }
        public DateTime? GdprDatProHist { get; set; }
        public DateTime? GdprDatPostAkt { get; set; }
        public DateTime? GdprDatPostHist { get; set; }
        public bool GdprOmezeniZprac { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public string Ttext { get; set; }

        public ICollection<TAdgdpr> TAdgdpr { get; set; }
        public ICollection<TAducet> TAducet { get; set; }
    }
}
