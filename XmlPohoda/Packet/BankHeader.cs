using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd", IsNullable = false)]
    public partial class bankHeader
    {
        /// <remarks/>
        public int id { get; set; }

        /// <remarks/>
        public string bankType { get; set; }

        /// <remarks/>
        public Ids account { get; set; }

        /// <remarks/>
        public string number { get; set; }

        /// <remarks/>
        public StatementNumber statementNumber { get; set; }

        /// <remarks/>
        public string symVar { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool symVarSpecified { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime dateStatement { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime datePayment { get; set; }

        /// <remarks/>
        public Ids accounting { get; set; }

        /// <remarks/>
        public string text { get; set; }

        /// <remarks/>
        public PartnerIdentity partnerIdentity { get; set; }

        /// <remarks/>
        public MyIdentity myIdentity { get; set; }

        /// <remarks/>
        public PaymentAccount paymentAccount { get; set; }

        /// <remarks/>
        public int symConst { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool symConstSpecified { get; set; }

        /// <remarks/>
        public string symSpec { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool symSpecSpecified { get; set; }

        /// <remarks/>
        public Ids centre { get; set; }

        /// <remarks/>
        public Ids activity { get; set; }

        /// <remarks/>
        public Ids contract { get; set; }

        /// <remarks/>
        public string symPar { get; set; }
    }
}
