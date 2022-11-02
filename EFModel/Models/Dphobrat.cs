using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphobrat
    {
        public int Id { get; set; }
        public int? RelAgId { get; set; }
        public string Zdroj { get; set; }
        public string Cislo { get; set; }
        public DateTime? Datum1 { get; set; }
        public DateTime? Datum2 { get; set; }
        public DateTime? Datum3 { get; set; }
        public DateTime? Datum4 { get; set; }
        public DateTime? DatumRef { get; set; }
        public string Stext1 { get; set; }
        public string Stext2 { get; set; }
        public decimal? KcMd { get; set; }
        public decimal? KcD { get; set; }
        public decimal? KcObrat { get; set; }
        public string Ucet { get; set; }
        public string UcetStext { get; set; }
        public int? OrderFld { get; set; }
    }
}
