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
    public partial class friend_chat : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public friend_chat()
        {
            InitializeComponent();
        }

        private void friend_chat_Load(object sender, EventArgs e)
        {

        }
        int ID;
        public void id(string i,int id)
        {
            db.connection.Open();
            ID= id; 
            string query = "select User_Name from sign_up where ID = " + i;
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            label1.Text = (string)cmd.ExecuteScalar();
            db.connection.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            chat chat = new chat(ID,sign_in.id,label1.Text);
            chat.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
