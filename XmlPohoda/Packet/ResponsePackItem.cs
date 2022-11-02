using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
    public partial class ResponsePackItem
    {
        [System.Xml.Serialization.XmlElementAttribute("listAddressBook", typeof(ListAddressBook), Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("addressbookResponse", typeof(AddressbookResponse), Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("listContract", typeof(ListContract), Namespace = "http://www.stormware.cz/schema/version_2/list_contract.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("contractResponse", typeof(ContractResponse), Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("listBank", typeof(listBank), Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("listVoucher", typeof(ListVoucher), Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("voucherResponse", typeof(VoucherResponse), Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("listInvoice", typeof(ListInvoice), Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("invoiceResponse", typeof(InvoiceResponse), Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
        [System.Xml.Serialization.XmlElementAttribute("printResponse", typeof(PrintResponse), Namespace = "http://www.stormware.cz/schema/version_2/print.xsd")]
        public List<object> Items { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public enumState state { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string note { get; set; }

    }
}
