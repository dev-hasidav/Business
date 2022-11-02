using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dm
    {
        public Dm()
        {
            Dmpohyb = new HashSet<Dmpohyb>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RelTpDm { get; set; }
        public int? RelAgId { get; set; }
        public int? RefPol { get; set; }
        public string Stext { get; set; }
        public DateTime? Datum { get; set; }
        public int? Pocet { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcJedn { get; set; }
        public DateTime? DatLikv { get; set; }
        public int? RefImmist { get; set; }
        public int? RefImclen { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<Dmpohyb> Dmpohyb { get; set; }
    }
}
