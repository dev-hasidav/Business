using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkRefParam
    {
        public int Id { get; set; }
        public int? AgId { get; set; }
        public int? RefAg { get; set; }
        public int? RefParam { get; set; }
        public bool FullList { get; set; }
        public decimal? ValCurrency { get; set; }
        public int? ValLong { get; set; }
        public double? ValDouble { get; set; }
        public string ValText { get; set; }
        public DateTime? ValDate { get; set; }
        public int? OrderFld { get; set; }
    }
}
