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
    public partial class CreateTicket : Form
    {
        private TicketsData ticketdb;
        public CreateTicket()
        {
            InitializeComponent();
            ticketdb = new TicketsData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                txtContactNumber.Text == "" || txtDescription.Text == "" ||
                txtEmail.Text == "" || txtLocation.Text == "" || txtUsername.Text == "" ||
                ddlCategory.SelectedItem.ToString() == "" || ddlImpact.SelectedItem.ToString() == ""
                )
            {
                lblMessage.Text = "Please enter all details to create a ticket";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                Tickets t = new Tickets();

                t.CustomerName = txtUsername.Text;
                t.Description = txtDescription.Text;
                t.Priority = ddlImpact.SelectedItem.ToString();
                t.PhoneNumber = txtContactNumber.Text;
                t.Email = txtEmail.Text;
                t.Location = txtLocation.Text;
                t.Category = ddlCategory.SelectedItem.ToString();
                t.Impact = ddlCategory.SelectedItem.ToString();
                t.CustomerId = CurrentUser.CurrentUserId;
                t.Status = "Open";

                string message = ticketdb.AddTicket(t);

                if (message == "Ticket Added Succcessfully")
                {
                    TicketStatus ts = new TicketStatus();
                    ts.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Text = message;
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerHomepage c = new CustomerHomepage();
            c.Show();
            this.Hide();
        }

        private void CreateTicket_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
