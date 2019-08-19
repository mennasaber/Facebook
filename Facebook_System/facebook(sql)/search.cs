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
    public partial class search : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public search()
        {
            InitializeComponent();
        }
        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Search")
                bunifuMaterialTextbox1.Text = "";

        }
        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
                bunifuMaterialTextbox1.Text = "Search";
        }
        private void clear()
        {
            if (bunifuMaterialTextbox1.Text == "")
                flowLayoutPanel1.Controls.Clear();
        }
        static public string key;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bool c1 = bunifuMaterialTextbox1.Text.Contains('+');
            bool c2 = bunifuMaterialTextbox1.Text.Contains('&');
            if (!c1 && !c2)
            {
                int counter = 0;
                key = bunifuMaterialTextbox1.Text;
                flowLayoutPanel1.Controls.Clear();
                db.connection.Open();
                string query = "select * from sign_up where User_Name like '%" + key + "%'";
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["ID"].ToString() == sign_in.id.ToString())
                        continue;
                    friend friend = new friend();
                    friend.id(rdr["ID"].ToString());
                    flowLayoutPanel1.Controls.Add(friend);
                    counter++;
                }
                db.connection.Close();
                if (counter == 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    Label label = new Label();
                    label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.ForeColor = System.Drawing.Color.White;
                    label.Size = new System.Drawing.Size(561, 65);
                    label.Text = "Not Found !";
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    flowLayoutPanel1.Controls.Add(label);
                }
            }
            else
            {
                if (c2)
                {

                    string[] s = bunifuMaterialTextbox1.Text.Split('&');
                    flowLayoutPanel1.Controls.Clear();
                   
                    check1(s[0], s[1]);
                }
                if (counter == 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    Label label = new Label();
                    label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.ForeColor = System.Drawing.Color.White;
                    label.Size = new System.Drawing.Size(561, 65);
                    label.Text = "No Mutual Friends !";
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    flowLayoutPanel1.Controls.Add(label);
                }
            }


        }
        int counter = 0;
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            clear();
        }
        private void search_Load(object sender, EventArgs e)
        {

        }
        int Id2;
        private void check1(string u1, string u2)
        {
            db.connection.Open();

            string query = "select ID from [sign_up] where User_Name = '" + u1 + "'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int Id1 = (int)cmd.ExecuteScalar();
            db.connection.Close();

            db.connection.Open();
            string query3 = "select ID from [sign_up] where User_Name = '" + u2 + "'";
            MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
            Id2 = (int)cmd3.ExecuteScalar();
            db.connection.Close();

          
            db.connection.Open();
            string query2 = "select * from [Friends] where ID1 = " + Id1 + "or ID2 = " + Id1 + "and Relationship = 'Friend'";
            MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
            MySqlDataReader rdr = cmd2.ExecuteReader();

            while (rdr.Read())
            {
                if ((int)rdr["ID1"] == Id1)
                {
                    check2((int)rdr["ID2"]);
                }
                else
                {
                    check2((int)rdr["ID1"]);
                }

            }
            db.connection.Close();
        }
        private void check2(int i)
        {

            string query1 = "select count(*) from [Friends] where ID1 = " + i + "and ID2 = " + Id2 + "and Relationship = 'Friend'";
            string query2 = "select count(*) from [Friends] where ID1 = " + Id2 + "and ID2 = " + i + "and Relationship = 'Friend'";
            MySqlCommand cmd1 = new MySqlCommand(query1, db.connection);
            MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
            int k = (int)cmd1.ExecuteScalar();
            int t = (int)cmd2.ExecuteScalar();
            

            if (k != 0 || t != 0)
            {
                string query3 = "select User_Name from [sign_up] where ID = " + i;
                MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
                string u = (string)cmd3.ExecuteScalar();
                liker mutual = new liker();
                counter++;
                mutual.set_name(u);
                if (counter == 1)
                {
                    flowLayoutPanel1.Controls.Clear();
                    Label label = new Label();
                    label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.ForeColor = System.Drawing.Color.White;
                    label.Size = new System.Drawing.Size(561, 65);
                    label.Text = "Mutual Friends !";
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    flowLayoutPanel1.Controls.Add(label);
                }
                flowLayoutPanel1.Controls.Add(mutual);
            }



        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
