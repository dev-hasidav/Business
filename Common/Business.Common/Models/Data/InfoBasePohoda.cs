using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    [Serializable]
    [NumClass(28)]
    public class InfoBasePohoda
    {
        #region  ==========  Property  ==========
        public int Id { set; get; }
        public int Rok { set; get; }
        public string Firma { set; get; }
        public string Jmeno { set; get; }
        public string Prijm { set; get; }
        public string ICO { set; get; }
        public string DIC { set; get; }
        public string Soubor { set; get; }
        /// <summary>
        /// Наличие базы на сервере
        /// </summary>
        public bool IsPresent { set; get; } = false;

        #endregion

        #region  ==========  Constructor  ==========

        public InfoBasePohoda()
        {
        }
        public InfoBasePohoda(Servers srv, int Id)
        {
            Load(srv, Id);
        }

        #endregion

        #region  ==========  Function  ==========

        [NumFunction(1)]
        public void Load(Servers srv, int Id)
        {
            this.Id = Id;
            _Load(srv);
        }
        [NumFunction(2)]
        private void _Load(Servers srv)
        {
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                string sys_base = string.Format("{0}_sys", GetPrifixPohoda(srv));
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, sys_base));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"SELECT ID, Rok, Firma, Jmeno, Prijm, ICO, DIC, Soubor " +
                    @" FROM Firma WHERE Id = @Id";
                System.Data.SqlClient.SqlParameter pr = cm.Parameters.Add("Id", System.Data.SqlDbType.Int);
                pr.Value = this.Id;
                System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.Id = (int)dr["Id"];
                    this.Rok = (int)dr["Rok"];
                    this.Firma = dr["Firma"] == DBNull.Value ? "" : dr["Firma"].ToString();
                    this.Jmeno = dr["Jmeno"] == DBNull.Value ? "" : dr["Jmeno"].ToString();
                    this.Prijm = dr["Prijm"] == DBNull.Value ? "" : dr["Prijm"].ToString();
                    this.ICO = dr["ICO"] == DBNull.Value ? "" : dr["ICO"].ToString();
                    this.DIC = dr["DIC"] == DBNull.Value ? "" : dr["DIC"].ToString();
                    this.Soubor = dr["Soubor"] == DBNull.Value ? "" : dr["Soubor"].ToString();
                }
                dr.Close();
                cm.CommandText = @"select COUNT(*) from sys.databases where name = @Name";
                cm.Parameters.Clear();
                pr = cm.Parameters.Add("Name", System.Data.SqlDbType.VarChar);
                pr.Value = this.Soubor;
                this.IsPresent = (int)cm.ExecuteScalar() != 0;
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(this, e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }
        }

        #endregion

        #region  ==========  Static  ==========

        public static List<InfoBasePohoda> GetBasePohoda(Servers srv) { 
            List<InfoBasePohoda> li = new List<InfoBasePohoda>();
            string sys_base = string.Format("{0}_sys", GetPrifixPohoda(srv));
            System.Data.SqlClient.SqlConnection cn =
                new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, sys_base));
            cn.Open();
            System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
            cm.Connection = cn;
            cm.CommandText = @"SELECT ID FROM Firma order by Rok DESC, Firma ";
            System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                InfoBasePohoda ibp = new InfoBasePohoda(srv, (int)dr["Id"]);
                if (ibp.IsPresent) li.Add(ibp);
            }
            dr.Close();
            cn?.Close();
            return li;
        }
        public static Dictionary<string, Models.ListTrigger> GetTriggersPohoda(Servers srv)
        {
            Dictionary<string, Models.ListTrigger> di = new Dictionary<string, Models.ListTrigger>();
            List<Models.InfoBasePohoda> li_base = Models.InfoBasePohoda.GetBasePohoda(srv);
            System.Data.SqlClient.SqlConnection cn = null;
            foreach (Models.InfoBasePohoda ibp in li_base)
            {
                try
                {
                    cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(srv, ibp.Soubor));
                    cn.Open();
                    string s1 = @"select [name], object_id, parent_id, OBJECT_NAME(parent_id) as NameParent, [type], [type_desc] from sys.triggers where name like 'Trg_%'";
                    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand(s1, cn);
                    System.Data.SqlClient.SqlDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        s1 = dr["name"].ToString();
                        int n1 = s1.IndexOf("_", 0);
                        s1 = s1.Insert(n1, "_" + ibp.Soubor);
                        if (!di.ContainsKey(s1))
                        {
                            Models.ListTrigger item = new Models.ListTrigger();
                            item.NameTrigger = dr["name"].ToString();
                            item.NameBase = ibp.Soubor;
                            item.NameTable = dr["NameParent"].ToString();
                            item.IsRemote = false;
                            di.Add(s1, item);
                        }
                    }
                    dr.Close();
                }
                catch (Exception e1)
                {
                    FileEventLog.WriteWarting(string.Format("Checking trigers {1}. Message: {0}", e1.Message, System.Reflection.MethodInfo.GetCurrentMethod()));
                }
                finally { cn?.Close(); }
            }
            return di;
        }

        public static string GetPrifixPohoda(Servers srv)
        {
            if (srv.Type == TypeServers.MsSql)
            {
                return GetPrifixPohoda(srv.SqlHostIp, srv.SqlUser, srv.SqlPassword);
            }
            else if (srv.Type == TypeServers.PohodaXml)
            {
                return GetPrifixPohoda(srv.PohodaSqlHostIp, srv.PohodaSqlUser, srv.PohodaSqlPassword);
            }
            else return "";
        }
        private static string GetPrifixPohoda(string Host, string Login, string Pass)
        {
            string pref = "";
            System.Data.SqlClient.SqlConnection cn = null;
            try
            {
                cn = new System.Data.SqlClient.SqlConnection(SqlScripts.GetConnectSQL(Host,
                    Login, Pass, null));
                cn.Open();
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = cn;
                cm.CommandText = @"select name from sys.databases where name like '%_sys'";
                object o1 = cm.ExecuteScalar();
                if (o1 != null)
                {
                    pref = o1.ToString();
                    string[] ss = pref.Split('_');
                    pref = ss[0];
                }
            }
            catch (Exception e1)
            {
                FileEventLog.WriteErr(e1, System.Reflection.MethodInfo.GetCurrentMethod());
            }
            finally { cn?.Close(); }

            return pref;
        }

        #endregion
    }
}
