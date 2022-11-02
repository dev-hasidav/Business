using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphkh
    {
        public Dphkh()
        {
            Dphkhitems = new HashSet<Dphkhitems>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public bool ElOdeslano { get; set; }
        public DateTime? Datum { get; set; }
        public int? Rok { get; set; }
        public string Rodpoved { get; set; }
        public string CisloJv { get; set; }
        public DateTime? DatDuvod { get; set; }
        public int? RelObKh { get; set; }
        public int? RelDrDphkh { get; set; }
        public DateTime? EditTimeStamp { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<Dphkhitems> Dphkhitems { get; set; }
    }
}
