using System.Drawing;
using System.Windows.Forms;

namespace LiteCanSimProj._MainUIs._SizingUCs
{
    public partial class UCSizing : UserControl
    {
        float _labelWidth;
        float _labelHeight;
        public UCSizing(string argFont, int argFontSize, string _arg_skeletonString)
        {
            InitializeComponent();
            mlbl_B0.Text = _arg_skeletonString;
            mlbl_B0.Font = new Font(argFont, argFontSize, FontStyle.Bold);
            _labelWidth = mlbl_B0.Width / 2;
            _labelHeight = mlbl_B0.Height / 2;
        }
        public float Get_LableWidth()
        {
            return mlbl_B0.Width;
        }
        public float Get_LableHeight()
        {
            return mlbl_B0.Height;
        }
    }
}
