using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzRefV
    {
        public int Id { get; set; }
        public int? RefSkz { get; set; }
        public int? OrderFld { get; set; }
        public int? RelCenyVyr { get; set; }
        public string User { get; set; }
    }
}
