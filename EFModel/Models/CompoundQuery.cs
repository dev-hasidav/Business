using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class CompoundQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RelAgId { get; set; }
        public int? RelSubId { get; set; }
        public bool IsPublic { get; set; }
        public string Creator { get; set; }
        public byte[] QueryDef { get; set; }
    }
}
