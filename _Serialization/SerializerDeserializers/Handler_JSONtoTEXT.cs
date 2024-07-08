using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LiteCanSimProj._Serialization.DataObjectsDefinition;

namespace LiteCanSimProj._Serialization.SerializerDeserializers
{
    public class Handler_JSONtoTEXT
    {
        string targetFilePath_JSON;
        List<VC_PGN_Text_Object> vC_PGN_Text_Objects;
        public int TotalPgnsInJSON { get { return vC_PGN_Text_Objects.Count; } }
        private int PgnsInFilteredList;
        public int Get_pgnCountInFilteredList() { return PgnsInFilteredList; }
        public Handler_JSONtoTEXT()
        {
            PgnsInFilteredList = 0;
        }
        public void Partial_testFunc(string path)
        {
            this.targetFilePath_JSON = path;
            //check if target file exists
            if (!File.Exists(targetFilePath_JSON))
            {
                MessageBox.Show("Json File does not exist: " + targetFilePath_JSON);
                return;
            }
            Root_VC_PGN_Text_Object _root_VC_PGN_OBJ = JsonConvert.DeserializeObject<Root_VC_PGN_Text_Object>(File.ReadAllText(targetFilePath_JSON));
            if (_root_VC_PGN_OBJ == null)
            {
                MessageBox.Show("Json File is empty: " + targetFilePath_JSON);
                return;
            }
            vC_PGN_Text_Objects = _root_VC_PGN_OBJ.VC_PGN_Text_Object;
        }
        #region Filters

        List<VC_PGN_Text_Object> GetFilteredby_Boolean(bool arg_byPGN, string argPGNcontains, bool arg_Uverdion, string arg_UnitversionContains, bool arg_byFrom, string argFROMcontains, bool arg_byConfiguration, string argCONFIGcontains, bool arg_byProject, string argPROJECTcontains, bool arg_byGroup, string argGROUPcontains, bool arg_byType, string argTYPEcontains, bool arg_byCTRLs, string argCTRLscontains)
        {
            IEnumerable<VC_PGN_Text_Object> filteredList = vC_PGN_Text_Objects;
            if (arg_byPGN)
            {
                filteredList = filteredList.Where(item => item.vC_PGNData.PGN.Contains(argPGNcontains));
            }
            if (arg_Uverdion)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.Sending_Unit_Software_version.Contains(arg_UnitversionContains));
            }
            if (arg_byFrom)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.From.Contains(argFROMcontains));
            }
            if (arg_byConfiguration)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.Configuration.Contains(argCONFIGcontains));
            }
            if (arg_byProject)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.Project.Contains(argPROJECTcontains));
            }
            if (arg_byGroup)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.Group.Contains(argGROUPcontains));
            }
            return filteredList.ToList();
        }
        #endregion
        private void Build_List_of_BytesAndBitsFor_VC_PGN_Object(StringBuilder argsb, string description, List<string> bits, bool argShowBits)
        {
            argsb.AppendLine("            - " + description);
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
        List<VC_PGN_Text_Object> SortVC_PGN_Text_Objects(Root_VC_PGN_Text_Object rootObject)
        {
            List<VC_PGN_Text_Object> sortedList = rootObject.VC_PGN_Text_Object;
            return sortedList;
        }
    }
}
