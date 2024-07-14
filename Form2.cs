using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;


namespace LiteCanSimProj
{
    public partial class Form2 : Form
    {
        StringBuilder sb;
        private const int BaudRate = 19200;
        private List<SerialPort> ports = new List<SerialPort>();
        private byte[][] buffers = new byte[2][];
        private State state;
        private object state_lock = new object();
        private bool stopping;
        public Form2()
        {
            InitializeComponent();
            sb = new StringBuilder();
            comboSerial1.DropDown += new EventHandler(Serial_DropDown);
            comboSerial2.DropDown += new EventHandler(Serial_DropDown);
            for (int index = 0; index < buffers.Length; ++index)
                buffers[index] = new byte[4096];

            // Populate the dropdowns initially
            PopulateSerialPorts(comboSerial1);
            PopulateSerialPorts(comboSerial2);

            btnBridge.Click += btnBridge_Click;
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
            else if (comboSerial1.SelectedItem == null || comboSerial2.SelectedItem == null)
            {
                MessageBox.Show("Both serial ports must be selected to begin bridging", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                ports.Add(new SerialPort((string)comboSerial1.SelectedItem, BaudRate));
                ports.Add(new SerialPort((string)comboSerial2.SelectedItem, BaudRate));
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
                comboSerial1.Enabled = false;
                comboSerial2.Enabled = false;
            }
        }
        private void bridge(SerialPort read_port, byte[] read_buffer, SerialPort write_port)
        {
            read_port.BaseStream.BeginRead(read_buffer, 0, read_buffer.Length, ar =>
            {
                int count;
                try
                {
                    count = read_port.BaseStream.EndRead(ar);
                }
                catch (Exception ex)
                {
                    lock (state_lock)
                    {
                        if (state == State.Running)
                            state = stopping ? State.Closing : State.GotError;
                    }
                    if (state != State.GotError)
                        return;
                    state = State.ErrorClosing;
                    Invoke((Action)(() =>
                    {
                        MessageBox.Show("Communications error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        stop_bridge();
                    }));
                    return;
                }
                write_port.Write(read_buffer, 0, count);
                bridge(read_port, read_buffer, write_port);

             


            }, null);
           
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
            comboSerial1.Enabled = true;
            comboSerial2.Enabled = true;
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
