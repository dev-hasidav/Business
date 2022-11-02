using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TCpetapy
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatOd { get; set; }
        public string CasOd { get; set; }
        public string MistoOd { get; set; }
        public DateTime? DatDo { get; set; }
        public string CasDo { get; set; }
        public string MistoDo { get; set; }
        public int? RelZpDpr { get; set; }
        public string CasPocPr { get; set; }
        public string CasKonPr { get; set; }
        public double? Km { get; set; }
        public int? RelZeme { get; set; }
        public bool Prives { get; set; }
        public int? OrderFld { get; set; }
        public string Ttext { get; set; }
    }
}
