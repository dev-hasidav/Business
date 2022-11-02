using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    [NumClass(61)]
    [Serializable]
    public class exZakazka : AbsDocument
    {
        public exZakazka(Models.HeadDataPack Head) : base(Head) { }

        /// <summary>
        /// Прочитать одну (Id != 0) или все (Id == 0) записи из таблице
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NumFunction(1)]
        public System.Xml.XmlDocument GetZakazka(FilterGet Filtr)
        {
            _GetZakazka(Filtr);
            return this.Xd;
        }

        /// <summary>
        /// Записать новую запись в таблицу
        /// </summary>
        /// <param name="Mod"></param>
        /// <returns></returns>
        [NumFunction(2)]
        public System.Xml.XmlDocument SetZakazka(Packet.Contract Mod)
        {
            System.Xml.XmlElement contract = this.Xd.CreateElement("con:contract", this.Scopes["con"]);

            this.dataPack.AppendChild(contract);

            System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
            xa.Value = "2.0";
            contract.Attributes.Append(xa);

            _SetZakazka(contract, Mod, true);

            return this.Xd;
        }

        [NumFunction(3)]
        protected override void SetHead(Models.HeadDataPack Head)
        {
            this.Scopes = new Dictionary<string, string>
            {
                { "dat", "http://www.stormware.cz/schema/version_2/data.xsd" },
                { "typ", "http://www.stormware.cz/schema/version_2/type.xsd" },
                { "ftr", "http://www.stormware.cz/schema/version_2/filter.xsd" },
                { "con", "http://www.stormware.cz/schema/version_2/contract.xsd" },
                { "lCon", "http://www.stormware.cz/schema/version_2/list_contract.xsd" }
            };
            base.SetHead(Head);
        }

        [NumFunction(4)]
        private void _GetZakazka(FilterGet Filtr)
        {
            System.Xml.XmlElement listContractRequest = this.Xd.CreateElement("lCon:listContractRequest", this.Scopes["lCon"]);

            this.dataPack.AppendChild(listContractRequest);

            System.Xml.XmlAttribute xa = this.Xd.CreateAttribute("version");
            xa.Value = "2.0";
            listContractRequest.Attributes.Append(xa);

            xa = this.Xd.CreateAttribute("contractVersion");
            xa.Value = "2.0";
            listContractRequest.Attributes.Append(xa);

            //  requestContract
            System.Xml.XmlElement requestContract = this.Xd.CreateElement("lCon:requestContract", this.Scopes["lCon"]);
            listContractRequest.AppendChild(requestContract);

            //  если надо конкретная информация 
            if (Filtr.Id != 0)
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestContract.AppendChild(filter);
                System.Xml.XmlElement id = this.Xd.CreateElement("ftr:id", this.Scopes["ftr"]);
                filter.AppendChild(id);
                System.Xml.XmlText xt_id = this.Xd.CreateTextNode(Filtr.Id.ToString());
                id.AppendChild(xt_id);
            }
            else if (!string.IsNullOrWhiteSpace(Filtr.Ids))
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestContract.AppendChild(filter);
                System.Xml.XmlElement number = this.Xd.CreateElement("ftr:number", this.Scopes["ftr"]);
                filter.AppendChild(number);
                System.Xml.XmlText xt_number = this.Xd.CreateTextNode(Filtr.Ids);
                number.AppendChild(xt_number);
            }
            else if (!string.IsNullOrWhiteSpace(Filtr.Ico))
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestContract.AppendChild(filter);
                System.Xml.XmlElement ico = this.Xd.CreateElement("ftr:ico", this.Scopes["ftr"]);
                filter.AppendChild(ico);
                System.Xml.XmlText xt_ico = this.Xd.CreateTextNode(Filtr.Ico);
                ico.AppendChild(xt_ico);
            }
            else if (!string.IsNullOrWhiteSpace(Filtr.Company))
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestContract.AppendChild(filter);
                System.Xml.XmlElement company = this.Xd.CreateElement("ftr:company", this.Scopes["ftr"]);
                filter.AppendChild(company);
                System.Xml.XmlText xt_Company = this.Xd.CreateTextNode(Filtr.Company);
                company.AppendChild(xt_Company);
            }
            else
            {
                System.Xml.XmlElement filter = this.Xd.CreateElement("ftr:filter", this.Scopes["ftr"]);
                requestContract.AppendChild(filter);
            }
        }

        [NumFunction(5)]
        private void _SetZakazka(System.Xml.XmlElement contract, Packet.Contract Part, bool IsNew)
        {
            System.Xml.XmlElement el_contractDesc = this.Xd.CreateElement("con:contractDesc", Scopes["con"]);
            contract.AppendChild(el_contractDesc);

            //  Cislo
            if (!string.IsNullOrWhiteSpace(Part.contractDesc.number.ids))
            {
                System.Xml.XmlElement el_number = this.Xd.CreateElement("con:number", Scopes["con"]);
                el_contractDesc.AppendChild(el_number);
                System.Xml.XmlElement el_cislo_ids = this.Xd.CreateElement("typ:ids", Scopes["typ"]);
                el_number.AppendChild(el_cislo_ids);
                System.Xml.XmlText xt_cislo_ids = this.Xd.CreateTextNode(Part.contractDesc.number.ids);
                el_cislo_ids.AppendChild(xt_cislo_ids);
            }

            // datePlanStart
            if (Part.contractDesc.datePlanStart != null)
            {
                System.Xml.XmlElement el_datePlanStart = this.Xd.CreateElement("con:datePlanStart", Scopes["con"]);
                el_contractDesc.AppendChild(el_datePlanStart);
                System.Xml.XmlText xt_datePlanStart = this.Xd.CreateTextNode(Part.contractDesc.datePlanStart.Value.ToString(MyFormating.DateFormat));
                el_datePlanStart.AppendChild(xt_datePlanStart);
            }

            // datePlanDelivery
            if (Part.contractDesc.datePlanDelivery != null)
            {
                System.Xml.XmlElement eldatePlanDelivery = this.Xd.CreateElement("con:datePlanDelivery", Scopes["con"]);
                el_contractDesc.AppendChild(eldatePlanDelivery);
                System.Xml.XmlText xt_datePlanDelivery = this.Xd.CreateTextNode(Part.contractDesc.datePlanDelivery.Value.ToString(MyFormating.DateFormat));
                eldatePlanDelivery.AppendChild(xt_datePlanDelivery);
            }

            // dateStart
            if (Part.contractDesc.dateStart != null)
            {
                System.Xml.XmlElement el_dateStart = this.Xd.CreateElement("con:dateStart", Scopes["con"]);
                el_contractDesc.AppendChild(el_dateStart);
                System.Xml.XmlText xt_dateStart = this.Xd.CreateTextNode(Part.contractDesc.dateStart.Value.ToString(MyFormating.DateFormat));
                el_dateStart.AppendChild(xt_dateStart);
            }

            // dateDelivery
            if (Part.contractDesc.dateDelivery != null)
            {
                System.Xml.XmlElement el_dateDelivery = this.Xd.CreateElement("con:dateDelivery", Scopes["con"]);
                el_contractDesc.AppendChild(el_dateDelivery);
                System.Xml.XmlText xt_dateDelivery = this.Xd.CreateTextNode(Part.contractDesc.dateDelivery.Value.ToString(MyFormating.DateFormat));
                el_dateDelivery.AppendChild(xt_dateDelivery);
            }

            // dateWarranty
            if (Part.contractDesc.dateWarranty != null)
            {
                System.Xml.XmlElement el_dateWarranty = this.Xd.CreateElement("con:dateWarranty", Scopes["con"]);
                el_contractDesc.AppendChild(el_dateWarranty);
                System.Xml.XmlText xt_dateWarranty = this.Xd.CreateTextNode(Part.contractDesc.dateWarranty.Value.ToString(MyFormating.DateFormat));
                el_dateWarranty.AppendChild(xt_dateWarranty);
            }

            if (Part.contractDesc.partnerIdentity != null)
            {
                // Adresar ID. Если id=0 то имя компании, город, улица
                if (Part.contractDesc.partnerIdentity.id != 0)
                {
                    System.Xml.XmlElement el_partnerIdentity = this.Xd.CreateElement("con:partnerIdentity", Scopes["con"]);
                    el_contractDesc.AppendChild(el_partnerIdentity);
                    System.Xml.XmlElement el_id_Firma = this.Xd.CreateElement("typ:id", Scopes["typ"]);
                    el_partnerIdentity.AppendChild(el_id_Firma);
                    System.Xml.XmlText xt_id_Firma = this.Xd.CreateTextNode(Part.contractDesc.partnerIdentity.id.ToString());
                    el_id_Firma.AppendChild(xt_id_Firma);
                }
                else if (Part.contractDesc.partnerIdentity.address != null)
                {
                    System.Xml.XmlElement el_partnerIdentity = this.Xd.CreateElement("con:partnerIdentity", Scopes["con"]);
                    el_contractDesc.AppendChild(el_partnerIdentity);
                    System.Xml.XmlElement el_address = this.Xd.CreateElement("typ:address", Scopes["typ"]);
                    el_partnerIdentity.AppendChild(el_address);
                    if (!string.IsNullOrWhiteSpace(Part.contractDesc.partnerIdentity.address.company))
                    {
                        System.Xml.XmlElement el_company = this.Xd.CreateElement("typ:company", Scopes["typ"]);
                        el_address.AppendChild(el_company);
                        System.Xml.XmlText xt_company = this.Xd.CreateTextNode(Part.contractDesc.partnerIdentity.address.company);
                        el_company.AppendChild(xt_company);
                    }
                    if (!string.IsNullOrWhiteSpace(Part.contractDesc.partnerIdentity.address.city))
                    {

                        System.Xml.XmlElement el_city = this.Xd.CreateElement("typ:city", Scopes["typ"]);
                        el_address.AppendChild(el_city);
                        System.Xml.XmlText xt_city = this.Xd.CreateTextNode(Part.contractDesc.partnerIdentity.address.city);
                        el_city.AppendChild(xt_city);
                    }
                    if (!string.IsNullOrWhiteSpace(Part.contractDesc.partnerIdentity.address.street))
                    {

                        System.Xml.XmlElement el_street = this.Xd.CreateElement("typ:street", Scopes["typ"]);
                        el_address.AppendChild(el_street);
                        System.Xml.XmlText xt_street = this.Xd.CreateTextNode(Part.contractDesc.partnerIdentity.address.street);
                        el_street.AppendChild(xt_street);
                    }
                    if (!string.IsNullOrWhiteSpace(Part.contractDesc.partnerIdentity.address.ico))
                    {

                        System.Xml.XmlElement el_ico = this.Xd.CreateElement("typ:ico", Scopes["typ"]);
                        el_address.AppendChild(el_ico);
                        System.Xml.XmlText xt_ico = this.Xd.CreateTextNode(Part.contractDesc.partnerIdentity.address.ico);
                        el_ico.AppendChild(xt_ico);
                    }
                    if (!string.IsNullOrWhiteSpace(Part.contractDesc.partnerIdentity.address.dic))
                    {

                        System.Xml.XmlElement el_dic = this.Xd.CreateElement("typ:dic", Scopes["typ"]);
                        el_address.AppendChild(el_dic);
                        System.Xml.XmlText xt_dic = this.Xd.CreateTextNode(Part.contractDesc.partnerIdentity.address.dic);
                        el_dic.AppendChild(xt_dic);
                    }
                }
            }

            // responsiblePersonIds
            if (Part.contractDesc.responsiblePerson.id != 0)
            {
                System.Xml.XmlElement el_responsiblePerson = this.Xd.CreateElement("con:responsiblePerson", Scopes["con"]);
                el_contractDesc.AppendChild(el_responsiblePerson);
                System.Xml.XmlElement el_responsiblePersonId = this.Xd.CreateElement("typ:id", Scopes["typ"]);
                el_responsiblePerson.AppendChild(el_responsiblePersonId);
                System.Xml.XmlText xt_responsiblePersonId = this.Xd.CreateTextNode(Part.contractDesc.responsiblePerson.id.ToString());
                el_responsiblePersonId.AppendChild(xt_responsiblePersonId);
            }

            // contractState
            if (Part.contractDesc.contractState != EnumContractState.None)
            {
                System.Xml.XmlElement el_contractState = this.Xd.CreateElement("con:contractState", Scopes["con"]);
                el_contractDesc.AppendChild(el_contractState);
                System.Xml.XmlText xt_contractState = this.Xd.CreateTextNode(Part.contractDesc.contractState.ToString());
                el_contractState.AppendChild(xt_contractState);
            }

            // Text
            if (!string.IsNullOrWhiteSpace(Part.contractDesc.text))
            {
                System.Xml.XmlElement el_Text = this.Xd.CreateElement("con:text", Scopes["con"]);
                el_contractDesc.AppendChild(el_Text);
                System.Xml.XmlText xt_Text = this.Xd.CreateTextNode(Part.contractDesc.text);
                el_Text.AppendChild(xt_Text);
            }

            // ost1
            if (!string.IsNullOrWhiteSpace(Part.contractDesc.ost1))
            {
                System.Xml.XmlElement el_ost1 = this.Xd.CreateElement("con:ost1", Scopes["con"]);
                el_contractDesc.AppendChild(el_ost1);
                System.Xml.XmlText xt_ost1 = this.Xd.CreateTextNode(Part.contractDesc.ost1);
                el_ost1.AppendChild(xt_ost1);
            }

            // ost2
            if (!string.IsNullOrWhiteSpace(Part.contractDesc.ost2))
            {
                System.Xml.XmlElement el_ost2 = this.Xd.CreateElement("con:ost2", Scopes["con"]);
                el_contractDesc.AppendChild(el_ost2);
                System.Xml.XmlText xt_ost2r = this.Xd.CreateTextNode(Part.contractDesc.ost2);
                el_ost2.AppendChild(xt_ost2r);
            }

            // note
            if (!string.IsNullOrWhiteSpace(Part.contractDesc.note))
            {
                System.Xml.XmlElement el_note = this.Xd.CreateElement("con:note", Scopes["con"]);
                el_contractDesc.AppendChild(el_note);
                System.Xml.XmlText xt_note = this.Xd.CreateTextNode(Part.contractDesc.note);
                el_note.AppendChild(xt_note);
            }
        }

    }
}
