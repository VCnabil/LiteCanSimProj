using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LiteCanSimProj._Globalz
{
    public static class Helpers
    {
        public enum CtrlType
        {
            _8_bs = 0,
            _8_bG = 1,
            _1_By = 2,
            _2_by = 3,
            _3_by = 4,
            _4_by = 5
        }
        public static string EnumToString_CtrlType(CtrlType argctrl_type)
        {
            return argctrl_type.ToString();
        }
        public static CtrlType StringToEnum_CtrlType(string argctrl_typeString)
        {
            if (Enum.TryParse(argctrl_typeString, out CtrlType ctrl_type))
            {
                return ctrl_type;
            }
            else
            {
                throw new ArgumentException("Invalid string for ctrl_type enum conversion");
            }
        }
        public static int HexStringToDecimal(string hexString)
        {
            try
            {
                return Convert.ToInt32(hexString, 16);
            }
            catch (FormatException)
            {
                Debug.Print("The string is not a valid hexadecimal number.");
                return 0;
            }
            catch (OverflowException)
            {
                Debug.Print("The hexadecimal number is too large to fit in a long.");
                return 0;
            }
        }
        public static (int, string) ParseBitsNamesString(string input)
        {
            int number;
            string text;
            // Split the string at the first period followed by a space
            var parts = input.Split(new[] { ". " }, StringSplitOptions.None);
            if (parts.Length >= 2 && int.TryParse(parts[0], out number))
            {
                // Successfully parsed the number, the rest of the string is the text
                text = input.Substring(parts[0].Length + 2);
            }
            else
            {
                // Handle the case where the string is not in the expected format
                number = -1; // or any default/error value
                text = input;
            }
            if (number > 7) number = 7;
            if (number < 0) number = 0;
            return (number, text);
        }
    }
}
