using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzBuf
    {
        public int Id { get; set; }
        public int? RefSkz { get; set; }
        public double? StavZ { get; set; }
        public double? Rezer { get; set; }
        public double? ObjedP { get; set; }
        public double? ObjedV { get; set; }
        public double? Reklam { get; set; }
        public double? Servis { get; set; }
        public decimal? Vnakup { get; set; }
        public bool Foul { get; set; }
        public int NullCheckRefSkz { get; set; }

        public Skz RefSkzNavigation { get; set; }
    }
}
