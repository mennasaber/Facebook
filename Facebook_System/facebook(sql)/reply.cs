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
    public partial class reply : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public reply()
        {
            InitializeComponent();
        }

        private void reply_Load(object sender, EventArgs e)
        {

        }
        public void  user_name(string u)
        {
            label1.Text = u;
        }
        public void id(int i)
        {
            ID = i;
        }
        int ID;
        public void re(string r)
        {            
            label2.Text = r;
        }
        public void check(string r)
        {
            db.connection.Open();
            string query = "select count(*) from like_reply where ID = " + sign_in.id + " and ID_Reply = " + ID;
            MySqlCommand cmd = new MySqlCommand(query, db.connection);


            int k = int.Parse(cmd.ExecuteScalar().ToString());

            if (k == 0)
            {

                string query2 = "insert into like_reply (ID_Reply,ID,user_name,React) values (@ID_Reply,@ID,@user_name,@React)";
                MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                cmd2.Parameters.AddWithValue("@ID_Reply", ID);
                cmd2.Parameters.AddWithValue("@ID", sign_in.id);
                cmd2.Parameters.AddWithValue("@user_name", sign_in.user_name);
                cmd2.Parameters.AddWithValue("@React", r);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                string query3 = "select React from like_reply where ID = " + sign_in.id + " and ID_Reply = " + ID;
                MySqlCommand cmd3 = new MySqlCommand(query3, db.connection);
                if (cmd3.ExecuteScalar().ToString() != r)
                {
                    string query4 = "update like_Reply set React = '" + r + "' where ID = " + sign_in.id + " and ID_Reply = " + ID;
                    MySqlCommand cmd4 = new MySqlCommand(query4, db.connection);
                    cmd4.ExecuteNonQuery();
                }
            }
            db.connection.Close();
        }

        private void like_Click(object sender, EventArgs e)
        {
            check(like.Name);
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
            liker_reply liker_reply = new liker_reply(ID);
            liker_reply.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
