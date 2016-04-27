using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Word;

namespace Festel1
{
    class MySql
    {
        MySql GetComments()
        {
            MySql dt = new MySql();
            MySqlConnectionStringBuilder connect = new MySqlConnectionStringBuilder();
            connect.Server = "127.0.0.1";
            connect.Database = "Festel";
            connect.UserID = "root";
            connect.Password = "12345";
            return dt;
        }
    }
}
