using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ZamzivPoj
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public int? RefPoj { get; set; }
        public decimal? KcPoj { get; set; }
        public string VarSym { get; set; }
        public string SpecSym { get; set; }
        public bool BezNaroku { get; set; }

        public Zam RefAgNavigation { get; set; }
    }
}
