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
    public partial class ImageWrapper : UserControl
    {
        private string selectedDesk;
        private List<List<string>> processCsv;
        private int currentRowIndex = 5;
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
            LoadImagesForCurrentRow(); // initial load
        }

        private void LoadImagesForCurrentRow()
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
    
         private void pictureBox1_Click(object sender, EventArgs e)
          {

            }

        private void ImageWrapper_Load(object sender, EventArgs e)
        {

        }
    }
}
