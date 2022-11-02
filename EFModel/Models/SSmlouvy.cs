using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SSmlouvy
    {
        public int Id { get; set; }
        public int? RelTyp { get; set; }
        public string Ids { get; set; }
    }
}
