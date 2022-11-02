using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable]
    [NumClass(22)]
    public class InfoSql
    {
        public int Id { set; get; }
        public string NameServerOrIp { set; get; }
        public int Port { set; get; } = 1433;
        public string User { set; get; }
        public string Password { set; get; }
        public string Base { set; get; }
        public static ResponseResult CheckSql(Models.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                rr.Status = StatusMessage.In;
                rr.ListMessage.Add("Start checking MSSQL");
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, null));
                cn.Open();
                rr.ListMessage.Add("Connect MSSQL OK");
                string s1 = "select COUNT(*) from sys.databases";
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand(s1, cn);
                int n1 = (int)cm.ExecuteScalar();
                rr.ListMessage.Add(string.Format("Count bases: {0}", n1));
                rr.ListMessage.Add("Command MSSQL OK");
                rr.ListMessage.Add("Checking your shared directory.");
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(srv.PublicPath);
                if (di.Exists)
                {
                    rr.ListMessage.Add("Checking your shared directory - OK.");
                    rr.IsError = false;
                    rr.Status = StatusMessage.Ok;
                    rr.Message = "Checking MSSQL OK";
                }
                else
                {
                    rr.Status = StatusMessage.Er;
                    rr.Message = "Checking your shared directory - ERROR.";
                    rr.ListMessage.Add("Checking your shared directory - ERROR.");
                }
            }
            catch (Exception e1)
            {
                rr.Message = e1.Message;
                rr.Status = StatusMessage.Er;
                rr.ListMessage.Add(System.Reflection.MethodInfo.GetCurrentMethod().Name);
                rr.ListMessage.Add(e1.Message);
                FileEventLog.WriteErr(e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally
            {
                cn?.Close();
            }
            return rr;
        }
    }
}
