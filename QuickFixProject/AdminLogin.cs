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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Console.WriteLine(txtUserId.Text);

            Console.WriteLine(txtPassword.Text);

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            
            AdminSignUp adminSignUp = new AdminSignUp();
            adminSignUp.Show();
            
            lnkAdminSignUp.LinkVisited = true;
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
            
            lnkForgotPassword.LinkVisited = true;
        }
    }
}
