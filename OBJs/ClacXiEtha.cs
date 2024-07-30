using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj.OBJs
{
    public class ClacXiEtha
    {
        static double radiusEarth_equatorial_ft = 6378.14 * 100000 / (2.54 * 12);
        static double radiusEarth_polar_ft = 6356.75 * 100000 / (2.54 * 12);
        public static double Calc_DeltaX(GPSPOSOBJ arg_cmd, GPSPOSOBJ arg_act)
        {

            double lat1 = 0; double lon1 = 0; double lat2 = 0; double lon2 = 0; double _resulte = 0;

            lat1 = arg_cmd.Get_LATITUDE_double();
            lon1 = arg_cmd.Get_LONGITUDE_double();

            lat2 = arg_act.Get_LATITUDE_double();
            lon2 = arg_act.Get_LONGITUDE_double();



            /*
              This function computes the east-west distance between two coordinates.
              The east-west distance is along a "circle of latitude" or "parallel"
              passing through the reference point (lat1/lon1).

              return value: distance in feet (> 0 if lon2 is due east of lon1)

              Note: 	The reference point is lat1/lon1... we want to know
                      how much lat2/lon2 is from the reference point

                      Example: 	a positive deltax is something like  "pt1 ..... pt2" in the LCD
                                  a negative deltax is something like  "pt2 ..... pt1" in the LCD
          */
            double del_longitude_deg = lon2 - lon1;
            // Ensure that sign of del_longitude_deg is correct for any values of lon1 and lon2.
            // 	 Note: 	Range of del_longitude_deg is -180 to 180 deg
            //   		Of course, we expect the value of del_longitude_deg to be close to zero.
            if (lon2 > lon1)
            {
                if (del_longitude_deg > 180) del_longitude_deg -= 360;
            }
            else
            {
                if (del_longitude_deg < -180) del_longitude_deg += 360;
            }
            double dist_EastWest = radiusEarth_equatorial_ft * Math.Cos(lat1 * Math.PI / 180) * del_longitude_deg * Math.PI / 180;

            _resulte = dist_EastWest * 10000;
            return _resulte;
        }
        public static double Calc_DeltaY(GPSPOSOBJ arg_cmd, GPSPOSOBJ arg_act)
        {
            double lat1 = 0; double lon1 = 0; double lat2 = 0; double lon2 = 0; double _resulte = 0;
            lat1 = arg_cmd.Get_LATITUDE_double();
            lon1 = arg_cmd.Get_LONGITUDE_double();

            lat2 = arg_act.Get_LATITUDE_double();
            lon2 = arg_act.Get_LONGITUDE_double();

            double dist_NorthSouth = radiusEarth_polar_ft * (lat2 - lat1) * Math.PI / 180;

            _resulte = dist_NorthSouth * 10000;
            return _resulte;
        }

        public static double Calc_OG_DeltaX(double lat1, double lon1, double lat2, double lon2)
        {
            double _resulte = 0;
            double del_longitude_deg = lon2 - lon1;

            if (lon2 > lon1)
            {
                if (del_longitude_deg > 180) del_longitude_deg -= 360;
            }
            else
            {
                if (del_longitude_deg < -180) del_longitude_deg += 360;
            }
            double dist_EastWest = radiusEarth_equatorial_ft * Math.Cos(lat1 * Math.PI / 180) * del_longitude_deg * Math.PI / 180;

            _resulte = dist_EastWest * 10000;
            return _resulte;

        }
        public static double Calc_OG_DeltaY(double lat1, double lon1, double lat2, double lon2)
        {
            double _resulte = 0;
            double dist_NorthSouth = radiusEarth_polar_ft * (lat2 - lat1) * Math.PI / 180;

            _resulte = dist_NorthSouth * 10000;
            return _resulte;
        }

        public static double[] ComputeOffsetsXiEta(double delx_ft, double dely_ft, double heading_deg)
        {
            /*
            *  This function computes offset pair (xi, eta)
            *
            *  Note: xi  is stored in offsets[0]
            *        eta is stored in offsets[1]
            */

            // distance between actual position and commanded position (units: feet)
            double r_ft = Math.Sqrt(delx_ft * delx_ft + dely_ft * dely_ft);

            // alpha: the polar angle corresponding to the heading (range: 0 to 359.9999)
            double alpha_deg = 0;//= ConvertHeadingToPolar(heading_deg);
            if (heading_deg <= 90)
            {
                alpha_deg = 90 - heading_deg;
            }
            else if (heading_deg <= 360)
            {
                alpha_deg = 450 - heading_deg;
            }

            // beta: the angle of the vector between target point and vessel (range: 0 to 359.9999)
            double beta_deg = RadsToDegs(Math.Atan2(dely_ft, delx_ft));
            // Ensure that beta_deg >= 0 Note: Expected range of above expression: -180 to 180 deg
            if (beta_deg < 0) beta_deg += 360;

            double[] offsets = new double[2];

            if (beta_deg >= 0 && beta_deg <= 90)
            {   // vessel in 1ST QUADRANT
                double alphaMinusBeta_deg = alpha_deg - beta_deg;
                // ensure the following:  0 <= (alpha - beta) <= 360
                if (alphaMinusBeta_deg < 0) alphaMinusBeta_deg += 360;
                else if (alphaMinusBeta_deg > 360) alphaMinusBeta_deg -= 360;

                if (alphaMinusBeta_deg >= 0 && alphaMinusBeta_deg <= 90)
                {   // Case 1 (in notes)
                    offsets[0] = r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg)); // xi
                    offsets[1] = r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg)); // eta
                }
                else if (alphaMinusBeta_deg > 90 && alphaMinusBeta_deg <= 180)
                {   // Case 2 (in notes)
                    offsets[0] = r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg - 90)); // xi
                    offsets[1] = -r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg - 90)); // eta
                }
                else if (alphaMinusBeta_deg > 180 && alphaMinusBeta_deg <= 270)
                {   // Case 3 (in notes)
                    offsets[0] = -r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg - 180)); // xi
                    offsets[1] = -r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg - 180)); // eta
                }
                else if (alphaMinusBeta_deg > 270 && alphaMinusBeta_deg <= 360)
                {   // Case 4 (in notes)
                    offsets[0] = -r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg - 270)); // xi
                    offsets[1] = r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg - 270)); // eta
                }
            }
            else if (beta_deg > 90 && beta_deg <= 180)
            {   // vessel in 2ND QUADRANT
                double betaMinusAlpha_deg = beta_deg - alpha_deg;
                // ensure the following:  -180 <= (beta - alpha) <= 180
                if (betaMinusAlpha_deg < -180) betaMinusAlpha_deg += 360;
                else if (betaMinusAlpha_deg > 180) betaMinusAlpha_deg -= 360;

                if (betaMinusAlpha_deg <= 180 && betaMinusAlpha_deg >= 90)
                {   // Case 1 (in notes)
                    offsets[0] = -r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg - 90)); // xi
                    offsets[1] = -r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg - 90)); // eta
                }
                else if (betaMinusAlpha_deg < 90 && betaMinusAlpha_deg >= 0)
                {   // Case 2 (in notes)
                    offsets[0] = -r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg)); // xi
                    offsets[1] = r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg)); // eta
                }
                else if (betaMinusAlpha_deg < 0 && betaMinusAlpha_deg >= -90)
                {   // Case 3 (in notes)
                    offsets[0] = r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg + 90)); // xi
                    offsets[1] = r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg + 90)); // eta
                }
                else if (betaMinusAlpha_deg < -90 && betaMinusAlpha_deg >= -180)
                {   // Case 4 (in notes)
                    offsets[0] = r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg + 180)); // xi
                    offsets[1] = -r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg + 180)); // eta
                }
            }
            else if (beta_deg > 180 && beta_deg <= 270)
            {   // vessel in 3RD QUADRANT
                double alphaMinusBeta_deg = alpha_deg - beta_deg;
                // ensure the following:  -270 <= (alpha - beta) <= 90
                if (alphaMinusBeta_deg < -270) alphaMinusBeta_deg += 360;
                else if (alphaMinusBeta_deg > 90) alphaMinusBeta_deg -= 360;

                if (alphaMinusBeta_deg >= 0 && alphaMinusBeta_deg <= 90)
                {   // Case 3 (in notes)
                    offsets[0] = r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg)); // xi
                    offsets[1] = r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg)); // eta
                }
                else if (alphaMinusBeta_deg < 0 && alphaMinusBeta_deg >= -90)
                {   // Case 2 (in notes)
                    offsets[0] = -r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg + 90)); // xi
                    offsets[1] = r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg + 90)); // eta
                }
                else if (alphaMinusBeta_deg < -90 && alphaMinusBeta_deg >= -180)
                {   // Case 1 (in notes)
                    offsets[0] = -r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg + 180)); // xi
                    offsets[1] = -r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg + 180)); // eta
                }
                else if (alphaMinusBeta_deg < -180 && alphaMinusBeta_deg >= -270)
                {   // Case 4 (in notes)
                    offsets[0] = r_ft * Math.Cos(DegsToRads(alphaMinusBeta_deg + 270)); // xi
                    offsets[1] = -r_ft * Math.Sin(DegsToRads(alphaMinusBeta_deg + 270)); // eta
                }
            }
            else if (beta_deg > 270 && beta_deg <= 360)
            {   // vessel in 4TH QUADRANT
                double betaMinusAlpha_deg = beta_deg - alpha_deg;
                // ensure the following:  -90 <= (beta - alpha) <= 270
                if (betaMinusAlpha_deg < -90) betaMinusAlpha_deg += 360;
                else if (betaMinusAlpha_deg > 270) betaMinusAlpha_deg -= 360;

                if (betaMinusAlpha_deg >= -90 && betaMinusAlpha_deg <= 0)
                {   // Case 1 (in notes)
                    offsets[0] = r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg + 90)); // xi
                    offsets[1] = r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg + 90)); // eta
                }
                else if (betaMinusAlpha_deg > 0 && betaMinusAlpha_deg <= 90)
                {   // Case 4 (in notes)
                    offsets[0] = -r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg)); // xi
                    offsets[1] = r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg)); // eta
                }
                else if (betaMinusAlpha_deg > 90 && betaMinusAlpha_deg <= 180)
                {   // Case 3 (in notes)
                    offsets[0] = -r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg - 90)); // xi
                    offsets[1] = -r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg - 90)); // eta
                }
                else if (betaMinusAlpha_deg > 180 && betaMinusAlpha_deg <= 270)
                {   // Case 2 (in notes)
                    offsets[0] = r_ft * Math.Sin(DegsToRads(betaMinusAlpha_deg - 180)); // xi
                    offsets[1] = -r_ft * Math.Cos(DegsToRads(betaMinusAlpha_deg - 180)); // eta
                }
            }
            offsets[0] *= -1.0f;

            return offsets;
        }

        public static double[] ComputeOffsetsXiEta_usingMatrix(double delx_ft, double dely_ft, double heading_deg)
        {
            double headingRad = heading_deg * Math.PI / 180;
            double xi = delx_ft * Math.Cos(headingRad) + dely_ft * Math.Sin(headingRad);
            double eta = -delx_ft * Math.Sin(headingRad) + dely_ft * Math.Cos(headingRad);

            return new double[] { xi, eta };

        }
        static double DegsToRads(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }
        static double RadsToDegs(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }

}
