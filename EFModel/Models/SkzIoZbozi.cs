using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzIoZbozi
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public bool Souvisejici { get; set; }
        public int? OrderFld { get; set; }
    }
}
