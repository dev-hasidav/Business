using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Djvoz
    {
        public Djvoz()
        {
            Cp = new HashSet<Cp>();
            Djjizdy = new HashSet<Djjizdy>();
            TCp = new HashSet<TCp>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Spz { get; set; }
        public string Znacka { get; set; }
        public DateTime? DatVyr { get; set; }
        public int? RelTypVoz { get; set; }
        public int? RelDrVoz { get; set; }
        public int? RelVozKod { get; set; }
        public int? RelPhm { get; set; }
        public double? Spotr { get; set; }
        public double? ProcPhm { get; set; }
        public double? TachPoc { get; set; }
        public double? Objem { get; set; }
        public int? Provoz { get; set; }
        public bool Prives { get; set; }
        public bool Ceny { get; set; }
        public double? NadrzPoc { get; set; }
        public DateTime? DatZar { get; set; }
        public DateTime? DatEvid { get; set; }
        public int? RelPoplatnik { get; set; }
        public int? RelOsvob { get; set; }
        public int? RelSnizSazby { get; set; }
        public double? Hmotnost { get; set; }
        public int? PocetNaprav { get; set; }
        public int? RelTypNo { get; set; }
        public bool Elektromobil { get; set; }
        public double? ElMobVykon { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<Cp> Cp { get; set; }
        public ICollection<Djjizdy> Djjizdy { get; set; }
        public ICollection<TCp> TCp { get; set; }
    }
}
