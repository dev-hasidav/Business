using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class OprPolozPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public bool Uzavreno { get; set; }
        public DateTime? Datum { get; set; }
        public int? RelOpOpr { get; set; }
        public decimal? Kc { get; set; }
        public int? RefCm { get; set; }
        public double? CmKurs { get; set; }
        public int? CmMnoz { get; set; }
        public decimal? Cm { get; set; }
        public bool Rucne { get; set; }
        public int? RelPk { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public OprPoloz RefAgNavigation { get; set; }
    }
}
