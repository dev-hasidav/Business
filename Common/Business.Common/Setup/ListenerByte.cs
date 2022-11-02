using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Setup
{
    /// <summary>
    /// Запускает прослушку (TcpListener) и при приёме вызывает указанный метод
    /// </summary>
    [NumClass(12)]
    public class ListenerByte
    {
        private int _PortListener = 0;
        private int _PortBase;
        private string _NameScopeBase;
        private Type _typeConnectBase;
        private string _NameMetod;
        private System.Net.IPAddress adr;
        private int _ok = 5683562, _end = -1396247;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="PortListener">Порт прослушки TcpListener</param>
        /// <param name="PortBase">Порт связи с основным сервером</param>
        /// <param name="NameScopeBase">Пространство основного сервера</param>
        /// <param name="objConnectBase">Тип основного сервера соединения. Можно интерфейс</param>
        /// <param name="NameMetod">Метод основного сервераб который будет вызван</param>
        public ListenerByte(int PortListener, int PortBase, string NameScopeBase, Type objConnectBase, string NameMetod)
        {
            _PortListener = PortListener;
            _NameScopeBase = NameScopeBase;
            _PortBase = PortBase;
            _NameMetod = NameMetod;
            _typeConnectBase = objConnectBase;
            adr = System.Net.IPAddress.Any;
        }

        [NumFunction(1)]
        public void StartListener()
        {
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(_StartListener);
            System.Threading.Thread th = new System.Threading.Thread(ts)
            {
                Name = "ListenerTriggers"
            };
            th.Start();
            FileEventLog.WriteOk(this, "Запущен поток ListenerTriggers.", System.Reflection.MethodInfo.GetCurrentMethod());
        }

        [NumFunction(2)]
        private void _StartListener()
        {
            System.Net.Sockets.TcpListener tl = null;
            System.Net.Sockets.TcpClient tc = null;
            System.Net.Sockets.NetworkStream ns = null;
            //RetTriggers ret = null;
            System.Net.IPEndPoint ep_local = new System.Net.IPEndPoint(adr, _PortListener);
            tl = new System.Net.Sockets.TcpListener(ep_local);
            tl.Start();
            bool b_list = true;
            FileEventLog.WriteOk(this, "ListenerTriggers подготовлен к работе.", System.Reflection.MethodInfo.GetCurrentMethod());
            do
            {
                try
                {
                    tc = tl.AcceptTcpClient();
                    System.Net.IPEndPoint e_loc = (System.Net.IPEndPoint)tc.Client.LocalEndPoint;
                    System.Net.IPEndPoint e_rem = (System.Net.IPEndPoint)tc.Client.RemoteEndPoint;
                    System.Net.IPHostEntry he_loc = System.Net.Dns.GetHostEntry(e_loc.Address);
                    System.Net.IPHostEntry he_rem = System.Net.Dns.GetHostEntry(e_rem.Address);
                    string s_Al_lok = "";
                    foreach (string item in he_loc.Aliases)
                    {
                        s_Al_lok += item + "; ";
                    }
                    string s_Al_rem = "";
                    foreach (string item in he_rem.Aliases)
                    {
                        s_Al_rem += item + "; ";
                    }
                    FileEventLog.WriteOk(this,
                        string.Format("IPloc: {0}:{1}, IPrem: {2}:{3}, AliasLoc: {4}-{5}, AliasRem: {6}-{7}",
                            e_loc.Address,
                            e_loc.Port,
                            e_rem.Address,
                            e_rem.Port,
                            he_loc.HostName, string.IsNullOrWhiteSpace(s_Al_lok) ? "No local alias" : s_Al_lok,
                            he_rem.HostName, string.IsNullOrWhiteSpace(s_Al_rem) ? "No remote alias" : s_Al_rem
                        ), System.Reflection.MethodInfo.GetCurrentMethod());
                    ns = tc.GetStream();
                    byte[] bb = new byte[1024 * 1024];
                    int n_count = ns.Read(bb, 0, bb.Length);

                    RetTriggers ret = ConvertByteToRetTriggers(bb, n_count);

                    if (ret != null)
                    {
                        if (ret.IsOk)
                        {
                            if (ret.CodeMess == _ok)
                            {
                                switch (ret.Status)
                                {
                                    case StatusMessage.Sen:
                                        FileEventLog.WriteOk(this, "ListenerTriggers - отсылка пакета серверу.", System.Reflection.MethodInfo.GetCurrentMethod());
                                        string s1 = string.Format(@"http://{0}:{1}/{2}", "localhost" /*adr.ToString()*/, _PortBase, _NameScopeBase);
                                        object cl_Connect = Activator.GetObject(_typeConnectBase, s1);
                                        _typeConnectBase.GetMethod(_NameMetod).Invoke(cl_Connect, new object[] { ret });
                                        break;
                                    case StatusMessage.End:
                                        FileEventLog.WriteOk(this, "ListenerTriggers - команда к завершению выполняется.",
                                            System.Reflection.MethodInfo.GetCurrentMethod());
                                        b_list = false;
                                        break;
                                    default:
                                        FileEventLog.WriteOk(this,
                                            string.Format("ListenerTriggers 1 - нераспознанный пакет. Id: {0}, Status: {1}", ret.Id, (int)ret.Status),
                                            System.Reflection.MethodInfo.GetCurrentMethod());
                                        break;
                                }
                            }
                            else
                            {
                                FileEventLog.WriteOk(this,
                                    string.Format("ListenerTriggers 2 - нераспознанный пакет. Code: {0}, Status: {1}, Id: {2}",
                                    ret.CodeMess, ret.Status, ret.Id),
                                    System.Reflection.MethodInfo.GetCurrentMethod());
                            }
                        }
                        else
                        {
                            FileEventLog.WriteOk(this,
                                string.Format("ListenerTriggers 3 - ошибка обработки пакета"),
                                System.Reflection.MethodInfo.GetCurrentMethod());
                        }
                    }
                    else
                    {
                        FileEventLog.WriteOk(this,
                            string.Format("ListenerTriggers 4 - получен NULL-packet"),
                            System.Reflection.MethodInfo.GetCurrentMethod());
                    }

                    ret = null;
                }
                catch (Exception e1)
                {
                    FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                }
                finally
                {
                    ns?.Close();
                    ns = null;
                    tc?.Close();
                    tc = null;
                }
            } while (b_list);
            tl?.Stop();
            tl = null;
            FileEventLog.WriteOk(this, "ListenerTriggers - команда к завершению ВЫПОЛНЕНА.",
                System.Reflection.MethodInfo.GetCurrentMethod());
        }

        [NumFunction(3)]
        public void StopListener()
        {
            System.Net.Sockets.TcpClient tc = null;
            System.Net.Sockets.NetworkStream ns = null;
            try
            {
                Random r = new Random(DateTime.Now.Millisecond);
                FileEventLog.WriteOk(this, "ListenerTriggers - Start команда к завершению.",
                    System.Reflection.MethodInfo.GetCurrentMethod());
                byte[] bb = new byte[511];
                r.NextBytes(bb);
                bb[4] = (byte)StatusMessage.End;
                byte[] bb2 = BitConverter.GetBytes(_ok);
                int n1 = 0;
                for (n1 = 0; n1 < bb2.Length; n1++)
                {
                    bb[n1 + 10] = bb2[n1];
                }
                bb[n1 + 10] = 0x00;
                bb2 = BitConverter.GetBytes(_end);
                for (n1 = 0; n1 < bb2.Length; n1++)
                {
                    bb[n1 + 300] = bb2[n1];
                }
                bb[n1 + 300] = 0x00;

                bb = Cryptography.Crypto.EncryptorByte(bb);
                tc = new System.Net.Sockets.TcpClient();
                tc.Connect("localhost", _PortListener);
                ns = tc.GetStream();
                ns.Write(bb, 0, bb.Length);
                FileEventLog.WriteOk(this, "ListenerTriggers - команда к завершению отосланна.",
                    System.Reflection.MethodInfo.GetCurrentMethod());
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                ns?.Close();
                tc?.Close();
            }
            //System.Threading.Thread.Sleep(5 * 1000);

        }


        [NumFunction(4)]
        private RetTriggers ConvertByteToRetTriggers(byte[] bb, int Count)
        {
            RetTriggers ret = new RetTriggers();
            try
            {

                byte[] bb1 = new byte[Count];
                for (int n1 = 0; n1 < Count; n1++)
                {
                    bb1[n1] = bb[n1];
                }
                bb1 = Cryptography.Crypto.DecryptorByte(bb1);
                if (bb1.Length != 511) return ret;

                ret.Status = (StatusMessage)bb1[4];
                ret.CodeMess = BitConverter.ToInt32(bb1, 10);
                ret.Id = BitConverter.ToInt32(bb1, 30);

                for (int n1 = 50; n1 < 100; n1++)
                {
                    if (bb1[n1] == 0) break;
                    ret.NameServer += Convert.ToChar(bb1[n1]);
                }
                for (int n1 = 100; n1 < 150; n1++)
                {
                    if (bb1[n1] == 0) break;
                    ret.NameBase += Convert.ToChar(bb1[n1]);
                }
                for (int n1 = 150; n1 < 200; n1++)
                {
                    if (bb1[n1] == 0) break;
                    ret.NameTable += Convert.ToChar(bb1[n1]);
                }
                for (int n1 = 200; n1 < 250; n1++)
                {
                    if (bb1[n1] == 0) break;
                    ret.NameTrigger += Convert.ToChar(bb1[n1]);
                }
                for (int n1 = 250; n1 < 300; n1++)
                {
                    if (bb1[n1] == 0) break;
                    ret.TriggerAction += Convert.ToChar(bb1[n1]);
                }
                ret.IdRecord = BitConverter.ToInt32(bb1, 300);
                for (int n1 = 350; n1 < 400; n1++)
                {
                    if (bb1[n1] == 0) break;
                    ret.GuidTask += Convert.ToChar(bb1[n1]);
                }
                ret.IsOk = true;
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

    }
}
