using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SBi
    {
        public int Id { get; set; }
        public string STable { get; set; }
        public string SColumn { get; set; }
        public int? LId { get; set; }
        public string SName { get; set; }
        public int? LValue { get; set; }
        public string SValue { get; set; }
        public int? LAgId { get; set; }
    }
}
