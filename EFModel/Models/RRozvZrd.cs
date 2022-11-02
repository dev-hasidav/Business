﻿using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RRozvZrd
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? OrderFld { get; set; }
        public string Sucet { get; set; }
        public bool Minus { get; set; }
        public int? Radek { get; set; }
        public int? Sloupec { get; set; }
    }
}
