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
    public partial class replies : Form
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        int ID;
        public replies(string u , string c , int i)
        {
            InitializeComponent();
            label1.Text = u;
            label2.Text = c;
            ID = i;
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Write Your Reply")
                richTextBox1.Text = "";
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                richTextBox1.Text = "Write Your Reply";
        }
        private void load_replies()
        {
            flowLayoutPanel2.Controls.Clear();
            db.connection.Open();
            string query = "select * from Reply where ID_Comment = " + ID;
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                reply reply = new reply();
                reply.user_name(rdr["user_name"].ToString());
                reply.re(rdr["Reply"].ToString());
                reply.id((int)rdr["ID_Reply"]);
                flowLayoutPanel2.Controls.Add(reply);
            }
            db.connection.Close();
        }

        private void replies_Load(object sender, EventArgs e)
        {
            load_replies();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            string query = "insert into Reply (ID_Comment,Reply,user_name,ID) values (@ID_Comment,@Reply,@user_name,@ID) ";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@ID_Comment", ID);
            cmd.Parameters.AddWithValue("@Reply", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@ID", sign_in.id);
            cmd.Parameters.AddWithValue("@user_name", sign_in.user_name);
            cmd.ExecuteNonQuery();
            db.connection.Close();
            load_replies();
            richTextBox1.Text = "";
        }
    }
}
