using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Uhrady
    {
        public int Id { get; set; }
        public DateTime? DatumU { get; set; }
        public int? RelAgH { get; set; }
        public int? RelIdh { get; set; }
        public string CisloH { get; set; }
        public string VarSymH { get; set; }
        public int? RelAgU { get; set; }
        public int? RelIdu { get; set; }
        public int? RefDd { get; set; }
        public string CisloU { get; set; }
        public decimal? KcU { get; set; }
        public decimal? CmH { get; set; }
        public decimal? CmU { get; set; }
        public decimal? KcKrozd { get; set; }
        public bool Bzavaz { get; set; }
        public bool UzKursu { get; set; }
        public decimal? KcEet { get; set; }
        public int? RelAgPrepl { get; set; }
        public int? RelIdprepl { get; set; }
        public decimal? KcPrepl { get; set; }
        public string Pozn { get; set; }
    }
}
