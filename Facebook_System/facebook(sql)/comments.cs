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
    public partial class comments : Form
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        int ID;
        public comments(string u , string p , int id)
        {
            InitializeComponent();
            label1.Text = u;
            label2.Text = p;
            ID = id;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            string query = "insert into comment (ID_Post,Comment,ID,user_name) values  (@ID_Post,@Comment,@ID,@user_name) ";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@ID_Post", ID);
            cmd.Parameters.AddWithValue("@Comment", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@ID", sign_in.id);
            cmd.Parameters.AddWithValue("@user_name", sign_in.user_name);
            cmd.ExecuteNonQuery();
            db.connection.Close();
            load_comments();
            richTextBox1.Text = "";

        }
        private void load_comments()
        {
            flowLayoutPanel2.Controls.Clear();
            db.connection.Open();
            string query = "select * from comment where ID_Post = " + ID;
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                comment comment = new comment();
                comment.user_name(rdr["user_name"].ToString());
                comment.comm(rdr["Comment"].ToString());
                comment.id((int)rdr["ID_Comment"]);
                flowLayoutPanel2.Controls.Add(comment);
            }
            db.connection.Close();
        }

        private void comments_Load(object sender, EventArgs e)
        {
            load_comments();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Write Your Comment")
                richTextBox1.Text = "";
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                richTextBox1.Text = "Write Your Comment";
        }
    }
}
