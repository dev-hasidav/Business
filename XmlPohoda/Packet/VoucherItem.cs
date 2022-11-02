using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    public partial class VoucherItem
    {
        /// <remarks/>
        public string text { get; set; }

        /// <remarks/>
        public decimal quantity { get; set; }

        /// <remarks/>
        public decimal coefficient { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool coefficientSpecified { get; set; }

        /// <remarks/>
        public bool payVAT { get; set; }

        /// <remarks/>
        public string rateVAT { get; set; }

        /// <remarks/>
        public decimal discountPercentage { get; set; }

        /// <remarks/>
        public HomeCurrency homeCurrency { get; set; }

        /// <remarks/>
        public string symPar { get; set; }

        /// <remarks/>
        public string note { get; set; }

        /// <remarks/>
        public Ids accounting { get; set; }

        /// <remarks/>
        public Ids classificationVAT { get; set; }

        /// <remarks/>
        public Ids contract { get; set; }
    }
}
