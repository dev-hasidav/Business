using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class LgBulkOp
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelTpBulkOp { get; set; }
        public int? RelAgId { get; set; }
        public int? CntRec { get; set; }
        public string Log { get; set; }
        public string Jmeno { get; set; }
        public string Pcname { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
