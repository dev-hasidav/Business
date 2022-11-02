using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.SyncAgent
{
    /// <summary>
    /// Доступ к свойствам программы
    /// </summary>
    [NumClass(14)]
    public class Setup
    {
        #region  ==========  Функции сохранения  ==========
        private static string str_NameSetupFile;
        private static string str_PathSetupFile;
        private static string str_FullFile;

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
                }
                else
                {
                    cl_Stpsrv = new stpsrv();
                    IsSave = true;
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

        #endregion

        #region  ==========  Вызов переменных   ==========

        /// <summary>
        /// Вызов свойст из динамического класса
        /// </summary>
        public static stpsrv cl_Stpsrv { set; get; }

        /// <summary>
        /// True - сохранить всойства в файл
        /// </summary>
        public static bool IsSave { get { return cl_Stpsrv.IsSave; } set { cl_Stpsrv.IsSave = value; } }

        /// <summary>
        /// Директория запуска сервиса
        /// </summary>
        public static string StartPath { get; set; }

        #region  ==========  Основное подключение  ==========

        /// <summary>
        /// Имя-Agent порта соединения с сервером
        /// </summary>
        public static string NameAgentPort { set; get; } = "SyncSrvAgentPort";

        /// <summary>
        /// Имя-Agent пространства имён соединения с сервером
        /// </summary>
        public static string NameAgentScope { set; get; } = "SyncSrvAgentScope";

        /// <summary>
        /// Порт-Agent соединения с сервером
        /// </summary>
        public static int PortAgent { set; get; } = 43242;

        #endregion

        #endregion
    }

    [Serializable]
    [NumClass(15)]
    public class stpsrv
    {
        public bool IsSave { set; get; } = false;
    }
}
