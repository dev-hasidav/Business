using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SExtToolsLog
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Agenda { get; set; }
        public DateTime? Datum { get; set; }
        public string Command { get; set; }
        public string Directory { get; set; }
        public string RunUser { get; set; }

        public SExtTools RefAgNavigation { get; set; }
    }
}
