﻿using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SStr
    {
        public SStr()
        {
            Djridic = new HashSet<Djridic>();
            Zam = new HashSet<Zam>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? RefProvozovna { get; set; }
        public int? RefPzdJ { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<Djridic> Djridic { get; set; }
        public ICollection<Zam> Zam { get; set; }
    }
}
