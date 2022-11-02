using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Enpitems
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgId { get; set; }
        public int? RelId { get; set; }
        public int? RelStatus { get; set; }
        public string Cislo { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDokl { get; set; }
        public DateTime? DatumDod { get; set; }
        public DateTime? DatumZapl { get; set; }
        public string Ico { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Email { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public Enp RefAgNavigation { get; set; }
    }
}
