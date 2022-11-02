using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Mzdavky
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatZac { get; set; }
        public DateTime? DatKon { get; set; }
        public int? RelDrDov { get; set; }
        public float? HodPrac { get; set; }
        public decimal? KcZakVyp { get; set; }
        public decimal? KcZakUpl { get; set; }
        public float? KracVvz { get; set; }
        public decimal? KcDenVz { get; set; }
        public decimal? KcNaDen { get; set; }
        public decimal? Kc { get; set; }
        public string Cislo { get; set; }
        public bool Oprava { get; set; }
        public float? Sazba { get; set; }
        public float? Kraceni { get; set; }

        public Mz RefAgNavigation { get; set; }
    }
}
