namespace Wiring_Desk
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.tbUsername = new System.Windows.Forms.RichTextBox();
            this.tbPassword = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoginPage = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(326, 415);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(10);
            this.tbUsername.Multiline = false;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(144, 28);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.Text = "";
            this.tbUsername.Enter += new System.EventHandler(this.tbUsername_Enter);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(326, 464);
            this.tbPassword.Multiline = false;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(144, 28);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Text = "";
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.Enter += new System.EventHandler(this.tbPassword_Enter);
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(193, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(193, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btnLoginPage
            // 
            this.btnLoginPage.BorderColor = System.Drawing.Color.Transparent;
            this.btnLoginPage.BorderThickness = 2;
            this.btnLoginPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoginPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoginPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoginPage.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoginPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoginPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(190)))), ((int)(((byte)(219)))));
            this.btnLoginPage.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(219)))));
            this.btnLoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginPage.ForeColor = System.Drawing.Color.White;
            this.btnLoginPage.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnLoginPage.Location = new System.Drawing.Point(326, 513);
            this.btnLoginPage.Name = "btnLoginPage";
            this.btnLoginPage.Size = new System.Drawing.Size(144, 28);
            this.btnLoginPage.TabIndex = 61;
            this.btnLoginPage.Text = "Login";
            this.btnLoginPage.Click += new System.EventHandler(this.btnLoginPage_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnLoginPage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loginForm";
            this.Text = "loginForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbUsername;
        private System.Windows.Forms.RichTextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientButton btnLoginPage;
    }
}