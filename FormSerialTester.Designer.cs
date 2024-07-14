namespace LiteCanSimProj
{
    partial class FormSerialTester
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.trackBarSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(125, 288);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(188, 25);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Messagestype103";
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(223, 138);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(163, 33);
            this.comboBoxPorts.TabIndex = 45;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(416, 138);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(259, 79);
            this.btnStart.TabIndex = 46;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // trackBarSlider
            // 
            this.trackBarSlider.Location = new System.Drawing.Point(116, 12);
            this.trackBarSlider.Name = "trackBarSlider";
            this.trackBarSlider.Size = new System.Drawing.Size(104, 90);
            this.trackBarSlider.TabIndex = 48;
            // 
            // FormSerialTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBarSlider);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.btnStart);
            this.Name = "FormSerialTester";
            this.Text = "FormSerialTester";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TrackBar trackBarSlider;
    }
}