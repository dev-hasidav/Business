using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzVcp
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public double? Mnozstvi { get; set; }
        public int? RelAgIddst { get; set; }
        public string User { get; set; }
    }
}
