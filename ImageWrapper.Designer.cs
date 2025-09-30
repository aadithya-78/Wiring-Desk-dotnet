namespace Wiring_Desk
{
    partial class ImageWrapper
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbBin = new System.Windows.Forms.PictureBox();
            this.pbCon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCon)).BeginInit();
            this.SuspendLayout();
            // 
            // rounded_Button1
            // 
            this.rounded_Button1.BackColor = System.Drawing.Color.Transparent;
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
            this.rounded_Button1.TabIndex = 0;
            this.rounded_Button1.Text = "Modules to be installed";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pbBin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbCon, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 52);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1346, 441);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pbBin
            // 
            this.pbBin.Location = new System.Drawing.Point(4, 4);
            this.pbBin.Name = "pbBin";
            this.pbBin.Size = new System.Drawing.Size(660, 410);
            this.pbBin.TabIndex = 0;
            this.pbBin.TabStop = false;
            this.pbBin.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbCon
            // 
            this.pbCon.Location = new System.Drawing.Point(676, 4);
            this.pbCon.Name = "pbCon";
            this.pbCon.Size = new System.Drawing.Size(660, 410);
            this.pbCon.TabIndex = 1;
            this.pbCon.TabStop = false;
            // 
            // ImageWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rounded_Button1);
            this.Name = "ImageWrapper";
            this.Size = new System.Drawing.Size(1366, 493);
            this.Load += new System.EventHandler(this.ImageWrapper_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Rounded_Button rounded_Button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbBin;
        private System.Windows.Forms.PictureBox pbCon;
    }
}
