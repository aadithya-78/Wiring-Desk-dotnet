namespace Wiring_Desk
{
    partial class GTI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GTI));
            this.panelFooter = new System.Windows.Forms.Panel();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Date_Timer = new System.Windows.Forms.Timer(this.components);
            this.panelHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelComIndicator = new System.Windows.Forms.Panel();
            this.btnDate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnShift = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTime = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelUserControl = new System.Windows.Forms.Panel();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.selectDesk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActualTargetTime = new System.Windows.Forms.RichTextBox();
            this.lblTargetCycleTime = new System.Windows.Forms.RichTextBox();
            this.lblActualCount = new System.Windows.Forms.RichTextBox();
            this.lblTargetCount = new System.Windows.Forms.RichTextBox();
            this.lblStepIndicator = new System.Windows.Forms.RichTextBox();
            this.btnStepDecr = new System.Windows.Forms.Button();
            this.btnStepIncr = new System.Windows.Forms.Button();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.panelPicConfig = new System.Windows.Forms.Panel();
            this.cycleTimer = new System.Windows.Forms.Timer(this.components);
            this.rxtxTimerHome = new System.Windows.Forms.Timer(this.components);
            this.rounded_Button2 = new Wiring_Desk.Rounded_Button();
            this.btnClose = new Wiring_Desk.Rounded_Button();
            this.btn_TimeElapsedDisable = new Wiring_Desk.Rounded_Button();
            this.btn_Manual = new Wiring_Desk.Rounded_Button();
            this.btn_TimeElapsedEnable = new Wiring_Desk.Rounded_Button();
            this.btn_Scanner = new Wiring_Desk.Rounded_Button();
            this.btn_CyDisable = new Wiring_Desk.Rounded_Button();
            this.btn_CyEnable = new Wiring_Desk.Rounded_Button();
            this.btn_WarOff = new Wiring_Desk.Rounded_Button();
            this.lblCycleTime = new Wiring_Desk.Rounded_Button();
            this.btn_WarOn = new Wiring_Desk.Rounded_Button();
            this.lblCount = new Wiring_Desk.Rounded_Button();
            this.lblTimeElapsed = new Wiring_Desk.Rounded_Button();
            this.lblDeskSelection = new Wiring_Desk.Rounded_Button();
            this.rounded_Button5 = new Wiring_Desk.Rounded_Button();
            this.lblProcessStep = new Wiring_Desk.Rounded_Button();
            this.lbWarningAlarm = new Wiring_Desk.Rounded_Button();
            this.lblSelectDesk = new Wiring_Desk.Rounded_Button();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(103)))), ((int)(((byte)(160)))));
            this.panelFooter.Controls.Add(this.labelInstruction);
            this.panelFooter.Controls.Add(this.btnSettings);
            this.panelFooter.Controls.Add(this.btnStart);
            this.panelFooter.Controls.Add(this.btnReset);
            this.panelFooter.Controls.Add(this.btnPause);
            this.panelFooter.Location = new System.Drawing.Point(0, 625);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1366, 70);
            this.panelFooter.TabIndex = 30;
            this.panelFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFooter_Paint);
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstruction.ForeColor = System.Drawing.Color.White;
            this.labelInstruction.Location = new System.Drawing.Point(169, 11);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(1110, 46);
            this.labelInstruction.TabIndex = 38;
            this.labelInstruction.Text = resources.GetString("labelInstruction.Text");
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageSize = new System.Drawing.Size(60, 60);
            this.btnSettings.Location = new System.Drawing.Point(1294, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(60, 60);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnStart
            // 
            this.btnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStart.FillColor = System.Drawing.Color.White;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageSize = new System.Drawing.Size(60, 60);
            this.btnStart.Location = new System.Drawing.Point(12, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 60);
            this.btnStart.TabIndex = 0;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Yellow;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(78, 36);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 28);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(78, 7);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(85, 28);
            this.btnPause.TabIndex = 36;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 19200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataRecieved);
            // 
            // Date_Timer
            // 
            this.Date_Timer.Interval = 1000;
            this.Date_Timer.Tick += new System.EventHandler(this.Date_Timer_Tick);
            // 
            // panelHeader
            // 
            this.panelHeader.BorderRadius = 5;
            this.panelHeader.Controls.Add(this.panelComIndicator);
            this.panelHeader.Controls.Add(this.btnDate);
            this.panelHeader.Controls.Add(this.btnLogin);
            this.panelHeader.Controls.Add(this.btnShift);
            this.panelHeader.Controls.Add(this.btnTime);
            this.panelHeader.Controls.Add(this.guna2Button1);
            this.panelHeader.Controls.Add(this.panel2);
            this.panelHeader.Controls.Add(this.rounded_Button2);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(103)))), ((int)(((byte)(160)))));
            this.panelHeader.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.panelHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1366, 75);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // panelComIndicator
            // 
            this.panelComIndicator.Location = new System.Drawing.Point(1065, 63);
            this.panelComIndicator.Name = "panelComIndicator";
            this.panelComIndicator.Size = new System.Drawing.Size(167, 10);
            this.panelComIndicator.TabIndex = 64;
            // 
            // btnDate
            // 
            this.btnDate.BorderColor = System.Drawing.Color.Transparent;
            this.btnDate.BorderThickness = 2;
            this.btnDate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(190)))), ((int)(((byte)(219)))));
            this.btnDate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(219)))));
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.ForeColor = System.Drawing.Color.White;
            this.btnDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDate.Location = new System.Drawing.Point(1065, 37);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(82, 24);
            this.btnDate.TabIndex = 63;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderThickness = 2;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.btnLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(153)))));
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnLogin.Location = new System.Drawing.Point(1065, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 24);
            this.btnLogin.TabIndex = 62;
            this.btnLogin.Text = "Admin";
            // 
            // btnShift
            // 
            this.btnShift.BorderColor = System.Drawing.Color.Transparent;
            this.btnShift.BorderThickness = 2;
            this.btnShift.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShift.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShift.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShift.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShift.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShift.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(51)))));
            this.btnShift.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(153)))));
            this.btnShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShift.ForeColor = System.Drawing.Color.Black;
            this.btnShift.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnShift.Location = new System.Drawing.Point(1153, 6);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(79, 24);
            this.btnShift.TabIndex = 61;
            this.btnShift.Text = "Shift-A";
            // 
            // btnTime
            // 
            this.btnTime.BorderColor = System.Drawing.Color.Transparent;
            this.btnTime.BorderThickness = 2;
            this.btnTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTime.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(190)))), ((int)(((byte)(219)))));
            this.btnTime.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(219)))));
            this.btnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTime.ForeColor = System.Drawing.Color.White;
            this.btnTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTime.Location = new System.Drawing.Point(1150, 37);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(82, 24);
            this.btnTime.TabIndex = 60;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageOffset = new System.Drawing.Point(0, 25);
            this.guna2Button1.ImageSize = new System.Drawing.Size(55, 55);
            this.guna2Button1.Location = new System.Drawing.Point(1255, 8);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(60, 60);
            this.guna2Button1.TabIndex = 59;
            this.guna2Button1.Text = "guna2Button1";
            this.guna2Button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Guna2Button1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 687);
            this.panel2.TabIndex = 50;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(325, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(717, 33);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "GUIDED TERMINAL INSERTION NAVIGATION SYSTEM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 50);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // panelUserControl
            // 
            this.panelUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserControl.Location = new System.Drawing.Point(0, 120);
            this.panelUserControl.Name = "panelUserControl";
            this.panelUserControl.Size = new System.Drawing.Size(1366, 502);
            this.panelUserControl.TabIndex = 31;
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(103)))), ((int)(((byte)(160)))));
            this.panelToolbar.Controls.Add(this.selectDesk);
            this.panelToolbar.Controls.Add(this.label3);
            this.panelToolbar.Controls.Add(this.label2);
            this.panelToolbar.Controls.Add(this.btn_TimeElapsedDisable);
            this.panelToolbar.Controls.Add(this.btn_Manual);
            this.panelToolbar.Controls.Add(this.btn_TimeElapsedEnable);
            this.panelToolbar.Controls.Add(this.btn_Scanner);
            this.panelToolbar.Controls.Add(this.btn_CyDisable);
            this.panelToolbar.Controls.Add(this.btn_CyEnable);
            this.panelToolbar.Controls.Add(this.btn_WarOff);
            this.panelToolbar.Controls.Add(this.lblCycleTime);
            this.panelToolbar.Controls.Add(this.btn_WarOn);
            this.panelToolbar.Controls.Add(this.lblCount);
            this.panelToolbar.Controls.Add(this.lblTimeElapsed);
            this.panelToolbar.Controls.Add(this.lblDeskSelection);
            this.panelToolbar.Controls.Add(this.rounded_Button5);
            this.panelToolbar.Controls.Add(this.lblProcessStep);
            this.panelToolbar.Controls.Add(this.lbWarningAlarm);
            this.panelToolbar.Controls.Add(this.lblSelectDesk);
            this.panelToolbar.Controls.Add(this.lblActualTargetTime);
            this.panelToolbar.Controls.Add(this.lblTargetCycleTime);
            this.panelToolbar.Controls.Add(this.lblActualCount);
            this.panelToolbar.Controls.Add(this.lblTargetCount);
            this.panelToolbar.Controls.Add(this.lblStepIndicator);
            this.panelToolbar.Controls.Add(this.btnStepDecr);
            this.panelToolbar.Controls.Add(this.btnStepIncr);
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1366, 120);
            this.panelToolbar.TabIndex = 33;
            // 
            // selectDesk
            // 
            this.selectDesk.BackColor = System.Drawing.Color.White;
            this.selectDesk.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectDesk.DropDownHeight = 200;
            this.selectDesk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectDesk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDesk.FormattingEnabled = true;
            this.selectDesk.IntegralHeight = false;
            this.selectDesk.ItemHeight = 25;
            this.selectDesk.Location = new System.Drawing.Point(180, 20);
            this.selectDesk.Name = "selectDesk";
            this.selectDesk.Size = new System.Drawing.Size(148, 31);
            this.selectDesk.TabIndex = 49;
            this.selectDesk.SelectedIndexChanged += new System.EventHandler(this.selectDesk_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1257, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1168, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Target";
            // 
            // lblActualTargetTime
            // 
            this.lblActualTargetTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualTargetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualTargetTime.Location = new System.Drawing.Point(1238, 62);
            this.lblActualTargetTime.Multiline = false;
            this.lblActualTargetTime.Name = "lblActualTargetTime";
            this.lblActualTargetTime.ReadOnly = true;
            this.lblActualTargetTime.Size = new System.Drawing.Size(79, 34);
            this.lblActualTargetTime.TabIndex = 29;
            this.lblActualTargetTime.Text = "";
            // 
            // lblTargetCycleTime
            // 
            this.lblTargetCycleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetCycleTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetCycleTime.Location = new System.Drawing.Point(1153, 62);
            this.lblTargetCycleTime.Multiline = false;
            this.lblTargetCycleTime.Name = "lblTargetCycleTime";
            this.lblTargetCycleTime.ReadOnly = true;
            this.lblTargetCycleTime.Size = new System.Drawing.Size(79, 34);
            this.lblTargetCycleTime.TabIndex = 28;
            this.lblTargetCycleTime.Text = "";
            // 
            // lblActualCount
            // 
            this.lblActualCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualCount.Location = new System.Drawing.Point(1238, 20);
            this.lblActualCount.Multiline = false;
            this.lblActualCount.Name = "lblActualCount";
            this.lblActualCount.ReadOnly = true;
            this.lblActualCount.Size = new System.Drawing.Size(79, 34);
            this.lblActualCount.TabIndex = 27;
            this.lblActualCount.Text = "0";
            // 
            // lblTargetCount
            // 
            this.lblTargetCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTargetCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetCount.Location = new System.Drawing.Point(1153, 20);
            this.lblTargetCount.Multiline = false;
            this.lblTargetCount.Name = "lblTargetCount";
            this.lblTargetCount.ReadOnly = true;
            this.lblTargetCount.Size = new System.Drawing.Size(79, 34);
            this.lblTargetCount.TabIndex = 26;
            this.lblTargetCount.Tag = "";
            this.lblTargetCount.Text = "50";
            // 
            // lblStepIndicator
            // 
            this.lblStepIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepIndicator.Location = new System.Drawing.Point(508, 20);
            this.lblStepIndicator.Multiline = false;
            this.lblStepIndicator.Name = "lblStepIndicator";
            this.lblStepIndicator.ReadOnly = true;
            this.lblStepIndicator.Size = new System.Drawing.Size(76, 34);
            this.lblStepIndicator.TabIndex = 19;
            this.lblStepIndicator.Text = "";
            this.lblStepIndicator.TextChanged += new System.EventHandler(this.lblStepIndicator_TextChanged);
            // 
            // btnStepDecr
            // 
            this.btnStepDecr.BackColor = System.Drawing.Color.White;
            this.btnStepDecr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepDecr.Location = new System.Drawing.Point(590, 20);
            this.btnStepDecr.Name = "btnStepDecr";
            this.btnStepDecr.Size = new System.Drawing.Size(26, 34);
            this.btnStepDecr.TabIndex = 18;
            this.btnStepDecr.Text = "<";
            this.btnStepDecr.UseVisualStyleBackColor = false;
            this.btnStepDecr.Click += new System.EventHandler(this.btnStepDecr_Click);
            // 
            // btnStepIncr
            // 
            this.btnStepIncr.BackColor = System.Drawing.Color.White;
            this.btnStepIncr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepIncr.Location = new System.Drawing.Point(622, 20);
            this.btnStepIncr.Name = "btnStepIncr";
            this.btnStepIncr.Size = new System.Drawing.Size(26, 34);
            this.btnStepIncr.TabIndex = 17;
            this.btnStepIncr.Text = ">";
            this.btnStepIncr.UseVisualStyleBackColor = false;
            this.btnStepIncr.Click += new System.EventHandler(this.btnStepIncr_Click);
            // 
            // panelConfig
            // 
            this.panelConfig.BackColor = System.Drawing.Color.Transparent;
            this.panelConfig.Controls.Add(this.panelFooter);
            this.panelConfig.Controls.Add(this.panelToolbar);
            this.panelConfig.Controls.Add(this.panelUserControl);
            this.panelConfig.Controls.Add(this.panelPicConfig);
            this.panelConfig.Location = new System.Drawing.Point(0, 75);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(1366, 693);
            this.panelConfig.TabIndex = 59;
            this.panelConfig.Paint += new System.Windows.Forms.PaintEventHandler(this.panelConfig_Paint);
            // 
            // panelPicConfig
            // 
            this.panelPicConfig.Location = new System.Drawing.Point(0, 0);
            this.panelPicConfig.Name = "panelPicConfig";
            this.panelPicConfig.Size = new System.Drawing.Size(1366, 693);
            this.panelPicConfig.TabIndex = 34;
            // 
            // cycleTimer
            // 
            this.cycleTimer.Interval = 1000;
            this.cycleTimer.Tick += new System.EventHandler(this.cycleTimer_Tick);
            // 
            // rxtxTimerHome
            // 
            this.rxtxTimerHome.Interval = 50;
            this.rxtxTimerHome.Tick += new System.EventHandler(this.rxtxTimerHome_Tick);
            // 
            // rounded_Button2
            // 
            this.rounded_Button2.BackColor = System.Drawing.Color.Transparent;
            this.rounded_Button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rounded_Button2.BackgroundImage")));
            this.rounded_Button2.CornerRadius = 10;
            this.rounded_Button2.EndColor = System.Drawing.Color.Transparent;
            this.rounded_Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounded_Button2.HoverEndColor = System.Drawing.Color.Transparent;
            this.rounded_Button2.HoverStartColor = System.Drawing.Color.Transparent;
            this.rounded_Button2.Location = new System.Drawing.Point(1323, 38);
            this.rounded_Button2.Margin = new System.Windows.Forms.Padding(4);
            this.rounded_Button2.Name = "rounded_Button2";
            this.rounded_Button2.Size = new System.Drawing.Size(30, 30);
            this.rounded_Button2.StartColor = System.Drawing.Color.Transparent;
            this.rounded_Button2.TabIndex = 58;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CornerRadius = 10;
            this.btnClose.EndColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.HoverEndColor = System.Drawing.Color.Red;
            this.btnClose.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(1323, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.StartColor = System.Drawing.Color.Red;
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_TimeElapsedDisable
            // 
            this.btn_TimeElapsedDisable.BackColor = System.Drawing.Color.Transparent;
            this.btn_TimeElapsedDisable.CornerRadius = 25;
            this.btn_TimeElapsedDisable.EndColor = System.Drawing.Color.White;
            this.btn_TimeElapsedDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimeElapsedDisable.HoverEndColor = System.Drawing.Color.Green;
            this.btn_TimeElapsedDisable.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_TimeElapsedDisable.Location = new System.Drawing.Point(905, 62);
            this.btn_TimeElapsedDisable.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TimeElapsedDisable.Name = "btn_TimeElapsedDisable";
            this.btn_TimeElapsedDisable.Size = new System.Drawing.Size(70, 34);
            this.btn_TimeElapsedDisable.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_TimeElapsedDisable.TabIndex = 46;
            this.btn_TimeElapsedDisable.Text = "Disable";
            this.btn_TimeElapsedDisable.Click += new System.EventHandler(this.btnTimeElapsedDisable_Click);
            // 
            // btn_Manual
            // 
            this.btn_Manual.BackColor = System.Drawing.Color.Transparent;
            this.btn_Manual.CornerRadius = 25;
            this.btn_Manual.EndColor = System.Drawing.Color.White;
            this.btn_Manual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Manual.HoverEndColor = System.Drawing.Color.Green;
            this.btn_Manual.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_Manual.Location = new System.Drawing.Point(905, 20);
            this.btn_Manual.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Manual.Name = "btn_Manual";
            this.btn_Manual.Size = new System.Drawing.Size(70, 34);
            this.btn_Manual.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Manual.TabIndex = 42;
            this.btn_Manual.Text = "Manual";
            this.btn_Manual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btn_TimeElapsedEnable
            // 
            this.btn_TimeElapsedEnable.BackColor = System.Drawing.Color.Transparent;
            this.btn_TimeElapsedEnable.CornerRadius = 25;
            this.btn_TimeElapsedEnable.EndColor = System.Drawing.Color.White;
            this.btn_TimeElapsedEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimeElapsedEnable.HoverEndColor = System.Drawing.Color.Red;
            this.btn_TimeElapsedEnable.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_TimeElapsedEnable.Location = new System.Drawing.Point(831, 62);
            this.btn_TimeElapsedEnable.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TimeElapsedEnable.Name = "btn_TimeElapsedEnable";
            this.btn_TimeElapsedEnable.Size = new System.Drawing.Size(70, 34);
            this.btn_TimeElapsedEnable.StartColor = System.Drawing.Color.Red;
            this.btn_TimeElapsedEnable.TabIndex = 45;
            this.btn_TimeElapsedEnable.Text = "Enable";
            this.btn_TimeElapsedEnable.Click += new System.EventHandler(this.btnTimeElapsedEnable_Click);
            // 
            // btn_Scanner
            // 
            this.btn_Scanner.BackColor = System.Drawing.Color.Transparent;
            this.btn_Scanner.CornerRadius = 25;
            this.btn_Scanner.EndColor = System.Drawing.Color.White;
            this.btn_Scanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Scanner.HoverEndColor = System.Drawing.Color.Red;
            this.btn_Scanner.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_Scanner.Location = new System.Drawing.Point(831, 20);
            this.btn_Scanner.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Scanner.Name = "btn_Scanner";
            this.btn_Scanner.Size = new System.Drawing.Size(70, 34);
            this.btn_Scanner.StartColor = System.Drawing.Color.Red;
            this.btn_Scanner.TabIndex = 41;
            this.btn_Scanner.Text = "Scanner";
            this.btn_Scanner.Click += new System.EventHandler(this.btnScanner_Click);
            // 
            // btn_CyDisable
            // 
            this.btn_CyDisable.BackColor = System.Drawing.Color.Transparent;
            this.btn_CyDisable.CornerRadius = 25;
            this.btn_CyDisable.EndColor = System.Drawing.Color.White;
            this.btn_CyDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CyDisable.HoverEndColor = System.Drawing.Color.Green;
            this.btn_CyDisable.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_CyDisable.Location = new System.Drawing.Point(582, 62);
            this.btn_CyDisable.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CyDisable.Name = "btn_CyDisable";
            this.btn_CyDisable.Size = new System.Drawing.Size(70, 34);
            this.btn_CyDisable.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_CyDisable.TabIndex = 40;
            this.btn_CyDisable.Text = "Disable";
            this.btn_CyDisable.Click += new System.EventHandler(this.btnCyDisable_Click);
            // 
            // btn_CyEnable
            // 
            this.btn_CyEnable.BackColor = System.Drawing.Color.Transparent;
            this.btn_CyEnable.CornerRadius = 25;
            this.btn_CyEnable.EndColor = System.Drawing.Color.White;
            this.btn_CyEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CyEnable.HoverEndColor = System.Drawing.Color.Red;
            this.btn_CyEnable.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_CyEnable.Location = new System.Drawing.Point(508, 62);
            this.btn_CyEnable.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CyEnable.Name = "btn_CyEnable";
            this.btn_CyEnable.Size = new System.Drawing.Size(70, 34);
            this.btn_CyEnable.StartColor = System.Drawing.Color.Red;
            this.btn_CyEnable.TabIndex = 39;
            this.btn_CyEnable.Text = "Enable";
            this.btn_CyEnable.Click += new System.EventHandler(this.btnCyEnable_Click);
            // 
            // btn_WarOff
            // 
            this.btn_WarOff.BackColor = System.Drawing.Color.Transparent;
            this.btn_WarOff.CornerRadius = 25;
            this.btn_WarOff.EndColor = System.Drawing.Color.White;
            this.btn_WarOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_WarOff.HoverEndColor = System.Drawing.Color.Green;
            this.btn_WarOff.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_WarOff.Location = new System.Drawing.Point(258, 61);
            this.btn_WarOff.Margin = new System.Windows.Forms.Padding(4);
            this.btn_WarOff.Name = "btn_WarOff";
            this.btn_WarOff.Size = new System.Drawing.Size(70, 34);
            this.btn_WarOff.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_WarOff.TabIndex = 38;
            this.btn_WarOff.Text = "OFF";
            this.btn_WarOff.Click += new System.EventHandler(this.btnWarningOff_OnClick);
            // 
            // lblCycleTime
            // 
            this.lblCycleTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCycleTime.CornerRadius = 25;
            this.lblCycleTime.EndColor = System.Drawing.Color.White;
            this.lblCycleTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycleTime.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblCycleTime.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCycleTime.Location = new System.Drawing.Point(997, 62);
            this.lblCycleTime.Margin = new System.Windows.Forms.Padding(4);
            this.lblCycleTime.Name = "lblCycleTime";
            this.lblCycleTime.Size = new System.Drawing.Size(140, 34);
            this.lblCycleTime.StartColor = System.Drawing.Color.Yellow;
            this.lblCycleTime.TabIndex = 36;
            this.lblCycleTime.Text = "Cycle Time";
            // 
            // btn_WarOn
            // 
            this.btn_WarOn.BackColor = System.Drawing.Color.Transparent;
            this.btn_WarOn.CornerRadius = 25;
            this.btn_WarOn.EndColor = System.Drawing.Color.White;
            this.btn_WarOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_WarOn.HoverEndColor = System.Drawing.Color.Red;
            this.btn_WarOn.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_WarOn.Location = new System.Drawing.Point(180, 62);
            this.btn_WarOn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_WarOn.Name = "btn_WarOn";
            this.btn_WarOn.Size = new System.Drawing.Size(70, 34);
            this.btn_WarOn.StartColor = System.Drawing.Color.Red;
            this.btn_WarOn.TabIndex = 37;
            this.btn_WarOn.Text = "ON";
            this.btn_WarOn.Click += new System.EventHandler(this.btnWarning_OnClick);
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.CornerRadius = 25;
            this.lblCount.EndColor = System.Drawing.Color.White;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblCount.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCount.Location = new System.Drawing.Point(997, 20);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(140, 34);
            this.lblCount.StartColor = System.Drawing.Color.Yellow;
            this.lblCount.TabIndex = 35;
            this.lblCount.Text = "Count";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeElapsed.CornerRadius = 25;
            this.lblTimeElapsed.EndColor = System.Drawing.Color.White;
            this.lblTimeElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeElapsed.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblTimeElapsed.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTimeElapsed.Location = new System.Drawing.Point(675, 62);
            this.lblTimeElapsed.Margin = new System.Windows.Forms.Padding(4);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(140, 34);
            this.lblTimeElapsed.StartColor = System.Drawing.Color.Yellow;
            this.lblTimeElapsed.TabIndex = 34;
            this.lblTimeElapsed.Text = "Time Elapsed";
            // 
            // lblDeskSelection
            // 
            this.lblDeskSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblDeskSelection.CornerRadius = 25;
            this.lblDeskSelection.EndColor = System.Drawing.Color.White;
            this.lblDeskSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeskSelection.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblDeskSelection.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDeskSelection.Location = new System.Drawing.Point(675, 20);
            this.lblDeskSelection.Margin = new System.Windows.Forms.Padding(4);
            this.lblDeskSelection.Name = "lblDeskSelection";
            this.lblDeskSelection.Size = new System.Drawing.Size(140, 34);
            this.lblDeskSelection.StartColor = System.Drawing.Color.Yellow;
            this.lblDeskSelection.TabIndex = 33;
            this.lblDeskSelection.Text = "Desk Selection";
            // 
            // rounded_Button5
            // 
            this.rounded_Button5.BackColor = System.Drawing.Color.Transparent;
            this.rounded_Button5.CornerRadius = 25;
            this.rounded_Button5.EndColor = System.Drawing.Color.White;
            this.rounded_Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounded_Button5.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.rounded_Button5.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rounded_Button5.Location = new System.Drawing.Point(352, 62);
            this.rounded_Button5.Margin = new System.Windows.Forms.Padding(4);
            this.rounded_Button5.Name = "rounded_Button5";
            this.rounded_Button5.Size = new System.Drawing.Size(140, 34);
            this.rounded_Button5.StartColor = System.Drawing.Color.Yellow;
            this.rounded_Button5.TabIndex = 32;
            this.rounded_Button5.Text = "Cy Movement";
            // 
            // lblProcessStep
            // 
            this.lblProcessStep.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessStep.CornerRadius = 25;
            this.lblProcessStep.EndColor = System.Drawing.Color.White;
            this.lblProcessStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessStep.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lblProcessStep.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblProcessStep.Location = new System.Drawing.Point(352, 20);
            this.lblProcessStep.Margin = new System.Windows.Forms.Padding(4);
            this.lblProcessStep.Name = "lblProcessStep";
            this.lblProcessStep.Size = new System.Drawing.Size(140, 34);
            this.lblProcessStep.StartColor = System.Drawing.Color.Yellow;
            this.lblProcessStep.TabIndex = 31;
            this.lblProcessStep.Text = "Process Step";
            // 
            // lbWarningAlarm
            // 
            this.lbWarningAlarm.BackColor = System.Drawing.Color.Transparent;
            this.lbWarningAlarm.CornerRadius = 25;
            this.lbWarningAlarm.EndColor = System.Drawing.Color.White;
            this.lbWarningAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWarningAlarm.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lbWarningAlarm.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbWarningAlarm.Location = new System.Drawing.Point(21, 62);
            this.lbWarningAlarm.Margin = new System.Windows.Forms.Padding(4);
            this.lbWarningAlarm.Name = "lbWarningAlarm";
            this.lbWarningAlarm.Size = new System.Drawing.Size(140, 34);
            this.lbWarningAlarm.StartColor = System.Drawing.Color.Yellow;
            this.lbWarningAlarm.TabIndex = 30;
            this.lbWarningAlarm.Text = "Warning Alarm";
            // 
            // lblSelectDesk
            // 
            this.lblSelectDesk.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectDesk.CornerRadius = 25;
            this.lblSelectDesk.EndColor = System.Drawing.Color.White;
            this.lblSelectDesk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDesk.HoverEndColor = System.Drawing.Color.White;
            this.lblSelectDesk.HoverStartColor = System.Drawing.Color.Yellow;
            this.lblSelectDesk.Location = new System.Drawing.Point(21, 20);
            this.lblSelectDesk.Margin = new System.Windows.Forms.Padding(4);
            this.lblSelectDesk.Name = "lblSelectDesk";
            this.lblSelectDesk.Size = new System.Drawing.Size(140, 34);
            this.lblSelectDesk.StartColor = System.Drawing.Color.Yellow;
            this.lblSelectDesk.TabIndex = 0;
            this.lblSelectDesk.Text = "Select Desk";
            // 
            // GTI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1346, 745);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GTI";
            this.Text = "GTI";
            this.Load += new System.EventHandler(this.GTI_Load);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.panelConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPause;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer Date_Timer;
        private Guna.UI2.WinForms.Guna2GradientPanel panelHeader;
        private Rounded_Button rounded_Button2;
        private Rounded_Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnStart;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private System.Windows.Forms.Panel panelUserControl;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.ComboBox selectDesk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Rounded_Button btn_TimeElapsedDisable;
        private Rounded_Button btn_Manual;
        private Rounded_Button btn_TimeElapsedEnable;
        private Rounded_Button btn_Scanner;
        private Rounded_Button btn_CyDisable;
        private Rounded_Button btn_CyEnable;
        private Rounded_Button btn_WarOff;
        private Rounded_Button lblCycleTime;
        private Rounded_Button btn_WarOn;
        private Rounded_Button lblCount;
        private Rounded_Button lblTimeElapsed;
        private Rounded_Button lblDeskSelection;
        private Rounded_Button rounded_Button5;
        private Rounded_Button lblProcessStep;
        private Rounded_Button lbWarningAlarm;
        private Rounded_Button lblSelectDesk;
        private System.Windows.Forms.RichTextBox lblActualTargetTime;
        private System.Windows.Forms.RichTextBox lblTargetCycleTime;
        private System.Windows.Forms.RichTextBox lblActualCount;
        private System.Windows.Forms.RichTextBox lblTargetCount;
        private System.Windows.Forms.RichTextBox lblStepIndicator;
        private System.Windows.Forms.Button btnStepDecr;
        private System.Windows.Forms.Button btnStepIncr;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelPicConfig;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2GradientButton btnDate;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2GradientButton btnShift;
        private Guna.UI2.WinForms.Guna2GradientButton btnTime;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Windows.Forms.Panel panelComIndicator;
        private System.Windows.Forms.Timer rxtxTimerHome;
        private System.Windows.Forms.Label labelInstruction;
    }
}

