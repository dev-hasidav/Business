using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SCrady
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? Rok { get; set; }
        public int? RefIdor { get; set; }
        public string Ids { get; set; }
        public string Cislo { get; set; }
        public string Stext { get; set; }
        public int? RelCrAg { get; set; }
        public int? RelCrTyp { get; set; }
        public int? RefCrUc { get; set; }
        public int? RefPzdJ { get; set; }
        public int? RelTpObd { get; set; }
        public bool MPohoda { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
