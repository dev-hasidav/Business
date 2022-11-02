using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphmoss
    {
        public Dphmoss()
        {
            Dphmossopravy = new HashSet<Dphmossopravy>();
            Dphmosspodklady = new HashSet<Dphmosspodklady>();
            Dphmosspol = new HashSet<Dphmosspol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public DateTime? Datum { get; set; }
        public int? Rok { get; set; }
        public int? RelObMoss { get; set; }
        public int? RelDrDphmoss { get; set; }
        public string Prijemce { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public decimal? PlneniCelkem { get; set; }
        public decimal? OpravyCelkem { get; set; }
        public string MossrefCislo { get; set; }
        public bool ElOdeslano { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<Dphmossopravy> Dphmossopravy { get; set; }
        public ICollection<Dphmosspodklady> Dphmosspodklady { get; set; }
        public ICollection<Dphmosspol> Dphmosspol { get; set; }
    }
}
