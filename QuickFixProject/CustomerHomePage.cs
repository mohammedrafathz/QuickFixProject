using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickFixProject
{
    public partial class CustomerHomepage : Form
    {
        public CustomerHomepage()
        {
            InitializeComponent();
            lblCurrentUser.Text = CurrentUser.CurrentUserId;
        }

        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            CreateTicket ct = new CreateTicket();
            ct.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentUser.CurrentUserId = "";
            CustomerLogin cl = new CustomerLogin();
            cl.Show();
            this.Hide();
        }
    }
}
