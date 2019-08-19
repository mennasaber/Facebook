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
    public partial class comment : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public comment()
        {
            InitializeComponent();
        }

        private void comment_Load(object sender, EventArgs e)
        {

        }
        public void user_name(string u)
        {
            label1.Text = u;
        }
        int ID;
        public void id(int i)
        {
            ID = i;
        }
        public void comm(string c)
        {
            label2.Text = c;
        }

        private void like_Click(object sender, EventArgs e)
        {
            check(like.Name);
        }
        public void check(string r)
        {
            db.connection.Open();
            string query = "select count(*) from like_comment where ID = " + sign_in.id+ " and ID_Comment = "+ID ;
            MySqlCommand cmd = new MySqlCommand(query, db.connection);


            int k = int.Parse(cmd.ExecuteScalar().ToString());

            if (k == 0)
            {

                string query2 = "insert into like_comment (ID_Comment,ID,user_name,React) values (@ID_Comment,@ID,@user_name,@React)";
                MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                cmd2.Parameters.AddWithValue("@ID_Comment", ID);
                cmd2.Parameters.AddWithValue("@ID", sign_in.id);
                cmd2.Parameters.AddWithValue("@user_name", sign_in.user_name);
                cmd2.Parameters.AddWithValue("@React", r);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                string query3 = "select React from like_comment where ID = " + sign_in.id + " and ID_Comment = " + ID;
                MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
                if (cmd3.ExecuteScalar().ToString() != r)
                {
                    string query4 = "update like_comment set React = '" + r + "' where ID = " + sign_in.id + " and ID_Comment = " + ID;
                    MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                    cmd4.ExecuteNonQuery();
                }
            }
            db.connection.Close();
        }

        private void love_Click(object sender, EventArgs e)
        {
            check(love.Name);
        }

        private void owo_Click(object sender, EventArgs e)
        {
            check(owo.Name);
        }

        private void angery_Click(object sender, EventArgs e)
        {
            check(angery.Name);
        }

        private void sad_Click(object sender, EventArgs e)
        {
            check(sad.Name);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            liker_comment likers = new liker_comment(ID);
            likers.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            replies replies = new replies(label1.Text,label2.Text,ID);
            replies.Show();
        }
    }
}
