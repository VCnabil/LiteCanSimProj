namespace LiteCanSimProj
{
    partial class Form3
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
            this.comboSerial2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBridge = new System.Windows.Forms.Button();
            this.comboSerial1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBridgeContent1 = new System.Windows.Forms.TextBox();
            this.checkBox_is104 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboSerial2
            // 
            this.comboSerial2.FormattingEnabled = true;
            this.comboSerial2.Location = new System.Drawing.Point(35, 55);
            this.comboSerial2.Name = "comboSerial2";
            this.comboSerial2.Size = new System.Drawing.Size(163, 33);
            this.comboSerial2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(962, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // btnBridge
            // 
            this.btnBridge.Location = new System.Drawing.Point(431, 25);
            this.btnBridge.Name = "btnBridge";
            this.btnBridge.Size = new System.Drawing.Size(319, 90);
            this.btnBridge.TabIndex = 11;
            this.btnBridge.Text = "button1";
            this.btnBridge.UseVisualStyleBackColor = true;
            // 
            // comboSerial1
            // 
            this.comboSerial1.FormattingEnabled = true;
            this.comboSerial1.Location = new System.Drawing.Point(854, 58);
            this.comboSerial1.Name = "comboSerial1";
            this.comboSerial1.Size = new System.Drawing.Size(178, 33);
            this.comboSerial1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // textBoxBridgeContent1
            // 
            this.textBoxBridgeContent1.Location = new System.Drawing.Point(24, 150);
            this.textBoxBridgeContent1.Multiline = true;
            this.textBoxBridgeContent1.Name = "textBoxBridgeContent1";
            this.textBoxBridgeContent1.Size = new System.Drawing.Size(1021, 221);
            this.textBoxBridgeContent1.TabIndex = 13;
            // 
            // checkBox_is104
            // 
            this.checkBox_is104.AutoSize = true;
            this.checkBox_is104.Location = new System.Drawing.Point(225, 58);
            this.checkBox_is104.Name = "checkBox_is104";
            this.checkBox_is104.Size = new System.Drawing.Size(96, 29);
            this.checkBox_is104.TabIndex = 14;
            this.checkBox_is104.Text = "is104";
            this.checkBox_is104.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 460);
            this.Controls.Add(this.checkBox_is104);
            this.Controls.Add(this.textBoxBridgeContent1);
            this.Controls.Add(this.comboSerial2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBridge);
            this.Controls.Add(this.comboSerial1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboSerial2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBridge;
        private System.Windows.Forms.ComboBox comboSerial1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBridgeContent1;
        private System.Windows.Forms.CheckBox checkBox_is104;
    }
}