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

namespace LiteCanSimProj._MainUIs.debugUcs
{
    public partial class UC_ByteOutputControl : UserControl
    {
        Timer timerLoop = new Timer();
        byte outputByte = 0;
        byte[] _C3I_PGNdata18FE5600 = new byte[8];

        public UC_ByteOutputControl()
        {

            InitializeComponent();
            cb_can.Enabled = false;
            trackBar.Scroll += ControlValueChanged;
            checkBox_bit0.CheckedChanged += ControlValueChanged; 
            timerLoop.Interval = 250;
            timerLoop.Tick += TimerLoop_Tick;
            timerLoop.Start();
        }
        private void TimerLoop_Tick(object sender, EventArgs e)
        {
            _C3I_PGNdata18FE5600[0] = outputByte;
            cb_can.Checked = KvsrManager.Instance.GetIsOnBus();
            if (!cb_can.Checked) { return; }

            if (cb_allow.Checked) {
                KvsrManager.Instance.SendPGN_withStatus(1,0x18FE5600, _C3I_PGNdata18FE5600);
            }
        }

         private void ControlValueChanged(object sender, EventArgs e)
        {
            outputByte = 0;
            if (checkBox_bit0.Checked)
            {
                outputByte |= 0x01;
            }
            outputByte |= (byte)(trackBar.Value << 1);
            outputLabel.Text = $"Output: {outputByte}";
        }
    }
}
