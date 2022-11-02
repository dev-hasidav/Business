using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd", IsNullable = false)]
    public partial class BankSummary
    {
        /// <remarks/>
        public string roundingDocument { get; set; }

        /// <remarks/>
        public string roundingVAT { get; set; }

        /// <remarks/>
        public SummaryHomeCurrency homeCurrency { get; set; }
    }
}
