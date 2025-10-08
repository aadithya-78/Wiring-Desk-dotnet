using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class BarcodePrinter : Form
    {
        public BarcodePrinter()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
        }
     
        private void BarcodePrinter_Load(object sender, EventArgs e)
        {
            bp_DatePicker.Format = DateTimePickerFormat.Short;
            bp_DatePicker.ShowUpDown = false;

            // Time picker setup
            bp_TimePicker.Format = DateTimePickerFormat.Time;
            bp_TimePicker.ShowUpDown = true;

            // Default values
            bp_DatePicker.Value = DateTime.Now.Date;
            bp_TimePicker.Value = DateTime.Now;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime date = bp_DatePicker.Value.Date;
            TimeSpan time = bp_TimePicker.Value.TimeOfDay;
            DateTime combined = date + time;

            MessageBox.Show($"Selected Date: {date:d}\nSelected Time: {time}\nCombined: {combined}");
        }
    }
}
