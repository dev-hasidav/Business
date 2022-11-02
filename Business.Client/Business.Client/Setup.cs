using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Client
{
    /// <summary>
    /// Доступ к свойствам программы
    /// </summary>
    [NumClass(10)]
    public class Setup
    {
        #region  ==========  Функции сохранения  ==========
        private static string str_NameSetupFile;
        private static string str_PathSetupFile;
        private static string str_FullFile;

        public List<Models.Servers> ConnectedServers = new List<Models.Servers>();
        public string OdooConnectConsoleApp { get; set; }

        /// <summary>
        /// Доступ к свойствам программы
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Name">Имя файла</param>
        public Setup(string Path, string Name)
        {
            str_NameSetupFile = Name;
            str_PathSetupFile = Path;
            LoadSetup();
        }

        private bool LoadSetup()
        {
            System.IO.FileStream fs = null;
            try
            {
                if (!System.IO.Directory.Exists(str_PathSetupFile)) System.IO.Directory.CreateDirectory(str_PathSetupFile);
                str_FullFile = str_PathSetupFile + @"\" + str_NameSetupFile;
                System.IO.FileInfo fi = new System.IO.FileInfo(str_FullFile);
                if (fi.Exists)
                {
                    fs = fi.OpenRead();
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(stpsrv));
                    cl_Stpsrv = (stpsrv)xs.Deserialize(fs);
					OdooConnectConsoleApp =  cl_Stpsrv.OdooConnectConsoleApp;
				}
                else
                {
                    cl_Stpsrv = new stpsrv();
                    cl_Stpsrv.IsSave = true;
                    Save();
                }
                return true;
            }
            catch (System.Exception e1)
            {
                throw e1;
            }
            finally
            {
                fs?.Close();
            }
        }

        /// <summary>
        /// Функция сохранения
        /// </summary>
        /// <returns></returns>
        public static bool SaveSetup()
        {
            System.IO.FileStream fs = null;
            try
            {
                cl_Stpsrv.IsSave = cl_Stpsrv.IsSave || SqlScripts.IsSave;
                if (!cl_Stpsrv.IsSave) return true;
                cl_Stpsrv.IsSave = false;
                fs = new System.IO.FileStream(str_FullFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(stpsrv));
                xs.Serialize(fs, cl_Stpsrv);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                fs?.Close();
            }
        }
        public bool Save()
        {
            System.IO.FileStream fs = null;
            try
            {
                if (cl_Stpsrv.IsSave)
                {
                    cl_Stpsrv.IsSave = false;
                    fs = new System.IO.FileStream(str_FullFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(stpsrv));
                    xs.Serialize(fs, cl_Stpsrv);
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                fs?.Close();
            }
        }

        #endregion

        #region  ==========  Вызов переменных   ==========

        /// <summary>
        /// Вызов свойст из динамического класса
        /// </summary>
        public static stpsrv cl_Stpsrv { set; get; }

        /// <summary>
        /// Директория запуска сервиса
        /// </summary>
        public static string StartPath { get; set; }

        /// <summary>
        /// Соединение с основным сервером
        /// </summary>
        public static bool IsConnectServer { get; set; } = false;

        /// <summary>
        /// Соединение с основным SQL сервером
        /// </summary>
        public static bool IsConnectSQL { get; set; } = false;

        #region  ==========  Основное подключение  ==========

        /// <summary>
        /// Имя основного пространства имён соединения с сервером
        /// </summary>
        public static string NameScope { set; get; } = "SyncSrvScope";

        private static Interfases.IConnectMainSync _cl_Connect = null;
        /// <summary>
        /// переменная подключения к основному серверу
        /// </summary>
        public static Interfases.IConnectMainSync cl_Connect
        {
            get
            {
                if(_cl_Connect == null)
                {
                    object o1;
                    Business.Setup.RemAssecc ra = new Business.Setup.RemAssecc();
                    bool b1 = ra.GetConnectClient(cl_Stpsrv.NameHost, cl_Stpsrv.Port,
                        NameScope, typeof(Interfases.IConnectMainSync), out o1);
                    if (b1) _cl_Connect = (Interfases.IConnectMainSync)o1;
                }
                return _cl_Connect;
            }
            set
            {
                _cl_Connect = value;
            }
        }

        #endregion

        #endregion
    }

    [Serializable]
    [NumClass(15)]
    public class stpsrv
    {
        public bool IsSave { set; get; } = false;

        /// <summary>
        /// Имя хоста, где находится основной сервер
        /// </summary>
        public string NameHost { set; get; } = "localhost";

        /// <summary>
        /// Порт основного соединения с сервером
        /// </summary>
        public int Port { set; get; } = 43240;
        public string OdooConnectConsoleApp { get; set; }
    }
}
