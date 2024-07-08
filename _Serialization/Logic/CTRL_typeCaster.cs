using LiteCanSimProj._Serialization.DataObjectsDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LiteCanSimProj._Globalz.Helpers;
using static LiteCanSimProj._Globalz.G_Properties;

namespace LiteCanSimProj._Serialization.Logic
{
    public class CTRL_typeCaster
    {
        public CTRL_typeCaster()
        {
        }
        public Pgn_DataObject Convert_VC_PGN_Text_Object_to_pgn_DataObject(VC_PGN_Text_Object arg_textObj, string asdreestouse, string argUnit, int arg_ctrlID)
        {
            Pgn_DataObject pgn_DataObject = new Pgn_DataObject();
            int __pgnId = arg_ctrlID;
            string _pgnAdrs = asdreestouse;
            string _pgnPriority = arg_textObj.vC_PGN.priority;
            string PGN_XXXX = arg_textObj.vC_PGNData.PGN;
            if (PGN_XXXX.Length > 4)
            {
                PGN_XXXX = PGN_XXXX.Substring(2, PGN_XXXX.Length - 2);
            }
            string str_full_PGN = _pgnPriority + PGN_XXXX + _pgnAdrs;
            int __int_full_PGN = 0;
            if (_pgnPriority != string.Empty && PGN_XXXX != string.Empty && _pgnAdrs != string.Empty)
            {
                __int_full_PGN = HexStringToDecimal(str_full_PGN);
            }
            else
            {
                MessageBox.Show("error in PGN: " + str_full_PGN + "  is wrong for ctrl id " + __pgnId.ToString());
            }
            string __PGN_strHEX = "0x" + __int_full_PGN.ToString("X8");
            string original_TextDescription = arg_textObj.vC_PGNData.DescritionPGN;
            string __DESCpgn = "from " + arg_textObj.vC_PGN.From + " " + original_TextDescription + argUnit + " ";
            if (__DESCpgn.Length > G_PGN_Description_MaxLength)
            {
                __DESCpgn = __DESCpgn.Substring(0, G_PGN_Description_MaxLength);
            }
            pgn_DataObject.DESCpgn = __DESCpgn;
            pgn_DataObject.PGN_int = __int_full_PGN;
            pgn_DataObject.PGN_strHEX = __PGN_strHEX;
            pgn_DataObject.IDpgn = __pgnId;
            pgn_DataObject.CtrlList = new List<Ctrl_DataObject>();
            return Smart_Ctrl_DataObject_Generator(arg_textObj.vC_PGNData, pgn_DataObject);
        }
        Pgn_DataObject Smart_Ctrl_DataObject_Generator(VC_PGNData argVC_PGNData, Pgn_DataObject arg_DataObject)
        {
            bool[] _usedIndices = new bool[8];
            List<string>[] arrayOfStringLists = new List<string>[8];
            arrayOfStringLists[0] = argVC_PGNData.Byte0;
            arrayOfStringLists[1] = argVC_PGNData.Byte1;
            arrayOfStringLists[2] = argVC_PGNData.Byte2;
            arrayOfStringLists[3] = argVC_PGNData.Byte3;
            arrayOfStringLists[4] = argVC_PGNData.Byte4;
            arrayOfStringLists[5] = argVC_PGNData.Byte5;
            arrayOfStringLists[6] = argVC_PGNData.Byte6;
            arrayOfStringLists[7] = argVC_PGNData.Byte7;
            string[] ByteDescriptions = new string[8];
            ByteDescriptions[0] = argVC_PGNData.DescritionByte0;
            ByteDescriptions[1] = argVC_PGNData.DescritionByte1;
            ByteDescriptions[2] = argVC_PGNData.DescritionByte2;
            ByteDescriptions[3] = argVC_PGNData.DescritionByte3;
            ByteDescriptions[4] = argVC_PGNData.DescritionByte4;
            ByteDescriptions[5] = argVC_PGNData.DescritionByte5;
            ByteDescriptions[6] = argVC_PGNData.DescritionByte6;
            ByteDescriptions[7] = argVC_PGNData.DescritionByte7;
            Check8Bit(arrayOfStringLists, ByteDescriptions, _usedIndices, arg_DataObject);
            Check_B2(arrayOfStringLists, ByteDescriptions, _usedIndices, arg_DataObject);
            Check_BT(arrayOfStringLists, ByteDescriptions, _usedIndices, arg_DataObject);
            Check_BL(arrayOfStringLists, ByteDescriptions, _usedIndices, arg_DataObject);
            Check_B3(arrayOfStringLists, ByteDescriptions, _usedIndices, arg_DataObject);
            Check_B4(arrayOfStringLists, ByteDescriptions, _usedIndices, arg_DataObject);
            return arg_DataObject;
        }
        private void Check8Bit(List<string>[] arrayOfStringLists, string[] ByteDescriptions, bool[] _usedIndecies, Pgn_DataObject arg_DataObject)
        {
            for (int i = 0; i < arrayOfStringLists.Length; i++)
            {
                if (_usedIndecies[i]) { continue; }
                if (ByteDescriptions[i].Contains("N/A")) { _usedIndecies[i] = true; continue; }
                if (!ByteDescriptions[i].Contains('|')) { _usedIndecies[i] = true; continue; }
                string[] descritionParts = ByteDescriptions[i].Split('|');
                string _CleadDescription = descritionParts[0];
                if (_CleadDescription.Length > G_Byte_Description_MaxLength) { _CleadDescription = _CleadDescription.Substring(0, G_Byte_Description_MaxLength); }
                string Ctrl_Type = descritionParts[1];
                if (Ctrl_Type.Contains("XX"))
                {
                    int index = ByteDescriptions[i].IndexOf("XX");
                    string result_suffix = ByteDescriptions[i].Substring(index + 2);
                    int _min = 0;
                    int _def = 0;
                    uint _max = Integer_8bit_MaxValue;
                    if (string.IsNullOrEmpty(result_suffix))
                    {
                        _min = 0;
                        _def = 0;
                        _max = Integer_8bit_MaxValue;
                    }
                    else
                    {
                        if (result_suffix[0] == '*')
                        {
                            string _singleNumber = result_suffix.Substring(1);
                            int _singleNumber_int = int.Parse(_singleNumber);
                            _def = _singleNumber_int;
                        }
                        else
                        {
                            if (result_suffix[0] == '(')
                            {
                                int _index_of_close = result_suffix.IndexOf(')');
                                string _str_inParenths = result_suffix.Substring(1, _index_of_close - 1);
                                string[] _str_inParenths_arr = _str_inParenths.Split(',');
                                _min = int.Parse(_str_inParenths_arr[0]);
                                _def = int.Parse(_str_inParenths_arr[1]);
                                _max = uint.Parse(_str_inParenths_arr[2]);
                            }
                        }
                    }
                    Ctrl_DataObject ctrl_8bitDataObject = new Ctrl_DataObject();
                    ctrl_8bitDataObject.ID = i;
                    ctrl_8bitDataObject.MIN = 0;
                    ctrl_8bitDataObject.MAX = 255;
                    ctrl_8bitDataObject.DEF = _def;
                    ctrl_8bitDataObject.DESC = _CleadDescription;
                    ctrl_8bitDataObject.ISSLIDER = false;
                    ctrl_8bitDataObject.CTRL_TYOE_STR = EnumToString_CtrlType(CtrlType._8_bs);
                    ctrl_8bitDataObject.INDEXLO = i;
                    ctrl_8bitDataObject.INDEXHI = i;
                    ctrl_8bitDataObject.BitsList = new List<string>();
                    ctrl_8bitDataObject.Group1List = new List<string>();
                    ctrl_8bitDataObject.Group2List = new List<string>();
                    ctrl_8bitDataObject.RemoteList = new List<string>();
                    for (int x = 0; x < arrayOfStringLists[i].Count; x++)
                    {
                        if (arrayOfStringLists[i][x].Contains("N/A")) { continue; }
                        string _bitnamevalue = arrayOfStringLists[i][x];
                        int maxlen = 30;
                        if (_bitnamevalue.Length > maxlen)
                        {
                            _bitnamevalue = _bitnamevalue.Substring(0, maxlen);
                        }
                        string formated_bitName = x + ". " + _bitnamevalue;
                        ctrl_8bitDataObject.BitsList.Add(formated_bitName);
                    }
                    arg_DataObject.CtrlList.Add(ctrl_8bitDataObject);
                    _usedIndecies[i] = true;
                }
            }
        }
        private void Check_B2(List<string>[] arrayOfStringLists, string[] ByteDescriptions, bool[] _usedIndecies, Pgn_DataObject arg_DataObject)
        {
            for (int i = 0; i < arrayOfStringLists.Length; i++)
            {
                if (_usedIndecies[i]) { continue; }
                if (ByteDescriptions[i].Contains("N/A")) { _usedIndecies[i] = true; continue; }
                if (!ByteDescriptions[i].Contains('|')) { _usedIndecies[i] = true; continue; }
                string[] descritionParts = ByteDescriptions[i].Split('|');
                string _CleadDescription = descritionParts[0];
                if (_CleadDescription.Length > G_Byte_Description_MaxLength) { _CleadDescription = _CleadDescription.Substring(0, G_Byte_Description_MaxLength); }
                string Ctrl_Type = descritionParts[1];
                if (Ctrl_Type.Contains("B2"))
                {
                    for (int j = 0; j < ByteDescriptions.Length; j++)
                    {
                        if (_usedIndecies[j]) { continue; }
                        string str_J_cleaned = ByteDescriptions[j].Split('|')[0];
                        string str_I_cleaned = ByteDescriptions[i].Split('|')[0];
                        if ((Is_EndIn_HI(str_J_cleaned) && Is_EndIn_LO(str_I_cleaned)) ||
                            (Is_EndIn_LO(str_J_cleaned) && Is_EndIn_HI(str_I_cleaned)))
                        {
                            _usedIndecies[i] = true;
                            _usedIndecies[j] = true;
                            int _indexLO = Is_EndIn_LO(str_I_cleaned) ? i : j;
                            int _indexHI = Is_EndIn_HI(str_I_cleaned) ? i : j;
                            if (Is_EndIn_LO(_CleadDescription))
                            {
                                _CleadDescription = _CleadDescription.Substring(0, _CleadDescription.Length - 3);
                            }
                            if (Is_EndIn_HI(_CleadDescription))
                            {
                                _CleadDescription = _CleadDescription.Substring(0, _CleadDescription.Length - 3);
                            }
                            int index = ByteDescriptions[_indexLO].IndexOf("B2");
                            string result_suffix = ByteDescriptions[_indexLO].Substring(index + 2);
                            int _min = 0;
                            int _def = 0;
                            uint _max = Integer_16bit_MaxValue;
                            if (string.IsNullOrEmpty(result_suffix))
                            {
                                _min = 0;
                                _def = (int)Integer_16bit_MaxValue / 2;
                                _max = Integer_16bit_MaxValue;
                            }
                            else
                            {
                                if (result_suffix[0] == '*')
                                {
                                    string _singleNumber = result_suffix.Substring(1);
                                    int _singleNumber_int = int.Parse(_singleNumber);
                                    _def = _singleNumber_int;
                                }
                                else
                                {
                                    if (result_suffix[0] == '(')
                                    {
                                        int _index_of_close = result_suffix.IndexOf(')');
                                        string _str_inParenths = result_suffix.Substring(1, _index_of_close - 1);
                                        string[] _str_inParenths_arr = _str_inParenths.Split(',');
                                        _min = int.Parse(_str_inParenths_arr[0]);
                                        _def = int.Parse(_str_inParenths_arr[1]);
                                        _max = uint.Parse(_str_inParenths_arr[2]);
                                    }
                                }
                            }
                            Ctrl_DataObject _16bit_ctrl = new Ctrl_DataObject();
                            _16bit_ctrl.ID = i;
                            _16bit_ctrl.MIN = _min;
                            _16bit_ctrl.MAX = (int)_max;
                            _16bit_ctrl.DEF = _def;
                            _16bit_ctrl.DESC = _CleadDescription;
                            _16bit_ctrl.INDEXLO = _indexLO;
                            _16bit_ctrl.INDEXHI = _indexHI;
                            _16bit_ctrl.CTRL_TYOE_STR = EnumToString_CtrlType(CtrlType._2_by);
                            _16bit_ctrl.BitsList = new List<string>();
                            _16bit_ctrl.Group1List = new List<string>();
                            _16bit_ctrl.Group2List = new List<string>();
                            _16bit_ctrl.RemoteList = new List<string>();
                            if (Is_Contain_AnyOf_VersionKeywords(ByteDescriptions[_indexLO]))
                            {
                                _16bit_ctrl.ISSLIDER = false;
                            }
                            else
                            {
                                _16bit_ctrl.ISSLIDER = true;
                            }
                            arg_DataObject.CtrlList.Add(_16bit_ctrl);
                            break;
                        }
                    }
                }
            }
        }
        private void Check_BT(List<string>[] arrayOfStringLists, string[] ByteDescriptions, bool[] _usedIndecies, Pgn_DataObject arg_DataObject)
        {
            for (int i = 0; i < arrayOfStringLists.Length; i++)
            {
                if (_usedIndecies[i]) { continue; }
                if (ByteDescriptions[i].Contains("N/A")) { _usedIndecies[i] = true; continue; }
                if (!ByteDescriptions[i].Contains('|')) { _usedIndecies[i] = true; continue; }
                string[] descritionParts = ByteDescriptions[i].Split('|');
                string _CleadDescription = descritionParts[0];
                if (_CleadDescription.Length > G_Byte_Description_MaxLength) { _CleadDescription = _CleadDescription.Substring(0, G_Byte_Description_MaxLength); }
                string Ctrl_Type = descritionParts[1];
                if (Ctrl_Type.Contains("BT"))
                {
                    int index = ByteDescriptions[i].IndexOf("BT");
                    string result_suffix = ByteDescriptions[i].Substring(index + 2);
                    int _min = 0;
                    int _def = 0;
                    uint _max = Integer_16bit_MaxValue;
                    if (string.IsNullOrEmpty(result_suffix))
                    {
                        _min = 0;
                        _def = (int)Integer_16bit_MaxValue / 2;
                        _max = Integer_16bit_MaxValue;
                    }
                    else
                    {
                        if (result_suffix[0] == '*')
                        {
                            string _singleNumber = result_suffix.Substring(1);
                            int _singleNumber_int = int.Parse(_singleNumber);
                            _def = _singleNumber_int;
                        }
                        else
                        {
                            if (result_suffix[0] == '(')
                            {
                                int _index_of_close = result_suffix.IndexOf(')');
                                string _str_inParenths = result_suffix.Substring(1, _index_of_close - 1);
                                string[] _str_inParenths_arr = _str_inParenths.Split(',');
                                _min = int.Parse(_str_inParenths_arr[0]);
                                _def = int.Parse(_str_inParenths_arr[1]);
                                _max = uint.Parse(_str_inParenths_arr[2]);
                            }
                        }
                    }
                    Ctrl_DataObject ctrl_1B_DataObject = new Ctrl_DataObject();
                    ctrl_1B_DataObject.ID = i;
                    ctrl_1B_DataObject.MIN = _min;
                    ctrl_1B_DataObject.MAX = (int)_max;
                    ctrl_1B_DataObject.DEF = _def;
                    ctrl_1B_DataObject.DESC = _CleadDescription;
                    ctrl_1B_DataObject.ISSLIDER = true;
                    ctrl_1B_DataObject.CTRL_TYOE_STR = EnumToString_CtrlType(CtrlType._1_By);
                    ctrl_1B_DataObject.INDEXLO = i;
                    ctrl_1B_DataObject.INDEXHI = i;
                    ctrl_1B_DataObject.BitsList = new List<string>();
                    ctrl_1B_DataObject.Group1List = new List<string>();
                    ctrl_1B_DataObject.Group2List = new List<string>();
                    ctrl_1B_DataObject.RemoteList = new List<string>();
                    arg_DataObject.CtrlList.Add(ctrl_1B_DataObject);
                    _usedIndecies[i] = true;
                }
            }
        }
        private void Check_BL(List<string>[] arrayOfStringLists, string[] ByteDescriptions, bool[] _usedIndecies, Pgn_DataObject arg_DataObject)
        {
            for (int i = 0; i < arrayOfStringLists.Length; i++)
            {
                if (_usedIndecies[i]) { continue; }
                if (ByteDescriptions[i].Contains("N/A")) { _usedIndecies[i] = true; continue; }
                if (!ByteDescriptions[i].Contains('|')) { _usedIndecies[i] = true; continue; }
                string[] descritionParts = ByteDescriptions[i].Split('|');
                string _CleadDescription = descritionParts[0];
                if (_CleadDescription.Length > G_Byte_Description_MaxLength) { _CleadDescription = _CleadDescription.Substring(0, G_Byte_Description_MaxLength); }
                string Ctrl_Type = descritionParts[1];
                if (Ctrl_Type.Contains("BL"))
                {
                    int index = ByteDescriptions[i].IndexOf("BL");
                    string result_suffix = ByteDescriptions[i].Substring(index + 2);
                    int _min = 0;
                    int _def = 0;
                    uint _max = Integer_8bit_MaxValue;
                    if (string.IsNullOrEmpty(result_suffix))
                    {
                        _min = 0;
                        _def = (int)Integer_16bit_MaxValue / 2;
                        _max = Integer_16bit_MaxValue;
                    }
                    else
                    {
                        if (result_suffix[0] == '*')
                        {
                            string _singleNumber = result_suffix.Substring(1);
                            int _singleNumber_int = int.Parse(_singleNumber);
                            _def = _singleNumber_int;
                        }
                        else
                        {
                            if (result_suffix[0] == '(')
                            {
                                int _index_of_close = result_suffix.IndexOf(')');
                                string _str_inParenths = result_suffix.Substring(1, _index_of_close - 1);
                                string[] _str_inParenths_arr = _str_inParenths.Split(',');
                                _min = int.Parse(_str_inParenths_arr[0]);
                                _def = int.Parse(_str_inParenths_arr[1]);
                                _max = uint.Parse(_str_inParenths_arr[2]);
                            }
                        }
                    }
                    Ctrl_DataObject ctrl_1B_DataObject = new Ctrl_DataObject();
                    ctrl_1B_DataObject.ID = i;
                    ctrl_1B_DataObject.MIN = _min;
                    ctrl_1B_DataObject.MAX = (int)_max;
                    ctrl_1B_DataObject.DEF = _def;
                    ctrl_1B_DataObject.DESC = _CleadDescription;
                    ctrl_1B_DataObject.ISSLIDER = false;
                    ctrl_1B_DataObject.CTRL_TYOE_STR = EnumToString_CtrlType(CtrlType._1_By);
                    ctrl_1B_DataObject.INDEXLO = i;
                    ctrl_1B_DataObject.INDEXHI = i;
                    ctrl_1B_DataObject.BitsList = new List<string>();
                    ctrl_1B_DataObject.Group1List = new List<string>();
                    ctrl_1B_DataObject.Group2List = new List<string>();
                    ctrl_1B_DataObject.RemoteList = new List<string>();
                    arg_DataObject.CtrlList.Add(ctrl_1B_DataObject);
                }
            }
        }
        private void Check_B3(List<string>[] arrayOfStringLists, string[] ByteDescriptions, bool[] _usedIndecies, Pgn_DataObject arg_DataObject)
        {
            for (int i = 0; i < ByteDescriptions.Length; i++)
            {
                if (_usedIndecies[i]) { continue; }
                if (ByteDescriptions[i].Contains("N/A")) { _usedIndecies[i] = true; continue; }
                if (!ByteDescriptions[i].Contains('|')) { _usedIndecies[i] = true; continue; }
                string[] descritionParts = ByteDescriptions[i].Split('|');
                string _CleanedDescription = descritionParts[0];
                if (_CleanedDescription.Length > G_Byte_Description_MaxLength) { _CleanedDescription = _CleanedDescription.Substring(0, G_Byte_Description_MaxLength); }
                string Ctrl_Type = descritionParts[1];
                if (Ctrl_Type.Contains("B3"))
                {
                    if (descritionParts[0].Contains("bit_0"))
                    {
                        _usedIndecies[i] = true;
                        _usedIndecies[i + 1] = true;
                        _usedIndecies[i + 2] = true;
                        int startIndex = i;
                        int endIndex = i + 2;
                        int index = ByteDescriptions[i].IndexOf("B3");
                        string result_suffix = ByteDescriptions[i].Substring(index + 2);
                        int _min = 0;
                        int _def = 0;
                        uint _max = Integer_24bit_MaxValue;
                        if (string.IsNullOrEmpty(result_suffix))
                        {
                            _min = 0;
                            _def = (int)Integer_24bit_MaxValue / 2;
                            _max = Integer_24bit_MaxValue;
                        }
                        else
                        {
                            if (result_suffix[0] == '*')
                            {
                                string _singleNumber = result_suffix.Substring(1);
                                int _singleNumber_int = int.Parse(_singleNumber);
                                _def = _singleNumber_int;
                            }
                            else
                            {
                                if (result_suffix[0] == '(')
                                {
                                    int _index_of_close = result_suffix.IndexOf(')');
                                    string _str_inParenths = result_suffix.Substring(1, _index_of_close - 1);
                                    string[] _str_inParenths_arr = _str_inParenths.Split(',');
                                    _min = int.Parse(_str_inParenths_arr[0]);
                                    _def = int.Parse(_str_inParenths_arr[1]);
                                    _max = uint.Parse(_str_inParenths_arr[2]);
                                }
                            }
                        }
                        Ctrl_DataObject _24bit_slider = new Ctrl_DataObject();
                        _24bit_slider.ID = i;
                        _24bit_slider.MIN = _min;
                        _24bit_slider.MAX = (int)_max;
                        _24bit_slider.DEF = _def;
                        _24bit_slider.DESC = _CleanedDescription.Substring(0, _CleanedDescription.Length - 8);
                        _24bit_slider.ISSLIDER = true;
                        _24bit_slider.CTRL_TYOE_STR = EnumToString_CtrlType(CtrlType._3_by);
                        _24bit_slider.INDEXLO = startIndex;
                        _24bit_slider.INDEXHI = endIndex;
                        _24bit_slider.BitsList = new List<string>();
                        _24bit_slider.Group1List = new List<string>();
                        _24bit_slider.Group2List = new List<string>();
                        _24bit_slider.RemoteList = new List<string>();
                        arg_DataObject.CtrlList.Add(_24bit_slider);
                    }
                }
            }
        }
        private void Check_B4(List<string>[] arrayOfStringLists, string[] ByteDescriptions, bool[] _usedIndecies, Pgn_DataObject arg_DataObject)
        {
            for (int i = 0; i < ByteDescriptions.Length; i++)
            {
                if (_usedIndecies[i]) { continue; }
                if (ByteDescriptions[i].Contains("N/A")) { _usedIndecies[i] = true; continue; }
                if (!ByteDescriptions[i].Contains('|')) { _usedIndecies[i] = true; continue; }
                string[] descritionParts = ByteDescriptions[i].Split('|');
                string _CleadDescription = descritionParts[0];
                if (_CleadDescription.Length > G_Byte_Description_MaxLength) { _CleadDescription = _CleadDescription.Substring(0, G_Byte_Description_MaxLength); }
                string Ctrl_Type = descritionParts[1];
                if (Ctrl_Type.Contains("B4"))
                {
                    if (descritionParts[0].Contains("bit_0"))
                    {
                        _usedIndecies[i] = true;
                        _usedIndecies[i + 1] = true;
                        _usedIndecies[i + 2] = true;
                        _usedIndecies[i + 3] = true;
                        int startIndex = i;
                        int endIndex = i + 3;
                        int index = ByteDescriptions[i].IndexOf("B4");
                        string result_suffix = ByteDescriptions[i].Substring(index + 2);
                        int _min = 0;
                        int _def = 0;
                        uint _max = Integer_24bit_MaxValue;
                        if (string.IsNullOrEmpty(result_suffix))
                        {
                            _min = 0;
                            _def = (int)Integer_24bit_MaxValue / 2;
                            _max = Integer_24bit_MaxValue;
                        }
                        else
                        {
                            if (result_suffix[0] == '*')
                            {
                                string _singleNumber = result_suffix.Substring(1);
                                int _singleNumber_int = int.Parse(_singleNumber);
                                _def = _singleNumber_int;
                            }
                            else
                            {
                                if (result_suffix[0] == '(')
                                {
                                    int _index_of_close = result_suffix.IndexOf(')');
                                    string _str_inParenths = result_suffix.Substring(1, _index_of_close - 1);
                                    string[] _str_inParenths_arr = _str_inParenths.Split(',');
                                    _min = int.Parse(_str_inParenths_arr[0]);
                                    _def = int.Parse(_str_inParenths_arr[1]);
                                    _max = uint.Parse(_str_inParenths_arr[2]);
                                }
                            }
                        }
                        Ctrl_DataObject _32bit_slider = new Ctrl_DataObject();
                        _32bit_slider.ID = i;
                        _32bit_slider.MIN = _min;
                        _32bit_slider.MAX = (int)_max;
                        _32bit_slider.DEF = _def;
                        _32bit_slider.DESC = _CleadDescription.Substring(0, _CleadDescription.Length - 8);
                        _32bit_slider.ISSLIDER = true;
                        _32bit_slider.CTRL_TYOE_STR = EnumToString_CtrlType(CtrlType._4_by);
                        _32bit_slider.INDEXLO = startIndex;
                        _32bit_slider.INDEXHI = endIndex;
                        _32bit_slider.BitsList = new List<string>();
                        _32bit_slider.Group1List = new List<string>();
                        _32bit_slider.Group2List = new List<string>();
                        _32bit_slider.RemoteList = new List<string>();
                        arg_DataObject.CtrlList.Add(_32bit_slider);
                    }
                }
            }
        }
        #region Linecontains
        bool Is_EndIn_LO(string argStr)
        {
            if (argStr.EndsWith(" LO "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool Is_EndIn_HI(string argStr)
        {
            if (argStr.EndsWith(" HI "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool Is_Contain_AnyOf_VersionKeywords(string argStr)
        {
            string[] argStrArr = new string[] { "Version", "version", "VERSION", "Major", "Minor", "Revision" };
            for (int i = 0; i < argStrArr.Length; i++)
            {
                if (argStr.Contains(argStrArr[i]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}
