using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzInvZc
    {
        public int Id { get; set; }
        public int? RelSkDruh { get; set; }
        public int? RelZcTp { get; set; }
        public bool Manko { get; set; }
        public string Aucet { get; set; }
    }
}
