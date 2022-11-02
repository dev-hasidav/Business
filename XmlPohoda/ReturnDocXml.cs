using Business.Pohoda.Xml.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    public class ReturnDocXml
    {
        #region  ==========  public Property  ==========
        [System.Xml.Serialization.XmlElementAttribute("responsePack")]
        public responsePack Packet { set; get; }
        public bool IsSuccess { get { return _Success(); } }
        public string IdPack { private set; get; }
        public string Ico { private set; get; }
        public enumState State { private set; get; }
        public string Message { private set; get; }
        public List<string> CollectionMessage { private set; get; } = new List<string>();
        public string DateCreate { get { return _Date.ToString("dd-MMM-yyyy HH:mm:ss zzz"); } }
        public TimeSpan Time { get { sw.Stop(); return sw.Elapsed; } }

        #endregion

        #region  ==========  private Property  ==========

        private DateTimeOffset _Date = DateTimeOffset.Now;
        private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        /// <summary>
        /// {0}) {1}, idPac: {2}, idItem: {3}, Mess: {4}
        /// </summary>
        private string s_par = @"{0}) {1}, idPac: {2}, idItem: {3}, Mess: {4}";
        /// <summary>
        /// {0}-{1}) {2}, idPac: {3}, idItem: {4}, Mess: {5}
        /// </summary>
        private string s_el = @"{0}-{1}) {2}, idPac: {3}, idItem: {4}, Mess: {5}";

        #endregion

        #region  ==========  Constructor  ==========

        public ReturnDocXml()
        {
            sw.Start();
        }

        #endregion

        private bool _Success()
        {
            sw.Stop();
            bool b1 = false;
            CollectionMessage.Clear();
            int n_err = 0, n_war = 0;
            if (Packet == null)
            {
                State = enumState.error;
                Message = "Пакет 'responsePack' равен 'NULL'";
                return b1;
            }
            IdPack = Packet.id;
            Ico = Packet.ico;
            State = Packet.state;
            if (Packet.state == enumState.error)
            {
                Message = Packet.note;
            }
            else
            {
                if (Packet.responsePackItem == null)
                {
                    Message = "Пакет 'responsePackItem' равен 'NULL'.";
                }
                else if (Packet.responsePackItem.Count == 0)
                {
                    Message = "Пакет 'responsePackItem' равен '0'.";
                }
                else
                {
                    int n_rpi = 0;
                    foreach (ResponsePackItem rpi in Packet.responsePackItem)
                    {
                        n_rpi++;
                        if (rpi.state == enumState.error)
                        {
                            n_err++;
                            CollectionMessage.Add(string.Format(s_par, n_rpi, rpi.state, Packet.id, rpi.id, rpi.note));
                        }
                        else 
                        {
                            if (rpi.state != enumState.ok)
                            {
                                n_war++;
                                CollectionMessage.Add(string.Format(s_par, n_rpi, rpi.state, Packet.id, rpi.id, rpi.note));
                            }
                            if (rpi.Items == null)
                            {
                                CollectionMessage.Add(string.Format(s_par, n_rpi, rpi.state, Packet.id, rpi.id, "Пакет 'responsePackItem-item' равен 'NULL'."));
                            }
                            else if (rpi.Items.Count == 0)
                            {
                                CollectionMessage.Add(string.Format(s_par, n_rpi, rpi.state, Packet.id, rpi.id, "Пакет 'responsePackItem-item' равен '0'."));
                            }
                            else
                            {
                                int n_el = 0;
                                foreach (object el in rpi.Items)
                                {
                                    n_el++;
                                    //CollectionMessage.Add(string.Format(s_el, n_rpi, n_el, rpi.state, Packet.id, rpi.id, el.GetType()));
                                    if (el.GetType() == typeof(ListAddressBook))
                                    {
                                        ListAddressBook li = (ListAddressBook)el;
                                        string s_li = li.addressbook == null ? "List addressBook 'NULL'" :
                                            string.Format("Count: {0}", li.addressbook.Count);
                                        CollectionMessage.Add(string.Format("--" + s_el, n_rpi, n_el, li.state, Packet.id, rpi.id, s_li));
                                    }
                                    else if (el.GetType() == typeof(AddressbookResponse))
                                    {
                                        AddressbookResponse vr = (AddressbookResponse)el;
                                        if (vr.importDetails == null)
                                        {
                                            CollectionMessage.Add(string.Format(s_el, n_rpi, n_el, vr.state, Packet.id, rpi.id, "AddressbookResponse-importDetails 'NULL'"));
                                        }
                                        else
                                        {
                                            foreach (Detail id in vr.importDetails)
                                            {
                                                CollectionMessage.Add(string.Format("--{0}-{1}) {2}", n_rpi, n_el, id.ToString()));
                                            }
                                        }
                                    }
                                    else if (el.GetType() == typeof(ListContract))
                                    {
                                        ListContract li = (ListContract)el;
                                        string s_li = li.contract == null ? "List zakazka 'NULL'" :
                                            string.Format("Count: {0}", li.contract.Count);
                                        CollectionMessage.Add(string.Format("--" + s_el, n_rpi, n_el, li.state, Packet.id, rpi.id, s_li));
                                    }
                                    else if (el.GetType() == typeof(listBank))
                                    {
                                        listBank li = (listBank)el;
                                        string s_li = li.bank == null ? "List bank 'NULL'" :
                                            string.Format("Count: {0}", li.bank.Count);
                                        CollectionMessage.Add(string.Format("--" + s_el, n_rpi, n_el, li.state, Packet.id, rpi.id, s_li));
                                    }
                                    else if (el.GetType() == typeof(ListVoucher))
                                    {
                                        ListVoucher li = (ListVoucher)el;
                                        string s_li = li.voucher == null ? "List pokladna 'NULL'" :
                                            string.Format("Count: {0}", li.voucher.Count);
                                        CollectionMessage.Add(string.Format("--" + s_el, n_rpi, n_el, li.state, Packet.id, rpi.id, s_li));
                                    }
                                    else if (el.GetType() == typeof(ListInvoice))
                                    {
                                        ListInvoice li = (ListInvoice)el;
                                        string s_li = li.invoice == null ? "List invoice 'NULL'" :
                                            string.Format("Count: {0}", li.invoice.Count);
                                        CollectionMessage.Add(string.Format("--" + s_el, n_rpi, n_el, li.state, Packet.id, rpi.id, s_li));
                                    }
                                    else if (el.GetType() == typeof(VoucherResponse))
                                    {
                                        VoucherResponse vr = (VoucherResponse)el;
                                        if (vr.importDetails == null)
                                        {
                                            CollectionMessage.Add(string.Format(s_el, n_rpi, n_el, vr.state, Packet.id, rpi.id, "VoucherResponse-importDetails 'NULL'"));
                                        }
                                        else
                                        {
                                            foreach (Detail id in vr.importDetails)
                                            {
                                                CollectionMessage.Add(string.Format("--{0}-{1}) {2}", n_rpi, n_el, id.ToString()));
                                            }
                                        }
                                    }
                                    else if (el.GetType() == typeof(InvoiceResponse))
                                    {
                                        InvoiceResponse vr = (InvoiceResponse)el;
                                        if (vr.importDetails == null)
                                        {
                                            CollectionMessage.Add(string.Format(s_el, n_rpi, n_el, vr.state, Packet.id, rpi.id, "InvoiceResponse-importDetails 'NULL'"));
                                        }
                                        else
                                        {
                                            foreach (Detail id in vr.importDetails)
                                            {
                                                CollectionMessage.Add(string.Format("--{0}-{1}) {2}", n_rpi, n_el, id.ToString()));
                                            }
                                        }
                                    }
                                    else if (el.GetType() == typeof(PrintResponse))
                                    {
                                        PrintResponse vr = (PrintResponse)el;
                                        if (vr.importDetails == null)
                                        {
                                            CollectionMessage.Add(string.Format(s_el, n_rpi, n_el, vr.state, Packet.id, rpi.id, "PrintResponse-importDetails 'NULL'"));
                                        }
                                        else
                                        {
                                            foreach (Detail id in vr.importDetails)
                                            {
                                                CollectionMessage.Add(string.Format("--{0}-{1}) {2}", n_rpi, n_el, id.ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        CollectionMessage.Add(string.Format(s_el, n_rpi, n_el, enumState.error, Packet.id, rpi.id, "Packet no identification"));
                                    }
                                }
                            }
                        }
                    }
                    Message = string.Format("Status: {0}, Date: {1}, Lead time: {2}, Всего пакетов: {3}, Error: {4}, Warting: {5}",
                        Packet.state, DateCreate, Time, Packet.responsePackItem.Count, n_err, n_war);
                    b1 = true;
                }
            }
            return b1;
        }
    }
}
