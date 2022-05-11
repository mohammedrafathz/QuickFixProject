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
    public partial class AdminLogin : Form
    {
        private UsersData userdb;

        public AdminLogin()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtUserId.Text != "" && txtPassword.Text != "")
            {
                string message = userdb.AdminLogin(txtUserId.Text, txtPassword.Text);

                if (message == "Login Success")
                {
                    AdminHomePage adminHomePage = new AdminHomePage();
                    CurrentUser.CurrentUserId = txtUserId.Text;

                    this.Hide();
                    adminHomePage.Show();
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

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            CustomerLogin cl = new CustomerLogin();
            cl.Show();
        }
    }
}
