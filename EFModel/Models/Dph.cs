using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dph
    {
        public Dph()
        {
            Dphprilohy = new HashSet<Dphprilohy>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? Rok { get; set; }
        public int? RelObDph { get; set; }
        public int? RelDrDph { get; set; }
        public bool Podklady { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatDuvod { get; set; }
        public DateTime? DatOdevz { get; set; }
        public decimal? KcDan { get; set; }
        public decimal? KcOdpoc { get; set; }
        public int? RelKodRoku { get; set; }
        public decimal? KcZmena { get; set; }
        public bool UprKracOdp { get; set; }
        public decimal? KcKracOdp { get; set; }
        public bool VypKoef { get; set; }
        public byte[] Data { get; set; }
        public bool ElOdeslano { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<Dphprilohy> Dphprilohy { get; set; }
    }
}
