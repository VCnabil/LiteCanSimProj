using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Serialization.DataObjectsDefinition
{
    public class Root_VC_PGN_Text_Object
    {
        public string ProjectName { get; set; }
        public List<VC_PGN_Text_Object> VC_PGN_Text_Object { get; set; }
    }
    public class VC_PGN_Text_Object
    {
        public VC_PGN vC_PGN { get; set; }
        public VC_PGNData vC_PGNData { get; set; }
    }
    public class VC_PGN
    {
        public string From { get; set; }
        public int VC_PGN_ID { get; set; }
        public uint PGN_32bit { get; set; }
        public string adrs_Port { get; set; }
        public string adrs_Stbd { get; set; }
        public string priority { get; set; }
        public string Sending_Unit_Software_version { get; set; }
        public string info { get; set; }
        public string Configuration { get; set; }
        public string Project { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string Group { get; set; }
        public string CTRLs { get; set; }
    }
    public class VC_PGNData
    {
        public string PGN { get; set; }
        public string DescritionPGN { get; set; }
        public string DescritionByte0 { get; set; }
        public List<string> Byte0 { get; set; }
        public string DescritionByte1 { get; set; }
        public List<string> Byte1 { get; set; }
        public string DescritionByte2 { get; set; }
        public List<string> Byte2 { get; set; }
        public string DescritionByte3 { get; set; }
        public List<string> Byte3 { get; set; }
        public string DescritionByte4 { get; set; }
        public List<string> Byte4 { get; set; }
        public string DescritionByte5 { get; set; }
        public List<string> Byte5 { get; set; }
        public string DescritionByte6 { get; set; }
        public List<string> Byte6 { get; set; }
        public string DescritionByte7 { get; set; }
        public List<string> Byte7 { get; set; }
    }
    public struct FilterData
    {
        public bool Filter_bool_Pgn { get; set; }
        public string Filter_str_Pgn { get; set; }
        public bool Filter_bool_UnitVersions { get; set; }
        public string Filter_str_UnitVersions { get; set; }
        public bool Filter_bool_FromSendingUnit { get; set; }
        public string Filter_str_From { get; set; }
        public bool Filter_bool_Configuration { get; set; }
        public string Filter_str_Configuration { get; set; }
        public bool Filter_bool_Project { get; set; }
        public string Filter_str_Project { get; set; }
        public bool Filter_bool_Group { get; set; }
        public string Filter_str_Group { get; set; }
        public bool Filter_bool_Type { get; set; }
        public string Filter_str_Type { get; set; }
        public bool Filter_bool_CTRLs { get; set; }
        public string Filter_str_CTRLs { get; set; }
        public bool Filter_Exclude_Pgn { get; set; }
        public bool Filter_Exclude_version { get; set; }
        public bool Filter_Exclude_sendingUnit { get; set; }
        public bool Filter_Exclude_configuration { get; set; }
        public bool Filter_Exclude_Project { get; set; }
        public bool Filter_Exclude_Group { get; set; }
        public bool Filter_Exclude_Type { get; set; }
        public bool Filter_Exclude_CTRLs { get; set; }
    }
    public struct DetailDisplayData
    {
        public bool Show_bool_Date { get; set; }
        public bool Show_bool_HEAVY { get; set; }
        public bool Show_bool_From { get; set; }
        public bool Show_bool_ID { get; set; }
        public bool Show_bool_PGN32bit { get; set; }
        public bool Show_bool_Addresses { get; set; }
        public bool Show_bool_Priority { get; set; }
        public bool Show_bool_SoftwareVersion { get; set; }
        public bool Show_bool_Info { get; set; }
        public bool Show_bool_Configuration { get; set; }
        public bool Show_bool_Project { get; set; }
        public bool Show_bool_Comments { get; set; }
        public bool Show_bool_Type { get; set; }
        public bool Show_bool_Group { get; set; }
        public bool Show_bool_CTRLS { get; set; }
        public bool Show_bool_Bytes { get; set; }
        public bool Show_bool_Bits { get; set; }
        public bool Show_Byte_Exts { get; set; }
        public bool Show_VcFormat { get; set; }
    }
}
