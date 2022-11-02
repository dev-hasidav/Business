using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class DphshcallOfStock
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? UsrOrder { get; set; }
        public string Dic { get; set; }
        public string Dicpuvodni { get; set; }
        public int? RelKod { get; set; }

        public Dphsh RefAgNavigation { get; set; }
    }
}
