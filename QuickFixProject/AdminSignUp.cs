using QuickFixProject.DataLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickFixProject
{
    public partial class AdminSignUp : Form
    {
        private UsersData userdb;
        public AdminSignUp()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
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
                u.IsAdmin = true;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

            AdminLogin al = new AdminLogin();
            al.Show();
        }
    }
}
