using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKodyPredmPln
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Mj { get; set; }
        public string Stext { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
