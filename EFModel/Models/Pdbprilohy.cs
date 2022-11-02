using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Pdbprilohy
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Stext { get; set; }
        public string Cesta { get; set; }

        public Pdb RefAgNavigation { get; set; }
    }
}
