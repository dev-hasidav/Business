using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    public partial class AddressBookHeader
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Ids accountForInvoicing { get; set; } = new Ids();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Ids accountingReceivedInvoice { get; set; } = new Ids();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Ids activity { get; set; } = new Ids();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string adGroup { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string adKey { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Ids centre { get; set; } = new Ids();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Ids classificationVATReceivedInvoice { get; set; } = new Ids();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string email { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string fax { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public int id { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Identity identity { get; set; } = new Identity();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool markRecord { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string mobil { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string note { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public Number number { get; set; } = new Number();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool p1 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool p2 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool p3 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool p4 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool p5 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public bool p6 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public PaymentType paymentType { get; set; } = new PaymentType();
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string phone { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public object priceIDS { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string region { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public int turnover { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public string web { get; set; }
    }
}
