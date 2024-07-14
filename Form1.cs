using LiteCanSimProj._Globalz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace LiteCanSimProj
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort1;
        private SerialPort serialPort2;
        private byte[] buffer1 = new byte[4096];
        private byte[] buffer2 = new byte[4096];
        private bool isBridging = false;
        string testStr = "<01,helm,123,456>";
        string teststr2 = "<A01,helm,123,456>";
        public Form1()
        {
            InitializeComponent();
            SERIALMNGR_1.Instance.RegisterDataReceivedHandler(OnSerialDataReceived1);
            SERIALMNGR_1.Instance.RegisterPortOpenedClosedHandler(OnPortOpenedClosed1);
            button_send1.Click += Button_send_Click;
            checkBox_autoSend1.Enabled = false;
            button_send1.Enabled = false;
            textBoxReceived1.Enabled = false;

            SERIALMNGR_2.Instance.RegisterDataReceivedHandler(OnSerialDataReceived2);
            SERIALMNGR_2.Instance.RegisterPortOpenedClosedHandler(OnPortOpenedClosed2);
            button_send2.Click += Button_send2_Click;
            checkBox_autoSend2.Enabled = false;
            button_send2.Enabled = false;
            textBoxReceived2.Enabled = false;


            timer1.Tick += Timer1_Tick;
            timer1.Interval = 380;
            timer1.Enabled = true;

            timer2.Tick += Timer2_Tick;
            timer2.Interval = 340;
            timer2.Enabled = true;

        }

        private void Button_send_Click(object sender, EventArgs e)
        {
            SERIALMNGR_1.Instance.SendMessage(textBox_messageToSend.Text);
        }
        private void Button_send2_Click(object sender, EventArgs e)
        {
            SERIALMNGR_2.Instance.SendMessage(textBox_messageToSend2.Text);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(checkBox_autoSend1.Checked)
            {
                SERIALMNGR_1.Instance.SendMessage(textBox_messageToSend.Text);
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox_autoSend2.Checked)
            {
                SERIALMNGR_2.Instance.SendMessage(textBox_messageToSend2.Text);
            }
        }


        private void BeginBridge(SerialPort readPort, byte[] buffer, SerialPort writePort)
        {
            readPort.BaseStream.BeginRead(buffer, 0, buffer.Length, ar =>
            {
                int count;
                try
                {
                    count = readPort.BaseStream.EndRead(ar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Communications error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    StopBridge();
                    return;
                }

                writePort.Write(buffer, 0, count);
                if (isBridging)
                {
                    BeginBridge(readPort, buffer, writePort);
                }
            }, null);
        }
        private void StopBridge()
        {
            if (!isBridging) return;

            isBridging = false;
            serialPort1?.Close();
            serialPort2?.Close();
            button_bridge.Text = "Start Bridge";
        }
        private void StartBridge()
        {

            serialPort1 = SERIALMNGR_1.Instance.GetActivatedPort();
            serialPort2 = SERIALMNGR_2.Instance.GetActivatedPort();
            if (serialPort1 == null || serialPort2 == null)
            {
                MessageBox.Show("Both serial ports must be selected to begin bridging", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                //serialPort1.Open();
                //serialPort2.Open();
                isBridging = true;
                button_bridge.Text = "Stop Bridge";
                BeginBridge(serialPort1, buffer1, serialPort2);
                BeginBridge(serialPort2, buffer2, serialPort1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                StopBridge();
            }
        }
        private void Button_bridge_Click(object sender, EventArgs e)
        {
            if (isBridging)
            {
                StopBridge();
            }
            else
            {
                StartBridge();
            }
        }

        private void OnSerialDataReceived1(string data)
        {   
            if (InvokeRequired)
            {
                Invoke(new Action(() => textBoxReceived1.AppendText(data + Environment.NewLine)));
            }
            else
            {
                textBoxReceived1.AppendText(data + Environment.NewLine);
            }
        }
        private void OnSerialDataReceived2(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => textBoxReceived2.AppendText(data + Environment.NewLine)));
            }
            else
            {
                textBoxReceived2.AppendText(data + Environment.NewLine);
            }
        }

        private void OnPortOpenedClosed1(string portName, bool opened)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (opened)
                    {
                        lblPortStatus.Text = portName + " opened";
                        checkBox_autoSend1.Enabled = true;
                        button_send1.Enabled = true;
                        textBoxReceived1.Enabled=true;
                        timer1.Start();
                    }
                    else
                    {
                        lblPortStatus.Text = portName + " closed";
                        checkBox_autoSend1.Enabled = false;
                        checkBox_autoSend1.Checked = false;
                        button_send1.Enabled = false;
                        textBoxReceived1.Enabled = false;
                        timer1.Stop();
                    }
                }));
            }
            else
            {
                if (opened)
                {
                    lblPortStatus.Text = portName + " opened";
                    checkBox_autoSend1.Enabled = true;
                    button_send1.Enabled = true;
                    textBoxReceived1.Enabled = true;
                    timer1.Start();
                }
                else
                {
                    lblPortStatus.Text = portName + " closed";
                    checkBox_autoSend1.Enabled = false;
                    checkBox_autoSend1.Checked = false;
                    button_send1.Enabled = false;
                    textBoxReceived1.Enabled = false;
                    timer1.Stop();
                }
            }
        }

        private void OnPortOpenedClosed2(string portName, bool opened)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (opened)
                    {
                        lblPortStatus2.Text = portName + " opened";
                        checkBox_autoSend2.Enabled = true;
                        button_send2.Enabled = true;
                        textBoxReceived2.Enabled = true;
                        timer2.Start();
                    }
                    else
                    {
                        lblPortStatus2.Text = portName + " closed";
                        checkBox_autoSend2.Enabled = false;
                        checkBox_autoSend2.Checked = false;
                        button_send2.Enabled = false;
                        textBoxReceived2.Enabled = false;
                        timer2.Stop();
                    }
                }));
            }
            else
            {
                if (opened)
                {
                    lblPortStatus.Text = portName + " opened";
                    checkBox_autoSend2.Enabled = true;
                    button_send2.Enabled = true;
                    textBoxReceived2.Enabled = true;
                    timer2.Start();
                }
                else
                {
                    lblPortStatus2.Text = portName + " closed";
                    checkBox_autoSend2.Enabled = false;
                    checkBox_autoSend2.Checked = false;
                    button_send2.Enabled = false;
                    textBoxReceived2.Enabled = false;
                    timer2.Stop();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SERIALMNGR_1.Instance.ClosePort();
            SERIALMNGR_1.Instance.UnregisterDataReceivedHandler(OnSerialDataReceived1);
            SERIALMNGR_1.Instance.UnregisterPortOpenedClosedHandler(OnPortOpenedClosed1);

            SERIALMNGR_2.Instance.ClosePort();
            SERIALMNGR_2.Instance.UnregisterDataReceivedHandler(OnSerialDataReceived2);
            SERIALMNGR_2.Instance.UnregisterPortOpenedClosedHandler(OnPortOpenedClosed2);
            base.OnFormClosed(e);
        }
    }
}
