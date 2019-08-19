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
    public partial class Home : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public Home()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int id = sign_in.id;
        private void Home_Load(object sender, EventArgs e)
        {

        }
        int counter = 0;
        public void load_post()
        {
            flowLayoutPanel1.Controls.Clear();
            db.connection.Open();
            string query = "SELECT * FROM post ";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                check_ownpost(rdr["ID"].ToString(), rdr["Privacy"].ToString());
                if (f || pb || me)
                {
                    f = false;
                    pb = false;
                    me = false;
                    counter++;
                    read_post read_post = new read_post();
                    read_post.user_name(rdr["ID"].ToString());
                    read_post.post(rdr["Post"].ToString());
                    read_post.id_post((int)rdr["ID_Post"]);
                    flowLayoutPanel1.Controls.Add(read_post);
                }
            }
            db.connection.Close();
            if(counter == 0)
            {
                flowLayoutPanel1.Controls.Clear();
                Label label = new Label();
                label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.ForeColor = System.Drawing.Color.White;
                label.Size = new System.Drawing.Size(561, 65);
                label.Text = "No Posts !";
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                flowLayoutPanel1.Controls.Add(label);
            }
        }
        bool f = false, pb = false, me = false;
        private void check_ownpost(string i, string p)
        {
            DBConnection db2 = new DBConnection();
            db2.connection.Open();
            string query1 = "SELECT count(*) FROM Friends WHERE ID1 = " + sign_in.id.ToString() + " AND ID2 = " + i.ToString() + " AND Relationship = 'Friend'";
            MySqlCommand cmd1 = new MySqlCommand(query1, db2.connection);
            int n1 = int.Parse(cmd1.ExecuteScalar().ToString());
            string query2 = "SELECT count(*) FROM Friends WHERE ID1 = " + i.ToString() + " AND ID2 = " + sign_in.id.ToString() + " AND Relationship = 'Friend' ";
            MySqlCommand cmd2 = new MySqlCommand(query2, db2.connection);
            int n2 = int.Parse(cmd2.ExecuteScalar().ToString());
            if (n1 == 1 || n2 == 1)
            {
                f = true;
            }

            if (p == "Public    ")
            {
                pb = true;
            }
            if (i == sign_in.id.ToString())
            {
                me = true;
            }
            db2.connection.Close();
        }

    }
}
