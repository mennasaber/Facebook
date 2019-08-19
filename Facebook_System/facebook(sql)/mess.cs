using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facebook_sql_
{
    public partial class mess : UserControl
    {
        public mess()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void set(string m , int i,string u)
        {
            label1.Text = u ;
            label2.Text = m ;
        }
    }
}
