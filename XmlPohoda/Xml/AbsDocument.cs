using Business.Pohoda.Xml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    public abstract class AbsDocument
    {
        public System.Xml.XmlDocument Xd;
        protected System.Xml.XmlElement dataPack;
        protected HeadDataPack HeadPack;
        protected Dictionary<string, string> Scopes;
        public AbsDocument(HeadDataPack Head)
        {
            SetHead(Head);
        }
        protected virtual void SetHead(HeadDataPack Head)
        {
            DataPack dp = new DataPack();
            this.Xd = dp.SetDataPack(Head, Scopes, out System.Xml.XmlElement dataPack);
            this.dataPack = dataPack;
        }
    }
}
