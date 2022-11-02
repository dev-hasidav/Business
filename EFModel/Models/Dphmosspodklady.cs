using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphmosspodklady
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelAg { get; set; }
        public int? DoklId { get; set; }
        public int? RelTpFak { get; set; }
        public string Dodavatel { get; set; }
        public string Zeme { get; set; }
        public int? RelMosstyp { get; set; }
        public string Mossdruh { get; set; }
        public int? RefCm { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public string Cislo { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatZdPlnPdoklad { get; set; }
        public string Stext { get; set; }
        public string StextPol { get; set; }
        public string Mjpol { get; set; }
        public double? MnozstviPol { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public decimal? VatBase { get; set; }
        public decimal? Vat { get; set; }
        public decimal? VatBaseEur { get; set; }
        public decimal? VatEur { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Mossdukaz { get; set; }

        public Dphmoss RefAgNavigation { get; set; }
    }
}
