namespace LiteCanSimProj._MainUIs.DynGPSUCs
{
    partial class uc_1_GpsLocation
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
            this.lbl_pointName = new System.Windows.Forms.Label();
            this.uc_0_Plat = new LiteCanSimProj._MainUIs.DynGPSUCs.uc_0_Point();
            this.uc_0_Plon = new LiteCanSimProj._MainUIs.DynGPSUCs.uc_0_Point();
            this.SuspendLayout();
            // 
            // lbl_pointName
            // 
            this.lbl_pointName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_pointName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_pointName.Location = new System.Drawing.Point(0, 0);
            this.lbl_pointName.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_pointName.Name = "lbl_pointName";
            this.lbl_pointName.Size = new System.Drawing.Size(454, 25);
            this.lbl_pointName.TabIndex = 222;
            this.lbl_pointName.Text = "Location name";
            // 
            // uc_0_Plat
            // 
            this.uc_0_Plat.BackColor = System.Drawing.Color.LightSalmon;
            this.uc_0_Plat.Location = new System.Drawing.Point(6, 35);
            this.uc_0_Plat.Margin = new System.Windows.Forms.Padding(0);
            this.uc_0_Plat.Name = "uc_0_Plat";
            this.uc_0_Plat.Size = new System.Drawing.Size(220, 160);
            this.uc_0_Plat.TabIndex = 223;
            this.uc_0_Plat.Z_IsLat = true;
            this.uc_0_Plat.Z_Title = "P1Lat";
            // 
            // uc_0_Plon
            // 
            this.uc_0_Plon.BackColor = System.Drawing.Color.LightGreen;
            this.uc_0_Plon.Location = new System.Drawing.Point(230, 35);
            this.uc_0_Plon.Margin = new System.Windows.Forms.Padding(0);
            this.uc_0_Plon.Name = "uc_0_Plon";
            this.uc_0_Plon.Size = new System.Drawing.Size(220, 160);
            this.uc_0_Plon.TabIndex = 224;
            this.uc_0_Plon.Z_IsLat = false;
            this.uc_0_Plon.Z_Title = "P1Lon";
            // 
            // uc_1_GpsLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_0_Plon);
            this.Controls.Add(this.uc_0_Plat);
            this.Controls.Add(this.lbl_pointName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_1_GpsLocation";
            this.Size = new System.Drawing.Size(454, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_pointName;
        private uc_0_Point uc_0_Plat;
        private uc_0_Point uc_0_Plon;
    }
}
