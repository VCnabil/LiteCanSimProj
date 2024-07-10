using LiteCanSimProj._Globalz;
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
    public partial class UCManipMultiByte_CTRL : UserControl
    {
        UC_DataDisplayCTRL _myUC_PGN_Displayer;
        int _myID = 0;
        int _myMin = 0;
        uint _myMax = 0;
        int _myDefVal = 0;
        //fyi: _my_lo_index and _my_hi_index will mean an index range for _3_by ad _4_by types
        int _my_lo_indx = 0;
        int _my_hi_indx = 0;
        string _myDesc = "";
        Color borderColor;
        CtrlType _myType;
        int Y_Cursor = 0;
        int standardRowHeight = 20;
        float minimum_Height = 82.0f;
        float minimum_Width = 300.0f;
        int yCursor = 0;
        bool _IsSLider;
        int CU_VALUE_INT;
        CheckBox[] myCbs;
        bool[] my_Default_bitsStates;
        // variables for auto sliding pingpong
        Random RANDO;
        int _my_set_min = 0;
        int _my_set_max = 100;
        int _my_set_step = 1;
        bool _Increasing = true;
        int _my_set_curVal = 8;
        void Do_pingpong()
        {
            if (!_IsSLider) return;
            if (_my_set_max > 255)
            {
                DoPinpongForLArgValues();
            }
            else
            {
                DoPinpongForSmallValues();
            }

        }
        void DoPinpongForLArgValues()
        {
            if (_Increasing)
            {
                if (_my_set_curVal < _my_set_max)
                {
                    _my_set_curVal += _my_set_step;
                }
                else
                {
                    _Increasing = false;
                    _my_set_curVal -= _my_set_step;
                }
            }
            else
            {
                if (_my_set_curVal > _my_set_min)
                {
                    _my_set_curVal -= _my_set_step;
                }
                else
                {
                    _Increasing = true;
                    _my_set_curVal += _my_set_step;
                }
            }
            tb_Slider.Value = Math.Min(Math.Max(tb_Slider.Minimum, _my_set_curVal), tb_Slider.Maximum); // Update trackbar, ensuring value is within bounds
        }
        int smallalueStepper = 0;
        void DoPinpongForSmallValues()
        {
            smallalueStepper++;
            if (smallalueStepper > 5) smallalueStepper = 0;
            if (smallalueStepper == 0)
            {
                if (_Increasing)
                {
                    if (_my_set_curVal < _my_set_max)
                    {
                        _my_set_curVal += _my_set_step;
                    }
                    else
                    {
                        _Increasing = false;
                        _my_set_curVal -= _my_set_step;
                    }
                }
                else
                {
                    if (_my_set_curVal > _my_set_min)
                    {
                        _my_set_curVal -= _my_set_step;
                    }
                    else
                    {
                        _Increasing = true;
                        _my_set_curVal += _my_set_step;
                    }
                }
                tb_Slider.Value = Math.Min(Math.Max(tb_Slider.Minimum, _my_set_curVal), tb_Slider.Maximum);
            }
        }
        public UCManipMultiByte_CTRL(Ctrl_DataObject argCTRL_DO, UC_DataDisplayCTRL arg_HeadDisplayer)
        {
            RANDO = new Random();
            _myUC_PGN_Displayer = arg_HeadDisplayer;
            InitializeComponent();
            if (G_Base_Sizes_wereSet())
            {
                standardRowHeight = (int)G_Get_Base_FFF_Height() + 1;
                minimum_Width = G_Get_Base_PGN_Display_Width();
            }
            myCbs = new CheckBox[8];
            myCbs[0] = cb_b0;
            myCbs[1] = cb_b1;
            myCbs[2] = cb_b2;
            myCbs[3] = cb_b3;
            myCbs[4] = cb_b4;
            myCbs[5] = cb_b5;
            myCbs[6] = cb_b6;
            myCbs[7] = cb_b7;
            for (int x = 0; x < myCbs.Length; x++)
            {
                myCbs[x].Text = "";
                myCbs[x].Enabled = false;
                myCbs[x].Hide();
            }
            my_Default_bitsStates = new bool[8];
            for (int i = 0; i < my_Default_bitsStates.Length; i++)
            {
                my_Default_bitsStates[i] = false;
            }
            Init_Default_minMaxValues_According_to_CtrlType(argCTRL_DO);
            Init_UI_FontsandSizes();
            Init_Elemts_ShowHite(argCTRL_DO);
            Init_elemtsValues(argCTRL_DO);
            SubscribeHoverEvents(this);
            lbl_Bval.Text = _myDefVal.ToString();
            tb_Slider.Value = _myDefVal;
            for (int i = 0; i < my_Default_bitsStates.Length; i++)
            {
                if (myCbs[i].Enabled)
                    myCbs[i].Checked = my_Default_bitsStates[i];
            }
            label_CtrlTitle.Text = _myDesc;
            this.Width = (int)minimum_Width;
            this.Height = Y_Cursor + 1;
            Update_MyDisplayer();
            SetBorderColor();
        }
        void Update_MyDisplayer()
        {
            _myUC_PGN_Displayer.Set_BytesToDisplay(_my_lo_indx, _my_hi_indx, CU_VALUE_INT);
        }
        void Init_SimpleElementValues()
        {
            int numSteps = (int)_myMax;
            tb_Slider.Minimum = _myMin;
            tb_Slider.Maximum = (int)_myMax;
            int tickFrequency = ((int)_myMax - _myMin) / numSteps;
            tb_Slider.TickFrequency = tickFrequency;
            if (((int)_myMax - _myMin) > 2000)
                tb_Slider.SmallChange = 10;
            else
                tb_Slider.SmallChange = 1;

            tb_Slider.LargeChange = tickFrequency;
            tb_RawVAL.Text = _myDefVal.ToString();
        }
        void Init_elemtsValues(Ctrl_DataObject argCTRL_DO)
        {
            CtrlType _type = StringToEnum_CtrlType(argCTRL_DO.CTRL_TYOE_STR);

            if (_type == CtrlType._4_by)
            {
                int numSteps = (int)_myMax;
                tb_Slider.Minimum = _myMin;
                tb_Slider.Maximum = (int)_myMax;
                int tickFrequency = ((int)_myMax - _myMin) / numSteps;
                tb_Slider.TickFrequency = (int)_myMax / 20;
                if (((int)_myMax - _myMin) > 2000)
                    tb_Slider.SmallChange = 10;
                else
                    tb_Slider.SmallChange = 1;
                tb_Slider.LargeChange = tickFrequency;
                tb_RawVAL.Text = _myDefVal.ToString();
            }
            else if (_type == CtrlType._3_by)
            {
                int numSteps = (int)_myMax;
                tb_Slider.Minimum = _myMin;
                tb_Slider.Maximum = (int)_myMax;
                int tickFrequency = ((int)_myMax - _myMin) / numSteps;
                tb_Slider.TickFrequency = (int)_myMax / 10;
                if (((int)_myMax - _myMin) > 2000)
                    tb_Slider.SmallChange = (int)_myMax / 10000;
                else
                    tb_Slider.SmallChange = 100;

                tb_Slider.LargeChange = (int)_myMax / 1000;
                tb_RawVAL.Text = _myDefVal.ToString();

            }
            else
            {
                int numSteps = (int)_myMax;
                tb_Slider.Minimum = _myMin;
                tb_Slider.Maximum = (int)_myMax;
                int tickFrequency = ((int)_myMax - _myMin) / numSteps;
                tb_Slider.TickFrequency = tickFrequency;
                if (((int)_myMax - _myMin) > 2000)
                    tb_Slider.SmallChange = 10;
                else
                    tb_Slider.SmallChange = 1;

                tb_Slider.LargeChange = tickFrequency;
                tb_RawVAL.Text = _myDefVal.ToString();
            }

        }
        void Init_Default_minMaxValues_According_to_CtrlType(Ctrl_DataObject argCTRL_DO)
        {
            _myType = StringToEnum_CtrlType(argCTRL_DO.CTRL_TYOE_STR);
            if (_myType == CtrlType._1_By || _myType == CtrlType._8_bs || _myType == CtrlType._8_bG)
            {
                _myMin = 0;
                _myMax = Integer_8bit_MaxValue;
                _myDefVal = 15;
                _myDesc = "N/A";
            }
            else if (_myType == CtrlType._2_by)
            {
                _myMin = 0;
                _myMax = Integer_16bit_MaxValue;
                _myDefVal = 0;
                _myDesc = "N/A";
            }
            else if (_myType == CtrlType._3_by)
            {
                _myMin = 0;
                _myMax = Integer_24bit_MaxValue;
                _myDefVal = 0;
                _myDesc = "N/A";
            }
            else if (_myType == CtrlType._4_by)
            {
                _myMin = 0;
                _myMax = Integer_32bit_MaxValue;
                _myDefVal = 0;
                _myDesc = "N/A";
            }
            _myID = argCTRL_DO.ID;
            if (_myID > 7) _myID = 7;
            if (_myID < 0) _myID = 0;
            _myMin = argCTRL_DO.MIN;
            _myMax = (uint)argCTRL_DO.MAX;
            _myDefVal = argCTRL_DO.DEF;
            _my_lo_indx = argCTRL_DO.INDEXLO;
            _my_hi_indx = argCTRL_DO.INDEXHI;
            _myDesc = argCTRL_DO.DESC;
            borderColor = GetColorByIndex(_myID);
            _my_set_min = _myMin;
            _my_set_max = (int)_myMax;
            _my_set_step = 1;
            RANDO = new Random();
            _my_set_curVal = RANDO.Next(_my_set_min, _my_set_max);
            int NEWdIR = RANDO.Next(10);
            if (NEWdIR % 2 == 0)
            {
                _Increasing = true;
            }
            else
            {
                _Increasing = false;
            }
        }
        void Init_UI_FontsandSizes()
        {
            label_CtrlTitle.Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Bold);
            label_CtrlTitle.Margin = new Padding(2, 2, 2, 2);
            lbl_Bval.Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Regular);
            tb_RawVAL.Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Regular);
            for (int i = 0; i < myCbs.Length; i++)
            {
                myCbs[i].Font = new Font(MyFonts[FontIndexSelected], FontSizeSelected, FontStyle.Regular);
            }
        }
        void Init_Elemts_ShowHite(Ctrl_DataObject argCTRL_DO)
        {
            Place_UI_elements_LBLorSlider();
            if (argCTRL_DO.ISSLIDER)
            {
                tb_RawVAL.Hide();
                tb_RawVAL.Enabled = false;
                for (int i = 0; i < myCbs.Length; i++)
                {
                    myCbs[i].Hide();
                    myCbs[i].Enabled = false;
                }
                _IsSLider = true;
                yCursor += standardRowHeight;
            }
            else
            {   
                tb_Slider.Enabled = false;
                tb_Slider.Hide();
                if (_myType == CtrlType._8_bs)
                {
                    tb_RawVAL.Enabled = false;
                    tb_RawVAL.Hide();
                    for (int i = 0; i < myCbs.Length; i++)
                    {
                        myCbs[i].Enabled = true;
                        myCbs[i].Show();
                    }
                    Place_UI_elements_8bs(argCTRL_DO.BitsList);
                }
                else
                {
                    tb_RawVAL.Enabled = true;
                    tb_RawVAL.Show();
                    tb_RawVAL.Dock = DockStyle.Bottom;
                    for (int i = 0; i < myCbs.Length; i++)
                    {
                        myCbs[i].Enabled = false;
                        myCbs[i].Hide();
                    }
                }
            }
        }
        #region Commons

        void Place_UI_elements_8bs(List<string> argBitDescriptions)
        {
            Y_Cursor = 2;
            for (int x = 0; x < myCbs.Length; x++)
            {
                myCbs[x].Text = "";
                myCbs[x].Enabled = false;
                myCbs[x].Hide();
            }
            label_CtrlTitle.Location = new Point(2, Y_Cursor);
            Y_Cursor += standardRowHeight;
            lbl_Bval.Location = new Point(2, Y_Cursor + 2);
            Y_Cursor += standardRowHeight;
            for (int d = 0; d < my_Default_bitsStates.Length; d++)
            {
                my_Default_bitsStates[d] = false;
            }
            //this will grab at most 8 bits if they are present in list . they will not be present if marked N/A in original GroundZero.txt
            for (int i = 0; i < argBitDescriptions.Count; i++)
            {
                int bitnumber = 0;
                string bitDescriptor = "";
                var result = ParseBitsNamesString(argBitDescriptions[i]);
                bitnumber = result.Item1;
                bitDescriptor = result.Item2;
                myCbs[bitnumber].Location = new Point(2, Y_Cursor);
                myCbs[bitnumber].Show();
                myCbs[bitnumber].Enabled = true;
                myCbs[bitnumber].Text = bitDescriptor;
                Y_Cursor += standardRowHeight;
            }
            int DefaultVal = _myDefVal;
            //get a byte from the int value andturn in into my_default_bitsStates
            for (int i = 0; i < my_Default_bitsStates.Length; i++)
            {
                my_Default_bitsStates[i] = (DefaultVal & (1 << i)) != 0;
            }
            Y_Cursor += standardRowHeight;
        }
        void Place_UI_elements_LBLorSlider()
        {
            Y_Cursor = 2;
            label_CtrlTitle.Location = new Point(2, Y_Cursor);
            Y_Cursor += standardRowHeight;
            lbl_Bval.Location = new Point(2, Y_Cursor + 2);
            Y_Cursor += standardRowHeight;
            Y_Cursor += standardRowHeight;
            Y_Cursor += standardRowHeight;
        }
        void cb_bit_changed(object sender, EventArgs e)
        {
            // _cur_INT_Value is the value of the byte set by the cb_b0 to cb_b7 representing bit 0 to bit 8 of the byte    
            CU_VALUE_INT = 0;
            if (cb_b0.Checked) { CU_VALUE_INT += 1; }
            if (cb_b1.Checked) { CU_VALUE_INT += 2; }
            if (cb_b2.Checked) { CU_VALUE_INT += 4; }
            if (cb_b3.Checked) { CU_VALUE_INT += 8; }
            if (cb_b4.Checked) { CU_VALUE_INT += 16; }
            if (cb_b5.Checked) { CU_VALUE_INT += 32; }
            if (cb_b6.Checked) { CU_VALUE_INT += 64; }
            if (cb_b7.Checked) { CU_VALUE_INT += 128; }
            Update_Bval_label();
            Update_MyDisplayer();
        }
        private void Btn_reset_Click(object sender, EventArgs e)
        {
            CU_VALUE_INT = _myDefVal;
            tb_RawVAL.Text = CU_VALUE_INT.ToString();
            tb_Slider.Value = CU_VALUE_INT;
            for (int i = 0; i < my_Default_bitsStates.Length; i++)
            {
                if (myCbs[i].Enabled)
                    myCbs[i].Checked = my_Default_bitsStates[i];
            }
            Update_Bval_label();
            Update_MyDisplayer();
        }
        private void tb_Slider_ValueChanged(object sender, EventArgs e)
        {
            CU_VALUE_INT = tb_Slider.Value;
            Update_Bval_label();
            Update_MyDisplayer();
        }
        private void Tb_RawNum_TextChanged(object sender, EventArgs e)
        {
            int number = 0;
            bool result = int.TryParse(tb_RawVAL.Text, out number);
            if (result)
            {
                CU_VALUE_INT = number;
                Update_Bval_label();
                Update_MyDisplayer();
            }
            else
            {
                CU_VALUE_INT = 0;
            }
        }
        void SetBorderColor()
        {
            _myUC_PGN_Displayer.Set_Display_LblColorsCodes(_my_lo_indx, _my_hi_indx, _myID);
            this.Invalidate();
        }
        private void UC_manip8_bs_Paint(object sender, PaintEventArgs e)
        {
            using (Pen borderPen = new Pen(borderColor, 4))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width, this.Height);
            }
        }
        private void SubscribeHoverEvents(Control control)
        {
            this.Paint += UC_manip8_bs_Paint;
            lbl_Bval.Click += Btn_reset_Click;
            control.MouseEnter += UC_manip8_bs_MouseEnter;
            control.MouseLeave += UC_manip8_bs_MouseLeave;
            foreach (Control child in control.Controls)
            {
                SubscribeHoverEvents(child);
            }
            cb_b0.CheckedChanged += cb_bit_changed;
            cb_b1.CheckedChanged += cb_bit_changed;
            cb_b2.CheckedChanged += cb_bit_changed;
            cb_b3.CheckedChanged += cb_bit_changed;
            cb_b4.CheckedChanged += cb_bit_changed;
            cb_b5.CheckedChanged += cb_bit_changed;
            cb_b6.CheckedChanged += cb_bit_changed;
            cb_b7.CheckedChanged += cb_bit_changed;
            tb_RawVAL.TextChanged += Tb_RawNum_TextChanged;
            tb_Slider.ValueChanged += tb_Slider_ValueChanged;
            EventsManagerLib.OnHandTickPingPong += Do_pingpong;
        }
        private void UnsubscribeHoverEvents(Control control)
        {
            this.Paint -= UC_manip8_bs_Paint;
            lbl_Bval.Click -= Btn_reset_Click;
            control.MouseEnter -= UC_manip8_bs_MouseEnter;
            control.MouseLeave -= UC_manip8_bs_MouseLeave;
            foreach (Control child in control.Controls)
            {
                UnsubscribeHoverEvents(child);
            }
            cb_b0.CheckedChanged -= cb_bit_changed;
            cb_b1.CheckedChanged -= cb_bit_changed;
            cb_b2.CheckedChanged -= cb_bit_changed;
            cb_b3.CheckedChanged -= cb_bit_changed;
            cb_b4.CheckedChanged -= cb_bit_changed;
            cb_b5.CheckedChanged -= cb_bit_changed;
            cb_b6.CheckedChanged -= cb_bit_changed;
            cb_b7.CheckedChanged -= cb_bit_changed;
            tb_RawVAL.TextChanged -= Tb_RawNum_TextChanged;
            tb_Slider.ValueChanged -= tb_Slider_ValueChanged;
            EventsManagerLib.OnHandTickPingPong -= Do_pingpong;
        }
        private void UC_manip8_bs_MouseEnter(object sender, EventArgs e)
        {
            lbl_Bval.Font = new Font(lbl_Bval.Font, FontStyle.Bold);
            _myUC_PGN_Displayer.Highlight_Bold(_my_lo_indx, _my_hi_indx);
        }
        private void UC_manip8_bs_MouseLeave(object sender, EventArgs e)
        {
            lbl_Bval.Font = new Font(lbl_Bval.Font, FontStyle.Regular);
            _myUC_PGN_Displayer.Highlight_Regular(_my_lo_indx, _my_hi_indx);
        }
        public void DisposeMe()
        {
            if (true)
            {
                UnsubscribeHoverEvents(this);
            }
            base.Dispose(true);
        }
        #endregion
        void Update_Bval_label()
        {
            lbl_Bval.Text = CU_VALUE_INT.ToString();
        }
    }
}
