namespace LiteCanSimProj._MainUIs.DynGPSUCs
{
    partial class uc_dpControl
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
            this.lbl_dist_f = new System.Windows.Forms.Label();
            this.lbl_dist_m = new System.Windows.Forms.Label();
            this.btn_arrive_equator = new System.Windows.Forms.Button();
            this.btn_arrive_newton = new System.Windows.Forms.Button();
            this.btn_arive_0_0 = new System.Windows.Forms.Button();
            this.lbl_dx_f = new System.Windows.Forms.Label();
            this.lbl_dy_f = new System.Windows.Forms.Label();
            this.lbl_dx_m = new System.Windows.Forms.Label();
            this.lbl_dy_m = new System.Windows.Forms.Label();
            this.lbl_distAB_feet = new System.Windows.Forms.Label();
            this.lbl_distAB_meters = new System.Windows.Forms.Label();
            this.cb_allow = new System.Windows.Forms.CheckBox();
            this.lblETA2 = new System.Windows.Forms.Label();
            this.lblXI2 = new System.Windows.Forms.Label();
            this.cb_can = new System.Windows.Forms.CheckBox();
            this.uC_360Heading = new LiteCanSimProj._MainUIs.DynPosUCs.UC_360Heading();
            this.uC_PLATPLOT1ACT = new LiteCanSimProj._MainUIs.DynGPSUCs.uc_1_GpsLocation();
            this.uC_PLATPLOT1CMD = new LiteCanSimProj._MainUIs.DynGPSUCs.uc_1_GpsLocation();
            this.btn_view_onMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_dist_f
            // 
            this.lbl_dist_f.AutoSize = true;
            this.lbl_dist_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dist_f.Location = new System.Drawing.Point(6, 191);
            this.lbl_dist_f.Name = "lbl_dist_f";
            this.lbl_dist_f.Size = new System.Drawing.Size(184, 26);
            this.lbl_dist_f.TabIndex = 296;
            this.lbl_dist_f.Text = "dist f 0123456789";
            // 
            // lbl_dist_m
            // 
            this.lbl_dist_m.AutoSize = true;
            this.lbl_dist_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dist_m.Location = new System.Drawing.Point(256, 192);
            this.lbl_dist_m.Name = "lbl_dist_m";
            this.lbl_dist_m.Size = new System.Drawing.Size(202, 26);
            this.lbl_dist_m.TabIndex = 295;
            this.lbl_dist_m.Text = "dist  M 0123456789";
            // 
            // btn_arrive_equator
            // 
            this.btn_arrive_equator.Location = new System.Drawing.Point(135, 3);
            this.btn_arrive_equator.Name = "btn_arrive_equator";
            this.btn_arrive_equator.Size = new System.Drawing.Size(183, 42);
            this.btn_arrive_equator.TabIndex = 292;
            this.btn_arrive_equator.Text = "arive at equator";
            this.btn_arrive_equator.UseVisualStyleBackColor = true;
            // 
            // btn_arrive_newton
            // 
            this.btn_arrive_newton.Location = new System.Drawing.Point(517, 3);
            this.btn_arrive_newton.Name = "btn_arrive_newton";
            this.btn_arrive_newton.Size = new System.Drawing.Size(183, 42);
            this.btn_arrive_newton.TabIndex = 291;
            this.btn_arrive_newton.Text = "arive at newton";
            this.btn_arrive_newton.UseVisualStyleBackColor = true;
            // 
            // btn_arive_0_0
            // 
            this.btn_arive_0_0.Location = new System.Drawing.Point(335, 3);
            this.btn_arive_0_0.Name = "btn_arive_0_0";
            this.btn_arive_0_0.Size = new System.Drawing.Size(176, 42);
            this.btn_arive_0_0.TabIndex = 290;
            this.btn_arive_0_0.Text = "arive at 0 0";
            this.btn_arive_0_0.UseVisualStyleBackColor = true;
            // 
            // lbl_dx_f
            // 
            this.lbl_dx_f.AutoSize = true;
            this.lbl_dx_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dx_f.Location = new System.Drawing.Point(6, 122);
            this.lbl_dx_f.Name = "lbl_dx_f";
            this.lbl_dx_f.Size = new System.Drawing.Size(232, 26);
            this.lbl_dx_f.TabIndex = 289;
            this.lbl_dx_f.Text = "delta_x  ft 0123456789";
            // 
            // lbl_dy_f
            // 
            this.lbl_dy_f.AutoSize = true;
            this.lbl_dy_f.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dy_f.Location = new System.Drawing.Point(6, 159);
            this.lbl_dy_f.Name = "lbl_dy_f";
            this.lbl_dy_f.Size = new System.Drawing.Size(232, 26);
            this.lbl_dy_f.TabIndex = 288;
            this.lbl_dy_f.Text = "delta_y  ft 0123456789";
            // 
            // lbl_dx_m
            // 
            this.lbl_dx_m.AutoSize = true;
            this.lbl_dx_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dx_m.Location = new System.Drawing.Point(256, 123);
            this.lbl_dx_m.Name = "lbl_dx_m";
            this.lbl_dx_m.Size = new System.Drawing.Size(238, 26);
            this.lbl_dx_m.TabIndex = 287;
            this.lbl_dx_m.Text = "delta_x  M 0123456789";
            // 
            // lbl_dy_m
            // 
            this.lbl_dy_m.AutoSize = true;
            this.lbl_dy_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dy_m.Location = new System.Drawing.Point(256, 160);
            this.lbl_dy_m.Name = "lbl_dy_m";
            this.lbl_dy_m.Size = new System.Drawing.Size(238, 26);
            this.lbl_dy_m.TabIndex = 286;
            this.lbl_dy_m.Text = "delta_y  M 0123456789";
            // 
            // lbl_distAB_feet
            // 
            this.lbl_distAB_feet.AutoSize = true;
            this.lbl_distAB_feet.Location = new System.Drawing.Point(6, 94);
            this.lbl_distAB_feet.Name = "lbl_distAB_feet";
            this.lbl_distAB_feet.Size = new System.Drawing.Size(66, 25);
            this.lbl_distAB_feet.TabIndex = 285;
            this.lbl_distAB_feet.Text = "feet : ";
            // 
            // lbl_distAB_meters
            // 
            this.lbl_distAB_meters.AutoSize = true;
            this.lbl_distAB_meters.Location = new System.Drawing.Point(256, 94);
            this.lbl_distAB_meters.Name = "lbl_distAB_meters";
            this.lbl_distAB_meters.Size = new System.Drawing.Size(89, 25);
            this.lbl_distAB_meters.TabIndex = 284;
            this.lbl_distAB_meters.Text = "meters: ";
            // 
            // cb_allow
            // 
            this.cb_allow.AutoSize = true;
            this.cb_allow.Location = new System.Drawing.Point(11, 3);
            this.cb_allow.Name = "cb_allow";
            this.cb_allow.Size = new System.Drawing.Size(91, 29);
            this.cb_allow.TabIndex = 282;
            this.cb_allow.Text = "send";
            this.cb_allow.UseVisualStyleBackColor = true;
            // 
            // lblETA2
            // 
            this.lblETA2.AutoSize = true;
            this.lblETA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblETA2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblETA2.Location = new System.Drawing.Point(742, 215);
            this.lblETA2.Name = "lblETA2";
            this.lblETA2.Size = new System.Drawing.Size(76, 26);
            this.lblETA2.TabIndex = 281;
            this.lblETA2.Text = "label1";
            // 
            // lblXI2
            // 
            this.lblXI2.AutoSize = true;
            this.lblXI2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXI2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblXI2.Location = new System.Drawing.Point(742, 253);
            this.lblXI2.Name = "lblXI2";
            this.lblXI2.Size = new System.Drawing.Size(76, 26);
            this.lblXI2.TabIndex = 280;
            this.lblXI2.Text = "label2";
            // 
            // cb_can
            // 
            this.cb_can.AutoSize = true;
            this.cb_can.Enabled = false;
            this.cb_can.Location = new System.Drawing.Point(11, 52);
            this.cb_can.Name = "cb_can";
            this.cb_can.Size = new System.Drawing.Size(79, 29);
            this.cb_can.TabIndex = 278;
            this.cb_can.Text = "can";
            this.cb_can.UseVisualStyleBackColor = true;
            // 
            // uC_360Heading
            // 
            this.uC_360Heading.Location = new System.Drawing.Point(480, 227);
            this.uC_360Heading.Name = "uC_360Heading";
            this.uC_360Heading.Size = new System.Drawing.Size(240, 240);
            this.uC_360Heading.TabIndex = 303;
            // 
            // uC_PLATPLOT1ACT
            // 
            this.uC_PLATPLOT1ACT.Location = new System.Drawing.Point(4, 279);
            this.uC_PLATPLOT1ACT.Margin = new System.Windows.Forms.Padding(2);
            this.uC_PLATPLOT1ACT.Name = "uC_PLATPLOT1ACT";
            this.uC_PLATPLOT1ACT.Size = new System.Drawing.Size(454, 200);
            this.uC_PLATPLOT1ACT.TabIndex = 302;
            this.uC_PLATPLOT1ACT.Z_PointName = "ACT";
            // 
            // uC_PLATPLOT1CMD
            // 
            this.uC_PLATPLOT1CMD.Location = new System.Drawing.Point(747, 281);
            this.uC_PLATPLOT1CMD.Margin = new System.Windows.Forms.Padding(2);
            this.uC_PLATPLOT1CMD.Name = "uC_PLATPLOT1CMD";
            this.uC_PLATPLOT1CMD.Size = new System.Drawing.Size(454, 200);
            this.uC_PLATPLOT1CMD.TabIndex = 301;
            this.uC_PLATPLOT1CMD.Z_PointName = "CMD";
            // 
            // btn_view_onMap
            // 
            this.btn_view_onMap.Location = new System.Drawing.Point(747, 3);
            this.btn_view_onMap.Name = "btn_view_onMap";
            this.btn_view_onMap.Size = new System.Drawing.Size(183, 42);
            this.btn_view_onMap.TabIndex = 304;
            this.btn_view_onMap.Text = "open google maps";
            this.btn_view_onMap.UseVisualStyleBackColor = true;
            // 
            // uc_dpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_view_onMap);
            this.Controls.Add(this.uC_360Heading);
            this.Controls.Add(this.uC_PLATPLOT1ACT);
            this.Controls.Add(this.uC_PLATPLOT1CMD);
            this.Controls.Add(this.lbl_dist_f);
            this.Controls.Add(this.lbl_dist_m);
            this.Controls.Add(this.btn_arrive_equator);
            this.Controls.Add(this.btn_arrive_newton);
            this.Controls.Add(this.btn_arive_0_0);
            this.Controls.Add(this.lbl_dx_f);
            this.Controls.Add(this.lbl_dy_f);
            this.Controls.Add(this.lbl_dx_m);
            this.Controls.Add(this.lbl_dy_m);
            this.Controls.Add(this.lbl_distAB_feet);
            this.Controls.Add(this.lbl_distAB_meters);
            this.Controls.Add(this.cb_allow);
            this.Controls.Add(this.lblETA2);
            this.Controls.Add(this.lblXI2);
            this.Controls.Add(this.cb_can);
            this.Name = "uc_dpControl";
            this.Size = new System.Drawing.Size(1212, 481);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_dist_f;
        private System.Windows.Forms.Label lbl_dist_m;
        private System.Windows.Forms.Button btn_arrive_equator;
        private System.Windows.Forms.Button btn_arrive_newton;
        private System.Windows.Forms.Button btn_arive_0_0;
        private System.Windows.Forms.Label lbl_dx_f;
        private System.Windows.Forms.Label lbl_dy_f;
        private System.Windows.Forms.Label lbl_dx_m;
        private System.Windows.Forms.Label lbl_dy_m;
        private System.Windows.Forms.Label lbl_distAB_feet;
        private System.Windows.Forms.Label lbl_distAB_meters;
        private System.Windows.Forms.CheckBox cb_allow;
        private System.Windows.Forms.Label lblETA2;
        private System.Windows.Forms.Label lblXI2;
        private System.Windows.Forms.CheckBox cb_can;
        private uc_1_GpsLocation uC_PLATPLOT1CMD;
        private uc_1_GpsLocation uC_PLATPLOT1ACT;
        private DynPosUCs.UC_360Heading uC_360Heading;
        private System.Windows.Forms.Button btn_view_onMap;
    }
}
