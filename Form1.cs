using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class GTI : Form
    {
        public GTI()

        {
            InitializeComponent();
            LoadProcessDesk();
            LoadConfig();
           
            DateTime today = DateTime.Today; 
            btnDate.Text = today.ToString();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            // this.TopMost = true;

        }

        private void GTI_Load(object sender, EventArgs e)
        {
            LoadUI();
        }

        private void Date_Timer_Tick(object sender, EventArgs e)
        {
            btnLogin.Text = DateTime.Now.ToLongTimeString();
        }

        private void selectDesk_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void selectDesk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        /*-----------------------------------------------------------------LOAD------------------------------------------------------------------*/

        private void LoadConfig()
        {
            try
            {
                ConfigReader.LoadConfig(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV: " + ex.Message);
            }
        }

        private void LoadUI()
        {
            panelUserControl.Controls.Clear();
            ImageWrapper image_wrapper = new ImageWrapper();
            image_wrapper.Dock = DockStyle.Fill;
            panelUserControl.Controls.Add(image_wrapper);

            lblTargetCount.SelectionAlignment = HorizontalAlignment.Center;
            lblActualCount.SelectionAlignment = HorizontalAlignment.Center;

            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            string title = ConfigReader.ConfigCSV[16][10];
            lblTitle.Text = title;

        }


        private void LoadProcessDesk()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "process");

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("CSV folder not found: " + folderPath);
                return;
            }

            string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");

            selectDesk.Items.Clear();

            selectDesk.DrawItem += (s, eee) =>
            {
                if (eee.Index < 0) return;
                eee.DrawBackground();
                string text = selectDesk.Items[eee.Index].ToString();
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    eee.Graphics.DrawString(text, eee.Font, brush, eee.Bounds);
                }
                eee.DrawFocusRectangle();
            };


            foreach (string file in csvFiles)
            {
                selectDesk.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

     

/*---------------------------------------------------------------BUTTONS------------------------------------------------------------------*/


        private void btnWarning_OnClick(object sender, EventArgs e)
        {
            btn_WarOn.HoverEndColor = Color.Green;
            btn_WarOff.HoverEndColor = Color.Red;
            btn_WarOn.StartColor = Color.Green;
            btn_WarOff.StartColor = Color.Red;
            
        }

        private void btnWarningOff_OnClick(object sender, EventArgs e)
        {
            btn_WarOn.HoverEndColor = Color.Red;
            btn_WarOff.HoverEndColor = Color.Green;
            btn_WarOn.StartColor = Color.Red;
            btn_WarOff.StartColor = Color.Green;
           
        }

        private void btnStepIncr_Click(object sender, EventArgs e)
        {

        }

        private void btnStepDecr_Click(object sender, EventArgs e)
        {

        }

        private void btnCyEnable_Click(object sender, EventArgs e)
        {
            btn_CyEnable.HoverEndColor = Color.Green;
            btn_CyDisable.HoverEndColor = Color.Red;
            btn_CyEnable.StartColor = Color.Green;
            btn_CyDisable.StartColor = Color.Red;
        }

        private void btnCyDisable_Click(object sender, EventArgs e)
        {
            btn_CyEnable.HoverEndColor = Color.Red;
            btn_CyDisable.HoverEndColor = Color.Green;
            btn_CyEnable.StartColor = Color.Red;
            btn_CyDisable.StartColor = Color.Green;
        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            btn_Scanner.HoverEndColor = Color.Green;
            btn_Manual.HoverEndColor = Color.Red;
            btn_Scanner.StartColor = Color.Green;
            btn_Manual.StartColor = Color.Red;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            btn_Scanner.HoverEndColor = Color.Red;
            btn_Manual.HoverEndColor = Color.Green;
            btn_Scanner.StartColor = Color.Red;
            btn_Manual.StartColor = Color.Green;
        }

        private void btnTimeElapsedEnable_Click(object sender, EventArgs e)
        {
            btn_TimeElapsedEnable.HoverEndColor = Color.Green;
            btn_TimeElapsedDisable.HoverEndColor = Color.Red;
            btn_TimeElapsedEnable.StartColor = Color.Green;
            btn_TimeElapsedDisable.StartColor = Color.Red;
        }

        private void btnTimeElapsedDisable_Click(object sender, EventArgs e)
        {
            btn_TimeElapsedEnable.HoverEndColor = Color.Red;
            btn_TimeElapsedDisable.HoverEndColor = Color.Green;
            btn_TimeElapsedEnable.StartColor = Color.Red;
            btn_TimeElapsedDisable.StartColor = Color.Green;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }

       private void btnSettings_Click(object sender, EventArgs e)
        {
            panelUserControl.Controls.Clear();
            Settings settings = new Settings(panelUserControl, panelConfig, panelToolbar, panelFooter, panelPicConfig);
            settings.Dock = DockStyle.Fill; 
            panelUserControl.Controls.Add(settings);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelConfig_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFooter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

