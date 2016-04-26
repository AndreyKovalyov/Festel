using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Festel1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static public string cons = "server\"127.0.0.1\"; DATABASE = \"Festel\"; UID = \"root\"; PWD = \"12345\"; PORT = \"3306\"";
        static public MySqlConnection Client = new MySqlConnection(cons);
    }
}
