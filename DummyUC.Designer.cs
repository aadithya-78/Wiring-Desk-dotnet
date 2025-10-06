namespace Wiring_Desk
{
    partial class DummyUC
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
            this.rounded_Button1 = new Wiring_Desk.Rounded_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // rounded_Button1
            // 
            this.rounded_Button1.BackColor = System.Drawing.Color.Transparent;
            this.rounded_Button1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rounded_Button1.CornerRadius = 20;
            this.rounded_Button1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rounded_Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounded_Button1.HoverEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.rounded_Button1.HoverStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rounded_Button1.Location = new System.Drawing.Point(483, 6);
            this.rounded_Button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rounded_Button1.Name = "rounded_Button1";
            this.rounded_Button1.Size = new System.Drawing.Size(400, 40);
            this.rounded_Button1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.rounded_Button1.TabIndex = 1;
            this.rounded_Button1.Text = "Modules to be installed";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(10, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 417);
            this.panel1.TabIndex = 2;
            // 
            // DummyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rounded_Button1);
            this.Name = "DummyUC";
            this.Size = new System.Drawing.Size(1366, 493);
            this.ResumeLayout(false);

        }

        #endregion

        private Rounded_Button rounded_Button1;
        private System.Windows.Forms.Panel panel1;
    }
}
