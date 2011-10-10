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


            //string serverpath = @"j:\Download\BunnyBlogger\BunnyBlogger\WordLaunch\webserver";

            //Process webserver = new Process();
            //webserver.StartInfo = new ProcessStartInfo();
            //webserver.StartInfo.WorkingDirectory = serverpath;
            //webserver.StartInfo.FileName = Path.Combine(serverpath, "Server_Start.bat");
            //webserver.StartInfo.Verb = "open";
            //webserver.Start();


            SelectionForm sf = new SelectionForm();
            Application.Run(sf);

            Application.Run(new WordLaunch(sf.ServerInfo));

            

            //webserver.StartInfo.FileName = Path.Combine(serverpath, "Stop.bat");
            //webserver.Start();

            //Form2 f = new Form2();
            //f.ShowDialog();

            //if (f.Go)
            //{
            //    try
            //    {
            //        Application.Run(new Form1(f.URL, f.Username, f.Password));
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show("An error has occured: " + e.Message);
            //    }
            //}
        }
    }
}
