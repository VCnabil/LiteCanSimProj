namespace LiteCanSimProj._MainUIs.debugUcs
{
    partial class UC_ByteOutputControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputLabel = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.checkBox_bit0 = new System.Windows.Forms.CheckBox();
            this.cb_allow = new System.Windows.Forms.CheckBox();
            this.cb_can = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.outputLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.Location = new System.Drawing.Point(0, 0);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(1);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(474, 41);
            this.outputLabel.TabIndex = 237;
            this.outputLabel.Text = "output byte";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(4, 58);
            this.trackBar.Maximum = 127;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(338, 90);
            this.trackBar.TabIndex = 238;
            // 
            // checkBox_bit0
            // 
            this.checkBox_bit0.AutoSize = true;
            this.checkBox_bit0.Location = new System.Drawing.Point(361, 118);
            this.checkBox_bit0.Name = "checkBox_bit0";
            this.checkBox_bit0.Size = new System.Drawing.Size(87, 29);
            this.checkBox_bit0.TabIndex = 239;
            this.checkBox_bit0.Text = "Bit 0";
            this.checkBox_bit0.UseVisualStyleBackColor = true;
            // 
            // cb_allow
            // 
            this.cb_allow.AutoSize = true;
            this.cb_allow.Location = new System.Drawing.Point(361, 83);
            this.cb_allow.Name = "cb_allow";
            this.cb_allow.Size = new System.Drawing.Size(91, 29);
            this.cb_allow.TabIndex = 240;
            this.cb_allow.Text = "send";
            this.cb_allow.UseVisualStyleBackColor = true;
            // 
            // cb_can
            // 
            this.cb_can.AutoSize = true;
            this.cb_can.Location = new System.Drawing.Point(361, 45);
            this.cb_can.Name = "cb_can";
            this.cb_can.Size = new System.Drawing.Size(79, 29);
            this.cb_can.TabIndex = 241;
            this.cb_can.Text = "can";
            this.cb_can.UseVisualStyleBackColor = true;
            // 
            // UC_ByteOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_can);
            this.Controls.Add(this.cb_allow);
            this.Controls.Add(this.checkBox_bit0);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.outputLabel);
            this.Name = "UC_ByteOutputControl";
            this.Size = new System.Drawing.Size(474, 186);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.CheckBox checkBox_bit0;
        private System.Windows.Forms.CheckBox cb_allow;
        private System.Windows.Forms.CheckBox cb_can;
    }
}
