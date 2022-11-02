using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Atributes;

namespace Business
{
    [Serializable]
    [NumClass(23)]
    public class InfoPohoda
    {
        public string PathExe { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }

        public static ResponseResult CheckPohoda(Models.Servers srv)
        {
            ResponseResult rr = new ResponseResult();
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                rr.Status = StatusMessage.In;
                rr.ListMessage.Add("Start checking POHODA");
                rr.ListMessage.Add("Check path POHODA");
                string s1 = System.IO.Path.GetDirectoryName(srv.PohodaPath);
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(s1);
                if (di.Exists)
                {
                    rr.ListMessage.Add(string.Format("Check file {0}", srv.PohodaPath));
                    System.IO.FileInfo fi = new System.IO.FileInfo(srv.PohodaPath);
                    if (fi.Exists)
                    {
                        rr.ListMessage.Add(string.Format("Check file {0} - OK", srv.PohodaPath));

                        rr.ListMessage.Add("Start checking MSSQL");
                        cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, null));
                        cn.Open();
                        rr.ListMessage.Add("Connect MSSQL OK");
                        s1 = "select COUNT(*) from sys.databases";
                        System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand(s1, cn);
                        int n1 = (int)cm.ExecuteScalar();
                        rr.ListMessage.Add(string.Format("Count bases: {0}", n1));
                        rr.ListMessage.Add("Command MSSQL OK");


                        rr.ListMessage.Add("Checking your shared directory.");
                        di = new System.IO.DirectoryInfo(srv.PublicPath);
                        if (di.Exists)
                        {
                            rr.IsError = false;
                            rr.ListMessage.Add("Checking your shared directory - OK.");
                            rr.Status = StatusMessage.Ok;
                            rr.Message = "Checking POHODA OK";
                        }
                        else
                        {
                            rr.Status = StatusMessage.Er;
                            rr.Message = "Checking your shared directory - ERROR.";
                            rr.ListMessage.Add("Checking your shared directory - ERROR.");
                        }
                    }
                    else
                    {
                        rr.ListMessage.Add(string.Format("Check file {0} - ERROR", srv.PohodaPath));
                    }
                }
                else
                {
                    rr.ListMessage.Add(string.Format("Check path POHODA ERROR: {0}", s1));
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
