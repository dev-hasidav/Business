using Business.Pohoda.Xml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    [NumClass(62)]
    [Serializable]
    public class exAddressBook : AbsDocument
    {
        public exAddressBook(HeadDataPack Head) : base(Head) { this.HeadPack = Head; }

        /// <summary>
        /// Прочитать одну (Id != 0) или все (Id == 0) записи из таблице
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NumFunction(1)]
        public System.Xml.XmlDocument GetAddressBook(FilterGet Filtr)
        {
            GetAddress(Filtr);
            return this.Xd;
        }

        /// <summary>
        /// Записать новую запись в таблицу
        /// </summary>
        /// <param name="Mod"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public System.Xml.XmlDocument SetAddressBook(List<Packet.Addressbook> Mod)
        {
            int n1 = 0;
            DateTimeOffset dt = DateTimeOffset.Now;
            foreach (var item in Mod)
            {
                //  dat:dataPackItem
                System.Xml.XmlElement dataPackItem = GetDataPackItem(dt, ref n1);

                System.Xml.XmlElement addressbook = this.Xd.CreateElement("adb:addressbook", this.Scopes["adb"]);
                dataPackItem.AppendChild(addressbook);
                System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
                xa.Value = "2.0";
                addressbook.Attributes.Append(xa);

                SetAddress(addressbook, item, true);
            }
            return this.Xd;
        }

        /// <summary>
        /// Обновить запись в таблице
        /// </summary>
        /// <param name="Id">Id обновляемой записи</param>
        /// <param name="Mod">Обновляемые поля</param>
        /// <returns></returns>
        [NumFunction(3)]
        public System.Xml.XmlDocument UpdateAddressBook(List<Packet.Addressbook> Mod)
        {
            int n1 = 0;
            DateTimeOffset dt = DateTimeOffset.Now;
            foreach (var item in Mod)
            {
                //  dat:dataPackItem
                System.Xml.XmlElement dataPackItem = GetDataPackItem(dt, ref n1);

                System.Xml.XmlElement addressbook = this.Xd.CreateElement("adb:addressbook", this.Scopes["adb"]);
                dataPackItem.AppendChild(addressbook);
                System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
                xa.Value = "2.0";
                addressbook.Attributes.Append(xa);

                UpdateAddress(addressbook, item.addressbookHeader.id, EnumActionType.update);
                SetAddress(addressbook, item, false);
            }
            return this.Xd;
        }

        /// <summary>
        /// Удалить запись из таблицы
        /// </summary>
        /// <param name="Id">Id удаляемой записи</param>
        /// <returns></returns>
        [NumFunction(4)]
        public System.Xml.XmlDocument DeleteAddressBook(List<Packet.Addressbook> Mod)
        {
            int n1 = 0;
            DateTimeOffset dt = DateTimeOffset.Now;
            foreach (var item in Mod)
            {
                //  dat:dataPackItem
                System.Xml.XmlElement dataPackItem = GetDataPackItem(dt, ref n1);

                System.Xml.XmlElement addressbook = this.Xd.CreateElement("adb:addressbook", this.Scopes["adb"]);
                dataPackItem.AppendChild(addressbook);
                System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
                xa.Value = "2.0";
                addressbook.Attributes.Append(xa);

                UpdateAddress(addressbook, item.addressbookHeader.id, EnumActionType.delete);
            }
            return this.Xd;
        }

        [NumFunction(11)]
        protected override void SetHead(HeadDataPack Head)
        {
            this.Scopes = new Dictionary<string, string>
            {
                { "dat", "http://www.stormware.cz/schema/version_2/data.xsd" },
                { "typ", "http://www.stormware.cz/schema/version_2/type.xsd" },
                { "lst", "http://www.stormware.cz/schema/version_2/list.xsd" },
                { "ftr", "http://www.stormware.cz/schema/version_2/filter.xsd" },
                { "adb", "http://www.stormware.cz/schema/version_2/addressbook.xsd" },
                { "lAdb", "http://www.stormware.cz/schema/version_2/list_addBook.xsd" }
            };
            base.SetHead(Head);
        }

        /// <summary>
        /// Получить запись(и) согласно фильтру. Если фильтр(ы) не указанны - ВСЕ записи
        /// </summary>
        /// <param name="Filtr"></param>
        [NumFunction(12)]
        private void GetAddress(FilterGet Filtr)
        {
            int n1 = 0;
            DateTimeOffset dt = DateTimeOffset.Now;
            System.Xml.XmlElement dataPackItem = GetDataPackItem(dt, ref n1);

            System.Xml.XmlElement listAddressBookRequest = this.Xd.CreateElement("lAdb:listAddressBookRequest", this.Scopes["lAdb"]);
            dataPackItem.AppendChild(listAddressBookRequest);

            System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
            xa.Value = "2.0";
            listAddressBookRequest.Attributes.Append(xa);

            xa = this.Xd.CreateAttribute("addressBookVersion");
            xa.Value = "2.0";
            listAddressBookRequest.Attributes.Append(xa);

            //  addressbookHeader
            System.Xml.XmlElement requestAddressBook = this.Xd.CreateElement("lAdb:requestAddressBook", this.Scopes["lAdb"]);
            listAddressBookRequest.AppendChild(requestAddressBook);

            //  если надо конкретная информация 
            if (Filtr.Id != 0)
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestAddressBook.AppendChild(filter);
                System.Xml.XmlElement id = this.Xd.CreateElement("ftr:id", this.Scopes["ftr"]);
                filter.AppendChild(id);
                System.Xml.XmlText xt_id = this.Xd.CreateTextNode(Filtr.Id.ToString());
                id.AppendChild(xt_id);
            }
            else if (!string.IsNullOrWhiteSpace(Filtr.Ids))
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestAddressBook.AppendChild(filter);
                System.Xml.XmlElement number = this.Xd.CreateElement("ftr:number", this.Scopes["ftr"]);
                filter.AppendChild(number);
                System.Xml.XmlText xt_number = this.Xd.CreateTextNode(Filtr.Ids);
                number.AppendChild(xt_number);
            }
            else if (!string.IsNullOrWhiteSpace(Filtr.Ico))
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestAddressBook.AppendChild(filter);
                System.Xml.XmlElement ico = this.Xd.CreateElement("ftr:ico", this.Scopes["ftr"]);
                filter.AppendChild(ico);
                System.Xml.XmlText xt_ico = this.Xd.CreateTextNode(Filtr.Ico);
                ico.AppendChild(xt_ico);
            }
            else if (!string.IsNullOrWhiteSpace(Filtr.Company))
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestAddressBook.AppendChild(filter);
                System.Xml.XmlElement company = this.Xd.CreateElement("ftr:company", this.Scopes["ftr"]);
                filter.AppendChild(company);
                System.Xml.XmlText xt_Company = this.Xd.CreateTextNode(Filtr.Company);
                company.AppendChild(xt_Company);
            }
            else
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestAddressBook.AppendChild(filter);
            }
        }

        [NumFunction(13)]
        private void SetAddress(System.Xml.XmlElement addressbook, Packet.Addressbook Part, bool IsNew)
        {
            //  addressbookHeader
            System.Xml.XmlElement addressbookHeader = this.Xd.CreateElement("adb:addressbookHeader", this.Scopes["adb"]);
            addressbook.AppendChild(addressbookHeader);

            System.Xml.XmlElement identity = this.Xd.CreateElement("adb:identity", this.Scopes["adb"]);
            addressbookHeader.AppendChild(identity);

            System.Xml.XmlElement address = this.Xd.CreateElement("typ:address", this.Scopes["typ"]);
            identity.AppendChild(address);

            System.Xml.XmlElement company = this.Xd.CreateElement("typ:company", this.Scopes["typ"]);
            address.AppendChild(company);
            System.Xml.XmlText xt_company = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.company);
            company.AppendChild(xt_company);

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.name))
            {
                System.Xml.XmlElement name = this.Xd.CreateElement("typ:name", this.Scopes["typ"]);
                address.AppendChild(name);
                System.Xml.XmlText xt_name = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.name);
                name.AppendChild(xt_name);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.street))
            {
                System.Xml.XmlElement street = this.Xd.CreateElement("typ:street", this.Scopes["typ"]);
                address.AppendChild(street);
                System.Xml.XmlText xt_street = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.street);
                street.AppendChild(xt_street);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.zip))
            {
                System.Xml.XmlElement zip = this.Xd.CreateElement("typ:zip", this.Scopes["typ"]);
                address.AppendChild(zip);
                System.Xml.XmlText xt_zip = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.zip);
                zip.AppendChild(xt_zip);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.ico))
            {
                System.Xml.XmlElement ico = this.Xd.CreateElement("typ:ico", this.Scopes["typ"]);
                address.AppendChild(ico);
                System.Xml.XmlText xt_ico = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.ico);
                ico.AppendChild(xt_ico);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.dic))
            {
                System.Xml.XmlElement dic = this.Xd.CreateElement("typ:dic", this.Scopes["typ"]);
                address.AppendChild(dic);
                System.Xml.XmlText xt_dic = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.dic);
                dic.AppendChild(xt_dic);
            }

            //if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.city))
            //{
            System.Xml.XmlElement city = this.Xd.CreateElement("typ:city", this.Scopes["typ"]);
            address.AppendChild(city);
            System.Xml.XmlText xt_city = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.city);
            city.AppendChild(xt_city);
            //}

            if (Part.addressbookHeader.identity.address.country.id != 0)
            {
                System.Xml.XmlElement country = this.Xd.CreateElement("typ:country", this.Scopes["typ"]);
                address.AppendChild(country);
                System.Xml.XmlElement ids = this.Xd.CreateElement("typ:id", this.Scopes["typ"]);
                country.AppendChild(ids);
                System.Xml.XmlText xt_ids = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.country.id.ToString());
                ids.AppendChild(xt_ids);
            }
            else if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.identity.address.country.ids))
            {
                System.Xml.XmlElement country = this.Xd.CreateElement("typ:country", this.Scopes["typ"]);
                address.AppendChild(country);
                System.Xml.XmlElement ids = this.Xd.CreateElement("typ:ids", this.Scopes["typ"]);
                country.AppendChild(ids);
                System.Xml.XmlText xt_ids = this.Xd.CreateTextNode(Part.addressbookHeader.identity.address.country.ids);
                ids.AppendChild(xt_ids);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.phone))
            {
                System.Xml.XmlElement phone = this.Xd.CreateElement("adb:phone", this.Scopes["adb"]);
                addressbookHeader.AppendChild(phone);
                System.Xml.XmlText xt_phone = this.Xd.CreateTextNode(Part.addressbookHeader.phone);
                phone.AppendChild(xt_phone);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.mobil))
            {
                System.Xml.XmlElement mobil = this.Xd.CreateElement("adb:mobil", this.Scopes["adb"]);
                addressbookHeader.AppendChild(mobil);
                System.Xml.XmlText xt_mobil = this.Xd.CreateTextNode(Part.addressbookHeader.mobil);
                mobil.AppendChild(xt_mobil);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.email))
            {
                System.Xml.XmlElement email = this.Xd.CreateElement("adb:email", this.Scopes["adb"]);
                addressbookHeader.AppendChild(email);
                System.Xml.XmlText xt_email = this.Xd.CreateTextNode(Part.addressbookHeader.email);
                email.AppendChild(xt_email);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.web))
            {
                System.Xml.XmlElement web = this.Xd.CreateElement("adb:web", this.Scopes["adb"]);
                addressbookHeader.AppendChild(web);
                System.Xml.XmlText xt_web = this.Xd.CreateTextNode(Part.addressbookHeader.web);
                web.AppendChild(xt_web);
            }

            if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.note))
            {
                System.Xml.XmlElement note = this.Xd.CreateElement("adb:note", this.Scopes["adb"]);
                addressbookHeader.AppendChild(note);
                System.Xml.XmlText xt_note = this.Xd.CreateTextNode(Part.addressbookHeader.note);
                note.AppendChild(xt_note);
            }

            if(Part.addressbookAccount.Count != 0)
            {
                System.Xml.XmlElement addressbookAccount = null;
                System.Xml.XmlElement accountItem = null;
                System.Xml.XmlElement defaultAccount = null;
                if (!string.IsNullOrWhiteSpace(Part.addressbookAccount[0].accountNumber))
                {
                    addressbookAccount = this.Xd.CreateElement("adb:addressbookAccount", this.Scopes["adb"]);
                    addressbook.AppendChild(addressbookAccount);
                    accountItem = this.Xd.CreateElement("typ:accountItem", this.Scopes["adb"]);
                    addressbookAccount.AppendChild(accountItem);
                    System.Xml.XmlElement accountNumber = this.Xd.CreateElement("adb:accountNumber", this.Scopes["adb"]);
                    accountItem.AppendChild(accountNumber);
                    System.Xml.XmlText xt_accountNumber = this.Xd.CreateTextNode(Part.addressbookAccount[0].accountNumber);
                    accountNumber.AppendChild(xt_accountNumber);
                    defaultAccount = this.Xd.CreateElement("adb:defaultAccount", this.Scopes["adb"]);
                    accountItem.AppendChild(defaultAccount);
                    System.Xml.XmlText xt_defaultAccount = this.Xd.CreateTextNode("true");
                    defaultAccount.AppendChild(xt_defaultAccount);
                }
                if(!string.IsNullOrWhiteSpace(Part.addressbookAccount[0].bankCode))
                {
                    if (addressbookAccount == null)
                    {
                        addressbookAccount = this.Xd.CreateElement("adb:addressbookAccount", this.Scopes["adb"]);
                        addressbook.AppendChild(addressbookAccount);
                        accountItem = this.Xd.CreateElement("typ:accountItem", this.Scopes["adb"]);
                        addressbookAccount.AppendChild(accountItem);
                    }
                    System.Xml.XmlElement bankCode = this.Xd.CreateElement("adb:bankCode", this.Scopes["adb"]);
                    accountItem.AppendChild(bankCode);
                    System.Xml.XmlText xt_bankCode = this.Xd.CreateTextNode(Part.addressbookAccount[0].bankCode);
                    bankCode.AppendChild(xt_bankCode);
                    if (defaultAccount == null)
                    {
                        defaultAccount = this.Xd.CreateElement("adb:defaultAccount", this.Scopes["adb"]);
                        accountItem.AppendChild(defaultAccount);
                        System.Xml.XmlText xt_defaultAccount = this.Xd.CreateTextNode("true");
                        defaultAccount.AppendChild(xt_defaultAccount);
                    }
                }
            }

            if (IsNew)
            {
                if (!string.IsNullOrWhiteSpace(Part.addressbookHeader.number.numberRequested))
                {
                    System.Xml.XmlElement number = this.Xd.CreateElement("adb:number", this.Scopes["adb"]);
                    addressbookHeader.AppendChild(number);
                    System.Xml.XmlElement numberRequested = this.Xd.CreateElement("typ:numberRequested", this.Scopes["typ"]);
                    number.AppendChild(numberRequested);
                    System.Xml.XmlText xt_numberRequested = this.Xd.CreateTextNode(Part.addressbookHeader.number.numberRequested);
                    numberRequested.AppendChild(xt_numberRequested);
                }
            }

        }

        [NumFunction(14)]
        private void UpdateAddress(System.Xml.XmlElement addressbook, int Id, EnumActionType Act)
        {

            //  addressbookHeader
            System.Xml.XmlElement actionType = this.Xd.CreateElement("adb:actionType", this.Scopes["adb"]);
            addressbook.AppendChild(actionType);

            System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
            if (Act == EnumActionType.update)
            {
                System.Xml.XmlElement update = this.Xd.CreateElement("adb:update", this.Scopes["adb"]);
                actionType.AppendChild(update);
                update.AppendChild(filter);
           }
            else if(Act== EnumActionType.delete)
            {
                System.Xml.XmlElement delete = this.Xd.CreateElement("adb:delete", this.Scopes["adb"]);
                actionType.AppendChild(delete);
                delete.AppendChild(filter);
            }

            System.Xml.XmlElement id = this.Xd.CreateElement("ftr:id", this.Scopes["ftr"]);
            filter.AppendChild(id);
            System.Xml.XmlText xt_id = this.Xd.CreateTextNode(Id.ToString());
            id.AppendChild(xt_id);
        }

        [NumFunction(14)]
        private System.Xml.XmlElement GetDataPackItem(DateTimeOffset dt, ref int n1)
        {
            //  dat:dataPackItem
            System.Xml.XmlElement dataPackItem = this.Xd.CreateElement("dat:dataPackItem", Scopes["dat"]);
            dataPack.AppendChild(dataPackItem);

            System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
            xa.Value = this.HeadPack.VersionProc;
            dataPackItem.Attributes.Append(xa);

            xa = this.Xd.CreateAttribute("id");
            xa.Value = string.Format("ad-{1}-{0}", n1++, dt.ToString("yyMMddHHmmss"));
            dataPackItem.Attributes.Append(xa);

            return dataPackItem;
        }
    }
}
