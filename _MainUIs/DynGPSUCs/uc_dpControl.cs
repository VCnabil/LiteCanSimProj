using LiteCanSimProj._Globalz;
using LiteCanSimProj._MainUIs.DynPosUCs;
using LiteCanSimProj.OBJs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj._MainUIs.DynGPSUCs
{
    public partial class uc_dpControl : UserControl
    {
        Timer timerLoop = new Timer();
        char _degreeSymbol = (char)176;
        double headingDoubleForXIEtha;
        double headingPolar = 0;

        double deltaxValue;
        double deltayValue;
        int xiValue;
        int etaValue;
        double[] offsets;

        int temxiValue = 0;
        int temetaValue = 0;
        double[] tempoffset;





        private double _ab_dist_feet;
        private double _ab_dist_m;

        private const double EarthRadiusMeters = 6371000.0;
        private const double EarthRadiusFeet = 20925646.325;

        private double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2, double radius)
        {
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return radius * c;
        }
        private double CalculateDistanceInMeters(double lat1, double lon1, double lat2, double lon2)
        {
            return CalculateDistance(lat1, lon1, lat2, lon2, EarthRadiusMeters);
        }

        private double CalculateDistanceInFeet(double lat1, double lon1, double lat2, double lon2)
        {
            return CalculateDistance(lat1, lon1, lat2, lon2, EarthRadiusFeet);
        }

        private double CalculateHorizontalOffset(double lat, double lon1, double lon2, double radius)
        {
            double latRadians = ToRadians(lat);
            double dLon = ToRadians(lon2 - lon1);
            double offset = radius * dLon * Math.Cos(latRadians);
            return Math.Abs(offset);
        }

        private double CalculateVerticalOffset(double lat1, double lat2, double radius)
        {
            double dLat = ToRadians(lat2 - lat1);
            double offset = radius * dLat;
            return Math.Abs(offset);
        }

        public uc_dpControl()
        {

            InitializeComponent();
            btn_arive_0_0.Click += Btn_resetAll_Click;
            uC_PLATPLOT1ACT.Click += Uc_PointLatLonACT_Clicked;
            uC_PLATPLOT1CMD.Click += Uc_PointLatLon_CMD_Clicked;
            btn_arrive_newton.Click += Btn_arrive_newton_Click;
            btn_arrive_equator.Click += Btn_arrive_equator_Click;
            btn_view_onMap.Click += Btn_view_onMap_Click;

            offsets = new double[2];
            tempoffset = new double[2];
            cb_can.Enabled = false;
            cb_can.Checked = false;
            timerLoop.Interval = 250;
            timerLoop.Tick += TimerLoop_Tick;
            timerLoop.Start();
        }

        private void Btn_view_onMap_Click(object sender, EventArgs e)
        {
            // Get coordinates for the two points
            double cmdLat = uC_PLATPLOT1CMD.Get_POINT_LAT().Get_me_COORDINATE_DOUBLE();
            double cmdLon = uC_PLATPLOT1CMD.Get_POINT_LON().Get_me_COORDINATE_DOUBLE();
            double actLat = uC_PLATPLOT1ACT.Get_POINT_LAT().Get_me_COORDINATE_DOUBLE();  
            double actLon = uC_PLATPLOT1ACT.Get_POINT_LON().Get_me_COORDINATE_DOUBLE();

            // Construct the URL with both points uses maps and directions
            //string url = "https://www.google.com/maps/dir/?api=1&origin=" +
            //             cmdLat.ToString() + "," + cmdLon.ToString() +
            //             "&destination=" + actLat.ToString() + "," + actLon.ToString();

            // Construct the URL with both points and a path between them
            //string url = "https://www.google.com/maps/dir/?api=1" +
            //             "&markers=" + cmdLat.ToString() + "," + cmdLon.ToString() +
            //             "&markers=" + actLat.ToString() + "," + actLon.ToString() +
            //             "&path=" + cmdLat.ToString() + "," + cmdLon.ToString() + "|" + actLat.ToString() + "," + actLon.ToString();

            string url = "https://www.google.com/maps/@" +
                   ((cmdLat + actLat) / 2).ToString() + "," + ((cmdLon + actLon) / 2).ToString() + ",10z" +
                   "/data=!3m1!4b1!4m2!11m1!2e?markers=" +
                   cmdLat.ToString() + "," + cmdLon.ToString() +
                   "&markers=" + actLat.ToString() + "," + actLon.ToString();
            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(url);

        }

        private void UpdateOffsets(double latA, double lonA, double latB, double lonB)
        {
            double dist_f = CalculateDistanceInFeet(latA, lonA, latB, lonB);
            double dist_m = CalculateDistanceInMeters(latA, lonA, latB, lonB);
            double dx_m = CalculateHorizontalOffset(latA, lonA, lonB, EarthRadiusMeters);
            double dy_m = CalculateVerticalOffset(latA, latB, EarthRadiusMeters);
            double dx_f = CalculateHorizontalOffset(latA, lonA, lonB, EarthRadiusFeet);
            double dy_f = CalculateVerticalOffset(latA, latB, EarthRadiusFeet);
            lbl_dist_m.Text = $"Dist: {dist_m:F6} m";
            lbl_dist_f.Text = $"Dist: {dist_f:F6} ft";
            lbl_dx_m.Text = $"dx: {dx_m:F6} m";
            lbl_dy_m.Text = $"dy: {dy_m:F6} m";
            lbl_dx_f.Text = $"dx: {dx_f:F6} ft";
            lbl_dy_f.Text = $"dy: {dy_f:F6} ft";
        }
        private void update_originalXiEtaOffset(double latA, double lonA, double latB, double lonB)
        {
            deltaxValue = ClacXiEtha.Calc_OG_DeltaX(latA, lonA, latB, lonB);    
            deltayValue = ClacXiEtha.Calc_OG_DeltaY(latA, lonA, latB, lonB);  
           // lbl_dx.Text = "OGdx: " + deltaxValue.ToString();
           // lbl_dy.Text = "OGdy: " + deltayValue.ToString();

            headingDoubleForXIEtha = uC_360Heading.AngleValue; 


            headingPolar = headingDoubleForXIEtha * Math.PI / 180;
            //lbl_HeadingPolar.Text = headingPolar.ToString("0.00") + _degreeSymbol;

            offsets = ClacXiEtha.ComputeOffsetsXiEta(deltaxValue, deltayValue, headingDoubleForXIEtha);
            xiValue = (int)offsets[0];
            etaValue = (int)offsets[1];
           // lblXI.Text = "Xi: " + xiValue.ToString();
           // lblETA.Text = "eTa: " + etaValue.ToString();

           
            tempoffset = ClacXiEtha.ComputeOffsetsXiEta_usingMatrix(deltaxValue, deltayValue, headingDoubleForXIEtha);
            temxiValue = (int)tempoffset[0];
            temetaValue = (int)tempoffset[1];
            //lblXI2.Text = "xi: " + temxiValue.ToString();
            //lblETA2.Text = "eTa: " + temetaValue.ToString();


        }
        void Update_og_and_new(bool _isA_toB)
        {

            UpdateOffsets(uC_PLATPLOT1CMD.Get_POINT_LAT().Get_me_COORDINATE_DOUBLE(),
                uC_PLATPLOT1CMD.Get_POINT_LON().Get_me_COORDINATE_DOUBLE(),
                uC_PLATPLOT1ACT.Get_POINT_LAT().Get_me_COORDINATE_DOUBLE(),
                uC_PLATPLOT1ACT.Get_POINT_LON().Get_me_COORDINATE_DOUBLE());

            update_originalXiEtaOffset(uC_PLATPLOT1ACT.Get_POINT_LAT().Get_me_COORDINATE_DOUBLE(),
                uC_PLATPLOT1ACT.Get_POINT_LON().Get_me_COORDINATE_DOUBLE(),
                uC_PLATPLOT1CMD.Get_POINT_LAT().Get_me_COORDINATE_DOUBLE(),
                uC_PLATPLOT1CMD.Get_POINT_LON().Get_me_COORDINATE_DOUBLE());
        }
        private void TimerLoop_Tick(object sender, EventArgs e)
        {

            cb_can.Checked = KvsrManager.Instance.GetIsOnBus();
            Update_og_and_new(false);

            if (!cb_can.Checked) { return; }
            ushort heading = (ushort)Math.Round(headingDoubleForXIEtha * Math.PI / 180 * 10000);
            byte lowByte = (byte)heading;
            byte highByte = (byte)(heading >> 8);
            byte[] _PGNdata_Heading_09F1127F = new byte[8];
            _PGNdata_Heading_09F1127F[1] = lowByte;
            _PGNdata_Heading_09F1127F[2] = highByte;

            byte[] xiBytes = BitConverter.GetBytes(temxiValue);
            byte[] etaBytes = BitConverter.GetBytes(temetaValue);

            byte[] combined_Xi_eta = new byte[8];
            Array.Copy(xiBytes, 0, combined_Xi_eta, 0, 4);
            Array.Copy(etaBytes, 0, combined_Xi_eta, 4, 4);

            uint latACTuint = uC_PLATPLOT1ACT.Get_POINT_LAT().Get_me_COORD_x1E7();
            uint lonACTuint = uC_PLATPLOT1ACT.Get_POINT_LON().Get_me_COORD_x1E7();
            uint latCMDuint = uC_PLATPLOT1CMD.Get_POINT_LAT().Get_me_COORD_x1E7();
            uint lonCMDuint = uC_PLATPLOT1CMD.Get_POINT_LON().Get_me_COORD_x1E7();

            if (cb_allow.Checked)
            {

                KvsrManager.Instance.SendPGN_withStatus(1, 0x09F1127F, _PGNdata_Heading_09F1127F);

                KvsrManager.Instance.SendPGN_withStatus(1, 0x09F8017F, BitConverter.GetBytes(latCMDuint).Concat(BitConverter.GetBytes(lonCMDuint)).ToArray());

                KvsrManager.Instance.SendPGN_withStatus(1, 0x18FF6729, combined_Xi_eta);
            }

        }
        private void Btn_arrive_equator_Click(object sender, EventArgs e)
        {
            // lat 0.00
            //lon -71.205125 same as newton
            uC_PLATPLOT1CMD.SetLatLon_DoubleDouble(0.00, -71.205125);
            uC_PLATPLOT1ACT.SetLatLon_DoubleDouble(0.00, -71.205125);
            uC_360Heading.ResetAll();

        }
        private void Btn_arrive_newton_Click(object sender, EventArgs e)
        {
            //lat 42.36487 
            //lon -71.205125
            uC_PLATPLOT1CMD.SetLatLon_DoubleDouble(42.36487, -71.205125);
            uC_PLATPLOT1ACT.SetLatLon_DoubleDouble(42.36487, -71.205125);
            uC_360Heading.ResetAll();
        }
        private void Uc_PointLatLon_CMD_Clicked(object sender, EventArgs e)
        {
            uC_PLATPLOT1CMD.SetLatLon_DoubleDouble(0.01, 0.01);
        }
        private void Uc_PointLatLonACT_Clicked(object sender, EventArgs e)
        {
            uC_PLATPLOT1ACT.SetLatLon_DoubleDouble(0.02, 0.02);
        }
        private void Btn_resetAll_Click(object sender, EventArgs e)
        {
            uC_PLATPLOT1CMD.ResetAll();
            uC_PLATPLOT1ACT.ResetAll();
            uC_360Heading.ResetAll();
        }
    }
}
