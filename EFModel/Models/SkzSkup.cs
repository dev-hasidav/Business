﻿using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzSkup
    {
        public SkzSkup()
        {
            SkzSkupPol = new HashSet<SkzSkupPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Kod { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool Internet { get; set; }
        public string Obrazek { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public int NullCheckKod { get; set; }

        public ICollection<SkzSkupPol> SkzSkupPol { get; set; }
    }
}
