using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Serialization.DataObjectsDefinition
{
    public class Project_DataObject
    {
        public string Title { get; set; }
        public List<Pgn_DataObject> AllPgnList { get; set; }
    }

    public class Pgn_DataObject
    {
        public int IDpgn { get; set; }
        public int PGN_int { get; set; }
        public string PGN_strHEX { get; set; }
        public string DESCpgn { get; set; }
        public List<Ctrl_DataObject> CtrlList { get; set; }
    }
    public class Ctrl_DataObject
    {
        public int ID { get; set; }
        public string DESC { get; set; }
        public int MIN { get; set; }
        public int MAX { get; set; }
        public int DEF { get; set; }
        public int INDEXLO { get; set; }
        public int INDEXHI { get; set; }
        public string CTRL_TYOE_STR { get; set; }
        public bool ISSLIDER { get; set; }
        public List<string> BitsList { get; set; }
        public List<string> Group1List { get; set; }
        public List<string> Group2List { get; set; }
        public List<string> RemoteList { get; set; }
    }
}
