using LiteCanSimProj._MainUIs.MainForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.Run(new Form1());
            Application.Run(new FormBridge());
           // Application.Run(new Form2());
            //Application.Run(new CanManip_V0Form());
        }
    }
}
