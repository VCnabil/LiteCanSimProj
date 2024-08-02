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

namespace LiteCanSimProj._MainUIs.MainForms.Simships
{
    public partial class INFPB_MK3_AD : Form
    {
        Color ActiveCU1Color= Color.CornflowerBlue;
        Color ActiveCU2Color= Color.LightGreen;
        Timer timer;
        StringBuilder messageBuffer;
        int tickcount = 0;
        bool isOnBus;

        byte[] _core__FF90 = new byte[8];
        byte[] _core__FFA0 = new byte[8];
        byte[] _core__FFA1 = new byte[8];
        byte[] _core__FFAA = new byte[8];
        byte[] _core__FFB2 = new byte[8];
        byte[] _core__FFB3 = new byte[8];
        byte[] _core__FF8C_forCU1 = new byte[8];
        byte[] _core__FF8C_forCU2 = new byte[8];
        int FFAA_B2_dimmingKNob = 60;

        //faults FF8D
        byte[] _faults__FF8D = new byte[8];
        //stations commands
        byte[] _StaCMD_CU1__FF8E= new byte[8];
        byte[] _StaCMD_CU2__FF8E = new byte[8];

        byte[] _fbks_CU1_FEFC = new byte[8];
        byte[] _fbks_CU2_FEFC = new byte[8];
        public INFPB_MK3_AD()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 250; // Check every second
            timer.Tick += CheckIsOnBusStatus;
            timer.Start();

            // recorded raw data from the actual device
            // 57  EB  03  86  16  00  00  00
            _core__FF90[0] = 0x57;
            _core__FF90[1] = 0xEB;
            _core__FF90[2] = 0x03;
            _core__FF90[3] = 0x86;
            _core__FF90[4] = 0x16;
            _core__FF90[5] = 0x00;
            _core__FF90[6] = 0x00;
            _core__FF90[7] = 0x00;

            // A&M  recorded versions on can bus
            // 4F  00  E8  03  26  14  00  00  
            _core__FFA0[0] = 0x4F;
            _core__FFA0[1] = 0x00;
            _core__FFA0[2] = 0xE8;
            _core__FFA0[3] = 0x03;
            _core__FFA0[4] = 0x26;
            _core__FFA0[5] = 0x14;
            _core__FFA0[6] = 0x00;
            _core__FFA0[7] = 0x00;

            //recorded Cim
            //00  00  1B  65  E8  03  AC  13 
            _core__FFAA[0] = 0xFA;//historic max size (0-255)
            _core__FFAA[1] = 0x00;
            _core__FFAA[2] = 0x1B;//dimming knob
            _core__FFAA[3] = 0x65;
            _core__FFAA[4] = 0xE8;
            _core__FFAA[5] = 0x03;
            _core__FFAA[6] = 0xAC;
            _core__FFAA[7] = 0x13;


        }
        private void CheckIsOnBusStatus(object sender, EventArgs e)
        {
            if (rb_Active_CU1.Checked)
            {

                groupBox_ActiveCu.BackColor = ActiveCU1Color;
                groupBox_ActiveCu.Text = "Active CU1";
            }
            else
            {
                groupBox_ActiveCu.BackColor = ActiveCU2Color;
                groupBox_ActiveCu.Text = "Active CU2";
            }

            isOnBus = KvsrManager.Instance.GetIsOnBus();
            tickcount++;

            FFAA_B2_dimmingKNob = tb_DimmingKnob.Value;
            if (FFAA_B2_dimmingKNob > 255){FFAA_B2_dimmingKNob = 255;}
            if(FFAA_B2_dimmingKNob < 0){FFAA_B2_dimmingKNob = 0;}
            lbl_DimmingKnob.Text ="dimming:" + FFAA_B2_dimmingKNob.ToString();

            _core__FFAA[2]= (byte)FFAA_B2_dimmingKNob;
            //use the same value for FFB2 and FFB3 B4
            _core__FFB2[4] = (byte)FFAA_B2_dimmingKNob;
            _core__FFB3[4] = (byte)FFAA_B2_dimmingKNob;


            //  ============================================================================
            // 0xFF8C(system CU2 info)
            //
            //        - Byte0 : Clutch Command | XX * 18
            //                - b0 : rb_CU1_B0b0
            //                - b1 : rb_CU1_B0b1
            //                - b2 : rb_CU1_B0b2
            //                - b3 : rb_CU1_B0b3
            //                - b4 : rb_CU1_B0b4
            //                - b5 : rb_CU1_B0b5
            //                - b6 : N / A
            //                - b7 : N / A

            // Update _core__FF8C[0] based on the radio button states
            _core__FF8C_forCU1[0] = 0;
            if (rb_CU1_B0b0.Checked) _core__FF8C_forCU1[0] |= 1 << 0;
            if (rb_CU1_B0b1.Checked) _core__FF8C_forCU1[0] |= 1 << 1;
            if (rb_CU1_B0b2.Checked) _core__FF8C_forCU1[0] |= 1 << 2;
            if (rb_CU1_B0b3.Checked) _core__FF8C_forCU1[0] |= 1 << 3;
            if (rb_CU1_B0b4.Checked) _core__FF8C_forCU1[0] |= 1 << 4;
            if (rb_CU1_B0b5.Checked) _core__FF8C_forCU1[0] |= 1 << 5;

            _core__FF8C_forCU2[0] = 0;
            if (rb_CU1_B0b0.Checked) _core__FF8C_forCU2[0] |= 1 << 0;
            if (rb_CU1_B0b1.Checked) _core__FF8C_forCU2[0] |= 1 << 1;
            if (rb_CU1_B0b2.Checked) _core__FF8C_forCU2[0] |= 1 << 2;
            if (rb_CU1_B0b3.Checked) _core__FF8C_forCU2[0] |= 1 << 3;
            if (rb_CU1_B0b4.Checked) _core__FF8C_forCU2[0] |= 1 << 4;
            if (rb_CU1_B0b5.Checked) _core__FF8C_forCU2[0] |= 1 << 5;

            _core__FF8C_forCU1[1] = 0;
            if (rb_Active_CU1.Checked) _core__FF8C_forCU1[1] |= 1 << 1;


            _core__FF8C_forCU2[1] = 0;
            if (rb_Active_CU2.Checked) _core__FF8C_forCU2[1] |= 1 << 1;
            _core__FF8C_forCU1[2] = 0;
            _core__FF8C_forCU1[3] = 0;
            _core__FF8C_forCU1[4] = 0;
            _core__FF8C_forCU1[5] = 0;
            _core__FF8C_forCU1[2] = (byte)tb_PThro_AHD_1.Value; 
            _core__FF8C_forCU1[3] = (byte)tb_PThro_REV_1.Value;
            _core__FF8C_forCU1[4] = (byte)tb_SThro_AHD_1.Value;
            _core__FF8C_forCU1[5] = (byte)tb_SThro_REV_1.Value;

            _core__FF8C_forCU2[2] = 0;
            _core__FF8C_forCU2[3] = 0;
            _core__FF8C_forCU2[4] = 0;
            _core__FF8C_forCU2[5] = 0;
            _core__FF8C_forCU2[2] = (byte)tb_PThro_AHD_2.Value;
            _core__FF8C_forCU2[3] = (byte)tb_PThro_REV_2.Value;
            _core__FF8C_forCU2[4] = (byte)tb_SThro_AHD_2.Value;
            _core__FF8C_forCU2[5] = (byte)tb_SThro_REV_2.Value;


            _core__FF8C_forCU1[6] = 0;
            _core__FF8C_forCU2[6] = 0;

            if (rb_MainStation.Checked)
            {
                _core__FF8C_forCU1[6] = (byte)1;
                _core__FF8C_forCU2[6] = (byte)1;
            }
            else {
                _core__FF8C_forCU1[6] = (byte)2;
                _core__FF8C_forCU2[6] = (byte)2;

            }

            _StaCMD_CU1__FF8E[0] = 0;
            _StaCMD_CU1__FF8E[1] = 0;
            _StaCMD_CU1__FF8E[2] = 0;
            _StaCMD_CU1__FF8E[3] = 0;
            _StaCMD_CU1__FF8E[4] = 0;
            _StaCMD_CU1__FF8E[5] = 0;
            _StaCMD_CU1__FF8E[6] = 0;
            _StaCMD_CU1__FF8E[7] = 0;

            _StaCMD_CU1__FF8E[0] = (byte)tb_Ptrim_1.Value;
            _StaCMD_CU1__FF8E[1] = (byte)tb_Strim_1.Value;
            _StaCMD_CU1__FF8E[2] = (byte)tb_Helm_1.Value;
            //_StaCMD_CU1__FF8E[3] = (byte)tb_PThro_AHD_1.Value;
            //_StaCMD_CU1__FF8E[4] = (byte)tb_PThro_REV_1.Value;
            //_StaCMD_CU1__FF8E[5] = (byte)tb_SThro_AHD_1.Value;
            //_StaCMD_CU1__FF8E[6] = (byte)tb_SThro_REV_1.Value;
            if(cb_Sta1_REQ_B7_b0.Checked) _StaCMD_CU1__FF8E[7] |= 1 << 0;
            if(cb_Sta1_allow_B7_b1.Checked) _StaCMD_CU1__FF8E[7] |= 1 << 1;

            _StaCMD_CU2__FF8E[0] = 0;
            _StaCMD_CU2__FF8E[1] = 0;
            _StaCMD_CU2__FF8E[2] = 0;
            _StaCMD_CU2__FF8E[3] = 0;
            _StaCMD_CU2__FF8E[4] = 0;
            _StaCMD_CU2__FF8E[5] = 0;
            _StaCMD_CU2__FF8E[6] = 0;
            _StaCMD_CU2__FF8E[7] = 0;

            _StaCMD_CU2__FF8E[0] = (byte)tb_Ptrim_2.Value;
            _StaCMD_CU2__FF8E[1] = (byte)tb_Strim_2.Value;
            _StaCMD_CU2__FF8E[2] = (byte)tb_Helm_2.Value;
            //_StaCMD_CU2__FF8E[3] = (byte)tb_PThro_AHD_2.Value;
            //_StaCMD_CU2__FF8E[4] = (byte)tb_PThro_REV_2.Value;
            //_StaCMD_CU2__FF8E[5] = (byte)tb_SThro_AHD_2.Value;
            //_StaCMD_CU2__FF8E[6] = (byte)tb_SThro_REV_2.Value;
            if (cb_Sta2_REQ_B7_b0.Checked) _StaCMD_CU2__FF8E[7] |= 1 << 0;
            if (cb_Sta2_allow_B7_b1.Checked) _StaCMD_CU2__FF8E[7] |= 1 << 1;


            _fbks_CU1_FEFC[1] = 0;
            _fbks_CU1_FEFC[6] = 0;
            _fbks_CU1_FEFC[7] = 0;

            _fbks_CU1_FEFC[1] = (byte)tb_P_buck_fbk_1.Value;
            _fbks_CU1_FEFC[6] = (byte)tb_AD_Nozz_fbk_1.Value;
            _fbks_CU1_FEFC[7] = (byte)tb_S_buck_fbk_1.Value;

            _fbks_CU2_FEFC[1] = 0;
            _fbks_CU2_FEFC[6] = 0;
            _fbks_CU2_FEFC[7] = 0;

            _fbks_CU2_FEFC[1] = (byte)tb_P_buck_fbk_2.Value;
            _fbks_CU2_FEFC[6] = (byte)tb_AD_Nozz_fbk_2.Value;
            _fbks_CU2_FEFC[7] = (byte)tb_S_buck_fbk_2.Value;

            //check every second 
            if (tickcount >= 4) {
                tickcount = 0;

                if (isOnBus)
                {
                    this.Text = "Kvaser is - On Bus";
                }
                else
                {
                    this.Text = "Kvaser is- Off Bus";
                }
            }

            if (!isOnBus)
            {
                return;
            }

            //send FF90 Control Unit1 Software Version address is 00
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF9000, _core__FF90);
            //send FF90 Control Unit2 Software Version address is 01
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF9001, _core__FF90);

            //send FFA0 Control Unit1 Hardware Version address is 01
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFA001, _core__FFA0);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFA101, _core__FFA1);
            //send FFA0 Control Unit2 Hardware Version address is 02
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFA002, _core__FFA0);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFA102, _core__FFA1);

            //send FFAA cim address is 00 . this has the dimming knob value
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFAA00, _core__FFAA);
            //send FFB2 FFB3 address 00 and 01 with dimming on byte4 
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFB200, _core__FFB2);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFB300, _core__FFB3);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFB201, _core__FFB2);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FFB301, _core__FFB3);

            // Send the updated 0xFF8C message for CU2 info
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8C00, _core__FF8C_forCU1);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8C01, _core__FF8C_forCU2);



            //faults
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8D00, _faults__FF8D);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8D01, _faults__FF8D);


            //throt
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8E00, _StaCMD_CU1__FF8E);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8E01, _StaCMD_CU2__FF8E);
            //fbks
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FEFC00, _fbks_CU1_FEFC);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18FEFC01, _fbks_CU2_FEFC);
        }

        private void OnMessageReceived(string message)
        {
          //  MessageBox.Show(message, "CAN Message Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Unregister event handlers to avoid memory leaks
            KvsrManager.Instance.OnMessageReceived -= OnMessageReceived;
            timer.Stop();

        }
    }
}
