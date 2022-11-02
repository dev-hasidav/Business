using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Cpvyuct
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefCm { get; set; }
        public decimal? KcZaloha { get; set; }
        public decimal? KcStrav { get; set; }
        public decimal? KcStrDnu { get; set; }
        public decimal? KcVydaje { get; set; }
        public decimal? KcNahr { get; set; }
        public decimal? KcNahDnu { get; set; }
        public decimal? KcSmeny { get; set; }
        public decimal? KcCelkem { get; set; }
        public int? RefCmkon { get; set; }
        public double? CmKurs { get; set; }
        public string Smena { get; set; }
        public decimal? KcVyuct { get; set; }
        public decimal? KcDopl { get; set; }
        public decimal? KcZaokr { get; set; }
        public int? OrderFld { get; set; }

        public Cp RefAgNavigation { get; set; }
    }
}
