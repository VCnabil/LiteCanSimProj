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
        public BridgeFormSync()
        {
            InitializeComponent();
            messageBuffer = new StringBuilder();
            PCURSCbuffer = new byte[8192];
            AntennaSCbuffer = new byte[8192];

            comboBox_PCURSC.DropDown += new EventHandler(Serial_DropDown);
            comboBox_AntennaSC.DropDown += new EventHandler(Serial_DropDown);

            PopulateSerialPorts(comboBox_PCURSC);
            PopulateSerialPorts(comboBox_AntennaSC);
            btn_openSerialTester.Click += OnOpenTesterForm;
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

                Task.Run(() => BridgePorts(PCURSCport, PCURSCbuffer, AntennaSCport));
                Task.Run(() => BridgePorts(AntennaSCport, AntennaSCbuffer, PCURSCport));

                btnBridge.Text = "Stop Bridge";
                comboBox_PCURSC.Enabled = false;
                comboBox_AntennaSC.Enabled = false;
                checkBoxLaptopType.Enabled = false;
            }
        }
        private void BridgePorts(SerialPort readPort, byte[] readBuffer, SerialPort writePort)
        {
        
            try
            {
                while (state == State.Running)
                {
                    int count = readPort.Read(readBuffer, 0, readBuffer.Length);
                    if (count > 0)
                    {
                        string message = Encoding.ASCII.GetString(readBuffer, 0, count);
                        messageBuffer.Append(message);
                        ProcessMessages();

                        if (writePort.IsOpen)
                        {
                            //writePort.Write(readBuffer, 0, count);
                            Log($"Wrote {count} bytes to {writePort.PortName}.");
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
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Error during bridging: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    stop_bridge();
                }));
            }
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
            }
            else
            {
                isLaptopA_PCU = true;
                comboBox_AntennaSC.SelectedItem = "COM3";
                comboBox_PCURSC.SelectedItem = "COM4";
                lbl_PCname.Text = "Propulsion Control Unit";
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
                    //if message contains more than 1 '<' trim the message to the last '<'
                    if (message.Count(c => c == '<') > 1)
                    {
                        int index_of_last_ST = message.LastIndexOf('<');
                        message = message.Substring(index_of_last_ST);
                    }
                    if (message.Count(c => c == '>') > 1)
                    {
                        message = message.Substring(message.LastIndexOf('<'));
                    }

                    if (IsValid104Message(message)) // Check if it is a valid 104 message
                    {
                        if (isLaptopA_PCU)
                        {
                            WriteToPort(AntennaSCport, message); // Write to AntennaC port
                        }
                        else
                        {
                            WriteToPort(AntennaSCport, message); // Write to AntennaS port
                        }
                        DisplayMessage104(message);
                    }
                    else if (IsValid103Message(message)) // Check if it is a valid 103 message
                    {
                        if (isLaptopA_PCU)
                        {
                            WriteToPort(PCURSCport, message); // Write to PCUdevice port
                        }
                        else
                        {
                            WriteToPort(PCURSCport, message); // Write to RSCdevice port
                        }
                        DisplayMessage103(message);
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

        private bool IsValid104Message(string message)
        {
            int numberOfGTs = message.Count(c => c == '>');
            int numberOfSTs = message.Count(c => c == '<');
            if (numberOfGTs > 1) return false;
            if (numberOfSTs > 1) return false;

            int index_of_last_ST = message.LastIndexOf('<');
            int index_of_first_GT = message.IndexOf('>');


            if (message.StartsWith("<") && message.Count(c => c == ',') == 7 && message.EndsWith(">"))
            {
                return true;
            }
            return false;
        }

        private bool IsValid103Message(string message)
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

        private void DisplayMessage104(string message)
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
                Log($"Message '{message}' displayed in tb_104types.");
            }));
        }

        private void DisplayMessage103(string message)
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
                Log($"Message '{message}' displayed in tb_103types.");
            }));
        }

        private void stop_bridge()
        {
            if (stopping)
                return;
            stopping = true;
            state = State.Closing;

            Task.Run(() =>
            {
                if (PCURSCport != null && PCURSCport.IsOpen)
                {
                    PCURSCport.Close();
                    PCURSCport.Dispose();
                }
                if (AntennaSCport != null && AntennaSCport.IsOpen)
                {
                    AntennaSCport.Close();
                    AntennaSCport.Dispose();
                }

                Invoke(new Action(() =>
                {
                    btnBridge.Text = "Start Bridge";
                    comboBox_PCURSC.Enabled = true;
                    comboBox_AntennaSC.Enabled = true;
                    checkBoxLaptopType.Enabled = true;
                    stopping = false;
                    state = State.Idle;
                    Log("Bridge stopped.");
                }));
            });
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
