using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RRozvahZ
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? Stav { get; set; }
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C3en { get; set; }
        public string C3ge { get; set; }
        public string Stext { get; set; }
        public string StextEn { get; set; }
        public string StextGe { get; set; }
        public int? Radek { get; set; }
        public string Ucet { get; set; }
        public decimal? Sloup1 { get; set; }
        public decimal? Sloup2 { get; set; }
        public decimal? Sloup1P { get; set; }
        public decimal? Sloup2P { get; set; }
        public decimal? HalerS1 { get; set; }
        public decimal? HalerS2 { get; set; }
        public decimal? HalerS1p { get; set; }
        public decimal? HalerS2p { get; set; }
        public int? Priorita { get; set; }
        public bool Cross1 { get; set; }
        public bool Cross2 { get; set; }
        public bool Cross1P { get; set; }
        public decimal? SloupC { get; set; }
        public decimal? SloupCp { get; set; }
    }
}
