using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SSzDpheupol
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefAg { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public DateTime? PlatneOd { get; set; }
        public DateTime? PlatneDo { get; set; }

        public SSzDpheu RefAgNavigation { get; set; }
    }
}
