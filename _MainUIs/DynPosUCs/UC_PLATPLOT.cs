using LiteCanSimProj._MainUIs.DynPosUCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj._MainUIs
{
    public partial class UC_PLATPLOT : UserControl
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
                uC_PmyLAT.Z_Title = _z_pointName + " Lat";
                uC_PmyLON.Z_Title = _z_pointName + " Lon";
                Invalidate();
            }
        }
        public UC_PointDynData Get_POINT_LAT()
        {
            return this.uC_PmyLAT;
        }
        public UC_PointDynData Get_POINT_LON()
        {
            return this.uC_PmyLON;
        }
        public UC_PLATPLOT()
        {
            InitializeComponent();
        }
        public void ResetAll() {
            uC_PmyLAT.REST_ALL_TO_ZERO();
            uC_PmyLON.REST_ALL_TO_ZERO();
        }

        public void SetLatLon_DoubleDouble(double arg_lat, double arg_lon)
        {
            uC_PmyLAT.Init_withDouble(arg_lat);
            uC_PmyLON.Init_withDouble(arg_lon);
        }

    }
}
