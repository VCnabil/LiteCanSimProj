namespace LiteCanSimProj._MainUIs.MainForms
{
    partial class PGN_Manager_ViewerGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PGN_Manager_ViewerGUI));
            this.cb_exclude_project = new System.Windows.Forms.CheckBox();
            this.cb_exclude_group = new System.Windows.Forms.CheckBox();
            this.cb_exclude_type = new System.Windows.Forms.CheckBox();
            this.cb_exclude_ctrl = new System.Windows.Forms.CheckBox();
            this.cb_exclude_configuration = new System.Windows.Forms.CheckBox();
            this.cb_exclude_sendingunit = new System.Windows.Forms.CheckBox();
            this.cb_exclude_version = new System.Windows.Forms.CheckBox();
            this.cb_exclude_Pgn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Contains_str_UVersion = new System.Windows.Forms.TextBox();
            this.X2_lbl_CTRLs = new System.Windows.Forms.Label();
            this.textBox_Contains_str_CTRLs = new System.Windows.Forms.TextBox();
            this.X2_lbl_Type = new System.Windows.Forms.Label();
            this.textBox_Contains_str_Type = new System.Windows.Forms.TextBox();
            this.X2_lbl_Groups = new System.Windows.Forms.Label();
            this.textBox_Contains_str_Groups = new System.Windows.Forms.TextBox();
            this.textBox_infoBox = new System.Windows.Forms.TextBox();
            this.checkBox_Show_Ctrls = new System.Windows.Forms.CheckBox();
            this.checkBox_Show_Group = new System.Windows.Forms.CheckBox();
            this.checkBox_Show_Comments = new System.Windows.Forms.CheckBox();
            this.checkBox_Show_Type = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowVCformat = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowByteExtentions = new System.Windows.Forms.CheckBox();
            this.button_Display = new System.Windows.Forms.Button();
            this.button_Save_File = new System.Windows.Forms.Button();
            this.textBox_Contains = new System.Windows.Forms.TextBox();
            this.label_saveFilename = new System.Windows.Forms.Label();
            this.textBox_OUTPUTFilePath = new System.Windows.Forms.TextBox();
            this.X3_label_saveFilename = new System.Windows.Forms.Label();
            this.textBox_INPUTsaveFileName = new System.Windows.Forms.TextBox();
            this.X2_lbl_Project = new System.Windows.Forms.Label();
            this.X2_lbl_Config = new System.Windows.Forms.Label();
            this.X2_lbl_PGN = new System.Windows.Forms.Label();
            this.X2_lbl_TxUnit = new System.Windows.Forms.Label();
            this.textBox_Contains_str_Project = new System.Windows.Forms.TextBox();
            this.textBox_Contains_str_Configuration = new System.Windows.Forms.TextBox();
            this.textBox_Contains_str_PGN = new System.Windows.Forms.TextBox();
            this.textBox_Contains_str_Sendingunit = new System.Windows.Forms.TextBox();
            this.checkBox_Show_Softwareversion = new System.Windows.Forms.CheckBox();
            this.checkBox_Show32bitpgn = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowPriority = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowAddresses = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowID = new System.Windows.Forms.CheckBox();
            this.label_MatchesFound = new System.Windows.Forms.Label();
            this.X1_label3 = new System.Windows.Forms.Label();
            this.X1_label2 = new System.Windows.Forms.Label();
            this.checkBox_Configuration = new System.Windows.Forms.CheckBox();
            this.checkBox_Project = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowFrom = new System.Windows.Forms.CheckBox();
            this.checkBox_Info = new System.Windows.Forms.CheckBox();
            this.checkBox_BytesShowVerbos = new System.Windows.Forms.CheckBox();
            this.checkBox_BitsShowVerbos = new System.Windows.Forms.CheckBox();
            this.checkBox_PgnShowVerbos = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowDate = new System.Windows.Forms.CheckBox();
            this.label_totalPgnsInDb = new System.Windows.Forms.Label();
            this.X1_label1 = new System.Windows.Forms.Label();
            this.textBox_Display = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cb_exclude_project
            // 
            this.cb_exclude_project.AutoSize = true;
            this.cb_exclude_project.Location = new System.Drawing.Point(27, 945);
            this.cb_exclude_project.Name = "cb_exclude_project";
            this.cb_exclude_project.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_project.TabIndex = 154;
            this.cb_exclude_project.Text = "X";
            this.cb_exclude_project.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_group
            // 
            this.cb_exclude_group.AutoSize = true;
            this.cb_exclude_group.Location = new System.Drawing.Point(27, 990);
            this.cb_exclude_group.Name = "cb_exclude_group";
            this.cb_exclude_group.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_group.TabIndex = 153;
            this.cb_exclude_group.Text = "X";
            this.cb_exclude_group.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_type
            // 
            this.cb_exclude_type.AutoSize = true;
            this.cb_exclude_type.Location = new System.Drawing.Point(27, 1035);
            this.cb_exclude_type.Name = "cb_exclude_type";
            this.cb_exclude_type.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_type.TabIndex = 152;
            this.cb_exclude_type.Text = "X";
            this.cb_exclude_type.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_ctrl
            // 
            this.cb_exclude_ctrl.AutoSize = true;
            this.cb_exclude_ctrl.Location = new System.Drawing.Point(27, 1080);
            this.cb_exclude_ctrl.Name = "cb_exclude_ctrl";
            this.cb_exclude_ctrl.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_ctrl.TabIndex = 151;
            this.cb_exclude_ctrl.Text = "X";
            this.cb_exclude_ctrl.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_configuration
            // 
            this.cb_exclude_configuration.AutoSize = true;
            this.cb_exclude_configuration.Location = new System.Drawing.Point(27, 900);
            this.cb_exclude_configuration.Name = "cb_exclude_configuration";
            this.cb_exclude_configuration.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_configuration.TabIndex = 150;
            this.cb_exclude_configuration.Text = "X";
            this.cb_exclude_configuration.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_sendingunit
            // 
            this.cb_exclude_sendingunit.AutoSize = true;
            this.cb_exclude_sendingunit.Location = new System.Drawing.Point(27, 855);
            this.cb_exclude_sendingunit.Name = "cb_exclude_sendingunit";
            this.cb_exclude_sendingunit.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_sendingunit.TabIndex = 149;
            this.cb_exclude_sendingunit.Text = "X";
            this.cb_exclude_sendingunit.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_version
            // 
            this.cb_exclude_version.AutoSize = true;
            this.cb_exclude_version.Location = new System.Drawing.Point(27, 810);
            this.cb_exclude_version.Name = "cb_exclude_version";
            this.cb_exclude_version.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_version.TabIndex = 148;
            this.cb_exclude_version.Text = "X";
            this.cb_exclude_version.UseVisualStyleBackColor = true;
            // 
            // cb_exclude_Pgn
            // 
            this.cb_exclude_Pgn.AutoSize = true;
            this.cb_exclude_Pgn.Location = new System.Drawing.Point(27, 765);
            this.cb_exclude_Pgn.Name = "cb_exclude_Pgn";
            this.cb_exclude_Pgn.Size = new System.Drawing.Size(58, 29);
            this.cb_exclude_Pgn.TabIndex = 147;
            this.cb_exclude_Pgn.Text = "X";
            this.cb_exclude_Pgn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 810);
            this.label1.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 146;
            this.label1.Text = "version";
            // 
            // textBox_Contains_str_UVersion
            // 
            this.textBox_Contains_str_UVersion.Location = new System.Drawing.Point(104, 810);
            this.textBox_Contains_str_UVersion.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_UVersion.MaxLength = 16;
            this.textBox_Contains_str_UVersion.Name = "textBox_Contains_str_UVersion";
            this.textBox_Contains_str_UVersion.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_UVersion.TabIndex = 145;
            // 
            // X2_lbl_CTRLs
            // 
            this.X2_lbl_CTRLs.AutoSize = true;
            this.X2_lbl_CTRLs.Location = new System.Drawing.Point(344, 1080);
            this.X2_lbl_CTRLs.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_CTRLs.Name = "X2_lbl_CTRLs";
            this.X2_lbl_CTRLs.Size = new System.Drawing.Size(78, 25);
            this.X2_lbl_CTRLs.TabIndex = 144;
            this.X2_lbl_CTRLs.Text = "CTRLs";
            // 
            // textBox_Contains_str_CTRLs
            // 
            this.textBox_Contains_str_CTRLs.Location = new System.Drawing.Point(104, 1080);
            this.textBox_Contains_str_CTRLs.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_CTRLs.MaxLength = 16;
            this.textBox_Contains_str_CTRLs.Name = "textBox_Contains_str_CTRLs";
            this.textBox_Contains_str_CTRLs.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_CTRLs.TabIndex = 143;
            // 
            // X2_lbl_Type
            // 
            this.X2_lbl_Type.AutoSize = true;
            this.X2_lbl_Type.Location = new System.Drawing.Point(344, 1035);
            this.X2_lbl_Type.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_Type.Name = "X2_lbl_Type";
            this.X2_lbl_Type.Size = new System.Drawing.Size(60, 25);
            this.X2_lbl_Type.TabIndex = 142;
            this.X2_lbl_Type.Text = "Type";
            // 
            // textBox_Contains_str_Type
            // 
            this.textBox_Contains_str_Type.Location = new System.Drawing.Point(104, 1035);
            this.textBox_Contains_str_Type.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_Type.MaxLength = 16;
            this.textBox_Contains_str_Type.Name = "textBox_Contains_str_Type";
            this.textBox_Contains_str_Type.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_Type.TabIndex = 141;
            // 
            // X2_lbl_Groups
            // 
            this.X2_lbl_Groups.AutoSize = true;
            this.X2_lbl_Groups.Location = new System.Drawing.Point(344, 990);
            this.X2_lbl_Groups.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_Groups.Name = "X2_lbl_Groups";
            this.X2_lbl_Groups.Size = new System.Drawing.Size(82, 25);
            this.X2_lbl_Groups.TabIndex = 140;
            this.X2_lbl_Groups.Text = "Groups";
            // 
            // textBox_Contains_str_Groups
            // 
            this.textBox_Contains_str_Groups.Location = new System.Drawing.Point(104, 990);
            this.textBox_Contains_str_Groups.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_Groups.MaxLength = 16;
            this.textBox_Contains_str_Groups.Name = "textBox_Contains_str_Groups";
            this.textBox_Contains_str_Groups.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_Groups.TabIndex = 139;
            // 
            // textBox_infoBox
            // 
            this.textBox_infoBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox_infoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_infoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_infoBox.Location = new System.Drawing.Point(0, 0);
            this.textBox_infoBox.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_infoBox.Multiline = true;
            this.textBox_infoBox.Name = "textBox_infoBox";
            this.textBox_infoBox.ReadOnly = true;
            this.textBox_infoBox.Size = new System.Drawing.Size(1792, 128);
            this.textBox_infoBox.TabIndex = 138;
            this.textBox_infoBox.Text = "info box";
            // 
            // checkBox_Show_Ctrls
            // 
            this.checkBox_Show_Ctrls.AutoSize = true;
            this.checkBox_Show_Ctrls.Location = new System.Drawing.Point(255, 602);
            this.checkBox_Show_Ctrls.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Show_Ctrls.Name = "checkBox_Show_Ctrls";
            this.checkBox_Show_Ctrls.Size = new System.Drawing.Size(172, 29);
            this.checkBox_Show_Ctrls.TabIndex = 137;
            this.checkBox_Show_Ctrls.Text = "Show CTRLS";
            this.checkBox_Show_Ctrls.UseVisualStyleBackColor = true;
            // 
            // checkBox_Show_Group
            // 
            this.checkBox_Show_Group.AutoSize = true;
            this.checkBox_Show_Group.Location = new System.Drawing.Point(254, 559);
            this.checkBox_Show_Group.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Show_Group.Name = "checkBox_Show_Group";
            this.checkBox_Show_Group.Size = new System.Drawing.Size(159, 29);
            this.checkBox_Show_Group.TabIndex = 136;
            this.checkBox_Show_Group.Text = "show Group";
            this.checkBox_Show_Group.UseVisualStyleBackColor = true;
            // 
            // checkBox_Show_Comments
            // 
            this.checkBox_Show_Comments.AutoSize = true;
            this.checkBox_Show_Comments.Location = new System.Drawing.Point(9, 429);
            this.checkBox_Show_Comments.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Show_Comments.Name = "checkBox_Show_Comments";
            this.checkBox_Show_Comments.Size = new System.Drawing.Size(205, 29);
            this.checkBox_Show_Comments.TabIndex = 135;
            this.checkBox_Show_Comments.Text = "Show Comments";
            this.checkBox_Show_Comments.UseVisualStyleBackColor = true;
            // 
            // checkBox_Show_Type
            // 
            this.checkBox_Show_Type.AutoSize = true;
            this.checkBox_Show_Type.Location = new System.Drawing.Point(255, 516);
            this.checkBox_Show_Type.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Show_Type.Name = "checkBox_Show_Type";
            this.checkBox_Show_Type.Size = new System.Drawing.Size(199, 29);
            this.checkBox_Show_Type.TabIndex = 134;
            this.checkBox_Show_Type.Text = "show PGN Type";
            this.checkBox_Show_Type.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowVCformat
            // 
            this.checkBox_ShowVCformat.AutoSize = true;
            this.checkBox_ShowVCformat.Location = new System.Drawing.Point(255, 472);
            this.checkBox_ShowVCformat.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowVCformat.Name = "checkBox_ShowVCformat";
            this.checkBox_ShowVCformat.Size = new System.Drawing.Size(195, 29);
            this.checkBox_ShowVCformat.TabIndex = 133;
            this.checkBox_ShowVCformat.Text = "show VC format";
            this.checkBox_ShowVCformat.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowByteExtentions
            // 
            this.checkBox_ShowByteExtentions.AutoSize = true;
            this.checkBox_ShowByteExtentions.Location = new System.Drawing.Point(10, 602);
            this.checkBox_ShowByteExtentions.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowByteExtentions.Name = "checkBox_ShowByteExtentions";
            this.checkBox_ShowByteExtentions.Size = new System.Drawing.Size(188, 29);
            this.checkBox_ShowByteExtentions.TabIndex = 132;
            this.checkBox_ShowByteExtentions.Text = "ByteExtentions";
            this.checkBox_ShowByteExtentions.UseVisualStyleBackColor = true;
            // 
            // button_Display
            // 
            this.button_Display.Location = new System.Drawing.Point(317, 1341);
            this.button_Display.Name = "button_Display";
            this.button_Display.Size = new System.Drawing.Size(182, 44);
            this.button_Display.TabIndex = 131;
            this.button_Display.Text = "Display";
            this.button_Display.UseVisualStyleBackColor = true;
            // 
            // button_Save_File
            // 
            this.button_Save_File.Location = new System.Drawing.Point(369, 1502);
            this.button_Save_File.Name = "button_Save_File";
            this.button_Save_File.Size = new System.Drawing.Size(105, 44);
            this.button_Save_File.TabIndex = 130;
            this.button_Save_File.Text = "save";
            this.button_Save_File.UseVisualStyleBackColor = true;
            // 
            // textBox_Contains
            // 
            this.textBox_Contains.Location = new System.Drawing.Point(24, 1347);
            this.textBox_Contains.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains.MaxLength = 16;
            this.textBox_Contains.Name = "textBox_Contains";
            this.textBox_Contains.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains.TabIndex = 129;
            this.textBox_Contains.Text = "XXXX____XXXX____";
            this.textBox_Contains.Visible = false;
            // 
            // label_saveFilename
            // 
            this.label_saveFilename.AutoSize = true;
            this.label_saveFilename.Location = new System.Drawing.Point(17, 1557);
            this.label_saveFilename.Name = "label_saveFilename";
            this.label_saveFilename.Size = new System.Drawing.Size(180, 25);
            this.label_saveFilename.TabIndex = 128;
            this.label_saveFilename.Text = "save filename .txt";
            // 
            // textBox_OUTPUTFilePath
            // 
            this.textBox_OUTPUTFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_OUTPUTFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_OUTPUTFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_OUTPUTFilePath.Location = new System.Drawing.Point(0, 1600);
            this.textBox_OUTPUTFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_OUTPUTFilePath.Multiline = true;
            this.textBox_OUTPUTFilePath.Name = "textBox_OUTPUTFilePath";
            this.textBox_OUTPUTFilePath.ReadOnly = true;
            this.textBox_OUTPUTFilePath.Size = new System.Drawing.Size(1792, 56);
            this.textBox_OUTPUTFilePath.TabIndex = 127;
            this.textBox_OUTPUTFilePath.Text = resources.GetString("textBox_OUTPUTFilePath.Text");
            // 
            // X3_label_saveFilename
            // 
            this.X3_label_saveFilename.AutoSize = true;
            this.X3_label_saveFilename.Location = new System.Drawing.Point(10, 1521);
            this.X3_label_saveFilename.Name = "X3_label_saveFilename";
            this.X3_label_saveFilename.Size = new System.Drawing.Size(101, 25);
            this.X3_label_saveFilename.TabIndex = 126;
            this.X3_label_saveFilename.Text = "New File:";
            // 
            // textBox_INPUTsaveFileName
            // 
            this.textBox_INPUTsaveFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_INPUTsaveFileName.Location = new System.Drawing.Point(123, 1522);
            this.textBox_INPUTsaveFileName.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_INPUTsaveFileName.MaxLength = 16;
            this.textBox_INPUTsaveFileName.Name = "textBox_INPUTsaveFileName";
            this.textBox_INPUTsaveFileName.Size = new System.Drawing.Size(235, 24);
            this.textBox_INPUTsaveFileName.TabIndex = 125;
            this.textBox_INPUTsaveFileName.Text = "outFile";
            // 
            // X2_lbl_Project
            // 
            this.X2_lbl_Project.AutoSize = true;
            this.X2_lbl_Project.Location = new System.Drawing.Point(344, 945);
            this.X2_lbl_Project.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_Project.Name = "X2_lbl_Project";
            this.X2_lbl_Project.Size = new System.Drawing.Size(79, 25);
            this.X2_lbl_Project.TabIndex = 124;
            this.X2_lbl_Project.Text = "Project";
            // 
            // X2_lbl_Config
            // 
            this.X2_lbl_Config.AutoSize = true;
            this.X2_lbl_Config.Location = new System.Drawing.Point(344, 900);
            this.X2_lbl_Config.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_Config.Name = "X2_lbl_Config";
            this.X2_lbl_Config.Size = new System.Drawing.Size(140, 25);
            this.X2_lbl_Config.TabIndex = 123;
            this.X2_lbl_Config.Text = "Configuration";
            // 
            // X2_lbl_PGN
            // 
            this.X2_lbl_PGN.AutoSize = true;
            this.X2_lbl_PGN.Location = new System.Drawing.Point(344, 765);
            this.X2_lbl_PGN.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_PGN.Name = "X2_lbl_PGN";
            this.X2_lbl_PGN.Size = new System.Drawing.Size(57, 25);
            this.X2_lbl_PGN.TabIndex = 122;
            this.X2_lbl_PGN.Text = "PGN";
            // 
            // X2_lbl_TxUnit
            // 
            this.X2_lbl_TxUnit.AutoSize = true;
            this.X2_lbl_TxUnit.Location = new System.Drawing.Point(344, 855);
            this.X2_lbl_TxUnit.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X2_lbl_TxUnit.Name = "X2_lbl_TxUnit";
            this.X2_lbl_TxUnit.Size = new System.Drawing.Size(135, 25);
            this.X2_lbl_TxUnit.TabIndex = 121;
            this.X2_lbl_TxUnit.Text = "Sending Unit";
            // 
            // textBox_Contains_str_Project
            // 
            this.textBox_Contains_str_Project.Location = new System.Drawing.Point(104, 945);
            this.textBox_Contains_str_Project.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_Project.MaxLength = 16;
            this.textBox_Contains_str_Project.Name = "textBox_Contains_str_Project";
            this.textBox_Contains_str_Project.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_Project.TabIndex = 120;
            // 
            // textBox_Contains_str_Configuration
            // 
            this.textBox_Contains_str_Configuration.Location = new System.Drawing.Point(104, 900);
            this.textBox_Contains_str_Configuration.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_Configuration.MaxLength = 16;
            this.textBox_Contains_str_Configuration.Name = "textBox_Contains_str_Configuration";
            this.textBox_Contains_str_Configuration.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_Configuration.TabIndex = 119;
            // 
            // textBox_Contains_str_PGN
            // 
            this.textBox_Contains_str_PGN.Location = new System.Drawing.Point(104, 765);
            this.textBox_Contains_str_PGN.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_PGN.MaxLength = 16;
            this.textBox_Contains_str_PGN.Name = "textBox_Contains_str_PGN";
            this.textBox_Contains_str_PGN.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_PGN.TabIndex = 118;
            // 
            // textBox_Contains_str_Sendingunit
            // 
            this.textBox_Contains_str_Sendingunit.Location = new System.Drawing.Point(104, 855);
            this.textBox_Contains_str_Sendingunit.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Contains_str_Sendingunit.MaxLength = 16;
            this.textBox_Contains_str_Sendingunit.Name = "textBox_Contains_str_Sendingunit";
            this.textBox_Contains_str_Sendingunit.Size = new System.Drawing.Size(235, 31);
            this.textBox_Contains_str_Sendingunit.TabIndex = 117;
            // 
            // checkBox_Show_Softwareversion
            // 
            this.checkBox_Show_Softwareversion.AutoSize = true;
            this.checkBox_Show_Softwareversion.Location = new System.Drawing.Point(10, 343);
            this.checkBox_Show_Softwareversion.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Show_Softwareversion.Name = "checkBox_Show_Softwareversion";
            this.checkBox_Show_Softwareversion.Size = new System.Drawing.Size(126, 29);
            this.checkBox_Show_Softwareversion.TabIndex = 116;
            this.checkBox_Show_Softwareversion.Text = "soft vers";
            this.checkBox_Show_Softwareversion.UseVisualStyleBackColor = true;
            // 
            // checkBox_Show32bitpgn
            // 
            this.checkBox_Show32bitpgn.AutoSize = true;
            this.checkBox_Show32bitpgn.Location = new System.Drawing.Point(255, 343);
            this.checkBox_Show32bitpgn.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Show32bitpgn.Name = "checkBox_Show32bitpgn";
            this.checkBox_Show32bitpgn.Size = new System.Drawing.Size(127, 29);
            this.checkBox_Show32bitpgn.TabIndex = 115;
            this.checkBox_Show32bitpgn.Text = "pgn32bit";
            this.checkBox_Show32bitpgn.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowPriority
            // 
            this.checkBox_ShowPriority.AutoSize = true;
            this.checkBox_ShowPriority.Location = new System.Drawing.Point(255, 429);
            this.checkBox_ShowPriority.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowPriority.Name = "checkBox_ShowPriority";
            this.checkBox_ShowPriority.Size = new System.Drawing.Size(111, 29);
            this.checkBox_ShowPriority.TabIndex = 114;
            this.checkBox_ShowPriority.Text = "Priority";
            this.checkBox_ShowPriority.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowAddresses
            // 
            this.checkBox_ShowAddresses.AutoSize = true;
            this.checkBox_ShowAddresses.Location = new System.Drawing.Point(255, 386);
            this.checkBox_ShowAddresses.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowAddresses.Name = "checkBox_ShowAddresses";
            this.checkBox_ShowAddresses.Size = new System.Drawing.Size(144, 29);
            this.checkBox_ShowAddresses.TabIndex = 113;
            this.checkBox_ShowAddresses.Text = "addresses";
            this.checkBox_ShowAddresses.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowID
            // 
            this.checkBox_ShowID.AutoSize = true;
            this.checkBox_ShowID.Location = new System.Drawing.Point(255, 300);
            this.checkBox_ShowID.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowID.Name = "checkBox_ShowID";
            this.checkBox_ShowID.Size = new System.Drawing.Size(75, 29);
            this.checkBox_ShowID.TabIndex = 112;
            this.checkBox_ShowID.Text = "IDs";
            this.checkBox_ShowID.UseVisualStyleBackColor = true;
            // 
            // label_MatchesFound
            // 
            this.label_MatchesFound.AutoSize = true;
            this.label_MatchesFound.Location = new System.Drawing.Point(196, 1277);
            this.label_MatchesFound.Name = "label_MatchesFound";
            this.label_MatchesFound.Size = new System.Drawing.Size(23, 25);
            this.label_MatchesFound.TabIndex = 111;
            this.label_MatchesFound.Text = "x";
            // 
            // X1_label3
            // 
            this.X1_label3.AutoSize = true;
            this.X1_label3.Location = new System.Drawing.Point(21, 1277);
            this.X1_label3.Name = "X1_label3";
            this.X1_label3.Size = new System.Drawing.Size(154, 25);
            this.X1_label3.TabIndex = 110;
            this.X1_label3.Text = "found Matches";
            // 
            // X1_label2
            // 
            this.X1_label2.AutoSize = true;
            this.X1_label2.Location = new System.Drawing.Point(14, 722);
            this.X1_label2.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.X1_label2.Name = "X1_label2";
            this.X1_label2.Size = new System.Drawing.Size(71, 25);
            this.X1_label2.TabIndex = 109;
            this.X1_label2.Text = "Filters";
            // 
            // checkBox_Configuration
            // 
            this.checkBox_Configuration.AutoSize = true;
            this.checkBox_Configuration.Location = new System.Drawing.Point(10, 472);
            this.checkBox_Configuration.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Configuration.Name = "checkBox_Configuration";
            this.checkBox_Configuration.Size = new System.Drawing.Size(172, 29);
            this.checkBox_Configuration.TabIndex = 108;
            this.checkBox_Configuration.Text = "Configuration";
            this.checkBox_Configuration.UseVisualStyleBackColor = true;
            // 
            // checkBox_Project
            // 
            this.checkBox_Project.AutoSize = true;
            this.checkBox_Project.Location = new System.Drawing.Point(10, 516);
            this.checkBox_Project.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Project.Name = "checkBox_Project";
            this.checkBox_Project.Size = new System.Drawing.Size(111, 29);
            this.checkBox_Project.TabIndex = 107;
            this.checkBox_Project.Text = "Project";
            this.checkBox_Project.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowFrom
            // 
            this.checkBox_ShowFrom.AutoSize = true;
            this.checkBox_ShowFrom.Location = new System.Drawing.Point(10, 300);
            this.checkBox_ShowFrom.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowFrom.Name = "checkBox_ShowFrom";
            this.checkBox_ShowFrom.Size = new System.Drawing.Size(167, 29);
            this.checkBox_ShowFrom.TabIndex = 106;
            this.checkBox_ShowFrom.Text = "Sending Unit";
            this.checkBox_ShowFrom.UseVisualStyleBackColor = true;
            // 
            // checkBox_Info
            // 
            this.checkBox_Info.AutoSize = true;
            this.checkBox_Info.Location = new System.Drawing.Point(10, 386);
            this.checkBox_Info.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Info.Name = "checkBox_Info";
            this.checkBox_Info.Size = new System.Drawing.Size(123, 29);
            this.checkBox_Info.TabIndex = 105;
            this.checkBox_Info.Text = "Pgn Info";
            this.checkBox_Info.UseVisualStyleBackColor = true;
            // 
            // checkBox_BytesShowVerbos
            // 
            this.checkBox_BytesShowVerbos.AutoSize = true;
            this.checkBox_BytesShowVerbos.Location = new System.Drawing.Point(9, 559);
            this.checkBox_BytesShowVerbos.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_BytesShowVerbos.Name = "checkBox_BytesShowVerbos";
            this.checkBox_BytesShowVerbos.Size = new System.Drawing.Size(149, 29);
            this.checkBox_BytesShowVerbos.TabIndex = 104;
            this.checkBox_BytesShowVerbos.Text = "Data Bytes";
            this.checkBox_BytesShowVerbos.UseVisualStyleBackColor = true;
            // 
            // checkBox_BitsShowVerbos
            // 
            this.checkBox_BitsShowVerbos.AutoSize = true;
            this.checkBox_BitsShowVerbos.Location = new System.Drawing.Point(10, 646);
            this.checkBox_BitsShowVerbos.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_BitsShowVerbos.Name = "checkBox_BitsShowVerbos";
            this.checkBox_BitsShowVerbos.Size = new System.Drawing.Size(131, 29);
            this.checkBox_BitsShowVerbos.TabIndex = 103;
            this.checkBox_BitsShowVerbos.Text = "Data Bits";
            this.checkBox_BitsShowVerbos.UseVisualStyleBackColor = true;
            // 
            // checkBox_PgnShowVerbos
            // 
            this.checkBox_PgnShowVerbos.AutoSize = true;
            this.checkBox_PgnShowVerbos.Location = new System.Drawing.Point(255, 257);
            this.checkBox_PgnShowVerbos.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_PgnShowVerbos.Name = "checkBox_PgnShowVerbos";
            this.checkBox_PgnShowVerbos.Size = new System.Drawing.Size(171, 29);
            this.checkBox_PgnShowVerbos.TabIndex = 102;
            this.checkBox_PgnShowVerbos.Text = "Show Verbos";
            this.checkBox_PgnShowVerbos.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowDate
            // 
            this.checkBox_ShowDate.AutoSize = true;
            this.checkBox_ShowDate.Location = new System.Drawing.Point(10, 257);
            this.checkBox_ShowDate.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_ShowDate.Name = "checkBox_ShowDate";
            this.checkBox_ShowDate.Size = new System.Drawing.Size(148, 29);
            this.checkBox_ShowDate.TabIndex = 101;
            this.checkBox_ShowDate.Text = "Show Date";
            this.checkBox_ShowDate.UseVisualStyleBackColor = true;
            // 
            // label_totalPgnsInDb
            // 
            this.label_totalPgnsInDb.AutoSize = true;
            this.label_totalPgnsInDb.Location = new System.Drawing.Point(340, 222);
            this.label_totalPgnsInDb.Name = "label_totalPgnsInDb";
            this.label_totalPgnsInDb.Size = new System.Drawing.Size(23, 25);
            this.label_totalPgnsInDb.TabIndex = 100;
            this.label_totalPgnsInDb.Text = "x";
            // 
            // X1_label1
            // 
            this.X1_label1.AutoSize = true;
            this.X1_label1.Location = new System.Drawing.Point(6, 222);
            this.X1_label1.Name = "X1_label1";
            this.X1_label1.Size = new System.Drawing.Size(344, 25);
            this.X1_label1.TabIndex = 99;
            this.X1_label1.Text = "Totale Pgn definitions in database:";
            // 
            // textBox_Display
            // 
            this.textBox_Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Display.Location = new System.Drawing.Point(630, 127);
            this.textBox_Display.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Display.Multiline = true;
            this.textBox_Display.Name = "textBox_Display";
            this.textBox_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Display.Size = new System.Drawing.Size(1162, 1455);
            this.textBox_Display.TabIndex = 98;
            // 
            // PGN_Manager_ViewerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 1656);
            this.Controls.Add(this.cb_exclude_project);
            this.Controls.Add(this.cb_exclude_group);
            this.Controls.Add(this.cb_exclude_type);
            this.Controls.Add(this.cb_exclude_ctrl);
            this.Controls.Add(this.cb_exclude_configuration);
            this.Controls.Add(this.cb_exclude_sendingunit);
            this.Controls.Add(this.cb_exclude_version);
            this.Controls.Add(this.cb_exclude_Pgn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Contains_str_UVersion);
            this.Controls.Add(this.X2_lbl_CTRLs);
            this.Controls.Add(this.textBox_Contains_str_CTRLs);
            this.Controls.Add(this.X2_lbl_Type);
            this.Controls.Add(this.textBox_Contains_str_Type);
            this.Controls.Add(this.X2_lbl_Groups);
            this.Controls.Add(this.textBox_Contains_str_Groups);
            this.Controls.Add(this.textBox_infoBox);
            this.Controls.Add(this.checkBox_Show_Ctrls);
            this.Controls.Add(this.checkBox_Show_Group);
            this.Controls.Add(this.checkBox_Show_Comments);
            this.Controls.Add(this.checkBox_Show_Type);
            this.Controls.Add(this.checkBox_ShowVCformat);
            this.Controls.Add(this.checkBox_ShowByteExtentions);
            this.Controls.Add(this.button_Display);
            this.Controls.Add(this.button_Save_File);
            this.Controls.Add(this.textBox_Contains);
            this.Controls.Add(this.label_saveFilename);
            this.Controls.Add(this.textBox_OUTPUTFilePath);
            this.Controls.Add(this.X3_label_saveFilename);
            this.Controls.Add(this.textBox_INPUTsaveFileName);
            this.Controls.Add(this.X2_lbl_Project);
            this.Controls.Add(this.X2_lbl_Config);
            this.Controls.Add(this.X2_lbl_PGN);
            this.Controls.Add(this.X2_lbl_TxUnit);
            this.Controls.Add(this.textBox_Contains_str_Project);
            this.Controls.Add(this.textBox_Contains_str_Configuration);
            this.Controls.Add(this.textBox_Contains_str_PGN);
            this.Controls.Add(this.textBox_Contains_str_Sendingunit);
            this.Controls.Add(this.checkBox_Show_Softwareversion);
            this.Controls.Add(this.checkBox_Show32bitpgn);
            this.Controls.Add(this.checkBox_ShowPriority);
            this.Controls.Add(this.checkBox_ShowAddresses);
            this.Controls.Add(this.checkBox_ShowID);
            this.Controls.Add(this.label_MatchesFound);
            this.Controls.Add(this.X1_label3);
            this.Controls.Add(this.X1_label2);
            this.Controls.Add(this.checkBox_Configuration);
            this.Controls.Add(this.checkBox_Project);
            this.Controls.Add(this.checkBox_ShowFrom);
            this.Controls.Add(this.checkBox_Info);
            this.Controls.Add(this.checkBox_BytesShowVerbos);
            this.Controls.Add(this.checkBox_BitsShowVerbos);
            this.Controls.Add(this.checkBox_PgnShowVerbos);
            this.Controls.Add(this.checkBox_ShowDate);
            this.Controls.Add(this.label_totalPgnsInDb);
            this.Controls.Add(this.X1_label1);
            this.Controls.Add(this.textBox_Display);
            this.Name = "PGN_Manager_ViewerGUI";
            this.Text = "PGN_Manager_ViewerGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_exclude_project;
        private System.Windows.Forms.CheckBox cb_exclude_group;
        private System.Windows.Forms.CheckBox cb_exclude_type;
        private System.Windows.Forms.CheckBox cb_exclude_ctrl;
        private System.Windows.Forms.CheckBox cb_exclude_configuration;
        private System.Windows.Forms.CheckBox cb_exclude_sendingunit;
        private System.Windows.Forms.CheckBox cb_exclude_version;
        private System.Windows.Forms.CheckBox cb_exclude_Pgn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Contains_str_UVersion;
        private System.Windows.Forms.Label X2_lbl_CTRLs;
        private System.Windows.Forms.TextBox textBox_Contains_str_CTRLs;
        private System.Windows.Forms.Label X2_lbl_Type;
        private System.Windows.Forms.TextBox textBox_Contains_str_Type;
        private System.Windows.Forms.Label X2_lbl_Groups;
        private System.Windows.Forms.TextBox textBox_Contains_str_Groups;
        private System.Windows.Forms.TextBox textBox_infoBox;
        private System.Windows.Forms.CheckBox checkBox_Show_Ctrls;
        private System.Windows.Forms.CheckBox checkBox_Show_Group;
        private System.Windows.Forms.CheckBox checkBox_Show_Comments;
        private System.Windows.Forms.CheckBox checkBox_Show_Type;
        private System.Windows.Forms.CheckBox checkBox_ShowVCformat;
        private System.Windows.Forms.CheckBox checkBox_ShowByteExtentions;
        private System.Windows.Forms.Button button_Display;
        private System.Windows.Forms.Button button_Save_File;
        private System.Windows.Forms.TextBox textBox_Contains;
        private System.Windows.Forms.Label label_saveFilename;
        private System.Windows.Forms.TextBox textBox_OUTPUTFilePath;
        private System.Windows.Forms.Label X3_label_saveFilename;
        private System.Windows.Forms.TextBox textBox_INPUTsaveFileName;
        private System.Windows.Forms.Label X2_lbl_Project;
        private System.Windows.Forms.Label X2_lbl_Config;
        private System.Windows.Forms.Label X2_lbl_PGN;
        private System.Windows.Forms.Label X2_lbl_TxUnit;
        private System.Windows.Forms.TextBox textBox_Contains_str_Project;
        private System.Windows.Forms.TextBox textBox_Contains_str_Configuration;
        private System.Windows.Forms.TextBox textBox_Contains_str_PGN;
        private System.Windows.Forms.TextBox textBox_Contains_str_Sendingunit;
        private System.Windows.Forms.CheckBox checkBox_Show_Softwareversion;
        private System.Windows.Forms.CheckBox checkBox_Show32bitpgn;
        private System.Windows.Forms.CheckBox checkBox_ShowPriority;
        private System.Windows.Forms.CheckBox checkBox_ShowAddresses;
        private System.Windows.Forms.CheckBox checkBox_ShowID;
        private System.Windows.Forms.Label label_MatchesFound;
        private System.Windows.Forms.Label X1_label3;
        private System.Windows.Forms.Label X1_label2;
        private System.Windows.Forms.CheckBox checkBox_Configuration;
        private System.Windows.Forms.CheckBox checkBox_Project;
        private System.Windows.Forms.CheckBox checkBox_ShowFrom;
        private System.Windows.Forms.CheckBox checkBox_Info;
        private System.Windows.Forms.CheckBox checkBox_BytesShowVerbos;
        private System.Windows.Forms.CheckBox checkBox_BitsShowVerbos;
        private System.Windows.Forms.CheckBox checkBox_PgnShowVerbos;
        private System.Windows.Forms.CheckBox checkBox_ShowDate;
        private System.Windows.Forms.Label label_totalPgnsInDb;
        private System.Windows.Forms.Label X1_label1;
        private System.Windows.Forms.TextBox textBox_Display;
    }
}