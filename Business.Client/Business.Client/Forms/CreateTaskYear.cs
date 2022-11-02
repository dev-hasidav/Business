using Business.Models;
using Business.Models.Tables;
using Business.Models.Tasks;
using Business.Pohoda.Xml;
using Business.Setup;
using Business.Sync.Main;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Task = Business.Models.Task;

namespace Business.Client.Forms
{
    public partial class CreateTaskYear : Form
    {
        int CurrentYear = DateTime.Now.Year;
        
        public Setup SetupSettings { get; set; }

        List<Company> OdooCompanies = new List<Company>();
        List<Company> PohodaCompanies = new List<Company>();
        public CreateTaskYear()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        bool IsRowSelectedToSync(DataGridViewRow row)
        {
            var result = false;
            var srvOdoo = SetupSettings.ConnectedServers.FirstOrDefault(s => s.Type == TypeServers.Odoo && s.IsEnable == true);
            var srvPohoda = SetupSettings.ConnectedServers.FirstOrDefault(s => s.Type == TypeServers.PohodaXml && s.IsEnable == true);

            if (srvOdoo != null && srvPohoda != null)
            {
                var odooSelected = (bool)row.Cells[srvOdoo.Name].Value;
                var pohodaSelected = (bool)row.Cells[srvPohoda.Name].Value;

                if (odooSelected && pohodaSelected) result = true;
            }

            return result;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTaskName.Text))
            {
                MessageBox.Show("Please enter task name", "Error");
                return;
            }
			//var odooScripts = new OdooScripts();
            

			List<SyncTask> TasksToSync = new List<SyncTask>();
			var srvOdoo = SetupSettings.ConnectedServers.FirstOrDefault(s => s.Type == TypeServers.Odoo && s.IsEnable == true);
			//odooScripts.CheckAndCreateModelsColumns(srvOdoo);
			// create tasks to process
			SyncTask syncTask;
            string source = "";
            foreach (DataGridViewRow row in dataGridViewFirms.Rows)
            {
                if (IsRowSelectedToSync(row)) {
                    syncTask = new SyncTask();
                    syncTask.Tables.Add("Zakazky");
                    syncTask.server1 = SetupSettings.ConnectedServers.FirstOrDefault(s =>  s.Type == TypeServers.MsSql);
                    //set database for sql
                    source = row.Cells[1].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(source))
                    {
                        var split = source.Split('/');
                        if (split.Length == 2)
                        {
							syncTask.server1.SqlDataSource = split[0];
						}
					}
                    syncTask.server2 = SetupSettings.ConnectedServers.FirstOrDefault(s =>  s.Type == TypeServers.Odoo);
                    TasksToSync.Add(syncTask);
                }
            }

            // 
            ActionAll aa = new ActionAll();
            Task tsk;

			//Dictionary<string, List<Zakazka>> di_in = new Dictionary<string, List<Zakazka>>();
			//Dictionary<string, List<Zakazka>> di_out = null;
			//Dictionary<string, List<Objednalky>> di_in = new Dictionary<string, List<Objednalky>>();
			//Dictionary<string, List<Objednalky>> di_out = null;

			Dictionary<string, List<Factura>> di_in = new Dictionary<string, List<Factura>>();
			Dictionary<string, List<Factura>> di_out = null;

			//tsk = Task.GetTask(23);
			//;
			var mainSync = new MainSync();
            InfoSql inf = Setup.cl_Connect.GetPropertySqlMain();

            mainSync.SetPropertySqlMain(inf);
            var result = mainSync.GetTask(3);
            if (result.Status == StatusMessage.Ok)
            {
                tsk = result.Sender as Task;
                InfoBasePohoda ibp = tsk.Param.CollectionBaseSource[0];

                // pohoda
                //result = mainSync.GetListZakazka(TasksToSync[0].server1, ibp.Soubor, ibp.ICO, 0);
                //result = mainSync.GetListObjednalky(TasksToSync[0].server1, ibp.Soubor, ibp.ICO, 0);

                result = mainSync.GetListFactura(TasksToSync[0].server1).ConfigureAwait(false).GetAwaiter().GetResult();

				if (result.Status == StatusMessage.Ok)
                {
                    //var li_n = result.Sender as List<Objednalky>;
                    //foreach (Objednalky bn in li_n)
                    //{
                    //    if (string.IsNullOrWhiteSpace(bn.CompanyIco)) continue;
                    //    if (!di_in.TryGetValue(bn.CompanyIco, out List<Objednalky> li))
                    //    {
                    //        li = new List<Objednalky>();
                    //        di_in.Add(bn.CompanyIco, li);
                    //    }
                    //    li.Add(bn);
                    //}

                    //var li_n = result.Sender as List<Zakazka>;
                    //foreach (Zakazka bn in li_n)
                    //               {
                    //                   if (string.IsNullOrWhiteSpace(bn.CompanyIco)) continue;
                    //                   if (!di_in.TryGetValue(bn.CompanyIco, out List<Zakazka> li))
                    //                   {
                    //                       li = new List<Zakazka>();
                    //                       di_in.Add(bn.CompanyIco, li);
                    //                   }
                    //                   li.Add(bn);
                    //               }

                    var li_n = result.Sender as List<Factura>;
                    foreach (Factura bn in li_n)
                    {
                        if (string.IsNullOrWhiteSpace(bn.CompanyIco)) continue;
                        if (!di_in.TryGetValue(bn.CompanyIco, out List<Factura> li))
                        {
                            li = new List<Factura>();
                            di_in.Add(bn.CompanyIco, li);
                        }
                        li.Add(bn);
                    }
                }

				// odoo sync
				Console.WriteLine("odoo");
				var itemToSync = di_in[ibp.ICO][0];
                itemToSync.Srv = srvOdoo;
				//mainSync.CreateObjednalky(itemToSync, ibp.ICO);

				//mainSync.CreateZakazka(zakazka, ibp.ICO);
				//         result = mainSync.GetListZakazka(TasksToSync[0].server2, null, null, 0);
				//if (result.Status == StatusMessage.Ok)
				//         {

				//         }
				//aa.RunTaskSchedule(tsk);
			}
        }

        private void CreateTaskYear_Load(object sender, EventArgs e)
        {
            dataGridViewFirms.AutoGenerateColumns = false;
            lblTypeTask.Text = "Synchronization task - LOADING FIRMS...";
            SetDefaultView();
            timer1.Start();
            // get provider's list
            if (SetupSettings.ConnectedServers.Count() == 0)
            {
                MessageBox.Show("No Connected Servers", "Error");
                return;
            }
            
            foreach (var item in SetupSettings.ConnectedServers)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCheckBoxCell checkboxCell = new DataGridViewCheckBoxCell();
                checkboxCell.Value = true;
                row.Cells.Add(checkboxCell);
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Name });
                dataGridViewProviders.Rows.Add(row);

                // add column to datagrid
                DataGridViewCell checkboxColumn = new DataGridViewCheckBoxCell();
                dataGridViewFirms.Columns.Add(new DataGridViewColumn() { 
                    Name = item.Name,    
                    CellTemplate = checkboxColumn,
                });
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CurrentYear = ((DateTime)dateTimePicker1.Value).Year;
            SetDefaultView();
            timer1.Start();
            backgroundWorker1.RunWorkerAsync();
        }

        void SetDefaultView()
        {
            panelTables.Visible = false;
            dataGridViewFirms.Rows.Clear();
            progressBar1.Value = 0;
        }

        void CreateGridRow(Company item)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();

            // firm
            row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Name });

            // source
            var cell = new DataGridViewTextBoxCell() { Value = item.Tag };

            row.Cells.Add(cell);

            // year
            row.Cells.Add(new DataGridViewTextBoxCell { Value = CurrentYear });

            // sync settings
            DataGridViewCheckBoxCell checkboxCell;
            foreach (var server in SetupSettings.ConnectedServers)
            {
                checkboxCell = new DataGridViewCheckBoxCell();
                checkboxCell.Value = false;
                if ((server.Type == TypeServers.Odoo || server.Type == TypeServers.PohodaXml) && (item.Name.Contains("Develop"))) checkboxCell.Value = true;
                row.Cells.Add(checkboxCell);
            }
            dataGridViewFirms.Rows.Add(row);
        }
        void ShowCompaniesTable()
        {  
            List<Company> consolidated = new List<Company>();
            
            //update tag
            foreach (var item in PohodaCompanies)
            {
                item.Tag = $"{item.Soubor}/{item.Srv.Name}";

			}

            consolidated.AddRange(PohodaCompanies);
            Company company;
            foreach (var item in OdooCompanies)
            {
                // check if exists in consolidated, so update name
                // else just add new line
                company = consolidated.FirstOrDefault(i => i.Name == item.Name || (i.Partner.DIC != "" && item.Partner.DIC != "" &&  i.Partner.DIC == item.Partner.DIC ));
                if (company != null)
                {
					company.Tag = $"{company.Srv.Name}/{company.Base} | {item.Srv.Name}/{item.Base}";
				}
                else
                {
                    item.Tag = $"{item.Srv.Name}/{item.Base}";
					consolidated.Add(item);
				}
            }

            foreach (var item in consolidated)
            {
                CreateGridRow(item);
            }
			
		}
        async void FillBaseTable()
        {  
            List<Task<int>> stack = new List<Task<int>>();

            var taskOdooData = LoadCompaniesOdoo();
            var taskPohodaData = LoadCompaniesPohoda();

            stack.Add(taskOdooData);
            stack.Add(taskPohodaData);

            try
            {
                System.Threading.Tasks.Task.WaitAll(stack.ToArray());
            }
            catch(AggregateException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            await System.Threading.Tasks.Task.FromResult(0);
        }
        private async Task<int> LoadCompaniesPohoda()
        {
            var pohodaSrv = SetupSettings.ConnectedServers.FirstOrDefault(s => s.Type == TypeServers.PohodaXml && s.IsEnable == true);
            if (pohodaSrv != null)
            {
				//var mainSync = new MainSync();
				//ResponseResult rr = mainSync.GetListCompany(pohodaSrv, pohodaSrv.Name, "", 0);
				ResponseResult rr = Setup.cl_Connect.GetListCompany(pohodaSrv, pohodaSrv.Name, "", 0);
				if (rr.IsError)
                {
                    MessageBox.Show(rr.Message, "Error");
                    return 0;
                }

                PohodaCompanies = ((List<Company>)rr.Sender).Where( b => b.Rok == CurrentYear).ToList();
                await System.Threading.Tasks.Task.FromResult(PohodaCompanies.Count());
            }
            return 0;
        }
        private async Task<int> LoadCompaniesOdoo()
        {
            var odooSrv = SetupSettings.ConnectedServers.FirstOrDefault(s => s.Type == TypeServers.Odoo && s.IsEnable == true);
            if (odooSrv != null)
            {
                //var r = Setup.cl_Connect.CheckServers(odooSrv);
                var response = Setup.cl_Connect.GetListCompany(odooSrv, odooSrv.OdooBase, "", 0);
                //var mainSync = new MainSync();
                //var response = mainSync.GetListCompany(odooSrv, odooSrv.OdooBase, "", 0);
                if (response.IsError)
                {
                    MessageBox.Show(response.Message, "Error");
                    return 0;
                }
                OdooCompanies = (List<Company>)response.Sender;
                return await System.Threading.Tasks.Task.FromResult(OdooCompanies.Count());             
            }
            return 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value >= 100) progressBar1.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FillBaseTable();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblTypeTask.Text = "Synchronization task";
            timer1.Stop();
            progressBar1.Value = 100;
            ShowCompaniesTable();
            panelTables.Visible = true;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
