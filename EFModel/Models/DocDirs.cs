using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class DocDirs
    {
        public int Id { get; set; }
        public int? RelAgId { get; set; }
        public int? RelSubId { get; set; }
        public int? RelId { get; set; }
        public string Dir { get; set; }
    }
}
