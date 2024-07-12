using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Globalz
{
    public static class G_Properties
    {

        public static readonly string G_DefaultPortName = "COM11";
        public static bool USER_IS_NABIL = true;
        public static bool G_SuppressMessageBoxes = true;
        public static readonly int G_PGN_Description_MaxLength = 50;
        public static readonly int G_Byte_Description_MaxLength = 30;
        public static readonly int G_Bit_Description_MaxLength = 20;

        public static readonly uint Integer_8bit_MaxValue = 255;
        public static readonly uint Integer_16bit_MaxValue = 65535;
        public static readonly uint Integer_24bit_MaxValue = 16777215;
        public static readonly uint Integer_32bit_MaxValue = 4294967295;

        public static readonly string _baseKey = "FFF";
        public static void G_Update_Base_FFF_Width(float argNewWidth)
        {
            _Base_FFF_Width = argNewWidth + 1;
            _Base_FFF_Width_wasSet = true;
        }
        public static void G_Update_Base_FFF_Height(float argNewHeight)
        {
            _Base_FFF_Height = argNewHeight + 1;
            _Base_FFF_Height_wasSet = true;
        }
        public static float G_Get_Base_FFF_Width()
        {
            return _Base_FFF_Width;
        }
        public static float G_Get_Base_FFF_Height()
        {
            return _Base_FFF_Height;
        }
        public static int G_Get_Base_PGN_Display_Width()
        {
            return (int)(8 * _Base_FFF_Width);
        }
        public static int G_Get_Base_PGN_Display_Height()
        {
            return (int)(2 * _Base_FFF_Height) + 10;
        }
        public static int FontIndexSelected = 0;

        public static int FontSizeSelected = 8;

        public static readonly string[] MyFonts = new string[]
        {
            "NSimSun",
            "Miriam CLM",
            "Arial Narrow",
            "Calibri Light",
            "Verdana",
            "Tahoma",
            "Franklin Gothic Medium",
            "Futura Condensed",
            "Segoe UI",
            "Niagara Solid",
        };

        static float _Base_FFF_Width = 2.0f;
        static float _Base_FFF_Height = 2.0f;

        static bool _Base_FFF_Width_wasSet = false;
        static bool _Base_FFF_Height_wasSet = false;
        public static bool G_Base_Sizes_wereSet()
        {
            return _Base_FFF_Width_wasSet && _Base_FFF_Height_wasSet;
        }

        public readonly struct WindowParameters
        {
            public int Width { get; }
            public int Height { get; }
            public WindowParameters(int width, int height)
            {
                Width = width;
                Height = height;
            }
        }
        public static readonly bool G_IsDebugging = false;
        public static readonly bool G_IsMinimal = true;

        public static readonly WindowParameters G_MainWindowParames = new WindowParameters(2000, 1800);

        public static readonly WindowParameters G_TestWindowParames = new WindowParameters(1800, 800);

        public static readonly WindowParameters G_PGN_Manager_ViewrGUI_WindowParames = new WindowParameters(1780, 1800);

        public static readonly WindowParameters G_PGN_CanManipV0_WindowParames = new WindowParameters(3000, 2000);
    }
}
