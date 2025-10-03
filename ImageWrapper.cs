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
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class ImageWrapper : UserControl
    {
        private string selectedDesk;
        private List<List<string>> processCsv;
        private int currentRowIndex = 5;
        private List<PinPoint> points = new List<PinPoint>();
        public int CurrentRowIndex
        {
            get => currentRowIndex;
            set
            {
                if (value >= 5 && value < processCsv.Count) 
                {
                    currentRowIndex = value;
                    LoadImagesForCurrentRow();
                }
            }
        }

        public ImageWrapper(string desk, List<List<string>> loadedCsv)
        {
            InitializeComponent();
            selectedDesk = desk;
            processCsv = loadedCsv;
            LoadImagesForCurrentRow();
            pbCon.Paint += pbCon_paint;
        }

        /* private void LoadImagesForCurrentRow()
         {
             try
             {
                 if (processCsv == null || currentRowIndex >= processCsv.Count)
                     return;

                 var row = processCsv[currentRowIndex];
                 if (row.Count < 4)
                     return;

                 string binFileName = row[1]; // 2nd column
                 string conFileName = row[3]; // 4th column

                 string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedDesk);

                 LoadPictureBox(pbBin, imagesPath, binFileName);
                 LoadPictureBox(pbCon, imagesPath, conFileName);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error loading images: " + ex.Message);
             }
         }*/

        private void LoadImagesForCurrentRow()
        {
            try
            {
                if (processCsv == null || currentRowIndex >= processCsv.Count)
                    return;

                var row = processCsv[currentRowIndex];
                if (row.Count < 6)
                    return;

                string binFileName = row[1]; // 2nd column
                string conFileName = row[3]; // 4th column
                int cavityNum = int.TryParse(row[4], out int tmpCavity) ? tmpCavity : 0; // 5th column

                string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedDesk);

                LoadPictureBox(pbBin, imagesPath, binFileName);
                LoadPictureBox(pbCon, imagesPath, conFileName);

                // Load JSON for CON and draw rings
                string jsonPath = Path.Combine(imagesPath, conFileName + ".json");
                points.Clear();

                if (File.Exists(jsonPath))
                {
                    string jsonContent = File.ReadAllText(jsonPath);
                    var loadedPoints = JsonSerializer.Deserialize<List<PinPoint>>(jsonContent);
                    if (loadedPoints != null && loadedPoints.Count > 0)
                    {
                        // Ignore null first element (based on your save logic)
                        points.AddRange(loadedPoints.Where(p => p != null));

                        // Filter points by sequence matching cavityNum
                        var pointsToDraw = points.Where(p => p.sequence == cavityNum).ToList();
                        points = pointsToDraw;

                        float pbWidth = pbCon.Width;
                        float pbHeight = pbCon.Height;
                      
                        RedrawAllRings();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading images or rings: " + ex.Message);
            }
        }

        private void LoadPictureBox(PictureBox pb, string folderPath, string fileNameWithoutExt)
        {
            string jpgPath = Path.Combine(folderPath, fileNameWithoutExt + ".jpg");
            string pngPath = Path.Combine(folderPath, fileNameWithoutExt + ".png");

            if (File.Exists(jpgPath))
                pb.Image = Image.FromFile(jpgPath);
            else if (File.Exists(pngPath))
                pb.Image = Image.FromFile(pngPath);
            else
                pb.Image = null;

            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        //--

       /* private void DrawRing(PinPoint p, float pbWidth, float pbHeight, float imgWidth, float imgHeight)
        {
            if (pbCon.Image == null) return;

            float scaleX = pbWidth / imgWidth;
            float scaleY = pbHeight / imgHeight;

            using (Graphics g = pbCon.CreateGraphics())
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
                using (Font font = new Font("Arial", float.Parse(p.size), FontStyle.Bold))
                {
                    g.DrawArc(pen1, rect, 90, 180);
                    g.DrawArc(pen2, rect, -90, 180);
                    SizeF textSize = g.MeasureString(p.text, font);
                    g.DrawString(p.text, font, brush,
                        drawX - textSize.Width / 2,
                        drawY - textSize.Height / 2);
                }
            }
        }*/

        private void RedrawAllRings() { 
            pbCon.Invalidate();
        }

        private void pbCon_paint(object sender, PaintEventArgs e)
        {
            if (points == null || points.Count == 0 || pbCon.Image == null) return;

            float pbWidth = pbCon.Width;
            float pbHeight = pbCon.Height;
            float imgWidth = 660f;
            float imgHeight = 410f;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var p in points)
            {
                float scaleX = pbWidth / imgWidth;
                float scaleY = pbHeight / imgHeight;

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
                using (Font font = new Font("Arial", float.Parse(p.size), FontStyle.Bold))
                {
                    e.Graphics.DrawArc(pen1, rect, 90, 180);
                    e.Graphics.DrawArc(pen2, rect, -90, 180);
                    SizeF textSize = e.Graphics.MeasureString(p.text, font);
                    e.Graphics.DrawString(p.text, font, brush,
                        drawX - textSize.Width / 2,
                        drawY - textSize.Height / 2);
                }
            }
        }

        // PinPoint class
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

        private void pictureBox1_Click(object sender, EventArgs e)
          {

            }

        private void ImageWrapper_Load(object sender, EventArgs e)
        {

        }

       
    }
}
