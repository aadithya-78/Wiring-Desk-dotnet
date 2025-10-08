using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Hosting;
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
        private SerialPort serialPort1;
        public int relay_flag = 0; 
        private byte[] rxBuffer = new byte[0];
        private bool rowAdvanced = false;
        private bool rowAdvancedEcon = false;
        public event Action<int, string> StepChanged;
        private Queue<int> UARTSequence = new Queue<int>();
        private bool blueOffFlag = false;
        public event Action OnProcessComplete;
        private bool actualIncrFlag = false;

        public int CurrentRowIndex
        {
            get => currentRowIndex;
            set
            {
                if (value >= 5 && value < processCsv.Count) 
                {
                    currentRowIndex = value;
                    LoadImagesForCurrentRow();
                    UARTSequence.Enqueue(3);
                    UARTSequence.Enqueue(3);
                    UARTSequence.Enqueue(4);
                    UARTSequence.Enqueue(5);
                    blueOffFlag = true;
                    string instruction = processCsv[CurrentRowIndex][7];
                    StepChanged?.Invoke(CurrentRowIndex - 4, instruction);
                }
            }
        }

        public ImageWrapper(string desk, List<List<string>> loadedCsv, SerialPort _serialPort1)
        {
            InitializeComponent();
            selectedDesk = desk;
            processCsv = loadedCsv;
            LoadImagesForCurrentRow();
            pbCon.Paint += pbCon_paint;

            UARTSequence.Enqueue(3);
            UARTSequence.Enqueue(4);
            UARTSequence.Enqueue(5);
            UARTSequence.Enqueue(6);

            serialPort1 = _serialPort1;
            rxtxTimer.Start();
        }

        private void ImageWrapper_Load(object sender, EventArgs e)
        {
            string instruction = processCsv[5][7];
            StepChanged?.Invoke(1, instruction);
        }

        private void LoadImagesForCurrentRow()
        {
            try
            {
                if (processCsv == null || currentRowIndex >= processCsv.Count)
                    return;

                var row = processCsv[currentRowIndex];
                if (row.Count < 6)
                    return;

                string binFileName = row[1]; 
                string conFileName = row[3];
                int cavityNum = int.TryParse(row[4], out int tmpCavity) ? tmpCavity : 0; 

                string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", selectedDesk);

                LoadPictureBox(pbBin, imagesPath, binFileName);
                LoadPictureBox(pbCon, imagesPath, conFileName);

                string jsonPath = Path.Combine(imagesPath, conFileName + ".json");
                points.Clear();

                if (File.Exists(jsonPath))
                {
                    string jsonContent = File.ReadAllText(jsonPath);
                    var loadedPoints = JsonSerializer.Deserialize<List<PinPoint>>(jsonContent);
                    if (loadedPoints != null && loadedPoints.Count > 0)
                    {
                        points.AddRange(loadedPoints.Where(p => p != null));

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

        public void stopTimers()
        {
            rxtxTimer.Stop();
        }

        private byte GetConNumber(string conName)
        {
            if (string.IsNullOrWhiteSpace(conName))
                return 0;
            if (!conName.StartsWith("CON-", StringComparison.OrdinalIgnoreCase))
                return 0;
            string numPart = conName.Substring(4);
            return byte.TryParse(numPart, out byte num) ? num : (byte)0;
        }

        private byte[] ConstructRowPacket(List<string> row)
        {
            if (row == null || row.Count < 5) return Array.Empty<byte>();

            byte val6 = 0;
            byte val7 = 0;

            if (row[1].Equals("BIN", StringComparison.OrdinalIgnoreCase))
            {
                val6 = (byte)((int.TryParse(row[2], out int tmp) && tmp < 60) ? 0x01 : 0x02);
                val7 = byte.TryParse(row[2], out byte tmp2) ? tmp2 : (byte)0;
            }

            byte conNum = GetConNumber(row[3]);
            byte val9 = byte.TryParse(row[4], out byte tmp3) ? (byte)tmp3 : (byte)0;

            return new byte[]
            {
                 0x27,
                 0x09,  
                 0x85,
                 0x01,
                 0x02,
                 0x02,
                 val6,
                 val7,
                 0x01,
                 conNum,
                 val9,
                 0x16
            };
        }

        private byte[] ConstructRowPacketAlt(List<string> row)
        {
            if (row == null || row.Count < 5) return Array.Empty<byte>();
            byte conNum = GetConNumber(row[3]);
            byte val9 = byte.TryParse(row[4], out byte tmp3) ? (byte)tmp3 : (byte)0;

            return new byte[]
            {
                 0x27,
                 0x09,
                 0x85,
                 0x01,
                 0x02,
                 0x02,
                 0x00,
                 0x00,
                 0x01,
                 conNum,
                 val9,
                 0x16
            };
        }


        public void HandleReceivedData(byte[] data)
        {
            rxBuffer = rxBuffer.Concat(data).ToArray();

            while (true)
            {
                int start = Array.IndexOf(rxBuffer, (byte)0x27);
                if (start < 0) { rxBuffer = new byte[0]; return; }

                if (rxBuffer.Length < start + 2) return;

                int length = rxBuffer[start + 1]; // frame length
                int frameLen = length + 3;        // header + length + footer

                if (rxBuffer.Length < start + frameLen) return;

                byte[] frame = rxBuffer.Skip(start).Take(frameLen).ToArray();
                ParseFrame(frame);  
                rxBuffer = rxBuffer.Skip(start + frameLen).ToArray();
            }
        }


        public bool processComplete = false;

        private void OnProcessCompleted()
        {
            if (processComplete) return;
            processComplete = true;
            processState.actualCount++;
            OnProcessComplete?.Invoke();
        }

        private void ParseFrame(byte[] frame)
        {
            if (frame.Length < 10) return;
            if (frame[0] != 0x27 || frame[frame.Length - 1] != 0x16) return;

            if (processCsv == null || currentRowIndex >= processCsv.Count) return;

            var row = processCsv[currentRowIndex];
            if (row.Count < 4) return;

            string conName = row[3];

            if (conName.StartsWith("CON-", StringComparison.OrdinalIgnoreCase))
            {

                string[] parts = conName.Split('-');
                if (parts.Length == 0) return;

                if (!int.TryParse(parts[1], out int conNum)) return;

                int dataIndex = 7 + (conNum - 1);
                if (dataIndex >= frame.Length - 1) return;

                byte value = frame[dataIndex];

                if (value == 0x07 && !rowAdvanced)
                {
                    if (CurrentRowIndex + 1 < processCsv.Count)
                    {
                        rowAdvanced = true;
                        CurrentRowIndex++;
                    }
                    else
                    {
                       if (!actualIncrFlag)
                        {
                            UARTSequence.Enqueue(3);
                            actualIncrFlag = true;
                            OnProcessCompleted();
                        }
                    }
                }
                else if (value != 0x07)
                {
                    rowAdvanced = false;
                }
            }

            else if (conName.StartsWith("E-CON", StringComparison.OrdinalIgnoreCase))
            {
                int dataIndex = 5;
                if (dataIndex >= frame.Length - 1) return;
                byte value = frame[dataIndex];

                if (value == 0x01 && !rowAdvancedEcon)
                {
                    if (CurrentRowIndex + 1 < processCsv.Count)
                    {
                        rowAdvancedEcon = true;
                        CurrentRowIndex++;
                        
                    }
                    else
                    {
                       if (!actualIncrFlag)
                        {
                            UARTSequence.Enqueue(4);
                            actualIncrFlag = true;
                            OnProcessCompleted();
                        }
                    }

                }

                else if (value == 0x00)
                {
                    rowAdvancedEcon = false;
                }

            }
        }

        private bool sendCmdNext = true;
        private void rxtxTimer_Tick(object sender, EventArgs e)
        {
            if (processCsv == null || currentRowIndex >= processCsv.Count) return;

            var row = processCsv[currentRowIndex];

            if (UARTSequence.Count > 0)
            {
                relay_flag = UARTSequence.Dequeue();
            }
            else if (UARTSequence.Count == 0)
            {
                relay_flag = 0;
            }

            switch (relay_flag)
            {
                case 1: //Warning Alarm ON 
                    {
                        if (serialPort1?.IsOpen == true) 
                        {
                            serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x01, 0x16 }, 0, 8);
                        }
                        relay_flag = 0;
                        break;
                    }

                case 2: //Warning Alarm OFF
                    {
                        if (serialPort1?.IsOpen == true)
                        {
                            serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x00, 0x16 }, 0, 8);
                        }
                        relay_flag = 0;
                        break;
                    }

                case 3: //LED OFF 
                    {
                        if (serialPort1?.IsOpen == true)
                        {
                            serialPort1.Write(new byte[] { 0x27, 0x04, 0x85, 0x01, 0x03, 0x00,0x16 }, 0, 7);
                        }
                        relay_flag = 0;
                        break;
                    }

                case 4: //E-CON OR START STATUS RESET
                    {
                        if (serialPort1?.IsOpen == true)
                        {
                            serialPort1.Write(new byte[] { 0x27, 0x04, 0x85, 0x01, 0x09, 0x00, 0x16 }, 0, 7);
                        }
                        relay_flag = 0;
                        break;
                    }

                case 5: //BLUE LIGHT ON
                    {
                        if (serialPort1?.IsOpen == true)
                        {
                            serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x06, 0x01, 0x16 }, 0, 8);
                        }
                        relay_flag = 0;
                        break;
                    }

                case 6: //BLUE LIGHT OFF
                    {
                        if (serialPort1?.IsOpen == true)
                        {
                            serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x06, 0x00, 0x16 }, 0, 8);
                        }
                        relay_flag = 0;

                        break;
                    }
                
                default:
                    if (serialPort1 != null && serialPort1.IsOpen)
                    {
                            if (sendCmdNext)
                            {
                                var packet1 = ConstructRowPacket(row);
                                serialPort1.Write(packet1, 0, packet1.Length);
                            }
                            else
                            {
                                var packet2 = ConstructRowPacketAlt(row);
                                serialPort1.Write(packet2, 0, packet2.Length);
                            }
                        sendCmdNext = !sendCmdNext;
                    }

                    if (blueOffFlag == true)
                    {
                        blueOffFlag = false;
                        UARTSequence.Enqueue(6);
                    }
                    break;
            }
        }
    }
}
