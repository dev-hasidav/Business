using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TCpsmeny
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? KcZmeny { get; set; }
        public int? RefCmz { get; set; }
        public decimal? KcNaMenu { get; set; }
        public int? RefCmna { get; set; }
        public int? RelCmMn { get; set; }
        public double? CmKurs { get; set; }
        public bool Kursy { get; set; }
        public decimal? KcPopl { get; set; }
        public int? RefCmpop { get; set; }
        public string Smena { get; set; }
        public bool Pouzit { get; set; }
        public int? OrderFld { get; set; }
        public string Ttext { get; set; }
    }
}
