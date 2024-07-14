namespace LiteCanSimProj
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSerial1 = new System.Windows.Forms.ComboBox();
            this.comboSerial2 = new System.Windows.Forms.ComboBox();
            this.btnBridge = new System.Windows.Forms.Button();
            this.textBoxBridgeContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // comboSerial1
            // 
            this.comboSerial1.FormattingEnabled = true;
            this.comboSerial1.Location = new System.Drawing.Point(311, 61);
            this.comboSerial1.Name = "comboSerial1";
            this.comboSerial1.Size = new System.Drawing.Size(178, 33);
            this.comboSerial1.TabIndex = 2;
            // 
            // comboSerial2
            // 
            this.comboSerial2.FormattingEnabled = true;
            this.comboSerial2.Location = new System.Drawing.Point(46, 61);
            this.comboSerial2.Name = "comboSerial2";
            this.comboSerial2.Size = new System.Drawing.Size(163, 33);
            this.comboSerial2.TabIndex = 3;
            // 
            // btnBridge
            // 
            this.btnBridge.Location = new System.Drawing.Point(69, 258);
            this.btnBridge.Name = "btnBridge";
            this.btnBridge.Size = new System.Drawing.Size(319, 90);
            this.btnBridge.TabIndex = 4;
            this.btnBridge.Text = "button1";
            this.btnBridge.UseVisualStyleBackColor = true;
            // 
            // textBoxBridgeContent
            // 
            this.textBoxBridgeContent.Location = new System.Drawing.Point(556, 12);
            this.textBoxBridgeContent.Multiline = true;
            this.textBoxBridgeContent.Name = "textBoxBridgeContent";
            this.textBoxBridgeContent.Size = new System.Drawing.Size(630, 428);
            this.textBoxBridgeContent.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 452);
            this.Controls.Add(this.textBoxBridgeContent);
            this.Controls.Add(this.comboSerial2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBridge);
            this.Controls.Add(this.comboSerial1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSerial1;
        private System.Windows.Forms.ComboBox comboSerial2;
        private System.Windows.Forms.Button btnBridge;
        private System.Windows.Forms.TextBox textBoxBridgeContent;
    }
}