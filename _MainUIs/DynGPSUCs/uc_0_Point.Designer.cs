namespace LiteCanSimProj._MainUIs.DynGPSUCs
{
    partial class uc_0_Point
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.txb_Input = new System.Windows.Forms.TextBox();
            this.txb_lat_DMS = new System.Windows.Forms.TextBox();
            this.txb_lat_Deci = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(220, 25);
            this.lbl_title.TabIndex = 236;
            this.lbl_title.Text = "_lat or Lon_";
            // 
            // txb_Input
            // 
            this.txb_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Input.Location = new System.Drawing.Point(0, 32);
            this.txb_Input.Margin = new System.Windows.Forms.Padding(2);
            this.txb_Input.Name = "txb_Input";
            this.txb_Input.Size = new System.Drawing.Size(220, 32);
            this.txb_Input.TabIndex = 237;
            this.txb_Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_lat_DMS
            // 
            this.txb_lat_DMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_lat_DMS.BackColor = System.Drawing.SystemColors.Menu;
            this.txb_lat_DMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_lat_DMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_lat_DMS.Location = new System.Drawing.Point(-2, 83);
            this.txb_lat_DMS.Margin = new System.Windows.Forms.Padding(2);
            this.txb_lat_DMS.Name = "txb_lat_DMS";
            this.txb_lat_DMS.Size = new System.Drawing.Size(220, 25);
            this.txb_lat_DMS.TabIndex = 238;
            this.txb_lat_DMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_lat_Deci
            // 
            this.txb_lat_Deci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_lat_Deci.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txb_lat_Deci.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_lat_Deci.Location = new System.Drawing.Point(0, 126);
            this.txb_lat_Deci.Margin = new System.Windows.Forms.Padding(2);
            this.txb_lat_Deci.Name = "txb_lat_Deci";
            this.txb_lat_Deci.Size = new System.Drawing.Size(220, 32);
            this.txb_lat_Deci.TabIndex = 239;
            this.txb_lat_Deci.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uc_0_Point
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txb_lat_Deci);
            this.Controls.Add(this.txb_lat_DMS);
            this.Controls.Add(this.txb_Input);
            this.Controls.Add(this.lbl_title);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_0_Point";
            this.Size = new System.Drawing.Size(220, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TextBox txb_Input;
        private System.Windows.Forms.TextBox txb_lat_DMS;
        private System.Windows.Forms.TextBox txb_lat_Deci;
    }
}
