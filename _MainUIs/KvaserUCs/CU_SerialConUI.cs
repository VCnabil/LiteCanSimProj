using LiteCanSimProj._Globalz;
using System;
using System.Windows.Forms;
using static LiteCanSimProj._Globalz.G_Properties;
using System.Diagnostics;
using System.IO.Ports;


namespace LiteCanSimProj._MainUIs.KvaserUCs
{
    public partial class CU_SerialConUI : UserControl
    {
        string _portSelectedName = "";
        public CU_SerialConUI()
        {
            _portSelectedName = G_DefaultPortName;
            InitializeComponent();
            SERIALMNGR_1.Instance.aPortHasOpened_orCloesdEVENT += Instance_aPortHasOpened_orCloesdEVENT;
            btn_YesAuto.Click += Btn_YesAuto_Click;
            btn_NoManual.Click += Btn_NoAuto_Click;
            btn_close.Click += Btn_close_Click;

            lbl_status.Text = "Auto.Con " + _portSelectedName + "?";

            lstCOMPorts.Visible = false;
            btn_NoManual.Visible = true;
            btn_YesAuto.Visible = true;
            btn_close.Visible = false;

            lstCOMPorts.Items.Clear();
            lstCOMPorts.DoubleClick += lstCOMPorts_DoubleClick;
            populatListbox();

            comboBoxBaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            comboBoxBaudRate.SelectedIndex = 1; // Default to 19200

    
            comboBoxHandshakes.Items.AddRange(new object[] { "None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff" });
            comboBoxHandshakes.SelectedIndex = 2; // Default to RequestToSend
            checkBox_RTS.Checked = true;

            comboBox_sendrate.Items.AddRange(new object[] { "25", "50", "100", "200", "250", "1000" });
            comboBox_sendrate.SelectedIndex = 2; // Default to 100ms

        }

        private void Instance_aPortHasOpened_orCloesdEVENT(string argPortName, bool argOpenedTrue_closedfalse)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        SfelyProcessPortHasOpenedOrclosed(argOpenedTrue_closedfalse);
                    }));
                }
                catch (Exception ex)
                {
                    Debug.Print("Error updating UI: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    SfelyProcessPortHasOpenedOrclosed(argOpenedTrue_closedfalse);
                }
                catch (Exception ex)
                {
                    Debug.Print("Error updating UI: " + ex.Message);
                }
            }
        }

        void SfelyProcessPortHasOpenedOrclosed(bool argOpen)
        {
            if (argOpen)
            {
                lbl_status.Text = "Connected " + _portSelectedName;
                btn_close.Visible = true;
                lstCOMPorts.Visible = false;
                btn_NoManual.Visible = false;
                btn_YesAuto.Visible = false;
                comboBoxBaudRate.Enabled = false;
                comboBoxHandshakes.Enabled = false;
                checkBox_RTS.Enabled = false;
            }
            else
            {
                lbl_status.Text = _portSelectedName + " Port is closed.";
                btn_close.Visible = false;
                btn_NoManual.Visible = true;
                btn_YesAuto.Visible = true;
                lstCOMPorts.Visible = false;
                comboBoxBaudRate.Enabled = true;
                comboBoxHandshakes.Enabled = true;
                checkBox_RTS.Enabled = true;
            }
        }

        private void lstCOMPorts_DoubleClick(object sender, EventArgs e)
        {
            if (lstCOMPorts.SelectedItem != null)
            {
                string selectedPort = lstCOMPorts.SelectedItem.ToString();
                int baudRate = int.Parse(comboBoxBaudRate.SelectedItem.ToString());
                Handshake handshake = (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshakes.SelectedItem.ToString());
                bool rtsEnable = checkBox_RTS.Checked;
                SERIALMNGR_1.Instance.OpenPort(selectedPort, baudRate, handshake, rtsEnable);
                _portSelectedName = selectedPort;
            }
            else
            {
                MessageBox.Show("Please select a COM port from the list.");
            }
        }

        bool populatListbox()
        {
            string[] ports = SERIALMNGR_1.Instance.GetAvailablePortNames();
            if (ports == null)
            {
                lbl_status.Text = "NO ports !";
                return false;
            }
            if (ports.Length == 0)
            {
                lbl_status.Text = "NO COM FOUND !";
                return false;
            }

            foreach (string port in ports)
            {
                lstCOMPorts.Items.Add(port);
            }
            return true;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            SERIALMNGR_1.Instance.ClosePort();
        }

        private void Btn_NoAuto_Click(object sender, EventArgs e)
        {
            btn_NoManual.Visible = false;
            btn_YesAuto.Visible = false;
            btn_close.Visible = true;
            lstCOMPorts.Visible = true;
            lstCOMPorts.Items.Clear();
            populatListbox();
        }

        private void Btn_YesAuto_Click(object sender, EventArgs e)
        {
            lstCOMPorts.Visible = false;
            btn_NoManual.Visible = false;
            btn_YesAuto.Visible = false;
            int baudRate = int.Parse(comboBoxBaudRate.SelectedItem.ToString());
            Handshake handshake = (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshakes.SelectedItem.ToString());
            bool rtsEnable = checkBox_RTS.Checked;
            SERIALMNGR_1.Instance.OpenPort(_portSelectedName, baudRate, handshake, rtsEnable);
        }
    }
}
