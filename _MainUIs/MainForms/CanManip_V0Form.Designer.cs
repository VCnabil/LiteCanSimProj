namespace LiteCanSimProj._MainUIs.MainForms
{
    partial class CanManip_V0Form
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
            this.components = new System.ComponentModel.Container();
            this.ucf_KvsrCanMod = new LiteCanSimProj._MainUIs.KvaserUCs.ucf_KvaserCanModule();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_version = new System.Windows.Forms.Label();
            this.button_delete_selectedFile = new System.Windows.Forms.Button();
            this.cb_DoPingpong = new System.Windows.Forms.CheckBox();
            this.button_makeNew = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label_pgnsFound = new System.Windows.Forms.Label();
            this.comboBox_loadFileNames = new System.Windows.Forms.ComboBox();
            this.btn_Load = new System.Windows.Forms.Button();
            this.label_selectedFilePath = new System.Windows.Forms.Label();
            this.textBox_Display = new System.Windows.Forms.TextBox();
            this.timer1_pingpong = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ucf_KvsrCanMod
            // 
            this.ucf_KvsrCanMod.Location = new System.Drawing.Point(13, 13);
            this.ucf_KvsrCanMod.Name = "ucf_KvsrCanMod";
            this.ucf_KvsrCanMod.Size = new System.Drawing.Size(700, 94);
            this.ucf_KvsrCanMod.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(2390, 1307);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(1034, 71);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(120, 25);
            this.lbl_version.TabIndex = 43;
            this.lbl_version.Text = "version X.3";
            // 
            // button_delete_selectedFile
            // 
            this.button_delete_selectedFile.Location = new System.Drawing.Point(825, 61);
            this.button_delete_selectedFile.Name = "button_delete_selectedFile";
            this.button_delete_selectedFile.Size = new System.Drawing.Size(199, 46);
            this.button_delete_selectedFile.TabIndex = 42;
            this.button_delete_selectedFile.Text = "deleteFile";
            this.button_delete_selectedFile.UseVisualStyleBackColor = true;
            // 
            // cb_DoPingpong
            // 
            this.cb_DoPingpong.AutoSize = true;
            this.cb_DoPingpong.Location = new System.Drawing.Point(1757, 17);
            this.cb_DoPingpong.Name = "cb_DoPingpong";
            this.cb_DoPingpong.Size = new System.Drawing.Size(160, 29);
            this.cb_DoPingpong.TabIndex = 41;
            this.cb_DoPingpong.Text = "Auto Sliders";
            this.cb_DoPingpong.UseVisualStyleBackColor = true;
            // 
            // button_makeNew
            // 
            this.button_makeNew.BackColor = System.Drawing.Color.DarkKhaki;
            this.button_makeNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_makeNew.ForeColor = System.Drawing.Color.DarkBlue;
            this.button_makeNew.Location = new System.Drawing.Point(1552, 17);
            this.button_makeNew.Name = "button_makeNew";
            this.button_makeNew.Size = new System.Drawing.Size(160, 40);
            this.button_makeNew.TabIndex = 40;
            this.button_makeNew.Text = "PGN LIST";
            this.button_makeNew.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1324, 71);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(207, 40);
            this.btnClear.TabIndex = 39;
            this.btnClear.Text = "clear GUI";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label_pgnsFound
            // 
            this.label_pgnsFound.AutoSize = true;
            this.label_pgnsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pgnsFound.Location = new System.Drawing.Point(1171, 17);
            this.label_pgnsFound.Name = "label_pgnsFound";
            this.label_pgnsFound.Size = new System.Drawing.Size(110, 24);
            this.label_pgnsFound.TabIndex = 38;
            this.label_pgnsFound.Text = "itemsFound";
            // 
            // comboBox_loadFileNames
            // 
            this.comboBox_loadFileNames.FormattingEnabled = true;
            this.comboBox_loadFileNames.Location = new System.Drawing.Point(825, 13);
            this.comboBox_loadFileNames.Name = "comboBox_loadFileNames";
            this.comboBox_loadFileNames.Size = new System.Drawing.Size(329, 33);
            this.comboBox_loadFileNames.TabIndex = 37;
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(1324, 17);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(207, 47);
            this.btn_Load.TabIndex = 36;
            this.btn_Load.Text = "Load GUI";
            this.btn_Load.UseVisualStyleBackColor = true;
            // 
            // label_selectedFilePath
            // 
            this.label_selectedFilePath.AutoSize = true;
            this.label_selectedFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_selectedFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_selectedFilePath.Location = new System.Drawing.Point(0, 1945);
            this.label_selectedFilePath.Name = "label_selectedFilePath";
            this.label_selectedFilePath.Size = new System.Drawing.Size(46, 24);
            this.label_selectedFilePath.TabIndex = 44;
            this.label_selectedFilePath.Text = "path";
            // 
            // textBox_Display
            // 
            this.textBox_Display.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Display.Location = new System.Drawing.Point(4, 1466);
            this.textBox_Display.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Display.Multiline = true;
            this.textBox_Display.Name = "textBox_Display";
            this.textBox_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Display.Size = new System.Drawing.Size(2398, 460);
            this.textBox_Display.TabIndex = 45;
            // 
            // CanManip_V0Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(2425, 1969);
            this.Controls.Add(this.textBox_Display);
            this.Controls.Add(this.label_selectedFilePath);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.button_delete_selectedFile);
            this.Controls.Add(this.cb_DoPingpong);
            this.Controls.Add(this.button_makeNew);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label_pgnsFound);
            this.Controls.Add(this.comboBox_loadFileNames);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ucf_KvsrCanMod);
            this.Name = "CanManip_V0Form";
            this.Text = "CanManip_V0Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KvaserUCs.ucf_KvaserCanModule ucf_KvsrCanMod;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Button button_delete_selectedFile;
        private System.Windows.Forms.CheckBox cb_DoPingpong;
        private System.Windows.Forms.Button button_makeNew;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label_pgnsFound;
        private System.Windows.Forms.ComboBox comboBox_loadFileNames;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Label label_selectedFilePath;
        private System.Windows.Forms.TextBox textBox_Display;
        private System.Windows.Forms.Timer timer1_pingpong;
    }
}