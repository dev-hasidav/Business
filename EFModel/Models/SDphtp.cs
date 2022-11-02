using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SDphtp
    {
        public int Id { get; set; }
        public bool Vydaj { get; set; }
        public int? Dph { get; set; }
        public string Stext { get; set; }
        public DateTime? PlatneOd { get; set; }
        public DateTime? PlatneDo { get; set; }
        public string Radky { get; set; }
        public int? Priznani { get; set; }
        public bool KodPredmPln { get; set; }
        public int? RelVlivKhdph { get; set; }
    }
}
