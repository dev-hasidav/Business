using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkCspol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkCeny { get; set; }
        public float? Marze { get; set; }
        public float? Rabat { get; set; }
        public float? Sleva { get; set; }
        public bool UpravSex { get; set; }
        public bool UpravS { get; set; }
        public bool Sdph { get; set; }
        public int? RelTpZkr { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public bool Pouzit { get; set; }

        public SkCs RefAgNavigation { get; set; }
    }
}
