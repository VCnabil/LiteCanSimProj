using LiteCanSimProj._MainUIs.MainForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btn_mybridgedisplay.Click += Open_BridgeForm;
            btn_SerialBridgeForm.Click += Open_SerialBridgeForm;
            btn_FormSerialTester.Click += Open_FormSerialTester;
            btn_BridgeFormSync.Click += Open_BridgeFormSync;
            btn_CanManip.Click += Btn_CanManip_Click;
            btn_SeeThree.Click += Btn_SeeThree_Click;
        }

        private void Btn_SeeThree_Click(object sender, EventArgs e)
        {
            SeeThree form = new SeeThree();
            form.Show();
        }

        private void Btn_CanManip_Click(object sender, EventArgs e)
        {
            CanManip_V1Form form = new CanManip_V1Form();
            form.Show();
        }

        private void Open_FormSerialTester(object sender, EventArgs e)
        {
            FormSerialTester formSerialTester = new FormSerialTester();
            formSerialTester.Show();
        }

        private void Open_SerialBridgeForm(object sender, EventArgs e)
        {
            SerialBridgeForm serialBridgeForm = new SerialBridgeForm();
            serialBridgeForm.Show();
        }

      

        private void Open_BridgeForm(object sender, EventArgs e)
        {
           BridgeForm bridgeForm = new BridgeForm(cb_auto.Checked);
            bridgeForm.Show();
        }


        private void Open_BridgeFormSync(object sender, EventArgs e)
        {
            BridgeFormSync bridgeFormSync = new BridgeFormSync(cb_auto.Checked);
            bridgeFormSync.Show();
        }
    }
}
