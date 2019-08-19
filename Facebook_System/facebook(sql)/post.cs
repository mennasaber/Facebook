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
    public partial class post : UserControl
    {
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        int ID = sign_in.id;
        public post()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }





        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "    Privacy" &&richTextBox1.Text!= " What's in your mind ?"&& richTextBox1.Text !="")

            {
                try
                {

                    string query = "INSERT INTO post (ID,Post,Privacy) VALUES (@ID,@Post,@Privacy)";
                    db.connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Post", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Privacy", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    refresh();
                }
                catch
                {
                    MessageBox.Show("Enter valid information");
                }
                db.connection.Close();
            }
            else
                MessageBox.Show("Enter valid information");
        }

        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == " What's in your mind ?")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.Font = new Font("Arial", 10, FontStyle.Regular);
            }
        }

        private void richTextBox1_Leave_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = " What's in your mind ?";
                richTextBox1.Font = new Font("Segeo UI", 16, FontStyle.Bold);
                richTextBox1.ForeColor = Color.Silver;
            }
        }

        private void post_Load(object sender, EventArgs e)
        {

        }
        public void refresh()
        {
            richTextBox1.Text = " What's in your mind ?";
            comboBox1.Text = "    Privacy";
            richTextBox1.Font = new Font("Segeo UI", 16, FontStyle.Bold);
            richTextBox1.ForeColor = Color.Silver;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
