using LiteCanSimProj._Globalz;
using LiteCanSimProj._MainUIs.CanManipUCs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiteCanSimProj._MainUIs.KvaserUCs
{
    public partial class ucf_KvaserCanModule : UserControl
    {
        int frameCount = 0;
        private List<UC_DataDisplayCTRL> _dataDisplayControls;
        public ucf_KvaserCanModule()
        {
            InitializeComponent();
            timer0_TestForm.Tick += new EventHandler(LOOP_Tick);
            timer0_TestForm.Interval = 400;
            timer0_TestForm.Start();
            timer0_TestForm.Enabled = false;

            checkBox_LoopRunning.CheckedChanged += new EventHandler(checkBox_LoopRunning_CheckedChanged);
            button1_initcan.Click += new EventHandler(button1_initcan_Click);
            button1_KillCan.Click += new EventHandler(button1_KillCan_Click);
            textBox_Rate.TextChanged += new EventHandler(textBox_Rate_TextChanged);
        }
        public void SetRefToListOfCtrls(List<UC_DataDisplayCTRL> arg_dataDisplayControls)
        {
            _dataDisplayControls = arg_dataDisplayControls; ;
        }
        private void textBox_Rate_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Rate.Text, out int newInterval) && newInterval >= 10 && newInterval <= 6000)
            {
                timer0_TestForm.Interval = newInterval;
            }
        }
        bool CheckifOnCan()
        {
            if (KvsrManager.Instance.GetIsOnBus())
            {
                lbl_bussStatus.BackColor = Color.Green;
                return true;
            }
            else
            {
                lbl_bussStatus.BackColor = Color.Red;
                return false;
            }
        }
        private void button1_initcan_Click(object sender, EventArgs e)
        {
            KvsrManager.Instance.Init(cb_dualChan.Checked);
            lbl_chinfo.Text = "sing ch: " + KvsrManager.Instance.GetChannelsFound();
            CheckifOnCan();
        }
        private void button1_KillCan_Click(object sender, EventArgs e)
        {
            KvsrManager.Instance.Close();
            CheckifOnCan();
            lbl_chinfo.Text = "ch: ";
        }
        private void checkBox_LoopRunning_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_LoopRunning.Checked)
            {
                timer0_TestForm.Enabled = true;
            }
            else
            {
                timer0_TestForm.Enabled = false;
            }
        }
        private void LOOP_Tick(object sender, EventArgs e)
        {
            label1_errors.Text = KvsrManager.Instance.GetErrorMessage();
            frameCount++;
            label4.Text = frameCount.ToString();
            if (!CheckifOnCan())
            {
                KvsrManager.Instance.Close();
                CheckifOnCan();
            }
            if (_dataDisplayControls.Count > 0)
            {
                foreach (UC_DataDisplayCTRL uc in _dataDisplayControls)
                {
                    if (uc.AllowSending)
                    {
                        int stat = KvsrManager.Instance.SendPGN_withStatus(uc.CanChannel, uc.MyPGN_INT, uc.Get_MyDatas());
                        if (stat != 0)
                        {
                            KvsrManager.Instance.Close();
                            CheckifOnCan();
                        }
                        label1_errors.Text = "";
                    }
                }
            }
        }
    }
}
