using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd", IsNullable = false)]
    public partial class ContractDesc
    {
        /// <remarks/>
        public int id { get; set; }

        /// <remarks/>
        public Number number { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime? datePlanStart { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime? datePlanDelivery { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime? dateWarranty { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool datePlanStartSpecified { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime? dateStart { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateStartSpecified { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime? dateDelivery { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateDeliverySpecified { get; set; }

        /// <remarks/>
        public string text { get; set; }

        /// <remarks/>
        public PartnerIdentity partnerIdentity { get; set; }

        /// <remarks/>
        public ResponsiblePerson responsiblePerson { get; set; }

        /// <remarks/>
        public EnumContractState contractState { get; set; }

        /// <remarks/>
        public string ost1 { get; set; }

        /// <remarks/>
        public string ost2 { get; set; }

        /// <remarks/>
        public string note { get; set; }

        /// <remarks/>
        public bool markRecord { get; set; }
    }
}
