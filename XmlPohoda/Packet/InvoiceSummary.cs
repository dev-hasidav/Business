using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    public partial class InvoiceSummary
    {
        /// <remarks/>
        public string roundingDocument { get; set; }

        /// <remarks/>
        public string roundingVAT { get; set; }

        /// <remarks/>
        public bool calculateVAT { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool calculateVATSpecified { get; set; }

        /// <remarks/>
        public string typeCalculateVATInclusivePrice { get; set; }

        /// <remarks/>
        public SummaryHomeCurrency homeCurrency { get; set; }
    }
}
