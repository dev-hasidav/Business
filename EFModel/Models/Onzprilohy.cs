using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Onzprilohy
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefPol { get; set; }
        public string Cesta { get; set; }
        public string Popis { get; set; }

        public Onzpol RefPolNavigation { get; set; }
    }
}
