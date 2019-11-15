namespace Chip8
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblROM = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dsadasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstDump = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.txtST = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.gridRegs = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.txtI = new System.Windows.Forms.TextBox();
            this.pnlHex = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVideo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInputF = new System.Windows.Forms.Button();
            this.btnInputB = new System.Windows.Forms.Button();
            this.btnInput0 = new System.Windows.Forms.Button();
            this.btnInputA = new System.Windows.Forms.Button();
            this.btnInputE = new System.Windows.Forms.Button();
            this.btnInput9 = new System.Windows.Forms.Button();
            this.btnInput8 = new System.Windows.Forms.Button();
            this.btnInput7 = new System.Windows.Forms.Button();
            this.btnInputD = new System.Windows.Forms.Button();
            this.btnInput6 = new System.Windows.Forms.Button();
            this.btnInput5 = new System.Windows.Forms.Button();
            this.btnInput4 = new System.Windows.Forms.Button();
            this.btnInputC = new System.Windows.Forms.Button();
            this.btnInput3 = new System.Windows.Forms.Button();
            this.btnInput2 = new System.Windows.Forms.Button();
            this.btnInput1 = new System.Windows.Forms.Button();
            this.status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegs)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblROM});
            this.status.Location = new System.Drawing.Point(0, 532);
            this.status.Name = "status";
            this.status.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.status.Size = new System.Drawing.Size(756, 22);
            this.status.TabIndex = 2;
            // 
            // lblROM
            // 
            this.lblROM.Name = "lblROM";
            this.lblROM.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dsadasdToolStripMenuItem,
            this.cPUToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dsadasdToolStripMenuItem
            // 
            this.dsadasdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.dsadasdToolStripMenuItem.Name = "dsadasdToolStripMenuItem";
            this.dsadasdToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dsadasdToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cPUToolStripMenuItem
            // 
            this.cPUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadROMToolStripMenuItem,
            this.toolStripMenuItem1,
            this.runToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stepToolStripMenuItem});
            this.cPUToolStripMenuItem.Name = "cPUToolStripMenuItem";
            this.cPUToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cPUToolStripMenuItem.Text = "&CPU";
            // 
            // loadROMToolStripMenuItem
            // 
            this.loadROMToolStripMenuItem.Name = "loadROMToolStripMenuItem";
            this.loadROMToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.loadROMToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.loadROMToolStripMenuItem.Text = "&Load ROM...";
            this.loadROMToolStripMenuItem.Click += new System.EventHandler(this.loadROMToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 24);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer4.Size = new System.Drawing.Size(756, 508);
            this.splitContainer4.SplitterDistance = 429;
            this.splitContainer4.TabIndex = 7;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pnlHex);
            this.splitContainer3.Size = new System.Drawing.Size(429, 508);
            this.splitContainer3.SplitterDistance = 282;
            this.splitContainer3.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstDump);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(429, 282);
            this.splitContainer2.SplitterDistance = 227;
            this.splitContainer2.TabIndex = 6;
            // 
            // lstDump
            // 
            this.lstDump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDump.FormattingEnabled = true;
            this.lstDump.IntegralHeight = false;
            this.lstDump.Location = new System.Drawing.Point(0, 0);
            this.lstDump.Name = "lstDump";
            this.lstDump.Size = new System.Drawing.Size(227, 282);
            this.lstDump.TabIndex = 3;
            this.lstDump.DoubleClick += new System.EventHandler(this.lstDump_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDT);
            this.groupBox2.Controls.Add(this.txtST);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnRun);
            this.groupBox2.Controls.Add(this.gridRegs);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnStep);
            this.groupBox2.Controls.Add(this.txtPC);
            this.groupBox2.Controls.Add(this.txtI);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 282);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CPU";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(127, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "SP";
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(130, 36);
            this.txtSP.Name = "txtSP";
            this.txtSP.ReadOnly = true;
            this.txtSP.Size = new System.Drawing.Size(53, 20);
            this.txtSP.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "DT";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(65, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "ST";
            // 
            // txtDT
            // 
            this.txtDT.Location = new System.Drawing.Point(6, 78);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(53, 20);
            this.txtDT.TabIndex = 15;
            // 
            // txtST
            // 
            this.txtST.Location = new System.Drawing.Point(68, 78);
            this.txtST.Name = "txtST";
            this.txtST.Size = new System.Drawing.Size(53, 20);
            this.txtST.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "PC";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(130, 130);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(53, 23);
            this.btnRun.TabIndex = 13;
            this.btnRun.Text = "Run (F5)";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // gridRegs
            // 
            this.gridRegs.AllowUserToAddRows = false;
            this.gridRegs.AllowUserToDeleteRows = false;
            this.gridRegs.AllowUserToResizeColumns = false;
            this.gridRegs.AllowUserToResizeRows = false;
            this.gridRegs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridRegs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridRegs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridRegs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridRegs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRegs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.gridRegs.Location = new System.Drawing.Point(6, 104);
            this.gridRegs.MultiSelect = false;
            this.gridRegs.Name = "gridRegs";
            this.gridRegs.RowHeadersVisible = false;
            this.gridRegs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridRegs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRegs.Size = new System.Drawing.Size(115, 178);
            this.gridRegs.TabIndex = 6;
            this.gridRegs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridRegs_CellBeginEdit);
            this.gridRegs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegs_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Vx";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 44;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "0x{0:x3}";
            dataGridViewCellStyle1.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Value";
            this.Column2.MaxInputLength = 6;
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 40;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(130, 156);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(53, 23);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(65, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Index";
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(130, 104);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(53, 23);
            this.btnStep.TabIndex = 11;
            this.btnStep.Text = "Step (F11)";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // txtPC
            // 
            this.txtPC.Location = new System.Drawing.Point(6, 36);
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(53, 20);
            this.txtPC.TabIndex = 8;
            // 
            // txtI
            // 
            this.txtI.Location = new System.Drawing.Point(68, 36);
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(53, 20);
            this.txtI.TabIndex = 10;
            // 
            // pnlHex
            // 
            this.pnlHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHex.Location = new System.Drawing.Point(0, 0);
            this.pnlHex.Name = "pnlHex";
            this.pnlHex.Size = new System.Drawing.Size(429, 222);
            this.pnlHex.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnVideo);
            this.groupBox3.Location = new System.Drawing.Point(3, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 52);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(6, 20);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(146, 23);
            this.btnVideo.TabIndex = 25;
            this.btnVideo.Text = "Show video";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInputF);
            this.groupBox1.Controls.Add(this.btnInputB);
            this.groupBox1.Controls.Add(this.btnInput0);
            this.groupBox1.Controls.Add(this.btnInputA);
            this.groupBox1.Controls.Add(this.btnInputE);
            this.groupBox1.Controls.Add(this.btnInput9);
            this.groupBox1.Controls.Add(this.btnInput8);
            this.groupBox1.Controls.Add(this.btnInput7);
            this.groupBox1.Controls.Add(this.btnInputD);
            this.groupBox1.Controls.Add(this.btnInput6);
            this.groupBox1.Controls.Add(this.btnInput5);
            this.groupBox1.Controls.Add(this.btnInput4);
            this.groupBox1.Controls.Add(this.btnInputC);
            this.groupBox1.Controls.Add(this.btnInput3);
            this.groupBox1.Controls.Add(this.btnInput2);
            this.groupBox1.Controls.Add(this.btnInput1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 179);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // btnInputF
            // 
            this.btnInputF.Location = new System.Drawing.Point(120, 138);
            this.btnInputF.Name = "btnInputF";
            this.btnInputF.Size = new System.Drawing.Size(32, 32);
            this.btnInputF.TabIndex = 40;
            this.btnInputF.Text = "F";
            this.btnInputF.UseVisualStyleBackColor = true;
            this.btnInputF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInputF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInputB
            // 
            this.btnInputB.Location = new System.Drawing.Point(82, 138);
            this.btnInputB.Name = "btnInputB";
            this.btnInputB.Size = new System.Drawing.Size(32, 32);
            this.btnInputB.TabIndex = 39;
            this.btnInputB.Text = "B";
            this.btnInputB.UseVisualStyleBackColor = true;
            this.btnInputB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInputB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput0
            // 
            this.btnInput0.Location = new System.Drawing.Point(44, 138);
            this.btnInput0.Name = "btnInput0";
            this.btnInput0.Size = new System.Drawing.Size(32, 32);
            this.btnInput0.TabIndex = 38;
            this.btnInput0.Text = "0";
            this.btnInput0.UseVisualStyleBackColor = true;
            this.btnInput0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInputA
            // 
            this.btnInputA.Location = new System.Drawing.Point(6, 138);
            this.btnInputA.Name = "btnInputA";
            this.btnInputA.Size = new System.Drawing.Size(32, 32);
            this.btnInputA.TabIndex = 37;
            this.btnInputA.Text = "A";
            this.btnInputA.UseVisualStyleBackColor = true;
            this.btnInputA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInputA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInputE
            // 
            this.btnInputE.Location = new System.Drawing.Point(120, 100);
            this.btnInputE.Name = "btnInputE";
            this.btnInputE.Size = new System.Drawing.Size(32, 32);
            this.btnInputE.TabIndex = 36;
            this.btnInputE.Text = "E";
            this.btnInputE.UseVisualStyleBackColor = true;
            this.btnInputE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInputE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput9
            // 
            this.btnInput9.Location = new System.Drawing.Point(82, 100);
            this.btnInput9.Name = "btnInput9";
            this.btnInput9.Size = new System.Drawing.Size(32, 32);
            this.btnInput9.TabIndex = 35;
            this.btnInput9.Tag = "";
            this.btnInput9.Text = "9";
            this.btnInput9.UseVisualStyleBackColor = true;
            this.btnInput9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput8
            // 
            this.btnInput8.Location = new System.Drawing.Point(44, 100);
            this.btnInput8.Name = "btnInput8";
            this.btnInput8.Size = new System.Drawing.Size(32, 32);
            this.btnInput8.TabIndex = 34;
            this.btnInput8.Tag = "";
            this.btnInput8.Text = "8";
            this.btnInput8.UseVisualStyleBackColor = true;
            this.btnInput8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput7
            // 
            this.btnInput7.Location = new System.Drawing.Point(6, 100);
            this.btnInput7.Name = "btnInput7";
            this.btnInput7.Size = new System.Drawing.Size(32, 32);
            this.btnInput7.TabIndex = 33;
            this.btnInput7.Tag = "";
            this.btnInput7.Text = "7";
            this.btnInput7.UseVisualStyleBackColor = true;
            this.btnInput7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInputD
            // 
            this.btnInputD.Location = new System.Drawing.Point(120, 62);
            this.btnInputD.Name = "btnInputD";
            this.btnInputD.Size = new System.Drawing.Size(32, 32);
            this.btnInputD.TabIndex = 32;
            this.btnInputD.Text = "D";
            this.btnInputD.UseVisualStyleBackColor = true;
            this.btnInputD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInputD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput6
            // 
            this.btnInput6.Location = new System.Drawing.Point(82, 62);
            this.btnInput6.Name = "btnInput6";
            this.btnInput6.Size = new System.Drawing.Size(32, 32);
            this.btnInput6.TabIndex = 31;
            this.btnInput6.Tag = "";
            this.btnInput6.Text = "6";
            this.btnInput6.UseVisualStyleBackColor = true;
            this.btnInput6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput5
            // 
            this.btnInput5.Location = new System.Drawing.Point(44, 62);
            this.btnInput5.Name = "btnInput5";
            this.btnInput5.Size = new System.Drawing.Size(32, 32);
            this.btnInput5.TabIndex = 30;
            this.btnInput5.Tag = "";
            this.btnInput5.Text = "5";
            this.btnInput5.UseVisualStyleBackColor = true;
            this.btnInput5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput4
            // 
            this.btnInput4.Location = new System.Drawing.Point(6, 62);
            this.btnInput4.Name = "btnInput4";
            this.btnInput4.Size = new System.Drawing.Size(32, 32);
            this.btnInput4.TabIndex = 29;
            this.btnInput4.Tag = "";
            this.btnInput4.Text = "4";
            this.btnInput4.UseVisualStyleBackColor = true;
            this.btnInput4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInputC
            // 
            this.btnInputC.Location = new System.Drawing.Point(120, 24);
            this.btnInputC.Name = "btnInputC";
            this.btnInputC.Size = new System.Drawing.Size(32, 32);
            this.btnInputC.TabIndex = 28;
            this.btnInputC.Text = "C";
            this.btnInputC.UseVisualStyleBackColor = true;
            this.btnInputC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInputC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput3
            // 
            this.btnInput3.Location = new System.Drawing.Point(82, 24);
            this.btnInput3.Name = "btnInput3";
            this.btnInput3.Size = new System.Drawing.Size(32, 32);
            this.btnInput3.TabIndex = 27;
            this.btnInput3.Tag = "";
            this.btnInput3.Text = "3";
            this.btnInput3.UseVisualStyleBackColor = true;
            this.btnInput3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput2
            // 
            this.btnInput2.Location = new System.Drawing.Point(44, 24);
            this.btnInput2.Name = "btnInput2";
            this.btnInput2.Size = new System.Drawing.Size(32, 32);
            this.btnInput2.TabIndex = 26;
            this.btnInput2.Tag = "";
            this.btnInput2.Text = "2";
            this.btnInput2.UseVisualStyleBackColor = true;
            this.btnInput2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // btnInput1
            // 
            this.btnInput1.Location = new System.Drawing.Point(6, 24);
            this.btnInput1.Name = "btnInput1";
            this.btnInput1.Size = new System.Drawing.Size(32, 32);
            this.btnInput1.TabIndex = 25;
            this.btnInput1.Tag = "";
            this.btnInput1.Text = "1";
            this.btnInput1.UseVisualStyleBackColor = true;
            this.btnInput1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_MouseDown);
            this.btnInput1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_MouseUp);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 554);
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "Chip-8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegs)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dsadasdToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstDump;
        private System.Windows.Forms.Panel pnlHex;
        private System.Windows.Forms.ToolStripMenuItem cPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridRegs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInputF;
        private System.Windows.Forms.Button btnInputB;
        private System.Windows.Forms.Button btnInput0;
        private System.Windows.Forms.Button btnInputA;
        private System.Windows.Forms.Button btnInputE;
        private System.Windows.Forms.Button btnInput9;
        private System.Windows.Forms.Button btnInput8;
        private System.Windows.Forms.Button btnInput7;
        private System.Windows.Forms.Button btnInputD;
        private System.Windows.Forms.Button btnInput6;
        private System.Windows.Forms.Button btnInput5;
        private System.Windows.Forms.Button btnInput4;
        private System.Windows.Forms.Button btnInputC;
        private System.Windows.Forms.Button btnInput3;
        private System.Windows.Forms.Button btnInput2;
        private System.Windows.Forms.Button btnInput1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.TextBox txtST;
        private System.Windows.Forms.ToolStripStatusLabel lblROM;
    }
}