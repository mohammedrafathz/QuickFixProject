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
    public partial class AdminHomePage : Form
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ViewTickets vt = new ViewTickets();
            vt.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchTickets st = new SearchTickets();
            st.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard st = new Dashboard();
            st.Show();

            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.CurrentUserId = "";
            Homepage cl = new Homepage();
            cl.Show();
            this.Hide();
        }
    }
}
