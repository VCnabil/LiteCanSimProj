using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Globalz
{
    public static class G_Properties
    {
        public static bool G_SuppressMessageBoxes = true;
        public static readonly int G_PGN_Description_MaxLength = 50;
        public static readonly int G_Byte_Description_MaxLength = 30;
        public static readonly int G_Bit_Description_MaxLength = 20;

        public static readonly uint Integer_8bit_MaxValue = 255;
        public static readonly uint Integer_16bit_MaxValue = 65535;
        public static readonly uint Integer_24bit_MaxValue = 16777215;
        public static readonly uint Integer_32bit_MaxValue = 4294967295;
    }
}
