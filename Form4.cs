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
using static System.Windows.Forms.AxHost;

namespace LiteCanSimProj
{
    public partial class Form4 : Form
    {
        StringBuilder messageBuffer;
        private const int BaudRate = 19200;
        private List<SerialPort> ports = new List<SerialPort>();
        private byte[][] buffers = new byte[2][];
        private State state;
        private object state_lock = new object();
        private bool stopping;
        private bool isLaptopA_PCU;
        public Form4()
        {
            InitializeComponent();
            messageBuffer = new StringBuilder();
            comboBox_PCURSC.DropDown += new EventHandler(Serial_DropDown);
            comboBox_AntennaSC.DropDown += new EventHandler(Serial_DropDown);
            for (int index = 0; index < buffers.Length; ++index)
                buffers[index] = new byte[4096];

            PopulateSerialPorts(comboBox_PCURSC);
            PopulateSerialPorts(comboBox_AntennaSC);

            btnBridge.Click += btnBridge_Click;
            checkBoxLaptopType.CheckedChanged += CheckBoxLaptopType_CheckedChanged;
        }
        private void CheckBoxLaptopType_CheckedChanged(object sender, EventArgs e)
        {
            isLaptopA_PCU = checkBoxLaptopType.Checked;
        }

        private void PopulateSerialPorts(ComboBox comboBox)
        {
            try
            {
                object selectedItem = comboBox.SelectedItem;
                comboBox.Items.Clear();
                string[] portNames = SerialPort.GetPortNames();
                if (portNames.Length == 0)
                {
                    MessageBox.Show("No serial ports found on this system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                comboBox.Items.AddRange(portNames);
                comboBox.SelectedItem = selectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching serial ports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Serial_DropDown(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            ComboBox comboBox = (ComboBox)sender;
            object selectedItem = comboBox.SelectedItem;
            comboBox.Items.Clear();
            comboBox.Items.AddRange(SerialPort.GetPortNames());
            comboBox.SelectedItem = selectedItem;
        }

        private void btnBridge_Click(object sender, EventArgs e)
        {
            if (ports.Count != 0)
                stop_bridge();
            else if (comboBox_PCURSC.SelectedItem == null || comboBox_AntennaSC.SelectedItem == null)
            {
                MessageBox.Show("Both serial ports must be selected to begin bridging", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                ports.Add(new SerialPort((string)comboBox_PCURSC.SelectedItem, BaudRate));
                ports.Add(new SerialPort((string)comboBox_AntennaSC.SelectedItem, BaudRate));
                state = State.Running;
                int index = 0;
                foreach (SerialPort port in ports)
                {
                    try
                    {
                        port.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        stop_bridge();
                        return;
                    }
                    bridge(port, buffers[index], ports[index ^ 1]);
                    ++index;
                }
                btnBridge.Text = "Stop Bridge";
                comboBox_PCURSC.Enabled = false;
                comboBox_AntennaSC.Enabled = false;
            }
        }

        private void bridge(SerialPort read_port, byte[] read_buffer, SerialPort write_port)
        {
            AsyncCallback callback = new AsyncCallback(ReadCallback);
            read_port.BaseStream.BeginRead(read_buffer, 0, read_buffer.Length, callback, new object[] { read_port, read_buffer, write_port });
        }

        private void ReadCallback(IAsyncResult ar)
        {
            object[] state = (object[])ar.AsyncState;
            SerialPort read_port = (SerialPort)state[0];
            byte[] read_buffer = (byte[])state[1];
            SerialPort write_port = (SerialPort)state[2];
            int count;

            try
            {
                count = read_port.BaseStream.EndRead(ar);
            }
            catch (Exception ex)
            {
                lock (state_lock)
                {
                    if (this.state == State.Running)
                        this.state = stopping ? State.Closing : State.GotError;
                }
                if (this.state != State.GotError)
                    return;
                this.state = State.ErrorClosing;
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Communications error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    stop_bridge();
                }));
                return;
            }

            if (count > 0)
            {
                messageBuffer.Append(Encoding.ASCII.GetString(read_buffer, 0, count));
                ProcessMessages();

                if (write_port.IsOpen)
                {
                    try
                    {
                        write_port.Write(read_buffer, 0, count);
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("Error writing to port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            stop_bridge();
                        }));
                        return;
                    }
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Write port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        stop_bridge();
                    }));
                    return;
                }

                bridge(read_port, read_buffer, write_port);
            }
        }

        private void ProcessMessages()
        {
            string bufferContent = messageBuffer.ToString();
            if (string.IsNullOrEmpty(bufferContent))
                return;

            int startIdx = bufferContent.IndexOf('<');
            int endIdx = bufferContent.IndexOf('>');

            while (startIdx != -1 && endIdx != -1 && endIdx > startIdx)
            {
                if (startIdx >= 0 && endIdx > startIdx && endIdx < bufferContent.Length)
                {
                    string message = bufferContent.Substring(startIdx, endIdx - startIdx + 1);

                    if (message.Count(c => c == ',') == 7) // Assuming this indicates a 104 message
                    {
                        if (isLaptopA_PCU)
                        {
                            WriteToPort(ports[0], message); // Write to AntennaC port
                        }
                        else
                        {
                            WriteToPort(ports[1], message); // Write to AntennaS port
                        }
                        DisplayMessage104(message);
                    }
                    else if (message.StartsWith("<A") && message.Count(c => c == ',') == 3) // Assuming this indicates a 103 message
                    {
                        if (isLaptopA_PCU)
                        {
                            WriteToPort(ports[1], message); // Write to PCUdevice port
                        }
                        else
                        {
                            WriteToPort(ports[0], message); // Write to RSCdevice port
                        }
                        DisplayMessage103(message);
                    }
                }

                if (endIdx + 1 < bufferContent.Length)
                {
                    bufferContent = bufferContent.Substring(endIdx + 1);
                }
                else
                {
                    bufferContent = string.Empty;
                }

                startIdx = bufferContent.IndexOf('<');
                endIdx = bufferContent.IndexOf('>');
            }

            messageBuffer.Clear();
            if (!string.IsNullOrEmpty(bufferContent))
            {
                messageBuffer.Append(bufferContent);
            }
        }

        private void WriteToPort(SerialPort port, string message)
        {
            if (port.IsOpen)
            {
                port.Write(message);
            }
        }

        private void DisplayMessage104(string message)
        {
            Invoke(new Action(() =>
            {
                tb_103types.AppendText(message + Environment.NewLine);
            }));
        }

        private void DisplayMessage103(string message)
        {
            Invoke(new Action(() =>
            {
                tb_104types.AppendText(message + Environment.NewLine);
            }));
        }

        private void stop_bridge()
        {
            if (stopping)
                return;
            stopping = true;
            foreach (SerialPort port in ports)
                port.Close();
            ports.Clear();
            btnBridge.Text = "Start Bridge";
            comboBox_PCURSC.Enabled = true;
            comboBox_AntennaSC.Enabled = true;
            stopping = false;
            state = State.Idle;
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
