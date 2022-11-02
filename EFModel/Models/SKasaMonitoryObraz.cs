using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaMonitoryObraz
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Stext { get; set; }
        public string Soubor { get; set; }
        public int? Cas { get; set; }
        public int? OrderFld { get; set; }

        public SKasaMonitory RefAgNavigation { get; set; }
    }
}
