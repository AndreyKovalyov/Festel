using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Festel1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Telo festel = new Telo(Convert.ToInt32(textBox1.Text), textBox2.Text);//От этого пляшем :)
            Func.algoritm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = GetComments();
        }

        /*DataTable dt = new DataTable();
        DataTable GetComments()
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder connect = new MySqlConnectionStringBuilder();

            connect.Server = "127.0.0.1";
            connect.Database = "Festel";
            connect.UserID = "root";
            connect.Password = "12345";

            string zapros = @"SELECT * FROM start_info";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = connect.ConnectionString;

                MySqlCommand com = new MySqlCommand(zapros, con);

                try
                {
                    con.Open();

                    using(MySqlDataReader dr = com.ExecuteReader())
                    {
                        if(dr.HasRows)
                            dt.Load(dr);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return dt;
        }*/
    }
}
