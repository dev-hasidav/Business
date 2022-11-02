using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Cpstrav
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public int? RelZeme { get; set; }
        public string Cm { get; set; }
        public double? Hodin { get; set; }
        public double? Doba { get; set; }
        public decimal? KcSazba { get; set; }
        public decimal? KcLegStr { get; set; }
        public bool Uprava { get; set; }
        public bool Snidane { get; set; }
        public bool Obed { get; set; }
        public bool Vecere { get; set; }
        public decimal? KcKapes { get; set; }
        public int? Kratit { get; set; }
        public decimal? KcStrav { get; set; }
        public int? OrderFld { get; set; }

        public Cp RefAgNavigation { get; set; }
    }
}
