using Business.Pohoda.Xml.Models;
using Business.Pohoda.Xml.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml
{
    /// <summary>
    /// Основной класс для создания, запуска и обработки XML-документов в 'POHODA'
    /// </summary>
    [NumClass(48)]
    public class Document
    {
        private string _Base;
        private string _Ico;
        private string _PathPohoda;
        private string _PathPublic;
        private string _LogPohoda;
        private string _PassPublic;
        private string _FileName;
        private string _FileNameIni;
        private string _FileNameInp;
        private string _FileNameOut;
        private System.IO.DirectoryInfo _di_root;
        private System.IO.DirectoryInfo _di_inp;
        private System.IO.DirectoryInfo _di_out;
        public Document(string Base, string Ico, string PathPohoda, string PathPublic, string Login, string Password)
        {
            _Base = Base;
            _Ico = Ico;
            _PathPohoda = PathPohoda;
            _PathPublic = PathPublic;
            _LogPohoda = Login;
            _PassPublic = Password;
        }

        #region  ==========  Address Book  ==========

        /// <summary>
        /// Запись информации в 'POHODA'
        /// </summary>
        /// <param name="Mod"></param>
        /// <returns></returns>
        [NumFunction(50)]
        public ReturnDocXml SetAddressBook(List<Packet.Addressbook> Mod)
        {
            ReturnDocXml rp = null;
            try
            {
                //  Подготавливаем директории и файлы
                HeadDataPack Head = PrepareCommand("ad");
                // Создаём входной XML файл
                exAddressBook add = new exAddressBook(Head);
                System.Xml.XmlDocument xd = add.SetAddressBook(Mod);
                rp = EndCommand(xd);
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return rp;
        }

        /// <summary>
        /// Чтение информации из 'POHODA'
        /// </summary>
        /// <param name="Id"></param>
        [NumFunction(51)]
        public ReturnDocXml GetAddressBook(FilterGet Filtr)
        {
            ReturnDocXml rp = null;
            try
            {
                //  Подготавливаем директории и файлы
                HeadDataPack Head = PrepareCommand("ad");
                exAddressBook add = new exAddressBook(Head);
                System.Xml.XmlDocument xd = add.GetAddressBook(Filtr);
                rp = EndCommand(xd);
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return rp;
        }

        /// <summary>
        /// Обновить или удалить информации в 'POHODA'
        /// </summary>
        /// <param name="Mod"></param>
        /// <returns></returns>
        [NumFunction(52)]
        public ReturnDocXml ChangeAddressBook(EnumActionType Act, List<Addressbook> Mod)
        {
            ReturnDocXml rp = null;
            try
            {
                //  Подготавливаем директории и файлы
                HeadDataPack Head = PrepareCommand("ad");
                exAddressBook add = new exAddressBook(Head);
                System.Xml.XmlDocument xd = null;
                if (Act == EnumActionType.delete)
                {
                    xd = add.DeleteAddressBook(Mod);
                }
                else
                {
                    xd = add.UpdateAddressBook(Mod);
                }
                rp = EndCommand(xd);
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return rp;
        }

        #endregion

        #region  ==========  Zakazka  ==========

        /// <summary>
        /// Запись информации в 'POHODA'
        /// </summary>
        /// <param name="Mod"></param>
        /// <returns></returns>
        [NumFunction(50)]
        public ReturnDocXml SetZakazka(Contract Mod)
        {
            ReturnDocXml rp = null;
            try
            {
                //  Подготавливаем директории и файлы
                HeadDataPack Head = PrepareCommand("zk");
                exZakazka add = new exZakazka(Head);
                System.Xml.XmlDocument xd = add.SetZakazka(Mod);
                rp = EndCommand(xd);
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return rp;
        }

        /// <summary>
        /// Чтение информации из 'POHODA'
        /// </summary>
        /// <param name="Id"></param>
        [NumFunction(51)]
        public ReturnDocXml GetZakazka(FilterGet Filtr)
        {
            ReturnDocXml rp = null;
            try
            {
                //  Подготавливаем директории и файлы
                HeadDataPack Head = PrepareCommand("zk");
                exZakazka zak = new exZakazka(Head);
                System.Xml.XmlDocument xd = zak.GetZakazka(Filtr);
                rp = EndCommand(xd);
            }
            catch (Exception e1)
            {
                throw e1;
            }
            return rp;
        }

        #endregion

        #region  ==========  private functions  ==========

        /// <summary>
        /// Подготовка директорий и файлов
        /// </summary>
        [NumFunction(1)]
        private HeadDataPack PrepareCommand(string NamePref)
        {
            //  имя для всех файлов
            _FileName = string.Format("{0}{1}_{2}", NamePref, _Ico, DateTime.Now.ToString("yyMMddHHmmssfff"));
            //  проверяем и если надо создаём необходимые директории
            CheckOrCreateDirectory();
            // Создаём входной ini файл и возвращаем полное имя созданного файла
            CreateIni();

            return new HeadDataPack(_Ico);

        }

        public ReturnDocXml EndCommand(System.Xml.XmlDocument xd)
        {
            System.IO.FileStream fs = null;
            ReturnDocXml rp = new ReturnDocXml();
            try
            {
                xd.Save(_FileNameInp);
                //  Вызываем POHODA и передаём данные на выполнение
                if (!RunCmdPrograms())
                {
                    throw new Exception("В процессе вызава 'POHODA' возникла ошибка");
                }
                //  Читаем выходной файл от POHODA
                System.IO.FileInfo fi = new System.IO.FileInfo(_FileNameOut);
                if (fi.Exists)
                {
                    fs = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(responsePack));
                    rp.Packet = (responsePack)xs.Deserialize(fs);
                    fs.Close();
                }
                //  Копируем для диагностики файлы перед удалением
#if DEBUG
                CopyDiagFiles();
#endif
                //  Удаляем ненужные файлы
                DeleteFiles();

            }
            catch (Exception)
            {
                throw;
            }
            finally { fs?.Close(); }
            return rp;
        }

        /// <summary>
        /// Удаление ненужных файлов
        /// </summary>
        [NumFunction(2)]
        private void DeleteFiles()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(_FileNameIni);
            if (fi.Exists) fi.Delete();
            fi = new System.IO.FileInfo(_FileNameInp);
            if (fi.Exists) fi.Delete();
            fi = new System.IO.FileInfo(_FileNameOut);
            if (fi.Exists) fi.Delete();
        }

        [NumFunction(7)]
        private void CopyDiagFiles()
        {
            System.IO.DirectoryInfo di_copy = new System.IO.DirectoryInfo(System.IO.Path.Combine(_di_root.FullName, "Diag"));
            if (!di_copy.Exists) di_copy.Create();
            System.IO.FileInfo fi = new System.IO.FileInfo(_FileNameIni);
            if (fi.Exists)
            {
                fi.CopyTo(System.IO.Path.Combine(di_copy.FullName, _FileName + "_N" + fi.Extension));
            }
            fi = new System.IO.FileInfo(_FileNameInp);
            if (fi.Exists)
            {
                fi.CopyTo(System.IO.Path.Combine(di_copy.FullName, _FileName + "_I" + fi.Extension));
            }
            fi = new System.IO.FileInfo(_FileNameOut);
            if (fi.Exists)
            {
                fi.CopyTo(System.IO.Path.Combine(di_copy.FullName, _FileName + "_O" + fi.Extension));
            }
            DateTime dt = DateTime.Now.AddMonths(-1);
            System.IO.FileInfo[] fis = di_copy.GetFiles();
            foreach (System.IO.FileInfo fi1 in fis)
            {
                if (fi1.CreationTimeUtc.CompareTo(dt) > 0) continue;
                fi.Delete();
            }
        }


        /// <summary>
        /// проверяем и если надо создаём необходимые директории
        /// </summary>
        [NumFunction(3)]
        private void CheckOrCreateDirectory()
        {
            System.IO.DirectoryInfo fi = new System.IO.DirectoryInfo(_PathPublic);
            if (!fi.Exists) fi.Create();
            fi = new System.IO.DirectoryInfo(fi.FullName + @"\Xml");
            if (!fi.Exists) fi.Create();
            string s1 = fi.FullName + @"\Input";
            System.IO.DirectoryInfo fi_in = new System.IO.DirectoryInfo(s1);
            if (!fi_in.Exists) fi_in.Create();
            string s2 = fi.FullName + @"\Output";
            System.IO.DirectoryInfo fi_out = new System.IO.DirectoryInfo(s2);
            if (!fi_out.Exists) fi_out.Create();
            _di_root = new System.IO.DirectoryInfo(fi.FullName);
            _di_inp = new System.IO.DirectoryInfo(fi_in.FullName);
            _di_out = new System.IO.DirectoryInfo(fi_out.FullName);
        }

        /// <summary>
        /// Создаём входной ini файл и возвращаем полное имя созданного файла
        /// </summary>
        /// <returns></returns>
        [NumFunction(4)]
        private void CreateIni()
        {
            System.IO.FileStream fs = null;
            System.IO.BufferedStream bs = null;
            System.IO.StreamWriter sw = null;
            try
            {
                _FileNameIni = System.IO.Path.Combine(_di_root.FullName, _FileName + ".ini");
                fs = new System.IO.FileStream(_FileNameIni, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                bs = new System.IO.BufferedStream(fs);
                sw = new System.IO.StreamWriter(bs);
                sw.WriteLine(string.Format(@"[XML]"));
                _FileNameInp = System.IO.Path.Combine(_di_inp.FullName, _FileName + ".xml");
                sw.WriteLine(string.Format(@"input_xml=""{0}""", _FileNameInp));
                _FileNameOut = System.IO.Path.Combine(_di_out.FullName, _FileName + ".xml");
                sw.WriteLine(string.Format(@"response_xml=""{0}""", _FileNameOut));
                sw.WriteLine(string.Format(@"database={0}", _Base));
                sw.WriteLine(string.Format(@"check_duplicity=0"));
                sw.WriteLine(string.Format(@"format_output=1"));
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally
            {
                sw?.Close();
                bs?.Close();
                fs?.Close();
            }
            return;
        }

        /// <summary>
        /// Запускаем Pohoda  <POHODA.exe> /XML Username password <cesta-k-ini-souboru
        /// </summary>
        /// <param name="srv"></param>
        /// <param name="IniFile"></param>
        /// <returns></returns>
        [NumFunction(5)]
        private bool RunCmdPrograms()
        {
            bool b_End = false;
            string s_Arg = string.Format(@"/XML {0} {1} ""{2}""", _LogPohoda, _PassPublic, _FileNameIni);
            System.Diagnostics.ProcessStartInfo psiOpt = new System.Diagnostics.ProcessStartInfo(_PathPohoda)
            {
                Arguments = s_Arg
            };

            psiOpt.CreateNoWindow = true;
            psiOpt.ErrorDialog = false;
            psiOpt.RedirectStandardError = true;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psiOpt.UseShellExecute = false;

            System.Diagnostics.Process proc = new System.Diagnostics.Process
            {
                StartInfo = psiOpt
            };
            proc.OutputDataReceived += Proc_OutputDataReceived;
            try
            {
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
                b_End = true;
            }
            catch (Exception e1)
            {
                b_End = false;
                throw e1;
            }
            return b_End;
        }

        private string ReturnMessage;

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">/param>
        /// <returns></returns>
        [NumFunction(6)]
        private void Proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Data))
            {
                ReturnMessage = "OutputDataReceived - пуст.";
            }
            else
            {
                ReturnMessage = e.Data;
            }
        }

        #endregion
    }
}
