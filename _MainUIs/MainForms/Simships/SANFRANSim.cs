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
    public partial class SANFRANSim : Form
    {
        Color ActiveCU1Color = Color.CornflowerBlue;
        Color ActiveCU2Color = Color.LightGreen;
        Timer timer;
        StringBuilder messageBuffer;
        int tickcount = 0;
        bool isOnBus;

        byte[] _logd__0cfff025 = new byte[] { 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x9F };
        byte[] _logd__0cfff125 = new byte[] { 0x3D, 0x0A, 0x58, 0x09, 0x4A, 0x08, 0x01, 0x00 };
        byte[] _logd__0cfff225 = new byte[] { 0xD4, 0x07, 0x18, 0x08, 0x18, 0x08, 0x01, 0x00 };
        byte[] _logd__0cff3134 = new byte[] { 0x01, 0x00, 0x00, 0x1B, 0x00, 0x01, 0x01, 0x00 };
        byte[] _logd__0cff8934 = new byte[] { 0x02, 0x00, 0x14, 0x99, 0x00, 0x00, 0x00, 0x00 };
        byte[] _logd__0cff3334 = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
        byte[] _logd__18ff1529 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] _logd__18fff329 = new byte[] { 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] _logd__18ff8f29 = new byte[] { 0x00, 0x04, 0x00, 0x00, 0xC3, 0x00, 0x66, 0x00 };
        byte[] _logd__18ff8d29 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
        byte[] _logd__18fefc29 = new byte[] { 0x00, 0x00, 0x00, 0x74, 0x00, 0x00, 0x00, 0x00 };
        byte[] _logd__18ff3029 = new byte[] { 0x01, 0x01, 0x55, 0x02, 0x00, 0x00, 0x00, 0x00 };
        byte[] _logd__18ff8c29 = new byte[] { 0x43, 0xF2, 0x03, 0x7C, 0x11, 0x00, 0x00, 0x00 };
        byte[] _logd__18ffa081 = new byte[] { 0x8D, 0x02, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa681 = new byte[] { 0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa181 = new byte[] { 0x16, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa481 = new byte[] { 0xC3, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa580 = new byte[] { 0x65, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa380 = new byte[] { 0x05, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa280 = new byte[] { 0x8D, 0x02, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__18ffa780 = new byte[] { 0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        byte[] _logd__19fa037f = new byte[] { 0x00, 0xD3, 0x32, 0x00, 0x5A, 0x00, 0xFF, 0x7F };
        byte[] _logd__19fa047f = new byte[] { 0x80, 0x93, 0x00, 0xFF, 0x0C, 0x05, 0xD0, 0x24 };
        byte[] _logd__1df11a7f = new byte[] { 0x00, 0xF6, 0xFF, 0xFF, 0xB6, 0x08, 0xFF, 0xFF };
        byte[] _logd__0df0107f = new byte[] { 0x00, 0xF0, 0xA2, 0x4D, 0x20, 0x56, 0xCD, 0x2A };
        byte[] _logd__09f1127f = new byte[] { 0x00, 0x17, 0xD4, 0xFF, 0x7F, 0xB6, 0x08, 0xFD };
        byte[] _logd__0df1137f = new byte[] { 0x00, 0x39, 0xEA, 0xFF, 0xFF, 0x01, 0xFF, 0xFF };
        byte[] _logd__09f8017f = new byte[] { 0x02, 0xBA, 0x92, 0x16, 0x6B, 0xE7, 0x02, 0xB7 };
        byte[] _logd__09f8027f = new byte[] { 0x00, 0xFC, 0x8D, 0xE2, 0x20, 0x01, 0xFF, 0xFF };
        byte[] _logd__0cf02ae2 = new byte[] { 0xB7, 0x7C, 0x4B, 0x7D, 0xB1, 0x7C, 0x00, 0x05 };
        byte[] _logd__0cf029e2 = new byte[] { 0xD6, 0x3D, 0x7D, 0xD9, 0x1A, 0x7C, 0x00, 0x05 };
        byte[] _logd__08f02de2 = new byte[] { 0xE7, 0x7C, 0x09, 0x7D, 0xD1, 0x80, 0x00, 0x00 };


        byte[] _pv78__0cff3334 = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x07, 0x08, 0x09 };
        byte[] _tester__18ff8829 = new byte[] { 0x08, 0x04, 0x07, 0x50, 0xC3, 0x90, 0x66, 0xa0 };


        private int currentAddress = 0x00;
    
        public SANFRANSim()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100; // Check every second
            timer.Tick += CheckIsOnBusStatus;
            timer.Start();
        }

        private void CheckIsOnBusStatus(object sender, EventArgs e)
        {
            isOnBus = KvsrManager.Instance.GetIsOnBus();
            tickcount++;
            //check every second 
            if (tickcount >= 4)
            {
                tickcount = 0;

                if (isOnBus)
                {
                    this.Text = "Kvaser is - On Bus";
                }
                else
                {
                    this.Text = "Kvaser is- Off Bus";
                }

               // Send_Logged_messages();
            }

            _tester__18ff8829[0] = (byte)tickcount;

            if (!isOnBus)
            {
                return;
            }

            send_All_neededInits();




        }

        void send_All_neededInits() {
            //byte[] _neededForINit__18FF8C29 = new byte[] { 0x43, 0xF2, 0x03, 0x7C, 0x11, 0x07, 0x08, 0x09 };
            //byte[] _neededForINit__0cff3334 = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x04, 0x07, 0x08, 0x09 };
            //byte[] _neededForINit__18FF0001 = new byte[] { 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //byte[] _neededForINit__18FF0101 = new byte[] { 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //byte[] _neededForINit__18FF0201 = new byte[] { 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //byte[] _neededForINit__18FF0301 = new byte[] { 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //byte[] _neededForINi__18ff8d29 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ff8f29 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //
            //byte[] _neededForINi__18fff329 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ff1603 = new byte[] { 0xf0, 0xf0, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ffa080 = new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ffa280 = new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ffa081 = new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ffa281 = new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            //byte[] _neededForINi__18ff1229 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };

            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF8C29, _neededForINit__18FF8C29);        
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x0cff3334, _neededForINit__0cff3334);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF0001, _neededForINit__18FF0001);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF0101, _neededForINit__18FF0101);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF0201, _neededForINit__18FF0201);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF0301, _neededForINit__18FF0301);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff8d29, _neededForINi__18ff8d29);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff8f29, _neededForINi__18ff8f29);
            //
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18fff329, _neededForINi__18fff329);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff1603, _neededForINi__18ff1603);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa080, _neededForINi__18ffa080);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa280, _neededForINi__18ffa280);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa081, _neededForINi__18ffa081);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa281, _neededForINi__18ffa281);
            //KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff1229, _neededForINi__18ff1229);

            byte[] _neededForINi__18fefc29 = new byte[] { 0x20, 0x30, 0x19, 0x21, 0x11, 0x01, 0x11, 0x11 };
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18fefc29, _neededForINi__18fefc29);


        }
        void Send_pv68_messages()
        {
            int basePGN = 0x18FF8C00;
            int pgn = basePGN | (int)currentAddress;

           // KvsrManager.Instance.SendPGN_withStatus(1, pgn, _neededForINit__18FF8C29);
            

            currentAddress++;
            if (currentAddress > 0xFF)
            {
                currentAddress = 0x00; // Reset the address to 0 after reaching 0xFF
            }
        }

  
        void Send_Logged_messages() {
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cfff025, _logd__0cfff025);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cfff125, _logd__0cfff125);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cfff225, _logd__0cfff225);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cff3134, _logd__0cff3134);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cff8934, _logd__0cff8934);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cff3334, _logd__0cff3334);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff1529, _logd__18ff1529);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18fff329, _logd__18fff329);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff8f29, _logd__18ff8f29);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff8d29, _logd__18ff8d29);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18fefc29, _logd__18fefc29);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff3029, _logd__18ff3029);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ff8c29, _logd__18ff8c29);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa081, _logd__18ffa081);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa681, _logd__18ffa681);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa181, _logd__18ffa181);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa481, _logd__18ffa481);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa580, _logd__18ffa580);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa380, _logd__18ffa380);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa280, _logd__18ffa280);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x18ffa780, _logd__18ffa780);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x19fa037f, _logd__19fa037f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x19fa047f, _logd__19fa047f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x1df11a7f, _logd__1df11a7f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0df0107f, _logd__0df0107f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x09f1127f, _logd__09f1127f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0df1137f, _logd__0df1137f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x09f8017f, _logd__09f8017f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x09f8027f, _logd__09f8027f);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cf02ae2, _logd__0cf02ae2);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x0cf029e2, _logd__0cf029e2);
            KvsrManager.Instance.SendPGN_withStatus(1, 0x08f02de2, _logd__08f02de2);
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
