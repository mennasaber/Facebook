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

    public partial class sign_in : Form
    {
        static public int id;
        //static string sql = @"Data Source = .\SQLEXPRESS ; Initial Catalog = Facebook ; Integrated Security = True ; User ID = '' ; Password = '' ";
        //SqlConnection con = new SqlConnection(sql);
        DBConnection db = new DBConnection();
        public sign_in()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_Enter_1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Email")
                bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox1_Leave_1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
                bunifuMaterialTextbox1.Text = "Email";
        }

        private void bunifuMaterialTextbox2_Enter_1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Password")
            {
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox2.isPassword = true;
            }
        }

        private void bunifuMaterialTextbox2_Leave_1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "Password";
                bunifuMaterialTextbox2.isPassword = false;
            }
        }
        static public string user_name ;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID FROM sign_up WHERE Email = '" + bunifuMaterialTextbox1.Text + "' and Password = '" + bunifuMaterialTextbox2.Text + "'";
                db.connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                id = (int)cmd.ExecuteScalar();
                string query2 = "SELECT User_Name FROM sign_up WHERE ID = " + id;
                MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                user_name = (string)cmd2.ExecuteScalar();
              
                main_page main_page = new main_page();
                main_page.Show();
            }
            catch
            {
                MessageBox.Show("Incorrect login");
            }            
            db.connection.Close();
            bunifuMaterialTextbox1.Text = "Email";
            bunifuMaterialTextbox2.Text = "Password";
            bunifuMaterialTextbox2.isPassword = false;
        }

        private void sign_in_Load(object sender, EventArgs e)
        {

        }
    }
}
