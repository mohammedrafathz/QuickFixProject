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
    public partial class ForgotPassword : Form
    {
        private UsersData userdb;
        public ForgotPassword()
        {
            InitializeComponent();
            userdb = new UsersData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerLogin cl = new CustomerLogin();
            cl.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                lblMessage.Text = "Please enter a User ID";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                Users user = userdb.GetUserByid(txtUserId.Text);

                if (user != null)
                {
                    ChangePassword cp = new ChangePassword(txtUserId.Text);
                    this.Hide();
                    cp.Show();
                }
                else
                {
                    lblMessage.Text = "Invalid User ID";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}
