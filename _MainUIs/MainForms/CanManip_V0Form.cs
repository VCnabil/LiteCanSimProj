using LiteCanSimProj._MainUIs._SizingUCs;
using LiteCanSimProj._MainUIs.CanManipUCs;
using LiteCanSimProj._Serialization.DataObjectsDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LiteCanSimProj._Globalz.Helpers;
using static LiteCanSimProj._Globalz.G_Properties;
using static LiteCanSimProj._Globalz.G_Paths;
using LiteCanSimProj._Globalz;

namespace LiteCanSimProj._MainUIs.MainForms
{
    public partial class CanManip_V0Form : Form
    {
        string _fileToLoad = "";
        string _filePathToLoad = "";
        Project_DataObject project_DataObject = null;
        private List<UC_DataDisplayCTRL> _dataDisplayControls = new List<UC_DataDisplayCTRL>();
        public CanManip_V0Form()
        {
            InitializeComponent();
            DoMeasure(5, 6);
            this.Width = G_PGN_CanManipV0_WindowParames.Width / 2;
            this.Height = G_PGN_CanManipV0_WindowParames.Height / 2;
            //list files in C:\___Root_VCI_Projects\Generic_VC_PGN_SIMULATOR\genericSim\VC_PGN_ManagerGUI\_Proj_Data_Dir\_OutDir\ in combobox comboBox_loadFileNames
            string[] files = System.IO.Directory.GetFiles(GetOutputDir(), "*.json");
            foreach (string file in files)
            {
                comboBox_loadFileNames.Items.Add(System.IO.Path.GetFileName(file));
            }
            comboBox_loadFileNames.SelectedIndex = 0;
            comboBox_loadFileNames.SelectedIndexChanged += ComboBox_loadFileNames_SelectedIndexChanged;
 
            label_selectedFilePath.Text = _filePathToLoad;
            btn_Load.Click += Btn_LoadFile_Click;
            btnClear.Click += Btn_ClearDataDisplayCtrls_Click;

            button_delete_selectedFile.Click += Button_delete_selectedFile_Click;
            timer1_pingpong.Tick += Timer1_pingpong_Tick;
            timer1_pingpong.Start();
            Refresh_list_of_filesinOutdir();
            SetFilePathsAndNames();
            this.ucf_KvsrCanMod.SetRefToListOfCtrls(_dataDisplayControls);

            button_makeNew.Click += Button_makeNew_Click;

        }
        private void Button_makeNew_Click(object sender, EventArgs e)
        {
            Dlete_GroundZeroJasonFile_if_existsat_path();
            PGN_Manager_ViewerGUI pgn_Manager_ViewrGUI = new PGN_Manager_ViewerGUI();
            pgn_Manager_ViewrGUI.FormClosed += new FormClosedEventHandler(pgn_Manager_ViewrGUI_FormClosed);
            pgn_Manager_ViewrGUI.Show();
        }
        private void pgn_Manager_ViewrGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            PGN_Manager_ViewerGUI form2 = sender as PGN_Manager_ViewerGUI;
            if (form2 != null)
            {
                form2.FormClosed -= pgn_Manager_ViewrGUI_FormClosed;
            }

            Refresh_list_of_filesinOutdir();
        }
        void Dlete_GroundZeroJasonFile_if_existsat_path()
        {

            string argpath = Get_Path_JSONFile();
            if (File.Exists(argpath))
            {
                File.Delete(argpath);
            }


        }
        private void Timer1_pingpong_Tick(object sender, EventArgs e)
        {
            if (cb_DoPingpong.Checked)
            {
                EventsManagerLib.CallHandTickPingPong();
            }
        }

        private void Button_delete_selectedFile_Click(object sender, EventArgs e)
        {
            if (comboBox_loadFileNames.SelectedItem != null)
            {
                _fileToLoad = comboBox_loadFileNames.SelectedItem.ToString();
                string _filePathToDelete = Path.Combine(GetOutputDir(), _fileToLoad);

                if (_fileToLoad.Contains("keep"))
                {
                    if (G_IsMinimal)
                    {

                        MessageBox.Show("Sorry, this is a working confing. pleasekeep it");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("This file its tagged keep , remove it ?", "Confirm Delete", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DeleteSelectedFileIfExists(_filePathToDelete);
                            Refresh_list_of_filesinOutdir();
                        }

                    }

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the file?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DeleteSelectedFileIfExists(_filePathToDelete);
                        Refresh_list_of_filesinOutdir();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a file to delete.");
            }
        }
        void DeleteSelectedFileIfExists(string filepath)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
                MessageBox.Show(filepath + "File deleted successfully.");
            }
            else
            {
                MessageBox.Show(filepath + " does not exist.");
            }
        }
        void Refresh_list_of_filesinOutdir()
        {
            comboBox_loadFileNames.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(GetOutputDir(), "*.json");
            foreach (string file in files)
            {
                comboBox_loadFileNames.Items.Add(System.IO.Path.GetFileName(file));
            }
            comboBox_loadFileNames.SelectedIndex = 0;
            comboBox_loadFileNames.SelectedIndexChanged += ComboBox_loadFileNames_SelectedIndexChanged;
            label_selectedFilePath.Text = _filePathToLoad;

        }
        private void Btn_ClearDataDisplayCtrls_Click(object sender, EventArgs e)
        {
            ClearUCDataDisplayCtrlsFlowPannel();
        }
        void Place_UC_DataDisplayCTRL_Flowpannel()
        {
            int MaxNumberOfUCs = 40;
            int numberOfFoundPgns = Math.Min(project_DataObject.AllPgnList.Count, MaxNumberOfUCs);

            for (int i = 0; i < numberOfFoundPgns; i++)
            {
                UC_DataDisplayCTRL uc = new UC_DataDisplayCTRL(project_DataObject.AllPgnList[i]);
                flowLayoutPanel1.Controls.Add(uc); // Add to the FlowLayoutPanel
                _dataDisplayControls.Add(uc); // Keep track of it
            }
        }
        void ClearUCDataDisplayCtrlsFlowPannel()
        {
            foreach (var ctrl in _dataDisplayControls)
            {
                flowLayoutPanel1.Controls.Remove(ctrl);
                ctrl.Dispose(); // Optional, if you want to dispose them immediately
            }
            _dataDisplayControls.Clear();
        }
        void DoMeasure(int fontIndex, int argSize)
        {
            float lblW = 0.0f;
            float lblH = 0.0f;
            using (UCSizing mySizongController = new UCSizing(MyFonts[fontIndex], argSize, _baseKey))
            {
                lblW = mySizongController.Get_LableWidth();
                lblH = mySizongController.Get_LableHeight();
                G_Update_Base_FFF_Width(lblW);
                G_Update_Base_FFF_Height(lblH);
                FontSizeSelected = argSize;
                FontIndexSelected = fontIndex;
            }
            int _fullpgnBasewidth = G_Get_Base_PGN_Display_Width();
            return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Label Width: " + lblW);
            sb.AppendLine("Label Height: " + lblH);
            sb.AppendLine("Full PGN Base Width: " + _fullpgnBasewidth);
            textBox_Display.Text = sb.ToString();
        }
        private void ComboBox_loadFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilePathsAndNames();
        }
        void SetFilePathsAndNames()
        {
            _fileToLoad = comboBox_loadFileNames.SelectedItem.ToString();
            _filePathToLoad = Path.Combine(GetOutputDir(), _fileToLoad);
            // label_SelectedFilenameAndExt.Text = _fileToLoad;
            label_selectedFilePath.Text = _filePathToLoad;
            QuickDeserialize();
        }
        private void Btn_LoadFile_Click(object sender, EventArgs e)
        {
            //  Place_UC_DataDisplayCTRL();
            Place_UC_DataDisplayCTRL_Flowpannel();
        }
        void QuickDeserialize()
        {
            project_DataObject = null;
            string json = System.IO.File.ReadAllText(_filePathToLoad);
            project_DataObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Project_DataObject>(json);
            int Pgns_Inthisfile = project_DataObject.AllPgnList.Count;
            label_pgnsFound.Text = Pgns_Inthisfile.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Found " + Pgns_Inthisfile + " PGNs in this file");
            foreach (Pgn_DataObject pgn in project_DataObject.AllPgnList)
            {
                sb.AppendLine(pgn.DESCpgn);
                foreach (Ctrl_DataObject ctrl in pgn.CtrlList)
                {
                    sb.AppendLine("   ctrl  " + ctrl.DESC);
                }
                sb.AppendLine("");
                sb.AppendLine("-------------");
                sb.AppendLine("");
            }
            textBox_Display.Text = sb.ToString();
        }


    }
}
