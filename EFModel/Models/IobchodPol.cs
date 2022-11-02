using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class IobchodPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public byte[] Settings { get; set; }
        public int? OrderFld { get; set; }

        public Iobchod RefAgNavigation { get; set; }
    }
}
