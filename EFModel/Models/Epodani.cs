using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Epodani
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelSluzba { get; set; }
        public int? RelZpusob { get; set; }
        public string Popis { get; set; }
        public int? RelDruhEp { get; set; }
        public int? RelTypEp { get; set; }
        public DateTime? DatOdes { get; set; }
        public DateTime? DatPrij { get; set; }
        public string ElPodpis { get; set; }
        public bool Rozsahle { get; set; }
        public string RozsahleId { get; set; }
        public string RozsahlePw { get; set; }
        public int? RefId { get; set; }
        public string Vazba { get; set; }
        public byte[] DatVeta { get; set; }
        public byte[] Sestava { get; set; }
        public int? RelStavEp { get; set; }
        public DateTime? DatStav { get; set; }
        public string IdentEpps { get; set; }
        public string IdentEp { get; set; }
        public string RespPoint { get; set; }
        public byte[] Dorucenka { get; set; }
        public byte[] Submit { get; set; }
        public int? RelObdobi { get; set; }
        public int? Rok { get; set; }
        public DateTime? InterOd { get; set; }
        public DateTime? InterDo { get; set; }
        public bool ImpEnesch { get; set; }
        public string HistorieLog { get; set; }
        public bool Official { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
