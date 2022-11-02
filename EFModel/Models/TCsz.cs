using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TCsz
    {
        public int Id { get; set; }
        public int? RefGroup { get; set; }
        public int? RelCszag { get; set; }
        public int? OrdFldIdr { get; set; }
        public int? RelTpHo { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public string Cislo { get; set; }
        public decimal? Kc { get; set; }
    }
}
