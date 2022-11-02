using System;

namespace TestPogodaWait
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            System.IO.FileStream fs = null;
            System.IO.BufferedStream bs = null;
            System.IO.StreamReader sr = null;
            System.IO.StreamWriter stw = null;
            try
            {
                System.Threading.Thread.Sleep(1000 * 1);
                // чтение командной строки
                string s_dir = System.Reflection.Assembly.GetExecutingAssembly().Location;
                s_dir = System.IO.Path.GetDirectoryName(s_dir);
                cCommand com = new cCommand();
                if(args.Length == 5)
                {
                    com.NumCommand = int.Parse(args[4]);
                }
                else if (args.Length == 4)
                {
                    ;
                }
                else
                {
                    string s2 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    s2 = System.IO.Path.GetDirectoryName(s2);
                    fs = new System.IO.FileStream(s2 + @"\returnini.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    bs = new System.IO.BufferedStream(fs);
                    stw = new System.IO.StreamWriter(bs);
                    stw.WriteLine(string.Format("Количество ({0}) аргументов меньше 4 или больше 5", args.Length));
                    int n1 = 0;
                    foreach (string item in args)
                    {
                        stw.WriteLine(string.Format("arg: {0}   -  {1}", n1++, item));
                    }
                    return;
                }
                com.Key = args[0];
                com.User = args[1];
                com.Password = args[2];
                com.FileIni = args[3];
                //  Читаем INI-файл
                System.IO.FileInfo fi = new System.IO.FileInfo(com.FileIni);
                if (!fi.Exists)
                {
                    fs = new System.IO.FileStream(s_dir + @"\returnini.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    bs = new System.IO.BufferedStream(fs);
                    stw = new System.IO.StreamWriter(bs);
                    stw.WriteLine(string.Format("Файл-ini: '{0}' - не найден", com.FileIni));
                    return;
                }
                fs = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                bs = new System.IO.BufferedStream(fs);
                sr = new System.IO.StreamReader(bs);
                bool b1 = true;
                char[] cc = new char[] { '=' };
                char[] cc1 = new char[] { '"' };
                cIni ini = new cIni();
                string[] ss = null;
                do
                {
                    string s1 = sr.ReadLine();
                    if (s1 == null)
                    {
                        b1 = false;
                    }
                    else
                    {
                        int n1 = 0;
                        if (s1.ToLower().StartsWith("input_xml"))
                        {
                            ss = s1.Split(cc);
                            if (ss.Length == 2)
                            {
                                ini.input_xml = ss[1].Trim().Trim(cc1).Trim();
                            }
                        }
                        else if (s1.ToLower().StartsWith("response_xml"))
                        {
                            ss = s1.Split(cc);
                            if (ss.Length == 2)
                            {
                                ini.response_xml = ss[1].Trim().Trim(cc1).Trim();
                            }
                        }
                        else if (s1.ToLower().StartsWith("database"))
                        {
                            ss = s1.Split(cc);
                            if (ss.Length == 2)
                            {
                                ini.database = ss[1];
                            }
                        }
                        else if (s1.ToLower().StartsWith("check_duplicity"))
                        {
                            ss = s1.Split(cc);
                            if (ss.Length == 2)
                            {
                                int.TryParse(ss[1], out n1);
                            }
                            ini.check_duplicity = n1;
                        }
                        else if (s1.ToLower().StartsWith("format_output"))
                        {
                            ss = s1.Split(cc);
                            if (ss.Length == 2)
                            {
                                int.TryParse(ss[1], out n1);
                            }
                            ini.format_output = n1;
                        }
                    }
                } while (b1);
                sr?.Close();
                bs?.Close();
                fs?.Close();
                //  читаем XML файл
                fi = new System.IO.FileInfo(ini.input_xml);
                if (!fi.Exists)
                {
                    string s2 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    s2 = System.IO.Path.GetDirectoryName(s2);
                    fs = new System.IO.FileStream(s2 + @"\returnini.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    bs = new System.IO.BufferedStream(fs);
                    stw = new System.IO.StreamWriter(bs);
                    stw.WriteLine(string.Format("Файл-xml: '{0}' - не найден", ini.input_xml));
                    return;
                }
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(ini.input_xml);
                //  проверяем тип документа
                System.Xml.XmlNodeList li = xd.GetElementsByTagName("invoiceResponse", "inv");
                if (li.Count != 0)
                {

                    return;
                }
                li = xd.GetElementsByTagName("printResponse", "prn");
                if (li.Count != 0)
                {
                    System.Xml.XmlNodeList xnl = xd.GetElementsByTagName("prn:fileName");
                    string s1 = xnl[0].ChildNodes[0].Value;

                    PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
                    PdfSharp.Pdf.PdfPage pdfPage1 = pdf.AddPage();
                    PdfSharp.Drawing.XGraphics graph1 = PdfSharp.Drawing.XGraphics.FromPdfPage(pdfPage1);
                    PdfSharp.Drawing.XFont font1 = new PdfSharp.Drawing.XFont("Verdana", 8, PdfSharp.Drawing.XFontStyle.Bold);
                    int n2 = 10;
                    graph1.DrawString("Это мой pdf файл.  УРА !!!!!!!",
                        font1, PdfSharp.Drawing.XBrushes.Black,
                        new PdfSharp.Drawing.XRect(0, n2, pdfPage1.Width.Point, pdfPage1.Height.Point), PdfSharp.Drawing.XStringFormats.TopLeft);
                    n2 += 20;
                    graph1.DrawString(string.Format("Параметры"),
                        font1, PdfSharp.Drawing.XBrushes.Black,
                        new PdfSharp.Drawing.XRect(0, n2, pdfPage1.Width.Point, pdfPage1.Height.Point), PdfSharp.Drawing.XStringFormats.TopCenter);
                    n2 += 20;
                    for (int n1 = 0; n1 < args.Length; n1++)
                    {
                        n2 = n2 + (n1 * 20);
                        graph1.DrawString(string.Format("{0})  1 - {1}", n1 + 1, args[n1]),
                            font1, PdfSharp.Drawing.XBrushes.Red,
                            new PdfSharp.Drawing.XRect(20, n2, pdfPage1.Width.Point, pdfPage1.Height.Point), PdfSharp.Drawing.XStringFormats.TopLeft);
                    }
                    n2 += 20;
                    sw.Stop();
                    graph1.DrawString(string.Format("Текущее время: {0},   Время выполнения: {1}", DateTime.Now.ToString("dd-MMM=yyyy HH:mm:ss"), sw.Elapsed),
                        font1, PdfSharp.Drawing.XBrushes.Blue,
                        new PdfSharp.Drawing.XRect(0, n2, pdfPage1.Width.Point, pdfPage1.Height.Point), PdfSharp.Drawing.XStringFormats.TopLeft);
                    pdf.Save(ini.response_xml);
                    return;
                }
                li = xd.GetElementsByTagName("addressbookResponse", "adb");
                if (li.Count != 0)
                {
                    xd = new System.Xml.XmlDocument();
                    xd.Load(s_dir + @"\RetXml\CreateR_AddressBook.xml");
                    xd.Save(ini.response_xml);
                    return;
                }
                li = xd.GetElementsByTagName("lAdb:listAddressBookRequest");
                if (li.Count != 0)
                {
                    xd = new System.Xml.XmlDocument();
                    xd.Load(s_dir + @"\RetXml\ListR_AddressBook.xml");
                    xd.Save(ini.response_xml);
                    return;
                }
            }
            catch (Exception e1)
            {
                string s2 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                s2 = System.IO.Path.GetDirectoryName(s2);
                fs = new System.IO.FileStream(s2 + @"\returnini.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                bs = new System.IO.BufferedStream(fs);
                stw = new System.IO.StreamWriter(bs);
                stw.WriteLine(string.Format("Возникла грубая ошибка в 'Test-POHODA': {0}", e1.Message));
            }
            finally
            {
                stw?.Close();
                sr?.Close();
                bs?.Close();
                fs?.Close();
            }
        }
        private class cCommand
        {
            public string Key { set; get; }
            public string User { set; get; }
            public string Password { set; get; }
            public string FileIni { set; get; }
            public int NumCommand { set; get; } = 0;
        }
        private class cIni
        {
            public string input_xml { set; get; }
            public string response_xml { set; get; }
            public string database { set; get; }
            public int check_duplicity { set; get; } = 0;
            public int format_output { set; get; } = 0;
        }
    }
}
