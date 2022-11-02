using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Enp
    {
        public Enp()
        {
            Enpitems = new HashSet<Enpitems>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Nazev { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatExport { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<Enpitems> Enpitems { get; set; }
    }
}
