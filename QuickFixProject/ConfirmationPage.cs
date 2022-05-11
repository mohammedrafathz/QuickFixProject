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
    public partial class ConfirmationPage : Form
    {
        public ConfirmationPage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTicket chp = new CreateTicket();
            this.Hide();
            chp.Show();

        }
    }
}
