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
            this.btn_mybridgedisplay = new System.Windows.Forms.Button();
            this.cb_auto = new System.Windows.Forms.CheckBox();
            this.btn_BridgeFormSync = new System.Windows.Forms.Button();
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
            // btn_mybridgedisplay
            // 
            this.btn_mybridgedisplay.Location = new System.Drawing.Point(26, 307);
            this.btn_mybridgedisplay.Name = "btn_mybridgedisplay";
            this.btn_mybridgedisplay.Size = new System.Drawing.Size(191, 82);
            this.btn_mybridgedisplay.TabIndex = 3;
            this.btn_mybridgedisplay.Text = "Bridge Display";
            this.btn_mybridgedisplay.UseVisualStyleBackColor = true;
            // 
            // cb_auto
            // 
            this.cb_auto.AutoSize = true;
            this.cb_auto.Location = new System.Drawing.Point(26, 188);
            this.cb_auto.Name = "cb_auto";
            this.cb_auto.Size = new System.Drawing.Size(162, 29);
            this.cb_auto.TabIndex = 4;
            this.cb_auto.Text = "autoconnect";
            this.cb_auto.UseVisualStyleBackColor = true;
            // 
            // btn_BridgeFormSync
            // 
            this.btn_BridgeFormSync.Location = new System.Drawing.Point(26, 219);
            this.btn_BridgeFormSync.Name = "btn_BridgeFormSync";
            this.btn_BridgeFormSync.Size = new System.Drawing.Size(191, 82);
            this.btn_BridgeFormSync.TabIndex = 5;
            this.btn_BridgeFormSync.Text = "BridgeFast";
            this.btn_BridgeFormSync.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 452);
            this.Controls.Add(this.btn_BridgeFormSync);
            this.Controls.Add(this.cb_auto);
            this.Controls.Add(this.btn_mybridgedisplay);
            this.Controls.Add(this.btn_SerialBridgeForm);
            this.Controls.Add(this.btn_FormSerialTester);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_FormSerialTester;
        private System.Windows.Forms.Button btn_SerialBridgeForm;
        private System.Windows.Forms.Button btn_mybridgedisplay;
        private System.Windows.Forms.CheckBox cb_auto;
        private System.Windows.Forms.Button btn_BridgeFormSync;
    }
}