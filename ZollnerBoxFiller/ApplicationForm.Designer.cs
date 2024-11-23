namespace ZollnerBoxFiller
{
    partial class ApplicationForm
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
            this.plPLC = new TX.Framework.WindowUI.Controls.Panel();
            this.btn_autoagv3_stop = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoagv3_start = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoagv2_stop = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoagv2_start = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoagv1_stop = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoagv1_start = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoprc_stop = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_autoprc_start = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_rollout = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_TakeScanFromEquiment2 = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_TakeScanFromEquiment1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_TakePhotoFromEquiment0 = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_error = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_initial = new TX.Framework.WindowUI.Controls.TXButton();
            this.txt_port = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.labIP = new System.Windows.Forms.Label();
            this.btn_stop = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_start = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_close = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_open = new TX.Framework.WindowUI.Controls.TXButton();
            this.txTabControl1 = new TX.Framework.WindowUI.Controls.TXTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbReelInfo = new TX.Framework.WindowUI.Controls.TXGroupBox();
            this.panelCurrentProcessInfo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtCurrentProcessInfo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plReelIdCheckResult = new TX.Framework.WindowUI.Controls.Panel();
            this.pbReelIdCheckResult = new System.Windows.Forms.PictureBox();
            this.panel50 = new TX.Framework.WindowUI.Controls.Panel();
            this.curBufReelIdBindOutorderNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.panel46 = new TX.Framework.WindowUI.Controls.Panel();
            this.curBufReelId = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plNGDisplay = new TX.Framework.WindowUI.Controls.Panel();
            this.panelCurrentNGInfo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtCurrentNGInfo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.txt_NGDisplay = new System.Windows.Forms.Label();
            this.gbPLCInfo = new TX.Framework.WindowUI.Controls.TXGroupBox();
            this.plScan2 = new TX.Framework.WindowUI.Controls.Panel();
            this.pbScan2 = new System.Windows.Forms.PictureBox();
            this.plScan1 = new TX.Framework.WindowUI.Controls.Panel();
            this.pbScan1 = new System.Windows.Forms.PictureBox();
            this.plCamera = new TX.Framework.WindowUI.Controls.Panel();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.plUrgentStop = new TX.Framework.WindowUI.Controls.Panel();
            this.pbUrgentStop = new System.Windows.Forms.PictureBox();
            this.plAutoModel = new TX.Framework.WindowUI.Controls.Panel();
            this.pbAutoModel = new System.Windows.Forms.PictureBox();
            this.plUpInitialInfo = new TX.Framework.WindowUI.Controls.Panel();
            this.pbUpInitialInfo = new System.Windows.Forms.PictureBox();
            this.plStreamInitialing = new TX.Framework.WindowUI.Controls.Panel();
            this.pbStreamInitialing = new System.Windows.Forms.PictureBox();
            this.plUpInitialing = new TX.Framework.WindowUI.Controls.Panel();
            this.pbUpInitialing = new System.Windows.Forms.PictureBox();
            this.plSteamAutoing = new TX.Framework.WindowUI.Controls.Panel();
            this.pbSteamAutoing = new System.Windows.Forms.PictureBox();
            this.plUpAutoing = new TX.Framework.WindowUI.Controls.Panel();
            this.pbUpAutoing = new System.Windows.Forms.PictureBox();
            this.plStreamInitialOK = new TX.Framework.WindowUI.Controls.Panel();
            this.pbStreamInitialOK = new System.Windows.Forms.PictureBox();
            this.plUpInitialOK = new TX.Framework.WindowUI.Controls.Panel();
            this.pbUpInitialOK = new System.Windows.Forms.PictureBox();
            this.plAutoModeling = new TX.Framework.WindowUI.Controls.Panel();
            this.pbAutoModeling = new System.Windows.Forms.PictureBox();
            this.plRaiseError = new TX.Framework.WindowUI.Controls.Panel();
            this.pbRaiseError = new System.Windows.Forms.PictureBox();
            this.gbBoxInfo = new TX.Framework.WindowUI.Controls.TXGroupBox();
            this.panelCurrentBoxInfo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtCurrentBoxInfo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.panel49 = new TX.Framework.WindowUI.Controls.Panel();
            this.curBufBoxNoBindOutorderNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.panel48 = new TX.Framework.WindowUI.Controls.Panel();
            this.curBufIsEmpty = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.panel45 = new TX.Framework.WindowUI.Controls.Panel();
            this.curBufBoxNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plBoxCheckResult = new TX.Framework.WindowUI.Controls.Panel();
            this.pbBoxCheckResult = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.plAGVOutput3 = new TX.Framework.WindowUI.Controls.Panel();
            this.btn_RefreshAGVSide3 = new TX.Framework.WindowUI.Controls.TXButton();
            this.plAGVSide3CarcaseNo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide3CarcaseNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide3BoxNo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide3BoxNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.btn_CancelAGVSide3 = new TX.Framework.WindowUI.Controls.TXButton();
            this.plAGVSide3Method = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide3Method = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide3TaskCode = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide3TaskCode = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide3CheckResult = new TX.Framework.WindowUI.Controls.Panel();
            this.pbAGVSide3CheckResult = new System.Windows.Forms.PictureBox();
            this.plAGVInput2 = new TX.Framework.WindowUI.Controls.Panel();
            this.btn_RefreshAGVSide2 = new TX.Framework.WindowUI.Controls.TXButton();
            this.plAGVSide2CarcaseNo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide2CarcaseNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide2BoxNo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide2BoxNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.btn_CancelAGVSide2 = new TX.Framework.WindowUI.Controls.TXButton();
            this.plAGVSide2Method = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide2Method = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide2TaskCode = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide2TaskCode = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide2CheckResult = new TX.Framework.WindowUI.Controls.Panel();
            this.pbAGVSide2CheckResult = new System.Windows.Forms.PictureBox();
            this.plAGVInput1 = new TX.Framework.WindowUI.Controls.Panel();
            this.btn_RefreshAGVSide1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.plAGVSide1CarcaseNo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide1CarcaseNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide1BoxNo = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide1BoxNo = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.btn_CancelAGVSide1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.plAGVSide1Method = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide1Method = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide1TaskCode = new TX.Framework.WindowUI.Controls.Panel();
            this.txtAGVSide1TaskCode = new TX.Framework.WindowUI.Controls.TXTextBox();
            this.plAGVSide1CheckResult = new TX.Framework.WindowUI.Controls.Panel();
            this.pbAGVSide1CheckResult = new System.Windows.Forms.PictureBox();
            this.templateColumnHeader1 = new TX.Framework.WindowUI.Controls.TemplateColumnHeader();
            this.templateColumnHeader2 = new TX.Framework.WindowUI.Controls.TemplateColumnHeader();
            this.templateColumnHeader3 = new TX.Framework.WindowUI.Controls.TemplateColumnHeader();
            this.plPLC.SuspendLayout();
            this.txTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbReelInfo.SuspendLayout();
            this.panelCurrentProcessInfo.SuspendLayout();
            this.plReelIdCheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReelIdCheckResult)).BeginInit();
            this.panel50.SuspendLayout();
            this.panel46.SuspendLayout();
            this.plNGDisplay.SuspendLayout();
            this.panelCurrentNGInfo.SuspendLayout();
            this.gbPLCInfo.SuspendLayout();
            this.plScan2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScan2)).BeginInit();
            this.plScan1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScan1)).BeginInit();
            this.plCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            this.plUrgentStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUrgentStop)).BeginInit();
            this.plAutoModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoModel)).BeginInit();
            this.plUpInitialInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpInitialInfo)).BeginInit();
            this.plStreamInitialing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStreamInitialing)).BeginInit();
            this.plUpInitialing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpInitialing)).BeginInit();
            this.plSteamAutoing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSteamAutoing)).BeginInit();
            this.plUpAutoing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpAutoing)).BeginInit();
            this.plStreamInitialOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStreamInitialOK)).BeginInit();
            this.plUpInitialOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpInitialOK)).BeginInit();
            this.plAutoModeling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoModeling)).BeginInit();
            this.plRaiseError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRaiseError)).BeginInit();
            this.gbBoxInfo.SuspendLayout();
            this.panelCurrentBoxInfo.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel45.SuspendLayout();
            this.plBoxCheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxCheckResult)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.plAGVOutput3.SuspendLayout();
            this.plAGVSide3CarcaseNo.SuspendLayout();
            this.plAGVSide3BoxNo.SuspendLayout();
            this.plAGVSide3Method.SuspendLayout();
            this.plAGVSide3TaskCode.SuspendLayout();
            this.plAGVSide3CheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAGVSide3CheckResult)).BeginInit();
            this.plAGVInput2.SuspendLayout();
            this.plAGVSide2CarcaseNo.SuspendLayout();
            this.plAGVSide2BoxNo.SuspendLayout();
            this.plAGVSide2Method.SuspendLayout();
            this.plAGVSide2TaskCode.SuspendLayout();
            this.plAGVSide2CheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAGVSide2CheckResult)).BeginInit();
            this.plAGVInput1.SuspendLayout();
            this.plAGVSide1CarcaseNo.SuspendLayout();
            this.plAGVSide1BoxNo.SuspendLayout();
            this.plAGVSide1Method.SuspendLayout();
            this.plAGVSide1TaskCode.SuspendLayout();
            this.plAGVSide1CheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAGVSide1CheckResult)).BeginInit();
            this.SuspendLayout();
            // 
            // plPLC
            // 
            this.plPLC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plPLC.AssociatedSplitter = null;
            this.plPLC.BackColor = System.Drawing.Color.Transparent;
            this.plPLC.CaptionFont = new System.Drawing.Font("宋体", 9.5F);
            this.plPLC.CaptionHeight = 22;
            this.plPLC.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plPLC.Controls.Add(this.btn_autoagv3_stop);
            this.plPLC.Controls.Add(this.btn_autoagv3_start);
            this.plPLC.Controls.Add(this.btn_autoagv2_stop);
            this.plPLC.Controls.Add(this.btn_autoagv2_start);
            this.plPLC.Controls.Add(this.btn_autoagv1_stop);
            this.plPLC.Controls.Add(this.btn_autoagv1_start);
            this.plPLC.Controls.Add(this.btn_autoprc_stop);
            this.plPLC.Controls.Add(this.btn_autoprc_start);
            this.plPLC.Controls.Add(this.btn_rollout);
            this.plPLC.Controls.Add(this.btn_TakeScanFromEquiment2);
            this.plPLC.Controls.Add(this.btn_TakeScanFromEquiment1);
            this.plPLC.Controls.Add(this.btn_TakePhotoFromEquiment0);
            this.plPLC.Controls.Add(this.btn_error);
            this.plPLC.Controls.Add(this.btn_initial);
            this.plPLC.Controls.Add(this.txt_port);
            this.plPLC.Controls.Add(this.label1);
            this.plPLC.Controls.Add(this.txt_ip);
            this.plPLC.Controls.Add(this.labIP);
            this.plPLC.Controls.Add(this.btn_stop);
            this.plPLC.Controls.Add(this.btn_start);
            this.plPLC.Controls.Add(this.btn_close);
            this.plPLC.Controls.Add(this.btn_open);
            this.plPLC.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plPLC.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plPLC.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plPLC.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plPLC.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plPLC.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plPLC.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plPLC.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plPLC.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plPLC.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plPLC.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plPLC.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plPLC.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plPLC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plPLC.Image = null;
            this.plPLC.Location = new System.Drawing.Point(6, 6);
            this.plPLC.MinimumSize = new System.Drawing.Size(22, 22);
            this.plPLC.Name = "plPLC";
            this.plPLC.Size = new System.Drawing.Size(1248, 157);
            this.plPLC.TabIndex = 0;
            this.plPLC.Text = "码垛机";
            this.plPLC.ToolTipTextCloseIcon = null;
            this.plPLC.ToolTipTextExpandIconPanelCollapsed = null;
            this.plPLC.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btn_autoagv3_stop
            // 
            this.btn_autoagv3_stop.Image = null;
            this.btn_autoagv3_stop.Location = new System.Drawing.Point(1071, 77);
            this.btn_autoagv3_stop.Name = "btn_autoagv3_stop";
            this.btn_autoagv3_stop.Size = new System.Drawing.Size(110, 28);
            this.btn_autoagv3_stop.TabIndex = 31;
            this.btn_autoagv3_stop.Text = "停止3通道AGV任务";
            this.btn_autoagv3_stop.UseVisualStyleBackColor = true;
            this.btn_autoagv3_stop.Click += new System.EventHandler(this.btn_autoagv3_stop_Click);
            // 
            // btn_autoagv3_start
            // 
            this.btn_autoagv3_start.Image = null;
            this.btn_autoagv3_start.Location = new System.Drawing.Point(955, 77);
            this.btn_autoagv3_start.Name = "btn_autoagv3_start";
            this.btn_autoagv3_start.Size = new System.Drawing.Size(110, 28);
            this.btn_autoagv3_start.TabIndex = 30;
            this.btn_autoagv3_start.Text = "开启3通道AGV任务";
            this.btn_autoagv3_start.UseVisualStyleBackColor = true;
            this.btn_autoagv3_start.Click += new System.EventHandler(this.btn_autoagv3_start_Click);
            // 
            // btn_autoagv2_stop
            // 
            this.btn_autoagv2_stop.Image = null;
            this.btn_autoagv2_stop.Location = new System.Drawing.Point(839, 77);
            this.btn_autoagv2_stop.Name = "btn_autoagv2_stop";
            this.btn_autoagv2_stop.Size = new System.Drawing.Size(110, 28);
            this.btn_autoagv2_stop.TabIndex = 29;
            this.btn_autoagv2_stop.Text = "停止2通道AGV任务";
            this.btn_autoagv2_stop.UseVisualStyleBackColor = true;
            this.btn_autoagv2_stop.Click += new System.EventHandler(this.btn_autoagv2_stop_Click);
            // 
            // btn_autoagv2_start
            // 
            this.btn_autoagv2_start.Image = null;
            this.btn_autoagv2_start.Location = new System.Drawing.Point(723, 77);
            this.btn_autoagv2_start.Name = "btn_autoagv2_start";
            this.btn_autoagv2_start.Size = new System.Drawing.Size(110, 28);
            this.btn_autoagv2_start.TabIndex = 28;
            this.btn_autoagv2_start.Text = "开启2通道AGV任务";
            this.btn_autoagv2_start.UseVisualStyleBackColor = true;
            this.btn_autoagv2_start.Click += new System.EventHandler(this.btn_autoagv2_start_Click);
            // 
            // btn_autoagv1_stop
            // 
            this.btn_autoagv1_stop.Image = null;
            this.btn_autoagv1_stop.Location = new System.Drawing.Point(607, 77);
            this.btn_autoagv1_stop.Name = "btn_autoagv1_stop";
            this.btn_autoagv1_stop.Size = new System.Drawing.Size(110, 28);
            this.btn_autoagv1_stop.TabIndex = 27;
            this.btn_autoagv1_stop.Text = "停止1通道AGV任务";
            this.btn_autoagv1_stop.UseVisualStyleBackColor = true;
            this.btn_autoagv1_stop.Click += new System.EventHandler(this.btn_autoagv1_stop_Click);
            // 
            // btn_autoagv1_start
            // 
            this.btn_autoagv1_start.Image = null;
            this.btn_autoagv1_start.Location = new System.Drawing.Point(491, 77);
            this.btn_autoagv1_start.Name = "btn_autoagv1_start";
            this.btn_autoagv1_start.Size = new System.Drawing.Size(110, 28);
            this.btn_autoagv1_start.TabIndex = 26;
            this.btn_autoagv1_start.Text = "开启1通道AGV任务";
            this.btn_autoagv1_start.UseVisualStyleBackColor = true;
            this.btn_autoagv1_start.Click += new System.EventHandler(this.btn_autoagv1_start_Click);
            // 
            // btn_autoprc_stop
            // 
            this.btn_autoprc_stop.Image = null;
            this.btn_autoprc_stop.Location = new System.Drawing.Point(172, 114);
            this.btn_autoprc_stop.Name = "btn_autoprc_stop";
            this.btn_autoprc_stop.Size = new System.Drawing.Size(100, 28);
            this.btn_autoprc_stop.TabIndex = 25;
            this.btn_autoprc_stop.Text = "停止自动任务";
            this.btn_autoprc_stop.UseVisualStyleBackColor = true;
            this.btn_autoprc_stop.Click += new System.EventHandler(this.btn_autoprc_stop_Click);
            // 
            // btn_autoprc_start
            // 
            this.btn_autoprc_start.Image = null;
            this.btn_autoprc_start.Location = new System.Drawing.Point(66, 114);
            this.btn_autoprc_start.Name = "btn_autoprc_start";
            this.btn_autoprc_start.Size = new System.Drawing.Size(100, 28);
            this.btn_autoprc_start.TabIndex = 24;
            this.btn_autoprc_start.Text = "开启自动任务";
            this.btn_autoprc_start.UseVisualStyleBackColor = true;
            this.btn_autoprc_start.Click += new System.EventHandler(this.btn_autoprc_start_Click);
            // 
            // btn_rollout
            // 
            this.btn_rollout.Image = null;
            this.btn_rollout.Location = new System.Drawing.Point(323, 114);
            this.btn_rollout.Name = "btn_rollout";
            this.btn_rollout.Size = new System.Drawing.Size(161, 28);
            this.btn_rollout.TabIndex = 23;
            this.btn_rollout.Text = "码垛位箱子流出";
            this.btn_rollout.UseVisualStyleBackColor = true;
            this.btn_rollout.Click += new System.EventHandler(this.btn_rollout_Click);
            // 
            // btn_TakeScanFromEquiment2
            // 
            this.btn_TakeScanFromEquiment2.Enabled = false;
            this.btn_TakeScanFromEquiment2.Image = null;
            this.btn_TakeScanFromEquiment2.Location = new System.Drawing.Point(684, 114);
            this.btn_TakeScanFromEquiment2.Name = "btn_TakeScanFromEquiment2";
            this.btn_TakeScanFromEquiment2.Size = new System.Drawing.Size(92, 28);
            this.btn_TakeScanFromEquiment2.TabIndex = 21;
            this.btn_TakeScanFromEquiment2.Text = "扫码2";
            this.btn_TakeScanFromEquiment2.UseVisualStyleBackColor = true;
            this.btn_TakeScanFromEquiment2.Visible = false;
            this.btn_TakeScanFromEquiment2.Click += new System.EventHandler(this.btn_TakeScanFromEquiment2_Click);
            // 
            // btn_TakeScanFromEquiment1
            // 
            this.btn_TakeScanFromEquiment1.Enabled = false;
            this.btn_TakeScanFromEquiment1.Image = null;
            this.btn_TakeScanFromEquiment1.Location = new System.Drawing.Point(586, 114);
            this.btn_TakeScanFromEquiment1.Name = "btn_TakeScanFromEquiment1";
            this.btn_TakeScanFromEquiment1.Size = new System.Drawing.Size(92, 28);
            this.btn_TakeScanFromEquiment1.TabIndex = 20;
            this.btn_TakeScanFromEquiment1.Text = "扫码1";
            this.btn_TakeScanFromEquiment1.UseVisualStyleBackColor = true;
            this.btn_TakeScanFromEquiment1.Visible = false;
            this.btn_TakeScanFromEquiment1.Click += new System.EventHandler(this.btn_TakeScanFromEquiment1_Click);
            // 
            // btn_TakePhotoFromEquiment0
            // 
            this.btn_TakePhotoFromEquiment0.Enabled = false;
            this.btn_TakePhotoFromEquiment0.Image = null;
            this.btn_TakePhotoFromEquiment0.Location = new System.Drawing.Point(490, 114);
            this.btn_TakePhotoFromEquiment0.Name = "btn_TakePhotoFromEquiment0";
            this.btn_TakePhotoFromEquiment0.Size = new System.Drawing.Size(90, 28);
            this.btn_TakePhotoFromEquiment0.TabIndex = 18;
            this.btn_TakePhotoFromEquiment0.Text = "相机拍照";
            this.btn_TakePhotoFromEquiment0.UseVisualStyleBackColor = true;
            this.btn_TakePhotoFromEquiment0.Visible = false;
            this.btn_TakePhotoFromEquiment0.Click += new System.EventHandler(this.btn_TakePhotoFromEquiment0_Click);
            // 
            // btn_error
            // 
            this.btn_error.Image = null;
            this.btn_error.Location = new System.Drawing.Point(384, 77);
            this.btn_error.Name = "btn_error";
            this.btn_error.Size = new System.Drawing.Size(100, 28);
            this.btn_error.TabIndex = 12;
            this.btn_error.Text = "报警复位";
            this.btn_error.UseVisualStyleBackColor = true;
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // btn_initial
            // 
            this.btn_initial.Image = null;
            this.btn_initial.Location = new System.Drawing.Point(66, 77);
            this.btn_initial.Name = "btn_initial";
            this.btn_initial.Size = new System.Drawing.Size(100, 28);
            this.btn_initial.TabIndex = 11;
            this.btn_initial.Text = "初始化";
            this.btn_initial.UseVisualStyleBackColor = true;
            this.btn_initial.Click += new System.EventHandler(this.btn_initial_Click);
            // 
            // txt_port
            // 
            this.txt_port.BackColor = System.Drawing.Color.Transparent;
            this.txt_port.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_port.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_port.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_port.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_port.Image = null;
            this.txt_port.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_port.Location = new System.Drawing.Point(289, 30);
            this.txt_port.Name = "txt_port";
            this.txt_port.Padding = new System.Windows.Forms.Padding(2);
            this.txt_port.PasswordChar = '\0';
            this.txt_port.Required = false;
            this.txt_port.Size = new System.Drawing.Size(180, 22);
            this.txt_port.TabIndex = 9;
            this.txt_port.Text = "502";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "端口:";
            // 
            // txt_ip
            // 
            this.txt_ip.BackColor = System.Drawing.Color.Transparent;
            this.txt_ip.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_ip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ip.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ip.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ip.Image = null;
            this.txt_ip.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ip.Location = new System.Drawing.Point(66, 32);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Padding = new System.Windows.Forms.Padding(2);
            this.txt_ip.PasswordChar = '\0';
            this.txt_ip.Required = false;
            this.txt_ip.Size = new System.Drawing.Size(180, 22);
            this.txt_ip.TabIndex = 7;
            this.txt_ip.Text = "192.168.1.88";
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Location = new System.Drawing.Point(37, 40);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(35, 12);
            this.labIP.TabIndex = 6;
            this.labIP.Text = "主机:";
            // 
            // btn_stop
            // 
            this.btn_stop.Image = null;
            this.btn_stop.Location = new System.Drawing.Point(278, 77);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(100, 28);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "停止";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Image = null;
            this.btn_start.Location = new System.Drawing.Point(172, 77);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 28);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "开启";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = null;
            this.btn_close.Location = new System.Drawing.Point(596, 24);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 28);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "断开";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_open
            // 
            this.btn_open.Image = null;
            this.btn_open.Location = new System.Drawing.Point(491, 24);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(100, 28);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "连接";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txTabControl1
            // 
            this.txTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txTabControl1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txTabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txTabControl1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txTabControl1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txTabControl1.Controls.Add(this.tabPage1);
            this.txTabControl1.Controls.Add(this.tabPage3);
            this.txTabControl1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txTabControl1.Location = new System.Drawing.Point(6, 30);
            this.txTabControl1.Name = "txTabControl1";
            this.txTabControl1.SelectedIndex = 0;
            this.txTabControl1.Size = new System.Drawing.Size(1268, 988);
            this.txTabControl1.TabCornerRadius = 3;
            this.txTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbReelInfo);
            this.tabPage1.Controls.Add(this.plNGDisplay);
            this.tabPage1.Controls.Add(this.gbPLCInfo);
            this.tabPage1.Controls.Add(this.gbBoxInfo);
            this.tabPage1.Controls.Add(this.plPLC);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1260, 955);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主窗口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbReelInfo
            // 
            this.gbReelInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbReelInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.gbReelInfo.CaptionColor = System.Drawing.Color.Black;
            this.gbReelInfo.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.gbReelInfo.Controls.Add(this.panelCurrentProcessInfo);
            this.gbReelInfo.Controls.Add(this.plReelIdCheckResult);
            this.gbReelInfo.Controls.Add(this.panel50);
            this.gbReelInfo.Controls.Add(this.panel46);
            this.gbReelInfo.Location = new System.Drawing.Point(6, 299);
            this.gbReelInfo.Name = "gbReelInfo";
            this.gbReelInfo.Size = new System.Drawing.Size(1248, 113);
            this.gbReelInfo.TabIndex = 23;
            this.gbReelInfo.TabStop = false;
            this.gbReelInfo.Text = "当前料盘信息";
            this.gbReelInfo.TextMargin = 6;
            // 
            // panelCurrentProcessInfo
            // 
            this.panelCurrentProcessInfo.AssociatedSplitter = null;
            this.panelCurrentProcessInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelCurrentProcessInfo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panelCurrentProcessInfo.CaptionHeight = 32;
            this.panelCurrentProcessInfo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panelCurrentProcessInfo.Controls.Add(this.txtCurrentProcessInfo);
            this.panelCurrentProcessInfo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panelCurrentProcessInfo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panelCurrentProcessInfo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelCurrentProcessInfo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelCurrentProcessInfo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelCurrentProcessInfo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panelCurrentProcessInfo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panelCurrentProcessInfo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panelCurrentProcessInfo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelCurrentProcessInfo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelCurrentProcessInfo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelCurrentProcessInfo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelCurrentProcessInfo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panelCurrentProcessInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelCurrentProcessInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelCurrentProcessInfo.Image = null;
            this.panelCurrentProcessInfo.Location = new System.Drawing.Point(1002, 22);
            this.panelCurrentProcessInfo.MinimumSize = new System.Drawing.Size(32, 32);
            this.panelCurrentProcessInfo.Name = "panelCurrentProcessInfo";
            this.panelCurrentProcessInfo.Size = new System.Drawing.Size(240, 77);
            this.panelCurrentProcessInfo.TabIndex = 6;
            this.panelCurrentProcessInfo.Text = "当前物料操作信息";
            this.panelCurrentProcessInfo.ToolTipTextCloseIcon = null;
            this.panelCurrentProcessInfo.ToolTipTextExpandIconPanelCollapsed = null;
            this.panelCurrentProcessInfo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtCurrentProcessInfo
            // 
            this.txtCurrentProcessInfo.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentProcessInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtCurrentProcessInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrentProcessInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCurrentProcessInfo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtCurrentProcessInfo.Image = null;
            this.txtCurrentProcessInfo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtCurrentProcessInfo.Location = new System.Drawing.Point(4, 36);
            this.txtCurrentProcessInfo.Name = "txtCurrentProcessInfo";
            this.txtCurrentProcessInfo.Padding = new System.Windows.Forms.Padding(2);
            this.txtCurrentProcessInfo.PasswordChar = '\0';
            this.txtCurrentProcessInfo.Required = false;
            this.txtCurrentProcessInfo.Size = new System.Drawing.Size(232, 37);
            this.txtCurrentProcessInfo.TabIndex = 0;
            // 
            // plReelIdCheckResult
            // 
            this.plReelIdCheckResult.AssociatedSplitter = null;
            this.plReelIdCheckResult.BackColor = System.Drawing.Color.Transparent;
            this.plReelIdCheckResult.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plReelIdCheckResult.CaptionHeight = 32;
            this.plReelIdCheckResult.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plReelIdCheckResult.Controls.Add(this.pbReelIdCheckResult);
            this.plReelIdCheckResult.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plReelIdCheckResult.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plReelIdCheckResult.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plReelIdCheckResult.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plReelIdCheckResult.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plReelIdCheckResult.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plReelIdCheckResult.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plReelIdCheckResult.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plReelIdCheckResult.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plReelIdCheckResult.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plReelIdCheckResult.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plReelIdCheckResult.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plReelIdCheckResult.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plReelIdCheckResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plReelIdCheckResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plReelIdCheckResult.Image = null;
            this.plReelIdCheckResult.Location = new System.Drawing.Point(14, 20);
            this.plReelIdCheckResult.MinimumSize = new System.Drawing.Size(32, 32);
            this.plReelIdCheckResult.Name = "plReelIdCheckResult";
            this.plReelIdCheckResult.Size = new System.Drawing.Size(167, 77);
            this.plReelIdCheckResult.TabIndex = 3;
            this.plReelIdCheckResult.Text = "入料位料盘检测";
            this.plReelIdCheckResult.ToolTipTextCloseIcon = null;
            this.plReelIdCheckResult.ToolTipTextExpandIconPanelCollapsed = null;
            this.plReelIdCheckResult.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbReelIdCheckResult
            // 
            this.pbReelIdCheckResult.BackColor = System.Drawing.Color.Gray;
            this.pbReelIdCheckResult.Location = new System.Drawing.Point(0, 36);
            this.pbReelIdCheckResult.Name = "pbReelIdCheckResult";
            this.pbReelIdCheckResult.Size = new System.Drawing.Size(163, 38);
            this.pbReelIdCheckResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReelIdCheckResult.TabIndex = 3;
            this.pbReelIdCheckResult.TabStop = false;
            // 
            // panel50
            // 
            this.panel50.AssociatedSplitter = null;
            this.panel50.BackColor = System.Drawing.Color.Transparent;
            this.panel50.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panel50.CaptionHeight = 32;
            this.panel50.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panel50.Controls.Add(this.curBufReelIdBindOutorderNo);
            this.panel50.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panel50.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panel50.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel50.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel50.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel50.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel50.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel50.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel50.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel50.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel50.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel50.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel50.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panel50.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel50.Image = null;
            this.panel50.Location = new System.Drawing.Point(433, 22);
            this.panel50.MinimumSize = new System.Drawing.Size(32, 32);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(240, 77);
            this.panel50.TabIndex = 6;
            this.panel50.Text = "对应工单";
            this.panel50.ToolTipTextCloseIcon = null;
            this.panel50.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel50.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // curBufReelIdBindOutorderNo
            // 
            this.curBufReelIdBindOutorderNo.BackColor = System.Drawing.Color.Transparent;
            this.curBufReelIdBindOutorderNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.curBufReelIdBindOutorderNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curBufReelIdBindOutorderNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.curBufReelIdBindOutorderNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.curBufReelIdBindOutorderNo.Image = null;
            this.curBufReelIdBindOutorderNo.ImageSize = new System.Drawing.Size(0, 0);
            this.curBufReelIdBindOutorderNo.Location = new System.Drawing.Point(4, 36);
            this.curBufReelIdBindOutorderNo.Name = "curBufReelIdBindOutorderNo";
            this.curBufReelIdBindOutorderNo.Padding = new System.Windows.Forms.Padding(2);
            this.curBufReelIdBindOutorderNo.PasswordChar = '\0';
            this.curBufReelIdBindOutorderNo.Required = false;
            this.curBufReelIdBindOutorderNo.Size = new System.Drawing.Size(232, 37);
            this.curBufReelIdBindOutorderNo.TabIndex = 0;
            // 
            // panel46
            // 
            this.panel46.AssociatedSplitter = null;
            this.panel46.BackColor = System.Drawing.Color.Transparent;
            this.panel46.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panel46.CaptionHeight = 32;
            this.panel46.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panel46.Controls.Add(this.curBufReelId);
            this.panel46.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panel46.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panel46.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel46.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel46.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel46.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel46.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel46.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel46.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel46.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel46.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel46.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel46.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panel46.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel46.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel46.Image = null;
            this.panel46.Location = new System.Drawing.Point(187, 22);
            this.panel46.MinimumSize = new System.Drawing.Size(32, 32);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(240, 77);
            this.panel46.TabIndex = 2;
            this.panel46.Text = "当前料号";
            this.panel46.ToolTipTextCloseIcon = null;
            this.panel46.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel46.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // curBufReelId
            // 
            this.curBufReelId.BackColor = System.Drawing.Color.Transparent;
            this.curBufReelId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.curBufReelId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curBufReelId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.curBufReelId.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.curBufReelId.Image = null;
            this.curBufReelId.ImageSize = new System.Drawing.Size(0, 0);
            this.curBufReelId.Location = new System.Drawing.Point(4, 36);
            this.curBufReelId.Name = "curBufReelId";
            this.curBufReelId.Padding = new System.Windows.Forms.Padding(2);
            this.curBufReelId.PasswordChar = '\0';
            this.curBufReelId.Required = false;
            this.curBufReelId.Size = new System.Drawing.Size(232, 37);
            this.curBufReelId.TabIndex = 0;
            // 
            // plNGDisplay
            // 
            this.plNGDisplay.AssociatedSplitter = null;
            this.plNGDisplay.BackColor = System.Drawing.Color.Transparent;
            this.plNGDisplay.CaptionFont = new System.Drawing.Font("宋体", 9.5F);
            this.plNGDisplay.CaptionHeight = 22;
            this.plNGDisplay.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plNGDisplay.Controls.Add(this.panelCurrentNGInfo);
            this.plNGDisplay.Controls.Add(this.txt_NGDisplay);
            this.plNGDisplay.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plNGDisplay.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plNGDisplay.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plNGDisplay.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plNGDisplay.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plNGDisplay.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plNGDisplay.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plNGDisplay.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plNGDisplay.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plNGDisplay.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plNGDisplay.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plNGDisplay.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plNGDisplay.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plNGDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plNGDisplay.Image = null;
            this.plNGDisplay.Location = new System.Drawing.Point(6, 169);
            this.plNGDisplay.MinimumSize = new System.Drawing.Size(22, 22);
            this.plNGDisplay.Name = "plNGDisplay";
            this.plNGDisplay.Size = new System.Drawing.Size(1242, 124);
            this.plNGDisplay.TabIndex = 4;
            this.plNGDisplay.Text = "当前NG";
            this.plNGDisplay.ToolTipTextCloseIcon = null;
            this.plNGDisplay.ToolTipTextExpandIconPanelCollapsed = null;
            this.plNGDisplay.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // panelCurrentNGInfo
            // 
            this.panelCurrentNGInfo.AssociatedSplitter = null;
            this.panelCurrentNGInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelCurrentNGInfo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panelCurrentNGInfo.CaptionHeight = 32;
            this.panelCurrentNGInfo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panelCurrentNGInfo.Controls.Add(this.txtCurrentNGInfo);
            this.panelCurrentNGInfo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panelCurrentNGInfo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panelCurrentNGInfo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelCurrentNGInfo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelCurrentNGInfo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelCurrentNGInfo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panelCurrentNGInfo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panelCurrentNGInfo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panelCurrentNGInfo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelCurrentNGInfo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelCurrentNGInfo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelCurrentNGInfo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelCurrentNGInfo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panelCurrentNGInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelCurrentNGInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelCurrentNGInfo.Image = null;
            this.panelCurrentNGInfo.Location = new System.Drawing.Point(1002, 36);
            this.panelCurrentNGInfo.MinimumSize = new System.Drawing.Size(32, 32);
            this.panelCurrentNGInfo.Name = "panelCurrentNGInfo";
            this.panelCurrentNGInfo.Size = new System.Drawing.Size(240, 77);
            this.panelCurrentNGInfo.TabIndex = 7;
            this.panelCurrentNGInfo.Text = "当前NG箱信息";
            this.panelCurrentNGInfo.ToolTipTextCloseIcon = null;
            this.panelCurrentNGInfo.ToolTipTextExpandIconPanelCollapsed = null;
            this.panelCurrentNGInfo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtCurrentNGInfo
            // 
            this.txtCurrentNGInfo.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentNGInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtCurrentNGInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrentNGInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCurrentNGInfo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtCurrentNGInfo.Image = null;
            this.txtCurrentNGInfo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtCurrentNGInfo.Location = new System.Drawing.Point(4, 36);
            this.txtCurrentNGInfo.Name = "txtCurrentNGInfo";
            this.txtCurrentNGInfo.Padding = new System.Windows.Forms.Padding(2);
            this.txtCurrentNGInfo.PasswordChar = '\0';
            this.txtCurrentNGInfo.Required = false;
            this.txtCurrentNGInfo.Size = new System.Drawing.Size(232, 37);
            this.txtCurrentNGInfo.TabIndex = 0;
            // 
            // txt_NGDisplay
            // 
            this.txt_NGDisplay.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NGDisplay.ForeColor = System.Drawing.Color.OrangeRed;
            this.txt_NGDisplay.Location = new System.Drawing.Point(37, 33);
            this.txt_NGDisplay.Name = "txt_NGDisplay";
            this.txt_NGDisplay.Size = new System.Drawing.Size(955, 80);
            this.txt_NGDisplay.TabIndex = 0;
            this.txt_NGDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbPLCInfo
            // 
            this.gbPLCInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbPLCInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.gbPLCInfo.CaptionColor = System.Drawing.Color.Black;
            this.gbPLCInfo.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.gbPLCInfo.Controls.Add(this.plScan2);
            this.gbPLCInfo.Controls.Add(this.plScan1);
            this.gbPLCInfo.Controls.Add(this.plCamera);
            this.gbPLCInfo.Controls.Add(this.plUrgentStop);
            this.gbPLCInfo.Controls.Add(this.plAutoModel);
            this.gbPLCInfo.Controls.Add(this.plUpInitialInfo);
            this.gbPLCInfo.Controls.Add(this.plStreamInitialing);
            this.gbPLCInfo.Controls.Add(this.plUpInitialing);
            this.gbPLCInfo.Controls.Add(this.plSteamAutoing);
            this.gbPLCInfo.Controls.Add(this.plUpAutoing);
            this.gbPLCInfo.Controls.Add(this.plStreamInitialOK);
            this.gbPLCInfo.Controls.Add(this.plUpInitialOK);
            this.gbPLCInfo.Controls.Add(this.plAutoModeling);
            this.gbPLCInfo.Controls.Add(this.plRaiseError);
            this.gbPLCInfo.Location = new System.Drawing.Point(6, 531);
            this.gbPLCInfo.Name = "gbPLCInfo";
            this.gbPLCInfo.Size = new System.Drawing.Size(1248, 335);
            this.gbPLCInfo.TabIndex = 3;
            this.gbPLCInfo.TabStop = false;
            this.gbPLCInfo.Text = "当前硬件传感信号";
            this.gbPLCInfo.TextMargin = 6;
            // 
            // plScan2
            // 
            this.plScan2.AssociatedSplitter = null;
            this.plScan2.BackColor = System.Drawing.Color.Transparent;
            this.plScan2.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plScan2.CaptionHeight = 32;
            this.plScan2.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plScan2.Controls.Add(this.pbScan2);
            this.plScan2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plScan2.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plScan2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plScan2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plScan2.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plScan2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plScan2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plScan2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plScan2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plScan2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plScan2.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plScan2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plScan2.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plScan2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plScan2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plScan2.Image = null;
            this.plScan2.Location = new System.Drawing.Point(352, 205);
            this.plScan2.MinimumSize = new System.Drawing.Size(32, 32);
            this.plScan2.Name = "plScan2";
            this.plScan2.Size = new System.Drawing.Size(167, 77);
            this.plScan2.TabIndex = 15;
            this.plScan2.Text = "扫码器2";
            this.plScan2.ToolTipTextCloseIcon = null;
            this.plScan2.ToolTipTextExpandIconPanelCollapsed = null;
            this.plScan2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbScan2
            // 
            this.pbScan2.BackColor = System.Drawing.Color.Gray;
            this.pbScan2.Location = new System.Drawing.Point(0, 36);
            this.pbScan2.Name = "pbScan2";
            this.pbScan2.Size = new System.Drawing.Size(163, 38);
            this.pbScan2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbScan2.TabIndex = 3;
            this.pbScan2.TabStop = false;
            // 
            // plScan1
            // 
            this.plScan1.AssociatedSplitter = null;
            this.plScan1.BackColor = System.Drawing.Color.Transparent;
            this.plScan1.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plScan1.CaptionHeight = 32;
            this.plScan1.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plScan1.Controls.Add(this.pbScan1);
            this.plScan1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plScan1.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plScan1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plScan1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plScan1.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plScan1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plScan1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plScan1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plScan1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plScan1.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plScan1.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plScan1.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plScan1.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plScan1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plScan1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plScan1.Image = null;
            this.plScan1.Location = new System.Drawing.Point(183, 205);
            this.plScan1.MinimumSize = new System.Drawing.Size(32, 32);
            this.plScan1.Name = "plScan1";
            this.plScan1.Size = new System.Drawing.Size(167, 77);
            this.plScan1.TabIndex = 13;
            this.plScan1.Text = "扫码器1";
            this.plScan1.ToolTipTextCloseIcon = null;
            this.plScan1.ToolTipTextExpandIconPanelCollapsed = null;
            this.plScan1.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbScan1
            // 
            this.pbScan1.BackColor = System.Drawing.Color.Gray;
            this.pbScan1.Location = new System.Drawing.Point(0, 36);
            this.pbScan1.Name = "pbScan1";
            this.pbScan1.Size = new System.Drawing.Size(163, 38);
            this.pbScan1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbScan1.TabIndex = 3;
            this.pbScan1.TabStop = false;
            // 
            // plCamera
            // 
            this.plCamera.AssociatedSplitter = null;
            this.plCamera.BackColor = System.Drawing.Color.Transparent;
            this.plCamera.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plCamera.CaptionHeight = 32;
            this.plCamera.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plCamera.Controls.Add(this.pbCamera);
            this.plCamera.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plCamera.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plCamera.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plCamera.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plCamera.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plCamera.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plCamera.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plCamera.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plCamera.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plCamera.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plCamera.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plCamera.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plCamera.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plCamera.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plCamera.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plCamera.Image = null;
            this.plCamera.Location = new System.Drawing.Point(14, 205);
            this.plCamera.MinimumSize = new System.Drawing.Size(32, 32);
            this.plCamera.Name = "plCamera";
            this.plCamera.Size = new System.Drawing.Size(167, 77);
            this.plCamera.TabIndex = 14;
            this.plCamera.Text = "相机工作";
            this.plCamera.ToolTipTextCloseIcon = null;
            this.plCamera.ToolTipTextExpandIconPanelCollapsed = null;
            this.plCamera.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbCamera
            // 
            this.pbCamera.BackColor = System.Drawing.Color.Gray;
            this.pbCamera.Location = new System.Drawing.Point(0, 36);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(163, 38);
            this.pbCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCamera.TabIndex = 3;
            this.pbCamera.TabStop = false;
            // 
            // plUrgentStop
            // 
            this.plUrgentStop.AssociatedSplitter = null;
            this.plUrgentStop.BackColor = System.Drawing.Color.Transparent;
            this.plUrgentStop.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plUrgentStop.CaptionHeight = 32;
            this.plUrgentStop.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plUrgentStop.Controls.Add(this.pbUrgentStop);
            this.plUrgentStop.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plUrgentStop.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plUrgentStop.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plUrgentStop.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUrgentStop.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUrgentStop.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plUrgentStop.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUrgentStop.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUrgentStop.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plUrgentStop.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plUrgentStop.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUrgentStop.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUrgentStop.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plUrgentStop.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plUrgentStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plUrgentStop.Image = null;
            this.plUrgentStop.Location = new System.Drawing.Point(352, 113);
            this.plUrgentStop.MinimumSize = new System.Drawing.Size(32, 32);
            this.plUrgentStop.Name = "plUrgentStop";
            this.plUrgentStop.Size = new System.Drawing.Size(167, 77);
            this.plUrgentStop.TabIndex = 13;
            this.plUrgentStop.Text = "急停";
            this.plUrgentStop.ToolTipTextCloseIcon = null;
            this.plUrgentStop.ToolTipTextExpandIconPanelCollapsed = null;
            this.plUrgentStop.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbUrgentStop
            // 
            this.pbUrgentStop.BackColor = System.Drawing.Color.Gray;
            this.pbUrgentStop.Location = new System.Drawing.Point(0, 36);
            this.pbUrgentStop.Name = "pbUrgentStop";
            this.pbUrgentStop.Size = new System.Drawing.Size(163, 38);
            this.pbUrgentStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUrgentStop.TabIndex = 3;
            this.pbUrgentStop.TabStop = false;
            // 
            // plAutoModel
            // 
            this.plAutoModel.AssociatedSplitter = null;
            this.plAutoModel.BackColor = System.Drawing.Color.Transparent;
            this.plAutoModel.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAutoModel.CaptionHeight = 32;
            this.plAutoModel.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAutoModel.Controls.Add(this.pbAutoModel);
            this.plAutoModel.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAutoModel.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAutoModel.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAutoModel.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAutoModel.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAutoModel.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAutoModel.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAutoModel.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAutoModel.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAutoModel.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAutoModel.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAutoModel.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAutoModel.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAutoModel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAutoModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAutoModel.Image = null;
            this.plAutoModel.Location = new System.Drawing.Point(521, 113);
            this.plAutoModel.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAutoModel.Name = "plAutoModel";
            this.plAutoModel.Size = new System.Drawing.Size(167, 77);
            this.plAutoModel.TabIndex = 12;
            this.plAutoModel.Text = "自动模式";
            this.plAutoModel.ToolTipTextCloseIcon = null;
            this.plAutoModel.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAutoModel.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbAutoModel
            // 
            this.pbAutoModel.BackColor = System.Drawing.Color.Gray;
            this.pbAutoModel.Location = new System.Drawing.Point(0, 36);
            this.pbAutoModel.Name = "pbAutoModel";
            this.pbAutoModel.Size = new System.Drawing.Size(163, 38);
            this.pbAutoModel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAutoModel.TabIndex = 3;
            this.pbAutoModel.TabStop = false;
            // 
            // plUpInitialInfo
            // 
            this.plUpInitialInfo.AssociatedSplitter = null;
            this.plUpInitialInfo.BackColor = System.Drawing.Color.Transparent;
            this.plUpInitialInfo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plUpInitialInfo.CaptionHeight = 32;
            this.plUpInitialInfo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plUpInitialInfo.Controls.Add(this.pbUpInitialInfo);
            this.plUpInitialInfo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plUpInitialInfo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plUpInitialInfo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plUpInitialInfo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpInitialInfo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpInitialInfo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plUpInitialInfo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpInitialInfo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpInitialInfo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpInitialInfo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpInitialInfo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpInitialInfo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpInitialInfo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plUpInitialInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plUpInitialInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plUpInitialInfo.Image = null;
            this.plUpInitialInfo.Location = new System.Drawing.Point(14, 113);
            this.plUpInitialInfo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plUpInitialInfo.Name = "plUpInitialInfo";
            this.plUpInitialInfo.Size = new System.Drawing.Size(167, 77);
            this.plUpInitialInfo.TabIndex = 11;
            this.plUpInitialInfo.Text = "码垛机初始化信号";
            this.plUpInitialInfo.ToolTipTextCloseIcon = null;
            this.plUpInitialInfo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plUpInitialInfo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbUpInitialInfo
            // 
            this.pbUpInitialInfo.BackColor = System.Drawing.Color.Gray;
            this.pbUpInitialInfo.Location = new System.Drawing.Point(0, 36);
            this.pbUpInitialInfo.Name = "pbUpInitialInfo";
            this.pbUpInitialInfo.Size = new System.Drawing.Size(163, 38);
            this.pbUpInitialInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpInitialInfo.TabIndex = 3;
            this.pbUpInitialInfo.TabStop = false;
            // 
            // plStreamInitialing
            // 
            this.plStreamInitialing.AssociatedSplitter = null;
            this.plStreamInitialing.BackColor = System.Drawing.Color.Transparent;
            this.plStreamInitialing.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plStreamInitialing.CaptionHeight = 32;
            this.plStreamInitialing.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plStreamInitialing.Controls.Add(this.pbStreamInitialing);
            this.plStreamInitialing.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plStreamInitialing.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plStreamInitialing.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialing.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plStreamInitialing.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plStreamInitialing.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plStreamInitialing.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plStreamInitialing.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plStreamInitialing.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialing.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialing.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plStreamInitialing.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plStreamInitialing.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plStreamInitialing.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plStreamInitialing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialing.Image = null;
            this.plStreamInitialing.Location = new System.Drawing.Point(183, 20);
            this.plStreamInitialing.MinimumSize = new System.Drawing.Size(32, 32);
            this.plStreamInitialing.Name = "plStreamInitialing";
            this.plStreamInitialing.Size = new System.Drawing.Size(167, 77);
            this.plStreamInitialing.TabIndex = 10;
            this.plStreamInitialing.Text = "汇流皮带初始化中";
            this.plStreamInitialing.ToolTipTextCloseIcon = null;
            this.plStreamInitialing.ToolTipTextExpandIconPanelCollapsed = null;
            this.plStreamInitialing.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbStreamInitialing
            // 
            this.pbStreamInitialing.BackColor = System.Drawing.Color.Gray;
            this.pbStreamInitialing.Location = new System.Drawing.Point(0, 36);
            this.pbStreamInitialing.Name = "pbStreamInitialing";
            this.pbStreamInitialing.Size = new System.Drawing.Size(163, 38);
            this.pbStreamInitialing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStreamInitialing.TabIndex = 3;
            this.pbStreamInitialing.TabStop = false;
            // 
            // plUpInitialing
            // 
            this.plUpInitialing.AssociatedSplitter = null;
            this.plUpInitialing.BackColor = System.Drawing.Color.Transparent;
            this.plUpInitialing.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plUpInitialing.CaptionHeight = 32;
            this.plUpInitialing.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plUpInitialing.Controls.Add(this.pbUpInitialing);
            this.plUpInitialing.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plUpInitialing.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plUpInitialing.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plUpInitialing.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpInitialing.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpInitialing.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plUpInitialing.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpInitialing.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpInitialing.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpInitialing.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpInitialing.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpInitialing.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpInitialing.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plUpInitialing.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plUpInitialing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plUpInitialing.Image = null;
            this.plUpInitialing.Location = new System.Drawing.Point(14, 20);
            this.plUpInitialing.MinimumSize = new System.Drawing.Size(32, 32);
            this.plUpInitialing.Name = "plUpInitialing";
            this.plUpInitialing.Size = new System.Drawing.Size(167, 77);
            this.plUpInitialing.TabIndex = 9;
            this.plUpInitialing.Text = "码垛机初始化中";
            this.plUpInitialing.ToolTipTextCloseIcon = null;
            this.plUpInitialing.ToolTipTextExpandIconPanelCollapsed = null;
            this.plUpInitialing.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbUpInitialing
            // 
            this.pbUpInitialing.BackColor = System.Drawing.Color.Gray;
            this.pbUpInitialing.Location = new System.Drawing.Point(0, 36);
            this.pbUpInitialing.Name = "pbUpInitialing";
            this.pbUpInitialing.Size = new System.Drawing.Size(163, 38);
            this.pbUpInitialing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpInitialing.TabIndex = 3;
            this.pbUpInitialing.TabStop = false;
            // 
            // plSteamAutoing
            // 
            this.plSteamAutoing.AssociatedSplitter = null;
            this.plSteamAutoing.BackColor = System.Drawing.Color.Transparent;
            this.plSteamAutoing.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plSteamAutoing.CaptionHeight = 32;
            this.plSteamAutoing.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plSteamAutoing.Controls.Add(this.pbSteamAutoing);
            this.plSteamAutoing.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plSteamAutoing.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plSteamAutoing.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plSteamAutoing.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plSteamAutoing.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plSteamAutoing.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plSteamAutoing.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plSteamAutoing.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plSteamAutoing.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plSteamAutoing.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plSteamAutoing.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plSteamAutoing.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plSteamAutoing.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plSteamAutoing.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plSteamAutoing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plSteamAutoing.Image = null;
            this.plSteamAutoing.Location = new System.Drawing.Point(859, 20);
            this.plSteamAutoing.MinimumSize = new System.Drawing.Size(32, 32);
            this.plSteamAutoing.Name = "plSteamAutoing";
            this.plSteamAutoing.Size = new System.Drawing.Size(167, 77);
            this.plSteamAutoing.TabIndex = 8;
            this.plSteamAutoing.Text = "汇流皮带自动中";
            this.plSteamAutoing.ToolTipTextCloseIcon = null;
            this.plSteamAutoing.ToolTipTextExpandIconPanelCollapsed = null;
            this.plSteamAutoing.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbSteamAutoing
            // 
            this.pbSteamAutoing.BackColor = System.Drawing.Color.Gray;
            this.pbSteamAutoing.Location = new System.Drawing.Point(0, 36);
            this.pbSteamAutoing.Name = "pbSteamAutoing";
            this.pbSteamAutoing.Size = new System.Drawing.Size(163, 38);
            this.pbSteamAutoing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSteamAutoing.TabIndex = 3;
            this.pbSteamAutoing.TabStop = false;
            // 
            // plUpAutoing
            // 
            this.plUpAutoing.AssociatedSplitter = null;
            this.plUpAutoing.BackColor = System.Drawing.Color.Transparent;
            this.plUpAutoing.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plUpAutoing.CaptionHeight = 32;
            this.plUpAutoing.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plUpAutoing.Controls.Add(this.pbUpAutoing);
            this.plUpAutoing.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plUpAutoing.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plUpAutoing.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plUpAutoing.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpAutoing.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpAutoing.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plUpAutoing.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpAutoing.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpAutoing.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpAutoing.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpAutoing.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpAutoing.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpAutoing.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plUpAutoing.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plUpAutoing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plUpAutoing.Image = null;
            this.plUpAutoing.Location = new System.Drawing.Point(690, 20);
            this.plUpAutoing.MinimumSize = new System.Drawing.Size(32, 32);
            this.plUpAutoing.Name = "plUpAutoing";
            this.plUpAutoing.Size = new System.Drawing.Size(167, 77);
            this.plUpAutoing.TabIndex = 7;
            this.plUpAutoing.Text = "码垛机自动中";
            this.plUpAutoing.ToolTipTextCloseIcon = null;
            this.plUpAutoing.ToolTipTextExpandIconPanelCollapsed = null;
            this.plUpAutoing.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbUpAutoing
            // 
            this.pbUpAutoing.BackColor = System.Drawing.Color.Gray;
            this.pbUpAutoing.Location = new System.Drawing.Point(0, 36);
            this.pbUpAutoing.Name = "pbUpAutoing";
            this.pbUpAutoing.Size = new System.Drawing.Size(163, 38);
            this.pbUpAutoing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpAutoing.TabIndex = 3;
            this.pbUpAutoing.TabStop = false;
            // 
            // plStreamInitialOK
            // 
            this.plStreamInitialOK.AssociatedSplitter = null;
            this.plStreamInitialOK.BackColor = System.Drawing.Color.Transparent;
            this.plStreamInitialOK.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plStreamInitialOK.CaptionHeight = 32;
            this.plStreamInitialOK.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plStreamInitialOK.Controls.Add(this.pbStreamInitialOK);
            this.plStreamInitialOK.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plStreamInitialOK.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plStreamInitialOK.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialOK.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plStreamInitialOK.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plStreamInitialOK.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plStreamInitialOK.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plStreamInitialOK.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plStreamInitialOK.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialOK.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialOK.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plStreamInitialOK.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plStreamInitialOK.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plStreamInitialOK.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plStreamInitialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plStreamInitialOK.Image = null;
            this.plStreamInitialOK.Location = new System.Drawing.Point(521, 20);
            this.plStreamInitialOK.MinimumSize = new System.Drawing.Size(32, 32);
            this.plStreamInitialOK.Name = "plStreamInitialOK";
            this.plStreamInitialOK.Size = new System.Drawing.Size(167, 77);
            this.plStreamInitialOK.TabIndex = 7;
            this.plStreamInitialOK.Text = "汇流皮带初始化OK";
            this.plStreamInitialOK.ToolTipTextCloseIcon = null;
            this.plStreamInitialOK.ToolTipTextExpandIconPanelCollapsed = null;
            this.plStreamInitialOK.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbStreamInitialOK
            // 
            this.pbStreamInitialOK.BackColor = System.Drawing.Color.Gray;
            this.pbStreamInitialOK.Location = new System.Drawing.Point(0, 36);
            this.pbStreamInitialOK.Name = "pbStreamInitialOK";
            this.pbStreamInitialOK.Size = new System.Drawing.Size(163, 38);
            this.pbStreamInitialOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStreamInitialOK.TabIndex = 3;
            this.pbStreamInitialOK.TabStop = false;
            // 
            // plUpInitialOK
            // 
            this.plUpInitialOK.AssociatedSplitter = null;
            this.plUpInitialOK.BackColor = System.Drawing.Color.Transparent;
            this.plUpInitialOK.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plUpInitialOK.CaptionHeight = 32;
            this.plUpInitialOK.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plUpInitialOK.Controls.Add(this.pbUpInitialOK);
            this.plUpInitialOK.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plUpInitialOK.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plUpInitialOK.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plUpInitialOK.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpInitialOK.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plUpInitialOK.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plUpInitialOK.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpInitialOK.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plUpInitialOK.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpInitialOK.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plUpInitialOK.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpInitialOK.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plUpInitialOK.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plUpInitialOK.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plUpInitialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plUpInitialOK.Image = null;
            this.plUpInitialOK.Location = new System.Drawing.Point(352, 20);
            this.plUpInitialOK.MinimumSize = new System.Drawing.Size(32, 32);
            this.plUpInitialOK.Name = "plUpInitialOK";
            this.plUpInitialOK.Size = new System.Drawing.Size(167, 77);
            this.plUpInitialOK.TabIndex = 6;
            this.plUpInitialOK.Text = "码垛机初始化OK";
            this.plUpInitialOK.ToolTipTextCloseIcon = null;
            this.plUpInitialOK.ToolTipTextExpandIconPanelCollapsed = null;
            this.plUpInitialOK.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbUpInitialOK
            // 
            this.pbUpInitialOK.BackColor = System.Drawing.Color.Gray;
            this.pbUpInitialOK.Location = new System.Drawing.Point(0, 36);
            this.pbUpInitialOK.Name = "pbUpInitialOK";
            this.pbUpInitialOK.Size = new System.Drawing.Size(163, 38);
            this.pbUpInitialOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpInitialOK.TabIndex = 3;
            this.pbUpInitialOK.TabStop = false;
            // 
            // plAutoModeling
            // 
            this.plAutoModeling.AssociatedSplitter = null;
            this.plAutoModeling.BackColor = System.Drawing.Color.Transparent;
            this.plAutoModeling.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAutoModeling.CaptionHeight = 32;
            this.plAutoModeling.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAutoModeling.Controls.Add(this.pbAutoModeling);
            this.plAutoModeling.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAutoModeling.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAutoModeling.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAutoModeling.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAutoModeling.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAutoModeling.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAutoModeling.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAutoModeling.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAutoModeling.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAutoModeling.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAutoModeling.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAutoModeling.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAutoModeling.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAutoModeling.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAutoModeling.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAutoModeling.Image = null;
            this.plAutoModeling.Location = new System.Drawing.Point(690, 113);
            this.plAutoModeling.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAutoModeling.Name = "plAutoModeling";
            this.plAutoModeling.Size = new System.Drawing.Size(167, 77);
            this.plAutoModeling.TabIndex = 5;
            this.plAutoModeling.Text = "自动模式运行中";
            this.plAutoModeling.ToolTipTextCloseIcon = null;
            this.plAutoModeling.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAutoModeling.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbAutoModeling
            // 
            this.pbAutoModeling.BackColor = System.Drawing.Color.Gray;
            this.pbAutoModeling.Location = new System.Drawing.Point(0, 36);
            this.pbAutoModeling.Name = "pbAutoModeling";
            this.pbAutoModeling.Size = new System.Drawing.Size(163, 38);
            this.pbAutoModeling.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAutoModeling.TabIndex = 3;
            this.pbAutoModeling.TabStop = false;
            // 
            // plRaiseError
            // 
            this.plRaiseError.AssociatedSplitter = null;
            this.plRaiseError.BackColor = System.Drawing.Color.Transparent;
            this.plRaiseError.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plRaiseError.CaptionHeight = 32;
            this.plRaiseError.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plRaiseError.Controls.Add(this.pbRaiseError);
            this.plRaiseError.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plRaiseError.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plRaiseError.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plRaiseError.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plRaiseError.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plRaiseError.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plRaiseError.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plRaiseError.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plRaiseError.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plRaiseError.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plRaiseError.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plRaiseError.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plRaiseError.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plRaiseError.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plRaiseError.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plRaiseError.Image = null;
            this.plRaiseError.Location = new System.Drawing.Point(183, 113);
            this.plRaiseError.MinimumSize = new System.Drawing.Size(32, 32);
            this.plRaiseError.Name = "plRaiseError";
            this.plRaiseError.Size = new System.Drawing.Size(167, 77);
            this.plRaiseError.TabIndex = 4;
            this.plRaiseError.Text = "码垛机报警";
            this.plRaiseError.ToolTipTextCloseIcon = null;
            this.plRaiseError.ToolTipTextExpandIconPanelCollapsed = null;
            this.plRaiseError.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbRaiseError
            // 
            this.pbRaiseError.BackColor = System.Drawing.Color.Gray;
            this.pbRaiseError.Location = new System.Drawing.Point(0, 36);
            this.pbRaiseError.Name = "pbRaiseError";
            this.pbRaiseError.Size = new System.Drawing.Size(163, 38);
            this.pbRaiseError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRaiseError.TabIndex = 3;
            this.pbRaiseError.TabStop = false;
            // 
            // gbBoxInfo
            // 
            this.gbBoxInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbBoxInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.gbBoxInfo.CaptionColor = System.Drawing.Color.Black;
            this.gbBoxInfo.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.gbBoxInfo.Controls.Add(this.panelCurrentBoxInfo);
            this.gbBoxInfo.Controls.Add(this.panel49);
            this.gbBoxInfo.Controls.Add(this.panel48);
            this.gbBoxInfo.Controls.Add(this.panel45);
            this.gbBoxInfo.Controls.Add(this.plBoxCheckResult);
            this.gbBoxInfo.Location = new System.Drawing.Point(6, 418);
            this.gbBoxInfo.Name = "gbBoxInfo";
            this.gbBoxInfo.Size = new System.Drawing.Size(1248, 107);
            this.gbBoxInfo.TabIndex = 2;
            this.gbBoxInfo.TabStop = false;
            this.gbBoxInfo.Text = "当前箱信息";
            this.gbBoxInfo.TextMargin = 6;
            // 
            // panelCurrentBoxInfo
            // 
            this.panelCurrentBoxInfo.AssociatedSplitter = null;
            this.panelCurrentBoxInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelCurrentBoxInfo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panelCurrentBoxInfo.CaptionHeight = 32;
            this.panelCurrentBoxInfo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panelCurrentBoxInfo.Controls.Add(this.txtCurrentBoxInfo);
            this.panelCurrentBoxInfo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panelCurrentBoxInfo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panelCurrentBoxInfo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelCurrentBoxInfo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelCurrentBoxInfo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelCurrentBoxInfo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panelCurrentBoxInfo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panelCurrentBoxInfo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panelCurrentBoxInfo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelCurrentBoxInfo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelCurrentBoxInfo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelCurrentBoxInfo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panelCurrentBoxInfo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panelCurrentBoxInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelCurrentBoxInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelCurrentBoxInfo.Image = null;
            this.panelCurrentBoxInfo.Location = new System.Drawing.Point(1002, 20);
            this.panelCurrentBoxInfo.MinimumSize = new System.Drawing.Size(32, 32);
            this.panelCurrentBoxInfo.Name = "panelCurrentBoxInfo";
            this.panelCurrentBoxInfo.Size = new System.Drawing.Size(240, 77);
            this.panelCurrentBoxInfo.TabIndex = 7;
            this.panelCurrentBoxInfo.Text = "当前料箱操作信息";
            this.panelCurrentBoxInfo.ToolTipTextCloseIcon = null;
            this.panelCurrentBoxInfo.ToolTipTextExpandIconPanelCollapsed = null;
            this.panelCurrentBoxInfo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtCurrentBoxInfo
            // 
            this.txtCurrentBoxInfo.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentBoxInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtCurrentBoxInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrentBoxInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCurrentBoxInfo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtCurrentBoxInfo.Image = null;
            this.txtCurrentBoxInfo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtCurrentBoxInfo.Location = new System.Drawing.Point(4, 36);
            this.txtCurrentBoxInfo.Name = "txtCurrentBoxInfo";
            this.txtCurrentBoxInfo.Padding = new System.Windows.Forms.Padding(2);
            this.txtCurrentBoxInfo.PasswordChar = '\0';
            this.txtCurrentBoxInfo.Required = false;
            this.txtCurrentBoxInfo.Size = new System.Drawing.Size(232, 37);
            this.txtCurrentBoxInfo.TabIndex = 0;
            // 
            // panel49
            // 
            this.panel49.AssociatedSplitter = null;
            this.panel49.BackColor = System.Drawing.Color.Transparent;
            this.panel49.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panel49.CaptionHeight = 32;
            this.panel49.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panel49.Controls.Add(this.curBufBoxNoBindOutorderNo);
            this.panel49.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panel49.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panel49.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel49.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel49.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel49.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel49.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel49.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel49.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel49.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel49.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel49.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel49.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panel49.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel49.Image = null;
            this.panel49.Location = new System.Drawing.Point(679, 20);
            this.panel49.MinimumSize = new System.Drawing.Size(32, 32);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(240, 77);
            this.panel49.TabIndex = 5;
            this.panel49.Text = "绑定工单";
            this.panel49.ToolTipTextCloseIcon = null;
            this.panel49.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel49.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // curBufBoxNoBindOutorderNo
            // 
            this.curBufBoxNoBindOutorderNo.BackColor = System.Drawing.Color.Transparent;
            this.curBufBoxNoBindOutorderNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.curBufBoxNoBindOutorderNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curBufBoxNoBindOutorderNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.curBufBoxNoBindOutorderNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.curBufBoxNoBindOutorderNo.Image = null;
            this.curBufBoxNoBindOutorderNo.ImageSize = new System.Drawing.Size(0, 0);
            this.curBufBoxNoBindOutorderNo.Location = new System.Drawing.Point(4, 36);
            this.curBufBoxNoBindOutorderNo.Name = "curBufBoxNoBindOutorderNo";
            this.curBufBoxNoBindOutorderNo.Padding = new System.Windows.Forms.Padding(2);
            this.curBufBoxNoBindOutorderNo.PasswordChar = '\0';
            this.curBufBoxNoBindOutorderNo.Required = false;
            this.curBufBoxNoBindOutorderNo.Size = new System.Drawing.Size(232, 37);
            this.curBufBoxNoBindOutorderNo.TabIndex = 0;
            // 
            // panel48
            // 
            this.panel48.AssociatedSplitter = null;
            this.panel48.BackColor = System.Drawing.Color.Transparent;
            this.panel48.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panel48.CaptionHeight = 32;
            this.panel48.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panel48.Controls.Add(this.curBufIsEmpty);
            this.panel48.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panel48.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panel48.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel48.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel48.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel48.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel48.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel48.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel48.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel48.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel48.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel48.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel48.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panel48.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel48.Image = null;
            this.panel48.Location = new System.Drawing.Point(433, 20);
            this.panel48.MinimumSize = new System.Drawing.Size(32, 32);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(240, 77);
            this.panel48.TabIndex = 4;
            this.panel48.Text = "是否空箱";
            this.panel48.ToolTipTextCloseIcon = null;
            this.panel48.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel48.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // curBufIsEmpty
            // 
            this.curBufIsEmpty.BackColor = System.Drawing.Color.Transparent;
            this.curBufIsEmpty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.curBufIsEmpty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curBufIsEmpty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.curBufIsEmpty.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.curBufIsEmpty.Image = null;
            this.curBufIsEmpty.ImageSize = new System.Drawing.Size(0, 0);
            this.curBufIsEmpty.Location = new System.Drawing.Point(4, 36);
            this.curBufIsEmpty.Name = "curBufIsEmpty";
            this.curBufIsEmpty.Padding = new System.Windows.Forms.Padding(2);
            this.curBufIsEmpty.PasswordChar = '\0';
            this.curBufIsEmpty.Required = false;
            this.curBufIsEmpty.Size = new System.Drawing.Size(232, 37);
            this.curBufIsEmpty.TabIndex = 0;
            // 
            // panel45
            // 
            this.panel45.AssociatedSplitter = null;
            this.panel45.BackColor = System.Drawing.Color.Transparent;
            this.panel45.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.panel45.CaptionHeight = 32;
            this.panel45.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.panel45.Controls.Add(this.curBufBoxNo);
            this.panel45.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.panel45.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.panel45.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel45.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel45.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel45.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel45.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel45.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.panel45.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel45.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel45.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel45.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel45.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.panel45.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel45.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel45.Image = null;
            this.panel45.Location = new System.Drawing.Point(187, 20);
            this.panel45.MinimumSize = new System.Drawing.Size(32, 32);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(240, 77);
            this.panel45.TabIndex = 1;
            this.panel45.Text = "当前箱号";
            this.panel45.ToolTipTextCloseIcon = null;
            this.panel45.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel45.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // curBufBoxNo
            // 
            this.curBufBoxNo.BackColor = System.Drawing.Color.Transparent;
            this.curBufBoxNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.curBufBoxNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curBufBoxNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.curBufBoxNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.curBufBoxNo.Image = null;
            this.curBufBoxNo.ImageSize = new System.Drawing.Size(0, 0);
            this.curBufBoxNo.Location = new System.Drawing.Point(4, 36);
            this.curBufBoxNo.Name = "curBufBoxNo";
            this.curBufBoxNo.Padding = new System.Windows.Forms.Padding(2);
            this.curBufBoxNo.PasswordChar = '\0';
            this.curBufBoxNo.Required = false;
            this.curBufBoxNo.Size = new System.Drawing.Size(232, 37);
            this.curBufBoxNo.TabIndex = 0;
            // 
            // plBoxCheckResult
            // 
            this.plBoxCheckResult.AssociatedSplitter = null;
            this.plBoxCheckResult.BackColor = System.Drawing.Color.Transparent;
            this.plBoxCheckResult.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plBoxCheckResult.CaptionHeight = 32;
            this.plBoxCheckResult.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plBoxCheckResult.Controls.Add(this.pbBoxCheckResult);
            this.plBoxCheckResult.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plBoxCheckResult.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plBoxCheckResult.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plBoxCheckResult.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plBoxCheckResult.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plBoxCheckResult.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plBoxCheckResult.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plBoxCheckResult.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plBoxCheckResult.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plBoxCheckResult.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plBoxCheckResult.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plBoxCheckResult.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plBoxCheckResult.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plBoxCheckResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBoxCheckResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plBoxCheckResult.Image = null;
            this.plBoxCheckResult.Location = new System.Drawing.Point(14, 20);
            this.plBoxCheckResult.MinimumSize = new System.Drawing.Size(32, 32);
            this.plBoxCheckResult.Name = "plBoxCheckResult";
            this.plBoxCheckResult.Size = new System.Drawing.Size(167, 77);
            this.plBoxCheckResult.TabIndex = 2;
            this.plBoxCheckResult.Text = "码垛位箱子检测";
            this.plBoxCheckResult.ToolTipTextCloseIcon = null;
            this.plBoxCheckResult.ToolTipTextExpandIconPanelCollapsed = null;
            this.plBoxCheckResult.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbBoxCheckResult
            // 
            this.pbBoxCheckResult.BackColor = System.Drawing.Color.Gray;
            this.pbBoxCheckResult.Location = new System.Drawing.Point(0, 36);
            this.pbBoxCheckResult.Name = "pbBoxCheckResult";
            this.pbBoxCheckResult.Size = new System.Drawing.Size(163, 38);
            this.pbBoxCheckResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBoxCheckResult.TabIndex = 3;
            this.pbBoxCheckResult.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.plAGVOutput3);
            this.tabPage3.Controls.Add(this.plAGVInput2);
            this.tabPage3.Controls.Add(this.plAGVInput1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1260, 955);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "AGV";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // plAGVOutput3
            // 
            this.plAGVOutput3.AssociatedSplitter = null;
            this.plAGVOutput3.BackColor = System.Drawing.Color.Transparent;
            this.plAGVOutput3.CaptionFont = new System.Drawing.Font("宋体", 9.5F);
            this.plAGVOutput3.CaptionHeight = 22;
            this.plAGVOutput3.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVOutput3.Controls.Add(this.btn_RefreshAGVSide3);
            this.plAGVOutput3.Controls.Add(this.plAGVSide3CarcaseNo);
            this.plAGVOutput3.Controls.Add(this.plAGVSide3BoxNo);
            this.plAGVOutput3.Controls.Add(this.btn_CancelAGVSide3);
            this.plAGVOutput3.Controls.Add(this.plAGVSide3Method);
            this.plAGVOutput3.Controls.Add(this.plAGVSide3TaskCode);
            this.plAGVOutput3.Controls.Add(this.plAGVSide3CheckResult);
            this.plAGVOutput3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVOutput3.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVOutput3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVOutput3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVOutput3.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVOutput3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVOutput3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVOutput3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVOutput3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVOutput3.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVOutput3.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVOutput3.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVOutput3.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVOutput3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVOutput3.Image = null;
            this.plAGVOutput3.Location = new System.Drawing.Point(3, 471);
            this.plAGVOutput3.MinimumSize = new System.Drawing.Size(22, 22);
            this.plAGVOutput3.Name = "plAGVOutput3";
            this.plAGVOutput3.Size = new System.Drawing.Size(1254, 187);
            this.plAGVOutput3.TabIndex = 2;
            this.plAGVOutput3.Text = "出箱通道AGV任务";
            this.plAGVOutput3.ToolTipTextCloseIcon = null;
            this.plAGVOutput3.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVOutput3.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btn_RefreshAGVSide3
            // 
            this.btn_RefreshAGVSide3.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RefreshAGVSide3.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RefreshAGVSide3.Image = null;
            this.btn_RefreshAGVSide3.Location = new System.Drawing.Point(246, 105);
            this.btn_RefreshAGVSide3.Name = "btn_RefreshAGVSide3";
            this.btn_RefreshAGVSide3.Size = new System.Drawing.Size(240, 77);
            this.btn_RefreshAGVSide3.TabIndex = 31;
            this.btn_RefreshAGVSide3.Text = "刷新";
            this.btn_RefreshAGVSide3.UseVisualStyleBackColor = true;
            this.btn_RefreshAGVSide3.Click += new System.EventHandler(this.btn_RefreshAGVSide3_Click);
            // 
            // plAGVSide3CarcaseNo
            // 
            this.plAGVSide3CarcaseNo.AssociatedSplitter = null;
            this.plAGVSide3CarcaseNo.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide3CarcaseNo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide3CarcaseNo.CaptionHeight = 32;
            this.plAGVSide3CarcaseNo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide3CarcaseNo.Controls.Add(this.txtAGVSide3CarcaseNo);
            this.plAGVSide3CarcaseNo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide3CarcaseNo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide3CarcaseNo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CarcaseNo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3CarcaseNo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3CarcaseNo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide3CarcaseNo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3CarcaseNo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3CarcaseNo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CarcaseNo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CarcaseNo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3CarcaseNo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3CarcaseNo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide3CarcaseNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide3CarcaseNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CarcaseNo.Image = null;
            this.plAGVSide3CarcaseNo.Location = new System.Drawing.Point(972, 26);
            this.plAGVSide3CarcaseNo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide3CarcaseNo.Name = "plAGVSide3CarcaseNo";
            this.plAGVSide3CarcaseNo.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide3CarcaseNo.TabIndex = 30;
            this.plAGVSide3CarcaseNo.Text = "架号";
            this.plAGVSide3CarcaseNo.ToolTipTextCloseIcon = null;
            this.plAGVSide3CarcaseNo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide3CarcaseNo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide3CarcaseNo
            // 
            this.txtAGVSide3CarcaseNo.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide3CarcaseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide3CarcaseNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide3CarcaseNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide3CarcaseNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide3CarcaseNo.Image = null;
            this.txtAGVSide3CarcaseNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide3CarcaseNo.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide3CarcaseNo.Name = "txtAGVSide3CarcaseNo";
            this.txtAGVSide3CarcaseNo.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide3CarcaseNo.PasswordChar = '\0';
            this.txtAGVSide3CarcaseNo.Required = false;
            this.txtAGVSide3CarcaseNo.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide3CarcaseNo.TabIndex = 0;
            // 
            // plAGVSide3BoxNo
            // 
            this.plAGVSide3BoxNo.AssociatedSplitter = null;
            this.plAGVSide3BoxNo.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide3BoxNo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide3BoxNo.CaptionHeight = 32;
            this.plAGVSide3BoxNo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide3BoxNo.Controls.Add(this.txtAGVSide3BoxNo);
            this.plAGVSide3BoxNo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide3BoxNo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide3BoxNo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3BoxNo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3BoxNo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3BoxNo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide3BoxNo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3BoxNo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3BoxNo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3BoxNo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3BoxNo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3BoxNo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3BoxNo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide3BoxNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide3BoxNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3BoxNo.Image = null;
            this.plAGVSide3BoxNo.Location = new System.Drawing.Point(730, 26);
            this.plAGVSide3BoxNo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide3BoxNo.Name = "plAGVSide3BoxNo";
            this.plAGVSide3BoxNo.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide3BoxNo.TabIndex = 29;
            this.plAGVSide3BoxNo.Text = "箱号";
            this.plAGVSide3BoxNo.ToolTipTextCloseIcon = null;
            this.plAGVSide3BoxNo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide3BoxNo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide3BoxNo
            // 
            this.txtAGVSide3BoxNo.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide3BoxNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide3BoxNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide3BoxNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide3BoxNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide3BoxNo.Image = null;
            this.txtAGVSide3BoxNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide3BoxNo.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide3BoxNo.Name = "txtAGVSide3BoxNo";
            this.txtAGVSide3BoxNo.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide3BoxNo.PasswordChar = '\0';
            this.txtAGVSide3BoxNo.Required = false;
            this.txtAGVSide3BoxNo.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide3BoxNo.TabIndex = 0;
            // 
            // btn_CancelAGVSide3
            // 
            this.btn_CancelAGVSide3.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelAGVSide3.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_CancelAGVSide3.Image = null;
            this.btn_CancelAGVSide3.Location = new System.Drawing.Point(4, 106);
            this.btn_CancelAGVSide3.Name = "btn_CancelAGVSide3";
            this.btn_CancelAGVSide3.Size = new System.Drawing.Size(240, 77);
            this.btn_CancelAGVSide3.TabIndex = 26;
            this.btn_CancelAGVSide3.Text = "取消任务";
            this.btn_CancelAGVSide3.UseVisualStyleBackColor = true;
            this.btn_CancelAGVSide3.Click += new System.EventHandler(this.btn_CancelAGVSide3_Click);
            // 
            // plAGVSide3Method
            // 
            this.plAGVSide3Method.AssociatedSplitter = null;
            this.plAGVSide3Method.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide3Method.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide3Method.CaptionHeight = 32;
            this.plAGVSide3Method.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide3Method.Controls.Add(this.txtAGVSide3Method);
            this.plAGVSide3Method.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide3Method.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide3Method.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3Method.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3Method.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3Method.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide3Method.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3Method.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3Method.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3Method.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3Method.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3Method.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3Method.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide3Method.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide3Method.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3Method.Image = null;
            this.plAGVSide3Method.Location = new System.Drawing.Point(488, 26);
            this.plAGVSide3Method.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide3Method.Name = "plAGVSide3Method";
            this.plAGVSide3Method.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide3Method.TabIndex = 12;
            this.plAGVSide3Method.Text = "AGV上报状态";
            this.plAGVSide3Method.ToolTipTextCloseIcon = null;
            this.plAGVSide3Method.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide3Method.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide3Method
            // 
            this.txtAGVSide3Method.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide3Method.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide3Method.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide3Method.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide3Method.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide3Method.Image = null;
            this.txtAGVSide3Method.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide3Method.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide3Method.Name = "txtAGVSide3Method";
            this.txtAGVSide3Method.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide3Method.PasswordChar = '\0';
            this.txtAGVSide3Method.Required = false;
            this.txtAGVSide3Method.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide3Method.TabIndex = 0;
            // 
            // plAGVSide3TaskCode
            // 
            this.plAGVSide3TaskCode.AssociatedSplitter = null;
            this.plAGVSide3TaskCode.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide3TaskCode.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide3TaskCode.CaptionHeight = 32;
            this.plAGVSide3TaskCode.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide3TaskCode.Controls.Add(this.txtAGVSide3TaskCode);
            this.plAGVSide3TaskCode.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide3TaskCode.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide3TaskCode.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3TaskCode.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3TaskCode.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3TaskCode.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide3TaskCode.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3TaskCode.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3TaskCode.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3TaskCode.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3TaskCode.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3TaskCode.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3TaskCode.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide3TaskCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide3TaskCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3TaskCode.Image = null;
            this.plAGVSide3TaskCode.Location = new System.Drawing.Point(246, 26);
            this.plAGVSide3TaskCode.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide3TaskCode.Name = "plAGVSide3TaskCode";
            this.plAGVSide3TaskCode.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide3TaskCode.TabIndex = 11;
            this.plAGVSide3TaskCode.Text = "AGV任务编号";
            this.plAGVSide3TaskCode.ToolTipTextCloseIcon = null;
            this.plAGVSide3TaskCode.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide3TaskCode.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide3TaskCode
            // 
            this.txtAGVSide3TaskCode.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide3TaskCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide3TaskCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide3TaskCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide3TaskCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide3TaskCode.Image = null;
            this.txtAGVSide3TaskCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide3TaskCode.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide3TaskCode.Name = "txtAGVSide3TaskCode";
            this.txtAGVSide3TaskCode.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide3TaskCode.PasswordChar = '\0';
            this.txtAGVSide3TaskCode.Required = false;
            this.txtAGVSide3TaskCode.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide3TaskCode.TabIndex = 0;
            // 
            // plAGVSide3CheckResult
            // 
            this.plAGVSide3CheckResult.AssociatedSplitter = null;
            this.plAGVSide3CheckResult.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide3CheckResult.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide3CheckResult.CaptionHeight = 32;
            this.plAGVSide3CheckResult.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide3CheckResult.Controls.Add(this.pbAGVSide3CheckResult);
            this.plAGVSide3CheckResult.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide3CheckResult.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide3CheckResult.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CheckResult.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3CheckResult.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide3CheckResult.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide3CheckResult.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3CheckResult.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide3CheckResult.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CheckResult.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CheckResult.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3CheckResult.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide3CheckResult.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide3CheckResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide3CheckResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide3CheckResult.Image = null;
            this.plAGVSide3CheckResult.Location = new System.Drawing.Point(4, 26);
            this.plAGVSide3CheckResult.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide3CheckResult.Name = "plAGVSide3CheckResult";
            this.plAGVSide3CheckResult.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide3CheckResult.TabIndex = 10;
            this.plAGVSide3CheckResult.Text = "AGV任务";
            this.plAGVSide3CheckResult.ToolTipTextCloseIcon = null;
            this.plAGVSide3CheckResult.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide3CheckResult.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbAGVSide3CheckResult
            // 
            this.pbAGVSide3CheckResult.BackColor = System.Drawing.Color.Gray;
            this.pbAGVSide3CheckResult.Location = new System.Drawing.Point(0, 36);
            this.pbAGVSide3CheckResult.Name = "pbAGVSide3CheckResult";
            this.pbAGVSide3CheckResult.Size = new System.Drawing.Size(236, 38);
            this.pbAGVSide3CheckResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAGVSide3CheckResult.TabIndex = 3;
            this.pbAGVSide3CheckResult.TabStop = false;
            // 
            // plAGVInput2
            // 
            this.plAGVInput2.AssociatedSplitter = null;
            this.plAGVInput2.BackColor = System.Drawing.Color.Transparent;
            this.plAGVInput2.CaptionFont = new System.Drawing.Font("宋体", 9.5F);
            this.plAGVInput2.CaptionHeight = 22;
            this.plAGVInput2.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVInput2.Controls.Add(this.btn_RefreshAGVSide2);
            this.plAGVInput2.Controls.Add(this.plAGVSide2CarcaseNo);
            this.plAGVInput2.Controls.Add(this.plAGVSide2BoxNo);
            this.plAGVInput2.Controls.Add(this.btn_CancelAGVSide2);
            this.plAGVInput2.Controls.Add(this.plAGVSide2Method);
            this.plAGVInput2.Controls.Add(this.plAGVSide2TaskCode);
            this.plAGVInput2.Controls.Add(this.plAGVSide2CheckResult);
            this.plAGVInput2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVInput2.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVInput2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVInput2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVInput2.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVInput2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVInput2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVInput2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVInput2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVInput2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVInput2.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVInput2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVInput2.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVInput2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVInput2.Image = null;
            this.plAGVInput2.Location = new System.Drawing.Point(3, 237);
            this.plAGVInput2.MinimumSize = new System.Drawing.Size(22, 22);
            this.plAGVInput2.Name = "plAGVInput2";
            this.plAGVInput2.Size = new System.Drawing.Size(1254, 188);
            this.plAGVInput2.TabIndex = 1;
            this.plAGVInput2.Text = "13寸入箱通道AGV任务";
            this.plAGVInput2.ToolTipTextCloseIcon = null;
            this.plAGVInput2.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVInput2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btn_RefreshAGVSide2
            // 
            this.btn_RefreshAGVSide2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RefreshAGVSide2.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RefreshAGVSide2.Image = null;
            this.btn_RefreshAGVSide2.Location = new System.Drawing.Point(246, 105);
            this.btn_RefreshAGVSide2.Name = "btn_RefreshAGVSide2";
            this.btn_RefreshAGVSide2.Size = new System.Drawing.Size(240, 77);
            this.btn_RefreshAGVSide2.TabIndex = 29;
            this.btn_RefreshAGVSide2.Text = "刷新";
            this.btn_RefreshAGVSide2.UseVisualStyleBackColor = true;
            this.btn_RefreshAGVSide2.Click += new System.EventHandler(this.btn_RefreshAGVSide2_Click);
            // 
            // plAGVSide2CarcaseNo
            // 
            this.plAGVSide2CarcaseNo.AssociatedSplitter = null;
            this.plAGVSide2CarcaseNo.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide2CarcaseNo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide2CarcaseNo.CaptionHeight = 32;
            this.plAGVSide2CarcaseNo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide2CarcaseNo.Controls.Add(this.txtAGVSide2CarcaseNo);
            this.plAGVSide2CarcaseNo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide2CarcaseNo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide2CarcaseNo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CarcaseNo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2CarcaseNo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2CarcaseNo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide2CarcaseNo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2CarcaseNo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2CarcaseNo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CarcaseNo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CarcaseNo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2CarcaseNo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2CarcaseNo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide2CarcaseNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide2CarcaseNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CarcaseNo.Image = null;
            this.plAGVSide2CarcaseNo.Location = new System.Drawing.Point(972, 26);
            this.plAGVSide2CarcaseNo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide2CarcaseNo.Name = "plAGVSide2CarcaseNo";
            this.plAGVSide2CarcaseNo.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide2CarcaseNo.TabIndex = 28;
            this.plAGVSide2CarcaseNo.Text = "架号";
            this.plAGVSide2CarcaseNo.ToolTipTextCloseIcon = null;
            this.plAGVSide2CarcaseNo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide2CarcaseNo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide2CarcaseNo
            // 
            this.txtAGVSide2CarcaseNo.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide2CarcaseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide2CarcaseNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide2CarcaseNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide2CarcaseNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide2CarcaseNo.Image = null;
            this.txtAGVSide2CarcaseNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide2CarcaseNo.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide2CarcaseNo.Name = "txtAGVSide2CarcaseNo";
            this.txtAGVSide2CarcaseNo.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide2CarcaseNo.PasswordChar = '\0';
            this.txtAGVSide2CarcaseNo.Required = false;
            this.txtAGVSide2CarcaseNo.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide2CarcaseNo.TabIndex = 0;
            // 
            // plAGVSide2BoxNo
            // 
            this.plAGVSide2BoxNo.AssociatedSplitter = null;
            this.plAGVSide2BoxNo.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide2BoxNo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide2BoxNo.CaptionHeight = 32;
            this.plAGVSide2BoxNo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide2BoxNo.Controls.Add(this.txtAGVSide2BoxNo);
            this.plAGVSide2BoxNo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide2BoxNo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide2BoxNo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2BoxNo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2BoxNo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2BoxNo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide2BoxNo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2BoxNo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2BoxNo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2BoxNo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2BoxNo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2BoxNo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2BoxNo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide2BoxNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide2BoxNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2BoxNo.Image = null;
            this.plAGVSide2BoxNo.Location = new System.Drawing.Point(730, 26);
            this.plAGVSide2BoxNo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide2BoxNo.Name = "plAGVSide2BoxNo";
            this.plAGVSide2BoxNo.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide2BoxNo.TabIndex = 27;
            this.plAGVSide2BoxNo.Text = "箱号";
            this.plAGVSide2BoxNo.ToolTipTextCloseIcon = null;
            this.plAGVSide2BoxNo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide2BoxNo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide2BoxNo
            // 
            this.txtAGVSide2BoxNo.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide2BoxNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide2BoxNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide2BoxNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide2BoxNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide2BoxNo.Image = null;
            this.txtAGVSide2BoxNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide2BoxNo.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide2BoxNo.Name = "txtAGVSide2BoxNo";
            this.txtAGVSide2BoxNo.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide2BoxNo.PasswordChar = '\0';
            this.txtAGVSide2BoxNo.Required = false;
            this.txtAGVSide2BoxNo.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide2BoxNo.TabIndex = 0;
            // 
            // btn_CancelAGVSide2
            // 
            this.btn_CancelAGVSide2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelAGVSide2.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_CancelAGVSide2.Image = null;
            this.btn_CancelAGVSide2.Location = new System.Drawing.Point(4, 106);
            this.btn_CancelAGVSide2.Name = "btn_CancelAGVSide2";
            this.btn_CancelAGVSide2.Size = new System.Drawing.Size(240, 77);
            this.btn_CancelAGVSide2.TabIndex = 25;
            this.btn_CancelAGVSide2.Text = "取消任务";
            this.btn_CancelAGVSide2.UseVisualStyleBackColor = true;
            this.btn_CancelAGVSide2.Click += new System.EventHandler(this.btn_CancelAGVSide2_Click);
            // 
            // plAGVSide2Method
            // 
            this.plAGVSide2Method.AssociatedSplitter = null;
            this.plAGVSide2Method.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide2Method.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide2Method.CaptionHeight = 32;
            this.plAGVSide2Method.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide2Method.Controls.Add(this.txtAGVSide2Method);
            this.plAGVSide2Method.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide2Method.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide2Method.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2Method.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2Method.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2Method.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide2Method.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2Method.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2Method.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2Method.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2Method.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2Method.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2Method.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide2Method.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide2Method.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2Method.Image = null;
            this.plAGVSide2Method.Location = new System.Drawing.Point(488, 26);
            this.plAGVSide2Method.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide2Method.Name = "plAGVSide2Method";
            this.plAGVSide2Method.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide2Method.TabIndex = 9;
            this.plAGVSide2Method.Text = "AGV上报状态";
            this.plAGVSide2Method.ToolTipTextCloseIcon = null;
            this.plAGVSide2Method.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide2Method.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide2Method
            // 
            this.txtAGVSide2Method.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide2Method.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide2Method.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide2Method.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide2Method.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide2Method.Image = null;
            this.txtAGVSide2Method.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide2Method.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide2Method.Name = "txtAGVSide2Method";
            this.txtAGVSide2Method.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide2Method.PasswordChar = '\0';
            this.txtAGVSide2Method.Required = false;
            this.txtAGVSide2Method.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide2Method.TabIndex = 0;
            // 
            // plAGVSide2TaskCode
            // 
            this.plAGVSide2TaskCode.AssociatedSplitter = null;
            this.plAGVSide2TaskCode.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide2TaskCode.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide2TaskCode.CaptionHeight = 32;
            this.plAGVSide2TaskCode.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide2TaskCode.Controls.Add(this.txtAGVSide2TaskCode);
            this.plAGVSide2TaskCode.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide2TaskCode.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide2TaskCode.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2TaskCode.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2TaskCode.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2TaskCode.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide2TaskCode.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2TaskCode.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2TaskCode.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2TaskCode.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2TaskCode.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2TaskCode.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2TaskCode.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide2TaskCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide2TaskCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2TaskCode.Image = null;
            this.plAGVSide2TaskCode.Location = new System.Drawing.Point(246, 26);
            this.plAGVSide2TaskCode.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide2TaskCode.Name = "plAGVSide2TaskCode";
            this.plAGVSide2TaskCode.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide2TaskCode.TabIndex = 8;
            this.plAGVSide2TaskCode.Text = "AGV任务编号";
            this.plAGVSide2TaskCode.ToolTipTextCloseIcon = null;
            this.plAGVSide2TaskCode.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide2TaskCode.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide2TaskCode
            // 
            this.txtAGVSide2TaskCode.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide2TaskCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide2TaskCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide2TaskCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide2TaskCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide2TaskCode.Image = null;
            this.txtAGVSide2TaskCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide2TaskCode.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide2TaskCode.Name = "txtAGVSide2TaskCode";
            this.txtAGVSide2TaskCode.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide2TaskCode.PasswordChar = '\0';
            this.txtAGVSide2TaskCode.Required = false;
            this.txtAGVSide2TaskCode.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide2TaskCode.TabIndex = 0;
            // 
            // plAGVSide2CheckResult
            // 
            this.plAGVSide2CheckResult.AssociatedSplitter = null;
            this.plAGVSide2CheckResult.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide2CheckResult.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide2CheckResult.CaptionHeight = 32;
            this.plAGVSide2CheckResult.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide2CheckResult.Controls.Add(this.pbAGVSide2CheckResult);
            this.plAGVSide2CheckResult.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide2CheckResult.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide2CheckResult.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CheckResult.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2CheckResult.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide2CheckResult.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide2CheckResult.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2CheckResult.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide2CheckResult.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CheckResult.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CheckResult.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2CheckResult.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide2CheckResult.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide2CheckResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide2CheckResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide2CheckResult.Image = null;
            this.plAGVSide2CheckResult.Location = new System.Drawing.Point(4, 26);
            this.plAGVSide2CheckResult.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide2CheckResult.Name = "plAGVSide2CheckResult";
            this.plAGVSide2CheckResult.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide2CheckResult.TabIndex = 7;
            this.plAGVSide2CheckResult.Text = "AGV任务";
            this.plAGVSide2CheckResult.ToolTipTextCloseIcon = null;
            this.plAGVSide2CheckResult.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide2CheckResult.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbAGVSide2CheckResult
            // 
            this.pbAGVSide2CheckResult.BackColor = System.Drawing.Color.Gray;
            this.pbAGVSide2CheckResult.Location = new System.Drawing.Point(0, 36);
            this.pbAGVSide2CheckResult.Name = "pbAGVSide2CheckResult";
            this.pbAGVSide2CheckResult.Size = new System.Drawing.Size(236, 38);
            this.pbAGVSide2CheckResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAGVSide2CheckResult.TabIndex = 3;
            this.pbAGVSide2CheckResult.TabStop = false;
            // 
            // plAGVInput1
            // 
            this.plAGVInput1.AssociatedSplitter = null;
            this.plAGVInput1.BackColor = System.Drawing.Color.Transparent;
            this.plAGVInput1.CaptionFont = new System.Drawing.Font("宋体", 9.5F);
            this.plAGVInput1.CaptionHeight = 22;
            this.plAGVInput1.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVInput1.Controls.Add(this.btn_RefreshAGVSide1);
            this.plAGVInput1.Controls.Add(this.plAGVSide1CarcaseNo);
            this.plAGVInput1.Controls.Add(this.plAGVSide1BoxNo);
            this.plAGVInput1.Controls.Add(this.btn_CancelAGVSide1);
            this.plAGVInput1.Controls.Add(this.plAGVSide1Method);
            this.plAGVInput1.Controls.Add(this.plAGVSide1TaskCode);
            this.plAGVInput1.Controls.Add(this.plAGVSide1CheckResult);
            this.plAGVInput1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVInput1.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVInput1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVInput1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVInput1.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVInput1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVInput1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVInput1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVInput1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVInput1.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVInput1.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVInput1.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVInput1.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVInput1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVInput1.Image = null;
            this.plAGVInput1.Location = new System.Drawing.Point(3, 3);
            this.plAGVInput1.MinimumSize = new System.Drawing.Size(22, 22);
            this.plAGVInput1.Name = "plAGVInput1";
            this.plAGVInput1.Size = new System.Drawing.Size(1254, 188);
            this.plAGVInput1.TabIndex = 0;
            this.plAGVInput1.Text = "7寸入箱通道AGV任务";
            this.plAGVInput1.ToolTipTextCloseIcon = null;
            this.plAGVInput1.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVInput1.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btn_RefreshAGVSide1
            // 
            this.btn_RefreshAGVSide1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RefreshAGVSide1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RefreshAGVSide1.Image = null;
            this.btn_RefreshAGVSide1.Location = new System.Drawing.Point(246, 107);
            this.btn_RefreshAGVSide1.Name = "btn_RefreshAGVSide1";
            this.btn_RefreshAGVSide1.Size = new System.Drawing.Size(240, 77);
            this.btn_RefreshAGVSide1.TabIndex = 27;
            this.btn_RefreshAGVSide1.Text = "刷新";
            this.btn_RefreshAGVSide1.UseVisualStyleBackColor = true;
            this.btn_RefreshAGVSide1.Click += new System.EventHandler(this.btn_RefreshAGVSide1_Click);
            // 
            // plAGVSide1CarcaseNo
            // 
            this.plAGVSide1CarcaseNo.AssociatedSplitter = null;
            this.plAGVSide1CarcaseNo.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide1CarcaseNo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide1CarcaseNo.CaptionHeight = 32;
            this.plAGVSide1CarcaseNo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide1CarcaseNo.Controls.Add(this.txtAGVSide1CarcaseNo);
            this.plAGVSide1CarcaseNo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide1CarcaseNo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide1CarcaseNo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CarcaseNo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1CarcaseNo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1CarcaseNo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide1CarcaseNo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1CarcaseNo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1CarcaseNo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CarcaseNo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CarcaseNo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1CarcaseNo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1CarcaseNo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide1CarcaseNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide1CarcaseNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CarcaseNo.Image = null;
            this.plAGVSide1CarcaseNo.Location = new System.Drawing.Point(972, 26);
            this.plAGVSide1CarcaseNo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide1CarcaseNo.Name = "plAGVSide1CarcaseNo";
            this.plAGVSide1CarcaseNo.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide1CarcaseNo.TabIndex = 26;
            this.plAGVSide1CarcaseNo.Text = "架号";
            this.plAGVSide1CarcaseNo.ToolTipTextCloseIcon = null;
            this.plAGVSide1CarcaseNo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide1CarcaseNo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide1CarcaseNo
            // 
            this.txtAGVSide1CarcaseNo.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide1CarcaseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide1CarcaseNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide1CarcaseNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide1CarcaseNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide1CarcaseNo.Image = null;
            this.txtAGVSide1CarcaseNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide1CarcaseNo.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide1CarcaseNo.Name = "txtAGVSide1CarcaseNo";
            this.txtAGVSide1CarcaseNo.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide1CarcaseNo.PasswordChar = '\0';
            this.txtAGVSide1CarcaseNo.Required = false;
            this.txtAGVSide1CarcaseNo.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide1CarcaseNo.TabIndex = 0;
            // 
            // plAGVSide1BoxNo
            // 
            this.plAGVSide1BoxNo.AssociatedSplitter = null;
            this.plAGVSide1BoxNo.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide1BoxNo.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide1BoxNo.CaptionHeight = 32;
            this.plAGVSide1BoxNo.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide1BoxNo.Controls.Add(this.txtAGVSide1BoxNo);
            this.plAGVSide1BoxNo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide1BoxNo.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide1BoxNo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1BoxNo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1BoxNo.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1BoxNo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide1BoxNo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1BoxNo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1BoxNo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1BoxNo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1BoxNo.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1BoxNo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1BoxNo.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide1BoxNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide1BoxNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1BoxNo.Image = null;
            this.plAGVSide1BoxNo.Location = new System.Drawing.Point(730, 26);
            this.plAGVSide1BoxNo.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide1BoxNo.Name = "plAGVSide1BoxNo";
            this.plAGVSide1BoxNo.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide1BoxNo.TabIndex = 25;
            this.plAGVSide1BoxNo.Text = "箱号";
            this.plAGVSide1BoxNo.ToolTipTextCloseIcon = null;
            this.plAGVSide1BoxNo.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide1BoxNo.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide1BoxNo
            // 
            this.txtAGVSide1BoxNo.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide1BoxNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide1BoxNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide1BoxNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide1BoxNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide1BoxNo.Image = null;
            this.txtAGVSide1BoxNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide1BoxNo.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide1BoxNo.Name = "txtAGVSide1BoxNo";
            this.txtAGVSide1BoxNo.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide1BoxNo.PasswordChar = '\0';
            this.txtAGVSide1BoxNo.Required = false;
            this.txtAGVSide1BoxNo.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide1BoxNo.TabIndex = 0;
            // 
            // btn_CancelAGVSide1
            // 
            this.btn_CancelAGVSide1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelAGVSide1.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_CancelAGVSide1.Image = null;
            this.btn_CancelAGVSide1.Location = new System.Drawing.Point(4, 106);
            this.btn_CancelAGVSide1.Name = "btn_CancelAGVSide1";
            this.btn_CancelAGVSide1.Size = new System.Drawing.Size(240, 77);
            this.btn_CancelAGVSide1.TabIndex = 24;
            this.btn_CancelAGVSide1.Text = "取消任务";
            this.btn_CancelAGVSide1.UseVisualStyleBackColor = true;
            this.btn_CancelAGVSide1.Click += new System.EventHandler(this.btn_CancelAGVSide1_Click);
            // 
            // plAGVSide1Method
            // 
            this.plAGVSide1Method.AssociatedSplitter = null;
            this.plAGVSide1Method.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide1Method.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide1Method.CaptionHeight = 32;
            this.plAGVSide1Method.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide1Method.Controls.Add(this.txtAGVSide1Method);
            this.plAGVSide1Method.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide1Method.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide1Method.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1Method.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1Method.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1Method.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide1Method.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1Method.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1Method.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1Method.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1Method.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1Method.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1Method.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide1Method.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide1Method.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1Method.Image = null;
            this.plAGVSide1Method.Location = new System.Drawing.Point(488, 26);
            this.plAGVSide1Method.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide1Method.Name = "plAGVSide1Method";
            this.plAGVSide1Method.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide1Method.TabIndex = 6;
            this.plAGVSide1Method.Text = "AGV上报状态";
            this.plAGVSide1Method.ToolTipTextCloseIcon = null;
            this.plAGVSide1Method.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide1Method.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide1Method
            // 
            this.txtAGVSide1Method.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide1Method.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide1Method.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide1Method.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide1Method.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide1Method.Image = null;
            this.txtAGVSide1Method.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide1Method.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide1Method.Name = "txtAGVSide1Method";
            this.txtAGVSide1Method.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide1Method.PasswordChar = '\0';
            this.txtAGVSide1Method.Required = false;
            this.txtAGVSide1Method.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide1Method.TabIndex = 0;
            // 
            // plAGVSide1TaskCode
            // 
            this.plAGVSide1TaskCode.AssociatedSplitter = null;
            this.plAGVSide1TaskCode.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide1TaskCode.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide1TaskCode.CaptionHeight = 32;
            this.plAGVSide1TaskCode.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide1TaskCode.Controls.Add(this.txtAGVSide1TaskCode);
            this.plAGVSide1TaskCode.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide1TaskCode.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide1TaskCode.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1TaskCode.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1TaskCode.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1TaskCode.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide1TaskCode.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1TaskCode.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1TaskCode.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1TaskCode.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1TaskCode.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1TaskCode.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1TaskCode.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide1TaskCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide1TaskCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1TaskCode.Image = null;
            this.plAGVSide1TaskCode.Location = new System.Drawing.Point(246, 26);
            this.plAGVSide1TaskCode.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide1TaskCode.Name = "plAGVSide1TaskCode";
            this.plAGVSide1TaskCode.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide1TaskCode.TabIndex = 5;
            this.plAGVSide1TaskCode.Text = "AGV任务编号";
            this.plAGVSide1TaskCode.ToolTipTextCloseIcon = null;
            this.plAGVSide1TaskCode.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide1TaskCode.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // txtAGVSide1TaskCode
            // 
            this.txtAGVSide1TaskCode.BackColor = System.Drawing.Color.Transparent;
            this.txtAGVSide1TaskCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtAGVSide1TaskCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAGVSide1TaskCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAGVSide1TaskCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAGVSide1TaskCode.Image = null;
            this.txtAGVSide1TaskCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAGVSide1TaskCode.Location = new System.Drawing.Point(4, 36);
            this.txtAGVSide1TaskCode.Name = "txtAGVSide1TaskCode";
            this.txtAGVSide1TaskCode.Padding = new System.Windows.Forms.Padding(2);
            this.txtAGVSide1TaskCode.PasswordChar = '\0';
            this.txtAGVSide1TaskCode.Required = false;
            this.txtAGVSide1TaskCode.Size = new System.Drawing.Size(232, 37);
            this.txtAGVSide1TaskCode.TabIndex = 0;
            // 
            // plAGVSide1CheckResult
            // 
            this.plAGVSide1CheckResult.AssociatedSplitter = null;
            this.plAGVSide1CheckResult.BackColor = System.Drawing.Color.Transparent;
            this.plAGVSide1CheckResult.CaptionFont = new System.Drawing.Font("宋体", 14F);
            this.plAGVSide1CheckResult.CaptionHeight = 32;
            this.plAGVSide1CheckResult.ColorScheme = TX.Framework.WindowUI.Controls.ColorScheme.Custom;
            this.plAGVSide1CheckResult.Controls.Add(this.pbAGVSide1CheckResult);
            this.plAGVSide1CheckResult.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.plAGVSide1CheckResult.CustomColors.CaptionCloseIcon = System.Drawing.Color.Red;
            this.plAGVSide1CheckResult.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CheckResult.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1CheckResult.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.plAGVSide1CheckResult.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.plAGVSide1CheckResult.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1CheckResult.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.plAGVSide1CheckResult.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CheckResult.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CheckResult.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1CheckResult.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.plAGVSide1CheckResult.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.plAGVSide1CheckResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plAGVSide1CheckResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plAGVSide1CheckResult.Image = null;
            this.plAGVSide1CheckResult.Location = new System.Drawing.Point(4, 26);
            this.plAGVSide1CheckResult.MinimumSize = new System.Drawing.Size(32, 32);
            this.plAGVSide1CheckResult.Name = "plAGVSide1CheckResult";
            this.plAGVSide1CheckResult.Size = new System.Drawing.Size(240, 77);
            this.plAGVSide1CheckResult.TabIndex = 4;
            this.plAGVSide1CheckResult.Text = "AGV任务";
            this.plAGVSide1CheckResult.ToolTipTextCloseIcon = null;
            this.plAGVSide1CheckResult.ToolTipTextExpandIconPanelCollapsed = null;
            this.plAGVSide1CheckResult.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // pbAGVSide1CheckResult
            // 
            this.pbAGVSide1CheckResult.BackColor = System.Drawing.Color.Gray;
            this.pbAGVSide1CheckResult.Location = new System.Drawing.Point(0, 36);
            this.pbAGVSide1CheckResult.Name = "pbAGVSide1CheckResult";
            this.pbAGVSide1CheckResult.Size = new System.Drawing.Size(236, 38);
            this.pbAGVSide1CheckResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAGVSide1CheckResult.TabIndex = 3;
            this.pbAGVSide1CheckResult.TabStop = false;
            // 
            // templateColumnHeader1
            // 
            this.templateColumnHeader1.Column = 0;
            this.templateColumnHeader1.Template = "$this.TaskCode";
            this.templateColumnHeader1.Text = "任务编号";
            this.templateColumnHeader1.Width = 240;
            // 
            // templateColumnHeader2
            // 
            this.templateColumnHeader2.Column = 0;
            this.templateColumnHeader2.Template = "$this.Method";
            this.templateColumnHeader2.Text = "任务状态信息";
            this.templateColumnHeader2.Width = 480;
            // 
            // templateColumnHeader3
            // 
            this.templateColumnHeader3.Column = 0;
            this.templateColumnHeader3.Template = "$this.CreateTime";
            this.templateColumnHeader3.Text = "上报时间";
            this.templateColumnHeader3.Width = 240;
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.txTabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ApplicationForm";
            this.Text = "码垛机";
            this.plPLC.ResumeLayout(false);
            this.plPLC.PerformLayout();
            this.txTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbReelInfo.ResumeLayout(false);
            this.panelCurrentProcessInfo.ResumeLayout(false);
            this.plReelIdCheckResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReelIdCheckResult)).EndInit();
            this.panel50.ResumeLayout(false);
            this.panel46.ResumeLayout(false);
            this.plNGDisplay.ResumeLayout(false);
            this.panelCurrentNGInfo.ResumeLayout(false);
            this.gbPLCInfo.ResumeLayout(false);
            this.plScan2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbScan2)).EndInit();
            this.plScan1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbScan1)).EndInit();
            this.plCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            this.plUrgentStop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUrgentStop)).EndInit();
            this.plAutoModel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoModel)).EndInit();
            this.plUpInitialInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpInitialInfo)).EndInit();
            this.plStreamInitialing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStreamInitialing)).EndInit();
            this.plUpInitialing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpInitialing)).EndInit();
            this.plSteamAutoing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSteamAutoing)).EndInit();
            this.plUpAutoing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpAutoing)).EndInit();
            this.plStreamInitialOK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStreamInitialOK)).EndInit();
            this.plUpInitialOK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpInitialOK)).EndInit();
            this.plAutoModeling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoModeling)).EndInit();
            this.plRaiseError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRaiseError)).EndInit();
            this.gbBoxInfo.ResumeLayout(false);
            this.panelCurrentBoxInfo.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.plBoxCheckResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxCheckResult)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.plAGVOutput3.ResumeLayout(false);
            this.plAGVSide3CarcaseNo.ResumeLayout(false);
            this.plAGVSide3BoxNo.ResumeLayout(false);
            this.plAGVSide3Method.ResumeLayout(false);
            this.plAGVSide3TaskCode.ResumeLayout(false);
            this.plAGVSide3CheckResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAGVSide3CheckResult)).EndInit();
            this.plAGVInput2.ResumeLayout(false);
            this.plAGVSide2CarcaseNo.ResumeLayout(false);
            this.plAGVSide2BoxNo.ResumeLayout(false);
            this.plAGVSide2Method.ResumeLayout(false);
            this.plAGVSide2TaskCode.ResumeLayout(false);
            this.plAGVSide2CheckResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAGVSide2CheckResult)).EndInit();
            this.plAGVInput1.ResumeLayout(false);
            this.plAGVSide1CarcaseNo.ResumeLayout(false);
            this.plAGVSide1BoxNo.ResumeLayout(false);
            this.plAGVSide1Method.ResumeLayout(false);
            this.plAGVSide1TaskCode.ResumeLayout(false);
            this.plAGVSide1CheckResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAGVSide1CheckResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TX.Framework.WindowUI.Controls.Panel plPLC;
        private TX.Framework.WindowUI.Controls.TXButton btn_open;
        private TX.Framework.WindowUI.Controls.TXButton btn_start;
        private TX.Framework.WindowUI.Controls.TXButton btn_close;
        private TX.Framework.WindowUI.Controls.TXButton btn_stop;
        private TX.Framework.WindowUI.Controls.TXTabControl txTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labIP;
        private TX.Framework.WindowUI.Controls.TXTextBox txt_port;
        private System.Windows.Forms.Label label1;
        private TX.Framework.WindowUI.Controls.TXTextBox txt_ip;
        private TX.Framework.WindowUI.Controls.TXButton btn_TakePhotoFromEquiment0;
        private TX.Framework.WindowUI.Controls.TXButton btn_error;
        private TX.Framework.WindowUI.Controls.TXButton btn_initial;
        private TX.Framework.WindowUI.Controls.TXButton btn_TakeScanFromEquiment2;
        private TX.Framework.WindowUI.Controls.TXButton btn_TakeScanFromEquiment1;
        private TX.Framework.WindowUI.Controls.TXGroupBox gbBoxInfo;
        private TX.Framework.WindowUI.Controls.Panel panel45;
        private TX.Framework.WindowUI.Controls.TXTextBox curBufBoxNo;
        private TX.Framework.WindowUI.Controls.Panel panel46;
        private TX.Framework.WindowUI.Controls.TXTextBox curBufReelId;
        private TX.Framework.WindowUI.Controls.Panel panel48;
        private TX.Framework.WindowUI.Controls.TXTextBox curBufIsEmpty;
        private TX.Framework.WindowUI.Controls.Panel panel49;
        private TX.Framework.WindowUI.Controls.TXTextBox curBufBoxNoBindOutorderNo;
        private TX.Framework.WindowUI.Controls.Panel panel50;
        private TX.Framework.WindowUI.Controls.TXTextBox curBufReelIdBindOutorderNo;
        private TX.Framework.WindowUI.Controls.TXGroupBox gbPLCInfo;
        private TX.Framework.WindowUI.Controls.Panel plBoxCheckResult;
        private System.Windows.Forms.PictureBox pbBoxCheckResult;
        private TX.Framework.WindowUI.Controls.Panel plReelIdCheckResult;
        private System.Windows.Forms.PictureBox pbReelIdCheckResult;
        private TX.Framework.WindowUI.Controls.Panel plRaiseError;
        private System.Windows.Forms.PictureBox pbRaiseError;
        private TX.Framework.WindowUI.Controls.Panel plAutoModeling;
        private System.Windows.Forms.PictureBox pbAutoModeling;
        private TX.Framework.WindowUI.Controls.Panel plUpInitialOK;
        private System.Windows.Forms.PictureBox pbUpInitialOK;
        private TX.Framework.WindowUI.Controls.Panel plUpAutoing;
        private System.Windows.Forms.PictureBox pbUpAutoing;
        private TX.Framework.WindowUI.Controls.Panel plStreamInitialOK;
        private System.Windows.Forms.PictureBox pbStreamInitialOK;
        private TX.Framework.WindowUI.Controls.Panel plStreamInitialing;
        private System.Windows.Forms.PictureBox pbStreamInitialing;
        private TX.Framework.WindowUI.Controls.Panel plUpInitialing;
        private System.Windows.Forms.PictureBox pbUpInitialing;
        private TX.Framework.WindowUI.Controls.Panel plSteamAutoing;
        private System.Windows.Forms.PictureBox pbSteamAutoing;
        private TX.Framework.WindowUI.Controls.Panel plNGDisplay;
        private System.Windows.Forms.Label txt_NGDisplay;
        private TX.Framework.WindowUI.Controls.Panel plUpInitialInfo;
        private System.Windows.Forms.PictureBox pbUpInitialInfo;
        private TX.Framework.WindowUI.Controls.Panel plAutoModel;
        private System.Windows.Forms.PictureBox pbAutoModel;
        private TX.Framework.WindowUI.Controls.Panel plUrgentStop;
        private System.Windows.Forms.PictureBox pbUrgentStop;
        private TX.Framework.WindowUI.Controls.TXGroupBox gbReelInfo;
        private TX.Framework.WindowUI.Controls.Panel plScan2;
        private System.Windows.Forms.PictureBox pbScan2;
        private TX.Framework.WindowUI.Controls.Panel plScan1;
        private System.Windows.Forms.PictureBox pbScan1;
        private TX.Framework.WindowUI.Controls.Panel plCamera;
        private System.Windows.Forms.PictureBox pbCamera;
        private TX.Framework.WindowUI.Controls.TXButton btn_rollout;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoprc_start;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoprc_stop;
        private System.Windows.Forms.TabPage tabPage3;
        private TX.Framework.WindowUI.Controls.Panel plAGVInput1;
        private TX.Framework.WindowUI.Controls.Panel plAGVInput2;
        private TX.Framework.WindowUI.Controls.Panel plAGVOutput3;
        private TX.Framework.WindowUI.Controls.TemplateColumnHeader templateColumnHeader1;
        private TX.Framework.WindowUI.Controls.TemplateColumnHeader templateColumnHeader2;
        private TX.Framework.WindowUI.Controls.TemplateColumnHeader templateColumnHeader3;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide1CheckResult;
        private System.Windows.Forms.PictureBox pbAGVSide1CheckResult;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide1TaskCode;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide1TaskCode;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide1Method;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide1Method;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide2Method;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide2Method;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide2TaskCode;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide2TaskCode;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide2CheckResult;
        private System.Windows.Forms.PictureBox pbAGVSide2CheckResult;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide3Method;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide3Method;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide3TaskCode;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide3TaskCode;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide3CheckResult;
        private System.Windows.Forms.PictureBox pbAGVSide3CheckResult;
        private TX.Framework.WindowUI.Controls.TXButton btn_CancelAGVSide1;
        private TX.Framework.WindowUI.Controls.TXButton btn_CancelAGVSide2;
        private TX.Framework.WindowUI.Controls.TXButton btn_CancelAGVSide3;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide1BoxNo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide1BoxNo;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide1CarcaseNo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide1CarcaseNo;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide2CarcaseNo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide2CarcaseNo;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide2BoxNo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide2BoxNo;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide3CarcaseNo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide3CarcaseNo;
        private TX.Framework.WindowUI.Controls.Panel plAGVSide3BoxNo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtAGVSide3BoxNo;
        private TX.Framework.WindowUI.Controls.Panel panelCurrentProcessInfo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtCurrentProcessInfo;
        private TX.Framework.WindowUI.Controls.Panel panelCurrentNGInfo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtCurrentNGInfo;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoagv1_start;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoagv1_stop;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoagv3_stop;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoagv3_start;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoagv2_stop;
        private TX.Framework.WindowUI.Controls.TXButton btn_autoagv2_start;
        private TX.Framework.WindowUI.Controls.Panel panelCurrentBoxInfo;
        private TX.Framework.WindowUI.Controls.TXTextBox txtCurrentBoxInfo;
        private TX.Framework.WindowUI.Controls.TXButton btn_RefreshAGVSide1;
        private TX.Framework.WindowUI.Controls.TXButton btn_RefreshAGVSide2;
        private TX.Framework.WindowUI.Controls.TXButton btn_RefreshAGVSide3;
    }
}