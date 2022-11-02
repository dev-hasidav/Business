using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphevd
    {
        public Dphevd()
        {
            Dphevdpol = new HashSet<Dphevdpol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public DateTime? Datum { get; set; }
        public int? Rok { get; set; }
        public int? RelObEvd { get; set; }
        public int? RelTypDphevd { get; set; }
        public int? RelDruh { get; set; }
        public decimal? Kc0 { get; set; }
        public decimal? Kc1 { get; set; }
        public decimal? Kc2 { get; set; }
        public decimal? Kc3 { get; set; }
        public bool ElOdeslano { get; set; }
        public int? RefDph { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }

        public ICollection<Dphevdpol> Dphevdpol { get; set; }
    }
}
