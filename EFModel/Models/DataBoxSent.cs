using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class DataBoxSent
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelAgId { get; set; }
        public int? RefId { get; set; }
        public string SenderId { get; set; }
        public string DataBoxId { get; set; }
        public string MsgNote { get; set; }
        public string MsgId { get; set; }
        public string Attachments { get; set; }
        public int? LegTitleLaw { get; set; }
        public int? LegTitleYear { get; set; }
        public string LegTitleSect { get; set; }
        public string LegTitlePar { get; set; }
        public string LegTitlePoint { get; set; }
        public string RecipRefNo { get; set; }
        public string RecipIdent { get; set; }
        public string SenderRefNo { get; set; }
        public string SenderIdent { get; set; }
        public string ToHands { get; set; }
        public bool Personal { get; set; }
        public string StatusInfo { get; set; }
        public DateTime? StatusDate { get; set; }
        public int? StatusIsds { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool Imported { get; set; }
        public bool Official { get; set; }
        public byte[] Dorucenka { get; set; }
        public bool JeDorucenka { get; set; }
        public DateTime? Datum { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
