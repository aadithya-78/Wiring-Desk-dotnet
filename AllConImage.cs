using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class AllConImage : UserControl
    {
        private PictureBox[,] pictureBoxes = new PictureBox[2, 10];
        private GTI parentForm;

        private int relay_flags = 1;
        public Queue<int> UARTSequence = new Queue<int>();
        private bool startupRunning = false;
        private int conCount = 0;
        private int binCount = 0;
        public List<byte> conValuesTx = new List<byte>();
        public List<byte> binValuesTx = new List<byte>();
        private byte[] rxBuffer = new byte[0];
 

        private SerialPort serialPort1;

        public AllConImage(SerialPort _serialPort1)
        {
            InitializeComponent();
            InitializePictureGrid();
            relayTimer.Start();
            UARTSequence.Enqueue(7);
            UARTSequence.Enqueue(2);
            UARTSequence.Enqueue(3);
            UARTSequence.Enqueue(2);
            UARTSequence.Enqueue(6);

            conValuesTx = ProcessReader.Process_CSV
                .Skip(5)
                .Where(row => row.Count > 3 &&
                              !string.IsNullOrWhiteSpace(row[3]) &&
                              row[3].Trim().StartsWith("CON-", StringComparison.OrdinalIgnoreCase))
                .Select(row =>
                {
                    var part = row[3].Split('-').LastOrDefault();
                    return byte.TryParse(part, out byte num) ? num : (byte)0;
                })
                .Where(val => val > 0)  
                .Distinct()
                .OrderBy(val => val)
                .ToList();
            conCount = conValuesTx.Count;

            binValuesTx = ProcessReader.Process_CSV
                .Skip(5)
                .Where(row => row.Count > 2 &&
                              row[1].Trim().Equals("BIN", StringComparison.OrdinalIgnoreCase) &&
                              !string.IsNullOrWhiteSpace(row[2]))
                .Select(row =>
                {
                    var part = row[2].Trim();
                    return byte.TryParse(part, out byte num) ? num : (byte)0;
                })
                .Where(val => val > 0) 
                .Distinct()
                .OrderBy(val => val)
                .ToList();

            binCount = binValuesTx.Count;

            startupRunning = true;
            serialPort1 = _serialPort1;
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

                        if (name.StartsWith("CON", StringComparison.OrdinalIgnoreCase))
                        {
                            pb.Tag = Color.Red;
                            pb.Paint += (s, e) =>
                            {
                                var color = (Color)(pb.Tag ?? Color.Red);
                                DrawBorder(e, color, 6);
                            };

                        }
   
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

        private byte[] ConstructPacket(int moduleCount)
        {
            int packetLength = 7 + (moduleCount * 2);
            byte[] packet = new byte[packetLength];
            packet[0] = 0x27; packet[1] = (byte)(packetLength - 3);
            packet[2] = 0x85;
            packet[3] = 0x01;
            packet[4] = 0x04;
            packet[5] = (byte)moduleCount;
            int index = 6;
            for (byte i = 1; i <= moduleCount; i++)
            {
                packet[index++] = i;
                packet[index++] = 0x01;
            }
            packet[index] = 0x16;
            return packet;
        }
        /*private void relayTimer_Tick(object sender, EventArgs e)
        {

            if (startupRunning && UARTSequence.Count > 0)
            {
                relay_flags = UARTSequence.Dequeue();
            }
            else if (startupRunning && UARTSequence.Count == 0)
            {
                startupRunning = false;
                relayTimer.Stop();
                rxtxTimer.Start();
                borderTimer.Start();
            }

            switch (relay_flags)
            {
                case 1: // Yellow Relay On
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x01, 0x01, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                        }
                        break;
                    }
                case 2: // Yellow Relay Off
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x01, 0x00, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                        }
                        break;
                    }

                case 3: // Green Relay On
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x02, 0x01, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                        }
                        break;
                    }
                case 4: // Green relay off
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x02, 0x00, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                        }
                        break;
                    }

                case 5: // Red Relay On
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x01, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                        }
                        break;
                    }
                case 6: // Red Relay Off
                    {
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            byte[] packet = { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x00, 0x16 };
                            serialPort1.Write(packet, 0, packet.Length);
                        }
                        break;
                    }
                case 7:

                    {
                        byte[] dataPacket = ConstructPacket(conCount);
                        if (serialPort1 != null && serialPort1.IsOpen)
                        {
                            serialPort1.Write(dataPacket, 0, dataPacket.Length);
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
        */

        private void relayTimer_Tick(object sender, EventArgs e)
        {
            // During startup
            if (startupRunning && UARTSequence.Count > 0)
            {
                relay_flags = UARTSequence.Dequeue();
            }
            else if (startupRunning && UARTSequence.Count == 0)
            {
                startupRunning = false;
                rxtxTimer.Start();
                borderTimer.Start();
                return; 
            }

            if (!startupRunning)
            {
                if (UARTSequence.Count > 0)
                {
                    relay_flags = UARTSequence.Dequeue();
                }
                else
                {
                    return;
                }
            }

            // Process relay_flags only if set
            switch (relay_flags)
            {
                case 1: // Yellow Relay On
                    if (serialPort1?.IsOpen == true)
                        serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x01, 0x01, 0x16 }, 0, 8);
                    break;

                case 2: // Yellow Relay Off
                    if (serialPort1?.IsOpen == true)
                        serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x01, 0x00, 0x16 }, 0, 8);
                    break;

                case 3: // Green Relay On
                    if (serialPort1?.IsOpen == true)
                        serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x02, 0x01, 0x16 }, 0, 8);
                    break;

                case 4: // Green relay off
                    if (serialPort1?.IsOpen == true)
                        serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x02, 0x00, 0x16 }, 0, 8);
                    break;

                case 5: // Red Relay On
                    if (serialPort1?.IsOpen == true)
                        serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x01, 0x16 }, 0, 8);
                    break;

                case 6: // Red Relay Off
                    if (serialPort1?.IsOpen == true)
                        serialPort1.Write(new byte[] { 0x27, 0x05, 0x85, 0x01, 0x06, 0x03, 0x00, 0x16 }, 0, 8);
                    break;

                case 7: // Custom startup packet
                    if (serialPort1?.IsOpen == true)
                    {
                        byte[] dataPacket = ConstructPacket(conCount);
                        serialPort1.Write(dataPacket, 0, dataPacket.Length);
                    }
                    break;

                default:

                    break;
            }
        }


        private byte[] conBurstPacket(int conCount, List<byte> conValues)
        {
         if (conValues == null || conValues.Count == 0)
            throw new ArgumentException("conValues cannot be null or empty");

            var distinctValues = conValues.Distinct().OrderBy(x => x).ToList();

            if (distinctValues.Count != conCount)
                throw new ArgumentException("conCount does not match the number of distinct conValues");
             List<byte> packet = new List<byte>();
            packet.Add(0x27);
            byte length = (byte)(conCount + 4);
            packet.Add(length);
            packet.Add(0x85);
            packet.Add(0x01);
            packet.Add(0x0A);
            packet.Add((byte)conCount);
            packet.AddRange(distinctValues);
            packet.Add(0x16);

            return packet.ToArray();
          }


        private byte[] binBurstPacket(int conCount, List<byte> conValues)
        {
            if (conValues == null || conValues.Count == 0)
                throw new ArgumentException("conValues cannot be null or empty");

            var distinctValues = conValues.Distinct().OrderBy(x => x).ToList();

            if (distinctValues.Count != conCount)
                throw new ArgumentException("conCount does not match the number of distinct conValues");
            List<byte> packet = new List<byte>();
            packet.Add(0x27);
            byte length = (byte)(conCount + 4);
            packet.Add(length);
            packet.Add(0x85);
            packet.Add(0x01);
            packet.Add(0x0B);
            packet.Add((byte)conCount);
            packet.AddRange(distinctValues);
            packet.Add(0x16);

            return packet.ToArray();
        }

        private bool sendCmd1Next = true; 
        private void rxtxTimer_Tick(object sender, EventArgs e)
        {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    if (sendCmd1Next)
                    {
                    var cmd1 = conBurstPacket(conValuesTx.Count, conValuesTx);
                    serialPort1.Write(cmd1, 0, cmd1.Length);
                }
                    else
                    {
                    var cmd2 = binBurstPacket(binValuesTx.Count, binValuesTx);
                    serialPort1.Write(cmd2, 0, cmd2.Length);
                }

                    sendCmd1Next = !sendCmd1Next;
                }
            }

        public void stopTimers()
        {
            rxtxTimer.Stop();
            borderTimer.Stop();
            relayTimer.Stop();
        }

        public void HandleReceivedData(byte[] data)
        {
            rxBuffer = rxBuffer.Concat(data).ToArray();
        }

        private void ParseFrame(byte[] frame)
        {
            if (frame.Length < 10) return;
            if (frame[0] != 0x27 || frame[frame.Length - 1] != 0x16) return;

            for (int i = 0; i < conValuesTx.Count; i++)
            {
                byte conNum = conValuesTx[i];          
                int dataIndex = 7 + (conNum - 1);     

                if (dataIndex >= frame.Length - 1) continue;

                byte value = frame[dataIndex];
                PictureBox pb = GetConPictureBox(i);   

                if (pb == null) continue;

                if (value == 0x05)
                    pb.Tag = Color.Green;   // mark as active
                else if (value == 0x00)
                    pb.Tag = Color.Red;     // mark as inactive
                else
                    pb.Tag = Color.Yellow;  // optional: unknown state
            }

            foreach (var pb in pictureBoxes)
                pb?.Invalidate();
        }


        private PictureBox GetConPictureBox(int index)
        {
            int row = index / 8;
            int col = index % 8;
            return pictureBoxes[row, col];
        }

        private void borderTimer_Tick(object sender, EventArgs e)
        {
            if (rxBuffer.Length == 0) return;

            while (true)
            {
                int start = Array.IndexOf(rxBuffer, (byte)0x27);
                if (start < 0) { rxBuffer = new byte[0]; return; }
                if (rxBuffer.Length < start + 2) return; 
                int length = rxBuffer[start + 1];  
                int frameLen = length + 3;           
                if (rxBuffer.Length < start + frameLen) return; 
                byte[] frame = rxBuffer.Skip(start).Take(frameLen).ToArray();
                rxBuffer = rxBuffer.Skip(start + frameLen).ToArray();
                ParseFrame(frame);
            }
        }
    }
}
