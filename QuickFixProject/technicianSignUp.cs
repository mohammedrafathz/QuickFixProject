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
    public partial class TechnicianSignUp : Form
    {

        private UsersData userdb;
        public TechnicianSignUp()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void technicianSignUp_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                u.IsAdmin = false;
                u.Role = "Technician";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

            TechnicianLogin tl = new TechnicianLogin();
            tl.Show();
        }
    }
}
