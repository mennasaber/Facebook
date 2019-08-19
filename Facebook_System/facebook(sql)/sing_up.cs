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
    public partial class sign_up : Form
    {
        string Type;
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();

        public sign_up()
        {
            InitializeComponent();
        }

        private void sing_up_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "User Name")
                bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
                bunifuMaterialTextbox1.Text = "User Name";
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Email")
                bunifuMaterialTextbox2.Text = "";
        }

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
                bunifuMaterialTextbox2.Text = "Email";
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "Password")
            {
                bunifuMaterialTextbox3.Text = "";
                bunifuMaterialTextbox3.isPassword = true;
            }
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "")
            {
                bunifuMaterialTextbox3.Text = "Password";
                bunifuMaterialTextbox3.isPassword = false;
            }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton1_Click(object sender, EventArgs e)
        {
            string Birth = comboBox1.Text + '-' + comboBox2.Text + '-' + comboBox3.Text;
            try
            {
                string query = "INSERT INTO sign_up (User_Name,Email,Password,Birthday,Type) VALUES (@User_Name,@Email,@Password,@Birthday,@Type)";
                db.connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                cmd.Parameters.AddWithValue("@User_Name", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@Email", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@Password", bunifuMaterialTextbox3.Text);
                cmd.Parameters.AddWithValue("@Birthday", Birth);
                cmd.Parameters.AddWithValue("@Type", Type);
         
                cmd.ExecuteNonQuery();
                this.Close();

            }
            catch
            {
                MessageBox.Show("Enter Valid Information");
            }
            db.connection.Close();           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Type = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Type = radioButton2.Text;
        }
    }
}
