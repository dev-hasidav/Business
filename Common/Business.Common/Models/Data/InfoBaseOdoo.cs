using Business.Atributes;
using OdooRpc.CoreCLR.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [NumClass(39)]
    public class InfoBaseOdoo
    {
        public async static System.Threading.Tasks.Task<ResponseResult> CheckOdoo(Models.Servers Srv)
        {
            ResponseResult rr = new ResponseResult();
            OdooConnectionInfo cn = null;
            Npgsql.NpgsqlConnection cn_p = null;
            try
            {
                //  Проверка подключения к ODOO
                rr.Status = StatusMessage.In;
                cn = new OdooConnectionInfo
                {
                    Host = Srv.OdooHostIp,
                    Port = Srv.OdooPort,
                    IsSSL = false,
                    Database = Srv.OdooBase,
                    Username = Srv.OdooUser,
                    Password = Srv.OdooPassword
                };
                rr.ListMessage.Add("Start check Odoo.");
                rr.ListMessage.Add("Start authorization check Odoo.");
                OdooRpc.CoreCLR.Client.OdooRpcClient odoClient = new OdooRpc.CoreCLR.Client.OdooRpcClient(cn);
                if (odoClient == null)
                {
                    throw new Exception("Odoo client creattion fail");
                }
                try
                {
                    OdooVersionInfo inf = await odoClient.GetOdooVersion().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                await odoClient.Authenticate().ConfigureAwait(false);
                //ts.Start();
                long? lo = odoClient.SessionInfo.UserId;
                if (lo == null)
                {
                    rr.Status = StatusMessage.Er;
                    rr.Message = "The Authenticate Odoo attempt failed. Check settings.";
                    rr.ListMessage.Add("The Authenticate Odoo attempt failed. Check settings.");
                }
                else if (lo.Value != 0)
                {
                    rr.ListMessage.Add("Authenticate Odoo successful.");
                    //  Проверка подключения к ODOO закончилась успешно

                    //  Проверка подключения к PostgreSQL
                    rr.ListMessage.Add("Start check PoatgreSQL.");
                    cn_p = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                    cn_p.Open();
                    rr.ListMessage.Add("Authenticate PoatgreSQL successful.");

                    rr.ListMessage.Add("Checking your shared directory.");
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Srv.PublicPath);
                    if (di.Exists)
                    {
                        rr.Status = StatusMessage.Ok;
                        rr.Message = "Checking your shared directory - OK.";
                        rr.ListMessage.Add("Checking your shared directory - OK.");
                        rr.IsError = false;
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
                    rr.Status = StatusMessage.Er;
                    rr.Message = "The Authenticate Odoo attempt failed. Check settings.";
                    rr.ListMessage.Add("The Authenticate Odoo attempt failed. Check settings.");
                }
            }
            catch (System.Exception e1)
            {
                rr.Message = e1.Message;
                rr.Status = StatusMessage.Er;
                rr.ListMessage.Add(System.Reflection.MethodInfo.GetCurrentMethod().Name);
                rr.ListMessage.Add(e1.Message);
                FileEventLog.WriteErr(e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn_p?.Close(); }
            return rr;
        }
        public static ResponseResult CheckPostGerSQL(Models.Servers Srv)
        {
            ResponseResult rr = new ResponseResult();
            Npgsql.NpgsqlConnection cn_p = null;
            try
            {
                //  Проверка подключения к PostgreSQL
                rr.ListMessage.Add("Start check PoatgreSQL.");
                cn_p = new Npgsql.NpgsqlConnection(OdooScripts.GetConnect(Srv));
                cn_p.Open();
                rr.ListMessage.Add("Authenticate PoatgreSQL successful.");

                rr.ListMessage.Add("Checking your shared directory.");
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Srv.PublicPath);
                if (di.Exists)
                {
                    rr.Status = StatusMessage.Ok;
                    rr.Message = "Checking your shared directory - OK.";
                    rr.ListMessage.Add("Checking your shared directory - OK.");
                    rr.IsError = false;
                }
                else
                {
                    rr.Status = StatusMessage.Er;
                    rr.Message = "Checking your shared directory - ERROR.";
                    rr.ListMessage.Add("Checking your shared directory - ERROR.");
                }
            }
            catch (System.Exception e1)
            {
                rr.Message = e1.Message;
                rr.Status = StatusMessage.Er;
                rr.ListMessage.Add(System.Reflection.MethodInfo.GetCurrentMethod().Name);
                rr.ListMessage.Add(e1.Message);
                FileEventLog.WriteErr(e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn_p?.Close(); }
            return rr;
        }
    }
}
