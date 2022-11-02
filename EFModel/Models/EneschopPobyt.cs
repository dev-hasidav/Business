using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class EneschopPobyt
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatVznikNotif { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Co { get; set; }
        public string Obec { get; set; }
        public string Psc { get; set; }
        public string KodStatu { get; set; }
        public string Dodatek { get; set; }

        public EneschopPol RefAgNavigation { get; set; }
    }
}
