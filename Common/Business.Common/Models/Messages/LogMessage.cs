using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Логирование операций в базе данных
    /// </summary>
    [Serializable]
    [NumClass(6)]
    public class LogMessage
    {
        #region  ==========  Property  ==========

        /// <summary>
        /// id записи
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// Имя записи
        /// </summary>
        public string Login { set; get; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { set; get; }
        /// <summary>
        /// Хост, инициирующий сообщение
        /// </summary>
        public string Host { set; get; }
        /// <summary>
        /// Статус сообщения
        /// </summary>
        public StatusMessage Status { set; get; } = StatusMessage.No;
        /// <summary>
        /// Имя функции
        /// </summary>
        public string Func { set; get; }
        /// <summary>
        /// Строка
        /// </summary>
        public int Rw { set; get; } = 0;
        /// <summary>
        /// Колонка
        /// </summary>
        public int Cl { set; get; } = 0;
        /// <summary>
        /// Номер класса
        /// </summary>
        public int Cs { set; get; } = 0;
        /// <summary>
        /// Номер функции
        /// </summary>
        public int Fn { set; get; } = 0;
        /// <summary>
        /// Номер ошибки или сообщения
        /// </summary>
        public int Nu { set; get; } = 0;
        /// <summary>
        /// Цепочка функций
        /// </summary>
        public string ChainOfFunctions { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset DateCreate { set; get; } = DateTimeOffset.Now;

        #endregion

        #region  ==========  Function  ==========

        [NumFunction(1)]
        public void Create()
        {
            System.Data.SqlClient.SqlConnection Conn = null;
            try
            {
                Conn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                Conn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand
                {
                    Connection = Conn,
                    CommandText = @"INSERT INTO sLogMessage " +
                    @" (Login, Text, Host, IPHost, Status, Func, Rw, Cl, Cs, Fn, Nu, ChainOfFunctions) " +
                    @" VALUES (@Login, @Text, @Host, @IPHost, @Status, @Func, @Rw, @Cl, @Cs, @Fn, @Nu, @ChainOfFunctions)"
                };
                System.Data.SqlClient.SqlParameter pr_Login = cm.Parameters.Add("Login", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Login)) pr_Login.Value = "-- No Login --";
                else pr_Login.Value = this.Login;
                System.Data.SqlClient.SqlParameter pr_Text = cm.Parameters.Add("Text", System.Data.SqlDbType.VarChar);
                pr_Text.Value = string.IsNullOrWhiteSpace(this.Text) ? "---" : this.Text;
                System.Data.SqlClient.SqlParameter pr_Host = cm.Parameters.Add("Host", System.Data.SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter pr_IPHost = cm.Parameters.Add("IPHost", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Host))
                {
                    pr_IPHost.Value = pr_Host.Value = DBNull.Value;
                }
                else
                {
                    pr_Host.Value = this.Host;
                    System.Net.IPAddress[] ip = System.Net.Dns.GetHostAddresses(this.Host);
                    string s1 = "";
                    foreach (System.Net.IPAddress add in ip)
                    {
                        s1 += string.Format("{0}, ", add.ToString());
                    }
                    pr_IPHost.Value = s1.Trim();
                }
                System.Data.SqlClient.SqlParameter pr_Status = cm.Parameters.Add("Status", System.Data.SqlDbType.Int);
                pr_Status.Value = (int)this.Status;
                System.Data.SqlClient.SqlParameter pr_Func = cm.Parameters.Add("Func", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.Func)) pr_Func.Value = DBNull.Value;
                else pr_Func.Value = this.Func;
                System.Data.SqlClient.SqlParameter pr_Rw = cm.Parameters.Add("Rw", System.Data.SqlDbType.Int);
                pr_Rw.Value = (int)this.Rw;
                System.Data.SqlClient.SqlParameter pr_Cl = cm.Parameters.Add("Cl", System.Data.SqlDbType.Int);
                pr_Cl.Value = (int)this.Cl;
                System.Data.SqlClient.SqlParameter pr_Cs = cm.Parameters.Add("Cs", System.Data.SqlDbType.Int);
                pr_Cs.Value = (int)this.Cs;
                System.Data.SqlClient.SqlParameter pr_Fn = cm.Parameters.Add("Fn", System.Data.SqlDbType.Int);
                pr_Fn.Value = (int)this.Fn;
                System.Data.SqlClient.SqlParameter pr_Nu = cm.Parameters.Add("Nu", System.Data.SqlDbType.Int);
                pr_Nu.Value = (int)this.Nu;
                System.Data.SqlClient.SqlParameter pr_ChainOfFunctions = cm.Parameters.Add("ChainOfFunctions", System.Data.SqlDbType.VarChar);
                if (string.IsNullOrWhiteSpace(this.ChainOfFunctions)) pr_ChainOfFunctions.Value = DBNull.Value;
                else pr_ChainOfFunctions.Value = this.ChainOfFunctions;
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                Conn?.Close();
            }
            return;
        }

        [NumFunction(2)]
        public override string ToString()
        {
            return string.Format("{0}, {1}, с:{2}-f:{3}-r:{4}-c:{5}-n:{6}, {7}, {8}, {9} ",
                this.Login,
                this.Text,
                this.Cs,
                this.Fn,
                this.Rw,
                this.Cl,
                this.Nu,
                this.Func,
                this.ChainOfFunctions,
                this.Host
                );
        }

        #endregion
    }
}
