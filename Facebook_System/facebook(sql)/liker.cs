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
    public partial class liker : UserControl
    {
        public liker()
        {
            InitializeComponent();
        }

        private void liker_Load(object sender, EventArgs e)
        {

        }
        public void set_name(string n)
        {
            label1.Text = n;
        }
    }
}
