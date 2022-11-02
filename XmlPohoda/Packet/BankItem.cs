using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    public partial class BankItem
    {
        /// <remarks/>
        public string text { get; set; }

        /// <remarks/>
        public BankHomeCurrency homeCurrency { get; set; }

        /// <remarks/>
        public ForeignCurrency foreignCurrency { get; set; }

        /// <remarks/>
        public string symPar { get; set; }

        /// <remarks/>
        public Ids accounting { get; set; }
    }
}
