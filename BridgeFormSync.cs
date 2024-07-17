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
    public partial class BridgeFormSync : Form
    {
        bool DisplayLog = false;
        bool AutoSetup = true;
        StringBuilder messageBuffer;
        private const int BaudRate = 19200;
        private SerialPort PCURSCport;
        private SerialPort AntennaSCport;
        private byte[] PCURSCbuffer;
        private byte[] AntennaSCbuffer;
        private State state;
        private object state_lock = new object();
        private bool stopping;
        private bool isLaptopA_PCU;
        private int lineNumber104 = 1;
        private int lineNumber103 = 1;
        private Color _initialBackGroundColor;
        private Color _Beige = Color.Beige;
        private Color _paleblue = Color.PaleTurquoise;
        int helmA_int, joyYA_int, joyXA_int;
        int helm1_int, joyY1_int, joyX1_int;
        public BridgeFormSync()
        {
            InitializeComponent();
            messageBuffer = new StringBuilder();
            PCURSCbuffer = new byte[8192]; // Increase buffer size to 8192 bytes
            AntennaSCbuffer = new byte[8192]; // Increase buffer size to 8192 bytes

            comboBox_PCURSC.DropDown += new EventHandler(Serial_DropDown);
            comboBox_AntennaSC.DropDown += new EventHandler(Serial_DropDown);

            PopulateSerialPorts(comboBox_PCURSC);
            PopulateSerialPorts(comboBox_AntennaSC);

            btnBridge.Click += btnBridge_Click;
            checkBoxLaptopType.CheckedChanged += CheckBoxLaptopType_CheckedChanged;
            if (AutoSetup)
            {
                AutoSetupConfiguration();
            }
            else
            {
                lbl_PCname.Text = Environment.MachineName;
            }
            checkBoxLaptopType.Text = " isLaptopA_PCU PCU ? SIMPLE";


        }

        public BridgeFormSync(bool argIsAuto)
        {
            AutoSetup = argIsAuto;
            InitializeComponent();
            messageBuffer = new StringBuilder();
            PCURSCbuffer = new byte[8192]; // Increase buffer size to 8192 bytes
            AntennaSCbuffer = new byte[8192]; // Increase buffer size to 8192 bytes

            comboBox_PCURSC.DropDown += new EventHandler(Serial_DropDown);
            comboBox_AntennaSC.DropDown += new EventHandler(Serial_DropDown);

            PopulateSerialPorts(comboBox_PCURSC);
            PopulateSerialPorts(comboBox_AntennaSC);

            btnBridge.Click += btnBridge_Click;
            checkBoxLaptopType.CheckedChanged += CheckBoxLaptopType_CheckedChanged;
            if (AutoSetup)
            {
                AutoSetupConfiguration();
            }
            else
            {
                lbl_PCname.Text = Environment.MachineName;
            }
            checkBoxLaptopType.Text = " isLaptopA_PCU PCU ? SIMPLE";


        }
        private void OnOpenTesterForm(object sender, EventArgs e)
        {

            //open the FormSerialTester 
            FormSerialTester formSerialTester = new FormSerialTester();
            formSerialTester.Show();


        }
        private void AutoSetupConfiguration()
        {
            if (Environment.MachineName.Contains("NABIL"))
            {
                isLaptopA_PCU = false;
                comboBox_AntennaSC.SelectedItem = "COM10";
                comboBox_PCURSC.SelectedItem = "COM9";
                lbl_PCname.Text = "Remote Station Contoler";
                this.BackColor = _Beige;
            }
            else
            {
                isLaptopA_PCU = true;
                comboBox_AntennaSC.SelectedItem = "COM3";
                comboBox_PCURSC.SelectedItem = "COM4";
                lbl_PCname.Text = "Propulsion Control Unit";
                this.BackColor = _paleblue;
            }

            checkBoxLaptopType.Enabled = false;
            comboBox_AntennaSC.Enabled = false;
            comboBox_PCURSC.Enabled = false;

            if (isLaptopA_PCU)
            {
                lbl_104.Text = "Received over Radio";
                lbl_103.Text = "Sending Over Radio";
            }
            else
            {
                lbl_103.Text = "Received over Radio";
                lbl_104.Text = "Sending Over Radio";
            }
        }
        private void CheckBoxLaptopType_CheckedChanged(object sender, EventArgs e)
        {
            isLaptopA_PCU = checkBoxLaptopType.Checked;
            if (isLaptopA_PCU)
            {
                lbl_104.Text = "Received over Radio";
                lbl_103.Text = "Sending Over Radio";

            }
            else
            {
                lbl_103.Text = "Received over Radio";
                lbl_104.Text = "Sending Over Radio";

            }
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
            if (PCURSCport != null && AntennaSCport != null && PCURSCport.IsOpen && AntennaSCport.IsOpen)
            {
                stop_bridge();
                checkBoxLaptopType.Enabled = true;
            }
            else if (comboBox_PCURSC.SelectedItem == null || comboBox_AntennaSC.SelectedItem == null)
            {
                MessageBox.Show("Both serial ports must be selected to begin bridging", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                PCURSCport = new SerialPort((string)comboBox_PCURSC.SelectedItem, BaudRate);
                AntennaSCport = new SerialPort((string)comboBox_AntennaSC.SelectedItem, BaudRate);
                state = State.Running;

                try
                {
                    PCURSCport.Open();
                    AntennaSCport.Open();
                    Log("Ports opened successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    stop_bridge();
                    return;
                }

                bridge(PCURSCport, PCURSCbuffer, AntennaSCport);
                bridge(AntennaSCport, AntennaSCbuffer, PCURSCport);

                btnBridge.Text = "Stop Bridge";
                comboBox_PCURSC.Enabled = false;
                comboBox_AntennaSC.Enabled = false;
                checkBoxLaptopType.Enabled = false;
            }
        }

        private void bridge(SerialPort read_port, byte[] read_buffer, SerialPort write_port)
        {
            AsyncCallback callback = new AsyncCallback(ReadCallback);
            read_port.BaseStream.BeginRead(read_buffer, 0, read_buffer.Length, callback, new object[] { read_port, read_buffer, write_port });
            Log($"Started bridging between {read_port.PortName} and {write_port.PortName}.");
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
                Log($"Read {count} bytes from {read_port.PortName}.");
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
                string message = Encoding.ASCII.GetString(read_buffer, 0, count);
                messageBuffer.Append(message);
                ProcessMessages();
 




                if (write_port.IsOpen)
                {
                    try
                    {
                        write_port.Write(read_buffer, 0, count);
                        Log($"Wrote {count} bytes to {write_port.PortName}.");
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
            while (startIdx != -1)
            {
                int endIdx = bufferContent.IndexOf('>', startIdx);
                if (endIdx != -1)
                {
                    string message = bufferContent.Substring(startIdx, endIdx - startIdx + 1);
                    // If message contains more than 1 '<' trim the message to the last '<'
                    if (message.Count(c => c == '<') > 1)
                    {
                        int index_of_last_ST = message.LastIndexOf('<');
                        message = message.Substring(index_of_last_ST);
                    }
                    if (message.Count(c => c == '>') > 1)
                    {
                        message = message.Substring(message.LastIndexOf('>') + 1);
                    }

                    if (IsValid104Message(message, out helm1_int, out joyX1_int, out joyY1_int)) // Check if it is a valid 104 message
                    {
                        if (isLaptopA_PCU)
                        {
                            WriteToPort(AntennaSCport, message); // Write to AntennaSC port
                        }
                        else
                        {
                            WriteToPort(AntennaSCport, message); // Write to AntennaSC port
                        }
                        DisplayMessage104(message, helm1_int, joyX1_int, joyY1_int);
                    }
                    else if (IsValid103Message(message, out helmA_int, out joyXA_int, out joyYA_int)) // Check if it is a valid 103 message
                    {
                        if (isLaptopA_PCU)
                        {
                            WriteToPort(PCURSCport, message); // Write to PCU device port
                        }
                        else
                        {
                            WriteToPort(PCURSCport, message); // Write to RSC device port
                        }
                        DisplayMessage103(message, helmA_int, joyXA_int, joyYA_int);
                    }

                    bufferContent = bufferContent.Substring(endIdx + 1);
                    startIdx = bufferContent.IndexOf('<');
                }
                else
                {
                    break;
                }
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
                Log($"Message '{message}' written to {port.PortName}.");
            }
            else
            {
                Log($"Attempted to write to closed port {port.PortName}.");
            }
        }


        private bool IsValid104Message(string message, out int helm1_int, out int joyx1_int, out int joyy1_int)
        {
            helm1_int = joyx1_int = joyy1_int = 0; // Initialize output parameters

            // Check the basic structure
            if (message.StartsWith("<") && message.EndsWith(">"))
            {
                // Remove the start and end characters
                string content = message.Substring(1, message.Length - 2);

                // Split the content by commas
                string[] parts = content.Split(',');

                // Ensure there are exactly eight parts
                if (parts.Length != 8)
                {
                    return false;
                }

                // Validate and extract the specific integer values
                if (int.TryParse(parts[1], out helm1_int) &&
                    int.TryParse(parts[2], out joyx1_int) &&
                    int.TryParse(parts[3], out joyy1_int))
                {
                    // All checks passed and values extracted
                    return true;
                }
            }

            // Structure does not match or parsing failed
            return false;
        }


        private bool IsValid103Messagesimple(string message)
        {
            int numberOfGTs = message.Count(c => c == '<');
            int numberOfSTs = message.Count(c => c == '>');
            if (numberOfGTs > 1) return false;
            if (numberOfSTs > 1) return false;

            if (message.StartsWith("<A") && message.Count(c => c == ',') == 3 && message.EndsWith(">"))
            {
                return true;
            }
            return false;
        }
        private bool IsValid103Message(string message, out int value1, out int value2, out int value3)
        {
            value1 = value2 = value3 = 0; // Initialize output parameters

            // Check the basic structure
            if (message.StartsWith("<A") && message.Count(c => c == ',') == 3 && message.EndsWith(">"))
            {

                string content = message.Substring(0, message.Length - 1);

                // Split the content by commas
                string[] parts = content.Split(',');



                //string helm = parts[1];
                //string joyX = parts[2];
                //string joyY = parts[3];


                //// Validate and extract the specific integer values
                //if (int.TryParse(helm, out value1) &&
                //    int.TryParse(joyX, out value2) &&
                //    int.TryParse(joyY, out value3))
                //{
                //    // All checks passed and values extracted
                //    return true;
                //}

                // Validate that each part is an integer and extract the values
                if (int.TryParse(parts[1], out value1) && int.TryParse(parts[2], out value2) && int.TryParse(parts[3], out value3))
                {
                    // All checks passed and values extracted
                    return true;
                }
            }

            // Structure does not match or parsing failed
            return false;
        }



        private void DisplayMessage103(string message, int helmA_int, int joyXA_int, int joyYA_int)
        {
            Invoke(new Action(() =>
            {
                string formattedMessage = $"{lineNumber103}: {message}{Environment.NewLine}";
                lineNumber103++;

                if (tb_103types.Lines.Length >= 24)
                {
                    tb_103types.Clear();
                }

                tb_103types.AppendText(formattedMessage);

                // Display the extracted values
                lbl_Ahelm.Text = helmA_int.ToString();
                lbl_AjoyX.Text = joyXA_int.ToString();
                lbl_AjoyY.Text = joyYA_int.ToString();

                Log($"Message '{message}' displayed in tb_103types.");
            }));
        }

    


        private void DisplayMessage104(string message, int helm1_int, int joyx1_int, int joyy1_int)
        {
            Invoke(new Action(() =>
            {
                string formattedMessage = $"{lineNumber104}: {message}{Environment.NewLine}";
                lineNumber104++;

                if (tb_104types.Lines.Length >= 24)
                {
                    tb_104types.Clear();
                }

                tb_104types.AppendText(formattedMessage);

                // Display the extracted values
                lbl_1helm.Text = helm1_int.ToString();
                lbl_1joyX.Text = joyx1_int.ToString();
                lbl_1joyY.Text = joyy1_int.ToString();

                Log($"Message '{message}' displayed in tb_104types.");
            }));
        }

        private void stop_bridge()
        {
            if (stopping)
                return;
            stopping = true;
            if (PCURSCport != null && PCURSCport.IsOpen)
                PCURSCport.Close();
            if (AntennaSCport != null && AntennaSCport.IsOpen)
                AntennaSCport.Close();

            btnBridge.Text = "Start Bridge";
            comboBox_PCURSC.Enabled = true;
            comboBox_AntennaSC.Enabled = true;
            stopping = false;
            state = State.Idle;
            Log("Bridge stopped.");
        }

        private void Log(string message)
        {
            // Implement your logging logic here, e.g., write to a log file or console
            if (DisplayLog) Console.WriteLine(message);
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
