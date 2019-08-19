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
    public partial class friend : UserControl
    {
        int ID1 = sign_in.id;
        int ID2;
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();
        public friend()
        {
            InitializeComponent();
        }
        private void friend_Load(object sender, EventArgs e)
        {

        }
        public void id(string i)
        {
            db.connection.Open();
            ID2 = Convert.ToInt32(i);
            string query = "select User_Name from sign_up where ID = " + Convert.ToInt32(i);
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            label1.Text = (string)cmd.ExecuteScalar();
            db.connection.Close();
            bool check1 = sent_to_me();
            bool check2 = sent_to_him();
            bool check3 = Friend();
            if (check1)
            {
                bunifuThinButton21.ButtonText = "Confirm";
                bunifuThinButton22.Visible = true;
            }
            if (check2)
                bunifuThinButton21.ButtonText = "Cancel Request";
            if (check3)
                bunifuThinButton21.ButtonText = "Friend";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if (bunifuThinButton21.ButtonText == "Add")
            {
                db.connection.Open();
                string query = "INSERT INTO Friends (ID1,ID2,Relationship) VALUES (@ID1,@ID2,@Relationship)";
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.Parameters.AddWithValue("@ID1", ID1);
                cmd.Parameters.AddWithValue("@ID2", ID2);
                cmd.Parameters.AddWithValue("@Relationship", "Sent Request");
                cmd.ExecuteNonQuery();
                db.connection.Close();
                bunifuThinButton21.ButtonText = "Cancel Request";
            }
            else if (bunifuThinButton21.ButtonText == "Cancel Request")
            {
                db.connection.Open();
                string query = "DELETE FROM Friends WHERE ID1 = " + ID1.ToString() + " and ID2 = " + ID2.ToString();
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.ExecuteNonQuery();
                db.connection.Close();
                bunifuThinButton21.ButtonText = "Add";
            }
            else if (bunifuThinButton21.ButtonText == "Confirm")
            {
                db.connection.Open();
                string query = "UPDATE Friends SET Relationship= 'Friend' WHERE ID1 = " + ID2.ToString() + " AND ID2 = " + ID1.ToString();
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.ExecuteNonQuery();
                db.connection.Close();
                bunifuThinButton22.Visible = false;
                bunifuThinButton21.ButtonText = "Friend";
            }
        }
        private bool sent_to_me()
        {
            bool SentToMe = false;
            db.connection.Open();
            string query = "select count(*) from Friends where ID1  =" + ID2.ToString() + " and Relationship = 'Sent Request' and ID2 = " + ID1.ToString();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int num = int.Parse(cmd.ExecuteScalar().ToString());          
            if (num == 1)
                SentToMe = true;
            db.connection.Close();
            return SentToMe;
        }
        private bool sent_to_him()
        {
            bool SentToHim = false;
            db.connection.Open();
            string query = "select count(*) from Friends where ID1  =" + ID1.ToString() + " and Relationship = 'Sent Request' and ID2 =" + ID2.ToString();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            int num = int.Parse(cmd.ExecuteScalar().ToString());
            if (num == 1)
                SentToHim = true;
            db.connection.Close();
            return SentToHim;
        }
        private bool Friend()
        {
            bool Frd = false;
            db.connection.Open();
            string query1 = "select count(*) from Friends where ID1  =" + ID1.ToString() + " and Relationship = 'Friend' and ID2 =" + ID2.ToString();
            MySqlCommand cmd1 = new MySqlCommand(query1, db.connection);
            int num1 = int.Parse(cmd1.ExecuteScalar().ToString());
            db.connection.Close();
            db.connection.Open();
            string query2 = "select count(*) from Friends where ID1  =" + ID2.ToString() + " and Relationship = 'Friend' and ID2 =" + ID1.ToString();
            MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
            int num2 = int.Parse(cmd2.ExecuteScalar().ToString());
            if (num1 == 1 || num2 == 1)
                Frd = true;
            db.connection.Close();
            return Frd;
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            string query = "DELETE FROM Friends WHERE ID1 = " + ID2.ToString() + " and ID2 = " + ID1.ToString();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.ExecuteNonQuery();
            db.connection.Close();
            bunifuThinButton22.Visible = false;
            bunifuThinButton21.ButtonText = "Add";
        }
    }
}
