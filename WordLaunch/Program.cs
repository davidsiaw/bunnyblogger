using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Skybound.Gecko;
using System.IO;
using System.Diagnostics;

namespace WordLaunch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Xpcom.Initialize(Path.Combine(Directory.GetCurrentDirectory(), "xulrunner"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            SelectionForm sf = new SelectionForm();
            Application.Run(sf);

            if (sf.ServerInfo != null)
            {
                Application.Run(new WordLaunch(sf.ServerInfo));
            }
        }
    }
}
