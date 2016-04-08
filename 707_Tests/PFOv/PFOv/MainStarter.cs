using Hobis.Helpers;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace PFOv
{
    public static class MainStarter
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThreadAttribute]
        public static void Main()
        {
            if (SingleInstanceCheck.IsTest())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmRoot());
            }
        }
    }
}
