using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SExtId
    {
        public SExtId()
        {
            SExtIdpol = new HashSet<SExtIdpol>();
        }

        public int Id { get; set; }
        public int? RefDocId { get; set; }
        public int? RelAgId { get; set; }
        public string Ids { get; set; }
        public int? RefExtSys { get; set; }
        public int? RelZmena { get; set; }

        public ICollection<SExtIdpol> SExtIdpol { get; set; }
    }
}
