using SuperstoreTool.SQLConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStore_Tool
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
            Application.SetCompatibleTextRenderingDefault(false);
            string stringConnectionSqlConfig = ConfigurationManager.ConnectionStrings["SuperstoreConnection"].ToString();
            DataAccess.SuperstoreServerConnectionUpdate(stringConnectionSqlConfig);
            Application.Run(new Form1());
        }
    }
}
