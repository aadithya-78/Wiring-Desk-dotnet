namespace Wiring_Desk
{
    partial class DeleteUserForm
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
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.du_cmbUsername = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderThickness = 2;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(80)))), ((int)(((byte)(40)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientButton1.Location = new System.Drawing.Point(207, 209);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(145, 39);
            this.guna2GradientButton1.TabIndex = 72;
            this.guna2GradientButton1.Text = "Close";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(131, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 30);
            this.label4.TabIndex = 71;
            this.label4.Text = "Delete User";
            // 
            // btnCreate
            // 
            this.btnCreate.BorderColor = System.Drawing.Color.Transparent;
            this.btnCreate.BorderThickness = 2;
            this.btnCreate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(190)))), ((int)(((byte)(219)))));
            this.btnCreate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(219)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCreate.Location = new System.Drawing.Point(17, 209);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(145, 39);
            this.btnCreate.TabIndex = 70;
            this.btnCreate.Text = "Delete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 30);
            this.label1.TabIndex = 64;
            this.label1.Text = "Username";
            // 
            // du_cmbUsername
            // 
            this.du_cmbUsername.BackColor = System.Drawing.Color.White;
            this.du_cmbUsername.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.du_cmbUsername.DropDownHeight = 200;
            this.du_cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.du_cmbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.du_cmbUsername.FormattingEnabled = true;
            this.du_cmbUsername.IntegralHeight = false;
            this.du_cmbUsername.ItemHeight = 22;
            this.du_cmbUsername.Location = new System.Drawing.Point(207, 101);
            this.du_cmbUsername.Name = "du_cmbUsername";
            this.du_cmbUsername.Size = new System.Drawing.Size(148, 28);
            this.du_cmbUsername.TabIndex = 73;
            this.du_cmbUsername.SelectedIndexChanged += new System.EventHandler(this.du_cmbUsername_SelectedIndexChanged);
            // 
            // DeleteUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.du_cmbUsername);
            this.Controls.Add(this.guna2GradientButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label1);
            this.Name = "DeleteUserForm";
            this.Text = "DeleteUser";
            this.Load += new System.EventHandler(this.DeleteUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientButton btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox du_cmbUsername;
    }
}