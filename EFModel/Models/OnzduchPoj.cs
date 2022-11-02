using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class OnzduchPoj
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefPol { get; set; }
        public int? Radek { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }

        public Onzpol RefPolNavigation { get; set; }
    }
}
