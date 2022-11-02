using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkCeny
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool Cenik { get; set; }
        public int? RelTpPlt { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public int? RelTpCeny { get; set; }
        public float? Marze { get; set; }
        public float? Rabat { get; set; }
        public float? Sleva { get; set; }
        public bool Sdph { get; set; }
        public int? RelTpZkr { get; set; }
        public int? RefSpid { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
