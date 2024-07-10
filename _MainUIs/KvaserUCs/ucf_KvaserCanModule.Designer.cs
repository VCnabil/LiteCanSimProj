namespace LiteCanSimProj._MainUIs.KvaserUCs
{
    partial class ucf_KvaserCanModule
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
            this.components = new System.ComponentModel.Container();
            this.label1_errors = new System.Windows.Forms.Label();
            this.button1_initcan = new System.Windows.Forms.Button();
            this.button1_KillCan = new System.Windows.Forms.Button();
            this.checkBox_LoopRunning = new System.Windows.Forms.CheckBox();
            this.lbl_bussStatus = new System.Windows.Forms.Label();
            this.timer0_TestForm = new System.Windows.Forms.Timer(this.components);
            this.cb_dualChan = new System.Windows.Forms.CheckBox();
            this.lbl_chinfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1_errors
            // 
            this.label1_errors.AutoSize = true;
            this.label1_errors.Location = new System.Drawing.Point(7, 12);
            this.label1_errors.Name = "label1_errors";
            this.label1_errors.Size = new System.Drawing.Size(80, 25);
            this.label1_errors.TabIndex = 107;
            this.label1_errors.Text = "errors :";
            // 
            // button1_initcan
            // 
            this.button1_initcan.Location = new System.Drawing.Point(266, 48);
            this.button1_initcan.Name = "button1_initcan";
            this.button1_initcan.Size = new System.Drawing.Size(105, 37);
            this.button1_initcan.TabIndex = 106;
            this.button1_initcan.Text = "initcan";
            this.button1_initcan.UseVisualStyleBackColor = true;
            // 
            // button1_KillCan
            // 
            this.button1_KillCan.Location = new System.Drawing.Point(398, 48);
            this.button1_KillCan.Name = "button1_KillCan";
            this.button1_KillCan.Size = new System.Drawing.Size(105, 37);
            this.button1_KillCan.TabIndex = 105;
            this.button1_KillCan.Text = "kill can";
            this.button1_KillCan.UseVisualStyleBackColor = true;
            // 
            // checkBox_LoopRunning
            // 
            this.checkBox_LoopRunning.AutoSize = true;
            this.checkBox_LoopRunning.Location = new System.Drawing.Point(144, 48);
            this.checkBox_LoopRunning.Name = "checkBox_LoopRunning";
            this.checkBox_LoopRunning.Size = new System.Drawing.Size(89, 29);
            this.checkBox_LoopRunning.TabIndex = 104;
            this.checkBox_LoopRunning.Text = "Run:";
            this.checkBox_LoopRunning.UseVisualStyleBackColor = true;
            // 
            // lbl_bussStatus
            // 
            this.lbl_bussStatus.AutoSize = true;
            this.lbl_bussStatus.BackColor = System.Drawing.Color.Red;
            this.lbl_bussStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bussStatus.Location = new System.Drawing.Point(7, 48);
            this.lbl_bussStatus.Name = "lbl_bussStatus";
            this.lbl_bussStatus.Size = new System.Drawing.Size(104, 29);
            this.lbl_bussStatus.TabIndex = 103;
            this.lbl_bussStatus.Text = "ONBUS";
            // 
            // timer0_TestForm
            // 
            this.timer0_TestForm.Interval = 400;
            // 
            // cb_dualChan
            // 
            this.cb_dualChan.AutoSize = true;
            this.cb_dualChan.Location = new System.Drawing.Point(398, 10);
            this.cb_dualChan.Name = "cb_dualChan";
            this.cb_dualChan.Size = new System.Drawing.Size(150, 29);
            this.cb_dualChan.TabIndex = 112;
            this.cb_dualChan.Text = "use 2 chan";
            this.cb_dualChan.UseVisualStyleBackColor = true;
            // 
            // lbl_chinfo
            // 
            this.lbl_chinfo.AutoSize = true;
            this.lbl_chinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_chinfo.Location = new System.Drawing.Point(291, 12);
            this.lbl_chinfo.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_chinfo.Name = "lbl_chinfo";
            this.lbl_chinfo.Size = new System.Drawing.Size(60, 24);
            this.lbl_chinfo.TabIndex = 111;
            this.lbl_chinfo.Text = "ch_av";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 110;
            this.label1.Text = "Rate ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 109;
            this.label4.Text = "cntframes";
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Rate.Location = new System.Drawing.Point(601, 57);
            this.textBox_Rate.MaxLength = 6;
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.Size = new System.Drawing.Size(86, 24);
            this.textBox_Rate.TabIndex = 108;
            this.textBox_Rate.Text = "400";
            // 
            // ucf_KvaserCanModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1_errors);
            this.Controls.Add(this.button1_initcan);
            this.Controls.Add(this.button1_KillCan);
            this.Controls.Add(this.checkBox_LoopRunning);
            this.Controls.Add(this.lbl_bussStatus);
            this.Controls.Add(this.cb_dualChan);
            this.Controls.Add(this.lbl_chinfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Rate);
            this.Name = "ucf_KvaserCanModule";
            this.Size = new System.Drawing.Size(700, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_errors;
        private System.Windows.Forms.Button button1_initcan;
        private System.Windows.Forms.Button button1_KillCan;
        private System.Windows.Forms.CheckBox checkBox_LoopRunning;
        private System.Windows.Forms.Label lbl_bussStatus;
        private System.Windows.Forms.Timer timer0_TestForm;
        private System.Windows.Forms.CheckBox cb_dualChan;
        private System.Windows.Forms.Label lbl_chinfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Rate;
    }
}
