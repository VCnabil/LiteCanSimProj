using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj.OBJs
{
    public class GPSPOSOBJ
    {
        int _degs_lat;
        int _mins_lat;
        int _secsWhole_lat;
        int _secsHundredths_lat;
        double _secs_lat;

        int _degs_lon;
        int _mins_lon;
        int _secsWhole_lon;
        int _secsHundredths_lon;
        double _secs_lon;

        byte[] _dataArray;

        //setter filters for the properties
        public int Degs_LAT
        {
            get { return _degs_lat; }
            set
            {
                if (value >= 0 && value <= 360)
                {
                    _degs_lat = value;
                }
            }
        }
        public int Mins_LAT
        {
            get { return _mins_lat; }
            set
            {
                if (value >= 0 && value < 60) // : Minutes should be less than 60
                {
                    _mins_lat = value;
                }
            }
        }
        public int SecsWhole_LAT
        {
            get { return _secsWhole_lat; }
            set
            {
                if (value >= 0 && value < 60) // : Whole seconds should be less than 60
                {
                    _secsWhole_lat = value;
                    _secs_lat = _secsWhole_lat + _secsHundredths_lat / 100.0; // Use 100.0 to ensure double division
                }
            }
        }
        public int SecsHundredths_LAT
        {
            get { return _secsHundredths_lat; }
            set
            {
                if (value >= 0 && value < 100) // : Hundredths should be less than 100
                {
                    _secsHundredths_lat = value;
                    _secs_lat = _secsWhole_lat + _secsHundredths_lat / 100.0; // Ensure double division
                }
            }
        }

        public double Secs_LAT
        {
            get { return _secs_lat; }
            set
            {
                if (value >= 0 && value < 60) // : Seconds should be less than 60
                {
                    _secsWhole_lat = (int)value;
                    _secsHundredths_lat = (int)((value - _secsWhole_lat) * 100);
                    _secs_lat = value;
                }
            }
        }

        public int Degs_LON
        {
            get { return _degs_lon; }
            set
            {
                if (value >= -360 && value <= 360)
                {
                    _degs_lon = value;
                }
            }
        }
        public int Mins_LON
        {
            get { return _mins_lon; }
            set
            {
                if (value >= 0 && value < 60) // : Minutes should be less than 60
                {
                    _mins_lon = value;
                }
            }
        }
        public int SecsWhole_LON
        {
            get { return _secsWhole_lon; }
            set
            {
                if (value >= 0 && value < 60) // : Whole seconds should be less than 60
                {
                    _secsWhole_lon = value;
                    _secs_lon = _secsWhole_lon + _secsHundredths_lon / 100.0; // Ensure double division
                }
            }
        }
        public int SecsHundredths_LON
        {
            get { return _secsHundredths_lon; }
            set
            {
                if (value >= 0 && value < 100) // : Hundredths should be less than 100
                {
                    _secsHundredths_lon = value;
                    _secs_lon = _secsWhole_lon + _secsHundredths_lon / 100.0; // Ensure double division
                }
            }
        }

        public double Secs_LON
        {
            get { return _secs_lon; }
            set
            {
                if (value >= 0 && value < 60) // : Seconds should be less than 60
                {
                    _secsWhole_lon = (int)value;
                    _secsHundredths_lon = (int)((value - _secsWhole_lon) * 100);
                    _secs_lon = value;
                }
            }
        }

        uint _latFullUnint;
        uint _longFullUnint;

        double _myLATITUDE_double;
        double _myLONGITUDE_double;

        public double Get_LATITUDE_double()
        {
            _secs_lat = _secsWhole_lat + _secsHundredths_lat / 100.0;
            _myLATITUDE_double = _degs_lat + _mins_lat / 60.0 + _secs_lat / 3600;
            return _myLATITUDE_double;
        }
        public double Get_LONGITUDE_double()
        {
            _secs_lon = _secsWhole_lon + _secsHundredths_lon / 100.0;
            _myLONGITUDE_double = _degs_lon + _mins_lon / 60.0 + _secs_lon / 3600;
            return _myLONGITUDE_double;
        }

        public uint LatFullUnint()
        {
            _secs_lat = _secsWhole_lat + _secsHundredths_lat / 100.0;
            _latFullUnint = (uint)((_degs_lat + _mins_lat / 60.0 + _secs_lat / 3600) * 1E7);
            return _latFullUnint;
        }
        public uint LonFullUnint()
        {
            _secs_lon = _secsWhole_lon + _secsHundredths_lon / 100.0;
            _longFullUnint = (uint)((_degs_lon + _mins_lon / 60.0 + _secs_lon / 3600) * 1E7);
            return _longFullUnint;
        }
        public GPSPOSOBJ()
        {
            _dataArray = new byte[8];
            _degs_lat = 0;
            _mins_lat = 0;
            _secsWhole_lat = 0;
            _secsHundredths_lat = 0;
            _secs_lat = 0.0;
            _degs_lon = 0;
            _mins_lon = 0;
            _secsWhole_lon = 0;
            _secsHundredths_lon = 0;
            _secs_lon = 0.0;

            _latFullUnint = (uint)((_degs_lat + _mins_lat / 60.0 + _secs_lat / 3600) * 1E7);
            _longFullUnint = (uint)((_degs_lon + _mins_lon / 60.0 + _secs_lon / 3600) * 1E7);

            _myLATITUDE_double = _degs_lat + _mins_lat / 60.0 + _secs_lat / 3600;
            _myLONGITUDE_double = _degs_lon + _mins_lon / 60.0 + _secs_lon / 3600;

            _dataArray = BitConverter.GetBytes(_latFullUnint).Concat(BitConverter.GetBytes(_longFullUnint)).ToArray();
        }
        public byte[] Get_LatLonInArrayForm()
        {
            return _dataArray;
        }

        #region unnecessary
        uint GetTransmitValueLAT()
        {
            double val = _degs_lat + _mins_lat / 60.0 + _secs_lat / 3600;
            return (uint)(val * 1E7);
        }

        uint GetTransmitValueLON()
        {
            double val = _degs_lon + _mins_lon / 60.0 + _secs_lon / 3600;
            return (uint)(val * 1E7);
        }
        #endregion
    }
}
