namespace WatchNyan
{
    partial class frmMain
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
            this.lblCaption1 = new System.Windows.Forms.Label();
            this.btnSelectInputFile = new System.Windows.Forms.Button();
            this.lblCaption3 = new System.Windows.Forms.Label();
            this.grpEncoding = new System.Windows.Forms.Panel();
            this.optEncoding_UTF8 = new System.Windows.Forms.RadioButton();
            this.optEncoding_ANSI = new System.Windows.Forms.RadioButton();
            this.lblCaption2 = new System.Windows.Forms.Label();
            this.lstKeyword = new System.Windows.Forms.ListView();
            this.lstKeyword_colKeyword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstKeyword_colKeyword2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstKeyWord_ShowFullLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCaption5 = new System.Windows.Forms.Label();
            this.grpPromptMethod = new System.Windows.Forms.Panel();
            this.btnNotify_APIurl = new System.Windows.Forms.Button();
            this.chkNotify_API = new System.Windows.Forms.CheckBox();
            this.chkNotify_OpenWnd = new System.Windows.Forms.CheckBox();
            this.chkNotify_TrayBubble = new System.Windows.Forms.CheckBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.txtTotalFinding = new System.Windows.Forms.Label();
            this.lblCaption9 = new System.Windows.Forms.Label();
            this.txtCurrentOffset = new System.Windows.Forms.Label();
            this.lblCaption8 = new System.Windows.Forms.Label();
            this.grpOffset = new System.Windows.Forms.Panel();
            this.optStartFrom_Begining = new System.Windows.Forms.RadioButton();
            this.optStartFrom_End = new System.Windows.Forms.RadioButton();
            this.lblCaption4 = new System.Windows.Forms.Label();
            this.lblCaption6 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.NumericUpDown();
            this.lblCaption7 = new System.Windows.Forms.Label();
            this.cmdOpen = new System.Windows.Forms.OpenFileDialog();
            this.mnuKeyword = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuKeyword_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKeyword_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKeyword_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIco = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrChecker = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCaption10 = new System.Windows.Forms.Label();
            this.txtInstanceTag = new System.Windows.Forms.TextBox();
            this.txtInputFile = new System.Windows.Forms.ComboBox();
            this.grpInput = new System.Windows.Forms.Panel();
            this.txtInputAPISecret = new System.Windows.Forms.TextBox();
            this.lblCaption11 = new System.Windows.Forms.Label();
            this.txtInputAPI = new System.Windows.Forms.TextBox();
            this.optMonitorOn_Remote = new System.Windows.Forms.RadioButton();
            this.optMonitorOn_Local = new System.Windows.Forms.RadioButton();
            this.grpEncoding.SuspendLayout();
            this.grpPromptMethod.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.grpOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).BeginInit();
            this.mnuKeyword.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption1
            // 
            this.lblCaption1.Location = new System.Drawing.Point(12, 13);
            this.lblCaption1.Name = "lblCaption1";
            this.lblCaption1.Size = new System.Drawing.Size(67, 18);
            this.lblCaption1.TabIndex = 0;
            this.lblCaption1.Text = "监听目标：";
            this.lblCaption1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectInputFile
            // 
            this.btnSelectInputFile.Location = new System.Drawing.Point(460, 2);
            this.btnSelectInputFile.Name = "btnSelectInputFile";
            this.btnSelectInputFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectInputFile.TabIndex = 2;
            this.btnSelectInputFile.Text = "浏览(&B)...";
            this.btnSelectInputFile.UseVisualStyleBackColor = true;
            this.btnSelectInputFile.Click += new System.EventHandler(this.btnSelectInputFile_Click);
            // 
            // lblCaption3
            // 
            this.lblCaption3.Location = new System.Drawing.Point(298, 77);
            this.lblCaption3.Name = "lblCaption3";
            this.lblCaption3.Size = new System.Drawing.Size(88, 18);
            this.lblCaption3.TabIndex = 5;
            this.lblCaption3.Text = "文件编码：";
            this.lblCaption3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpEncoding
            // 
            this.grpEncoding.Controls.Add(this.optEncoding_UTF8);
            this.grpEncoding.Controls.Add(this.optEncoding_ANSI);
            this.grpEncoding.Location = new System.Drawing.Point(392, 75);
            this.grpEncoding.Name = "grpEncoding";
            this.grpEncoding.Size = new System.Drawing.Size(220, 20);
            this.grpEncoding.TabIndex = 6;
            // 
            // optEncoding_UTF8
            // 
            this.optEncoding_UTF8.Location = new System.Drawing.Point(113, 0);
            this.optEncoding_UTF8.Name = "optEncoding_UTF8";
            this.optEncoding_UTF8.Size = new System.Drawing.Size(95, 20);
            this.optEncoding_UTF8.TabIndex = 1;
            this.optEncoding_UTF8.Text = "UTF-8";
            this.optEncoding_UTF8.UseVisualStyleBackColor = true;
            // 
            // optEncoding_ANSI
            // 
            this.optEncoding_ANSI.Checked = true;
            this.optEncoding_ANSI.Location = new System.Drawing.Point(0, 0);
            this.optEncoding_ANSI.Name = "optEncoding_ANSI";
            this.optEncoding_ANSI.Size = new System.Drawing.Size(107, 20);
            this.optEncoding_ANSI.TabIndex = 0;
            this.optEncoding_ANSI.TabStop = true;
            this.optEncoding_ANSI.Text = "GB2312 / ANSI";
            this.optEncoding_ANSI.UseVisualStyleBackColor = true;
            // 
            // lblCaption2
            // 
            this.lblCaption2.Location = new System.Drawing.Point(12, 68);
            this.lblCaption2.Name = "lblCaption2";
            this.lblCaption2.Size = new System.Drawing.Size(276, 18);
            this.lblCaption2.TabIndex = 2;
            this.lblCaption2.Text = "监视关键字列表（右键修改，大小写敏感）";
            this.lblCaption2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstKeyword
            // 
            this.lstKeyword.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstKeyword_colKeyword,
            this.lstKeyword_colKeyword2,
            this.lstKeyWord_ShowFullLine});
            this.lstKeyword.FullRowSelect = true;
            this.lstKeyword.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstKeyword.Location = new System.Drawing.Point(14, 94);
            this.lstKeyword.Name = "lstKeyword";
            this.lstKeyword.Size = new System.Drawing.Size(274, 216);
            this.lstKeyword.TabIndex = 3;
            this.lstKeyword.UseCompatibleStateImageBehavior = false;
            this.lstKeyword.View = System.Windows.Forms.View.Details;
            // 
            // lstKeyword_colKeyword
            // 
            this.lstKeyword_colKeyword.Text = "关键字";
            this.lstKeyword_colKeyword.Width = 100;
            // 
            // lstKeyword_colKeyword2
            // 
            this.lstKeyword_colKeyword2.Text = "配合关键字";
            this.lstKeyword_colKeyword2.Width = 100;
            // 
            // lstKeyWord_ShowFullLine
            // 
            this.lstKeyWord_ShowFullLine.Text = "显示行";
            // 
            // lblCaption5
            // 
            this.lblCaption5.Location = new System.Drawing.Point(298, 145);
            this.lblCaption5.Name = "lblCaption5";
            this.lblCaption5.Size = new System.Drawing.Size(88, 18);
            this.lblCaption5.TabIndex = 9;
            this.lblCaption5.Text = "提示方式：";
            this.lblCaption5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPromptMethod
            // 
            this.grpPromptMethod.Controls.Add(this.btnNotify_APIurl);
            this.grpPromptMethod.Controls.Add(this.chkNotify_API);
            this.grpPromptMethod.Controls.Add(this.chkNotify_OpenWnd);
            this.grpPromptMethod.Controls.Add(this.chkNotify_TrayBubble);
            this.grpPromptMethod.Location = new System.Drawing.Point(392, 135);
            this.grpPromptMethod.Name = "grpPromptMethod";
            this.grpPromptMethod.Size = new System.Drawing.Size(220, 56);
            this.grpPromptMethod.TabIndex = 10;
            // 
            // btnNotify_APIurl
            // 
            this.btnNotify_APIurl.Location = new System.Drawing.Point(72, 31);
            this.btnNotify_APIurl.Name = "btnNotify_APIurl";
            this.btnNotify_APIurl.Size = new System.Drawing.Size(148, 22);
            this.btnNotify_APIurl.TabIndex = 3;
            this.btnNotify_APIurl.Text = "设置API地址...";
            this.btnNotify_APIurl.UseVisualStyleBackColor = true;
            this.btnNotify_APIurl.Click += new System.EventHandler(this.btnNotify_APIurl_Click);
            // 
            // chkNotify_API
            // 
            this.chkNotify_API.Location = new System.Drawing.Point(0, 33);
            this.chkNotify_API.Name = "chkNotify_API";
            this.chkNotify_API.Size = new System.Drawing.Size(72, 20);
            this.chkNotify_API.TabIndex = 2;
            this.chkNotify_API.Text = "远端API";
            this.chkNotify_API.UseVisualStyleBackColor = true;
            // 
            // chkNotify_OpenWnd
            // 
            this.chkNotify_OpenWnd.Location = new System.Drawing.Point(113, 4);
            this.chkNotify_OpenWnd.Name = "chkNotify_OpenWnd";
            this.chkNotify_OpenWnd.Size = new System.Drawing.Size(103, 20);
            this.chkNotify_OpenWnd.TabIndex = 1;
            this.chkNotify_OpenWnd.Text = "弹出窗口";
            this.chkNotify_OpenWnd.UseVisualStyleBackColor = true;
            // 
            // chkNotify_TrayBubble
            // 
            this.chkNotify_TrayBubble.Location = new System.Drawing.Point(0, 4);
            this.chkNotify_TrayBubble.Name = "chkNotify_TrayBubble";
            this.chkNotify_TrayBubble.Size = new System.Drawing.Size(107, 20);
            this.chkNotify_TrayBubble.TabIndex = 0;
            this.chkNotify_TrayBubble.Text = "通知区域气泡";
            this.chkNotify_TrayBubble.UseVisualStyleBackColor = true;
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(470, 232);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(142, 40);
            this.btnDo.TabIndex = 15;
            this.btnDo.Text = "启动监听";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.txtTotalFinding);
            this.grpSummary.Controls.Add(this.lblCaption9);
            this.grpSummary.Controls.Add(this.txtCurrentOffset);
            this.grpSummary.Controls.Add(this.lblCaption8);
            this.grpSummary.Location = new System.Drawing.Point(296, 274);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(316, 55);
            this.grpSummary.TabIndex = 16;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "统计信息";
            // 
            // txtTotalFinding
            // 
            this.txtTotalFinding.Location = new System.Drawing.Point(247, 17);
            this.txtTotalFinding.Name = "txtTotalFinding";
            this.txtTotalFinding.Size = new System.Drawing.Size(63, 32);
            this.txtTotalFinding.TabIndex = 3;
            this.txtTotalFinding.Text = "0";
            this.txtTotalFinding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCaption9
            // 
            this.lblCaption9.Location = new System.Drawing.Point(180, 16);
            this.lblCaption9.Name = "lblCaption9";
            this.lblCaption9.Size = new System.Drawing.Size(69, 32);
            this.lblCaption9.TabIndex = 2;
            this.lblCaption9.Text = "找到次数：";
            this.lblCaption9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCurrentOffset
            // 
            this.txtCurrentOffset.Location = new System.Drawing.Point(84, 16);
            this.txtCurrentOffset.Name = "txtCurrentOffset";
            this.txtCurrentOffset.Size = new System.Drawing.Size(93, 32);
            this.txtCurrentOffset.TabIndex = 1;
            this.txtCurrentOffset.Text = "0";
            this.txtCurrentOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCaption8
            // 
            this.lblCaption8.Location = new System.Drawing.Point(6, 16);
            this.lblCaption8.Name = "lblCaption8";
            this.lblCaption8.Size = new System.Drawing.Size(80, 32);
            this.lblCaption8.TabIndex = 0;
            this.lblCaption8.Text = "当前偏移量：";
            this.lblCaption8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpOffset
            // 
            this.grpOffset.Controls.Add(this.optStartFrom_Begining);
            this.grpOffset.Controls.Add(this.optStartFrom_End);
            this.grpOffset.Location = new System.Drawing.Point(392, 105);
            this.grpOffset.Name = "grpOffset";
            this.grpOffset.Size = new System.Drawing.Size(220, 20);
            this.grpOffset.TabIndex = 8;
            // 
            // optStartFrom_Begining
            // 
            this.optStartFrom_Begining.Location = new System.Drawing.Point(113, 0);
            this.optStartFrom_Begining.Name = "optStartFrom_Begining";
            this.optStartFrom_Begining.Size = new System.Drawing.Size(103, 20);
            this.optStartFrom_Begining.TabIndex = 1;
            this.optStartFrom_Begining.Text = "从开头开始";
            this.optStartFrom_Begining.UseVisualStyleBackColor = true;
            // 
            // optStartFrom_End
            // 
            this.optStartFrom_End.Checked = true;
            this.optStartFrom_End.Location = new System.Drawing.Point(0, 0);
            this.optStartFrom_End.Name = "optStartFrom_End";
            this.optStartFrom_End.Size = new System.Drawing.Size(107, 20);
            this.optStartFrom_End.TabIndex = 0;
            this.optStartFrom_End.TabStop = true;
            this.optStartFrom_End.Text = "从末尾开始";
            this.optStartFrom_End.UseVisualStyleBackColor = true;
            // 
            // lblCaption4
            // 
            this.lblCaption4.Location = new System.Drawing.Point(298, 107);
            this.lblCaption4.Name = "lblCaption4";
            this.lblCaption4.Size = new System.Drawing.Size(88, 18);
            this.lblCaption4.TabIndex = 7;
            this.lblCaption4.Text = "扫描起点：";
            this.lblCaption4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCaption6
            // 
            this.lblCaption6.Location = new System.Drawing.Point(298, 242);
            this.lblCaption6.Name = "lblCaption6";
            this.lblCaption6.Size = new System.Drawing.Size(88, 18);
            this.lblCaption6.TabIndex = 13;
            this.lblCaption6.Text = "采样间隔：";
            this.lblCaption6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(392, 242);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(47, 21);
            this.txtInterval.TabIndex = 14;
            // 
            // lblCaption7
            // 
            this.lblCaption7.Location = new System.Drawing.Point(444, 243);
            this.lblCaption7.Name = "lblCaption7";
            this.lblCaption7.Size = new System.Drawing.Size(20, 18);
            this.lblCaption7.TabIndex = 13;
            this.lblCaption7.Text = "秒";
            this.lblCaption7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdOpen
            // 
            this.cmdOpen.FileName = "openFileDialog1";
            // 
            // mnuKeyword
            // 
            this.mnuKeyword.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKeyword_Add,
            this.mnuKeyword_Modify,
            this.mnuKeyword_Remove});
            this.mnuKeyword.Name = "mnuKeyword";
            this.mnuKeyword.Size = new System.Drawing.Size(131, 70);
            this.mnuKeyword.Opened += new System.EventHandler(this.mnuKeyword_Opened);
            // 
            // mnuKeyword_Add
            // 
            this.mnuKeyword_Add.Name = "mnuKeyword_Add";
            this.mnuKeyword_Add.Size = new System.Drawing.Size(130, 22);
            this.mnuKeyword_Add.Text = "添加(&A)...";
            this.mnuKeyword_Add.Click += new System.EventHandler(this.mnuKeyword_Add_Click);
            // 
            // mnuKeyword_Modify
            // 
            this.mnuKeyword_Modify.Name = "mnuKeyword_Modify";
            this.mnuKeyword_Modify.Size = new System.Drawing.Size(130, 22);
            this.mnuKeyword_Modify.Text = "修改(&M)...";
            this.mnuKeyword_Modify.Click += new System.EventHandler(this.mnuKeyword_Modify_Click);
            // 
            // mnuKeyword_Remove
            // 
            this.mnuKeyword_Remove.Name = "mnuKeyword_Remove";
            this.mnuKeyword_Remove.Size = new System.Drawing.Size(130, 22);
            this.mnuKeyword_Remove.Text = "删除(&R)";
            this.mnuKeyword_Remove.Click += new System.EventHandler(this.mnuKeyword_Remove_Click);
            // 
            // trayIco
            // 
            this.trayIco.Text = "notifyIcon1";
            this.trayIco.Visible = true;
            this.trayIco.DoubleClick += new System.EventHandler(this.trayIco_DoubleClick);
            // 
            // tmrChecker
            // 
            this.tmrChecker.Tick += new System.EventHandler(this.tmrChecker_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "注意：将按行检索关键字，仅支持CRLF换行符！";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaption10
            // 
            this.lblCaption10.Location = new System.Drawing.Point(298, 202);
            this.lblCaption10.Name = "lblCaption10";
            this.lblCaption10.Size = new System.Drawing.Size(88, 18);
            this.lblCaption10.TabIndex = 11;
            this.lblCaption10.Text = "实例标识：";
            this.lblCaption10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInstanceTag
            // 
            this.txtInstanceTag.Location = new System.Drawing.Point(392, 202);
            this.txtInstanceTag.Name = "txtInstanceTag";
            this.txtInstanceTag.Size = new System.Drawing.Size(220, 21);
            this.txtInstanceTag.TabIndex = 12;
            // 
            // txtInputFile
            // 
            this.txtInputFile.FormattingEnabled = true;
            this.txtInputFile.Items.AddRange(new object[] {
            "1"});
            this.txtInputFile.Location = new System.Drawing.Point(89, 4);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(365, 20);
            this.txtInputFile.TabIndex = 1;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtInputAPISecret);
            this.grpInput.Controls.Add(this.lblCaption11);
            this.grpInput.Controls.Add(this.txtInputAPI);
            this.grpInput.Controls.Add(this.optMonitorOn_Remote);
            this.grpInput.Controls.Add(this.optMonitorOn_Local);
            this.grpInput.Controls.Add(this.txtInputFile);
            this.grpInput.Controls.Add(this.btnSelectInputFile);
            this.grpInput.Location = new System.Drawing.Point(73, 7);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(539, 55);
            this.grpInput.TabIndex = 1;
            // 
            // txtInputAPISecret
            // 
            this.txtInputAPISecret.Location = new System.Drawing.Point(344, 29);
            this.txtInputAPISecret.Name = "txtInputAPISecret";
            this.txtInputAPISecret.Size = new System.Drawing.Size(191, 21);
            this.txtInputAPISecret.TabIndex = 6;
            // 
            // lblCaption11
            // 
            this.lblCaption11.Location = new System.Drawing.Point(265, 30);
            this.lblCaption11.Name = "lblCaption11";
            this.lblCaption11.Size = new System.Drawing.Size(85, 18);
            this.lblCaption11.TabIndex = 5;
            this.lblCaption11.Text = "API Secret：";
            this.lblCaption11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInputAPI
            // 
            this.txtInputAPI.Location = new System.Drawing.Point(89, 29);
            this.txtInputAPI.Name = "txtInputAPI";
            this.txtInputAPI.Size = new System.Drawing.Size(170, 21);
            this.txtInputAPI.TabIndex = 4;
            // 
            // optMonitorOn_Remote
            // 
            this.optMonitorOn_Remote.AutoSize = true;
            this.optMonitorOn_Remote.Location = new System.Drawing.Point(12, 31);
            this.optMonitorOn_Remote.Name = "optMonitorOn_Remote";
            this.optMonitorOn_Remote.Size = new System.Drawing.Size(65, 16);
            this.optMonitorOn_Remote.TabIndex = 3;
            this.optMonitorOn_Remote.TabStop = true;
            this.optMonitorOn_Remote.Text = "远端API";
            this.optMonitorOn_Remote.UseVisualStyleBackColor = true;
            // 
            // optMonitorOn_Local
            // 
            this.optMonitorOn_Local.AutoSize = true;
            this.optMonitorOn_Local.Location = new System.Drawing.Point(12, 8);
            this.optMonitorOn_Local.Name = "optMonitorOn_Local";
            this.optMonitorOn_Local.Size = new System.Drawing.Size(71, 16);
            this.optMonitorOn_Local.TabIndex = 0;
            this.optMonitorOn_Local.TabStop = true;
            this.optMonitorOn_Local.Text = "本地文件";
            this.optMonitorOn_Local.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 337);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.txtInstanceTag);
            this.Controls.Add(this.lblCaption10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCaption7);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.lblCaption6);
            this.Controls.Add(this.grpOffset);
            this.Controls.Add(this.lblCaption4);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.grpPromptMethod);
            this.Controls.Add(this.lblCaption5);
            this.Controls.Add(this.lstKeyword);
            this.Controls.Add(this.lblCaption2);
            this.Controls.Add(this.grpEncoding);
            this.Controls.Add(this.lblCaption3);
            this.Controls.Add(this.lblCaption1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自在观喵";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpEncoding.ResumeLayout(false);
            this.grpPromptMethod.ResumeLayout(false);
            this.grpSummary.ResumeLayout(false);
            this.grpOffset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).EndInit();
            this.mnuKeyword.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption1;
        private System.Windows.Forms.Button btnSelectInputFile;
        private System.Windows.Forms.Label lblCaption3;
        private System.Windows.Forms.Panel grpEncoding;
        private System.Windows.Forms.RadioButton optEncoding_UTF8;
        private System.Windows.Forms.RadioButton optEncoding_ANSI;
        private System.Windows.Forms.Label lblCaption2;
        private System.Windows.Forms.ListView lstKeyword;
        private System.Windows.Forms.ColumnHeader lstKeyword_colKeyword;
        private System.Windows.Forms.ColumnHeader lstKeyword_colKeyword2;
        private System.Windows.Forms.Label lblCaption5;
        private System.Windows.Forms.Panel grpPromptMethod;
        private System.Windows.Forms.CheckBox chkNotify_OpenWnd;
        private System.Windows.Forms.CheckBox chkNotify_TrayBubble;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblCaption8;
        private System.Windows.Forms.Panel grpOffset;
        private System.Windows.Forms.RadioButton optStartFrom_Begining;
        private System.Windows.Forms.RadioButton optStartFrom_End;
        private System.Windows.Forms.Label lblCaption4;
        private System.Windows.Forms.Label txtTotalFinding;
        private System.Windows.Forms.Label lblCaption9;
        private System.Windows.Forms.Label txtCurrentOffset;
        private System.Windows.Forms.Label lblCaption6;
        private System.Windows.Forms.NumericUpDown txtInterval;
        private System.Windows.Forms.Label lblCaption7;
        private System.Windows.Forms.OpenFileDialog cmdOpen;
        private System.Windows.Forms.ContextMenuStrip mnuKeyword;
        private System.Windows.Forms.ToolStripMenuItem mnuKeyword_Add;
        private System.Windows.Forms.ToolStripMenuItem mnuKeyword_Modify;
        private System.Windows.Forms.ToolStripMenuItem mnuKeyword_Remove;
        private System.Windows.Forms.NotifyIcon trayIco;
        private System.Windows.Forms.Timer tmrChecker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCaption10;
        private System.Windows.Forms.TextBox txtInstanceTag;
        private System.Windows.Forms.ComboBox txtInputFile;
        private System.Windows.Forms.ColumnHeader lstKeyWord_ShowFullLine;
        private System.Windows.Forms.Button btnNotify_APIurl;
        private System.Windows.Forms.CheckBox chkNotify_API;
        private System.Windows.Forms.Panel grpInput;
        private System.Windows.Forms.TextBox txtInputAPI;
        private System.Windows.Forms.RadioButton optMonitorOn_Remote;
        private System.Windows.Forms.RadioButton optMonitorOn_Local;
        private System.Windows.Forms.TextBox txtInputAPISecret;
        private System.Windows.Forms.Label lblCaption11;
    }
}

