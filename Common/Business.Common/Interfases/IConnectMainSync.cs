using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = Business.Models;

namespace Business.Interfases
{
    public interface IConnectMainSync: IConnectMainSyncAgent
    {
        #region  ==========  Test-запросы  ==========

        /// <summary>
        /// Тестирование соединения Client-server
        /// </summary>
        /// <param name="n1"></param>
        /// <returns></returns>
        [NumFunction(1)]
        int TestServer(int n1);

        /// <summary>
        /// Тестирование соединения Client-server-SQL
        /// </summary>
        /// <param name="n1"></param>
        /// <returns></returns>
        [NumFunction(2)]
        bool TestSql();

        /// <summary>
        /// Пока не работает
        /// </summary>
        [NumFunction(3)]
        [System.Runtime.Remoting.Messaging.OneWay]
        void TestListener(RetTriggers ret);

        #endregion

        #region  ==========  Info my SQL Servers  ==========

        [NumFunction(5)]
        InfoSql GetPropertySqlMain();

        [NumFunction(6)]
        InfoSql SetPropertySqlMain(InfoSql sr);

        #endregion

        #region  ==========  Servers  ==========

        /// <summary>
        /// Добавить сервер в Main-базу
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(8)]
        ResponseResult AddServer(mod.Servers srv);

        /// <summary>
        /// Обновить сервер в Main-базе
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(9)]
        ResponseResult UpdateServer(mod.Servers srv);

        /// <summary>
        /// Удалить сервер в Main-базе
        /// </summary>
        /// <param name="srv"></param>
        /// <returns></returns>
        [NumFunction(10)]
        ResponseResult DelServer(mod.Servers srv);


        #endregion

        #region  ==========  Tasks-1  ==========

        /// <summary>
        /// Получить список задач из Main-базы
        /// </summary>
        /// <returns></returns>
        [NumFunction(11)]
        ResponseResult GetTasks();

        /// <summary>
        /// Получить 1 задачу
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NumFunction(33)]
        ResponseResult GetTask(int Id);

        /// <summary>
        /// Добавить задачу в Main-базу
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(12)]
        ResponseResult AddTask(mod.Task tsk);

        /// <summary>
        /// Обновить задачу в Main-базе
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(13)]
        ResponseResult UpdateTask(mod.Task tsk);

        /// <summary>
        /// Удалить задачу в Main-базе
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        [NumFunction(14)]
        ResponseResult DelTask(mod.Task tsk);

        #endregion

        #region  ==========  TasksLog  ==========

        /// <summary>
        /// Получить сообщения от сегодня до указанной даты
        /// </summary>
        /// <param name="dt">если NULL (по умолчанию) то за последнии 7 дней</param>
        /// <returns></returns>
        [NumFunction(30)]
        List<mod.TasksLog> GetTasksLog(int IdTask, DateTimeOffset? dt = null);

        #endregion

        #region  ==========  Run task triggers  ==========

        [NumFunction(31)]
        [System.Runtime.Remoting.Messaging.OneWay]
        void RunTaskTriggers(RetTriggers ret);

        [NumFunction(32)]
        [System.Runtime.Remoting.Messaging.OneWay]
        void RunTaskSchedule();
        #endregion
    }
}
