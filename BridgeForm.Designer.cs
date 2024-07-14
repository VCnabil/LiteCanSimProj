namespace LiteCanSimProj
{
    partial class BridgeForm
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
            this.lbl_104 = new System.Windows.Forms.Label();
            this.lbl_103 = new System.Windows.Forms.Label();
            this.tb_104types = new System.Windows.Forms.TextBox();
            this.tb_103types = new System.Windows.Forms.TextBox();
            this.comboBox_AntennaSC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBridge = new System.Windows.Forms.Button();
            this.comboBox_PCURSC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLaptopType = new System.Windows.Forms.CheckBox();
            this.lbl_PCname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_104
            // 
            this.lbl_104.AutoSize = true;
            this.lbl_104.Location = new System.Drawing.Point(804, 207);
            this.lbl_104.Name = "lbl_104";
            this.lbl_104.Size = new System.Drawing.Size(188, 25);
            this.lbl_104.TabIndex = 34;
            this.lbl_104.Text = "Messagestype104";
            // 
            // lbl_103
            // 
            this.lbl_103.AutoSize = true;
            this.lbl_103.Location = new System.Drawing.Point(23, 207);
            this.lbl_103.Name = "lbl_103";
            this.lbl_103.Size = new System.Drawing.Size(188, 25);
            this.lbl_103.TabIndex = 33;
            this.lbl_103.Text = "Messagestype103";
            // 
            // tb_104types
            // 
            this.tb_104types.Location = new System.Drawing.Point(809, 252);
            this.tb_104types.Multiline = true;
            this.tb_104types.Name = "tb_104types";
            this.tb_104types.Size = new System.Drawing.Size(684, 574);
            this.tb_104types.TabIndex = 32;
            // 
            // tb_103types
            // 
            this.tb_103types.Location = new System.Drawing.Point(19, 252);
            this.tb_103types.Multiline = true;
            this.tb_103types.Name = "tb_103types";
            this.tb_103types.Size = new System.Drawing.Size(684, 574);
            this.tb_103types.TabIndex = 31;
            // 
            // comboBox_AntennaSC
            // 
            this.comboBox_AntennaSC.FormattingEnabled = true;
            this.comboBox_AntennaSC.Location = new System.Drawing.Point(121, 57);
            this.comboBox_AntennaSC.Name = "comboBox_AntennaSC";
            this.comboBox_AntennaSC.Size = new System.Drawing.Size(163, 33);
            this.comboBox_AntennaSC.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "MBIV";
            // 
            // btnBridge
            // 
            this.btnBridge.Location = new System.Drawing.Point(314, 57);
            this.btnBridge.Name = "btnBridge";
            this.btnBridge.Size = new System.Drawing.Size(259, 79);
            this.btnBridge.TabIndex = 30;
            this.btnBridge.Text = "Connect";
            this.btnBridge.UseVisualStyleBackColor = true;
            // 
            // comboBox_PCURSC
            // 
            this.comboBox_PCURSC.FormattingEnabled = true;
            this.comboBox_PCURSC.Location = new System.Drawing.Point(121, 99);
            this.comboBox_PCURSC.Name = "comboBox_PCURSC";
            this.comboBox_PCURSC.Size = new System.Drawing.Size(163, 33);
            this.comboBox_PCURSC.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Antenna";
            // 
            // checkBoxLaptopType
            // 
            this.checkBoxLaptopType.AutoSize = true;
            this.checkBoxLaptopType.Location = new System.Drawing.Point(19, 12);
            this.checkBoxLaptopType.Name = "checkBoxLaptopType";
            this.checkBoxLaptopType.Size = new System.Drawing.Size(193, 29);
            this.checkBoxLaptopType.TabIndex = 25;
            this.checkBoxLaptopType.Text = "is laptop PCU ?";
            this.checkBoxLaptopType.UseVisualStyleBackColor = true;
            // 
            // lbl_PCname
            // 
            this.lbl_PCname.AutoSize = true;
            this.lbl_PCname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PCname.Location = new System.Drawing.Point(812, 12);
            this.lbl_PCname.Name = "lbl_PCname";
            this.lbl_PCname.Size = new System.Drawing.Size(161, 55);
            this.lbl_PCname.TabIndex = 35;
            this.lbl_PCname.Text = "laptop";
            // 
            // BridgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 845);
            this.Controls.Add(this.lbl_PCname);
            this.Controls.Add(this.lbl_104);
            this.Controls.Add(this.lbl_103);
            this.Controls.Add(this.tb_104types);
            this.Controls.Add(this.tb_103types);
            this.Controls.Add(this.comboBox_AntennaSC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBridge);
            this.Controls.Add(this.comboBox_PCURSC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxLaptopType);
            this.Name = "BridgeForm";
            this.Text = "BridgeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_104;
        private System.Windows.Forms.Label lbl_103;
        private System.Windows.Forms.TextBox tb_104types;
        private System.Windows.Forms.TextBox tb_103types;
        private System.Windows.Forms.ComboBox comboBox_AntennaSC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBridge;
        private System.Windows.Forms.ComboBox comboBox_PCURSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxLaptopType;
        private System.Windows.Forms.Label lbl_PCname;
    }
}