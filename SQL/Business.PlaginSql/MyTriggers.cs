using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public class MyTriggers
{
    public static void EventTablePohoda()
    {
        SqlConnection cn = null;
        int _ok = 5683562;
        System.Net.Sockets.TcpClient tc = null;
        System.Net.Sockets.NetworkStream ns = null;
        System.IO.MemoryStream ms = null;
        System.Security.Cryptography.CryptoStream strim = null;
        System.Diagnostics.EventLog el = null;
        //string _SourceEvent = "PlaginSQL";  // "Application";    // "BusinessSyncSrv";
        string _Application = "Application";    // "BusinessSyncSrv";
        try
        {
            el = new System.Diagnostics.EventLog();
            el.Source = _Application;
            el.WriteEntry(string.Format("Trigger fired"), System.Diagnostics.EventLogEntryType.Information, 30, 1);

            Random r = new Random(DateTime.Now.Millisecond);
            cn = new SqlConnection("context connection=true");
            cn.Open();
            string s_getNew = "";
            //string s_getDel = "";
            SqlTriggerContext context = SqlContext.TriggerContext;
            switch (context.TriggerAction)
            {
                case TriggerAction.Insert:
                    s_getNew = @"select * from inserted";
                    break;
                case TriggerAction.Update:
                    //s_getNew = @"select * from inserted";
                    //s_getDel = @"select * from deleted";
                    //break;
                case TriggerAction.Delete:
                    //s_getDel = @"select * from deleted";
                    //break;
                default:
                    return;
            }
            if (string.IsNullOrWhiteSpace(s_getNew))
            {
                throw new Exception("Непонятная команда из триггера");
            }
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = s_getNew;
            int Id = (int)cm.ExecuteScalar();
            cm.CommandText = "SELECT * FROM sEventTriggers WHERE(Id = @Id)";
            System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
            pr.Value = Id;
            string Guid = "";
            string s_AddressMain = "";
            int IdRecord = 0;
            string Action = "";
            string s_NameTrigger = "";
            string s_NameTable = "";
            string s_NameBase = "";
            string s_NameServer = "";
            System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                Guid = dr["GuidTask"].ToString().Trim();
                s_AddressMain = dr["AddressMain"].ToString().Trim();
                IdRecord = (int)dr["IdRecord"];
                Action = dr["ActionTrigger"].ToString().Trim();
                s_NameTrigger = dr["NameTrigger"].ToString().Trim();
                s_NameTable = dr["NameTable"].ToString().Trim();
                s_NameBase = dr["NameBase"].ToString().Trim();
                s_NameServer = dr["NameServer"].ToString().Trim();
            }
            dr.Close();


            ///////////////////////////////////////////////////

            byte[] bb1 = new byte[511];
            r.NextBytes(bb1);
            int n1 = 0;

            // Status  Тип сообщения     End = 5, Sen = 6
            // 4
            bb1[4] = 6;

            //  CodeMess  Код message  _ok = 5683562
            // 10 - 19
            byte[] bb2 = BitConverter.GetBytes(_ok);
            for (n1 = 0; n1 < bb2.Length; n1++)
            {
                bb1[n1 + 10] = bb2[n1];
            }
            bb1[n1 + 10] = 0x00;
            // 20 - 29

            // Id записи в таблице sEventTriggers
            // 30 - 39
            bb2 = BitConverter.GetBytes(Id);
            for (n1 = 0; n1 < bb2.Length; n1++)
            {
                bb1[n1 + 30] = bb2[n1];
            }
            bb1[n1 + 30] = 0x00;
            // 40 - 49

            // NameServer  Имя сервера вызвавший срабатывания задачи
            // 50 - 99
            for (n1 = 0; n1 < s_NameServer.Length; n1++)
            {
                bb1[n1 + 50] = Convert.ToByte(s_NameServer[n1]);
            }
            bb1[n1 + 50] = 0x00;

            //  NameBase    Имя базы вызвавший срабатывания задачи
            // 100 - 149
            for (n1 = 0; n1 < s_NameBase.Length; n1++)
            {
                bb1[n1 + 100] = Convert.ToByte(s_NameBase[n1]);
            }
            bb1[n1 + 100] = 0x00;

            // NameTable   Имя таблицы вызвавший срабатывания задачи
            // 150 - 199
            for (n1 = 0; n1 < s_NameTable.Length; n1++)
            {
                bb1[n1 + 150] = Convert.ToByte(s_NameTable[n1]);
            }
            bb1[n1 + 150] = 0x00;

            // NameTrigger   Имя триггера вызвавший срабатывания задачи
            // 200 - 249
            for (n1 = 0; n1 < s_NameTrigger.Length; n1++)
            {
                bb1[n1 + 200] = Convert.ToByte(s_NameTrigger[n1]);
            }
            bb1[n1 + 200] = 0x00;

            // TriggerAction   Действие в таблице вызвавший срабатывания задачи ( I, U, D )
            // 250 - 299
            for (n1 = 0; n1 < Action.Length; n1++)
            {
                bb1[n1 + 250] = Convert.ToByte(Action[n1]);
            }
            bb1[n1 + 250] = 0x00;

            //  IdRecord   Id записи вызвавший срабатывания задачи
            // 300 - 349
            bb2 = BitConverter.GetBytes(IdRecord);
            for (n1 = 0; n1 < bb2.Length; n1++)
            {
                bb1[n1 + 300] = bb2[n1];
            }
            bb1[n1 + 300] = 0x00;

            // GuidTask   GUID задачи создавшей триггер
            // 350 - 399
            for (n1 = 0; n1 < Guid.Length; n1++)
            {
                bb1[n1 + 350] = Convert.ToByte(Guid[n1]);
            }
            bb1[n1 + 350] = 0x00;

            byte[] Key = new byte[] { 0x13, 0xff, 0x15, 0xb4, 0x59, 0x00, 0xde, 0xff,
                                      0x7a, 0xcd, 0xc4, 0x5e, 0x83, 0x30, 0xd1, 0xf3 ,
                                      0xbc, 0x6a, 0xc4, 0x33, 0x00, 0x45, 0x6d, 0x6e};
            byte[] IV = new byte[] { 0x5e, 0x45, 0x99, 0x0e, 0x7a, 0xed, 0xb1, 0xe0 };

            System.Security.Cryptography.TripleDESCryptoServiceProvider cs =
                        new System.Security.Cryptography.TripleDESCryptoServiceProvider
                        {
                            Key = Key,
                            IV = IV
                        };

            ///////

            ms = new System.IO.MemoryStream();
            strim = new System.Security.Cryptography.CryptoStream(ms, cs.CreateEncryptor(),
                System.Security.Cryptography.CryptoStreamMode.Write);
            strim.Write(bb1, 0, bb1.Length);
            strim.FlushFinalBlock();
            tc = new System.Net.Sockets.TcpClient();
            System.Net.IPAddress adr = System.Net.IPAddress.Parse(s_AddressMain);
            //System.Net.IPAddress adr = System.Net.IPAddress.Parse("192.168.88.6");
            tc.Connect(adr, 43241);
            ns = tc.GetStream();
            ms.Position = 0;
            ns.Write(ms.ToArray(), 0, (int)ms.Length);
            cm.CommandText = "UPDATE sEventTriggers SET IsTask = @IsTask, DateTrigger = @DateTrigger, DateClose = @DateClose WHERE(Id = @Id)";
            cm.Parameters.Clear();
            pr = cm.Parameters.Add("IsTask", System.Data.SqlDbType.Int);
            pr.Value = 2;
            pr = cm.Parameters.Add("DateTrigger", System.Data.SqlDbType.DateTimeOffset);
            pr.Value = DateTimeOffset.Now.ToUniversalTime();
            pr = cm.Parameters.Add("DateClose", System.Data.SqlDbType.DateTimeOffset);
            pr.Value = DateTimeOffset.Now.ToUniversalTime();
            pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
            pr.Value = Id;
            cm.ExecuteNonQuery();
        }
        catch (Exception e1)
        {
            el?.WriteEntry(string.Format("{1}: {0}", e1.Message, "EventTablePohoda"),
                System.Diagnostics.EventLogEntryType.Error, 30, 1);
        }
        finally
        {
            strim?.Close();
            ms?.Close();
            ns?.Close();
            tc?.Close();
            cn?.Close();
            ////
        }
    }
}
