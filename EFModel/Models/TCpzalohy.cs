using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TCpzalohy
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatVypl { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? KcZal { get; set; }
        public int? RefCm { get; set; }
        public string Doklad { get; set; }
        public string Pozn { get; set; }
        public int? OrderFld { get; set; }
        public string Ttext { get; set; }
    }
}
