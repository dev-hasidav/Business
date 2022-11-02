namespace Business.Client.Forms
{
    partial class CreateTaskYear
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.chkCreateTaskRun = new System.Windows.Forms.CheckBox();
			this.lblTypeTask = new System.Windows.Forms.Label();
			this.txtTaskName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblYear = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dataGridViewFirms = new System.Windows.Forms.DataGridView();
			this.ColumnFirm = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewProviders = new System.Windows.Forms.DataGridView();
			this.ColumnChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBox14 = new System.Windows.Forms.CheckBox();
			this.checkBox13 = new System.Windows.Forms.CheckBox();
			this.checkBox12 = new System.Windows.Forms.CheckBox();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.panelTables = new System.Windows.Forms.Panel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.checkBox20 = new System.Windows.Forms.CheckBox();
			this.checkBox19 = new System.Windows.Forms.CheckBox();
			this.checkBox18 = new System.Windows.Forms.CheckBox();
			this.checkBox17 = new System.Windows.Forms.CheckBox();
			this.checkBox16 = new System.Windows.Forms.CheckBox();
			this.checkBox15 = new System.Windows.Forms.CheckBox();
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirms)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProviders)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panelTables.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkCreateTaskRun
			// 
			this.chkCreateTaskRun.AutoSize = true;
			this.chkCreateTaskRun.Location = new System.Drawing.Point(423, 44);
			this.chkCreateTaskRun.Name = "chkCreateTaskRun";
			this.chkCreateTaskRun.Size = new System.Drawing.Size(113, 17);
			this.chkCreateTaskRun.TabIndex = 29;
			this.chkCreateTaskRun.Text = "The task is active.";
			this.chkCreateTaskRun.UseVisualStyleBackColor = true;
			// 
			// lblTypeTask
			// 
			this.lblTypeTask.AutoSize = true;
			this.lblTypeTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTypeTask.ForeColor = System.Drawing.Color.Red;
			this.lblTypeTask.Location = new System.Drawing.Point(12, 6);
			this.lblTypeTask.Name = "lblTypeTask";
			this.lblTypeTask.Size = new System.Drawing.Size(201, 24);
			this.lblTypeTask.TabIndex = 39;
			this.lblTypeTask.Text = "Synchronization task";
			// 
			// txtTaskName
			// 
			this.txtTaskName.Location = new System.Drawing.Point(92, 42);
			this.txtTaskName.Name = "txtTaskName";
			this.txtTaskName.Size = new System.Drawing.Size(316, 20);
			this.txtTaskName.TabIndex = 28;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Name";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(860, 51);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 33);
			this.btnCancel.TabIndex = 36;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(860, 11);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 33);
			this.btnOk.TabIndex = 35;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(51, 80);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(29, 13);
			this.lblYear.TabIndex = 41;
			this.lblYear.Text = "Year";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(92, 80);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 42;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// dataGridViewFirms
			// 
			this.dataGridViewFirms.AllowUserToAddRows = false;
			this.dataGridViewFirms.AllowUserToDeleteRows = false;
			this.dataGridViewFirms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridViewFirms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFirms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFirm,
            this.ColumnSource,
            this.ColumnYear});
			this.dataGridViewFirms.Location = new System.Drawing.Point(12, 224);
			this.dataGridViewFirms.Name = "dataGridViewFirms";
			this.dataGridViewFirms.Size = new System.Drawing.Size(923, 150);
			this.dataGridViewFirms.TabIndex = 45;
			// 
			// ColumnFirm
			// 
			this.ColumnFirm.HeaderText = "Firm";
			this.ColumnFirm.Name = "ColumnFirm";
			this.ColumnFirm.Width = 51;
			// 
			// ColumnSource
			// 
			this.ColumnSource.HeaderText = "Source";
			this.ColumnSource.Name = "ColumnSource";
			this.ColumnSource.Width = 66;
			// 
			// ColumnYear
			// 
			this.ColumnYear.HeaderText = "Year";
			this.ColumnYear.Name = "ColumnYear";
			this.ColumnYear.Width = 54;
			// 
			// dataGridViewProviders
			// 
			this.dataGridViewProviders.AllowUserToAddRows = false;
			this.dataGridViewProviders.AllowUserToDeleteRows = false;
			this.dataGridViewProviders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewProviders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewProviders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnChecked,
            this.ColumnName});
			this.dataGridViewProviders.Location = new System.Drawing.Point(555, 32);
			this.dataGridViewProviders.Name = "dataGridViewProviders";
			this.dataGridViewProviders.Size = new System.Drawing.Size(299, 176);
			this.dataGridViewProviders.TabIndex = 46;
			// 
			// ColumnChecked
			// 
			this.ColumnChecked.FillWeight = 30.45685F;
			this.ColumnChecked.HeaderText = "";
			this.ColumnChecked.Name = "ColumnChecked";
			// 
			// ColumnName
			// 
			this.ColumnName.FillWeight = 169.5432F;
			this.ColumnName.HeaderText = "Name";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(552, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 47;
			this.label2.Text = "Servers";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(2, 714);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(941, 23);
			this.progressBar1.TabIndex = 48;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 205);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 13);
			this.label3.TabIndex = 49;
			this.label3.Text = "Firms to synchronize";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox7);
			this.groupBox1.Controls.Add(this.checkBox6);
			this.groupBox1.Controls.Add(this.checkBox5);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox4);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(16, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 179);
			this.groupBox1.TabIndex = 50;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Base";
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(6, 156);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(87, 17);
			this.checkBox7.TabIndex = 5;
			this.checkBox7.Text = "Predkontace";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(6, 133);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(98, 17);
			this.checkBox6.TabIndex = 4;
			this.checkBox6.Text = "Uctova Ostova";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(7, 110);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(51, 17);
			this.checkBox5.TabIndex = 3;
			this.checkBox5.Text = "Cities";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(6, 66);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(71, 17);
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Accounts";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(6, 87);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(62, 17);
			this.checkBox4.TabIndex = 3;
			this.checkBox4.Text = "Country";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(7, 43);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(56, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Banks";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(7, 20);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Users";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox10);
			this.groupBox2.Controls.Add(this.checkBox9);
			this.groupBox2.Controls.Add(this.checkBox8);
			this.groupBox2.Location = new System.Drawing.Point(16, 210);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 90);
			this.groupBox2.TabIndex = 51;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(6, 65);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(75, 17);
			this.checkBox10.TabIndex = 3;
			this.checkBox10.Text = "Internidokl";
			this.checkBox10.UseVisualStyleBackColor = true;
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(7, 42);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(71, 17);
			this.checkBox9.TabIndex = 2;
			this.checkBox9.Text = "Pokladna";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(7, 19);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(57, 17);
			this.checkBox8.TabIndex = 1;
			this.checkBox8.Text = "Banka";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(190, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 13);
			this.label4.TabIndex = 52;
			this.label4.Text = "TABLES TO SYNC";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBox14);
			this.groupBox3.Controls.Add(this.checkBox13);
			this.groupBox3.Controls.Add(this.checkBox12);
			this.groupBox3.Controls.Add(this.checkBox11);
			this.groupBox3.Location = new System.Drawing.Point(175, 25);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 114);
			this.groupBox3.TabIndex = 53;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "groupBox3";
			// 
			// checkBox14
			// 
			this.checkBox14.AutoSize = true;
			this.checkBox14.Location = new System.Drawing.Point(6, 87);
			this.checkBox14.Name = "checkBox14";
			this.checkBox14.Size = new System.Drawing.Size(71, 17);
			this.checkBox14.TabIndex = 4;
			this.checkBox14.Text = "Poptavky";
			this.checkBox14.UseVisualStyleBackColor = true;
			// 
			// checkBox13
			// 
			this.checkBox13.AutoSize = true;
			this.checkBox13.Location = new System.Drawing.Point(6, 66);
			this.checkBox13.Name = "checkBox13";
			this.checkBox13.Size = new System.Drawing.Size(65, 17);
			this.checkBox13.TabIndex = 3;
			this.checkBox13.Text = "Nabidky";
			this.checkBox13.UseVisualStyleBackColor = true;
			// 
			// checkBox12
			// 
			this.checkBox12.AutoSize = true;
			this.checkBox12.Location = new System.Drawing.Point(6, 43);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new System.Drawing.Size(83, 17);
			this.checkBox12.TabIndex = 2;
			this.checkBox12.Text = "Objednavky";
			this.checkBox12.UseVisualStyleBackColor = true;
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(6, 20);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(67, 17);
			this.checkBox11.TabIndex = 1;
			this.checkBox11.Text = "Zakazky";
			this.checkBox11.UseVisualStyleBackColor = true;
			// 
			// panelTables
			// 
			this.panelTables.Controls.Add(this.groupBox4);
			this.panelTables.Controls.Add(this.label4);
			this.panelTables.Controls.Add(this.groupBox1);
			this.panelTables.Controls.Add(this.groupBox3);
			this.panelTables.Controls.Add(this.groupBox2);
			this.panelTables.Location = new System.Drawing.Point(249, 380);
			this.panelTables.Name = "panelTables";
			this.panelTables.Size = new System.Drawing.Size(466, 328);
			this.panelTables.TabIndex = 54;
			this.panelTables.Visible = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.checkBox20);
			this.groupBox4.Controls.Add(this.checkBox19);
			this.groupBox4.Controls.Add(this.checkBox18);
			this.groupBox4.Controls.Add(this.checkBox17);
			this.groupBox4.Controls.Add(this.checkBox16);
			this.groupBox4.Controls.Add(this.checkBox15);
			this.groupBox4.Location = new System.Drawing.Point(175, 145);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 156);
			this.groupBox4.TabIndex = 55;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "groupBox4";
			// 
			// checkBox20
			// 
			this.checkBox20.AutoSize = true;
			this.checkBox20.Location = new System.Drawing.Point(6, 132);
			this.checkBox20.Name = "checkBox20";
			this.checkBox20.Size = new System.Drawing.Size(51, 17);
			this.checkBox20.TabIndex = 10;
			this.checkBox20.Text = "Mzdy";
			this.checkBox20.UseVisualStyleBackColor = true;
			// 
			// checkBox19
			// 
			this.checkBox19.AutoSize = true;
			this.checkBox19.Location = new System.Drawing.Point(6, 112);
			this.checkBox19.Name = "checkBox19";
			this.checkBox19.Size = new System.Drawing.Size(91, 17);
			this.checkBox19.TabIndex = 9;
			this.checkBox19.Text = "Personalistika";
			this.checkBox19.UseVisualStyleBackColor = true;
			// 
			// checkBox18
			// 
			this.checkBox18.AutoSize = true;
			this.checkBox18.Location = new System.Drawing.Point(6, 89);
			this.checkBox18.Name = "checkBox18";
			this.checkBox18.Size = new System.Drawing.Size(101, 17);
			this.checkBox18.TabIndex = 8;
			this.checkBox18.Text = "Ostatni zavazky";
			this.checkBox18.UseVisualStyleBackColor = true;
			// 
			// checkBox17
			// 
			this.checkBox17.AutoSize = true;
			this.checkBox17.Location = new System.Drawing.Point(6, 66);
			this.checkBox17.Name = "checkBox17";
			this.checkBox17.Size = new System.Drawing.Size(105, 17);
			this.checkBox17.TabIndex = 7;
			this.checkBox17.Text = "Ostatni poklavky";
			this.checkBox17.UseVisualStyleBackColor = true;
			// 
			// checkBox16
			// 
			this.checkBox16.AutoSize = true;
			this.checkBox16.Location = new System.Drawing.Point(6, 43);
			this.checkBox16.Name = "checkBox16";
			this.checkBox16.Size = new System.Drawing.Size(97, 17);
			this.checkBox16.TabIndex = 6;
			this.checkBox16.Text = "Presate factury";
			this.checkBox16.UseVisualStyleBackColor = true;
			// 
			// checkBox15
			// 
			this.checkBox15.AutoSize = true;
			this.checkBox15.Checked = true;
			this.checkBox15.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox15.Location = new System.Drawing.Point(6, 22);
			this.checkBox15.Name = "checkBox15";
			this.checkBox15.Size = new System.Drawing.Size(94, 17);
			this.checkBox15.TabIndex = 5;
			this.checkBox15.Text = "Vidane factury";
			this.checkBox15.UseVisualStyleBackColor = true;
			// 
			// backgroundWorker2
			// 
			this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
			// 
			// CreateTaskYear
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 741);
			this.Controls.Add(this.panelTables);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridViewProviders);
			this.Controls.Add(this.dataGridViewFirms);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.lblYear);
			this.Controls.Add(this.chkCreateTaskRun);
			this.Controls.Add(this.lblTypeTask);
			this.Controls.Add(this.txtTaskName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Name = "CreateTaskYear";
			this.Text = "Syncronization task";
			this.Load += new System.EventHandler(this.CreateTaskYear_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirms)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProviders)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.panelTables.ResumeLayout(false);
			this.panelTables.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkCreateTaskRun;
        private System.Windows.Forms.Label lblTypeTask;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewFirms;
        private System.Windows.Forms.DataGridView dataGridViewProviders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.Panel panelTables;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}