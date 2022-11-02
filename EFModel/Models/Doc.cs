using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Doc
    {
        public int Id { get; set; }
        public int? RelDocType { get; set; }
        public int? RelAgId { get; set; }
        public int? RelSubId { get; set; }
        public int? RelId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string RefElArchivId { get; set; }
        public string Url { get; set; }
        public DateTime? Datum { get; set; }
    }
}
