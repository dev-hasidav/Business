namespace Business.Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Узел2");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Узел1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Узел0", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tolStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tolStatusMainServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tolStatusSqlServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tolStatusServers = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTaskCreate = new System.Windows.Forms.Button();
            this.btnReloadTask = new System.Windows.Forms.Button();
            this.btnTaskDelete = new System.Windows.Forms.Button();
            this.btnTaskUpdate = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treViewTasks = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.txtTaskDateLast = new System.Windows.Forms.TextBox();
            this.txtTaskDateNext = new System.Windows.Forms.TextBox();
            this.txtTaskPeriod = new System.Windows.Forms.TextBox();
            this.txtTaskMessage = new System.Windows.Forms.TextBox();
            this.chkRaskIsRun = new System.Windows.Forms.CheckBox();
            this.chkTaskIsError = new System.Windows.Forms.CheckBox();
            this.txtTaskAction = new System.Windows.Forms.TextBox();
            this.txtTaskIntervalTimer = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTaskDataSource = new System.Windows.Forms.TextBox();
            this.txtTaskDectination = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dtgViewTaskLog = new System.Windows.Forms.DataGridView();
            this.clStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnClientUpdate = new System.Windows.Forms.Button();
            this.btnClientCheck = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numClientPort = new System.Windows.Forms.NumericUpDown();
            this.txtClientIP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnClientSave = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.txtSqlIpOrHost = new System.Windows.Forms.TextBox();
            this.btnSqlUpdate = new System.Windows.Forms.Button();
            this.btnSqlSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSqlViewPass = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSqlPass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnServerReload = new System.Windows.Forms.Button();
            this.btnServerDelete = new System.Windows.Forms.Button();
            this.btnServerUpdate = new System.Windows.Forms.Button();
            this.btnServerAdd = new System.Windows.Forms.Button();
            this.dtgServers = new System.Windows.Forms.DataGridView();
            this.clgStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.clIsEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clIsRemote = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clSId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSTypeServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSPublicPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rthTest = new System.Windows.Forms.RichTextBox();
            this.btnMainTest = new System.Windows.Forms.Button();
            this.iglStatus = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewTaskLog)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClientPort)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServers)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolStatusText,
            this.lblCurrentDate,
            this.tolStatusMainServer,
            this.tolStatusSqlServer,
            this.tolStatusServers});
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1043, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tolStatusText
            // 
            this.tolStatusText.Name = "tolStatusText";
            this.tolStatusText.Size = new System.Drawing.Size(753, 17);
            this.tolStatusText.Spring = true;
            this.tolStatusText.Text = "OK";
            this.tolStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = false;
            this.lblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(170, 17);
            this.lblCurrentDate.Text = "toolStripStatusLabel1";
            // 
            // tolStatusMainServer
            // 
            this.tolStatusMainServer.ActiveLinkColor = System.Drawing.Color.White;
            this.tolStatusMainServer.AutoSize = false;
            this.tolStatusMainServer.Name = "tolStatusMainServer";
            this.tolStatusMainServer.Size = new System.Drawing.Size(35, 17);
            this.tolStatusMainServer.Text = "M";
            this.tolStatusMainServer.ToolTipText = "Соединение с MAIN сервером отсуствует";
            // 
            // tolStatusSqlServer
            // 
            this.tolStatusSqlServer.ActiveLinkColor = System.Drawing.Color.White;
            this.tolStatusSqlServer.AutoSize = false;
            this.tolStatusSqlServer.Name = "tolStatusSqlServer";
            this.tolStatusSqlServer.Size = new System.Drawing.Size(35, 17);
            this.tolStatusSqlServer.Text = "S";
            // 
            // tolStatusServers
            // 
            this.tolStatusServers.ActiveLinkColor = System.Drawing.Color.White;
            this.tolStatusServers.AutoSize = false;
            this.tolStatusServers.Name = "tolStatusServers";
            this.tolStatusServers.Size = new System.Drawing.Size(35, 17);
            this.tolStatusServers.Text = "Ss";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 573);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTaskCreate);
            this.tabPage1.Controls.Add(this.btnReloadTask);
            this.tabPage1.Controls.Add(this.btnTaskDelete);
            this.tabPage1.Controls.Add(this.btnTaskUpdate);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1035, 547);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tasks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTaskCreate
            // 
            this.btnTaskCreate.Location = new System.Drawing.Point(180, 11);
            this.btnTaskCreate.Name = "btnTaskCreate";
            this.btnTaskCreate.Size = new System.Drawing.Size(91, 34);
            this.btnTaskCreate.TabIndex = 4;
            this.btnTaskCreate.Text = "Create";
            this.btnTaskCreate.UseVisualStyleBackColor = true;
            this.btnTaskCreate.Click += new System.EventHandler(this.btnTaskCreate_Click);
            // 
            // btnReloadTask
            // 
            this.btnReloadTask.Location = new System.Drawing.Point(60, 11);
            this.btnReloadTask.Name = "btnReloadTask";
            this.btnReloadTask.Size = new System.Drawing.Size(91, 34);
            this.btnReloadTask.TabIndex = 0;
            this.btnReloadTask.Text = "Reload";
            this.btnReloadTask.UseVisualStyleBackColor = true;
            this.btnReloadTask.Click += new System.EventHandler(this.btnTaskReload_Click);
            // 
            // btnTaskDelete
            // 
            this.btnTaskDelete.Location = new System.Drawing.Point(420, 11);
            this.btnTaskDelete.Name = "btnTaskDelete";
            this.btnTaskDelete.Size = new System.Drawing.Size(91, 34);
            this.btnTaskDelete.TabIndex = 3;
            this.btnTaskDelete.Text = "Delete";
            this.btnTaskDelete.UseVisualStyleBackColor = true;
            this.btnTaskDelete.Click += new System.EventHandler(this.btnTaskDelete_Click);
            // 
            // btnTaskUpdate
            // 
            this.btnTaskUpdate.Location = new System.Drawing.Point(300, 11);
            this.btnTaskUpdate.Name = "btnTaskUpdate";
            this.btnTaskUpdate.Size = new System.Drawing.Size(91, 34);
            this.btnTaskUpdate.TabIndex = 2;
            this.btnTaskUpdate.Text = "Update";
            this.btnTaskUpdate.UseVisualStyleBackColor = true;
            this.btnTaskUpdate.Click += new System.EventHandler(this.btnTaskUpdate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(8, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treViewTasks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 449);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // treViewTasks
            // 
            this.treViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treViewTasks.FullRowSelect = true;
            this.treViewTasks.HideSelection = false;
            this.treViewTasks.ImageIndex = 0;
            this.treViewTasks.ImageList = this.imageList1;
            this.treViewTasks.Location = new System.Drawing.Point(0, 0);
            this.treViewTasks.Name = "treViewTasks";
            treeNode1.Name = "Узел2";
            treeNode1.Text = "Узел2";
            treeNode2.Name = "Узел1";
            treeNode2.Text = "Узел1";
            treeNode3.Name = "Узел0";
            treeNode3.Text = "Узел0";
            this.treViewTasks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treViewTasks.SelectedImageIndex = 1;
            this.treViewTasks.Size = new System.Drawing.Size(199, 449);
            this.treViewTasks.TabIndex = 0;
            this.treViewTasks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treViewTasks_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Task-3.jpg");
            this.imageList1.Images.SetKeyName(1, "Task-2.png");
            this.imageList1.Images.SetKeyName(2, "Task-1.png");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtgViewTaskLog);
            this.splitContainer2.Size = new System.Drawing.Size(810, 449);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskDateLast, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskDateNext, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskPeriod, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskMessage, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkRaskIsRun, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkTaskIsError, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskAction, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskIntervalTimer, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label18, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label19, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskDataSource, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTaskDectination, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label23, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label24, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtId, 4, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 253);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1);
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1);
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date last";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(1);
            this.label3.Size = new System.Drawing.Size(92, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date next";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(368, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(1);
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Period";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(368, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(1);
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Action";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(368, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(1);
            this.label7.Size = new System.Drawing.Size(92, 29);
            this.label7.TabIndex = 7;
            this.label7.Text = "Run";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(540, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(1);
            this.label8.Size = new System.Drawing.Size(72, 29);
            this.label8.TabIndex = 8;
            this.label8.Text = "Error";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(8, 131);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(1);
            this.label9.Size = new System.Drawing.Size(92, 29);
            this.label9.TabIndex = 9;
            this.label9.Text = "Id guid";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskName.Location = new System.Drawing.Point(104, 9);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.ReadOnly = true;
            this.txtTaskName.Size = new System.Drawing.Size(260, 20);
            this.txtTaskName.TabIndex = 10;
            // 
            // txtTaskDateLast
            // 
            this.txtTaskDateLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskDateLast.Location = new System.Drawing.Point(104, 40);
            this.txtTaskDateLast.Name = "txtTaskDateLast";
            this.txtTaskDateLast.ReadOnly = true;
            this.txtTaskDateLast.Size = new System.Drawing.Size(260, 20);
            this.txtTaskDateLast.TabIndex = 11;
            // 
            // txtTaskDateNext
            // 
            this.txtTaskDateNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskDateNext.Location = new System.Drawing.Point(104, 71);
            this.txtTaskDateNext.Name = "txtTaskDateNext";
            this.txtTaskDateNext.ReadOnly = true;
            this.txtTaskDateNext.Size = new System.Drawing.Size(260, 20);
            this.txtTaskDateNext.TabIndex = 12;
            // 
            // txtTaskPeriod
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTaskPeriod, 3);
            this.txtTaskPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskPeriod.Location = new System.Drawing.Point(464, 71);
            this.txtTaskPeriod.Name = "txtTaskPeriod";
            this.txtTaskPeriod.ReadOnly = true;
            this.txtTaskPeriod.Size = new System.Drawing.Size(232, 20);
            this.txtTaskPeriod.TabIndex = 13;
            // 
            // txtTaskMessage
            // 
            this.txtTaskMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskMessage.Location = new System.Drawing.Point(104, 133);
            this.txtTaskMessage.Name = "txtTaskMessage";
            this.txtTaskMessage.ReadOnly = true;
            this.txtTaskMessage.Size = new System.Drawing.Size(260, 20);
            this.txtTaskMessage.TabIndex = 14;
            // 
            // chkRaskIsRun
            // 
            this.chkRaskIsRun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkRaskIsRun.Enabled = false;
            this.chkRaskIsRun.ForeColor = System.Drawing.Color.Blue;
            this.chkRaskIsRun.Location = new System.Drawing.Point(483, 43);
            this.chkRaskIsRun.Margin = new System.Windows.Forms.Padding(22, 6, 1, 1);
            this.chkRaskIsRun.Name = "chkRaskIsRun";
            this.chkRaskIsRun.Padding = new System.Windows.Forms.Padding(14, 2, 0, 0);
            this.chkRaskIsRun.Size = new System.Drawing.Size(48, 23);
            this.chkRaskIsRun.TabIndex = 15;
            this.chkRaskIsRun.UseVisualStyleBackColor = false;
            // 
            // chkTaskIsError
            // 
            this.chkTaskIsError.BackColor = System.Drawing.SystemColors.Control;
            this.chkTaskIsError.Enabled = false;
            this.chkTaskIsError.Location = new System.Drawing.Point(635, 43);
            this.chkTaskIsError.Margin = new System.Windows.Forms.Padding(22, 6, 1, 1);
            this.chkTaskIsError.Name = "chkTaskIsError";
            this.chkTaskIsError.Padding = new System.Windows.Forms.Padding(14, 1, 0, 0);
            this.chkTaskIsError.Size = new System.Drawing.Size(48, 23);
            this.chkTaskIsError.TabIndex = 16;
            this.chkTaskIsError.UseVisualStyleBackColor = false;
            // 
            // txtTaskAction
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTaskAction, 3);
            this.txtTaskAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskAction.Location = new System.Drawing.Point(464, 9);
            this.txtTaskAction.Name = "txtTaskAction";
            this.txtTaskAction.ReadOnly = true;
            this.txtTaskAction.Size = new System.Drawing.Size(232, 20);
            this.txtTaskAction.TabIndex = 17;
            // 
            // txtTaskIntervalTimer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTaskIntervalTimer, 5);
            this.txtTaskIntervalTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskIntervalTimer.Location = new System.Drawing.Point(104, 164);
            this.txtTaskIntervalTimer.Multiline = true;
            this.txtTaskIntervalTimer.Name = "txtTaskIntervalTimer";
            this.txtTaskIntervalTimer.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.txtTaskIntervalTimer, 3);
            this.txtTaskIntervalTimer.Size = new System.Drawing.Size(592, 87);
            this.txtTaskIntervalTimer.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(10, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 31);
            this.label18.TabIndex = 19;
            this.label18.Text = "Data source";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(370, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 31);
            this.label19.TabIndex = 20;
            this.label19.Text = "Destination";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaskDataSource
            // 
            this.txtTaskDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskDataSource.Location = new System.Drawing.Point(104, 102);
            this.txtTaskDataSource.Name = "txtTaskDataSource";
            this.txtTaskDataSource.ReadOnly = true;
            this.txtTaskDataSource.Size = new System.Drawing.Size(260, 20);
            this.txtTaskDataSource.TabIndex = 21;
            // 
            // txtTaskDectination
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTaskDectination, 3);
            this.txtTaskDectination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskDectination.Location = new System.Drawing.Point(464, 102);
            this.txtTaskDectination.Name = "txtTaskDectination";
            this.txtTaskDectination.ReadOnly = true;
            this.txtTaskDectination.Size = new System.Drawing.Size(232, 20);
            this.txtTaskDectination.TabIndex = 22;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Location = new System.Drawing.Point(10, 161);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 31);
            this.label23.TabIndex = 23;
            this.label23.Text = "Schedule";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(370, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 31);
            this.label24.TabIndex = 24;
            this.label24.Text = "Id";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.Location = new System.Drawing.Point(464, 133);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(72, 20);
            this.txtId.TabIndex = 25;
            // 
            // dtgViewTaskLog
            // 
            this.dtgViewTaskLog.AllowUserToAddRows = false;
            this.dtgViewTaskLog.AllowUserToDeleteRows = false;
            this.dtgViewTaskLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgViewTaskLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clStatus,
            this.clDate,
            this.clMessage});
            this.dtgViewTaskLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgViewTaskLog.Location = new System.Drawing.Point(0, 0);
            this.dtgViewTaskLog.Name = "dtgViewTaskLog";
            this.dtgViewTaskLog.ReadOnly = true;
            this.dtgViewTaskLog.Size = new System.Drawing.Size(810, 191);
            this.dtgViewTaskLog.TabIndex = 0;
            this.dtgViewTaskLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgViewTaskLog_CellFormatting);
            // 
            // clStatus
            // 
            this.clStatus.DataPropertyName = "Status";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clStatus.DefaultCellStyle = dataGridViewCellStyle1;
            this.clStatus.HeaderText = "Status";
            this.clStatus.Name = "clStatus";
            this.clStatus.ReadOnly = true;
            this.clStatus.Width = 50;
            // 
            // clDate
            // 
            this.clDate.DataPropertyName = "Date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy HH:mm:ss";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.clDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.clDate.HeaderText = "Date";
            this.clDate.Name = "clDate";
            this.clDate.ReadOnly = true;
            this.clDate.Width = 180;
            // 
            // clMessage
            // 
            this.clMessage.DataPropertyName = "Message";
            this.clMessage.HeaderText = "Message";
            this.clMessage.Name = "clMessage";
            this.clMessage.ReadOnly = true;
            this.clMessage.Width = 500;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tabControl2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1035, 547);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Property server";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.HotTrack = true;
            this.tabControl2.ItemSize = new System.Drawing.Size(80, 30);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1035, 547);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btnClientUpdate);
            this.tabPage7.Controls.Add(this.btnClientCheck);
            this.tabPage7.Controls.Add(this.label12);
            this.tabPage7.Controls.Add(this.label13);
            this.tabPage7.Controls.Add(this.numClientPort);
            this.tabPage7.Controls.Add(this.txtClientIP);
            this.tabPage7.Controls.Add(this.label15);
            this.tabPage7.Controls.Add(this.label16);
            this.tabPage7.Controls.Add(this.btnClientSave);
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1027, 509);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Client";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // btnClientUpdate
            // 
            this.btnClientUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientUpdate.Location = new System.Drawing.Point(802, 109);
            this.btnClientUpdate.Name = "btnClientUpdate";
            this.btnClientUpdate.Size = new System.Drawing.Size(179, 51);
            this.btnClientUpdate.TabIndex = 3;
            this.btnClientUpdate.Text = "Reload";
            this.btnClientUpdate.UseVisualStyleBackColor = true;
            this.btnClientUpdate.Click += new System.EventHandler(this.btnClientUpdate_Click);
            // 
            // btnClientCheck
            // 
            this.btnClientCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientCheck.Location = new System.Drawing.Point(802, 43);
            this.btnClientCheck.Name = "btnClientCheck";
            this.btnClientCheck.Size = new System.Drawing.Size(179, 51);
            this.btnClientCheck.TabIndex = 2;
            this.btnClientCheck.Text = "Check";
            this.btnClientCheck.UseVisualStyleBackColor = true;
            this.btnClientCheck.Click += new System.EventHandler(this.btnClientCheck_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(205, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(260, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Например:  192.168.10.10  или  www.company.com";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(255, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(366, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "Введите IP адрес или имя хоста MAIN сервера";
            // 
            // numClientPort
            // 
            this.numClientPort.Location = new System.Drawing.Point(205, 115);
            this.numClientPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.numClientPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numClientPort.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numClientPort.Name = "numClientPort";
            this.numClientPort.Size = new System.Drawing.Size(153, 20);
            this.numClientPort.TabIndex = 1;
            this.numClientPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numClientPort.Value = new decimal(new int[] {
            28620,
            0,
            0,
            0});
            this.numClientPort.ValueChanged += new System.EventHandler(this.numClientPort_ValueChanged);
            // 
            // txtClientIP
            // 
            this.txtClientIP.Location = new System.Drawing.Point(205, 58);
            this.txtClientIP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtClientIP.Name = "txtClientIP";
            this.txtClientIP.Size = new System.Drawing.Size(254, 20);
            this.txtClientIP.TabIndex = 0;
            this.txtClientIP.TextChanged += new System.EventHandler(this.txtClientIP_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(157, 117);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Port";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(73, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "IP or name host";
            // 
            // btnClientSave
            // 
            this.btnClientSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientSave.Location = new System.Drawing.Point(802, 175);
            this.btnClientSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClientSave.Name = "btnClientSave";
            this.btnClientSave.Size = new System.Drawing.Size(179, 51);
            this.btnClientSave.TabIndex = 4;
            this.btnClientSave.Text = "Save";
            this.btnClientSave.UseVisualStyleBackColor = true;
            this.btnClientSave.Click += new System.EventHandler(this.btnClientSave_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.txtSqlIpOrHost);
            this.tabPage8.Controls.Add(this.btnSqlUpdate);
            this.tabPage8.Controls.Add(this.btnSqlSave);
            this.tabPage8.Controls.Add(this.label6);
            this.tabPage8.Controls.Add(this.btnSqlViewPass);
            this.tabPage8.Controls.Add(this.label10);
            this.tabPage8.Controls.Add(this.txtSqlPass);
            this.tabPage8.Controls.Add(this.label11);
            this.tabPage8.Controls.Add(this.txtSqlUser);
            this.tabPage8.Location = new System.Drawing.Point(4, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1027, 509);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "SQL main";
            // 
            // txtSqlIpOrHost
            // 
            this.txtSqlIpOrHost.Location = new System.Drawing.Point(221, 35);
            this.txtSqlIpOrHost.Name = "txtSqlIpOrHost";
            this.txtSqlIpOrHost.Size = new System.Drawing.Size(241, 20);
            this.txtSqlIpOrHost.TabIndex = 0;
            // 
            // btnSqlUpdate
            // 
            this.btnSqlUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSqlUpdate.Location = new System.Drawing.Point(802, 44);
            this.btnSqlUpdate.Name = "btnSqlUpdate";
            this.btnSqlUpdate.Size = new System.Drawing.Size(179, 46);
            this.btnSqlUpdate.TabIndex = 3;
            this.btnSqlUpdate.Text = "Reload";
            this.btnSqlUpdate.UseVisualStyleBackColor = true;
            this.btnSqlUpdate.Click += new System.EventHandler(this.btnSqlUpdate_Click);
            // 
            // btnSqlSave
            // 
            this.btnSqlSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSqlSave.Location = new System.Drawing.Point(802, 122);
            this.btnSqlSave.Name = "btnSqlSave";
            this.btnSqlSave.Size = new System.Drawing.Size(179, 46);
            this.btnSqlSave.TabIndex = 4;
            this.btnSqlSave.Text = "Save";
            this.btnSqlSave.UseVisualStyleBackColor = true;
            this.btnSqlSave.Click += new System.EventHandler(this.btnSqlSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "IP address or name host SQL";
            // 
            // btnSqlViewPass
            // 
            this.btnSqlViewPass.Location = new System.Drawing.Point(469, 101);
            this.btnSqlViewPass.Name = "btnSqlViewPass";
            this.btnSqlViewPass.Size = new System.Drawing.Size(30, 25);
            this.btnSqlViewPass.TabIndex = 14;
            this.btnSqlViewPass.UseVisualStyleBackColor = true;
            this.btnSqlViewPass.Click += new System.EventHandler(this.btnSqlViewPass_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Password";
            // 
            // txtSqlPass
            // 
            this.txtSqlPass.Location = new System.Drawing.Point(221, 102);
            this.txtSqlPass.Name = "txtSqlPass";
            this.txtSqlPass.PasswordChar = '*';
            this.txtSqlPass.Size = new System.Drawing.Size(241, 20);
            this.txtSqlPass.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(175, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "User";
            // 
            // txtSqlUser
            // 
            this.txtSqlUser.Location = new System.Drawing.Point(221, 68);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(241, 20);
            this.txtSqlUser.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnServerReload);
            this.tabPage2.Controls.Add(this.btnServerDelete);
            this.tabPage2.Controls.Add(this.btnServerUpdate);
            this.tabPage2.Controls.Add(this.btnServerAdd);
            this.tabPage2.Controls.Add(this.dtgServers);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1027, 509);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Data Sources and Receivers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnServerReload
            // 
            this.btnServerReload.Location = new System.Drawing.Point(71, 16);
            this.btnServerReload.Name = "btnServerReload";
            this.btnServerReload.Size = new System.Drawing.Size(128, 39);
            this.btnServerReload.TabIndex = 6;
            this.btnServerReload.Text = "Reload server";
            this.btnServerReload.UseVisualStyleBackColor = true;
            this.btnServerReload.Click += new System.EventHandler(this.btnServerReload_Click);
            // 
            // btnServerDelete
            // 
            this.btnServerDelete.Location = new System.Drawing.Point(503, 16);
            this.btnServerDelete.Name = "btnServerDelete";
            this.btnServerDelete.Size = new System.Drawing.Size(128, 39);
            this.btnServerDelete.TabIndex = 5;
            this.btnServerDelete.Text = "Delete server";
            this.btnServerDelete.UseVisualStyleBackColor = true;
            this.btnServerDelete.Click += new System.EventHandler(this.btnServerDelete_Click);
            // 
            // btnServerUpdate
            // 
            this.btnServerUpdate.Location = new System.Drawing.Point(359, 16);
            this.btnServerUpdate.Name = "btnServerUpdate";
            this.btnServerUpdate.Size = new System.Drawing.Size(128, 39);
            this.btnServerUpdate.TabIndex = 4;
            this.btnServerUpdate.Text = "Update server";
            this.btnServerUpdate.UseVisualStyleBackColor = true;
            this.btnServerUpdate.Click += new System.EventHandler(this.btnServerUpdate_Click);
            // 
            // btnServerAdd
            // 
            this.btnServerAdd.Location = new System.Drawing.Point(215, 16);
            this.btnServerAdd.Name = "btnServerAdd";
            this.btnServerAdd.Size = new System.Drawing.Size(128, 39);
            this.btnServerAdd.TabIndex = 3;
            this.btnServerAdd.Text = "Add server";
            this.btnServerAdd.UseVisualStyleBackColor = true;
            this.btnServerAdd.Click += new System.EventHandler(this.btnServerAdd_Click_1);
            // 
            // dtgServers
            // 
            this.dtgServers.AllowUserToAddRows = false;
            this.dtgServers.AllowUserToDeleteRows = false;
            this.dtgServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clgStatus,
            this.clIsEnable,
            this.clIsRemote,
            this.clSId,
            this.clSName,
            this.clSTypeServer,
            this.clSRemark,
            this.clSPublicPath});
            this.dtgServers.Location = new System.Drawing.Point(6, 60);
            this.dtgServers.Name = "dtgServers";
            this.dtgServers.ReadOnly = true;
            this.dtgServers.Size = new System.Drawing.Size(1021, 411);
            this.dtgServers.TabIndex = 2;
            // 
            // clgStatus
            // 
            this.clgStatus.DataPropertyName = "StatusImage";
            this.clgStatus.HeaderText = "S";
            this.clgStatus.Name = "clgStatus";
            this.clgStatus.ReadOnly = true;
            this.clgStatus.ToolTipText = "Ok server";
            this.clgStatus.Width = 22;
            // 
            // clIsEnable
            // 
            this.clIsEnable.DataPropertyName = "IsEnable";
            this.clIsEnable.FalseValue = "No";
            this.clIsEnable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clIsEnable.HeaderText = "E";
            this.clIsEnable.Name = "clIsEnable";
            this.clIsEnable.ReadOnly = true;
            this.clIsEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clIsEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clIsEnable.TrueValue = "Ok";
            this.clIsEnable.Width = 22;
            // 
            // clIsRemote
            // 
            this.clIsRemote.DataPropertyName = "IsRemote";
            this.clIsRemote.FalseValue = "No";
            this.clIsRemote.HeaderText = "R";
            this.clIsRemote.Name = "clIsRemote";
            this.clIsRemote.ReadOnly = true;
            this.clIsRemote.TrueValue = "Ok";
            this.clIsRemote.Width = 22;
            // 
            // clSId
            // 
            this.clSId.DataPropertyName = "Id";
            this.clSId.HeaderText = "Id";
            this.clSId.Name = "clSId";
            this.clSId.ReadOnly = true;
            this.clSId.Visible = false;
            this.clSId.Width = 40;
            // 
            // clSName
            // 
            this.clSName.DataPropertyName = "Name";
            this.clSName.HeaderText = "Name";
            this.clSName.Name = "clSName";
            this.clSName.ReadOnly = true;
            this.clSName.Width = 130;
            // 
            // clSTypeServer
            // 
            this.clSTypeServer.DataPropertyName = "Type";
            this.clSTypeServer.HeaderText = "Type";
            this.clSTypeServer.Name = "clSTypeServer";
            this.clSTypeServer.ReadOnly = true;
            // 
            // clSRemark
            // 
            this.clSRemark.DataPropertyName = "Remark";
            this.clSRemark.HeaderText = "Remark";
            this.clSRemark.Name = "clSRemark";
            this.clSRemark.ReadOnly = true;
            this.clSRemark.Width = 300;
            // 
            // clSPublicPath
            // 
            this.clSPublicPath.DataPropertyName = "PublicPath";
            this.clSPublicPath.HeaderText = "Public path";
            this.clSPublicPath.Name = "clSPublicPath";
            this.clSPublicPath.ReadOnly = true;
            this.clSPublicPath.Width = 250;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rthTest);
            this.tabPage3.Controls.Add(this.btnMainTest);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1035, 547);
            this.tabPage3.TabIndex = 6;
            this.tabPage3.Text = "Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rthTest
            // 
            this.rthTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rthTest.Location = new System.Drawing.Point(8, 125);
            this.rthTest.Name = "rthTest";
            this.rthTest.Size = new System.Drawing.Size(1019, 419);
            this.rthTest.TabIndex = 3;
            this.rthTest.Text = "";
            // 
            // btnMainTest
            // 
            this.btnMainTest.Enabled = false;
            this.btnMainTest.Location = new System.Drawing.Point(42, 21);
            this.btnMainTest.Name = "btnMainTest";
            this.btnMainTest.Size = new System.Drawing.Size(196, 44);
            this.btnMainTest.TabIndex = 2;
            this.btnMainTest.Text = "Test";
            this.btnMainTest.UseVisualStyleBackColor = true;
            this.btnMainTest.Click += new System.EventHandler(this.btnMainTest_Click);
            // 
            // iglStatus
            // 
            this.iglStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglStatus.ImageStream")));
            this.iglStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.iglStatus.Images.SetKeyName(0, "red.png");
            this.iglStatus.Images.SetKeyName(1, "yellow.png");
            this.iglStatus.Images.SetKeyName(2, "green.png");
            this.iglStatus.Images.SetKeyName(3, "blue.png");
            this.iglStatus.Images.SetKeyName(4, "lightblue.png");
            this.iglStatus.Images.SetKeyName(5, "purple.png");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.notifyIcon1.BalloonTipText = "BalloonTipText-text";
            this.notifyIcon1.BalloonTipTitle = "BalloonTipTitle-title";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Text-Text";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 636);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewTaskLog)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClientPort)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServers)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnTaskDelete;
        private System.Windows.Forms.Button btnTaskUpdate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treViewTasks;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.TextBox txtTaskDateLast;
        private System.Windows.Forms.TextBox txtTaskDateNext;
        private System.Windows.Forms.TextBox txtTaskPeriod;
        private System.Windows.Forms.TextBox txtTaskMessage;
        private System.Windows.Forms.CheckBox chkRaskIsRun;
        private System.Windows.Forms.CheckBox chkTaskIsError;
        private System.Windows.Forms.TextBox txtTaskAction;
        private System.Windows.Forms.TextBox txtTaskIntervalTimer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTaskDataSource;
        private System.Windows.Forms.DataGridView dtgViewTaskLog;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnClientUpdate;
        private System.Windows.Forms.Button btnClientCheck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numClientPort;
        private System.Windows.Forms.TextBox txtClientIP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnClientSave;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnSqlUpdate;
        private System.Windows.Forms.TextBox txtSqlIpOrHost;
        private System.Windows.Forms.Button btnSqlSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSqlViewPass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSqlPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnServerDelete;
        private System.Windows.Forms.Button btnServerUpdate;
        private System.Windows.Forms.Button btnServerAdd;
        private System.Windows.Forms.DataGridView dtgServers;
        private System.Windows.Forms.ToolStripStatusLabel tolStatusText;
        private System.Windows.Forms.ToolStripStatusLabel tolStatusMainServer;
        private System.Windows.Forms.ToolStripStatusLabel tolStatusSqlServer;
        private System.Windows.Forms.ToolStripStatusLabel tolStatusServers;
        private System.Windows.Forms.ImageList iglStatus;
        private System.Windows.Forms.Button btnServerReload;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridViewImageColumn clgStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsEnable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsRemote;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSTypeServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSPublicPath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnReloadTask;
        private System.Windows.Forms.Button btnTaskCreate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTaskDectination;
        private System.Windows.Forms.Button btnMainTest;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMessage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rthTest;
    }
}

