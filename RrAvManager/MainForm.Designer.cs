namespace RrAvManager
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0");
            this.treeViewFolderExploer = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labScanDir = new System.Windows.Forms.Label();
            this.btnFileScan = new System.Windows.Forms.Button();
            this.labCurrDir = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFileManager = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gvMainLsit = new System.Windows.Forms.DataGridView();
            this.COVER_IMAGE = new System.Windows.Forms.DataGridViewImageColumn();
            this.VIDEO_FILE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INDEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.litBoxFileList = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtVdoInfoIntro = new System.Windows.Forms.TextBox();
            this.labVdoInfoIntro = new System.Windows.Forms.Label();
            this.txtVdoInfoLength = new System.Windows.Forms.TextBox();
            this.labVdoInfoLength = new System.Windows.Forms.Label();
            this.txtVdoInfoSno = new System.Windows.Forms.TextBox();
            this.labVdoInfoSno = new System.Windows.Forms.Label();
            this.txtVdoInfoReleaseDate = new System.Windows.Forms.TextBox();
            this.labVdoInfoReleaseDate = new System.Windows.Forms.Label();
            this.txtVdoInfoIssuer = new System.Windows.Forms.TextBox();
            this.labVdoInfoIssuer = new System.Windows.Forms.Label();
            this.txtVdoInfoMaker = new System.Windows.Forms.TextBox();
            this.labVdoInfoVdoMaker = new System.Windows.Forms.Label();
            this.txtVdoInfoActor = new System.Windows.Forms.TextBox();
            this.labVdoInfoActor = new System.Windows.Forms.Label();
            this.txtVdoInfoVdoName = new System.Windows.Forms.TextBox();
            this.labVdoInfoVdoName = new System.Windows.Forms.Label();
            this.btnSearchSNO = new System.Windows.Forms.Button();
            this.txtSearchID = new System.Windows.Forms.TextBox();
            this.picVdoInfoVdoCover = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userControl11 = new RrAvManager.control.UserControl1();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageFileManager.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMainLsit)).BeginInit();
            this.tabPageDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVdoInfoVdoCover)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewFolderExploer
            // 
            this.treeViewFolderExploer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewFolderExploer.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.treeViewFolderExploer.Indent = 20;
            this.treeViewFolderExploer.Location = new System.Drawing.Point(11, 44);
            this.treeViewFolderExploer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.treeViewFolderExploer.Name = "treeViewFolderExploer";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            this.treeViewFolderExploer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeViewFolderExploer.Size = new System.Drawing.Size(173, 399);
            this.treeViewFolderExploer.TabIndex = 0;
            this.treeViewFolderExploer.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFolderExploer_BeforeCollapse);
            this.treeViewFolderExploer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFolderExploer_BeforeExpand);
            this.treeViewFolderExploer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolderExploer_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.treeViewFolderExploer);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 715);
            this.panel1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(11, 467);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(173, 228);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "選擇掃瞄目錄";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.labScanDir);
            this.panel2.Controls.Add(this.btnFileScan);
            this.panel2.Controls.Add(this.labCurrDir);
            this.panel2.Location = new System.Drawing.Point(225, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 59);
            this.panel2.TabIndex = 2;
            // 
            // labScanDir
            // 
            this.labScanDir.AutoSize = true;
            this.labScanDir.Font = new System.Drawing.Font("標楷體", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labScanDir.ForeColor = System.Drawing.Color.Teal;
            this.labScanDir.Location = new System.Drawing.Point(231, 21);
            this.labScanDir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labScanDir.Name = "labScanDir";
            this.labScanDir.Size = new System.Drawing.Size(42, 19);
            this.labScanDir.TabIndex = 5;
            this.labScanDir.Text = "C:\\";
            // 
            // btnFileScan
            // 
            this.btnFileScan.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFileScan.Location = new System.Drawing.Point(9, 7);
            this.btnFileScan.Name = "btnFileScan";
            this.btnFileScan.Size = new System.Drawing.Size(107, 49);
            this.btnFileScan.TabIndex = 4;
            this.btnFileScan.Text = "掃瞄檔案";
            this.btnFileScan.UseVisualStyleBackColor = true;
            this.btnFileScan.Click += new System.EventHandler(this.btnFileScan_Click);
            // 
            // labCurrDir
            // 
            this.labCurrDir.AutoSize = true;
            this.labCurrDir.Font = new System.Drawing.Font("標楷體", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCurrDir.ForeColor = System.Drawing.Color.Blue;
            this.labCurrDir.Location = new System.Drawing.Point(128, 21);
            this.labCurrDir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labCurrDir.Name = "labCurrDir";
            this.labCurrDir.Size = new System.Drawing.Size(114, 19);
            this.labCurrDir.TabIndex = 3;
            this.labCurrDir.Text = "當前目錄：";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageFileManager);
            this.tabControl1.Controls.Add(this.tabPageDebug);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 759);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageFileManager
            // 
            this.tabPageFileManager.Controls.Add(this.panel2);
            this.tabPageFileManager.Controls.Add(this.panel3);
            this.tabPageFileManager.Controls.Add(this.panel1);
            this.tabPageFileManager.Controls.Add(this.gvMainLsit);
            this.tabPageFileManager.Location = new System.Drawing.Point(4, 26);
            this.tabPageFileManager.Name = "tabPageFileManager";
            this.tabPageFileManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileManager.Size = new System.Drawing.Size(1256, 729);
            this.tabPageFileManager.TabIndex = 0;
            this.tabPageFileManager.Text = "檔案管理";
            this.tabPageFileManager.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.userControl11);
            this.panel3.Controls.Add(this.txtVdoInfoIntro);
            this.panel3.Controls.Add(this.labVdoInfoIntro);
            this.panel3.Controls.Add(this.txtVdoInfoLength);
            this.panel3.Controls.Add(this.labVdoInfoLength);
            this.panel3.Controls.Add(this.txtVdoInfoSno);
            this.panel3.Controls.Add(this.labVdoInfoSno);
            this.panel3.Controls.Add(this.txtVdoInfoReleaseDate);
            this.panel3.Controls.Add(this.labVdoInfoReleaseDate);
            this.panel3.Controls.Add(this.txtVdoInfoIssuer);
            this.panel3.Controls.Add(this.labVdoInfoIssuer);
            this.panel3.Controls.Add(this.txtVdoInfoMaker);
            this.panel3.Controls.Add(this.labVdoInfoVdoMaker);
            this.panel3.Controls.Add(this.txtVdoInfoActor);
            this.panel3.Controls.Add(this.labVdoInfoActor);
            this.panel3.Controls.Add(this.txtVdoInfoVdoName);
            this.panel3.Controls.Add(this.labVdoInfoVdoName);
            this.panel3.Controls.Add(this.btnSearchSNO);
            this.panel3.Controls.Add(this.txtSearchID);
            this.panel3.Controls.Add(this.picVdoInfoVdoCover);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(764, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 541);
            this.panel3.TabIndex = 1;
            // 
            // gvMainLsit
            // 
            this.gvMainLsit.AllowUserToAddRows = false;
            this.gvMainLsit.AllowUserToDeleteRows = false;
            this.gvMainLsit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMainLsit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvMainLsit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvMainLsit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMainLsit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COVER_IMAGE,
            this.VIDEO_FILE_NAME,
            this.SNO,
            this.INDEX});
            this.gvMainLsit.Location = new System.Drawing.Point(225, 77);
            this.gvMainLsit.Name = "gvMainLsit";
            this.gvMainLsit.ReadOnly = true;
            this.gvMainLsit.RowTemplate.Height = 24;
            this.gvMainLsit.Size = new System.Drawing.Size(520, 646);
            this.gvMainLsit.TabIndex = 0;
            this.gvMainLsit.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMainLsit_CellMouseEnter);
            this.gvMainLsit.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMainLsit_CellMouseLeave);
            this.gvMainLsit.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvMainLsit_CellMouseMove);
            this.gvMainLsit.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvMainLsit_CellMouseUp);
            this.gvMainLsit.MouseLeave += new System.EventHandler(this.gvMainLsit_MouseLeave);
            this.gvMainLsit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gvMainLsit_MouseMove);
            // 
            // COVER_IMAGE
            // 
            this.COVER_IMAGE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.COVER_IMAGE.DataPropertyName = "COVER_IMAGE";
            this.COVER_IMAGE.FillWeight = 50F;
            this.COVER_IMAGE.Frozen = true;
            this.COVER_IMAGE.HeaderText = "封面";
            this.COVER_IMAGE.MinimumWidth = 300;
            this.COVER_IMAGE.Name = "COVER_IMAGE";
            this.COVER_IMAGE.ReadOnly = true;
            this.COVER_IMAGE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COVER_IMAGE.Width = 300;
            // 
            // VIDEO_FILE_NAME
            // 
            this.VIDEO_FILE_NAME.DataPropertyName = "VIDEO_FILE_NAME";
            this.VIDEO_FILE_NAME.HeaderText = "檔案名稱";
            this.VIDEO_FILE_NAME.Name = "VIDEO_FILE_NAME";
            this.VIDEO_FILE_NAME.ReadOnly = true;
            this.VIDEO_FILE_NAME.Width = 101;
            // 
            // SNO
            // 
            this.SNO.DataPropertyName = "SNO";
            this.SNO.HeaderText = "品番";
            this.SNO.Name = "SNO";
            this.SNO.ReadOnly = true;
            this.SNO.Width = 67;
            // 
            // INDEX
            // 
            this.INDEX.DataPropertyName = "INDEX";
            this.INDEX.HeaderText = "INDEX";
            this.INDEX.Name = "INDEX";
            this.INDEX.ReadOnly = true;
            this.INDEX.Visible = false;
            this.INDEX.Width = 65;
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.Controls.Add(this.txtDebug);
            this.tabPageDebug.Controls.Add(this.litBoxFileList);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 26);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebug.Size = new System.Drawing.Size(1256, 729);
            this.tabPageDebug.TabIndex = 1;
            this.tabPageDebug.Text = " 除錯";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebug.Location = new System.Drawing.Point(324, 7);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(696, 611);
            this.txtDebug.TabIndex = 7;
            // 
            // litBoxFileList
            // 
            this.litBoxFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.litBoxFileList.FormattingEnabled = true;
            this.litBoxFileList.HorizontalScrollbar = true;
            this.litBoxFileList.ItemHeight = 16;
            this.litBoxFileList.Location = new System.Drawing.Point(15, 6);
            this.litBoxFileList.Name = "litBoxFileList";
            this.litBoxFileList.Size = new System.Drawing.Size(272, 612);
            this.litBoxFileList.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1256, 729);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtVdoInfoIntro
            // 
            this.txtVdoInfoIntro.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoIntro.Location = new System.Drawing.Point(84, 441);
            this.txtVdoInfoIntro.Multiline = true;
            this.txtVdoInfoIntro.Name = "txtVdoInfoIntro";
            this.txtVdoInfoIntro.Size = new System.Drawing.Size(387, 55);
            this.txtVdoInfoIntro.TabIndex = 42;
            // 
            // labVdoInfoIntro
            // 
            this.labVdoInfoIntro.AutoSize = true;
            this.labVdoInfoIntro.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoIntro.Location = new System.Drawing.Point(7, 442);
            this.labVdoInfoIntro.Name = "labVdoInfoIntro";
            this.labVdoInfoIntro.Size = new System.Drawing.Size(66, 19);
            this.labVdoInfoIntro.TabIndex = 43;
            this.labVdoInfoIntro.Text = "簡介：";
            // 
            // txtVdoInfoLength
            // 
            this.txtVdoInfoLength.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoLength.Location = new System.Drawing.Point(574, 617);
            this.txtVdoInfoLength.Name = "txtVdoInfoLength";
            this.txtVdoInfoLength.Size = new System.Drawing.Size(31, 27);
            this.txtVdoInfoLength.TabIndex = 40;
            // 
            // labVdoInfoLength
            // 
            this.labVdoInfoLength.AutoSize = true;
            this.labVdoInfoLength.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoLength.Location = new System.Drawing.Point(494, 621);
            this.labVdoInfoLength.Name = "labVdoInfoLength";
            this.labVdoInfoLength.Size = new System.Drawing.Size(66, 19);
            this.labVdoInfoLength.TabIndex = 41;
            this.labVdoInfoLength.Text = "片長：";
            // 
            // txtVdoInfoSno
            // 
            this.txtVdoInfoSno.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoSno.Location = new System.Drawing.Point(9, 85);
            this.txtVdoInfoSno.Name = "txtVdoInfoSno";
            this.txtVdoInfoSno.Size = new System.Drawing.Size(100, 27);
            this.txtVdoInfoSno.TabIndex = 38;
            // 
            // labVdoInfoSno
            // 
            this.labVdoInfoSno.AutoSize = true;
            this.labVdoInfoSno.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoSno.Location = new System.Drawing.Point(7, 58);
            this.labVdoInfoSno.Name = "labVdoInfoSno";
            this.labVdoInfoSno.Size = new System.Drawing.Size(66, 19);
            this.labVdoInfoSno.TabIndex = 39;
            this.labVdoInfoSno.Text = "品番：";
            // 
            // txtVdoInfoReleaseDate
            // 
            this.txtVdoInfoReleaseDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoReleaseDate.Location = new System.Drawing.Point(9, 146);
            this.txtVdoInfoReleaseDate.Name = "txtVdoInfoReleaseDate";
            this.txtVdoInfoReleaseDate.Size = new System.Drawing.Size(100, 27);
            this.txtVdoInfoReleaseDate.TabIndex = 36;
            // 
            // labVdoInfoReleaseDate
            // 
            this.labVdoInfoReleaseDate.AutoSize = true;
            this.labVdoInfoReleaseDate.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoReleaseDate.Location = new System.Drawing.Point(7, 124);
            this.labVdoInfoReleaseDate.Name = "labVdoInfoReleaseDate";
            this.labVdoInfoReleaseDate.Size = new System.Drawing.Size(85, 19);
            this.labVdoInfoReleaseDate.TabIndex = 37;
            this.labVdoInfoReleaseDate.Text = "發售日：";
            // 
            // txtVdoInfoIssuer
            // 
            this.txtVdoInfoIssuer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoIssuer.Location = new System.Drawing.Point(326, 396);
            this.txtVdoInfoIssuer.Name = "txtVdoInfoIssuer";
            this.txtVdoInfoIssuer.Size = new System.Drawing.Size(145, 27);
            this.txtVdoInfoIssuer.TabIndex = 34;
            // 
            // labVdoInfoIssuer
            // 
            this.labVdoInfoIssuer.AutoSize = true;
            this.labVdoInfoIssuer.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoIssuer.Location = new System.Drawing.Point(235, 404);
            this.labVdoInfoIssuer.Name = "labVdoInfoIssuer";
            this.labVdoInfoIssuer.Size = new System.Drawing.Size(85, 19);
            this.labVdoInfoIssuer.TabIndex = 35;
            this.labVdoInfoIssuer.Text = "發行者：";
            // 
            // txtVdoInfoMaker
            // 
            this.txtVdoInfoMaker.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoMaker.Location = new System.Drawing.Point(84, 396);
            this.txtVdoInfoMaker.Name = "txtVdoInfoMaker";
            this.txtVdoInfoMaker.Size = new System.Drawing.Size(145, 27);
            this.txtVdoInfoMaker.TabIndex = 32;
            // 
            // labVdoInfoVdoMaker
            // 
            this.labVdoInfoVdoMaker.AutoSize = true;
            this.labVdoInfoVdoMaker.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoVdoMaker.Location = new System.Drawing.Point(7, 404);
            this.labVdoInfoVdoMaker.Name = "labVdoInfoVdoMaker";
            this.labVdoInfoVdoMaker.Size = new System.Drawing.Size(85, 19);
            this.labVdoInfoVdoMaker.TabIndex = 33;
            this.labVdoInfoVdoMaker.Text = "製作商：";
            // 
            // txtVdoInfoActor
            // 
            this.txtVdoInfoActor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoActor.Location = new System.Drawing.Point(70, 357);
            this.txtVdoInfoActor.Name = "txtVdoInfoActor";
            this.txtVdoInfoActor.Size = new System.Drawing.Size(405, 27);
            this.txtVdoInfoActor.TabIndex = 30;
            // 
            // labVdoInfoActor
            // 
            this.labVdoInfoActor.AutoSize = true;
            this.labVdoInfoActor.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoActor.Location = new System.Drawing.Point(7, 365);
            this.labVdoInfoActor.Name = "labVdoInfoActor";
            this.labVdoInfoActor.Size = new System.Drawing.Size(66, 19);
            this.labVdoInfoActor.TabIndex = 31;
            this.labVdoInfoActor.Text = "演員：";
            // 
            // txtVdoInfoVdoName
            // 
            this.txtVdoInfoVdoName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVdoInfoVdoName.Location = new System.Drawing.Point(70, 319);
            this.txtVdoInfoVdoName.Name = "txtVdoInfoVdoName";
            this.txtVdoInfoVdoName.Size = new System.Drawing.Size(405, 27);
            this.txtVdoInfoVdoName.TabIndex = 28;
            // 
            // labVdoInfoVdoName
            // 
            this.labVdoInfoVdoName.AutoSize = true;
            this.labVdoInfoVdoName.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVdoInfoVdoName.Location = new System.Drawing.Point(7, 320);
            this.labVdoInfoVdoName.Name = "labVdoInfoVdoName";
            this.labVdoInfoVdoName.Size = new System.Drawing.Size(66, 19);
            this.labVdoInfoVdoName.TabIndex = 29;
            this.labVdoInfoVdoName.Text = "片名：";
            // 
            // btnSearchSNO
            // 
            this.btnSearchSNO.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearchSNO.Location = new System.Drawing.Point(212, 6);
            this.btnSearchSNO.Name = "btnSearchSNO";
            this.btnSearchSNO.Size = new System.Drawing.Size(137, 27);
            this.btnSearchSNO.TabIndex = 27;
            this.btnSearchSNO.Text = "搜尋";
            this.btnSearchSNO.UseVisualStyleBackColor = true;
            this.btnSearchSNO.Click += new System.EventHandler(this.btnSearchSNO_Click);
            // 
            // txtSearchID
            // 
            this.txtSearchID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSearchID.Location = new System.Drawing.Point(108, 6);
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.Size = new System.Drawing.Size(95, 27);
            this.txtSearchID.TabIndex = 25;
            // 
            // picVdoInfoVdoCover
            // 
            this.picVdoInfoVdoCover.Location = new System.Drawing.Point(115, 56);
            this.picVdoInfoVdoCover.Name = "picVdoInfoVdoCover";
            this.picVdoInfoVdoCover.Size = new System.Drawing.Size(360, 240);
            this.picVdoInfoVdoCover.TabIndex = 24;
            this.picVdoInfoVdoCover.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "搜尋品番：";
            // 
            // userControl11
            // 
            this.userControl11.BottomMargin = 2;
            this.userControl11.HoverColor = System.Drawing.Color.Yellow;
            this.userControl11.LeftMargin = 2;
            this.userControl11.Location = new System.Drawing.Point(9, 209);
            this.userControl11.Margin = new System.Windows.Forms.Padding(4);
            this.userControl11.Name = "userControl11";
            this.userControl11.OutlineColor = System.Drawing.Color.DarkGray;
            this.userControl11.OutlineThickness = 1;
            this.userControl11.RightMargin = 2;
            this.userControl11.SelectedColor = System.Drawing.Color.RoyalBlue;
            this.userControl11.Size = new System.Drawing.Size(99, 23);
            this.userControl11.StarCount = 5;
            this.userControl11.StarSpacing = 8;
            this.userControl11.TabIndex = 44;
            this.userControl11.TopMargin = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(7, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 45;
            this.label3.Text = "評分：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 783);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainForm";
            this.Text = "RrAvManager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageFileManager.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMainLsit)).EndInit();
            this.tabPageDebug.ResumeLayout(false);
            this.tabPageDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVdoInfoVdoCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFolderExploer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labCurrDir;
        private System.Windows.Forms.Button btnFileScan;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFileManager;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.DataGridView gvMainLsit;
        private System.Windows.Forms.DataGridViewImageColumn COVER_IMAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIDEO_FILE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INDEX;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labScanDir;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.ListBox litBoxFileList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtVdoInfoIntro;
        private System.Windows.Forms.Label labVdoInfoIntro;
        private System.Windows.Forms.TextBox txtVdoInfoLength;
        private System.Windows.Forms.Label labVdoInfoLength;
        private System.Windows.Forms.TextBox txtVdoInfoSno;
        private System.Windows.Forms.Label labVdoInfoSno;
        private System.Windows.Forms.TextBox txtVdoInfoReleaseDate;
        private System.Windows.Forms.Label labVdoInfoReleaseDate;
        private System.Windows.Forms.TextBox txtVdoInfoIssuer;
        private System.Windows.Forms.Label labVdoInfoIssuer;
        private System.Windows.Forms.TextBox txtVdoInfoMaker;
        private System.Windows.Forms.Label labVdoInfoVdoMaker;
        private System.Windows.Forms.TextBox txtVdoInfoActor;
        private System.Windows.Forms.Label labVdoInfoActor;
        private System.Windows.Forms.TextBox txtVdoInfoVdoName;
        private System.Windows.Forms.Label labVdoInfoVdoName;
        private System.Windows.Forms.Button btnSearchSNO;
        private System.Windows.Forms.TextBox txtSearchID;
        private System.Windows.Forms.PictureBox picVdoInfoVdoCover;
        private System.Windows.Forms.Label label2;
        private control.UserControl1 userControl11;
        private System.Windows.Forms.Label label3;
    }
}

