using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Models
{
    /// <summary>
    /// Пакет данных для создания контейнера (оболочки)
    /// </summary>
    [Serializable]
    public class HeadDataPack
    {
        public HeadDataPack(string Ico)
        {
            this.Ico = Ico;
        }

        /// <summary>
        /// Версия программы POGODA default - 2.0
        /// </summary>
        public string VersionProc { set; get; } = "2.0";

        /// <summary>
        /// default - Note QuerySrv
        /// </summary>
        public string Note { set; get; } = "Note QuerySrv";

        /// <summary>
        /// default - QuerySrv
        /// </summary>
        public string Application { set; get; } = "QuerySrv";

        /// <summary>
        /// default - 00000000
        /// </summary>
        public string Ico { set; get; } = "00000000";

        /// <summary>
        /// default - string.Format("dp-{0}", DateTimeOffset.Now.ToString("ddMMyyHHmmsszzz"));
        /// </summary>
        public string IdDataPack { set; get; } = string.Format("dp-{0}", DateTimeOffset.Now.ToString("ddMMyyHHmmss"));

        /// <summary>
        /// default - string.Format("dpi-{0}", DateTimeOffset.Now.ToString("ddMMyyHHmmsszzz"));
        /// </summary>
        public string IdDataPackItem { set; get; } = string.Format("dpi-{0}", DateTimeOffset.Now.ToString("ddMMyyHHmmss"));


        /// <summary>
        /// версия XML default - 1.0
        /// </summary>
        public string VersionXML { set; get; } = "1.0";
        /// <summary>
        /// Возможные значения - Windows-1250 (default), UTF-8, UTF-16,
        /// </summary>
        public string Encoding { set; get; } = "Windows-1250";
        /// <summary>
        /// no (default) , yes
        /// </summary>
        public string Standalone { set; get; } = "no";
    }
}
