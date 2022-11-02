using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Lmspl
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Kc { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public decimal? KcDph { get; set; }
        public int? RelPk { get; set; }
        public int? RelTpDph { get; set; }
        public decimal? KcFc { get; set; }
        public int? RelFcSzDph { get; set; }
        public double? ProcentoDph2 { get; set; }
        public decimal? KcFcDph { get; set; }
        public int? RelFcPk { get; set; }
        public int? RelFcTpDph { get; set; }
        public decimal? KcPoj { get; set; }
        public int? RelPojPk { get; set; }
        public int? RelPojTpDph { get; set; }
        public decimal? KcZaloha { get; set; }
        public int? RelZalPk { get; set; }
        public int? RelOz { get; set; }

        public Lm RefAgNavigation { get; set; }
    }
}
