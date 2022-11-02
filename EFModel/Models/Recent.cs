using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Recent
    {
        public int Id { get; set; }
        public int? AgId { get; set; }
        public int? RelSubId { get; set; }
        public string Ucetni { get; set; }
        public int? RefId { get; set; }
    }
}
