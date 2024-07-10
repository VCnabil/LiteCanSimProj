namespace LiteCanSimProj._MainUIs._SizingUCs
{
    partial class UCSizing
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
            this.mlbl_B0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mlbl_B0
            // 
            this.mlbl_B0.AutoSize = true;
            this.mlbl_B0.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mlbl_B0.Font = new System.Drawing.Font("NSimSun", 6F);
            this.mlbl_B0.Location = new System.Drawing.Point(0, 0);
            this.mlbl_B0.Margin = new System.Windows.Forms.Padding(0);
            this.mlbl_B0.Name = "mlbl_B0";
            this.mlbl_B0.Size = new System.Drawing.Size(31, 16);
            this.mlbl_B0.TabIndex = 24;
            this.mlbl_B0.Text = "F_0";
            this.mlbl_B0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCSizing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mlbl_B0);
            this.Name = "UCSizing";
            this.Size = new System.Drawing.Size(86, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mlbl_B0;
    }
}
