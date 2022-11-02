using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    public partial class InvoiceItem
    {
        /// <remarks/>
        public int id { get; set; }

        /// <remarks/>
        public string text { get; set; }

        /// <remarks/>
        public decimal quantity { get; set; }

        /// <remarks/>
        public string unit { get; set; }

        /// <remarks/>
        public decimal coefficient { get; set; }

        /// <remarks/>
        public bool payVAT { get; set; }

        /// <remarks/>
        public string rateVAT { get; set; }

        /// <remarks/>
        public decimal discountPercentage { get; set; }

        /// <remarks/>
        public HomeCurrency homeCurrency { get; set; }

        /// <remarks/>
        public string note { get; set; }

        /// <remarks/>
        public string code { get; set; }

        /// <remarks/>
        public InvoiceItemStockItem stockItem { get; set; }

        /// <remarks/>
        public ForeignCurrency foreignCurrency { get; set; }

        /// <remarks/>
        public Ids accounting { get; set; }

        /// <remarks/>
        public Ids classificationVAT { get; set; }

        /// <remarks/>
        public bool PDP { get; set; }

        /// <remarks/>
        public Ids centre { get; set; }

        /// <remarks/>
        public Ids activity { get; set; }

        /// <remarks/>
        public Ids contract { get; set; }
    }
}
