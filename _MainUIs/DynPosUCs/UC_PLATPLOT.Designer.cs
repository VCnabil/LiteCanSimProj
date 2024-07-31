namespace LiteCanSimProj._MainUIs
{
    partial class UC_PLATPLOT
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
            this.uC_PmyLON = new LiteCanSimProj._MainUIs.DynPosUCs.UC_PointDynData();
            this.uC_PmyLAT = new LiteCanSimProj._MainUIs.DynPosUCs.UC_PointDynData();
            this.SuspendLayout();
            // 
            // lbl_pointName
            // 
            this.lbl_pointName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_pointName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_pointName.Location = new System.Drawing.Point(0, 0);
            this.lbl_pointName.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_pointName.Name = "lbl_pointName";
            this.lbl_pointName.Size = new System.Drawing.Size(540, 25);
            this.lbl_pointName.TabIndex = 221;
            this.lbl_pointName.Text = "Point name";
            // 
            // uC_PmyLON
            // 
            this.uC_PmyLON.BackColor = System.Drawing.Color.LightGreen;
            this.uC_PmyLON.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_PmyLON.Location = new System.Drawing.Point(269, 29);
            this.uC_PmyLON.Name = "uC_PmyLON";
            this.uC_PmyLON.Size = new System.Drawing.Size(259, 246);
            this.uC_PmyLON.TabIndex = 1;
            this.uC_PmyLON.Z_IsLat = false;
            this.uC_PmyLON.Z_Title = "my lon";
            // 
            // uC_PmyLAT
            // 
            this.uC_PmyLAT.BackColor = System.Drawing.Color.LightSalmon;
            this.uC_PmyLAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_PmyLAT.Location = new System.Drawing.Point(3, 29);
            this.uC_PmyLAT.Name = "uC_PmyLAT";
            this.uC_PmyLAT.Size = new System.Drawing.Size(260, 246);
            this.uC_PmyLAT.TabIndex = 0;
            this.uC_PmyLAT.Z_IsLat = true;
            this.uC_PmyLAT.Z_Title = "mylat";
            // 
            // UC_PLATPLOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_pointName);
            this.Controls.Add(this.uC_PmyLON);
            this.Controls.Add(this.uC_PmyLAT);
            this.Name = "UC_PLATPLOT";
            this.Size = new System.Drawing.Size(540, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private DynPosUCs.UC_PointDynData uC_PmyLAT;
        private DynPosUCs.UC_PointDynData uC_PmyLON;
        private System.Windows.Forms.Label lbl_pointName;
    }
}
