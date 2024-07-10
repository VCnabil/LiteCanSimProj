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
using static LiteCanSimProj._Globalz.G_Paths;
using Newtonsoft.Json;
using LiteCanSimProj._Serialization.DataObjectsDefinition;
using LiteCanSimProj._Serialization.Logic;
using LiteCanSimProj._Serialization.SerializerDeserializers;
using System.IO;

namespace LiteCanSimProj._MainUIs.MainForms
{
    public partial class PGN_Manager_ViewerGUI : Form
    {
        bool UserIs_NOTNabil;
        DetailDisplayData structDisplay;
        FilterData structFilter;
        Root_VC_PGN_Text_Object _root_VC_PGN_Text_Object = null;
        Root_VC_PGN_Text_Object filetered = null;
        string _saveFileName_plusExt = "";
        string _fullpathTo_SavedTextFile = "";
        string _File_Project_Title = "";
        bool _fileExists_JSONFILE_and_Deserialized = false;
        DataOject_TextFormatter dataOject_TextFormatter;
        DataObject_TextFilterrer dataObject_TextFilterrer;
        public PGN_Manager_ViewerGUI()
        {
            InitializeComponent();
            this.Width = G_PGN_Manager_ViewrGUI_WindowParames.Width / 2;
            this.Height = G_PGN_Manager_ViewrGUI_WindowParames.Height / 2;
            UserIs_NOTNabil = !USER_IS_NABIL;
            dataOject_TextFormatter = new DataOject_TextFormatter();
            dataObject_TextFilterrer = new DataObject_TextFilterrer();
            structDisplay = new DetailDisplayData();
            structFilter = new FilterData();
            checkBox_ShowDate.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_PgnShowVerbos.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowFrom.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowID.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show32bitpgn.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowAddresses.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowPriority.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show_Softwareversion.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Info.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Configuration.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Project.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_BytesShowVerbos.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_BitsShowVerbos.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowVCformat.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowByteExtentions.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show_Type.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show_Comments.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show_Group.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show_Ctrls.CheckedChanged += CheckBoxs_CheckedChanged;
            textBox_Contains_str_Sendingunit.TextChanged += TextBox_From_TextChanged;
            textBox_Contains_str_PGN.TextChanged += TextBox_PGN_TextChanged;
            textBox_Contains_str_UVersion.TextChanged += TextBox_UVersion_TextChanged;
            textBox_Contains_str_Configuration.TextChanged += TextBox_Config_TextChanged;
            textBox_Contains_str_Project.TextChanged += TextBox_Proj_TextChanged;
            textBox_Contains_str_Groups.TextChanged += TextBox_Group_TextChanged;
            textBox_Contains_str_Type.TextChanged += TextBox_Type_TextChanged;
            textBox_Contains_str_CTRLs.TextChanged += TextBox_CTRLs_TextChanged;
            cb_exclude_Pgn.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_sendingunit.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_version.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_configuration.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_project.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_group.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_type.CheckedChanged += CheckBoxs_CheckedChanged;
            cb_exclude_ctrl.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowFrom.Checked = true;
            checkBox_ShowID.Checked = true;
            checkBox_Show32bitpgn.Checked = true;
            checkBox_ShowAddresses.Checked = true;
            checkBox_ShowPriority.Checked = true;
            checkBox_Show_Softwareversion.Checked = true;
            checkBox_Info.Checked = false;
            checkBox_Configuration.Checked = true;
            checkBox_Project.Checked = true;
            checkBox_BytesShowVerbos.Checked = true;
            checkBox_ShowVCformat.Checked = true;
            checkBox_ShowByteExtentions.Checked = true;
            checkBox_Show_Type.Checked = true;
            checkBox_Show_Comments.Checked = false;
            checkBox_Show_Group.Checked = true;
            checkBox_Show_Ctrls.Checked = true;
            checkBox_BitsShowVerbos.Hide();
            checkBox_ShowVCformat.Checked = false;
            textBox_INPUTsaveFileName.TextChanged += TextBoxINPUT_saveFileName_TextChanged;
            button_Save_File.Click += Button_Save_File_Click;
            button_Display.Click += Button_Display_Click;
            button_Display.Hide();
            textBox_INPUTsaveFileName.Text = "";
            if (UserIs_NOTNabil)
            {
                checkBox_PgnShowVerbos.Hide();
                checkBox_ShowID.Hide();
                checkBox_Show32bitpgn.Hide();
                checkBox_ShowAddresses.Hide();
                checkBox_ShowPriority.Hide();
                checkBox_ShowVCformat.Hide();
                checkBox_Show_Type.Hide();
                checkBox_Show_Group.Hide();
                checkBox_Show_Ctrls.Hide();
                textBox_INPUTsaveFileName.Hide();
                label_saveFilename.Hide();
                X3_label_saveFilename.Hide();
                textBox_OUTPUTFilePath.Hide();
                button_Save_File.Hide();
            }
            Handle_OpeningJsonFile();
            if (_fileExists_JSONFILE_and_Deserialized)
            {
                filetered = _root_VC_PGN_Text_Object;
                Update_DisplayedPgns();
            }

        }
        private void TextBox_UVersion_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_UVersion.Text.Length > 0)
            {
                structFilter.Filter_bool_UnitVersions = true;
                structFilter.Filter_str_UnitVersions = textBox_Contains_str_UVersion.Text;
            }
            else
            {
                structFilter.Filter_bool_UnitVersions = false;
            }
            Update_DisplayedPgns();
        }
        void Handle_OpeningJsonFile()
        {
            string pathtest_JSON_File = Get_Path_JSONFile();
            string pathtest_text_File = Get_Path_BaseTextFile();
            bool _fileExists_JSONFILE = File.Exists(pathtest_JSON_File);
            bool _fileExists_TEXTFILE = File.Exists(pathtest_text_File);
            StringBuilder sbinfo = new StringBuilder();
            string _FileINfoStr0 = "ALL the pgns are implemented using  " + pathtest_text_File;
            string _FileINfoStr1 = " you may modify it but NOT rename or remove it   ";
            string _FileINfoStr2 = "1- looking for Interim JSON file in " + pathtest_JSON_File;
            string _FileINfoStr3 = "2- if not, then recreate it from " + pathtest_text_File;
            sbinfo.AppendLine(_FileINfoStr0);
            sbinfo.AppendLine(_FileINfoStr1);
            sbinfo.AppendLine(" ");
            sbinfo.AppendLine(_FileINfoStr2);
            sbinfo.AppendLine(_FileINfoStr3);
            textBox_infoBox.Text = sbinfo.ToString();
            if (_fileExists_JSONFILE)
            {
                string jsonFileContent = File.ReadAllText(pathtest_JSON_File);
                if (!string.IsNullOrWhiteSpace(jsonFileContent))  // Check if the file content is not empty
                {
                    Handler_JSONtoJSON handler_JSONtoJSON = new Handler_JSONtoJSON();
                    _root_VC_PGN_Text_Object = handler_JSONtoJSON.Deserialize_GroundZero_Json(pathtest_JSON_File);
                    _fileExists_JSONFILE_and_Deserialized = true;
                }
                else
                {
                    MessageBox.Show("JSON interim file is empty");
                    RebuildJsonFromTextFile(pathtest_text_File);
                }
            }
            else
            {
                RebuildJsonFromTextFile(pathtest_text_File);
            }
        }
        private void RebuildJsonFromTextFile(string textFilePath)
        {
            if (File.Exists(textFilePath))
            {
                // MessageBox.Show("Rebuilding Json from TEXTFILE"); very enoying 
                Handler_TEXTtoJSON handler_TEXTtoJSON = new Handler_TEXTtoJSON();
                handler_TEXTtoJSON.Serialize_GroundZero_Tex_andWrite_JsonFile(textFilePath);
                Handle_OpeningJsonFile();
            }
            else
            {
                MessageBox.Show("TEXTFILE does not exist. Too bad.");
            }
        }
        private void Button_Save_File_Click(object sender, EventArgs e)
        {
            string _savePath = _fullpathTo_SavedTextFile;
            Handler_JSONtoJSON handler_JSONtoJSON = new Handler_JSONtoJSON();
            Project_DataObject pod_CTRLS_toSave = handler_JSONtoJSON.Transform_Root_VC_PGN_Text_Object__to_Project_DataObject_andReturn(filetered, _File_Project_Title);
            string json = JsonConvert.SerializeObject(pod_CTRLS_toSave, Formatting.Indented);
            File.WriteAllText(_savePath, json);
            this.Close();
        }
        private void TextBoxINPUT_saveFileName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_INPUTsaveFileName.Text.Length == 0)
            {
                button_Save_File.Enabled = false;
                button_Save_File.Hide();
            }
            else
            {
                button_Save_File.Enabled = true;
                button_Save_File.Show();
            }
            _File_Project_Title = textBox_INPUTsaveFileName.Text;
            _saveFileName_plusExt = _File_Project_Title + ".json";
            label_saveFilename.Text = "Save This Filtered Output as " + _saveFileName_plusExt;
            _fullpathTo_SavedTextFile = Path.Combine(GetOutputDir(), _saveFileName_plusExt);
            textBox_OUTPUTFilePath.Text = _fullpathTo_SavedTextFile;
        }
        private void TextBox_From_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Sendingunit.Text.Length > 0)
            {
                structFilter.Filter_bool_FromSendingUnit = true;
                structFilter.Filter_str_From = textBox_Contains_str_Sendingunit.Text;
            }
            else
            {
                structFilter.Filter_bool_FromSendingUnit = false;
            }
            Update_DisplayedPgns();
        }
        private void TextBox_PGN_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_PGN.Text.Length > 0)
            {
                structFilter.Filter_bool_Pgn = true;

                string _allCaps_PGN_filter = textBox_Contains_str_PGN.Text.ToUpper();
                structFilter.Filter_str_Pgn = _allCaps_PGN_filter;
            }
            else
            {
                structFilter.Filter_bool_Pgn = false;
            }
            Update_DisplayedPgns();
        }
        private void TextBox_Config_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Configuration.Text.Length > 0)
            {
                structFilter.Filter_bool_Configuration = true;

                structFilter.Filter_str_Configuration = textBox_Contains_str_Configuration.Text;
            }
            else
            {
                structFilter.Filter_bool_Configuration = false;
            }

            Update_DisplayedPgns();
        }
        private void TextBox_Group_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Groups.Text.Length > 0)
            {
                structFilter.Filter_bool_Group = true;

                structFilter.Filter_str_Group = textBox_Contains_str_Groups.Text;
            }
            else
            {
                structFilter.Filter_bool_Group = false;
            }

            Update_DisplayedPgns();
        }
        private void TextBox_CTRLs_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_CTRLs.Text.Length > 0)
            {
                structFilter.Filter_bool_CTRLs = true;

                structFilter.Filter_str_CTRLs = textBox_Contains_str_CTRLs.Text;
            }
            else
            {
                structFilter.Filter_bool_CTRLs = false;
            }

            Update_DisplayedPgns();
        }
        private void TextBox_Type_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Type.Text.Length > 0)
            {
                structFilter.Filter_bool_Type = true;

                structFilter.Filter_str_Type = textBox_Contains_str_Type.Text;
            }
            else
            {
                structFilter.Filter_bool_Type = false;
            }
            Update_DisplayedPgns();
        }
        private void TextBox_Proj_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Project.Text.Length > 0)
            {
                structFilter.Filter_bool_Project = true;
                structFilter.Filter_str_Project = textBox_Contains_str_Project.Text;
            }
            else
            {
                structFilter.Filter_bool_Project = false;
            }
            Update_DisplayedPgns();
        }
        private void Button_Display_Click(object sender, EventArgs e)
        {
            Update_DisplayedPgns();
        }
        private void CheckBoxs_CheckedChanged(object sender, EventArgs e)
        {
            structDisplay.Show_bool_Date = checkBox_ShowDate.Checked;
            structDisplay.Show_bool_HEAVY = checkBox_PgnShowVerbos.Checked;
            structDisplay.Show_bool_From = checkBox_ShowFrom.Checked;
            structDisplay.Show_bool_ID = checkBox_ShowID.Checked;
            structDisplay.Show_bool_PGN32bit = checkBox_Show32bitpgn.Checked;
            structDisplay.Show_bool_Addresses = checkBox_ShowAddresses.Checked;
            structDisplay.Show_bool_Priority = checkBox_ShowPriority.Checked;
            structDisplay.Show_bool_SoftwareVersion = checkBox_Show_Softwareversion.Checked;
            structDisplay.Show_bool_Info = checkBox_Info.Checked;
            structDisplay.Show_bool_Configuration = checkBox_Configuration.Checked;
            structDisplay.Show_bool_Project = checkBox_Project.Checked;
            structDisplay.Show_bool_Bytes = checkBox_BytesShowVerbos.Checked;
            structDisplay.Show_bool_Bits = checkBox_BitsShowVerbos.Checked;
            structDisplay.Show_VcFormat = checkBox_ShowVCformat.Checked;
            structDisplay.Show_Byte_Exts = checkBox_ShowByteExtentions.Checked;
            structDisplay.Show_bool_Comments = checkBox_Show_Comments.Checked;
            structDisplay.Show_bool_Type = checkBox_Show_Type.Checked;
            structDisplay.Show_bool_Group = checkBox_Show_Group.Checked;
            structDisplay.Show_bool_CTRLS = checkBox_Show_Ctrls.Checked;
            structFilter.Filter_Exclude_Pgn = cb_exclude_Pgn.Checked;
            structFilter.Filter_Exclude_configuration = cb_exclude_configuration.Checked;
            structFilter.Filter_Exclude_version = cb_exclude_version.Checked;
            structFilter.Filter_Exclude_sendingUnit = cb_exclude_sendingunit.Checked;
            structFilter.Filter_Exclude_Type = cb_exclude_type.Checked;
            structFilter.Filter_Exclude_Project = cb_exclude_project.Checked;
            structFilter.Filter_Exclude_Group = cb_exclude_group.Checked;
            structFilter.Filter_Exclude_CTRLs = cb_exclude_ctrl.Checked;
            Update_DisplayedPgns();
        }
        void Update_DisplayedPgns()
        {
            textBox_Display.Text = "";
            if (_root_VC_PGN_Text_Object == null)
            {
                textBox_Display.Text = "root object is null";
                return;
            }
            filetered = dataObject_TextFilterrer.FilterTextObject(_root_VC_PGN_Text_Object, structFilter);
            textBox_Display.Text = dataOject_TextFormatter.GetTextFromDataObject(filetered, structDisplay);
            int matchesfound = filetered.VC_PGN_Text_Object.Count();
            label_MatchesFound.Text = matchesfound.ToString();
        }
    }
}
