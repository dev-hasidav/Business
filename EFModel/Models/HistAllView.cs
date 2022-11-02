using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class HistAllView
    {
        public HistAllView()
        {
            HistAllViewPol = new HashSet<HistAllViewPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelZmAgId { get; set; }
        public int? RefId { get; set; }
        public int? RelZmTyp { get; set; }
        public string Cislo { get; set; }
        public int? OrigId { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<HistAllViewPol> HistAllViewPol { get; set; }
    }
}
