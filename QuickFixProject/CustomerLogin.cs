using QuickFixProject.DataLayer;
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
    public partial class CustomerLogin : Form
    {
        private readonly UsersData userdb;
        public CustomerLogin()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void lnkAdminSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            CustomerSignUp cs = new CustomerSignUp();
            cs.Show();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            ForgotPassword fp = new ForgotPassword();
            fp.Show();
        }

        private void lnkAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text != "" && txtPassword.Text != "")
            {
                string message = userdb.CustomerLogin(txtUserId.Text, txtPassword.Text);

                if (message == "Login Success")
                {
                    CreateTicket customerHomePage = new CreateTicket();

                    this.Hide();
                    customerHomePage.Show();
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = message;
                }
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please enter your credentials";
            }
        }
    }
}
