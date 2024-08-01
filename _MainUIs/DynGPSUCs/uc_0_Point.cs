using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj._MainUIs.DynGPSUCs
{
    public partial class uc_0_Point : UserControl
    {
        string _z_title = "na";
        // Expose the title property in the designer view and use invalidate()
        [Category("ZCustom Properties")]
        [Description("Sets the title of the control")]
        public string Z_Title
        {
            get { return _z_title; }
            set
            {
                _z_title = value;
                lbl_title.Text = _z_title;
                Invalidate();
            }
        }
        bool _z_isLat = true;
        // Expose the title property in the designer view and use invalidate()
        [Category("ZCustom Properties")]
        [Description("Sets the nature of this box Lat or Lon and the title of the control")]
        public bool Z_IsLat
        {
            get { return _z_isLat; }
            set
            {
                _z_isLat = value;
                //set back color to lightsalmon if lat else lightgreen
                this.BackColor = _z_isLat ? Color.LightSalmon : Color.LightGreen;
                Invalidate();
            }
        }


        double _my_COORDINATE_DOUBLE = 0.0;
        uint _my_COORD_x1E7;
        int _my_DEGS = 0;
        int _my_MINS = 0;
        double _my_SECS = 0.0;
        public uc_0_Point()
        {
            InitializeComponent();
            txb_Input.TextChanged += Txb__TextChanged;
            InitializeLabels();
            REST_ALL_TO_ZERO();
        }

        private void InitializeLabels()
        {
            txb_lat_Deci.Text = "--";
            txb_lat_DMS.Text = ": " + " DD MM SS.------";
        }
        public void REST_ALL_TO_ZERO()
        {
            txb_Input.Text = "00.0000";
            _my_COORDINATE_DOUBLE = 0.0;
            Read_textInouts_andUpdateDecimal();
        }
        private void Txb__TextChanged(object sender, EventArgs e)
        {
            Read_textInouts_andUpdateDecimal();
        }
        private bool TryParseCoordinate(string input, out double decimalDegrees)
        {
            decimalDegrees = 0.0;
            input = input.Trim();

            // Regex patterns for different formats
            var dmsPattern = @"^(\d{1,3})\s+(\d{1,2})\s+(\d{1,2}(?:\.\d+)?)([NSEW]?)$";
            var ddmPattern = @"^(\d{1,3})\s+(\d{1,2}\.\d+)([NSEW]?)$";
            var ddPattern = @"^(-?\d+(?:\.\d+)?)$";

            if (Regex.IsMatch(input, dmsPattern))
            {
                var match = Regex.Match(input, dmsPattern);
                int degrees = int.Parse(match.Groups[1].Value);
                int minutes = int.Parse(match.Groups[2].Value);
                double seconds = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
                string direction = match.Groups[4].Value;

                decimalDegrees = degrees + (minutes / 60.0) + (seconds / 3600.0);
                if (direction == "S" || direction == "W")
                {
                    decimalDegrees = -decimalDegrees;
                }
                return true;
            }

            if (Regex.IsMatch(input, ddmPattern))
            {
                var match = Regex.Match(input, ddmPattern);
                int degrees = int.Parse(match.Groups[1].Value);
                double minutes = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                string direction = match.Groups[3].Value;

                decimalDegrees = degrees + (minutes / 60.0);
                if (direction == "S" || direction == "W")
                {
                    decimalDegrees = -decimalDegrees;
                }
                return true;
            }

            if (Regex.IsMatch(input, ddPattern))
            {
                decimalDegrees = double.Parse(input, CultureInfo.InvariantCulture);
                return true;
            }

            return false;
        }
        void Read_textInouts_andUpdateDecimal()
        {
            string input = txb_Input.Text;

            if (TryParseCoordinate(input, out double decimalDegrees))
            {
                _my_COORDINATE_DOUBLE = decimalDegrees;
                _my_COORD_x1E7 = (uint)(_my_COORDINATE_DOUBLE * 1E7); // Update _my_COORD_x1E7

                var dms = ConvertToDMS(decimalDegrees, _z_isLat);
                var ddm = ConvertToDDM(decimalDegrees, _z_isLat);
                var dd = decimalDegrees.ToString("F5", CultureInfo.InvariantCulture);

                txb_lat_DMS.Text = "" + dms;
                txb_lat_Deci.Text = "" + dd;

                UpdateCoordinateComponents(decimalDegrees);

            }
            else
            {
                InitializeLabels();
            }

        }
        private void UpdateCoordinateComponents(double decimalDegrees)
        {
            _my_DEGS = (int)decimalDegrees;
            double minutesDecimal = Math.Abs((decimalDegrees - _my_DEGS) * 60);
            _my_MINS = (int)minutesDecimal;
            _my_SECS = (minutesDecimal - _my_MINS) * 60;

        }
        private string ConvertToDMS(double decimalDegrees, bool isLatitude)
        {
            int degrees = (int)decimalDegrees;
            double minutesDecimal = Math.Abs((decimalDegrees - degrees) * 60);
            int minutes = (int)minutesDecimal;
            double seconds = (minutesDecimal - minutes) * 60;

            char direction;
            if (isLatitude)
            {
                if (decimalDegrees == 0)
                    direction = 'N';
                else
                    direction = decimalDegrees > 0 ? 'N' : 'S';
            }
            else
            {
                if (decimalDegrees == 0)
                    direction = 'E';
                else
                    direction = decimalDegrees > 0 ? 'E' : 'W';
            }

            degrees = Math.Abs(degrees);

            // return $"{degrees}° {minutes}' {seconds:0.##}\" {direction}";
            return $"{degrees} {minutes} {seconds:0.###}{direction}";
        }
        private string ConvertToDDM(double decimalDegrees, bool isLatitude)
        {
            int degrees = (int)decimalDegrees;
            double minutes = Math.Abs((decimalDegrees - degrees) * 60);

            char direction;
            if (isLatitude)
            {
                if (decimalDegrees == 0)
                    direction = 'N';
                else
                    direction = decimalDegrees > 0 ? 'N' : 'S';
            }
            else
            {
                if (decimalDegrees == 0)
                    direction = 'E';
                else
                    direction = decimalDegrees > 0 ? 'E' : 'W';
            }

            degrees = Math.Abs(degrees);

            //return $"{degrees}° {minutes:0.###}' {direction}";
            return $"{degrees} {minutes:0.####} {direction}";
        }


        public void Init_withDouble(double arg_double)
        {
            _my_COORDINATE_DOUBLE = arg_double;
            txb_Input.Text = arg_double.ToString("F5", CultureInfo.InvariantCulture);
            Read_textInouts_andUpdateDecimal();
        }
        public uint Get_me_COORD_x1E7()
        {
            return _my_COORD_x1E7;
        }
        public double Get_me_COORDINATE_DOUBLE()
        {
            return _my_COORDINATE_DOUBLE;
        }
    }
}
