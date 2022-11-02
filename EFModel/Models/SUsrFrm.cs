using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SUsrFrm
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelSubId { get; set; }
        public byte[] Settings { get; set; }
    }
}
