using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    [NumClass(27)]
    [Serializable]
    public class TasksLog
    {
        #region  ==========  Property  ==========
        public int Id { set; get; }
        public int IdTask { set; get; }
        public StatusMessage Status { set; get; } = StatusMessage.No;
        public string Message { set; get; }
        public DateTimeOffset Date { set; get; } = DateTimeOffset.Now;
        #endregion

        #region  ==========  Construcyor  ==========
        public TasksLog()
        {

        }
        public TasksLog(int Id)
        {
            Load(Id);
        }
        #endregion

        #region  ==========  Function  ==========
        [NumFunction(1)]
        public void Load(int Id)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"select * from sTasksLog where Id = @Id ";
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr.Value = Id;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["Id"];
                    this.IdTask = (int)dr["IdTask"];
                    this.Status = (StatusMessage)dr["Status"];
                    this.Message = dr["Message"] == DBNull.Value ? "" : dr["Message"].ToString();
                    this.Date = (DateTimeOffset)dr["Date"];
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
        }

        /// <summary>
        /// Создать новую запись в базе
        /// </summary>
        /// <returns></returns>
        [NumFunction(2)]
        public TasksLog Create()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"INSERT INTO sTasksLog " +
                    @" (IdTask, Status, Message, Date) " +
                    @" VALUES (@IdTask, @Status,  @Message, @Date)" +
                    @" ;SELECT Id FROM sTasksLog WHERE (Id = SCOPE_IDENTITY())";
                System.Data.SqlClient.SqlParameter pr_IdTask = cm.Parameters.Add("IdTask", System.Data.SqlDbType.Int);
                pr_IdTask.Value = this.IdTask;
                System.Data.SqlClient.SqlParameter pr_Status = cm.Parameters.Add("Status", System.Data.SqlDbType.Int);
                pr_Status.Value = (int)this.Status;
                System.Data.SqlClient.SqlParameter pr_Date = cm.Parameters.Add("Date", System.Data.SqlDbType.DateTimeOffset);
                pr_Date.Value = this.Date.ToUniversalTime();
                System.Data.SqlClient.SqlParameter pr_Message = cm.Parameters.Add("Message", System.Data.SqlDbType.VarChar);
                pr_Message.Value = this.Message;
                int n1 = (int)cm.ExecuteScalar();
                Load(n1);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Изменить существующую запись 
        /// </summary>
        /// <returns></returns>
        [NumFunction(3)]
        public TasksLog Update()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"UPDATE sTasksLog " +
                    @" SET IdTask = @IdTask, Status = @Status, Message = @Message, Date = @Date " +
                    @" WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                System.Data.SqlClient.SqlParameter pr_IdTask = cm.Parameters.Add("IdTask", System.Data.SqlDbType.Int);
                pr_IdTask.Value = this.IdTask;
                System.Data.SqlClient.SqlParameter pr_Status = cm.Parameters.Add("Status", System.Data.SqlDbType.Int);
                pr_Status.Value = (int)this.Status;
                System.Data.SqlClient.SqlParameter pr_Date = cm.Parameters.Add("Date", System.Data.SqlDbType.DateTimeOffset);
                pr_Date.Value = this.Date;
                System.Data.SqlClient.SqlParameter pr_Message = cm.Parameters.Add("Message", System.Data.SqlDbType.VarChar);
                pr_Message.Value = this.Message;
                cm.ExecuteNonQuery();
                Load(this.Id);
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return this;
        }

        /// <summary>
        /// Удалить существующую запись 
        /// </summary>
        /// <returns></returns>
        [NumFunction(4)]
        public void Delete()
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"DELETE FROM sTasksLog WHERE (Id = @Id)";
                System.Data.SqlClient.SqlParameter pr_Id = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr_Id.Value = this.Id;
                cm.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
                throw e1;
            }
            finally { cn?.Close(); }
            return;
        }
        #endregion

        #region  ==========  static  Function  ==========

        /// <summary>
        /// Получить сообщения от сегодня до указанной даты
        /// </summary>
        /// <param name="dt">если NULL (по умолчанию) то за последнии 7 дней</param>
        /// <returns></returns>
        public static List<TasksLog> GetTasksLog(int IdTask, DateTimeOffset? dt = null)
        {
            List<TasksLog> li = new List<TasksLog>();
            if (dt == null) dt = DateTimeOffset.Now.ToUniversalTime().AddDays(-7);
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT Id FROM sTasksLog where (IdTask = @IdTask) AND ([Date] >= @Date) ORDER BY Date DESC, Id DESC ";
                System.Data.SqlClient.SqlParameter pr_IdTask = cm.Parameters.Add("IdTask", System.Data.SqlDbType.Int);
                pr_IdTask.Value = IdTask;
                System.Data.SqlClient.SqlParameter pr_Date = cm.Parameters.Add("Date", System.Data.SqlDbType.DateTimeOffset);
                pr_Date.Value = dt.Value;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        li.Add(new TasksLog((int)dr["Id"]));
                    }
                }
                dr?.Close();
                int n11 = 70;
                if (li.Count <= n11)
                {
                    li.Clear();
                    cm.CommandText = string.Format(@"SELECT TOP({0}) Id FROM sTasksLog where (IdTask = @IdTask) ORDER BY Date DESC, Id DESC ", n11);
                    cm.Parameters.Remove(pr_Date);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        li.Add(new TasksLog((int)dr["Id"]));
                    }
                    dr?.Close();
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally { cn?.Close(); }

            return li;
        }

        /// <summary>
        /// Получить сообщения от сегодня до указанной даты
        /// </summary>
        /// <param name="stat">если 'No' то только сообщения с ошибками</param>
        /// <param name="dt">если NULL (по умолчанию) то за последнии 7 дней</param>
        /// <returns></returns>
        public static List<TasksLog> GetTasksLog(int IdTask, DateTimeOffset? dt = null, StatusMessage stat = StatusMessage.No)
        {
            List<TasksLog> li = new List<TasksLog>();
            if (dt == null) dt = DateTimeOffset.Now.AddDays(-7);
            if (stat == StatusMessage.No) stat = StatusMessage.Er;
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQLMain());
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT Id FROM sTasksLog where (IdTask = @IdTask) AND (Status = @Status) AND ([Date] >= @Date) ORDER BY Date DESC";
                System.Data.SqlClient.SqlParameter pr_IdTask = cm.Parameters.Add("IdTask", System.Data.SqlDbType.Int);
                pr_IdTask.Value = IdTask;
                System.Data.SqlClient.SqlParameter pr_Date = cm.Parameters.Add("Date", System.Data.SqlDbType.DateTimeOffset);
                pr_Date.Value = dt.Value;
                System.Data.SqlClient.SqlParameter pr_Status = cm.Parameters.Add("Status", System.Data.SqlDbType.Int);
                pr_Status.Value = stat;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    li.Add(new TasksLog((int)dr["Id"]));
                }
                dr?.Close();
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally { cn?.Close(); }

            return li;
        }
        #endregion
    }
}
