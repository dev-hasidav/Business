using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Setup
{
    [NumClass(13)]
    public class RemAssecc
    {
        [NumFunction(1)]
        public bool SetupConnectServer(string NamePort, string NameScope, int Port, Type objConnect)
        {
            bool b1 = false;
            try
            {
                BinaryServerFormatterSinkProvider serProv = new BinaryServerFormatterSinkProvider
                {
                    TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
                };
                BinaryClientFormatterSinkProvider clProv = new BinaryClientFormatterSinkProvider();
                Dictionary<string, string> prop = new Dictionary<string, string>
                {
                    ["port"] = Port.ToString(),
                    ["name"] = NamePort
                };
                HttpChannel ch = new HttpChannel(prop, clProv, serProv);
#if DEBUG
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off; ///  отключение ошибок = On
#else
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.On; ///  отключение ошибок = On
#endif
                System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ch, false);
                RemotingConfiguration.RegisterWellKnownServiceType(objConnect, NameScope, WellKnownObjectMode.SingleCall);
                b1 = true;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            return b1;
        }

        [NumFunction(2)]
        public bool SetupConnectClient(int Port, string NameScope)
        {
            bool b1 = false;
            try
            {
                BinaryServerFormatterSinkProvider serProv = new BinaryServerFormatterSinkProvider
                {
                    TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
                };
                BinaryClientFormatterSinkProvider clProv = new BinaryClientFormatterSinkProvider();
                Dictionary<string, string> prop = new Dictionary<string, string>
                {
                    ["port"] = "0",
                    ["name"] = string.Format("Cl_{0}_{1}", NameScope, Port)
                };
                HttpChannel ch = new HttpChannel(prop, clProv, serProv);
#if DEBUG
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off; ///  отключение ошибок = On
#else
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.On; ///  отключение ошибок = On
#endif
                System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ch, false);

                b1 = true;
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return b1;
        }

        [NumFunction(3)]
        public bool GetConnectClient(string NameHost, int Port, string NameScope, Type objConnect, out object Connect)
        {
            bool b1 = false;
            Connect = null;
            try
            {
                string s1 = string.Format(@"http://{0}:{1}/{2}", NameHost, Port, NameScope);
                Connect = Activator.GetObject(objConnect, s1);
                b1 = true;
            }
            catch (Exception)
            {
            }
            return b1;
        }

        public static string NameAgentScope { set; get; }
        public static int PortAgent { set; get; }
        public static Interfases.IConnectMainSyncAgent GetConnectAgent(string Host)
        {
            Interfases.IConnectMainSyncAgent ag = null;
            try
            {
                string s1 = string.Format(@"http://{0}:{1}/{2}", Host, PortAgent, NameAgentScope);
                ag = (Interfases.IConnectMainSyncAgent)Activator.GetObject(typeof(Interfases.IConnectMainSyncAgent), s1);
            }
            catch (Exception)
            {
            }
            return ag;
        }
    }
}
