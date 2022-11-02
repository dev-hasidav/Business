using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Класс ответов из сервера или агента.
    /// </summary>
    [Serializable]
    public class ResponseResult
    {
        /// <summary>
        /// true - возникла ошибка, false - ощибки нет. (default - 'true')
        /// </summary>
        public bool IsError { set; get; } = true;
        /// <summary>
        /// Более конкретная информация о сообщение (default - 'No')
        /// </summary>
        public StatusMessage Status { set; get; } = StatusMessage.No;
        /// <summary>
        /// Сообщение (default - "All error")
        /// </summary>
        public string Message { set; get; } = "All error";
        /// <summary>
        /// Список сообщений
        /// </summary>
        public List<string> ListMessage { set; get; } = new List<string>();
        /// <summary>
        /// Номер сообщений
        /// </summary>
        public int Number { set; get; } = 0;
        /// <summary>
        /// обьбкт - отправляемый для получения
        /// </summary>
        public object Sender { set; get; }
    }
}
