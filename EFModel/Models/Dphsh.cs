using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphsh
    {
        public Dphsh()
        {
            DphshcallOfStock = new HashSet<DphshcallOfStock>();
            Dphshpodklady = new HashSet<Dphshpodklady>();
            Dphshpol = new HashSet<Dphshpol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public DateTime? Datum { get; set; }
        public int? Rok { get; set; }
        public int? RelObSh { get; set; }
        public int? RelDrDphsh { get; set; }
        public decimal? KcPlneniCelkem { get; set; }
        public bool ElOdeslano { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<DphshcallOfStock> DphshcallOfStock { get; set; }
        public ICollection<Dphshpodklady> Dphshpodklady { get; set; }
        public ICollection<Dphshpol> Dphshpol { get; set; }
    }
}
