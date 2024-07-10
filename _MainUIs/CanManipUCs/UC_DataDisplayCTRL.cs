using LiteCanSimProj._Serialization.DataObjectsDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LiteCanSimProj._Globalz.Helpers;
using static LiteCanSimProj._Globalz.G_Properties;

namespace LiteCanSimProj._MainUIs.CanManipUCs
{
    public partial class UC_DataDisplayCTRL : UserControl
    {
        byte[] bytes;
        Label[] mLabels;
        float _labelWidth;
        float _labelHeight;
        int _YpositionCursor = 0;
        public bool AllowSending { get; private set; }
        public int CanChannel { get; private set; }
        public int MyPGN_ID { get; private set; }
        public int MyPGN_INT { get; private set; }
        public string MyPGN_STRHEX { get; private set; }
        public byte[] Get_MyDatas()
        {
            return bytes;
        }
        public UC_DataDisplayCTRL(Pgn_DataObject argPGN_DataOB)
        {
            InitializeComponent();
            MyPGN_ID = argPGN_DataOB.IDpgn;
            MyPGN_INT = argPGN_DataOB.PGN_int;
            MyPGN_STRHEX = argPGN_DataOB.PGN_strHEX;
            CanChannel = 1;

            if (argPGN_DataOB.DESCpgn.Length > 2)
            {
                //if starts with "ch2" then channel is 1 . anything eles ch is 0 
                if (argPGN_DataOB.DESCpgn.Substring(0, 3) == "ch2")
                {
                    CanChannel = 2;
                }
                else
                {
                    CanChannel = 1;
                }
            }

            cb_allowSend.CheckedChanged += Cb_allowSend_CheckedChanged;
            cb_allowSend.Checked = true;
            AllowSending = true;
            bytes = new byte[8];
            bytes[0] = 0x00;
            bytes[1] = 0x00;
            bytes[2] = 0x00;
            bytes[3] = 0x00;
            bytes[4] = 0x00;
            bytes[5] = 0x00;
            bytes[6] = 0x00;
            bytes[7] = 0x00;
            mLabels = new Label[8];
            mLabels[0] = mlbl_B0;
            mLabels[1] = mlbl_B1;
            mLabels[2] = mlbl_B2;
            mLabels[3] = mlbl_B3;
            mLabels[4] = mlbl_B4;
            mLabels[5] = mlbl_B5;
            mLabels[6] = mlbl_B6;
            mLabels[7] = mlbl_B7;
            for (int i = 0; i < mLabels.Length; i++)
            {
                mLabels[i].Text = _baseKey;
                mLabels[i].Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Regular);
            }
            label_PGN_Dec.Text = "PGN: " + argPGN_DataOB.PGN_strHEX;
            label_PGN_Dec.Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Bold);
            label_PGN_Dec.Location = new Point(0, 0);
            label_PGN_Title.Text = argPGN_DataOB.DESCpgn;
            label_PGN_Title.Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Bold);
            UpdateLabelLocations();
            List<Ctrl_DataObject> _CtrlList = argPGN_DataOB.CtrlList;
            for (int i = 0; i < _CtrlList.Count; i++)
            {
                CtrlType ctrlType = StringToEnum_CtrlType(_CtrlList[i].CTRL_TYOE_STR);
                if (ctrlType == CtrlType._8_bG)
                {
                    _YpositionCursor += 1;
                }
                else
                {
                    UCManipMultiByte_CTRL uc_manip_LABEL = new UCManipMultiByte_CTRL(_CtrlList[i], this);
                    uc_manip_LABEL.Location = new Point(0, _YpositionCursor);
                    this.Controls.Add(uc_manip_LABEL);
                    _YpositionCursor += uc_manip_LABEL.Height + 1;
                }
            }
            this.Height = _YpositionCursor + 1;
        }
        void UpdateLabelLocations()
        {
            _labelWidth = G_Get_Base_FFF_Width() - 2;
            _labelHeight = G_Get_Base_FFF_Height();
            for (int i = 0; i < mLabels.Length; i++)
            {
                mLabels[i].Location = new Point((int)_labelWidth * i, (int)G_Get_Base_FFF_Height() + 1);
            }
            this.Width = G_Get_Base_PGN_Display_Width();
            _YpositionCursor = G_Get_Base_PGN_Display_Height();
            label_PGN_Title.Location = new Point(0, _YpositionCursor);
            _YpositionCursor += (int)G_Get_Base_FFF_Height() + 1;
        }
        public void Set_Display_LblColorsCodes(int argIndex, int argindex2, int arg_myID)
        {
            Set_lbl_color(argIndex, argindex2, arg_myID);
        }
        public void Highlight_Bold(int argIndex, int argindex2)
        {
            for (int i = argIndex; i <= argindex2; i++)
            {
                mLabels[i].Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Bold);
            }
        }
        public void Highlight_Regular(int argIndex, int argindex2)
        {
            for (int i = argIndex; i <= argindex2; i++)
            {
                mLabels[i].Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Regular);
            }
        }
        void UpdateDisplay(byte[] data)
        {
            if (data.Length > 0)
            {
                bytes = data;
                for (int i = 0; i < data.Length; i++)
                {
                    mLabels[i].Text = data[i].ToString("X2");
                }
            }
        }
        void Set_lbl_color(int argIndex, int argindex2, int arg_myID)
        {
            Color argColor = GetColorByIndex(arg_myID);

            for (int i = argIndex; i <= argindex2; i++)
            {
                mLabels[i].BackColor = argColor;
            }
            if (arg_myID <= 1)
            {
                for (int i = argIndex; i <= argindex2; i++)
                {
                    mLabels[i].ForeColor = Color.White;
                }
            }
        }
        public void Set_BytesToDisplay(int argIndexStart, int argIndexEnd, int argValue)
        {
            if (argIndexStart > argIndexEnd)
            {
                MessageBox.Show("problem, HI is smaller than LO");
                return;
            }
            if (argIndexEnd - argIndexStart == 0)
            {
                if (argValue > 255)
                    argValue = 255;
                else if (argValue < 0)
                    argValue = 0;

                bytes[argIndexStart] = (byte)argValue;
            }
            else
                if (argIndexEnd - argIndexStart == 1)
            {

                if (argValue > 65535)
                    argValue = 65535;
                else if (argValue < 0)
                    argValue = 0;

                bytes[argIndexStart] = (byte)(argValue & 0xFF);
                bytes[argIndexStart + 1] = (byte)((argValue >> 8) & 0xFF);

            }
            else
                if (argIndexEnd - argIndexStart == 2)
            {
                if (argValue > 16777215)
                    argValue = 16777215;
                else if (argValue < 0)
                    argValue = 0;

                bytes[argIndexStart] = (byte)(argValue & 0xFF);
                bytes[argIndexStart + 1] = (byte)((argValue >> 8) & 0xFF);
                bytes[argIndexStart + 2] = (byte)((argValue >> 16) & 0xFF);
            }
            else
                if (argIndexEnd - argIndexStart == 3)
                {
                    bytes[argIndexStart] = (byte)(argValue & 0xFF);
                    bytes[argIndexStart + 1] = (byte)((argValue >> 8) & 0xFF);
                    bytes[argIndexStart + 2] = (byte)((argValue >> 16) & 0xFF);
                    bytes[argIndexStart + 3] = (byte)((argValue >> 24) & 0xFF);
                }


            UpdateDisplay(bytes);
        }
        public void SetTitle_intPgnHex(int argPgn)
        {
            label_PGN_Dec.Text = "0x " + argPgn.ToString("X");
        }

        private void Cb_allowSend_CheckedChanged(object sender, EventArgs e)
        {
            AllowSending = cb_allowSend.Checked;
        }
    }
}
