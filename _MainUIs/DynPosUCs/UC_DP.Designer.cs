namespace LiteCanSimProj._MainUIs.DynPosUCs
{
    partial class UC_DP
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
            this.lbl_ACT_lonUint = new System.Windows.Forms.Label();
            this.lbl_ACT_latUint = new System.Windows.Forms.Label();
            this.lbl_CMD_lonUint = new System.Windows.Forms.Label();
            this.lbl_CMD_latUint = new System.Windows.Forms.Label();
            this.lbl_dist_f = new System.Windows.Forms.Label();
            this.lbl_dist_m = new System.Windows.Forms.Label();
            this.lbl_dx = new System.Windows.Forms.Label();
            this.lbl_dy = new System.Windows.Forms.Label();
            this.btn_arrive_equator = new System.Windows.Forms.Button();
            this.btn_arrive_newton = new System.Windows.Forms.Button();
            this.btn_arive_0_0 = new System.Windows.Forms.Button();
            this.lbl_dx_f = new System.Windows.Forms.Label();
            this.lbl_dy_f = new System.Windows.Forms.Label();
            this.lbl_dx_m = new System.Windows.Forms.Label();
            this.lbl_dy_m = new System.Windows.Forms.Label();
            this.lbl_distAB_feet = new System.Windows.Forms.Label();
            this.lbl_distAB_meters = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_allow = new System.Windows.Forms.CheckBox();
            this.lblETA2 = new System.Windows.Forms.Label();
            this.lblXI2 = new System.Windows.Forms.Label();
            this.lbl_HeadingPolar = new System.Windows.Forms.Label();
            this.cb_can = new System.Windows.Forms.CheckBox();
            this.lblETA = new System.Windows.Forms.Label();
            this.lblXI = new System.Windows.Forms.Label();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.uC_PLATPLOT1CMD = new LiteCanSimProj._MainUIs.UC_PLATPLOT();
            this.uC_PLATPLOT1ACT = new LiteCanSimProj._MainUIs.UC_PLATPLOT();
            this.uC_360Heading = new LiteCanSimProj._MainUIs.DynPosUCs.UC_360Heading();
            this.SuspendLayout();
            // 
            // lbl_ACT_lonUint
            // 
            this.lbl_ACT_lonUint.AutoSize = true;
            this.lbl_ACT_lonUint.Location = new System.Drawing.Point(949, 531);
            this.lbl_ACT_lonUint.Name = "lbl_ACT_lonUint";
            this.lbl_ACT_lonUint.Size = new System.Drawing.Size(70, 25);
            this.lbl_ACT_lonUint.TabIndex = 275;
            this.lbl_ACT_lonUint.Text = "label3";
            // 
            // lbl_ACT_latUint
            // 
            this.lbl_ACT_latUint.AutoSize = true;
            this.lbl_ACT_latUint.Location = new System.Drawing.Point(615, 531);
            this.lbl_ACT_latUint.Name = "lbl_ACT_latUint";
            this.lbl_ACT_latUint.Size = new System.Drawing.Size(70, 25);
            this.lbl_ACT_latUint.TabIndex = 274;
            this.lbl_ACT_latUint.Text = "label4";
            // 
            // lbl_CMD_lonUint
            // 
            this.lbl_CMD_lonUint.AutoSize = true;
            this.lbl_CMD_lonUint.Location = new System.Drawing.Point(173, 531);
            this.lbl_CMD_lonUint.Name = "lbl_CMD_lonUint";
            this.lbl_CMD_lonUint.Size = new System.Drawing.Size(70, 25);
            this.lbl_CMD_lonUint.TabIndex = 273;
            this.lbl_CMD_lonUint.Text = "label2";
            // 
            // lbl_CMD_latUint
            // 
            this.lbl_CMD_latUint.AutoSize = true;
            this.lbl_CMD_latUint.Location = new System.Drawing.Point(14, 531);
            this.lbl_CMD_latUint.Name = "lbl_CMD_latUint";
            this.lbl_CMD_latUint.Size = new System.Drawing.Size(70, 25);
            this.lbl_CMD_latUint.TabIndex = 272;
            this.lbl_CMD_latUint.Text = "label1";
            // 
            // lbl_dist_f
            // 
            this.lbl_dist_f.AutoSize = true;
            this.lbl_dist_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dist_f.Location = new System.Drawing.Point(18, 464);
            this.lbl_dist_f.Name = "lbl_dist_f";
            this.lbl_dist_f.Size = new System.Drawing.Size(184, 26);
            this.lbl_dist_f.TabIndex = 271;
            this.lbl_dist_f.Text = "dist f 0123456789";
            // 
            // lbl_dist_m
            // 
            this.lbl_dist_m.AutoSize = true;
            this.lbl_dist_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dist_m.Location = new System.Drawing.Point(325, 464);
            this.lbl_dist_m.Name = "lbl_dist_m";
            this.lbl_dist_m.Size = new System.Drawing.Size(202, 26);
            this.lbl_dist_m.TabIndex = 270;
            this.lbl_dist_m.Text = "dist  M 0123456789";
            // 
            // lbl_dx
            // 
            this.lbl_dx.AutoSize = true;
            this.lbl_dx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dx.Location = new System.Drawing.Point(273, 286);
            this.lbl_dx.Name = "lbl_dx";
            this.lbl_dx.Size = new System.Drawing.Size(82, 26);
            this.lbl_dx.TabIndex = 269;
            this.lbl_dx.Text = "delta_x";
            // 
            // lbl_dy
            // 
            this.lbl_dy.AutoSize = true;
            this.lbl_dy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dy.Location = new System.Drawing.Point(310, 318);
            this.lbl_dy.Name = "lbl_dy";
            this.lbl_dy.Size = new System.Drawing.Size(82, 26);
            this.lbl_dy.TabIndex = 268;
            this.lbl_dy.Text = "delta_y";
            // 
            // btn_arrive_equator
            // 
            this.btn_arrive_equator.Location = new System.Drawing.Point(1215, 414);
            this.btn_arrive_equator.Name = "btn_arrive_equator";
            this.btn_arrive_equator.Size = new System.Drawing.Size(183, 42);
            this.btn_arrive_equator.TabIndex = 267;
            this.btn_arrive_equator.Text = "arive at equator";
            this.btn_arrive_equator.UseVisualStyleBackColor = true;
            // 
            // btn_arrive_newton
            // 
            this.btn_arrive_newton.Location = new System.Drawing.Point(1208, 366);
            this.btn_arrive_newton.Name = "btn_arrive_newton";
            this.btn_arrive_newton.Size = new System.Drawing.Size(183, 42);
            this.btn_arrive_newton.TabIndex = 266;
            this.btn_arrive_newton.Text = "arive at newton";
            this.btn_arrive_newton.UseVisualStyleBackColor = true;
            // 
            // btn_arive_0_0
            // 
            this.btn_arive_0_0.Location = new System.Drawing.Point(1215, 318);
            this.btn_arive_0_0.Name = "btn_arive_0_0";
            this.btn_arive_0_0.Size = new System.Drawing.Size(176, 42);
            this.btn_arive_0_0.TabIndex = 265;
            this.btn_arive_0_0.Text = "arive at 0 0";
            this.btn_arive_0_0.UseVisualStyleBackColor = true;
            // 
            // lbl_dx_f
            // 
            this.lbl_dx_f.AutoSize = true;
            this.lbl_dx_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dx_f.Location = new System.Drawing.Point(18, 395);
            this.lbl_dx_f.Name = "lbl_dx_f";
            this.lbl_dx_f.Size = new System.Drawing.Size(232, 26);
            this.lbl_dx_f.TabIndex = 264;
            this.lbl_dx_f.Text = "delta_x  ft 0123456789";
            // 
            // lbl_dy_f
            // 
            this.lbl_dy_f.AutoSize = true;
            this.lbl_dy_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dy_f.Location = new System.Drawing.Point(18, 432);
            this.lbl_dy_f.Name = "lbl_dy_f";
            this.lbl_dy_f.Size = new System.Drawing.Size(232, 26);
            this.lbl_dy_f.TabIndex = 263;
            this.lbl_dy_f.Text = "delta_y  ft 0123456789";
            // 
            // lbl_dx_m
            // 
            this.lbl_dx_m.AutoSize = true;
            this.lbl_dx_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dx_m.Location = new System.Drawing.Point(325, 395);
            this.lbl_dx_m.Name = "lbl_dx_m";
            this.lbl_dx_m.Size = new System.Drawing.Size(238, 26);
            this.lbl_dx_m.TabIndex = 262;
            this.lbl_dx_m.Text = "delta_x  M 0123456789";
            // 
            // lbl_dy_m
            // 
            this.lbl_dy_m.AutoSize = true;
            this.lbl_dy_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dy_m.Location = new System.Drawing.Point(325, 432);
            this.lbl_dy_m.Name = "lbl_dy_m";
            this.lbl_dy_m.Size = new System.Drawing.Size(238, 26);
            this.lbl_dy_m.TabIndex = 261;
            this.lbl_dy_m.Text = "delta_y  M 0123456789";
            // 
            // lbl_distAB_feet
            // 
            this.lbl_distAB_feet.AutoSize = true;
            this.lbl_distAB_feet.Location = new System.Drawing.Point(18, 367);
            this.lbl_distAB_feet.Name = "lbl_distAB_feet";
            this.lbl_distAB_feet.Size = new System.Drawing.Size(66, 25);
            this.lbl_distAB_feet.TabIndex = 260;
            this.lbl_distAB_feet.Text = "feet : ";
            // 
            // lbl_distAB_meters
            // 
            this.lbl_distAB_meters.AutoSize = true;
            this.lbl_distAB_meters.Location = new System.Drawing.Point(325, 366);
            this.lbl_distAB_meters.Name = "lbl_distAB_meters";
            this.lbl_distAB_meters.Size = new System.Drawing.Size(89, 25);
            this.lbl_distAB_meters.TabIndex = 259;
            this.lbl_distAB_meters.Text = "meters: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1223, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 258;
            this.label5.Text = "Distance a nd b ";
            // 
            // cb_allow
            // 
            this.cb_allow.AutoSize = true;
            this.cb_allow.Location = new System.Drawing.Point(1106, 461);
            this.cb_allow.Name = "cb_allow";
            this.cb_allow.Size = new System.Drawing.Size(91, 29);
            this.cb_allow.TabIndex = 257;
            this.cb_allow.Text = "send";
            this.cb_allow.UseVisualStyleBackColor = true;
            // 
            // lblETA2
            // 
            this.lblETA2.AutoSize = true;
            this.lblETA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblETA2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblETA2.Location = new System.Drawing.Point(609, 318);
            this.lblETA2.Name = "lblETA2";
            this.lblETA2.Size = new System.Drawing.Size(76, 26);
            this.lblETA2.TabIndex = 256;
            this.lblETA2.Text = "label1";
            // 
            // lblXI2
            // 
            this.lblXI2.AutoSize = true;
            this.lblXI2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXI2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblXI2.Location = new System.Drawing.Point(569, 285);
            this.lblXI2.Name = "lblXI2";
            this.lblXI2.Size = new System.Drawing.Size(76, 26);
            this.lblXI2.TabIndex = 255;
            this.lblXI2.Text = "label2";
            // 
            // lbl_HeadingPolar
            // 
            this.lbl_HeadingPolar.AutoSize = true;
            this.lbl_HeadingPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HeadingPolar.Location = new System.Drawing.Point(1145, 274);
            this.lbl_HeadingPolar.Name = "lbl_HeadingPolar";
            this.lbl_HeadingPolar.Size = new System.Drawing.Size(77, 31);
            this.lbl_HeadingPolar.TabIndex = 254;
            this.lbl_HeadingPolar.Text = "Polar";
            // 
            // cb_can
            // 
            this.cb_can.AutoSize = true;
            this.cb_can.Enabled = false;
            this.cb_can.Location = new System.Drawing.Point(1106, 488);
            this.cb_can.Name = "cb_can";
            this.cb_can.Size = new System.Drawing.Size(79, 29);
            this.cb_can.TabIndex = 253;
            this.cb_can.Text = "can";
            this.cb_can.UseVisualStyleBackColor = true;
            // 
            // lblETA
            // 
            this.lblETA.AutoSize = true;
            this.lblETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblETA.Location = new System.Drawing.Point(33, 320);
            this.lblETA.Name = "lblETA";
            this.lblETA.Size = new System.Drawing.Size(67, 24);
            this.lblETA.TabIndex = 252;
            this.lblETA.Text = "lblETA";
            // 
            // lblXI
            // 
            this.lblXI.AutoSize = true;
            this.lblXI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXI.Location = new System.Drawing.Point(15, 286);
            this.lblXI.Name = "lblXI";
            this.lblXI.Size = new System.Drawing.Size(47, 24);
            this.lblXI.TabIndex = 251;
            this.lblXI.Text = "lblXI";
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.Location = new System.Drawing.Point(0, 0);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(100, 23);
            this.lbl_Heading.TabIndex = 0;
            // 
            // uC_PLATPLOT1CMD
            // 
            this.uC_PLATPLOT1CMD.Location = new System.Drawing.Point(5, 3);
            this.uC_PLATPLOT1CMD.Name = "uC_PLATPLOT1CMD";
            this.uC_PLATPLOT1CMD.Size = new System.Drawing.Size(540, 280);
            this.uC_PLATPLOT1CMD.TabIndex = 276;
            this.uC_PLATPLOT1CMD.Z_PointName = "the CMD";
            // 
            // uC_PLATPLOT1ACT
            // 
            this.uC_PLATPLOT1ACT.Location = new System.Drawing.Point(564, 3);
            this.uC_PLATPLOT1ACT.Name = "uC_PLATPLOT1ACT";
            this.uC_PLATPLOT1ACT.Size = new System.Drawing.Size(540, 280);
            this.uC_PLATPLOT1ACT.TabIndex = 277;
            this.uC_PLATPLOT1ACT.Z_PointName = "the ACT";
            // 
            // uC_360Heading
            // 
            this.uC_360Heading.Location = new System.Drawing.Point(1151, 16);
            this.uC_360Heading.Name = "uC_360Heading";
            this.uC_360Heading.Size = new System.Drawing.Size(240, 240);
            this.uC_360Heading.TabIndex = 278;
            // 
            // UC_DP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.uC_360Heading);
            this.Controls.Add(this.uC_PLATPLOT1ACT);
            this.Controls.Add(this.uC_PLATPLOT1CMD);
            this.Controls.Add(this.lbl_Heading);
            this.Controls.Add(this.lbl_ACT_lonUint);
            this.Controls.Add(this.lbl_ACT_latUint);
            this.Controls.Add(this.lbl_CMD_lonUint);
            this.Controls.Add(this.lbl_CMD_latUint);
            this.Controls.Add(this.lbl_dist_f);
            this.Controls.Add(this.lbl_dist_m);
            this.Controls.Add(this.lbl_dx);
            this.Controls.Add(this.lbl_dy);
            this.Controls.Add(this.btn_arrive_equator);
            this.Controls.Add(this.btn_arrive_newton);
            this.Controls.Add(this.btn_arive_0_0);
            this.Controls.Add(this.lbl_dx_f);
            this.Controls.Add(this.lbl_dy_f);
            this.Controls.Add(this.lbl_dx_m);
            this.Controls.Add(this.lbl_dy_m);
            this.Controls.Add(this.lbl_distAB_feet);
            this.Controls.Add(this.lbl_distAB_meters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_allow);
            this.Controls.Add(this.lblETA2);
            this.Controls.Add(this.lblXI2);
            this.Controls.Add(this.lbl_HeadingPolar);
            this.Controls.Add(this.cb_can);
            this.Controls.Add(this.lblETA);
            this.Controls.Add(this.lblXI);
            this.Name = "UC_DP";
            this.Size = new System.Drawing.Size(1421, 560);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ACT_lonUint;
        private System.Windows.Forms.Label lbl_ACT_latUint;
        private System.Windows.Forms.Label lbl_CMD_lonUint;
        private System.Windows.Forms.Label lbl_CMD_latUint;
        private System.Windows.Forms.Label lbl_dist_f;
        private System.Windows.Forms.Label lbl_dist_m;
        private System.Windows.Forms.Label lbl_dx;
        private System.Windows.Forms.Label lbl_dy;
        private System.Windows.Forms.Button btn_arrive_equator;
        private System.Windows.Forms.Button btn_arrive_newton;
        private System.Windows.Forms.Button btn_arive_0_0;
        private System.Windows.Forms.Label lbl_dx_f;
        private System.Windows.Forms.Label lbl_dy_f;
        private System.Windows.Forms.Label lbl_dx_m;
        private System.Windows.Forms.Label lbl_dy_m;
        private System.Windows.Forms.Label lbl_distAB_feet;
        private System.Windows.Forms.Label lbl_distAB_meters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_allow;
        private System.Windows.Forms.Label lblETA2;
        private System.Windows.Forms.Label lblXI2;
        private System.Windows.Forms.Label lbl_HeadingPolar;
        private System.Windows.Forms.CheckBox cb_can;
        private System.Windows.Forms.Label lblETA;
        private System.Windows.Forms.Label lblXI;
        private System.Windows.Forms.Label lbl_Heading;
        private UC_PLATPLOT uC_PLATPLOT1CMD;
        private UC_PLATPLOT uC_PLATPLOT1ACT;
        private UC_360Heading uC_360Heading;
    }
}
