using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PPk
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelPkAg { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string Umd { get; set; }
        public string Ud { get; set; }
        public string Stext2 { get; set; }
        public string Umd2 { get; set; }
        public string Ud2 { get; set; }
        public string Stext1 { get; set; }
        public string Umd1 { get; set; }
        public string Ud1 { get; set; }
        public string Stext3 { get; set; }
        public string Umd3 { get; set; }
        public string Ud3 { get; set; }
        public bool Bez { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
