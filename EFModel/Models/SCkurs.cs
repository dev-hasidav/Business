using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SCkurs
    {
        public SCkurs()
        {
            SCkurspol = new HashSet<SCkurspol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelCkurs { get; set; }
        public DateTime? Datum { get; set; }
        public bool Polozky { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<SCkurspol> SCkurspol { get; set; }
    }
}
