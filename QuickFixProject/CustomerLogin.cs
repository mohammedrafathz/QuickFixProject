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
        public CustomerLogin()
        {
            InitializeComponent();
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
    }
}
