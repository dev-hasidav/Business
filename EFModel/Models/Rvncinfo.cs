using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Rvncinfo
    {
        public int Id { get; set; }
        public int? RefSkz { get; set; }
        public DateTime? Datum { get; set; }
        public int? OrderFld { get; set; }
        public int? RelOp { get; set; }
        public int? PohId { get; set; }
        public int? Hupinfo { get; set; }
        public int? TreePos { get; set; }
        public string User { get; set; }
    }
}
