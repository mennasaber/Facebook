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
    public partial class messages : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public messages()
        {
            InitializeComponent();
        }

        private void messages_Load(object sender, EventArgs e)
        {

        }
        public void load_friend()
        {
            int counter = 0;
            flowLayoutPanel1.Controls.Clear();
            db.connection.Open();
            string query = "SELECT * FROM Friends WHERE ID2 = " + sign_in.id.ToString() + " or ID1 = " + sign_in.id.ToString() + " and Relationship = 'Friend'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr["ID1"].ToString() == sign_in.id.ToString())
                {
                    
                    friend_chat friend_chat = new friend_chat();
                    counter++;
                    friend_chat.id(rdr["ID2"].ToString(), (int)rdr["ID2"]);
                    flowLayoutPanel1.Controls.Add(friend_chat);
                }
                else
                {
                    friend_chat friend_chat = new friend_chat();
                    counter++;
                    friend_chat.id(rdr["ID1"].ToString(), (int)rdr["ID1"]);
                    flowLayoutPanel1.Controls.Add(friend_chat);
                }
            }
            db.connection.Close();
            if(counter==0)
            {
                flowLayoutPanel1.Controls.Clear();
                Label label = new Label();
                label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.ForeColor = System.Drawing.Color.White;
                label.Size = new System.Drawing.Size(540, 65);
                label.Text = "No Messages !";
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                flowLayoutPanel1.Controls.Add(label);
            }
        }
    }
}
