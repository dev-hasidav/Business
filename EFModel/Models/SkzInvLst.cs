using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzInvLst
    {
        public SkzInvLst()
        {
            SkzInv = new HashSet<SkzInv>();
            SkzInvVc = new HashSet<SkzInvVc>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefSklad { get; set; }
        public DateTime? Datum { get; set; }
        public string Stext { get; set; }
        public bool Zauct { get; set; }
        public bool OldDt { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }

        public ICollection<SkzInv> SkzInv { get; set; }
        public ICollection<SkzInvVc> SkzInvVc { get; set; }
    }
}
