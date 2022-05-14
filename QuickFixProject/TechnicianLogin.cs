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
    public partial class TechnicianLogin : Form
    {
        private readonly UsersData userdb;
        public TechnicianLogin()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void lnkAdminSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TechnicianSignUp ts = new TechnicianSignUp();
            ts.Show();

            this.Hide();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fw = new ForgotPassword();
            fw.Show();

            this.Hide();
        }

        private void lnkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text != "" && txtPassword.Text != "")
            {
                string message = userdb.TechnicianLogin(txtUserId.Text, txtPassword.Text);

                if (message == "Login Success")
                {
                    CurrentUser.CurrentUserId = txtUserId.Text;
                    TechnicianTickets tt = new TechnicianTickets();

                    this.Hide();
                    tt.Show();
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
