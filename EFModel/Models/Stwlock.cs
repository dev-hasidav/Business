using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Stwlock
    {
        public int Id { get; set; }
        public int Rowid { get; set; }
        public string Tablename { get; set; }
        public short Spid { get; set; }
        public int Processid { get; set; }
    }
}
