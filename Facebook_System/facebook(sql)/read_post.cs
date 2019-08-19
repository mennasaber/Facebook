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
    public partial class read_post : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();
        int id;
        public read_post()
        {
            InitializeComponent();
        }

        private void read_post_Load(object sender, EventArgs e)
        {

        }
        string username;
        public void user_name(string n)
        {
            db.connection.Open();
            string query = "SELECT User_Name FROM Sign_Up WHERE ID = " + n;

            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            username = (string)cmd.ExecuteScalar();
            db.connection.Close();
            label1.Text = username;
        }
        public void post(string p)
        {
            label2.Text = p;
        }
        public void id_post(int i)
        {
            id = i;
        }

        private void like_Click(object sender, EventArgs e)
        {
            check(like.Name);
        }
        public void check(string r)
        {
            db.connection.Open();
            string query = "select count(*) from like_ where ID = " + sign_in.id + " and ID_Post = " + id;
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
           
            
            int k = int.Parse(cmd.ExecuteScalar().ToString());        
          
            if (k == 0)
            {
               
                string query2 = "insert into like_ (ID_Post,ID,user_name,React) values (@ID_Post,@ID,@user_name,@React)";
                MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                cmd2.Parameters.AddWithValue("@ID_Post", id);
                cmd2.Parameters.AddWithValue("@ID", sign_in.id);
                cmd2.Parameters.AddWithValue("@user_name", sign_in.user_name);
                cmd2.Parameters.AddWithValue("@React", r);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                string query3 = "select React from like_ where ID = " + sign_in.id + " and ID_Post = " + id;
                MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
                if (cmd3.ExecuteScalar().ToString() != r)
                {
                    string query4 = "update like_ set React = '" + r + "' where ID = " + sign_in.id + " and ID_Post = " + id;
                    MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                    cmd4.ExecuteNonQuery();
                }
            }
            db.connection.Close();
        }

        private void owo_Click(object sender, EventArgs e)
        {
            check(owo.Name);
        }

        private void love_Click(object sender, EventArgs e)
        {
            check(love.Name);
        }

        private void angry_Click(object sender, EventArgs e)
        {
            check(angry.Name);
        }

        private void sad_Click(object sender, EventArgs e)
        {
            check(sad.Name);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            likers likers = new likers(id);
            likers.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            comments comments = new comments(username , label2.Text , id);
            comments.Show();
        }
    }
}
