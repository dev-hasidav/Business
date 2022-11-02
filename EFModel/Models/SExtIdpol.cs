using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SExtIdpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefDocId { get; set; }
        public string RefTable { get; set; }
        public string Ids { get; set; }

        public SExtId RefAgNavigation { get; set; }
    }
}
