namespace LiteCanSimProj
{
    partial class FormBridge
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
            this.checkBoxLaptopType = new System.Windows.Forms.CheckBox();
            this.tb_104types = new System.Windows.Forms.TextBox();
            this.tb_103types = new System.Windows.Forms.TextBox();
            this.comboBox_AntennaSC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBridge = new System.Windows.Forms.Button();
            this.comboBox_PCURSC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxLaptopType
            // 
            this.checkBoxLaptopType.AutoSize = true;
            this.checkBoxLaptopType.Location = new System.Drawing.Point(550, 33);
            this.checkBoxLaptopType.Name = "checkBoxLaptopType";
            this.checkBoxLaptopType.Size = new System.Drawing.Size(193, 29);
            this.checkBoxLaptopType.TabIndex = 0;
            this.checkBoxLaptopType.Text = "is laptop PCU ?";
            this.checkBoxLaptopType.UseVisualStyleBackColor = true;
            // 
            // tb_104types
            // 
            this.tb_104types.Location = new System.Drawing.Point(933, 602);
            this.tb_104types.Multiline = true;
            this.tb_104types.Name = "tb_104types";
            this.tb_104types.Size = new System.Drawing.Size(684, 477);
            this.tb_104types.TabIndex = 22;
            // 
            // tb_103types
            // 
            this.tb_103types.Location = new System.Drawing.Point(134, 602);
            this.tb_103types.Multiline = true;
            this.tb_103types.Name = "tb_103types";
            this.tb_103types.Size = new System.Drawing.Size(684, 477);
            this.tb_103types.TabIndex = 21;
            // 
            // comboBox_AntennaSC
            // 
            this.comboBox_AntennaSC.FormattingEnabled = true;
            this.comboBox_AntennaSC.Location = new System.Drawing.Point(157, 404);
            this.comboBox_AntennaSC.Name = "comboBox_AntennaSC";
            this.comboBox_AntennaSC.Size = new System.Drawing.Size(163, 33);
            this.comboBox_AntennaSC.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1084, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "MBIV";
            // 
            // btnBridge
            // 
            this.btnBridge.Location = new System.Drawing.Point(553, 374);
            this.btnBridge.Name = "btnBridge";
            this.btnBridge.Size = new System.Drawing.Size(319, 90);
            this.btnBridge.TabIndex = 20;
            this.btnBridge.Text = "button1";
            this.btnBridge.UseVisualStyleBackColor = true;
            // 
            // comboBox_PCURSC
            // 
            this.comboBox_PCURSC.FormattingEnabled = true;
            this.comboBox_PCURSC.Location = new System.Drawing.Point(976, 407);
            this.comboBox_PCURSC.Name = "comboBox_PCURSC";
            this.comboBox_PCURSC.Size = new System.Drawing.Size(178, 33);
            this.comboBox_PCURSC.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Antenna";
            // 
            // FormBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 1446);
            this.Controls.Add(this.tb_104types);
            this.Controls.Add(this.tb_103types);
            this.Controls.Add(this.comboBox_AntennaSC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBridge);
            this.Controls.Add(this.comboBox_PCURSC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxLaptopType);
            this.Name = "FormBridge";
            this.Text = "FormBridge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxLaptopType;
        private System.Windows.Forms.TextBox tb_104types;
        private System.Windows.Forms.TextBox tb_103types;
        private System.Windows.Forms.ComboBox comboBox_AntennaSC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBridge;
        private System.Windows.Forms.ComboBox comboBox_PCURSC;
        private System.Windows.Forms.Label label1;
    }
}