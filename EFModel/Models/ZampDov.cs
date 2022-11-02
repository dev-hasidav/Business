using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ZampDov
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatZac { get; set; }
        public DateTime? DatKon { get; set; }
        public int? DnyPrac { get; set; }
        public int? DnyKal { get; set; }
        public float? Dnu { get; set; }
        public int? RelDrDov { get; set; }
        public string Diagnoza { get; set; }
        public DateTime? VypMmrr { get; set; }
        public float? ZacPrac { get; set; }
        public int? RelZacJ { get; set; }
        public float? KonPrac { get; set; }
        public int? RelKonJ { get; set; }
        public int? RelNavaz { get; set; }
        public int? RefNavaz { get; set; }
        public float? Sazba { get; set; }
        public bool CanHzupn { get; set; }
        public int? RefEneschop { get; set; }
        public DateTime? DatZacRo { get; set; }
        public DateTime? DatKonRo { get; set; }
        public DateTime? DatPorod { get; set; }

        public Zam RefAgNavigation { get; set; }
    }
}
