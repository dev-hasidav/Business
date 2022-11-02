using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    public partial class Invoice
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
        public InvoiceHeader invoiceHeader { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
        [System.Xml.Serialization.XmlArrayItemAttribute("invoiceItem", IsNullable = false)]
        public List<InvoiceItem> invoiceDetail { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
        public InvoiceSummary invoiceSummary { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
        public EET EET { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version { get; set; }
    }
}
