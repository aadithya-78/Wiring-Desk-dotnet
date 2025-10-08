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
    public partial class DummyUC : UserControl
    {

        public event Action StartRequested;

        private byte[] rxBuffer = new byte[0];
        private bool startTriggered = false;
        public DummyUC()
        {
            InitializeComponent();
            processState.userControl = "DUMMY";
        }

        private void DummyUC_Load(object sender, EventArgs e)
        {

        }

        public void HandleReceivedData(byte[] data)
        {
            // Append incoming bytes to buffer
            rxBuffer = rxBuffer.Concat(data).ToArray();
            ParseBuffer(); // process immediately
        }

        private void ParseBuffer()
        {
            while (true)
            {
                int start = Array.IndexOf(rxBuffer, (byte)0x27);
                if (start < 0)
                {
                    rxBuffer = new byte[0];
                    return;
                }

                if (rxBuffer.Length < start + 2) return; // not enough data for length byte

                int length = rxBuffer[start + 1]; // length field
                int frameLen = length + 3; // full frame = start + length + checksum/end

                if (rxBuffer.Length < start + frameLen) return; // wait for more data

                byte[] frame = rxBuffer.Skip(start).Take(frameLen).ToArray();
                rxBuffer = rxBuffer.Skip(start + frameLen).ToArray();

                ParseFrame(frame);
            }
        }

        private void ParseFrame(byte[] frame)
        {
            if (frame.Length < 6) return;
            if (frame[0] != 0x27 || frame[frame.Length - 1] != 0x16) return;

            if (frame.Length > 5 && frame[5] == 0x01)
            {
                OnStartRequested();
            }
        }

        private void OnStartRequested()
        {
            if (startTriggered) return; // prevent multiple triggers
            startTriggered = true;
            StartRequested?.Invoke(); // Form1 subscribes and calls btnStart_Click
        }
    }
}
