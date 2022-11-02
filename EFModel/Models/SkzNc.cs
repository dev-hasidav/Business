using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzNc
    {
        public int Id { get; set; }
        public bool DefDod { get; set; }
        public int? RefAg { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string ObjKod { get; set; }
        public string ObjNazev { get; set; }
        public decimal? NakupC { get; set; }
        public int? RefCm { get; set; }
        public double? CmKurs { get; set; }
        public bool Sdph { get; set; }
        public string Ean { get; set; }
        public bool PrintEan { get; set; }
        public string Mjean { get; set; }
        public double? MjkoefEan { get; set; }
        public int? DobaDod { get; set; }
        public int? RelDbDod { get; set; }
        public double? MinMnoz { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public int? OrderFld { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Skz RefAgNavigation { get; set; }
    }
}
