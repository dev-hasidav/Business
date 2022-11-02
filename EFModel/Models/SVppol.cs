using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SVppol
    {
        public SVppol()
        {
            SVpref = new HashSet<SVpref>();
        }

        public int Id { get; set; }
        public int? RefAg { get; set; }
        public bool Items { get; set; }
        public string Popis { get; set; }
        public string Nazev { get; set; }
        public int? RelTyp { get; set; }
        public int? Delka { get; set; }
        public string Definice { get; set; }
        public int? RelUl { get; set; }
        public int? OrderFld { get; set; }
        public byte[] Settings { get; set; }
        public bool Write { get; set; }
        public int? RelRow { get; set; }
        public bool Use0 { get; set; }
        public bool Use1 { get; set; }
        public bool Use2 { get; set; }
        public bool Use3 { get; set; }
        public bool Use4 { get; set; }
        public bool Use5 { get; set; }

        public SVp RefAgNavigation { get; set; }
        public ICollection<SVpref> SVpref { get; set; }
    }
}
