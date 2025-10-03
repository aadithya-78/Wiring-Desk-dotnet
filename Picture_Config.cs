using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;
using Panel = System.Windows.Forms.Panel;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Wiring_Desk
{
    public partial class Picture_Config : UserControl
    {
        private Panel userControlPanel;
        private Panel configPanel;
        private Panel panelToolbar;
        private Panel panelFooter;
        private Panel picConfig;

        private List<PinPoint> points = new List<PinPoint>();
        private char currentText = 'A';
        private bool clickLocked = false;
        private Timer clickTimer;
        private int circleRadius = 10;
        private int colorRingOne;
        private int colorRingTwo;
        private int fontColor;
        private int fontSize = 12;
        private int buttonFlag;
        
        public Picture_Config(Panel _userControlPanel, Panel _configPanel, Panel _panelToolbar, Panel _panelFooter, Panel _picConfig)
        {
            InitializeComponent();
            userControlPanel = _userControlPanel;
            configPanel = _configPanel;
            panelToolbar = _panelToolbar;
            panelFooter = _panelFooter;
            picConfig = _picConfig;
            LoadHarnesses();

            //Timer for Picture click debouncing
            clickTimer = new Timer();
            clickTimer.Interval = 500; // 1 second
            clickTimer.Tick += (s, ev) =>
            {
                clickLocked = false;
                clickTimer.Stop();
            };
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            guna2TrackBar1.Minimum = 1;
            guna2TrackBar1.Maximum = 50;
            guna2TrackBar1.Value = 10;
            guna2TrackBar1.Scroll += guna2TrackBar1_Scroll;
            panel2.Paint += panel2_Paint;


            for (int i = 8; i <= 24; i++)
            {
                cmbFontSize.Items.Add(i);
            }
            cmbFontSize.SelectedItem = fontSize;

            //Initialization

            colorRingOne = Color.Red.ToArgb();
            colorRingTwo = Color.Blue.ToArgb();
            fontColor = Color.Yellow.ToArgb();
            fontSize = 12;

            btnColor1.BackColor = Color.Red;
            btnColor2.BackColor = Color.Blue;
            btnTextColor.BackColor = Color.Yellow;

            cmbFontSize.SelectedItem = fontSize;

            rBtnAuto.Checked = true;   // Automatic mode initially
            buttonFlag = 1;            // Matches automatic mode behavior

            // Draw initial ring in panel2
            panel2.Invalidate();        // triggers panel2_Paint

        }

        /*-------------------------------------------------------LOAD-----------------------------------------------------------*/

        private void LoadHarnesses()
        {
            cmbConnector.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbConnector.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbHarness.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbHarness.AutoCompleteSource = AutoCompleteSource.ListItems;

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "process");

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("CSV folder not found: " + folderPath);
                return;
            }

            string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");

            cmbHarness.Items.Clear();

            foreach (string file in csvFiles)
            {
                cmbHarness.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void cmbHarness_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedHarness = cmbHarness.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(selectedHarness))
                    return;

                string harnessPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedHarness);

                if (!Directory.Exists(harnessPath))
                {
                    MessageBox.Show("Image Folder Not Found for: " + selectedHarness);
                    return;
                }

                string[] files = Directory.GetFiles(harnessPath, "*.*")
                    .Where(f => (f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                     f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)) &&
                     Path.GetFileName(f).StartsWith("CON", StringComparison.OrdinalIgnoreCase) || Path.GetFileName(f).StartsWith("E-CON", StringComparison.OrdinalIgnoreCase))
                     .ToArray();


                cmbConnector.Items.Clear();
                foreach (string file in files)
                {
                    cmbConnector.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading connectors: " + ex.Message);
            }
        }

        /*---------------------------------------------Picture Configuration------------------------------------------------*/

        public class PinPoint
        {
            public float x { get; set; }
            public float y { get; set; }
            public string radius { get; set; }
            public string text { get; set; }
            public string c1 { get; set; }
            public string c2 { get; set; }
            public string tc { get; set; }
            public string size { get; set; }
            public int sequence { get; set; }
        }

        private void DrawRing(PinPoint p, float pbWidth, float pbHeight, float imgWidth, float imgHeight)
        {
            float scaleX = pbWidth / imgWidth;
            float scaleY = pbHeight / imgHeight;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                float drawX = p.x * scaleX;
                float drawY = p.y * scaleY;
                float radius = float.Parse(p.radius);

                Rectangle rect = new Rectangle(
                    (int)(drawX - radius),
                    (int)(drawY - radius),
                    (int)(radius * 2),
                    (int)(radius * 2)
                );

                using (Pen pen1 = new Pen(ColorTranslator.FromHtml(p.c1), 2))
                using (Pen pen2 = new Pen(ColorTranslator.FromHtml(p.c2), 2))
                using (Brush brush = new SolidBrush(ColorTranslator.FromHtml(p.tc)))
                {
                    g.DrawArc(pen1, rect, 90, 180);
                    g.DrawArc(pen2, rect, -90, 180);
                    using (Font font = new Font("Arial", fontSize, FontStyle.Bold))
                    {
                        SizeF textSize = g.MeasureString(p.text, font);
                        g.DrawString(p.text, font, brush,
                            drawX - textSize.Width / 2,
                            drawY - textSize.Height / 2);
                    }
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSelectPin.Text) ||
                string.IsNullOrWhiteSpace(tbPinName.Text) ||
                colorRingOne == 0 || colorRingTwo == 0)
            {
                MessageBox.Show("Please select Pin, Pin name and choose both colors before placing ring.");
                return;
            }

            if (clickLocked) return;
            clickLocked = true;
            clickTimer.Start();

            float pbWidth = pictureBox1.Width;
            float pbHeight = pictureBox1.Height;

            float imgWidth = pictureBox1.Image.Width;
            float imgHeight = pictureBox1.Image.Height;

            float mouseX = e.X;
            float mouseY = e.Y;

            float scaleX = 660f / pbWidth;
            float scaleY = 410f / pbHeight;

            float actualX = mouseX * scaleX;
            float actualY = mouseY * scaleY;

            string hexC1 = ColorTranslator.ToHtml(Color.FromArgb(colorRingOne));
            string hexC2 = ColorTranslator.ToHtml(Color.FromArgb(colorRingTwo));
            string hexTC = ColorTranslator.ToHtml(Color.FromArgb(fontColor));

            string enteredText = tbPinName.Text.Trim();


            int seq = 0;

            if (cmbSelectPin.SelectedItem != null && int.TryParse(cmbSelectPin.SelectedItem.ToString(), out int temp))
            {
                seq = temp;
            }
            else if (int.TryParse(tbPinName.Text.Trim(), out int temp2))
            {
                seq = temp2;
            }


            var point = new PinPoint
            {
                x = actualX,
                y = actualY,
                radius = guna2TrackBar1.Value.ToString(),
                text = enteredText,
                c1 = hexC1,
                c2 = hexC2,
                tc = hexTC,
                size = fontSize.ToString(),
                sequence = seq
            };

            var existing = points.FirstOrDefault(p => p.text == enteredText);
            if (existing != null)
            {

                points.Remove(existing);
            }

            points.Add(point);

            RedrawAllRings(pbWidth, pbHeight, 660f, 410f);

            //Delete Combo Box
            cmbDeletePin.Items.Clear();
            if (points.Count > 0)
            {
                foreach (var pt in points)
                {
                    cmbDeletePin.Items.Add(pt.sequence); 
                }
            }

        }

        private void RedrawAllRings(float pbWidth, float pbHeight, float imgWidth, float imgHeight)
        {
            pictureBox1.Refresh();
            foreach (var point in points)
            {
                DrawRing(point, pbWidth, pbHeight, imgWidth, imgHeight);
            }
        }


        private void btnColor1_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.SolidColorOnly = false;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    colorRingOne = cd.Color.ToArgb();
                    btnColor1.BackColor = cd.Color;
                }
            }
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.SolidColorOnly = false;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    colorRingTwo = cd.Color.ToArgb();
                    btnColor2.BackColor = cd.Color;
                }
            }
        }


        private void btnTextColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.SolidColorOnly = false;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    fontColor = cd.Color.ToArgb();
                    btnTextColor.BackColor = cd.Color;
                }
            }
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            circleRadius = guna2TrackBar1.Value;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel2.BackColor);

            int centerX = panel2.Width / 2;
            int centerY = panel2.Height / 2;

            int radius = circleRadius;
            Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
            using (Pen pen1 = new Pen(Color.FromArgb(colorRingOne), 4)) // thicker line
            using (Pen pen2 = new Pen(Color.FromArgb(colorRingTwo), 4))
            {
                e.Graphics.DrawArc(pen1, rect, 90, 180);
                e.Graphics.DrawArc(pen2, rect, 270, 180);
            }
        }


        private void cmbSelectPin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buttonFlag == 1)
            {
                if (cmbSelectPin.SelectedItem != null)
                {
                    tbPinName.Text = cmbSelectPin.SelectedItem.ToString();
                }
            }
            else
            {
                tbPinName.Text = "";
            }
        }

        private void rBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnAuto.Checked)
            {
                tbPinName.Enabled = false;
                buttonFlag = 1;
                if (cmbSelectPin.SelectedItem != null)
                {
                    tbPinName.Text = cmbSelectPin.SelectedItem.ToString();
                }
            }
            else
            {
                tbPinName.Enabled = true;
            }
        }

        private void rBtnManual_CheckedChanged(object sender, EventArgs e)
        {
            buttonFlag = 0;
        }

        /*-----------------------------------------------------------------------------------------------------------------*/

        private void btnSave_Click(object sender, EventArgs e)
        {
           try
            {
                string imagesBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                string selectedHarness = cmbHarness.SelectedItem?.ToString();
                string selectedCon = cmbConnector.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedHarness))
                {
                    MessageBox.Show("Please select a harness before saving.");
                    return;
                }

                string harnessDir = Path.Combine(imagesBasePath, selectedHarness);
                if (!Directory.Exists(harnessDir))
                {
                    Directory.CreateDirectory(harnessDir);
                }

                var jsonList = new List<object> { null };
                var scaledPoints = points.Select(p => new PinPoint
                {
                    x = p.x,
                    y = p.y,
                    radius = p.radius,
                    text = p.text,
                    c1 = p.c1,
                    c2 = p.c2,
                    tc = p.tc,
                    size = p.size,
                    sequence = p.sequence
                });

                jsonList.AddRange(scaledPoints);
                string json = JsonSerializer.Serialize(jsonList, new JsonSerializerOptions { WriteIndented = true });

                string jsonPath = Path.Combine(harnessDir, $"{selectedCon}.json");
                File.WriteAllText(jsonPath, json);

               //MessageBox.Show($"JSON saved successfully at:\n{jsonPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving JSON: " + ex.Message);
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            picConfig.Controls.Clear();
            picConfig.SendToBack();
            configPanel.BringToFront();

            userControlPanel.Visible = true;
            panelToolbar.Visible = true;

            Settings settingsPage = new Settings(userControlPanel, configPanel, panelToolbar, panelFooter, picConfig);
            settingsPage.Dock = DockStyle.Fill;
            userControlPanel.Controls.Add(settingsPage);
        }

        private void cmbConnector_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string selectedHarness = cmbHarness.SelectedItem.ToString();
                string selectedmage = cmbConnector.SelectedItem.ToString();
                string harnessPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedHarness);

                if (string.IsNullOrWhiteSpace(selectedHarness))
                    return;
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedHarness, selectedmage + ".jpg");
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedHarness, selectedmage + ".json");

                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    string errorImage = Path.Combine(harnessPath, "no_image.jpg");
                    if (File.Exists(errorImage))
                    {
                        pictureBox1.Image = Image.FromFile(errorImage);
                    }
                    else
                    {
                        MessageBox.Show("Neither the connector image nor the error image could be found.");
                        pictureBox1.Image = null;
                        return;
                    }
                }

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                
                //Get Total Pins 
                bool found = false;
                int totalPins =0;
                for (int i = 3; i < ConfigReader.ConfigCSV.Count; i++) 
                {
                    var row = ConfigReader.ConfigCSV[i];
                    if (row.Count > 3) 
                    {
                        string connectorName = row[1]; 
                        if (connectorName.Equals(selectedmage, StringComparison.OrdinalIgnoreCase))
                        {
                            tbTotalPins.Text = row[3];
                           
                            if (!int.TryParse(row[3], out totalPins))
                            {
                                MessageBox.Show("Invalid pin count in Config file for " + connectorName);
                                return;
                            }


                            found = true;
                            break;
                        }
                    }
                }


                cmbSelectPin.Items.Clear();
                for (int i = 1; i <= totalPins; i++)
                {
                    cmbSelectPin.Items.Add(i);
                }

                if (!found)
                {
                    MessageBox.Show("Add this CON in Config file error: " + selectedmage);
                    tbTotalPins.Text = string.Empty;
                }


                // Reset points list
                points.Clear();

                // Load JSON if available
                if (File.Exists(jsonPath))
                {
                    try
                    {
                        string jsonContent = File.ReadAllText(jsonPath);
                        var loadedPoints = System.Text.Json.JsonSerializer.Deserialize<List<PinPoint>>(jsonContent);
                        if (loadedPoints != null && loadedPoints.Count > 0)
                        {
                            points.AddRange(loadedPoints.Where(p => p != null));

                            // Redraw all markers using your DrawRing
                            float pbWidth = pictureBox1.Width;
                            float pbHeight = pictureBox1.Height;

                            float imgWidth = pictureBox1.Image.Width;
                            float imgHeight = pictureBox1.Image.Height;

                            RedrawAllRings(pbWidth, pbHeight, 660f, 410f);

                            cmbDeletePin.Items.Clear();

                            if (points.Count > 0)
                            {
                                foreach (var pt in points)
                                {
                                    cmbDeletePin.Items.Add(pt.sequence);
                                }
                            }

                        }
                    }
                    catch (Exception jex)
                    {
                        MessageBox.Show("Error reading JSON: " + jex.Message);
                    }
                   }
          
        }

            catch (Exception ex) {
                MessageBox.Show("Error loading Images: " + ex.Message);
            }

        }

     
        private void tbPinName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeletePin_Click(object sender, EventArgs e)
        {
            if (cmbDeletePin.SelectedItem == null)
            {
                MessageBox.Show("Please select a pin to delete.");
                return;
            }

            // Get the selected sequence number
            if (!int.TryParse(cmbDeletePin.SelectedItem.ToString(), out int seqToDelete))
            {
                MessageBox.Show("Invalid sequence selected.");
                return;
            }

            // Remove the point from the current list
            var pointToRemove = points.FirstOrDefault(p => p.sequence == seqToDelete);
            if (pointToRemove != null)
            {
                points.Remove(pointToRemove);
            }
            else
            {
                MessageBox.Show("Point not found.");
                return;
            }

            // Redraw the picture
            float pbWidth = pictureBox1.Width;
            float pbHeight = pictureBox1.Height;
            float imgWidth = pictureBox1.Image.Width;
            float imgHeight = pictureBox1.Image.Height;

            RedrawAllRings(pbWidth, pbHeight, 660f, 410f);

            // Refresh Delete Pin ComboBox
            cmbDeletePin.Items.Clear();

            if (points.Count > 0)
            {
                foreach (var pt in points)
                {
                    cmbDeletePin.Items.Add(pt.sequence);
                }
            }

            // Update JSON file
            try
            {
                string selectedHarness = cmbHarness.SelectedItem?.ToString();
                string selectedCon = cmbConnector.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedHarness) || string.IsNullOrEmpty(selectedCon))
                    return;

                string harnessDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedHarness);
                if (!Directory.Exists(harnessDir))
                    Directory.CreateDirectory(harnessDir);

                string jsonPath = Path.Combine(harnessDir, $"{selectedCon}.json");

                // Serialize current points list
                var jsonList = new List<object> { null }; // first null as per your format
                jsonList.AddRange(points);
                string json = JsonSerializer.Serialize(jsonList, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(jsonPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating JSON after deletion: " + ex.Message);
            }
        }

        private void Picture_Config_Load(object sender, EventArgs e)
        {

        }
    }
}
