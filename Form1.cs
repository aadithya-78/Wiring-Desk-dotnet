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
        private int targetCycleTimeInSeconds = 0;
        private int actualCycleTimeInSeconds = 0;
        private ImageWrapper imgWrapper; // accessible to all buttons

        public GTI()

        {
            InitializeComponent();
            LoadProcessDesk();
            LoadConfig();
           
            DateTime today = DateTime.Today; 
            btnDate.Text = today.ToString();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            Date_Timer.Start();

            InitializeContextMenu();

            guna2Button1.MouseUp += Guna2Button1_MouseUp;

        }

        private void GTI_Load(object sender, EventArgs e)
        {
            LoadUI();
           
        }

        private ContextMenuStrip buttonContextMenu;

        private void InitializeContextMenu()
        {
            buttonContextMenu = new ContextMenuStrip { ShowImageMargin = false };
            buttonContextMenu.Items.Add("Create User", null, (s, e) => CreateUser());
            buttonContextMenu.Items.Add("Update Password", null, (s, e) => UpdatePassword());
            buttonContextMenu.Items.Add("Delete User", null, (s, e) => DeleteUser());
            buttonContextMenu.Items.Add("Close", null, (s, e) => buttonContextMenu.Close()); 
        }

        private void CreateUser()
        {
            using (CreateUserForm form = new CreateUserForm())
            {
                form.ShowDialog(this);  
            }
        }

        private void UpdatePassword()
        {
            using (UpdatePasswordForm form = new UpdatePasswordForm())
            {
                form.ShowDialog(this);
            }
        }

        private void DeleteUser()
        {
            using (DeleteUserForm form = new DeleteUserForm())
            {
                form.ShowDialog(this);
            }
        }

        private void Date_Timer_Tick(object sender, EventArgs e)
        {
            if (btnDate.InvokeRequired)
            {
                btnDate.Invoke((MethodInvoker)(() => btnDate.Text = DateTime.Now.ToString("dd-MM-yy")));
                btnTime.Invoke((MethodInvoker)(() => btnTime.Text = DateTime.Now.ToLongTimeString()));
            }
            else
            {
                btnDate.Text = DateTime.Now.ToString("dd-MM-yy");  
                btnTime.Text = DateTime.Now.ToLongTimeString();
            }
        }

        private void selectDesk_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (selectDesk.SelectedItem != null)
            {
                string selectedFile = selectDesk.SelectedItem.ToString();
                ProcessReader.LoadProcess(selectedFile);
                panelUserControl.Controls.Clear();
                AllConImage allCon = new AllConImage();
                allCon.SetParentForm(this);
                allCon.Dock = DockStyle.Fill;
                panelUserControl.Controls.Add(allCon);
                allCon.LoadImagesFromProcess(selectedFile);

                try
                {
                    if (ConfigReader.ConfigCSV.Count > 3)
                    {
                        var row = ConfigReader.ConfigCSV[3]; // 4th row
                        if (row != null && row.Count > 3)
                        {
                            if (!int.TryParse(row[2], out int minutes))
                                minutes = 0;
                            if (!int.TryParse(row[3], out int seconds))
                                seconds = 0;
                            lblTargetCycleTime.Text = $"{minutes:D2}:{seconds:D2}";
                            targetCycleTimeInSeconds = minutes * 60 + seconds;

                            actualCycleTimeInSeconds = 0; 
                            lblActualTargetTime.ForeColor = Color.Black;
                            cycleTimer.Start();
                        }
                        else
                        {
                            lblTargetCycleTime.Text = "00:00";
                            targetCycleTimeInSeconds = 0;
                            MessageBox.Show("Target cycle time column missing in ConfigCSV.");
                        }
                    }
                    else
                    {
                        lblTargetCycleTime.Text = "00:00";
                        targetCycleTimeInSeconds = 0;
                        MessageBox.Show("Target cycle time row missing in ConfigCSV.");
                    }
                }
                catch (Exception ex)
                {
                    lblTargetCycleTime.Text = "00:00";
                    targetCycleTimeInSeconds = 0;
                    MessageBox.Show("Error reading target cycle time: " + ex.Message);
                }
            }
        }


        private void cycleTimer_Tick(object sender, EventArgs e)
        {
        
            actualCycleTimeInSeconds++;
            int minutes = actualCycleTimeInSeconds / 60;
            int seconds = actualCycleTimeInSeconds % 60;

            lblActualTargetTime.Text = $"{minutes:D2}:{seconds:D2}";

            if (actualCycleTimeInSeconds >= targetCycleTimeInSeconds)
            {
                lblActualTargetTime.ForeColor = Color.Red;
            }
            else
            {
                lblActualTargetTime.ForeColor = Color.Black; 
            }
        }

        public void ResetSelectDesk()
        {
            selectDesk.SelectedIndexChanged -= selectDesk_SelectedIndexChanged;
            selectDesk.SelectedIndex = -1;
            selectDesk.SelectedIndexChanged += selectDesk_SelectedIndexChanged;
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
            lblTargetCount.SelectionAlignment = HorizontalAlignment.Center;
            lblActualCount.SelectionAlignment = HorizontalAlignment.Center;
            lblActualTargetTime.SelectionAlignment = HorizontalAlignment.Center;
            lblTargetCycleTime.SelectionAlignment = HorizontalAlignment.Center;
            lblStepIndicator.SelectionAlignment = HorizontalAlignment.Center;

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
            if (imgWrapper != null && imgWrapper.CurrentRowIndex < ProcessReader.Process_CSV.Count - 1)
            {
                imgWrapper.CurrentRowIndex++;
                lblStepIndicator.Text = (imgWrapper.CurrentRowIndex - 4).ToString();
            }
        }

        private void btnStepDecr_Click(object sender, EventArgs e)
        {
            if (imgWrapper != null && imgWrapper.CurrentRowIndex > 5)
            {
                imgWrapper.CurrentRowIndex--;
                lblStepIndicator.Text = (imgWrapper.CurrentRowIndex - 4).ToString();
            }
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
            try
            {
                panelUserControl.Controls.Clear();
                string selectedFile = selectDesk.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(selectedFile))
                {
                    MessageBox.Show("Select a desk first.");
                    return;
                }

                ProcessReader.LoadProcess(selectedFile);
                imgWrapper = new ImageWrapper(selectedFile, ProcessReader.Process_CSV);
                imgWrapper.Dock = DockStyle.Fill;
                panelUserControl.Controls.Add(imgWrapper);
                lblStepIndicator.Text = "1"; // first step (6th row)

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a process before starting. " + ex.Message);
            }
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


        private void Guna2Button1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                buttonContextMenu.Show(guna2Button1, e.Location);
            }
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

        private void lblStepIndicator_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

