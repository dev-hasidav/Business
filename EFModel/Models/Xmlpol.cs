using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Xmlpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Ids { get; set; }
        public bool Stav { get; set; }
        public int? RelAgId { get; set; }
        public int? RelTyp { get; set; }
        public int? RelId { get; set; }
        public string Pozn { get; set; }

        public Xml RefAgNavigation { get; set; }
    }
}
