using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TAdgdpr
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefGdprDuvod { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public DateTime? DatOdvolani { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Ttext { get; set; }

        public TAd RefAgNavigation { get; set; }
    }
}
