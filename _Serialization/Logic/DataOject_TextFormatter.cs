using LiteCanSimProj._Serialization.DataObjectsDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Serialization.Logic
{
    public class DataOject_TextFormatter
    {
        public DataOject_TextFormatter() { }
        public string GetTextFromDataObject(Root_VC_PGN_Text_Object argRootTextObj, DetailDisplayData argDisplayDetail)
        {
            StringBuilder sbOut = new StringBuilder();
            if (argDisplayDetail.Show_bool_Date)
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string hour = DateTime.Now.Hour.ToString();
                string minute = DateTime.Now.Minute.ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append(month);
                sb.Append("/");
                sb.Append(day);
                sb.Append("/");
                sb.Append(year);
                sb.Append(" st ");
                sb.Append(hour);
                sb.Append(":");
                sb.Append(minute);
                sb.Append(":");
                sb.Append("00");
                string date = sb.ToString();
                sbOut.AppendLine("============================================================================");
                sbOut.AppendLine("created on : " + date);
                sbOut.AppendLine("============================================================================");
            }
            foreach (VC_PGN_Text_Object vcpgnt in argRootTextObj.VC_PGN_Text_Object)
            {
                sbOut.AppendLine("============================================================================");
                if (argDisplayDetail.Show_bool_From) sbOut.AppendLine("CAN Messages From : " + vcpgnt.vC_PGN.From);
                if (argDisplayDetail.Show_bool_ID) sbOut.AppendLine("VC_PGN_ID : " + vcpgnt.vC_PGN.VC_PGN_ID);
                if (argDisplayDetail.Show_bool_PGN32bit) sbOut.AppendLine("PGN_32bit : " + vcpgnt.vC_PGN.PGN_32bit);
                if (argDisplayDetail.Show_bool_Addresses) sbOut.AppendLine("address Port: " + vcpgnt.vC_PGN.adrs_Port);
                if (argDisplayDetail.Show_bool_Addresses) sbOut.AppendLine("address Stbd: " + vcpgnt.vC_PGN.adrs_Stbd);
                if (argDisplayDetail.Show_bool_Priority) sbOut.AppendLine("priority    : " + vcpgnt.vC_PGN.priority);
                if (argDisplayDetail.Show_bool_SoftwareVersion) sbOut.AppendLine("Sending_Unit_Software_version : " + vcpgnt.vC_PGN.Sending_Unit_Software_version);
                if (argDisplayDetail.Show_bool_Info) sbOut.AppendLine("info: " + vcpgnt.vC_PGN.info);
                if (argDisplayDetail.Show_bool_Configuration) sbOut.AppendLine("Configuration : " + vcpgnt.vC_PGN.Configuration);
                if (argDisplayDetail.Show_bool_Project) sbOut.AppendLine("Project : " + vcpgnt.vC_PGN.Project);
                if (argDisplayDetail.Show_bool_Type) sbOut.AppendLine("Type : " + vcpgnt.vC_PGN.Type);
                if (argDisplayDetail.Show_bool_Comments) sbOut.AppendLine("Comments : " + vcpgnt.vC_PGN.Comments);
                if (argDisplayDetail.Show_bool_Group) sbOut.AppendLine("Group : " + vcpgnt.vC_PGN.Group);
                if (argDisplayDetail.Show_bool_CTRLS) sbOut.AppendLine("CTRLs : " + vcpgnt.vC_PGN.CTRLs);
                sbOut.AppendLine("============================================================================");
                sbOut.AppendLine("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                sbOut.AppendLine("");
                if (argDisplayDetail.Show_bool_Bytes)
                {
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7, argDisplayDetail.Show_bool_Bits, argDisplayDetail.Show_Byte_Exts, argDisplayDetail.Show_VcFormat);
                }
            }
            return sbOut.ToString();
        }
        string Constuct_Propper_Description(string argDesc, bool ShowByte_XX, bool Do_Vc_Fprmat)
        {
            string retStr = "xxx_Problem";
            if (!argDesc.Contains('|') || Do_Vc_Fprmat == false)
            {
                return argDesc;
            }
            else
            {
                string[] descParts = argDesc.Split('|');
                string description_prefix = descParts[0];
                string description_suffix = descParts[1];
                if (description_suffix.Length < 4)
                {
                    return description_prefix;
                }
                else
                {
                    if (!ShowByte_XX)
                    {
                        return description_prefix;
                    }
                    if (description_suffix.Contains("*"))
                    {
                        string _baseDesc_STAR_value = description_suffix.Split('*')[1];

                        return description_prefix + "  ( " + _baseDesc_STAR_value + " )";
                    }
                    else
                    {
                        if (description_suffix.Contains("("))
                        {
                            int _index_of_close = description_suffix.IndexOf(')');
                            int index_of_open = description_suffix.IndexOf('(');
                            string _str_inParenths = description_suffix.Substring(index_of_open, _index_of_close - 1);
                            string[] _str_inParenths_arr = _str_inParenths.Split(',');
                            string _minstr = _str_inParenths_arr[0];
                            if (_minstr.Contains('('))
                                _minstr = _minstr.Substring(1);
                            string _defstr = _str_inParenths_arr[1];
                            string _maxstr = _str_inParenths_arr[2];
                            if (_maxstr.Contains(')'))
                                _maxstr = _maxstr.Substring(0, _maxstr.Length - 1);

                            return description_prefix + " ( " + _minstr + "  to " + _maxstr + " )";
                        }
                    }
                }
            }
            return retStr;
        }
        private void Build_List_of_BytesAndBitsFor_VC_PGN_Object(StringBuilder argsb, string _description, List<string> bits, bool argShowBits, bool ShowByte_XX, bool Do_Vc_Fprmat)
        {
            string _propperSedscription = Constuct_Propper_Description(_description, ShowByte_XX, Do_Vc_Fprmat);
            argsb.AppendLine("            - " + _propperSedscription);
            if (bits.Count == 0)
            {
                argsb.AppendLine(" ");
                return;
            }
            if (argShowBits)
            {
                int bitIndex = 0;
                foreach (var bitLine in bits)
                {
                    string fullBitLine = "                    - b" + bitIndex.ToString() + " : " + bitLine;
                    argsb.AppendLine(fullBitLine);
                    bitIndex++;
                }
            }
            argsb.AppendLine(" ");
        }
    }
}
