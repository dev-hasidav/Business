using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Impohyb
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelUzavreno { get; set; }
        public int? RefPredm { get; set; }
        public int? RelTpPoh { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Kc { get; set; }
        public int? OdpisMin { get; set; }
        public string Pozn { get; set; }
        public int? RelPk { get; set; }
        public int? RelImAg { get; set; }
        public int? RelAgId { get; set; }
        public string Cislo { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Im RefAgNavigation { get; set; }
    }
}
