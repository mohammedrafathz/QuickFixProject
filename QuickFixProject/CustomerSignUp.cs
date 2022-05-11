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
    public partial class CustomerSignUp : Form
    {
        private UsersData userdb;
        public CustomerSignUp()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerLogin cl = new CustomerLogin();

            this.Hide();
            cl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
            {
                lblMessage.Text = "Please enter your details to continue";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                Users u = new Users();
                u.Username = txtUserName.Text;
                u.Password = txtPassword.Text;
                u.UserID = txtUserId.Text;
                u.IsAdmin = false;
                string message = userdb.CreateNewUser(u);

                if (message == "New user created successfully")
                {
                    lblMessage.Text = "Sign up success. Please click on login to continue";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Failed to create user " + message;
                    lblMessage.ForeColor = Color.Red;
                }
            }

        }
    }
}
