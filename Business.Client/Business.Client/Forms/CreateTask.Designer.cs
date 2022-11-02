namespace Business.Client.Forms
{
    partial class CreateTask
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCreateTaskName = new System.Windows.Forms.TextBox();
            this.cmbCreateTaskAction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCreateTaskRun = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbCreateTaskDataSource = new System.Windows.Forms.ComboBox();
            this.cmbCreateTaskDestimation = new System.Windows.Forms.ComboBox();
            this.lblTypeTask = new System.Windows.Forms.Label();
            this.lblChilden = new System.Windows.Forms.Label();
            this.lstSServer = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstSList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstDList = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Base = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstDServer = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lnkSchedule = new System.Windows.Forms.LinkLabel();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.btnDelD = new System.Windows.Forms.Button();
            this.btnAddD = new System.Windows.Forms.Button();
            this.btnDelS = new System.Windows.Forms.Button();
            this.btnAddS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(857, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 33);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(857, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtCreateTaskName
            // 
            this.txtCreateTaskName.Location = new System.Drawing.Point(89, 39);
            this.txtCreateTaskName.Name = "txtCreateTaskName";
            this.txtCreateTaskName.Size = new System.Drawing.Size(316, 20);
            this.txtCreateTaskName.TabIndex = 0;
            // 
            // cmbCreateTaskAction
            // 
            this.cmbCreateTaskAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreateTaskAction.FormattingEnabled = true;
            this.cmbCreateTaskAction.Location = new System.Drawing.Point(89, 75);
            this.cmbCreateTaskAction.Name = "cmbCreateTaskAction";
            this.cmbCreateTaskAction.Size = new System.Drawing.Size(202, 21);
            this.cmbCreateTaskAction.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Action";
            // 
            // chkCreateTaskRun
            // 
            this.chkCreateTaskRun.AutoSize = true;
            this.chkCreateTaskRun.Location = new System.Drawing.Point(433, 42);
            this.chkCreateTaskRun.Name = "chkCreateTaskRun";
            this.chkCreateTaskRun.Size = new System.Drawing.Size(113, 17);
            this.chkCreateTaskRun.TabIndex = 1;
            this.chkCreateTaskRun.Text = "The task is active.";
            this.chkCreateTaskRun.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 121);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 11;
            this.label23.Text = "Data source";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(569, 121);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "Destination";
            // 
            // cmbCreateTaskDataSource
            // 
            this.cmbCreateTaskDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreateTaskDataSource.FormattingEnabled = true;
            this.cmbCreateTaskDataSource.Location = new System.Drawing.Point(89, 117);
            this.cmbCreateTaskDataSource.Name = "cmbCreateTaskDataSource";
            this.cmbCreateTaskDataSource.Size = new System.Drawing.Size(233, 21);
            this.cmbCreateTaskDataSource.TabIndex = 3;
            this.cmbCreateTaskDataSource.SelectedIndexChanged += new System.EventHandler(this.cmbCreateTaskDataSource_SelectedIndexChanged);
            // 
            // cmbCreateTaskDestimation
            // 
            this.cmbCreateTaskDestimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreateTaskDestimation.FormattingEnabled = true;
            this.cmbCreateTaskDestimation.Location = new System.Drawing.Point(636, 117);
            this.cmbCreateTaskDestimation.Name = "cmbCreateTaskDestimation";
            this.cmbCreateTaskDestimation.Size = new System.Drawing.Size(233, 21);
            this.cmbCreateTaskDestimation.TabIndex = 6;
            this.cmbCreateTaskDestimation.SelectedIndexChanged += new System.EventHandler(this.cmbCreateTaskDestimation_SelectedIndexChanged);
            // 
            // lblTypeTask
            // 
            this.lblTypeTask.AutoSize = true;
            this.lblTypeTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeTask.ForeColor = System.Drawing.Color.Red;
            this.lblTypeTask.Location = new System.Drawing.Point(220, 0);
            this.lblTypeTask.Name = "lblTypeTask";
            this.lblTypeTask.Size = new System.Drawing.Size(112, 24);
            this.lblTypeTask.TabIndex = 15;
            this.lblTypeTask.Text = "Parent task";
            // 
            // lblChilden
            // 
            this.lblChilden.AutoSize = true;
            this.lblChilden.Location = new System.Drawing.Point(508, 10);
            this.lblChilden.Name = "lblChilden";
            this.lblChilden.Size = new System.Drawing.Size(41, 13);
            this.lblChilden.TabIndex = 27;
            this.lblChilden.Text = "label19";
            // 
            // lstSServer
            // 
            this.lstSServer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader8});
            this.lstSServer.FullRowSelect = true;
            this.lstSServer.GridLines = true;
            this.lstSServer.HideSelection = false;
            this.lstSServer.Location = new System.Drawing.Point(22, 164);
            this.lstSServer.Name = "lstSServer";
            this.lstSServer.Size = new System.Drawing.Size(380, 119);
            this.lstSServer.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstSServer.TabIndex = 29;
            this.lstSServer.UseCompatibleStateImageBehavior = false;
            this.lstSServer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Year";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Firma";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Base";
            this.columnHeader8.Width = 200;
            // 
            // lstSList
            // 
            this.lstSList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader9});
            this.lstSList.FullRowSelect = true;
            this.lstSList.GridLines = true;
            this.lstSList.HideSelection = false;
            this.lstSList.Location = new System.Drawing.Point(22, 289);
            this.lstSList.Name = "lstSList";
            this.lstSList.Size = new System.Drawing.Size(380, 90);
            this.lstSList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstSList.TabIndex = 30;
            this.lstSList.UseCompatibleStateImageBehavior = false;
            this.lstSList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Year";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Firma";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Base";
            this.columnHeader9.Width = 200;
            // 
            // lstDList
            // 
            this.lstDList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader7,
            this.Base});
            this.lstDList.FullRowSelect = true;
            this.lstDList.GridLines = true;
            this.lstDList.HideSelection = false;
            this.lstDList.Location = new System.Drawing.Point(503, 290);
            this.lstDList.Name = "lstDList";
            this.lstDList.Size = new System.Drawing.Size(380, 90);
            this.lstDList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstDList.TabIndex = 32;
            this.lstDList.UseCompatibleStateImageBehavior = false;
            this.lstDList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Year";
            this.columnHeader11.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Firma";
            this.columnHeader7.Width = 150;
            // 
            // Base
            // 
            this.Base.Text = "Base";
            this.Base.Width = 200;
            // 
            // lstDServer
            // 
            this.lstDServer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader3});
            this.lstDServer.FullRowSelect = true;
            this.lstDServer.GridLines = true;
            this.lstDServer.HideSelection = false;
            this.lstDServer.Location = new System.Drawing.Point(503, 164);
            this.lstDServer.Name = "lstDServer";
            this.lstDServer.Size = new System.Drawing.Size(380, 119);
            this.lstDServer.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstDServer.TabIndex = 31;
            this.lstDServer.UseCompatibleStateImageBehavior = false;
            this.lstDServer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Year";
            this.columnHeader10.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Firma";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Base";
            this.columnHeader3.Width = 200;
            // 
            // lnkSchedule
            // 
            this.lnkSchedule.AutoSize = true;
            this.lnkSchedule.Location = new System.Drawing.Point(19, 383);
            this.lnkSchedule.Name = "lnkSchedule";
            this.lnkSchedule.Size = new System.Drawing.Size(52, 13);
            this.lnkSchedule.TabIndex = 37;
            this.lnkSchedule.TabStop = true;
            this.lnkSchedule.Text = "Schedule";
            this.lnkSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSchedule_LinkClicked);
            // 
            // txtSchedule
            // 
            this.txtSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchedule.Location = new System.Drawing.Point(12, 399);
            this.txtSchedule.Multiline = true;
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.ReadOnly = true;
            this.txtSchedule.Size = new System.Drawing.Size(923, 229);
            this.txtSchedule.TabIndex = 38;
            // 
            // btnDelD
            // 
            this.btnDelD.Image = global::Business.Client.Properties.Resources.Up;
            this.btnDelD.Location = new System.Drawing.Point(890, 290);
            this.btnDelD.Name = "btnDelD";
            this.btnDelD.Size = new System.Drawing.Size(47, 52);
            this.btnDelD.TabIndex = 8;
            this.btnDelD.Text = "Del";
            this.btnDelD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelD.UseVisualStyleBackColor = true;
            this.btnDelD.Click += new System.EventHandler(this.btnDelD_Click);
            // 
            // btnAddD
            // 
            this.btnAddD.Image = global::Business.Client.Properties.Resources.Down;
            this.btnAddD.Location = new System.Drawing.Point(890, 231);
            this.btnAddD.Name = "btnAddD";
            this.btnAddD.Size = new System.Drawing.Size(47, 52);
            this.btnAddD.TabIndex = 7;
            this.btnAddD.Text = "Add";
            this.btnAddD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddD.UseVisualStyleBackColor = true;
            this.btnAddD.Click += new System.EventHandler(this.btnAddD_Click);
            // 
            // btnDelS
            // 
            this.btnDelS.Image = global::Business.Client.Properties.Resources.Up;
            this.btnDelS.Location = new System.Drawing.Point(408, 289);
            this.btnDelS.Name = "btnDelS";
            this.btnDelS.Size = new System.Drawing.Size(47, 52);
            this.btnDelS.TabIndex = 5;
            this.btnDelS.Text = "Del";
            this.btnDelS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelS.UseVisualStyleBackColor = true;
            this.btnDelS.Click += new System.EventHandler(this.btnDelS_Click);
            // 
            // btnAddS
            // 
            this.btnAddS.Image = global::Business.Client.Properties.Resources.Down;
            this.btnAddS.Location = new System.Drawing.Point(408, 231);
            this.btnAddS.Name = "btnAddS";
            this.btnAddS.Size = new System.Drawing.Size(47, 52);
            this.btnAddS.TabIndex = 4;
            this.btnAddS.Text = "Add";
            this.btnAddS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddS.UseVisualStyleBackColor = true;
            this.btnAddS.Click += new System.EventHandler(this.btnAddS_Click);
            // 
            // CreateTask
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(943, 640);
            this.ControlBox = false;
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.lnkSchedule);
            this.Controls.Add(this.btnDelD);
            this.Controls.Add(this.btnAddD);
            this.Controls.Add(this.btnDelS);
            this.Controls.Add(this.btnAddS);
            this.Controls.Add(this.lstDList);
            this.Controls.Add(this.lstDServer);
            this.Controls.Add(this.lstSList);
            this.Controls.Add(this.lstSServer);
            this.Controls.Add(this.lblChilden);
            this.Controls.Add(this.chkCreateTaskRun);
            this.Controls.Add(this.lblTypeTask);
            this.Controls.Add(this.cmbCreateTaskDestimation);
            this.Controls.Add(this.cmbCreateTaskDataSource);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCreateTaskAction);
            this.Controls.Add(this.txtCreateTaskName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CreateTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateTask";
            this.Load += new System.EventHandler(this.CreateTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCreateTaskName;
        private System.Windows.Forms.ComboBox cmbCreateTaskAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCreateTaskRun;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbCreateTaskDataSource;
        private System.Windows.Forms.ComboBox cmbCreateTaskDestimation;
        private System.Windows.Forms.Label lblTypeTask;
        private System.Windows.Forms.Label lblChilden;
        private System.Windows.Forms.ListView lstSServer;
        private System.Windows.Forms.ListView lstSList;
        private System.Windows.Forms.ListView lstDList;
        private System.Windows.Forms.ListView lstDServer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader Base;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnAddS;
        private System.Windows.Forms.Button btnDelS;
        private System.Windows.Forms.Button btnAddD;
        private System.Windows.Forms.Button btnDelD;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.LinkLabel lnkSchedule;
        private System.Windows.Forms.TextBox txtSchedule;
    }
}