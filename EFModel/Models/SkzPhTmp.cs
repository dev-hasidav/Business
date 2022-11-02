using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzPhTmp
    {
        public int Id { get; set; }
        public int? PohId { get; set; }
        public int? RefSkz { get; set; }
        public decimal? Vnakup { get; set; }
        public decimal? KcOceneni { get; set; }
        public double? StavZ { get; set; }
        public int? RelOp { get; set; }
        public DateTime? Datum { get; set; }
        public string User { get; set; }
    }
}
