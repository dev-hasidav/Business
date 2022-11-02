using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzVntmp
    {
        public int Id { get; set; }
        public decimal? Vnc { get; set; }
        public decimal? Vncr { get; set; }
        public decimal? VncocJ { get; set; }
        public decimal? Pnakup { get; set; }
        public double? StavZ { get; set; }
        public int? RefSkz { get; set; }
        public string User { get; set; }
        public string Umd { get; set; }
        public string Ud { get; set; }
        public string Umdud { get; set; }
        public string Umdtxt { get; set; }
        public string Udtxt { get; set; }
        public DateTime? Datum { get; set; }
    }
}
