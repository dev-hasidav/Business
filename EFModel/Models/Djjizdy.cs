using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Djjizdy
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RefVoz { get; set; }
        public int? RefRidic { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatumP { get; set; }
        public string Cas { get; set; }
        public string CasP { get; set; }
        public string Odkud { get; set; }
        public string Kam { get; set; }
        public string Pres { get; set; }
        public string Ucel { get; set; }
        public double? Km { get; set; }
        public bool Soukr { get; set; }
        public double? Cerpano { get; set; }
        public string Misto { get; set; }
        public decimal? Kc { get; set; }
        public bool Prives { get; set; }
        public decimal? KcNahr { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public double? ProcPhm { get; set; }
        public decimal? Kcl { get; set; }
        public decimal? KclVoz { get; set; }
        public decimal? KcPhm { get; set; }
        public decimal? KcPausal { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcCelkZaokr { get; set; }
        public bool Pouzito { get; set; }
        public bool Lock1 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? VprIdCp { get; set; }
        public int? VprIdMzcesty { get; set; }

        public Djridic RefRidicNavigation { get; set; }
        public Djvoz RefVozNavigation { get; set; }
    }
}
