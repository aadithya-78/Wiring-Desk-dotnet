namespace Wiring_Desk
{
    partial class AllConImage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rounded_Button1 = new Wiring_Desk.Rounded_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.relayTimer = new System.Windows.Forms.Timer(this.components);
            this.rxtxTimer = new System.Windows.Forms.Timer(this.components);
            this.borderTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1346, 336);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // rounded_Button1
            // 
            this.rounded_Button1.BackColor = System.Drawing.Color.Transparent;
            this.rounded_Button1.CornerRadius = 20;
            this.rounded_Button1.EndColor = System.Drawing.Color.Yellow;
            this.rounded_Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounded_Button1.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.rounded_Button1.HoverStartColor = System.Drawing.Color.Yellow;
            this.rounded_Button1.Location = new System.Drawing.Point(483, 6);
            this.rounded_Button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rounded_Button1.Name = "rounded_Button1";
            this.rounded_Button1.Size = new System.Drawing.Size(400, 40);
            this.rounded_Button1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(190)))), ((int)(((byte)(100)))));
            this.rounded_Button1.TabIndex = 1;
            this.rounded_Button1.Text = "Modules to be installed";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(10, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 417);
            this.panel1.TabIndex = 3;
            // 
            // relayTimer
            // 
            this.relayTimer.Interval = 50;
            this.relayTimer.Tick += new System.EventHandler(this.relayTimer_Tick);
            // 
            // rxtxTimer
            // 
            this.rxtxTimer.Interval = 300;
            this.rxtxTimer.Tick += new System.EventHandler(this.rxtxTimer_Tick);
            // 
            // borderTimer
            // 
            this.borderTimer.Interval = 300;
            this.borderTimer.Tick += new System.EventHandler(this.borderTimer_Tick);
            // 
            // AllConImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rounded_Button1);
            this.Name = "AllConImage";
            this.Size = new System.Drawing.Size(1366, 331);
            this.Load += new System.EventHandler(this.AllConImage_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Rounded_Button rounded_Button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer relayTimer;
        private System.Windows.Forms.Timer rxtxTimer;
        private System.Windows.Forms.Timer borderTimer;
    }
}
