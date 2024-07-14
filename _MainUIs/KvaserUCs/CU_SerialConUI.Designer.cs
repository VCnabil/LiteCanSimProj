namespace LiteCanSimProj._MainUIs.KvaserUCs
{
    partial class CU_SerialConUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_COMM = new System.Windows.Forms.GroupBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_YesAuto = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_NoManual = new System.Windows.Forms.Button();
            this.lstCOMPorts = new System.Windows.Forms.ListBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxHandshakes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_RTS = new System.Windows.Forms.CheckBox();
            this.comboBox_sendrate = new System.Windows.Forms.ComboBox();
            this.groupBox_COMM.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 663;
            this.label1.Text = "Baud Rate";
            // 
            // groupBox_COMM
            // 
            this.groupBox_COMM.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox_COMM.Controls.Add(this.comboBox_sendrate);
            this.groupBox_COMM.Controls.Add(this.checkBox_RTS);
            this.groupBox_COMM.Controls.Add(this.label2);
            this.groupBox_COMM.Controls.Add(this.comboBoxHandshakes);
            this.groupBox_COMM.Controls.Add(this.comboBoxBaudRate);
            this.groupBox_COMM.Controls.Add(this.label1);
            this.groupBox_COMM.Controls.Add(this.lstCOMPorts);
            this.groupBox_COMM.Controls.Add(this.btn_close);
            this.groupBox_COMM.Controls.Add(this.btn_YesAuto);
            this.groupBox_COMM.Controls.Add(this.lbl_status);
            this.groupBox_COMM.Controls.Add(this.btn_NoManual);
            this.groupBox_COMM.Location = new System.Drawing.Point(8, 10);
            this.groupBox_COMM.Name = "groupBox_COMM";
            this.groupBox_COMM.Size = new System.Drawing.Size(528, 167);
            this.groupBox_COMM.TabIndex = 667;
            this.groupBox_COMM.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(333, 85);
            this.btn_close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(177, 39);
            this.btn_close.TabIndex = 662;
            this.btn_close.Text = "close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_YesAuto
            // 
            this.btn_YesAuto.Location = new System.Drawing.Point(141, 116);
            this.btn_YesAuto.Margin = new System.Windows.Forms.Padding(0);
            this.btn_YesAuto.Name = "btn_YesAuto";
            this.btn_YesAuto.Size = new System.Drawing.Size(93, 39);
            this.btn_YesAuto.TabIndex = 658;
            this.btn_YesAuto.Text = "YES";
            this.btn_YesAuto.UseVisualStyleBackColor = true;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(0, 128);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(141, 27);
            this.lbl_status.TabIndex = 661;
            this.lbl_status.Text = "AutoConnect?";
            // 
            // btn_NoManual
            // 
            this.btn_NoManual.Location = new System.Drawing.Point(234, 116);
            this.btn_NoManual.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NoManual.Name = "btn_NoManual";
            this.btn_NoManual.Size = new System.Drawing.Size(93, 39);
            this.btn_NoManual.TabIndex = 659;
            this.btn_NoManual.Text = "NO";
            this.btn_NoManual.UseVisualStyleBackColor = true;
            // 
            // lstCOMPorts
            // 
            this.lstCOMPorts.FormattingEnabled = true;
            this.lstCOMPorts.ItemHeight = 25;
            this.lstCOMPorts.Location = new System.Drawing.Point(333, 3);
            this.lstCOMPorts.Name = "lstCOMPorts";
            this.lstCOMPorts.Size = new System.Drawing.Size(177, 79);
            this.lstCOMPorts.TabIndex = 660;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(143, 0);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(184, 33);
            this.comboBoxBaudRate.TabIndex = 664;
            // 
            // comboBoxHandshakes
            // 
            this.comboBoxHandshakes.FormattingEnabled = true;
            this.comboBoxHandshakes.Location = new System.Drawing.Point(143, 39);
            this.comboBoxHandshakes.Name = "comboBoxHandshakes";
            this.comboBoxHandshakes.Size = new System.Drawing.Size(184, 33);
            this.comboBoxHandshakes.TabIndex = 665;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 26);
            this.label2.TabIndex = 666;
            this.label2.Text = "Handshake";
            // 
            // checkBox_RTS
            // 
            this.checkBox_RTS.AutoSize = true;
            this.checkBox_RTS.Location = new System.Drawing.Point(11, 82);
            this.checkBox_RTS.Name = "checkBox_RTS";
            this.checkBox_RTS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_RTS.Size = new System.Drawing.Size(171, 29);
            this.checkBox_RTS.TabIndex = 667;
            this.checkBox_RTS.Text = "RTS Enabled";
            this.checkBox_RTS.UseVisualStyleBackColor = true;
            // 
            // comboBox_sendrate
            // 
            this.comboBox_sendrate.FormattingEnabled = true;
            this.comboBox_sendrate.Location = new System.Drawing.Point(205, 78);
            this.comboBox_sendrate.Name = "comboBox_sendrate";
            this.comboBox_sendrate.Size = new System.Drawing.Size(122, 33);
            this.comboBox_sendrate.TabIndex = 668;
            // 
            // CU_SerialConUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.groupBox_COMM);
            this.Name = "CU_SerialConUI";
            this.Size = new System.Drawing.Size(547, 180);
            this.groupBox_COMM.ResumeLayout(false);
            this.groupBox_COMM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_COMM;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_YesAuto;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_NoManual;
        private System.Windows.Forms.ListBox lstCOMPorts;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxHandshakes;
        private System.Windows.Forms.CheckBox checkBox_RTS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_sendrate;
    }
}
