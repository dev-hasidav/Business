using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Информация о юзере, пытающегося подключится к серверу
    /// </summary>
    [Serializable]
    [NumClass(8)]
    public class UserLog
    {
        public string Name { set; get; }
        public string Host { set; get; }
    }
}
