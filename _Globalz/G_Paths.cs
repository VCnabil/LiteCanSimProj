using System.IO;
using System.Windows.Forms;

namespace LiteCanSimProj._Globalz
{
    public static class G_Paths
    {
        public static string FileName_textREADONLY = "_GroundZero.txt";
        public static string FileName_JSON = "_GroundZero.json";
        public static string FileName_CTRL_JSON = "_DynamicCtrls.json";
        public static string FileName_CTRL_JSON_DynaSavePath = @"C:\___Root_VCI_Projects\Generic_VC_PGN_SIMULATOR\lite_pgnSim\LiteCANSim\LiteCanSimProj\_Proj_Data_Dir\_CCM_Trimmed\_Dynamic_Trimmed2.json";
        public static string GetBaseDir()
        {
            if (System.Diagnostics.Debugger.IsAttached) { return @"C:\___Root_VCI_Projects\Generic_VC_PGN_SIMULATOR\lite_pgnSim\LiteCANSim\LiteCanSimProj\_Proj_Data_Dir\_BaseDir\"; }
            else { return Path.Combine(Application.StartupPath, "_Proj_Data_Dir", "_BaseDir"); }
        }
        public static string GetOutputDir()
        {
            if (System.Diagnostics.Debugger.IsAttached) { return @"C:\___Root_VCI_Projects\Generic_VC_PGN_SIMULATOR\lite_pgnSim\LiteCANSim\LiteCanSimProj\_Proj_Data_Dir\_OutDir\"; }
            else { return Path.Combine(Application.StartupPath, "_Proj_Data_Dir", "_OutDir"); }
        }
        public static string Get_Path_BaseTextFile()
        {
            return Path.Combine(GetBaseDir(), FileName_textREADONLY);
        }
        public static string Get_Path_JSONFile()
        {
            return Path.Combine(GetBaseDir(), FileName_JSON);
        }
        public static string Get_Path_JSON_CTRLs_File()
        {
            return Path.Combine(GetBaseDir(), FileName_CTRL_JSON);
        }
    }
}
