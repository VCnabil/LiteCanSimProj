using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj
{
    public partial class FormSerialTester : Form
    {
        private const int BaudRate = 19200;
        private SerialPort serialPort;
        private System.Windows.Forms.Timer sendTimer;
        public FormSerialTester()
        {
            InitializeComponent();
            comboBoxPorts.DropDown += new EventHandler(Serial_DropDown);
            PopulateSerialPorts(comboBoxPorts);
            btnStart.Click += btnStart_Click;

            sendTimer = new System.Windows.Forms.Timer();
            sendTimer.Interval = 250; // Set the timer interval to 250 ms
            sendTimer.Tick += SendTimer_Tick;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                StopSendingData();
            }
            else if (comboBoxPorts.SelectedItem == null)
            {
                MessageBox.Show("Select a serial port to start.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StartSendingData();
            }
        }

        private void StartSendingData()
        {
            serialPort = new SerialPort((string)comboBoxPorts.SelectedItem, BaudRate);

            try
            {
                serialPort.Open();
                Log("Serial port opened.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnStart.Text = "Stop";
            comboBoxPorts.Enabled = false;

            sendTimer.Start();
        }

        private void StopSendingData()
        {
            sendTimer.Stop();

            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

            btnStart.Text = "Start";
            comboBoxPorts.Enabled = true;
            lblStatus.Text = "Stopped";
            Log("Serial port closed.");
        }

        //private void SendTimer_Tick(object sender, EventArgs e)
        //{
        //    // Generate the message string with expected format
        //    string message = $"<1,{trackBarSlider.Value},900,1000,0,1,0,0>"; // Adjust values as needed
        //    try
        //    {
        //        serialPort.Write(message);
        //        Log($"Sent: {message}");
        //        lblStatus.Text = $"Sent: {message}";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error writing to port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        StopSendingData();
        //    }

        //}


        private void SendTimer_Tick(object sender, EventArgs e)
        {
            // Generate the message string with expected format
            string message = $"<A,{trackBarSlider.Value},500,400>"; // Adjust values as needed
            if (checkBox1.Checked) {

                message = textBox1.Text;
            }


            try
            {
                serialPort.Write(message+"\n");
                Log($"Sent: {message}");
                lblStatus.Text = $"Sent: {message}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopSendingData();
            }

        }

        private void Log(string message)
        {
            // Implement logging logic here, such as writing to a log file or console
            Console.WriteLine(message);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Dispose();
            }
        }
    }
}
