using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ReklStav
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public int? RelReklStav { get; set; }
        public int? RelReklZpVyr { get; set; }
        public string PopisVyr { get; set; }
        public bool Servis { get; set; }
        public string Firma { get; set; }
        public int? RefAd { get; set; }
        public int? RelZpPosl { get; set; }
        public int? RelCr { get; set; }
        public string CisReklList { get; set; }
        public int? RefSkz { get; set; }
        public string Kod { get; set; }
        public string Stext { get; set; }
        public string Vcislo { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public bool Vyrizeno { get; set; }
        public double? Kvyrizeni { get; set; }
        public string KvyrMj { get; set; }
        public double? Prenes { get; set; }
        public string PrenesMj { get; set; }
        public int? RefOsoba { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public Rekl RefAgNavigation { get; set; }
    }
}
