using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace facebook_sql_
{
    public partial class liker_reply : Form
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        int ID;
        public liker_reply(int i)
        {
            InitializeComponent();
            ID = i;
        }

        private void liker_reply_Load(object sender, EventArgs e)
        {
            num_like();
            num_love();
            num_owo();
            num_sad();
            num_angery();
        }
        private void num_like()
        {
            db.connection.Open();
            string query = "select count(*) from like_reply where ID_Reply = " + ID + " and React = 'like'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            label1.Text = n.ToString();
            db.connection.Close();
        }
       
        
        private void num_love()
        {
            db.connection.Open();
            string query = "select count(*) from like_reply where ID_Reply = " + ID + " and React = 'love'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            label3.Text = n.ToString();
            db.connection.Close();

        }

        private void num_owo()
        {
            db.connection.Open();
            string query = "select count(*) from like_reply where ID_Reply = " + ID + " and React = 'owo'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            label2.Text = n.ToString();
            db.connection.Close();

        }
        private void num_angery()
        {
            db.connection.Open();
            string query = "select count(*) from like_reply where ID_Reply = " + ID + " and React = 'angery'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            label4.Text = n.ToString();
            db.connection.Close();

        }
        private void num_sad()
        {
            db.connection.Open();
            string query = "select count(*) from like_reply where ID_Reply = " + ID + " and React = 'sad'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            label5.Text = n.ToString();
            db.connection.Close();

        }

        private void like_Click(object sender, EventArgs e)
        {
            check(like.Name);
        }
        private void check(string r)
        {
            flowLayoutPanel1.Controls.Clear();
            db.connection.Open();
            string query = "select * from like_Reply where ID_Reply = " + ID + " and React = '" + r + "'";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                liker liker = new liker();
                liker.set_name(rdr["user_name"].ToString());
                flowLayoutPanel1.Controls.Add(liker);
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
            check(angery.Name);
        }

        private void sad_Click(object sender, EventArgs e)
        {
            check(sad.Name);
        }
    }
}
