using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkRefKat
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefKat { get; set; }
    }
}
