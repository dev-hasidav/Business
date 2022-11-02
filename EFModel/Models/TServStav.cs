using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TServStav
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public int? RelServStav { get; set; }
        public string Firma { get; set; }
        public int? RefAd { get; set; }
        public int? RelZpPosl { get; set; }
        public int? RefOsoba { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public TServ RefAgNavigation { get; set; }
    }
}
