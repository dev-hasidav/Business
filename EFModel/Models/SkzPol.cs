using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzPol
    {
        public SkzPol()
        {
            SkzCnPol = new HashSet<SkzCnPol>();
        }

        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public double? Mnozstvi { get; set; }
        public int? OrderFld { get; set; }
        public int? RelTypPol { get; set; }
        public bool PrijemSz { get; set; }
        public bool NevysklSz { get; set; }
        public bool UpravaCen { get; set; }

        public Skz RefAgNavigation { get; set; }
        public ICollection<SkzCnPol> SkzCnPol { get; set; }
    }
}
