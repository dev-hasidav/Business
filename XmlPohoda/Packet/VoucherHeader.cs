using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    public partial class VoucherHeader
    {
        public Ids accounting { get; set; }

        public Ids activity { get; set; }

        public Ids cashAccount { get; set; }

        public Ids centre { get; set; }

        public Ids classificationVAT { get; set; }

        public Ids contract { get; set; }

        public System.DateTime date { get; set; }

        public System.DateTime datePayment { get; set; }

        public System.DateTime dateTax { get; set; }

        public int id { get; set; }

        public bool markRecord { get; set; }

        public MyIdentity myIdentity { get; set; }

        public Number number { get; set; }

        public string originalDocument { get; set; }

        public PartnerIdentity partnerIdentity { get; set; }

        public string symPar { get; set; }

        public string text { get; set; }

        public string voucherType { get; set; }
    }
}
