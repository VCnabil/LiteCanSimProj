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
using LiteCanSimProj._MainUIs.DynPosUCs;
using LiteCanSimProj._MainUIs.DynGPSUCs;
using LiteCanSimProj._MainUIs.MainForms.Simships;

namespace LiteCanSimProj._MainUIs.MainForms
{
    public partial class CanManip_V1Form : Form
    {
        string _fileToLoad = "";
        string _filePathToLoad = "";
        Project_DataObject project_DataObject = null;
        private List<UC_DataDisplayCTRL> _dataDisplayControls = new List<UC_DataDisplayCTRL>();

        // Create a new timer for ping pong
        Timer timer1_pingpong = new Timer();
        uc_dpControl uC_DP1;
        //  UC_DP uC_DP1;
        //this.uC_DP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        //this.uC_DP1.Location = new System.Drawing.Point(488, 1284);
        //this.uC_DP1.Name = "uC_DP1";
        //this.uC_DP1.Size = new System.Drawing.Size(1421, 560);
        //this.uC_DP1.TabIndex = 57;

        public CanManip_V1Form()
        {
            InitializeComponent();
            uC_DP1 = new uc_dpControl();
            this.Controls.Add(uC_DP1);

            int HeightOfFlow = this.flowLayoutPanel1.Height;
            int Y_posOfFlow = this.flowLayoutPanel1.Location.Y;
            int Y_pos_bellow_flow  = Y_posOfFlow + HeightOfFlow + 10;

            uC_DP1.Location = new Point(260, Y_pos_bellow_flow);
            //uC_DP1.Size = new Size(750, 300);
             

            DoMeasure(5, 6);
            this.Width = G_PGN_CanManipV0_WindowParames.Width / 2;
            this.Height = G_PGN_CanManipV0_WindowParames.Height / 2;

            // Ensure the output directory exists
            string outputDir = GetOutputDir();
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List files in the output directory in combobox
            RefreshComboBoxWithFiles();

            comboBox_loadFileNames.SelectedIndexChanged += ComboBox_loadFileNames_SelectedIndexChanged;

            label_selectedFilePath.Text = _filePathToLoad;
            btn_Load.Click += Btn_LoadFile_Click;
            btnClear.Click += Btn_ClearDataDisplayCtrls_Click;
            button_delete_selectedFile.Click += Button_delete_selectedFile_Click;
            btn_MK3_AD.Click += Button_Open_MK3_AD_Click;
            btn_MK3_WJ.Click += Button_Open_MK3_WJ_Click;
            btn_SSRS_K12.Click += Button_Open_SSRS_K12_Click;
            btn_SANFRANsim.Click += Btn_SANFRANsim_Click;
            timer1_pingpong.Tick += Timer1_pingpong_Tick;
            timer1_pingpong.Start();
            Refresh_list_of_filesinOutdir();
            SetFilePathsAndNames();
            this.ucf_KvaserCanModule1.SetRefToListOfCtrls(_dataDisplayControls);

            button_makeNew.Click += Button_makeNew_Click;
        }

        private void Btn_SANFRANsim_Click(object sender, EventArgs e)
        {
            SANFRANSim SANFRAN_simulationform = new SANFRANSim();
            SANFRAN_simulationform.Show();
        }

        private void Button_Open_SANFRANSim_Click(object sender, EventArgs e)
        {
            INFPB_MK3_AD form_mk3AD = new INFPB_MK3_AD();
            form_mk3AD.Show();
        }

        private void Button_Open_MK3_AD_Click(object sender, EventArgs e)
        {
            INFPB_MK3_AD form_mk3AD = new INFPB_MK3_AD();
            form_mk3AD.Show();
        }
        private void Button_Open_MK3_WJ_Click(object sender, EventArgs e)
        {
            INFPB_MK3_WJ form_mk3WJ = new INFPB_MK3_WJ();
            form_mk3WJ.Show();
        }
        private void Button_Open_SSRS_K12_Click(object sender, EventArgs e)
        {
            SSRS_K12 form_ssrsk12 = new SSRS_K12();
            form_ssrsk12.Show();
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
                        MessageBox.Show("Sorry, this is a working config. please keep it");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("This file is tagged keep, remove it?", "Confirm Delete", MessageBoxButtons.YesNo);
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
                MessageBox.Show(filepath + " File deleted successfully.");
            }
            else
            {
                MessageBox.Show(filepath + " does not exist.");
            }
        }

        void Refresh_list_of_filesinOutdir()
        {
            RefreshComboBoxWithFiles();
        }

        void RefreshComboBoxWithFiles()
        {
            comboBox_loadFileNames.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(GetOutputDir(), "*.json");
            foreach (string file in files)
            {
                comboBox_loadFileNames.Items.Add(System.IO.Path.GetFileName(file));
            }

            if (comboBox_loadFileNames.Items.Count > 0)
            {
                comboBox_loadFileNames.SelectedIndex = 0;
            }
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
            // No need to return here, the method is void
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Label Width: " + lblW);
            sb.AppendLine("Label Height: " + lblH);
            sb.AppendLine("Full PGN Base Width: " + _fullpgnBasewidth);
            //textBox_Display.Text = sb.ToString();
        }

        private void ComboBox_loadFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilePathsAndNames();
        }

        void SetFilePathsAndNames()
        {
            if (comboBox_loadFileNames.SelectedItem != null)
            {
                _fileToLoad = comboBox_loadFileNames.SelectedItem.ToString();
                _filePathToLoad = Path.Combine(GetOutputDir(), _fileToLoad);
                label_selectedFilePath.Text = _filePathToLoad;
                QuickDeserialize();
            }
        }

        private void Btn_LoadFile_Click(object sender, EventArgs e)
        {
            Place_UC_DataDisplayCTRL_Flowpannel();
        }

        void QuickDeserialize()
        {
            project_DataObject = null;
            if (File.Exists(_filePathToLoad))
            {
                string json = File.ReadAllText(_filePathToLoad);
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
                //textBox_Display.Text = sb.ToString();
            }
        }
    }
}
