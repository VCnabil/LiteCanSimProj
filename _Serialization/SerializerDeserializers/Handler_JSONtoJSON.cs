using LiteCanSimProj._Serialization.DataObjectsDefinition;
using LiteCanSimProj._Serialization.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LiteCanSimProj._Globalz.G_Paths;

namespace LiteCanSimProj._Serialization.SerializerDeserializers
{
    public class Handler_JSONtoJSON
    {
        private int PgnsInDeseriedObject;
        public int Get_pgnCountIn_Deserialized_TextList() { return PgnsInDeseriedObject; }
        List<VC_PGN_Text_Object> List_ToDressIntoCTRLs;
        Project_DataObject _MY_PROJECTDATAOBJECT_ROOT;
        List<Pgn_DataObject> _ITS_LISTOFPGNDO;
        int PGNDO_ID = 0;
        CTRL_typeCaster cTRL_TypeCaster;
        public Handler_JSONtoJSON()
        {
            PgnsInDeseriedObject = 0;
            cTRL_TypeCaster = new CTRL_typeCaster();
        }
        public void Transform_Root_VC_PGN_Text_Object__to_Project_DataObject(Root_VC_PGN_Text_Object argRootTextObj)
        {
            Root_VC_PGN_Text_Object _root_VC_PGN_OBJ = argRootTextObj;
            if (_root_VC_PGN_OBJ == null)
            {
                MessageBox.Show("argRootTextObj is null !!! ");
                return;
            }
            List_ToDressIntoCTRLs = _root_VC_PGN_OBJ.VC_PGN_Text_Object;
            PgnsInDeseriedObject = List_ToDressIntoCTRLs.Count;
            _MY_PROJECTDATAOBJECT_ROOT = new Project_DataObject();
            _ITS_LISTOFPGNDO = new List<Pgn_DataObject>();
            _MY_PROJECTDATAOBJECT_ROOT.AllPgnList = _ITS_LISTOFPGNDO;
            int start = 0;
            int end = List_ToDressIntoCTRLs.Count;
            for (int i = start; i < end; i++)
            {
                int _pgnId = List_ToDressIntoCTRLs[i].vC_PGN.VC_PGN_ID;
                uint _pgn32bit = List_ToDressIntoCTRLs[i].vC_PGN.PGN_32bit;
                string _pgnDesc = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                string _pgnFrom = List_ToDressIntoCTRLs[i].vC_PGN.From;
                string _pgnAdrsPort = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Port;
                string _pgnAdrsStbd = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Stbd;
                string _pgnPriority = List_ToDressIntoCTRLs[i].vC_PGN.priority;
                string PGN_XXXX = List_ToDressIntoCTRLs[i].vC_PGNData.PGN;
                string PGN_Desciption = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                if (_pgnAdrsPort.ToString() == _pgnAdrsStbd.ToString())
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, "");
                }
                else
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, " unit A");
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsStbd, " unit B");
                }
            }
            _MY_PROJECTDATAOBJECT_ROOT.Title = "_DynamicCtrls";
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(_MY_PROJECTDATAOBJECT_ROOT, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FileName_CTRL_JSON_DynaSavePath, json);
        }
        public Project_DataObject Transform_Root_VC_PGN_Text_Object__to_Project_DataObject_andReturn(Root_VC_PGN_Text_Object argRootTextObj, string argTitle)
        {
            Root_VC_PGN_Text_Object _root_VC_PGN_OBJ = argRootTextObj;
            if (_root_VC_PGN_OBJ == null)
            {
                MessageBox.Show("argRootTextObj is null !!! ");
                return null;
            }
            List_ToDressIntoCTRLs = _root_VC_PGN_OBJ.VC_PGN_Text_Object;
            PgnsInDeseriedObject = List_ToDressIntoCTRLs.Count;
            _MY_PROJECTDATAOBJECT_ROOT = new Project_DataObject();
            _ITS_LISTOFPGNDO = new List<Pgn_DataObject>();
            _MY_PROJECTDATAOBJECT_ROOT.AllPgnList = _ITS_LISTOFPGNDO;
            int start = 0;
            int end = List_ToDressIntoCTRLs.Count;
            for (int i = start; i < end; i++)
            {
                int _pgnId = List_ToDressIntoCTRLs[i].vC_PGN.VC_PGN_ID;
                uint _pgn32bit = List_ToDressIntoCTRLs[i].vC_PGN.PGN_32bit;
                string _pgnDesc = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                string _pgnFrom = List_ToDressIntoCTRLs[i].vC_PGN.From;
                string _pgnAdrsPort = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Port;
                string _pgnAdrsStbd = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Stbd;
                string _pgnPriority = List_ToDressIntoCTRLs[i].vC_PGN.priority;
                string PGN_XXXX = List_ToDressIntoCTRLs[i].vC_PGNData.PGN;
                string PGN_Desciption = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                if (_pgnAdrsPort.ToString() == _pgnAdrsStbd.ToString())
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, "");
                }
                else
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, " unit A");
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsStbd, " unit B");
                }
            }
            _MY_PROJECTDATAOBJECT_ROOT.Title = argTitle;
            return _MY_PROJECTDATAOBJECT_ROOT;
        }
        public void Deserialize_GroundZero_Json_andWriteCTRLObj(string targetFilePath_JSON)
        {
            //check if target file exists
            if (!File.Exists(targetFilePath_JSON))
            {
                MessageBox.Show("Cannot deseriakize a json file that doesn t exixt: " + targetFilePath_JSON);
                // return "Json File does not exist: " + targetFilePath_JSON;
                return;
            }
            Root_VC_PGN_Text_Object _root_VC_PGN_OBJ = JsonConvert.DeserializeObject<Root_VC_PGN_Text_Object>(File.ReadAllText(targetFilePath_JSON));
            if (_root_VC_PGN_OBJ == null)
            {
                MessageBox.Show("Json File is empty: " + targetFilePath_JSON);
                return;
            }
            List_ToDressIntoCTRLs = _root_VC_PGN_OBJ.VC_PGN_Text_Object;
            PgnsInDeseriedObject = List_ToDressIntoCTRLs.Count;

            _MY_PROJECTDATAOBJECT_ROOT = new Project_DataObject();
            _MY_PROJECTDATAOBJECT_ROOT.Title = "simulator";
            _ITS_LISTOFPGNDO = new List<Pgn_DataObject>();
            _MY_PROJECTDATAOBJECT_ROOT.AllPgnList = _ITS_LISTOFPGNDO;
            int start = 0;
            int end = List_ToDressIntoCTRLs.Count;
            for (int i = start; i < end; i++)
            {
                int _pgnId = List_ToDressIntoCTRLs[i].vC_PGN.VC_PGN_ID;
                uint _pgn32bit = List_ToDressIntoCTRLs[i].vC_PGN.PGN_32bit;
                string _pgnDesc = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                string _pgnFrom = List_ToDressIntoCTRLs[i].vC_PGN.From;
                string _pgnAdrsPort = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Port;
                string _pgnAdrsStbd = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Stbd;
                string _pgnPriority = List_ToDressIntoCTRLs[i].vC_PGN.priority;
                string PGN_XXXX = List_ToDressIntoCTRLs[i].vC_PGNData.PGN;
                string PGN_Desciption = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                if (_pgnAdrsPort.ToString() == _pgnAdrsStbd.ToString())
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, "");
                }
                else
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, " unit A");
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsStbd, " unit B");
                }
            }
            _MY_PROJECTDATAOBJECT_ROOT.Title = "_DynamicCtrls";
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(_MY_PROJECTDATAOBJECT_ROOT, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Get_Path_JSON_CTRLs_File(), json);
        }
        public Root_VC_PGN_Text_Object Deserialize_GroundZero_Json(string targetFilePath_JSON)
        {
            string _extractedFileName = Path.GetFileName(targetFilePath_JSON);
            //check if target file exists
            if (!File.Exists(targetFilePath_JSON))
            {
                MessageBox.Show("Cannot deseriakize a json file that doesn t exixt: " + targetFilePath_JSON);
                // return "Json File does not exist: " + targetFilePath_JSON;
                return null;
            }
            Root_VC_PGN_Text_Object _root_VC_PGN_OBJ = JsonConvert.DeserializeObject<Root_VC_PGN_Text_Object>(File.ReadAllText(targetFilePath_JSON));
            if (_root_VC_PGN_OBJ == null)
            {
                MessageBox.Show("Json File is empty: " + targetFilePath_JSON);
                return null;
            }
            List_ToDressIntoCTRLs = _root_VC_PGN_OBJ.VC_PGN_Text_Object;
            PgnsInDeseriedObject = List_ToDressIntoCTRLs.Count;
            _MY_PROJECTDATAOBJECT_ROOT = new Project_DataObject();
            _MY_PROJECTDATAOBJECT_ROOT.Title = "CCM simulator";
            _ITS_LISTOFPGNDO = new List<Pgn_DataObject>();
            _MY_PROJECTDATAOBJECT_ROOT.AllPgnList = _ITS_LISTOFPGNDO;
            int start = 0;
            int end = List_ToDressIntoCTRLs.Count;
            for (int i = start; i < end; i++)
            {
                int _pgnId = List_ToDressIntoCTRLs[i].vC_PGN.VC_PGN_ID;
                uint _pgn32bit = List_ToDressIntoCTRLs[i].vC_PGN.PGN_32bit;
                string _pgnDesc = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                string _pgnFrom = List_ToDressIntoCTRLs[i].vC_PGN.From;
                string _pgnAdrsPort = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Port;
                string _pgnAdrsStbd = List_ToDressIntoCTRLs[i].vC_PGN.adrs_Stbd;
                string _pgnPriority = List_ToDressIntoCTRLs[i].vC_PGN.priority;
                string PGN_XXXX = List_ToDressIntoCTRLs[i].vC_PGNData.PGN;
                string PGN_Desciption = List_ToDressIntoCTRLs[i].vC_PGNData.DescritionPGN;
                if (_pgnAdrsPort.ToString() == _pgnAdrsStbd.ToString())
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, "");
                }
                else
                {
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsPort, " unit A");
                    Make_andAdd_a_DataObject(List_ToDressIntoCTRLs[i], _pgnAdrsStbd, " unit B");
                }
            }
            _MY_PROJECTDATAOBJECT_ROOT.Title = _extractedFileName;
            return _root_VC_PGN_OBJ;
        }
        public Project_DataObject Get_MuRootBuilt()
        {
            return this._MY_PROJECTDATAOBJECT_ROOT;
        }
        void Make_andAdd_a_DataObject(VC_PGN_Text_Object arg_textObj, string asdreestouse, string argUnit)
        {
            PGNDO_ID++;
            Pgn_DataObject temp = cTRL_TypeCaster.Convert_VC_PGN_Text_Object_to_pgn_DataObject(arg_textObj, asdreestouse, argUnit, PGNDO_ID);
            _ITS_LISTOFPGNDO.Add(temp);
        }
    }
}
