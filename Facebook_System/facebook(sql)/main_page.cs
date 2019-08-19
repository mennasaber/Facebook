using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace facebook_sql_
{
    public partial class main_page : Form
    {
        
        public main_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_page_Load(object sender, EventArgs e)
        {
            //con.Open();
            //string query2 = "SELECT count(*) FROM Friends WHERE ID2 = " + sign_in.id.ToString() + "and Relationship = 'Sent Request'";
            //SqlCommand cmd2 = new SqlCommand(query2, con);
            //if ((int)cmd2.ExecuteScalar() != 0)
            //{
            //    bunifuThinButton27.ButtonText = "Request (" + cmd2.ExecuteScalar()+')';
            //}
            //con.Close();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            home2.Visible = false;
            label1.Visible = false;
            search1.Visible = false;
            request1.Visible = false;
            my_friends1.Visible = false;
            post2.Visible = false;
            messages1.load_friend();
            bunifuTransition1.ShowSync(messages1);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            home2.Visible = false;
            label1.Visible = false;
            search1.Visible = false;
            request1.Visible = false;
            my_friends1.Visible = false;
            messages1.Visible = false;
            bunifuTransition1.ShowSync(post2);
        }


        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            post2.Visible = false;
            label1.Visible = false;
            search1.Visible = false;
            request1.Visible = false;
            my_friends1.Visible = false;
            messages1.Visible = false;
            home2.load_post();
            bunifuTransition1.ShowSync(home2);                        
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            post2.Visible = false;
            label1.Visible = false;
            home2.Visible = false;
            request1.Visible = false;
            my_friends1.Visible = false;
            messages1.Visible = false;
            bunifuTransition1.ShowSync(search1);

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            post2.Visible = false;
            label1.Visible = false;
            home2.Visible = false;
            search1.Visible = false;
            my_friends1.Visible = false;
            messages1.Visible = false;
            request1.load_request();
            bunifuTransition1.ShowSync(request1);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            post2.Visible = false;
            label1.Visible = false;
            home2.Visible = false;
            search1.Visible = false;
            request1.Visible = false;
            messages1.Visible = false;
            my_friends1.load_friend();
            bunifuTransition1.ShowSync(my_friends1);
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
