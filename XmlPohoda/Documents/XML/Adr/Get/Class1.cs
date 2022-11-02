using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Documents.XML.Adr.Get
{
    class Class1
    {

        // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/response.xsd", IsNullable = false)]
        public partial class responsePack
        {

            private responsePackResponsePackItem responsePackItemField;

            private decimal versionField;

            private string idField;

            private string stateField;

            private string programVersionField;

            private byte icoField;

            private string keyField;

            private string noteField;

            /// <remarks/>
            public responsePackResponsePackItem responsePackItem
            {
                get
                {
                    return this.responsePackItemField;
                }
                set
                {
                    this.responsePackItemField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string state
            {
                get
                {
                    return this.stateField;
                }
                set
                {
                    this.stateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string programVersion
            {
                get
                {
                    return this.programVersionField;
                }
                set
                {
                    this.programVersionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ico
            {
                get
                {
                    return this.icoField;
                }
                set
                {
                    this.icoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string note
            {
                get
                {
                    return this.noteField;
                }
                set
                {
                    this.noteField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
        public partial class responsePackResponsePackItem
        {

            private listAddressBook listAddressBookField;

            private decimal versionField;

            private string idField;

            private string stateField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
            public listAddressBook listAddressBook
            {
                get
                {
                    return this.listAddressBookField;
                }
                set
                {
                    this.listAddressBookField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string state
            {
                get
                {
                    return this.stateField;
                }
                set
                {
                    this.stateField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd", IsNullable = false)]
        public partial class listAddressBook
        {

            private listAddressBookAddressbook[] addressbookField;

            private decimal versionField;

            private System.DateTime dateTimeStampField;

            private System.DateTime dateValidFromField;

            private string stateField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("addressbook")]
            public listAddressBookAddressbook[] addressbook
            {
                get
                {
                    return this.addressbookField;
                }
                set
                {
                    this.addressbookField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public System.DateTime dateTimeStamp
            {
                get
                {
                    return this.dateTimeStampField;
                }
                set
                {
                    this.dateTimeStampField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
            public System.DateTime dateValidFrom
            {
                get
                {
                    return this.dateValidFromField;
                }
                set
                {
                    this.dateValidFromField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string state
            {
                get
                {
                    return this.stateField;
                }
                set
                {
                    this.stateField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
        public partial class listAddressBookAddressbook
        {

            private addressbookHeader addressbookHeaderField;

            private addressbookAccountAccountItem[] addressbookAccountField;

            private decimal versionField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
            public addressbookHeader addressbookHeader
            {
                get
                {
                    return this.addressbookHeaderField;
                }
                set
                {
                    this.addressbookHeaderField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
            [System.Xml.Serialization.XmlArrayItemAttribute("accountItem", IsNullable = false)]
            public addressbookAccountAccountItem[] addressbookAccount
            {
                get
                {
                    return this.addressbookAccountField;
                }
                set
                {
                    this.addressbookAccountField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IsNullable = false)]
        public partial class addressbookHeader
        {

            private object[] itemsField;

            private ItemsChoiceType[] itemsElementNameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("accountForInvoicing", typeof(addressbookHeaderAccountForInvoicing))]
            [System.Xml.Serialization.XmlElementAttribute("accountingReceivedInvoice", typeof(addressbookHeaderAccountingReceivedInvoice))]
            [System.Xml.Serialization.XmlElementAttribute("activity", typeof(addressbookHeaderActivity))]
            [System.Xml.Serialization.XmlElementAttribute("adGroup", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("adKey", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("centre", typeof(addressbookHeaderCentre))]
            [System.Xml.Serialization.XmlElementAttribute("classificationVATReceivedInvoice", typeof(addressbookHeaderClassificationVATReceivedInvoice))]
            [System.Xml.Serialization.XmlElementAttribute("email", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("fax", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("id", typeof(ushort))]
            [System.Xml.Serialization.XmlElementAttribute("identity", typeof(addressbookHeaderIdentity))]
            [System.Xml.Serialization.XmlElementAttribute("markRecord", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("mobil", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("note", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("number", typeof(addressbookHeaderNumber))]
            [System.Xml.Serialization.XmlElementAttribute("p1", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("p2", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("p3", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("p4", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("p5", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("p6", typeof(bool))]
            [System.Xml.Serialization.XmlElementAttribute("paymentType", typeof(addressbookHeaderPaymentType))]
            [System.Xml.Serialization.XmlElementAttribute("phone", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("priceIDS", typeof(object))]
            [System.Xml.Serialization.XmlElementAttribute("region", typeof(string))]
            [System.Xml.Serialization.XmlElementAttribute("turnover", typeof(byte))]
            [System.Xml.Serialization.XmlElementAttribute("web", typeof(string))]
            [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
            public object[] Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public ItemsChoiceType[] ItemsElementName
            {
                get
                {
                    return this.itemsElementNameField;
                }
                set
                {
                    this.itemsElementNameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderAccountForInvoicing
        {

            private ushort idField;

            private string idsField;

            private uint accountNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public uint accountNo
            {
                get
                {
                    return this.accountNoField;
                }
                set
                {
                    this.accountNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderAccountingReceivedInvoice
        {

            private ushort idField;

            private string idsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderActivity
        {

            private ushort idField;

            private string idsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderCentre
        {

            private ushort idField;

            private string idsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderClassificationVATReceivedInvoice
        {

            private ushort idField;

            private string idsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderIdentity
        {

            private address addressField;

            private shipToAddress shipToAddressField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public address address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public shipToAddress shipToAddress
            {
                get
                {
                    return this.shipToAddressField;
                }
                set
                {
                    this.shipToAddressField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
        public partial class address
        {

            private string companyField;

            private string divisionField;

            private string nameField;

            private string cityField;

            private string streetField;

            private string zipField;

            private uint icoField;

            private bool icoFieldSpecified;

            private string dicField;

            private addressCountry countryField;

            /// <remarks/>
            public string company
            {
                get
                {
                    return this.companyField;
                }
                set
                {
                    this.companyField = value;
                }
            }

            /// <remarks/>
            public string division
            {
                get
                {
                    return this.divisionField;
                }
                set
                {
                    this.divisionField = value;
                }
            }

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string city
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }

            /// <remarks/>
            public string street
            {
                get
                {
                    return this.streetField;
                }
                set
                {
                    this.streetField = value;
                }
            }

            /// <remarks/>
            public string zip
            {
                get
                {
                    return this.zipField;
                }
                set
                {
                    this.zipField = value;
                }
            }

            /// <remarks/>
            public uint ico
            {
                get
                {
                    return this.icoField;
                }
                set
                {
                    this.icoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool icoSpecified
            {
                get
                {
                    return this.icoFieldSpecified;
                }
                set
                {
                    this.icoFieldSpecified = value;
                }
            }

            /// <remarks/>
            public string dic
            {
                get
                {
                    return this.dicField;
                }
                set
                {
                    this.dicField = value;
                }
            }

            /// <remarks/>
            public addressCountry country
            {
                get
                {
                    return this.countryField;
                }
                set
                {
                    this.countryField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        public partial class addressCountry
        {

            private byte idField;

            private string idsField;

            /// <remarks/>
            public byte id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
        public partial class shipToAddress
        {

            private byte idField;

            private string companyField;

            private string cityField;

            private string streetField;

            private bool defaultShipAddressField;

            private string zipField;

            private shipToAddressCountry countryField;

            /// <remarks/>
            public byte id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public string company
            {
                get
                {
                    return this.companyField;
                }
                set
                {
                    this.companyField = value;
                }
            }

            /// <remarks/>
            public string city
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }

            /// <remarks/>
            public string street
            {
                get
                {
                    return this.streetField;
                }
                set
                {
                    this.streetField = value;
                }
            }

            /// <remarks/>
            public bool defaultShipAddress
            {
                get
                {
                    return this.defaultShipAddressField;
                }
                set
                {
                    this.defaultShipAddressField = value;
                }
            }

            /// <remarks/>
            public string zip
            {
                get
                {
                    return this.zipField;
                }
                set
                {
                    this.zipField = value;
                }
            }

            /// <remarks/>
            public shipToAddressCountry country
            {
                get
                {
                    return this.countryField;
                }
                set
                {
                    this.countryField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        public partial class shipToAddressCountry
        {

            private sbyte idField;

            private object idsField;

            /// <remarks/>
            public sbyte id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public object ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderNumber
        {

            private ushort idField;

            private bool idFieldSpecified;

            private string idsField;

            private string numberRequestedField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool idSpecified
            {
                get
                {
                    return this.idFieldSpecified;
                }
                set
                {
                    this.idFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string numberRequested
            {
                get
                {
                    return this.numberRequestedField;
                }
                set
                {
                    this.numberRequestedField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookHeaderPaymentType
        {

            private ushort idField;

            private string idsField;

            private string paymentTypeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string ids
            {
                get
                {
                    return this.idsField;
                }
                set
                {
                    this.idsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
            public string paymentType
            {
                get
                {
                    return this.paymentTypeField;
                }
                set
                {
                    this.paymentTypeField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IncludeInSchema = false)]
        public enum ItemsChoiceType
        {

            /// <remarks/>
            accountForInvoicing,

            /// <remarks/>
            accountingReceivedInvoice,

            /// <remarks/>
            activity,

            /// <remarks/>
            adGroup,

            /// <remarks/>
            adKey,

            /// <remarks/>
            centre,

            /// <remarks/>
            classificationVATReceivedInvoice,

            /// <remarks/>
            email,

            /// <remarks/>
            fax,

            /// <remarks/>
            id,

            /// <remarks/>
            identity,

            /// <remarks/>
            markRecord,

            /// <remarks/>
            mobil,

            /// <remarks/>
            note,

            /// <remarks/>
            number,

            /// <remarks/>
            p1,

            /// <remarks/>
            p2,

            /// <remarks/>
            p3,

            /// <remarks/>
            p4,

            /// <remarks/>
            p5,

            /// <remarks/>
            p6,

            /// <remarks/>
            paymentType,

            /// <remarks/>
            phone,

            /// <remarks/>
            priceIDS,

            /// <remarks/>
            region,

            /// <remarks/>
            turnover,

            /// <remarks/>
            web,
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public partial class addressbookAccountAccountItem
        {

            private ushort idField;

            private string accountNumberField;

            private object symSpecField;

            private string bankCodeField;

            private bool defaultAccountField;

            /// <remarks/>
            public ushort id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public string accountNumber
            {
                get
                {
                    return this.accountNumberField;
                }
                set
                {
                    this.accountNumberField = value;
                }
            }

            /// <remarks/>
            public object symSpec
            {
                get
                {
                    return this.symSpecField;
                }
                set
                {
                    this.symSpecField = value;
                }
            }

            /// <remarks/>
            public string bankCode
            {
                get
                {
                    return this.bankCodeField;
                }
                set
                {
                    this.bankCodeField = value;
                }
            }

            /// <remarks/>
            public bool defaultAccount
            {
                get
                {
                    return this.defaultAccountField;
                }
                set
                {
                    this.defaultAccountField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IsNullable = false)]
        public partial class addressbookAccount
        {

            private addressbookAccountAccountItem[] accountItemField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("accountItem")]
            public addressbookAccountAccountItem[] accountItem
            {
                get
                {
                    return this.accountItemField;
                }
                set
                {
                    this.accountItemField = value;
                }
            }
        }


    }
}
