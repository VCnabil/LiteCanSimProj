using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj
{
    public partial class SerialBridgeForm : Form
    {
        private const int BaudRate = 19200;
        private List<SerialPort> ports = new List<SerialPort>();
        private byte[][] buffers = new byte[2][];
        private SerialBridgeForm.State state;
        private object state_lock = new object();
        private bool stopping;
        public SerialBridgeForm()
        {
            InitializeComponent();
            btnBridge.Click += btnBridge_Click;
            this.comboSerial1.DropDown += new EventHandler(this.Serial_DropDown);
            this.comboSerial2.DropDown += new EventHandler(this.Serial_DropDown);
            for (int index = 0; index < this.buffers.Length; ++index)
                this.buffers[index] = new byte[4096];
        }

        private void Serial_DropDown(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            ComboBox comboBox = (ComboBox)sender;
            object selectedItem = comboBox.SelectedItem;
            comboBox.Items.Clear();
            comboBox.Items.AddRange((object[])SerialPort.GetPortNames());
            comboBox.SelectedItem = selectedItem;
        }

        private void btnBridge_Click(object sender, EventArgs e)
        {
            if (this.ports.Count != 0)
                this.stop_bridge();
            else if (this.comboSerial1.SelectedItem == null || this.comboSerial2.SelectedItem == null)
            {
                int num1 = (int)MessageBox.Show("Both serial ports must be selected to begin bridging", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.ports.Add(new SerialPort((string)this.comboSerial1.SelectedItem, 19200));
                this.ports.Add(new SerialPort((string)this.comboSerial2.SelectedItem, 19200));
                this.state = SerialBridgeForm.State.Running;
                int index = 0;
                foreach (SerialPort port in this.ports)
                {
                    try
                    {
                        port.Open();
                    }
                    catch (Exception ex)
                    {
                        int num2 = (int)MessageBox.Show("Error opening port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.stop_bridge();
                        return;
                    }
                    this.bridge(port, this.buffers[index], this.ports[index ^ 1]);
                    ++index;
                }
                this.btnBridge.Text = "Stop Bridge";
                this.comboSerial1.Enabled = false;
                this.comboSerial2.Enabled = false;
            }
        }

        private void bridge(SerialPort read_port, byte[] read_buffer, SerialPort write_port) => read_port.BaseStream.BeginRead(read_buffer, 0, read_buffer.Length, (AsyncCallback)(ar =>
        {
            int count;
            try
            {
                count = read_port.BaseStream.EndRead(ar);
            }
            catch (Exception ex)
            {
                lock (this.state_lock)
                {
                    if (this.state == SerialBridgeForm.State.Running)
                        this.state = this.stopping ? SerialBridgeForm.State.Closing : SerialBridgeForm.State.GotError;
                }
                if (this.state != SerialBridgeForm.State.GotError)
                    return;
                this.state = SerialBridgeForm.State.ErrorClosing;
                this.Invoke((Action)(() =>
                {
                    int num = (int)MessageBox.Show("Communications error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.stop_bridge();
                }));
                return;
            }
            if (write_port.IsOpen) {
                if (read_port.IsOpen) { 
                    write_port.Write(read_buffer, 0, count);
                    this.bridge(read_port, read_buffer, write_port);
                
                }
            }
        }), (object)null);

        private void stop_bridge()
        {
            if (this.stopping)
                return;
            this.stopping = true;
            foreach (SerialPort port in this.ports)
                port.Close();
            this.ports.Clear();
            this.btnBridge.Text = "Start Bridge";
            this.comboSerial1.Enabled = true;
            this.comboSerial2.Enabled = true;
            this.stopping = false;
            this.state = SerialBridgeForm.State.Idle;
        }


        private enum State
        {
            Idle,
            Running,
            Closing,
            GotError,
            ErrorClosing,
        }
    }
}
