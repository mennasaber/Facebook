using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace facebook_sql_
{
    public partial class request : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public request()
        {
            InitializeComponent();
        }
        private void request_Load(object sender, EventArgs e)
        {

        }
        public void load_request()
        {
            db.connection.Open();
            string query2 = "SELECT count(*) FROM Friends WHERE ID2 = " + sign_in.id.ToString() + " and Relationship = 'Sent Request'";
            MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
            if (int.Parse(cmd2.ExecuteScalar().ToString()) == 0)
            {
                flowLayoutPanel1.Controls.Clear();
                Label label = new Label();
                label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.ForeColor = System.Drawing.Color.White;
                label.Size = new System.Drawing.Size(561, 65);
                label.Text = "No Request !";
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                flowLayoutPanel1.Controls.Add(label);

            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                string query = "SELECT * FROM Friends WHERE ID2 = " + sign_in.id.ToString() + " and Relationship = 'Sent Request'";
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    friend friend = new friend();
                    friend.id(rdr["ID1"].ToString());
                    flowLayoutPanel1.Controls.Add(friend);
                }
            }
            db.connection.Close();
        }
    }
}
