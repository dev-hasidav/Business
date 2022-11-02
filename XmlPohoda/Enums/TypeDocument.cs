using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    [Serializable]
    public enum enumState { none = 0, ok = 1, warning = 2, error = 3 }

    [Serializable]
    public enum ItemChoiceType
    {
        Note = 0,
        addressbookResponse = 1,
        invoiceResponse = 2,
        printResponse = 3
    }

    [Serializable]
    public enum EnumActionType { none = 0, add = 1, update = 2, delete = 3, print = 4, link = 5, sendEET = 6 }

    /// <summary>
    /// Типы документов
    /// </summary>
    [Serializable]
    public enum TypeDocument
    {
        None = 0, FV = 1, FP = 2, PD = 3, VD = 4, PB = 5, VB = 6, OP = 7, OZ = 8,
        ObjV = 9, ObjP = 10, Zak = 11, NabV = 12, NabP = 13, PopV = 14, PopP = 15,
        pInt = 16, Zam = 17, Mzdy = 18, Majetek = 19, DrobMajetek = 20, LeasMajetek = 21,
        Vozidla = 22, Ridicik = 23, CestPrikazy = 24, AddressBook = 25, Pdf = 100
    }

    [Serializable]
    public enum AgendaPrintPdf
    {
        None = 0,
        vydane_faktury = 1,
        prijate_faktury = 2,
        pokladnaPd = 3,
        pokladnaVd = 4,
        pokladna = 1000,
        //NonePb = 5,
        //NoneVb = 6,
        ostatni_pohledavky = 7,
        ostatni_zavazky = 8,
        vydane_objednavky = 9,
        prijate_objednavky = 10,
        zakazky = 11,
        vydane_nabidky = 12,
        prijate_nabidky = 13,
        vydane_poptavky = 14,
        prijate_poptavky = 15,
        interni_doklady = 16,

        vydane_zalohove_faktury = 17,
        prijate_zalohove_faktury = 18,
        adresar = 19,
        prevod = 21,
        prijemky = 22,
        prodejky = 23,
        vydejky = 24,
        vyroba = 25,
        zasoby = 26,
        NonePdf = 100
    }

    [Serializable]
    public enum VatRateType { none = 0, low = 1, high = 2, third = 3 }

    [Serializable]
    public enum TypeCleneniDPH { inland = 1, nonSubsume = 2 }

    [Serializable]
    public enum TypeRoundingDocument
    {
        /// <summary>
        /// Zaokrouhlení matematicky na koruny.
        /// Математически округлить до короны.
        /// </summary>
        math2one = 0,
        /// <summary>
        /// Zaokrouhlení nahoru na koruny.
        /// Округление до короны.
        /// </summary>
        up2one = 1,
        /// <summary>
        /// Zaokrouhlení matematicky na padesátníky.
        /// Математически округлить до пятидесятых.
        /// </summary>
        math2half = 2,
        /// <summary>
        /// Zaokrouhlení matematicky na desetníky.
        /// Математически округляя до десяти центов.
        /// </summary>
        math2tenth = 3,
        /// <summary>
        /// Zaokrouhlení nahoru na padesátníky.
        /// Округление до пятидесятых.
        /// </summary>
        up2half = 4,
        /// <summary>
        /// Zaokrouhlení nahoru na desetníky.
        /// Округление до центов.
        /// </summary>
        up2tenth = 5,
        /// <summary>
        /// Zaokrouhlení dolů na koruny.
        /// Округление до коронок.
        /// </summary>
        down2one = 6,
        /// <summary>
        /// Zaokrouhlení dolů na padesátníky.
        /// Округление до пятидесятых.
        /// </summary>
        down2half = 7,
        /// <summary>
        /// Zaokrouhlení dolů na desetníky.
        /// Округление до 10 центов
        /// </summary>
        down2tenth = 8
    }

    [Serializable]
    public enum TypeFormaUhr { draft = 0, cash = 1, postal = 2, delivery = 3, creditcart = 4, advance = 5, encashment = 6, cheque = 7, compensation = 8 }

    [Serializable]
    public enum EnumSzDPH { Kc0 = 0, Kc15 = 1, Kc21 = 2, Kc10 = 3 }

    [Serializable]
    public enum EnumInvoiceType
    {
        /// <summary>
        /// FV выставляемый счет-фактура   Vydaná Faktura
        /// </summary>
        issuedInvoice = 0,
        /// <summary>
        /// FP Dobropis
        /// выпущенное кредитное уведомление,
        /// </summary>
        issuedCreditNotice = 1,
        /// <summary>
        /// Vrubopis
        /// выпущенная дебетовая нота
        /// </summary>
        issuedDebitNote = 2,
        /// <summary>
        /// Zálohová faktura
        /// выданный авансовый счет
        /// </summary>
        issuedAdvanceInvoice = 3,
        /// <summary>
        /// OP   Ostatní pohledávka     дебиторская задолженность
        /// </summary>
        receivable = 4,
        /// <summary>
        /// Proforma faktura
        /// выданный Проформенный счет
        /// </summary>
        issuedProformaInvoice = 5,
        /// <summary>
        /// Penále
        /// штраф
        /// </summary>
        penalty = 6,
        /// <summary>
        /// Vydaný opravný daňový doklad (jen CZ verze)
        /// выдается корректирующий налог
        /// </summary>
        issuedCorrectiveTax = 7,
        /// <summary>
        /// Принятая фактура    Přijatá faktura
        /// получен счет
        /// </summary>
        receivedInvoice = 8,
        /// <summary>
        /// Přijatý dobropis
        /// получено Кредитное уведомление
        /// </summary>
        receivedCreditNotice = 9,
        /// <summary>
        /// Přijatý vrubopis
        /// получил Дебетовую заметку
        /// </summary>
        receivedDebitNote = 10,
        /// <summary>
        /// Přijatá zálohová faktura
        /// получил авансовый счет
        /// </summary>
        receivedAdvanceInvoice = 11,
        /// <summary>
        /// OZ  Závazek обязательство
        /// </summary>
        commitment = 12,
        /// <summary>
        /// Přijatá proforma faktura
        /// получил счет-фактуру Proforma
        /// </summary>
        receivedProformaInvoice = 13,
        /// <summary>
        /// Přijatý opravný daňový doklad (jen CZ verze)
        /// получил корректирующий налог
        /// </summary>
        receivedCorrectiveTax = 14,
        /// <summary>
        /// PD  PB  Příjmový doklad.  Příjmový doklad bank.
        /// </summary>
        receipt = 15,
        /// <summary>
        /// VD  VB  Výdajový doklad.   Výdajový doklad bank.
        /// </summary>
        expense = 16,
        /// <summary>
        /// Obj V    Vydaná objednávka
        /// </summary>
        issuedOrder = 17,
        /// <summary>
        /// Obj P    Přijatá objednávka
        /// </summary>
        receivedOrder = 18,
        /// <summary>
        /// Nab V     Vydaná nabídka
        /// </summary>
        issuedOffer = 19,
        /// <summary>
        /// Nab P    Přijatá nabídka.
        /// </summary>
        receivedOffer = 20,
        /// <summary>
        /// Pop V   Vydaná poptávka.
        /// </summary>
        issuedEnquiry = 21,
        /// <summary>
        /// Pop P    Přijatá poptávka.
        /// </summary>
        receivedEnquiry = 22
    }

    /// <summary>
    /// Статус документа от Pohoda
    /// </summary>
    [Serializable]
    public enum EnumContractState
    {
        /// <summary>
        /// отсутствует или NULL
        /// </summary>
        None = 0,
        /// <summary>
        /// Запланированный заказ.
        /// </summary>
        planned = 1,
        /// <summary>
        /// Контракт начался.
        /// </summary>
        opened = 2,
        /// <summary>
        /// Заказ отправлен
        /// </summary>
        delivered = 3,
        /// <summary>
        /// Закрытый договор.
        /// </summary>
        closed = 4
    }

}
