namespace LiteCanSimProj
{
    partial class SerialBridgeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialBridgeForm));
            this.btnBridge = new System.Windows.Forms.Button();
            this.comboSerial1 = new System.Windows.Forms.ComboBox();
            this.comboSerial2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBridge
            // 
            this.btnBridge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBridge.Location = new System.Drawing.Point(153, 131);
            this.btnBridge.Name = "btnBridge";
            this.btnBridge.Size = new System.Drawing.Size(264, 46);
            this.btnBridge.TabIndex = 6;
            this.btnBridge.Text = "Start Bridge";
            this.btnBridge.UseVisualStyleBackColor = true;
            // 
            // comboSerial1
            // 
            this.comboSerial1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboSerial1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboSerial1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.comboSerial1.FormattingEnabled = true;
            this.comboSerial1.Location = new System.Drawing.Point(20, 61);
            this.comboSerial1.Name = "comboSerial1";
            this.comboSerial1.Size = new System.Drawing.Size(242, 33);
            this.comboSerial1.TabIndex = 0;
            // 
            // comboSerial2
            // 
            this.comboSerial2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboSerial2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboSerial2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.comboSerial2.FormattingEnabled = true;
            this.comboSerial2.Location = new System.Drawing.Point(304, 61);
            this.comboSerial2.Name = "comboSerial2";
            this.comboSerial2.Size = new System.Drawing.Size(242, 33);
            this.comboSerial2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Port 1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serial Port 2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.comboSerial1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboSerial2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.16814F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.83186F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 113);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // SerialBridgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 195);
            this.Controls.Add(this.btnBridge);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerialBridgeForm";
            this.Text = "SerialBridgeForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBridge;
        private System.Windows.Forms.ComboBox comboSerial1;
        private System.Windows.Forms.ComboBox comboSerial2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}