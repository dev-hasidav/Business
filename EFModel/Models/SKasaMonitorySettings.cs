using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaMonitorySettings
    {
        public int Id { get; set; }
        public int? RefKasa { get; set; }
        public int? RefKasaMonitor { get; set; }
        public byte[] Settings { get; set; }

        public SKasaMonitory RefKasaMonitorNavigation { get; set; }
        public Kasa RefKasaNavigation { get; set; }
    }
}
