namespace LiteCanSimProj._MainUIs.DynPosUCs
{
    partial class UC_PointDynData
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
            this.txb_lat_Deci = new System.Windows.Forms.TextBox();
            this.txb_lat_DMS = new System.Windows.Forms.TextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_lat_DDM_A = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_Input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txb_lat_Deci
            // 
            this.txb_lat_Deci.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_lat_Deci.Location = new System.Drawing.Point(0, 164);
            this.txb_lat_Deci.Name = "txb_lat_Deci";
            this.txb_lat_Deci.Size = new System.Drawing.Size(249, 38);
            this.txb_lat_Deci.TabIndex = 237;
            this.txb_lat_Deci.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_lat_DMS
            // 
            this.txb_lat_DMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_lat_DMS.Location = new System.Drawing.Point(0, 111);
            this.txb_lat_DMS.Name = "txb_lat_DMS";
            this.txb_lat_DMS.Size = new System.Drawing.Size(249, 38);
            this.txb_lat_DMS.TabIndex = 236;
            this.txb_lat_DMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(260, 25);
            this.lbl_title.TabIndex = 235;
            this.lbl_title.Text = "_lat or Lon_";
            // 
            // lbl_lat_DDM_A
            // 
            this.lbl_lat_DDM_A.AutoSize = true;
            this.lbl_lat_DDM_A.Font = new System.Drawing.Font("Bookshelf Symbol 7", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lat_DDM_A.Location = new System.Drawing.Point(13, 218);
            this.lbl_lat_DDM_A.Name = "lbl_lat_DDM_A";
            this.lbl_lat_DDM_A.Size = new System.Drawing.Size(166, 25);
            this.lbl_lat_DDM_A.TabIndex = 234;
            this.lbl_lat_DDM_A.Text = "DD MM.123456";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookshelf Symbol 7", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 233;
            this.label1.Text = "label1";
            // 
            // txb_Input
            // 
            this.txb_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Input.Location = new System.Drawing.Point(3, 41);
            this.txb_Input.Name = "txb_Input";
            this.txb_Input.Size = new System.Drawing.Size(249, 38);
            this.txb_Input.TabIndex = 232;
            this.txb_Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UC_PointDynData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txb_lat_Deci);
            this.Controls.Add(this.txb_lat_DMS);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_lat_DDM_A);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_Input);
            this.Name = "UC_PointDynData";
            this.Size = new System.Drawing.Size(260, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_lat_Deci;
        private System.Windows.Forms.TextBox txb_lat_DMS;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_lat_DDM_A;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_Input;
    }
}
