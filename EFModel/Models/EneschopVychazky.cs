using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class EneschopVychazky
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatVznikNotif { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public DateTime? CasOd { get; set; }
        public DateTime? CasDo { get; set; }

        public EneschopPol RefAgNavigation { get; set; }
    }
}
