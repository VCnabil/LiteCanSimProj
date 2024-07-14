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
        private CancellationTokenSource cancellationTokenSource;
        public FormSerialTester()
        {
            InitializeComponent();
            comboBoxPorts.DropDown += new EventHandler(Serial_DropDown);
            PopulateSerialPorts(comboBoxPorts);
            btnStart.Click += btnStart_Click;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnStart.Text = "Stop";
            comboBoxPorts.Enabled = false;

            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => SendDataAsync(cancellationTokenSource.Token));
        }

        private void StopSendingData()
        {
            cancellationTokenSource.Cancel();
            serialPort.Close();
            btnStart.Text = "Start";
            comboBoxPorts.Enabled = true;
        }

        private async Task SendDataAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string message = $"<1,{trackBarSlider.Value},600,800,0,1,0,0>";
                try
                {
                    serialPort.Write(message);
                    Invoke(new Action(() =>
                    {
                        lblStatus.Text = $"Sent: {message}";
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Error writing to port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StopSendingData();
                    }));
                    break;
                }

                await Task.Delay(250, cancellationToken);
            }
        }
    }
}
