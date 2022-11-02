using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Pozastavky
    {
        public int Id { get; set; }
        public int? RelAg { get; set; }
        public int? RelId { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatSplat { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcLikv { get; set; }
        public decimal? Cm { get; set; }
        public decimal? CmLikv { get; set; }
        public DateTime? DatLikv { get; set; }
        public string Stext { get; set; }
        public int? RelPk { get; set; }
        public int? OrderFld { get; set; }
        public int? RelTpCalc { get; set; }
        public double? Procento { get; set; }
    }
}
