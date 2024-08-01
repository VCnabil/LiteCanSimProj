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
    public partial class uc_1_GpsLocation : UserControl
    {
        string _z_pointName = "na";
        //expose the title property in the designer view and use invalidate()
        [Category("ZCustom Properties")]
        [Description("Sets the name of the control")]
        public string Z_PointName
        {
            get { return _z_pointName; }
            set
            {
                _z_pointName = value;
                lbl_pointName.Text = _z_pointName;
                uc_0_Plat.Z_Title = _z_pointName + " Lat";
                uc_0_Plon.Z_Title = _z_pointName + " Lon";
                Invalidate();
            }
        }
        public uc_0_Point Get_POINT_LAT() { 
         return this.uc_0_Plat;
        }
        public uc_0_Point Get_POINT_LON() { 
         return this.uc_0_Plon;
        }
        public uc_1_GpsLocation()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            uc_0_Plat.REST_ALL_TO_ZERO();
            uc_0_Plon.REST_ALL_TO_ZERO();
        }
        public void SetLatLon_DoubleDouble(double arg_lat, double arg_lon){
            uc_0_Plat.Init_withDouble(arg_lat);
            uc_0_Plon.Init_withDouble(arg_lon);
        }
    }
}
