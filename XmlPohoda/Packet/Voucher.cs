using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    public partial class Voucher
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
        public VoucherHeader voucherHeader { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
        [System.Xml.Serialization.XmlArrayItemAttribute("voucherItem", IsNullable = false)]
        public List<VoucherItem> voucherDetail { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
        public VoucherSummary voucherSummary { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
        public EET EET { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version { get; set; }
    }
}
