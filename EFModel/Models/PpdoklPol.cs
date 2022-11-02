using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PpdoklPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelTypBv { get; set; }
        public string Dokl { get; set; }
        public string Par { get; set; }
        public int? RelCastka { get; set; }
        public int? RelSpln { get; set; }
        public bool EndG { get; set; }
        public int? RelEndG { get; set; }
        public string Pozn { get; set; }
        public int? OrderFld { get; set; }

        public Ppdokl RefAgNavigation { get; set; }
    }
}
