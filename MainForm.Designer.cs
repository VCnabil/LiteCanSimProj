namespace LiteCanSimProj
{
    partial class MainForm
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
            this.btn_FormSerialTester = new System.Windows.Forms.Button();
            this.btn_SerialBridgeForm = new System.Windows.Forms.Button();
            this.btn_BridgeFormSunc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_FormSerialTester
            // 
            this.btn_FormSerialTester.Location = new System.Drawing.Point(26, 12);
            this.btn_FormSerialTester.Name = "btn_FormSerialTester";
            this.btn_FormSerialTester.Size = new System.Drawing.Size(252, 82);
            this.btn_FormSerialTester.TabIndex = 0;
            this.btn_FormSerialTester.Text = "SerialTester";
            this.btn_FormSerialTester.UseVisualStyleBackColor = true;
            // 
            // btn_SerialBridgeForm
            // 
            this.btn_SerialBridgeForm.Location = new System.Drawing.Point(26, 100);
            this.btn_SerialBridgeForm.Name = "btn_SerialBridgeForm";
            this.btn_SerialBridgeForm.Size = new System.Drawing.Size(252, 82);
            this.btn_SerialBridgeForm.TabIndex = 1;
            this.btn_SerialBridgeForm.Text = "RawBridge";
            this.btn_SerialBridgeForm.UseVisualStyleBackColor = true;
            // 
            // btn_BridgeFormSunc
            // 
            this.btn_BridgeFormSunc.Location = new System.Drawing.Point(26, 200);
            this.btn_BridgeFormSunc.Name = "btn_BridgeFormSunc";
            this.btn_BridgeFormSunc.Size = new System.Drawing.Size(252, 82);
            this.btn_BridgeFormSunc.TabIndex = 3;
            this.btn_BridgeFormSunc.Text = "Bridge Display";
            this.btn_BridgeFormSunc.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 310);
            this.Controls.Add(this.btn_BridgeFormSunc);
            this.Controls.Add(this.btn_SerialBridgeForm);
            this.Controls.Add(this.btn_FormSerialTester);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_FormSerialTester;
        private System.Windows.Forms.Button btn_SerialBridgeForm;
        private System.Windows.Forms.Button btn_BridgeFormSunc;
    }
}