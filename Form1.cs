using Guna.UI2.AnimatorNS;
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
using System.Web.UI;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class GTI : Form
    {
        private int targetCycleTimeInSeconds = 0;
        private int actualCycleTimeInSeconds = 0;
        private ImageWrapper imgWrapper;
        private int hw_flags = 1;
        private Queue<int> UARTSequence = new Queue<int>();
        private bool startupRunning = false;
        private AllConImage allCon;

        public GTI()

        {
            InitializeComponent();
            LoadProcessDesk();
            LoadConfig();
            SerialInit();
     
            DummyUC dummy = new DummyUC();
            dummy.Dock = DockStyle.Fill;
            panelUserControl.Controls.Add(dummy);

            DateTime today = DateTime.Today; 
            btnDate.Text = today.ToString();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            Date_Timer.Start();

            rxtxTimerHome.Start();
            UARTSequence.Enqueue(2);
            UARTSequence.Enqueue(4);
            UARTSequence.Enqueue(6);
            UARTSequence.Enqueue(3);
            UARTSequence.Enqueue(5);
            UARTSequence.Enqueue(7);
            UARTSequence.Enqueue(2);
            startupRunning = true;

            serialPort1.DataReceived += serialPort1_DataRecieved;
            InitializeContextMenu();
            guna2Button1.MouseUp += Guna2Button1_MouseUp;
        }

        private void GTI_Load(object sender, EventArgs e)
        {
            LoadUI();
           
        }

        async public void Reset()
        {
            actualCycleTimeInSeconds = 0;
            targetCycleTimeInSeconds = 0;
            cycleTimer.Stop();
            lblTargetCycleTime.Text = "";
            btnStepDecr.Enabled = false;
            btnStepIncr.Enabled = false;
            lblStepIndicator.Text = "";

            imgWrapper?.stopTimers();
            rxtxTimerHome.Start();
            await Task.Delay(500); 
            panelUserControl.Controls.Clear();
           
            UARTSequence.Enqueue(2);
            UARTSequence.Enqueue(5);
            UARTSequence.Enqueue(7);
            startupRunning = true;


            if (selectDesk.SelectedItem != null)
            {
                string selectedFile = selectDesk.SelectedItem.ToString();
                ProcessReader.LoadProcess(selectedFile);
                panelUserControl.Controls.Clear();
                allCon = new AllConImage(serialPort1);
                allCon.SetParentForm(this);
                allCon.Dock = DockStyle.Fill;
                panelUserControl.Controls.Add(allCon);
                allCon.LoadImagesFromProcess(selectedFile);
                if (allCon != null) allCon.startTriggered = false; //HW START PUSH BUTTON FLAG
                allCon.StartRequested += HandleStartRequested; //HW START PUSH BUTTON 
                labelInstruction.Text = "PLACE ALL CONNECTOR AND START THE PROGRAM";
                rxtxTimerHome.Stop();
                btnStart.Enabled = true;

                try
                {
                    if (ConfigReader.ConfigCSV.Count > 3)
                    {
                        var row = ConfigReader.ConfigCSV[3];
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
                            lblTargetCycleTime.Text = "";
                            targetCycleTimeInSeconds = 0;
                            MessageBox.Show("Target cycle time column missing in ConfigCSV.");
                        }
                    }
                    else
                    {
                        lblTargetCycleTime.Text = "";
                        targetCycleTimeInSeconds = 0;
                        MessageBox.Show("Target cycle time row missing in ConfigCSV.");
                    }
                }
                catch (Exception ex)
                {
                    lblTargetCycleTime.Text = "";
                    targetCycleTimeInSeconds = 0;
                    MessageBox.Show("Error reading target cycle time: " + ex.Message);
                }
            }
            else
            {
                DummyUC dummy = new DummyUC();
                dummy.Dock = DockStyle.Fill;
                panelUserControl.Controls.Add(dummy);
            }
        }

        private void SerialInit()
        {
                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        string portNumberStr = ConfigReader.ConfigCSV[2][10];
                    if (!int.TryParse(portNumberStr, out int portNumber))
                        {
                            MessageBox.Show("Invalid COM port number in CSV.");
                            return;
                        }

                        serialPort1.PortName = "COM" + portNumber;
                        serialPort1.BaudRate = 19200;
                        serialPort1.Open();
                        serialPort1.RtsEnable = false;
                        serialPort1.DtrEnable = true;
                        serialPort1.DtrEnable = false;
                        panelComIndicator.BackColor = Color.Green;
                }
                    else
                    {
                     panelComIndicator.BackColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening serial port: " + ex.Message);
                }
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
                allCon = new AllConImage(serialPort1);
                allCon.SetParentForm(this);
                allCon.Dock = DockStyle.Fill;
                panelUserControl.Controls.Add(allCon);
                allCon.LoadImagesFromProcess(selectedFile);
                labelInstruction.Text = "PLACE ALL CONNECTOR AND START THE PROGRAM";
                rxtxTimerHome.Stop();
                btnStart.Enabled = true;
                allCon.StartRequested += HandleStartRequested; //HW START PUSH BUTTON 

                try
                {
                    if (ConfigReader.ConfigCSV.Count > 3)
                    {
                        var row = ConfigReader.ConfigCSV[3]; 
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
            btnStepDecr.Enabled = false;
            btnStepIncr.Enabled = false;
            btnStart.Enabled = false;

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

        /*--------------------------------------------------------------HARDWARE------------------------------------------------------------------*/


        private void rxtxTimerHome_Tick(object sender, EventArgs e)
        {
           if (startupRunning && UARTSequence.Count > 0)
            {
                hw_flags = UARTSequence.Dequeue();
            }
            else if (startupRunning && UARTSequence.Count == 0)
            {
                startupRunning = false;
            }

            switch (hw_flags)
            {
                case 1://Heart Beat
                    if (serialPort1 != null && serialPort1.IsOpen)
                    {
                        byte[] packet = { 0x27, 0x04, 0x85, 0x01, 0x00, 0x00, 0x16 };
                        serialPort1.Write(packet, 0, packet.Length);
                    }
                    break;

                case 2: // Yellow Relay On
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x01, 0x01, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                            hw_flags = 1;
                        }
                        break;
                    }
                case 3: // Yellow Relay Off
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x01, 0x00, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                            hw_flags = 1;
                        }
                        break;
                    }

                case 4: // Green Relay On
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x02, 0x01, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                            hw_flags = 1;
                        }
                        break;
                    }
                case 5: // Green relay off
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x02, 0x00, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                            hw_flags = 1;
                        }
                        break;
                    }

                case 6: // Red Relay On
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x01, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                            hw_flags = 1;
                        }
                        break;
                    }
                case 7: // Red Relay Off
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x00, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                            hw_flags = 1;
                        }
                        break;
                    }

                default:
                    if (serialPort1 != null && serialPort1.IsOpen)
                    {
                        byte[] packet = { 0x27, 0x04, 0x85, 0x01, 0x00, 0x00, 0x16 };
                        serialPort1.Write(packet, 0, packet.Length);
                    }
                    break;
            }
        }

        /*---------------------------------------------------------------BUTTONS------------------------------------------------------------------*/


        private void btnWarning_OnClick(object sender, EventArgs e)
        {
            hw_flags = 6;
            if(allCon != null) allCon.UARTSequence.Enqueue(5);
            if (imgWrapper != null) imgWrapper.relay_flag = 1;
            btn_WarOn.HoverEndColor = Color.Green;
            btn_WarOff.HoverEndColor = Color.Red;
            btn_WarOn.StartColor = Color.Green;
            btn_WarOff.StartColor = Color.Red;
        }

        private void btnWarningOff_OnClick(object sender, EventArgs e)
        {
            hw_flags = 7;
            if (allCon != null) allCon.UARTSequence.Enqueue(6);
            if (imgWrapper != null) imgWrapper.relay_flag = 2;
            btn_WarOn.HoverEndColor = Color.Red;
            btn_WarOff.HoverEndColor = Color.Green;
            btn_WarOn.StartColor = Color.Red;
            btn_WarOff.StartColor = Color.Green;
        }

        private void btnStepIncr_Click(object sender, EventArgs e)
        {
            imgWrapper.CurrentRowIndex++;
        }

        private void btnStepDecr_Click(object sender, EventArgs e)
        {
           imgWrapper.CurrentRowIndex--;   
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
            var result = MessageBox.Show(
            "Are you sure you want to reset?",   // message
            "Confirm Reset",                     // title
            MessageBoxButtons.YesNo,             // Yes and No buttons
            MessageBoxIcon.Question               // optional: warning icon
   );
            if (result == DialogResult.Yes)
            {
                Reset();  
            }
        }

        private void ImgWrapper_StepChanged(int stepNumber, string instruction)
        {
            if (lblStepIndicator.InvokeRequired || labelInstruction.InvokeRequired)
            {
                lblStepIndicator.Invoke(new Action(() =>
                {
                    lblStepIndicator.Text = stepNumber.ToString();
                    labelInstruction.Text = instruction;  // update instruction
                }));
            }
            else
            {
                lblStepIndicator.Text = stepNumber.ToString();
                labelInstruction.Text = instruction;
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                panelUserControl.Controls.Clear();
                string selectedFile = selectDesk.SelectedItem.ToString();
                allCon.stopTimers();
                byte[] packet = { 0x27, 0x04, 0x85, 0x01, 0x3A, 0x00, 0x16 };
                serialPort1.Write(packet, 0, packet.Length);

                if (string.IsNullOrWhiteSpace(selectedFile))
                {
                    MessageBox.Show("Select a desk first.");
                    return;
                }

                ProcessReader.LoadProcess(selectedFile);
                imgWrapper = new ImageWrapper(selectedFile, ProcessReader.Process_CSV, serialPort1);
                imgWrapper.StepChanged += ImgWrapper_StepChanged;
                imgWrapper.Dock = DockStyle.Fill;
                panelUserControl.Controls.Add(imgWrapper);
                btnStepDecr.Enabled = true;
                btnStepIncr.Enabled = true;
                lblStepIndicator.Text = "1"; 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a process before starting. " + ex.Message);
            }
        }

        private void HandleStartRequested()
        {
            btnStart_Click(null, EventArgs.Empty);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            panelUserControl.Controls.Clear();
            Settings settings = new Settings(panelUserControl, panelConfig, panelToolbar, panelFooter, panelPicConfig);
            settings.Dock = DockStyle.Fill;
            settings.SetParentForm(this);
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

        private void serialPort1_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = serialPort1.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort1.Read(buffer, 0, buffer.Length);

                allCon?.HandleReceivedData(buffer);
                imgWrapper?.HandleReceivedData(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("RX Error: " + ex.Message);
            }
        }
    }
}

