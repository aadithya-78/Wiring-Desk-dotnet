namespace Wiring_Desk
{
    partial class Settings
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
            this.btnPlanning = new Wiring_Desk.Rounded_Button();
            this.btnConfiguration = new Wiring_Desk.Rounded_Button();
            this.btnPictureConfiguration = new Wiring_Desk.Rounded_Button();
            this.btnClose = new Wiring_Desk.Rounded_Button();
            this.SuspendLayout();
            // 
            // btnPlanning
            // 
            this.btnPlanning.BackColor = System.Drawing.Color.Transparent;
            this.btnPlanning.CornerRadius = 20;
            this.btnPlanning.EndColor = System.Drawing.Color.Yellow;
            this.btnPlanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanning.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnPlanning.HoverStartColor = System.Drawing.Color.Yellow;
            this.btnPlanning.Location = new System.Drawing.Point(468, 29);
            this.btnPlanning.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPlanning.Name = "btnPlanning";
            this.btnPlanning.Size = new System.Drawing.Size(412, 50);
            this.btnPlanning.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnPlanning.TabIndex = 33;
            this.btnPlanning.Text = "Planning";
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.BackColor = System.Drawing.Color.Transparent;
            this.btnConfiguration.CornerRadius = 20;
            this.btnConfiguration.EndColor = System.Drawing.Color.Yellow;
            this.btnConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguration.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnConfiguration.HoverStartColor = System.Drawing.Color.Yellow;
            this.btnConfiguration.Location = new System.Drawing.Point(468, 145);
            this.btnConfiguration.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(412, 50);
            this.btnConfiguration.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnConfiguration.TabIndex = 34;
            this.btnConfiguration.Text = "Configuration";
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // btnPictureConfiguration
            // 
            this.btnPictureConfiguration.BackColor = System.Drawing.Color.Transparent;
            this.btnPictureConfiguration.CornerRadius = 20;
            this.btnPictureConfiguration.EndColor = System.Drawing.Color.Yellow;
            this.btnPictureConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPictureConfiguration.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnPictureConfiguration.HoverStartColor = System.Drawing.Color.Yellow;
            this.btnPictureConfiguration.Location = new System.Drawing.Point(468, 261);
            this.btnPictureConfiguration.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPictureConfiguration.Name = "btnPictureConfiguration";
            this.btnPictureConfiguration.Size = new System.Drawing.Size(412, 50);
            this.btnPictureConfiguration.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnPictureConfiguration.TabIndex = 35;
            this.btnPictureConfiguration.Text = "Picture Configuration";
            this.btnPictureConfiguration.Click += new System.EventHandler(this.btnPictureConfiguration_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CornerRadius = 20;
            this.btnClose.EndColor = System.Drawing.Color.Yellow;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnClose.HoverStartColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(468, 377);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(412, 50);
            this.btnClose.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(60)))));
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPictureConfiguration);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.btnPlanning);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1346, 493);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Rounded_Button btnPlanning;
        private Rounded_Button btnConfiguration;
        private Rounded_Button btnPictureConfiguration;
        private Rounded_Button btnClose;
    }
}
