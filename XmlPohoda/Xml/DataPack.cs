using Business.Pohoda.Xml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    /// <summary>
    /// Создание заголовка XML-document
    /// </summary>
    [NumClass(49)]
    public class DataPack
    {
        public System.Xml.XmlDocument SetDataPack(HeadDataPack HeadPack, Dictionary<string, string> Scopes, out System.Xml.XmlElement dataPack)
        {
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();

            System.Xml.XmlDeclaration xe_head = xd.CreateXmlDeclaration(HeadPack.VersionXML, HeadPack.Encoding, HeadPack.Standalone);
            xd.AppendChild(xe_head);

            //  dat:dataPack
            dataPack = xd.CreateElement("dat:dataPack", Scopes["dat"]);
            xd.AppendChild(dataPack);

            foreach (string str in Scopes.Keys)
            {
                System.Xml.XmlAttribute xa1 = xd.CreateAttribute(string.Format("xmlns:{0}", str));
                xa1.Value = Scopes[str];
                dataPack.Attributes.Append(xa1);
            }

            System.Xml.XmlAttribute xa = xd.CreateAttribute("version");
            xa.Value = HeadPack.VersionProc;
            dataPack.Attributes.Append(xa);

            xa = xd.CreateAttribute("note");
            xa.Value = HeadPack.Note;
            dataPack.Attributes.Append(xa);

            xa = xd.CreateAttribute("application");
            xa.Value = HeadPack.Application;
            dataPack.Attributes.Append(xa);

            xa = xd.CreateAttribute("ico");
            xa.Value = HeadPack.Ico;
            dataPack.Attributes.Append(xa);

            xa = xd.CreateAttribute("id");
            xa.Value = HeadPack.IdDataPack;
            dataPack.Attributes.Append(xa);

            return xd;
        }
    }
}
