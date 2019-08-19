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
    public partial class chat : Form
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        int ID_Friend, ID_me;
        string User_Name;

        public chat(int id, int sign_in_id, string u)
        {
            InitializeComponent();
            ID_Friend = id;
            ID_me = sign_in_id;
            User_Name = u;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            string query = "INSERT INTO chat (ID1,ID2,Message) VALUES (@ID1,@ID2,@Message)";
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@ID1", ID_me.ToString());
            cmd.Parameters.AddWithValue("@ID2", ID_Friend.ToString());
            cmd.Parameters.AddWithValue("@Message", richTextBox1.Text);
            cmd.ExecuteNonQuery();
            db.connection.Close();    
            flowLayoutPanel1.Controls.Clear();
            load_chat();
            richTextBox1.Text = "";
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Write Your Message")
                richTextBox1.Text = "";
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                richTextBox1.Text = "Write Your Message";
        }

        private void chat_Load(object sender, EventArgs e)
        {
            load_chat();
        }
        public void load_chat()
        {
            label1.Text = User_Name;
            db.connection.Open();
            string query = "select * from chat where ID1 = " + ID_Friend.ToString() + " or ID1 = " + ID_me.ToString() + " and ID2 = " + ID_me.ToString() + " or ID2 = " + ID_Friend.ToString();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
               
                mess mess = new mess();
                if ((int)rdr["ID1"] == sign_in.id)
                    mess.set(rdr["Message"].ToString(), (int)rdr["ID1"], sign_in.user_name);
                else
                    mess.set(rdr["Message"].ToString(), (int)rdr["ID1"], User_Name);
                flowLayoutPanel1.Controls.Add(mess);
            }
            db.connection.Close();
        }
    }
}
