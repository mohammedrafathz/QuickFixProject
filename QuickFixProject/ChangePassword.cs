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
    public partial class ChangePassword : Form
    {
        private string userId;
        private UsersData userdb;
        public ChangePassword(string userId)
        {
            this.userId = userId;
            userdb = new UsersData();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != "" || txtNewPassword.Text != "")
            {
                if (txtConfirmPassword.Text == txtNewPassword.Text)
                {
                    userdb.UpdatePassword(userId, txtNewPassword.Text);
                    CustomerLogin cl = new CustomerLogin();
                    cl.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Text = "Passwords don't match";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Passwords cannot be empty";
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerLogin al = new CustomerLogin();
            al.Show();
            this.Close();
        }
    }
}
