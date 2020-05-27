using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static int id;
        public static string oldPass;
        public static string depart;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginAuthentication());
        }
    }
}
