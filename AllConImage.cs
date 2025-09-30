using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class AllConImage : UserControl
    {
        private PictureBox[,] pictureBoxes = new PictureBox[2, 10];
        private GTI parentForm;
        public AllConImage()
        {
            InitializeComponent();
            InitializePictureGrid();
          
        }

        public void SetParentForm(GTI form)
        {
            parentForm = form;
        }
        private void AllConImage_Load(object sender, EventArgs e)
        {
          
        }

        private void InitializePictureGrid()
        {
            int rows = 2;
            int cols = 8;

            // Initialize pictureBoxes array
            pictureBoxes = new PictureBox[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    PictureBox pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(5) // 5px padding on all sides
                    };

                    tableLayoutPanel1.Controls.Add(pb, col, row);
                    pictureBoxes[row, col] = pb;
                    pb.Padding = new Padding(6);
                }
            }
        }

        public void LoadImagesFromProcess(string csvFileName)
        {
            if (ProcessReader.Process_CSV == null || ProcessReader.Process_CSV.Count == 0)
                return;

            string folderPath = Path.Combine("images", Path.GetFileNameWithoutExtension(csvFileName));

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Please add images inside {folderPath} and try again", "Images Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                parentForm?.ResetSelectDesk(); // reset dropdown

                return;
            }

            bool imagesExist = Directory.GetFiles(folderPath, "*.jpg").Any() || Directory.GetFiles(folderPath, "*.png").Any();
            if (!imagesExist)
            {
                MessageBox.Show($"No images found inside {folderPath}. Please add images and try again.", "Images Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                parentForm?.ResetSelectDesk();
                return;
            }

            // --- Rest of your current logic ---
            // 1. Get CON and E-CON values
            var conValues = ProcessReader.Process_CSV
                .Skip(5)
                .Where(row => row.Count > 3 && !string.IsNullOrWhiteSpace(row[3]))
                .Select(row => row[3].Trim())
                .Distinct()
                .OrderBy(val =>
                {
                    bool isECon = val.StartsWith("E-CON", StringComparison.OrdinalIgnoreCase);
                    var numPart = new string(val.SkipWhile(c => !char.IsDigit(c)).ToArray());
                    int.TryParse(numPart, out int number);
                    return (isECon ? 1 : 0, number);
                })
                .ToList();

            var binValues = ProcessReader.Process_CSV
                .Skip(5)
                .Where(row => row.Count > 1)
                .Select(row => row[1].Trim())
                .Where(val => val.Equals("BIN", StringComparison.OrdinalIgnoreCase)
                           || val.Equals("S-STICK", StringComparison.OrdinalIgnoreCase))
                .Distinct()
                .ToList();

            var allValues = conValues.Concat(binValues).ToList();

            int index = 0;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    PictureBox pb = pictureBoxes[row, col];

                    if (index < allValues.Count)
                    {
                        string name = allValues[index];
                        string imgPathJpg = Path.Combine(folderPath, name + ".jpg");
                        string imgPathPng = Path.Combine(folderPath, name + ".png");

                        if (File.Exists(imgPathJpg))
                            pb.Image = Image.FromFile(imgPathJpg);
                        else if (File.Exists(imgPathPng))
                            pb.Image = Image.FromFile(imgPathPng);
                        else
                            pb.Image = null;

                        pb.Visible = true;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;

                        // Keep your existing Paint/border logic here
                        if (name.StartsWith("CON", StringComparison.OrdinalIgnoreCase))
                            pb.Paint += (s, e) => DrawBorder(e, Color.Red, 6);
                        else if (name.Equals("BIN", StringComparison.OrdinalIgnoreCase) || name.Equals("S-STICK", StringComparison.OrdinalIgnoreCase) || name.StartsWith("E-CON", StringComparison.OrdinalIgnoreCase))
                            pb.Paint += (s, e) => DrawBorder(e, Color.Blue, 6);

                        index++;
                    }
                    else
                    {
                        pb.Image = null;
                        pb.Visible = false;
                        pb.BorderStyle = BorderStyle.None;
                    }
                }
            }
        }


        // Helper method to draw custom border
        private void DrawBorder(PaintEventArgs e, Color color, int thickness)
        {
            using (Pen pen = new Pen(color, thickness))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
