using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    public partial class InvoiceHeader
    {
        public Ids account { set; get; }

        public Ids accounting { set; get; }

        public Ids activity { set; get; }

        public Ids centre { set; get; }

        public Ids classificationVAT { set; get; }

        public Ids contract { set; get; }

        public System.DateTime date { set; get; }

        public System.DateTime dateAccounting { set; get; }

        public System.DateTime dateDue { set; get; }

        public System.DateTime dateOrder { set; get; }

        public System.DateTime dateTax { set; get; }

        public ExtId extId { set; get; }

        public int id { set; get; }

        public string intNote { set; get; }

        public string invoiceType { set; get; }

        public Liquidation liquidation { set; get; }

        public bool markRecord { set; get; }

        public MyIdentity myIdentity { set; get; }

        public string note { set; get; }

        public Ids number { set; get; }

        public string numberOrder { set; get; }

        public PartnerIdentity partnerIdentity { set; get; }

        public PaymentType paymentType { set; get; }

        public string storno { set; get; }

        public string symConst { set; get; }

        public string symPar { set; get; }

        public string symVar { set; get; }

        public string text { set; get; }
    }
}
