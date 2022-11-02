using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzRecalcZ
    {
        public int Id { get; set; }
        public int? RefSkz { get; set; }
        public int? RelTpRecalc { get; set; }
        public string User { get; set; }
    }
}
