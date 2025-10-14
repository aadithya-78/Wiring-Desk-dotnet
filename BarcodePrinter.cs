using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class BarcodePrinter : Form
    {
        [DllImport(@"C:\Program Files (x86)\Phoeneix Process Automation\Wiring Desk Setup\tsclib86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int openport(string printerName);

        [DllImport(@"C:\Program Files (x86)\Phoeneix Process Automation\Wiring Desk Setup\tsclib86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int sendcommand(string command);

        [DllImport(@"C:\Program Files (x86)\Phoeneix Process Automation\Wiring Desk Setup\tsclib86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int closeport();

        public BarcodePrinter()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;

            if(processState.deskName != null) bp_rtbDeskName.Text = processState.deskName;
            bp_rtbLineName.Text = processState.lineName;
            bp_rtbOpName.Text = processState.operatorName;
        }
     
        private void BarcodePrinter_Load(object sender, EventArgs e)
        {
            bp_DatePicker.Format = DateTimePickerFormat.Short;
            bp_DatePicker.ShowUpDown = false;

            bp_TimePicker.Format = DateTimePickerFormat.Time;
            bp_TimePicker.ShowUpDown = true;

            bp_DatePicker.Value = DateTime.Now.Date;
            bp_TimePicker.Value = DateTime.Now;
        }

        /* private void btnPrint_Click(object sender, EventArgs e)
         {
             DateTime date = bp_DatePicker.Value.Date;
             TimeSpan time = bp_TimePicker.Value.TimeOfDay;
             DateTime combined = date + time;

             try
             {
                 string mypn = "ABC123";
                 string srno = "0001";
                 string dates = "2025-05-13";
                 string times = "14:30";
                 string barcode = "My barcode printer";

                 string prnData = $@"
                 SIZE 35.0 mm, 16 mm
                 DIRECTION 0,0
                 REFERENCE 0,0
                 SPEED 0.5
                 OFFSET 20 mm
                 SET PEEL OFF
                 SET CUTTER OFF
                 SET PARTIAL_CUTTER OFF
                 SET TEAR ON
                 CLS
                 CODEPAGE 1252
                 TEXT 170,110,""0"",180,10,13,""{mypn}"" 
                 TEXT 170,78,""0"",180,6,6,""{times}"" 
                 TEXT 93,79,""0"",180,6,6,""{dates}"" 
                 TEXT 166,57,""0"",180,7,7,""Sr.No.- {srno}"" 
                 TEXT 160,24,""0"",180,6,6,""IP LINE2 SUB2A OK"" 
                 DMATRIX 170,10,71,71,x3,16,16,""{barcode}"" 
                 PRINT 1,1
                 ";


                 int openResult = openport("TSC TE244");
                 if (openResult != 1)
                 {
                     MessageBox.Show("Failed to open printer port. Check printer installation and port name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 foreach (string line in prnData.Trim().Split('\n'))
                 {
                     string cmd = line.Trim();
                     if (!string.IsNullOrEmpty(cmd))
                     {
                         int res = sendcommand(cmd);
                         if (res != 1)
                         {
                             MessageBox.Show($"Failed to send command:\n{cmd}", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                     }
                 }

                 closeport();
                 MessageBox.Show("PRN data sent to printer successfully.", "Wiring Desk");

             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Printing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }


         }

         */

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = bp_DatePicker.Value.Date;
                TimeSpan selectedTime = bp_TimePicker.Value.TimeOfDay;
                DateTime combined = selectedDate + selectedTime;

                string dates = combined.ToString("dd-MM-yyyy");
                string times = combined.ToString("HH:mm");

                string mypn = "240106VA0B";
                string srno = "00001";
                string barcode = "My barcode printer";

                string prnFilePath = Path.Combine(Application.StartupPath, "barcode", "label.prn");

                if (!File.Exists(prnFilePath))
                {
                    MessageBox.Show($"PRN file not found:\n{prnFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string prnData = File.ReadAllText(prnFilePath);

                prnData = prnData
                    .Replace("MYPN", mypn)
                    .Replace("MYSLNUM", srno)
                    .Replace("@date", dates)
                    .Replace("@time", times)
                    .Replace("MYBARCODE", barcode);

                int openResult = openport("TSC TE244");  
                if (openResult != 1)
                {
                    MessageBox.Show("Failed to open printer port. Check printer installation and port name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (string line in prnData.Split('\n'))
                {
                    string cmd = line.Trim();
                    if (!string.IsNullOrEmpty(cmd) && !cmd.StartsWith("#") && !cmd.StartsWith(":"))
                    {
                        int res = sendcommand(cmd);
                        if (res != 1)
                        {
                            MessageBox.Show($"Failed to send command:\n{cmd}", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                closeport();

                MessageBox.Show("Label printed successfully.", "Wiring Desk", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bp_rtbDeskName_TextChanged(object sender, EventArgs e)
        {

        }

     
    }
}
