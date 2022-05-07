using System;
using System.Windows.Forms;

namespace QuickFixProject
{
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

            AdminLogin al = new AdminLogin();
            al.Show();
        }
    }
}
