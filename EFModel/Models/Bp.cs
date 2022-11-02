using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Bp
    {
        public Bp()
        {
            Bppol = new HashSet<Bppol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public bool Polozky { get; set; }
        public int? RelTpBp { get; set; }
        public bool Sepa { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatSplat { get; set; }
        public DateTime? DatExport { get; set; }
        public string Stext { get; set; }
        public string Udaj { get; set; }
        public int? RefUcet { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? CmCelkem { get; set; }
        public decimal? EurCelkem { get; set; }
        public string KonstSym { get; set; }
        public string RequestId { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<Bppol> Bppol { get; set; }
    }
}
