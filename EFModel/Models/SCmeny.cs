using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SCmeny
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public bool Pouzit { get; set; }
        public string Kod { get; set; }
        public string Ids { get; set; }
        public string Zeme { get; set; }
        public int? Mnozstvi { get; set; }
        public bool DenEur { get; set; }
        public DateTime? DatDen { get; set; }
        public float? KoefEur { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckKod { get; set; }
    }
}
