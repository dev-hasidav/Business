using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzVcpoh
    {
        public int Id { get; set; }
        public int? RefVc { get; set; }
        public int? RefSkz { get; set; }
        public int? RelOp { get; set; }
        public DateTime? Datum { get; set; }
        public double? PohPmj { get; set; }

        public SkzVc RefVcNavigation { get; set; }
    }
}
