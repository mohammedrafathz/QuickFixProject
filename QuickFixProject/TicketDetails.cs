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
    public partial class TicketDetails : Form
    {
        private TicketsData td;
        private UsersData ud;
        private int tID;
        public TicketDetails(int ticketId)
        {
            InitializeComponent();
            td = new TicketsData();
            ud = new UsersData();
            tID = ticketId;
            Tickets t = td.GetTicketById(ticketId);

            lblCategory.Text = t.Category;
            lblCustomerName.Text = t.CustomerName;
            lblDescription.Text = t.Description;
            lblEmail.Text = t.Email;
            lblImpact.Text = t.Impact;
            lblLocation.Text = t.Location;
            lblNumber.Text = t.PhoneNumber;
            lblPriority.Text = t.Priority;
            lblStatus.Text = t.Status;

            List<Users> users = ud.GetAllTechnicians();

            foreach (var u in users)
            {
                cbTech.Items.Add(u.UserID);
            }
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            ViewTickets vt = new ViewTickets();
            vt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewTickets vt = new ViewTickets();
            vt.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = td.AssignTechnician(cbTech.SelectedItem.ToString(), tID);

            if (message == "Ticket Assigned")
            {
                lblMsg.ForeColor = Color.Green;
                lblMsg.Text = message;
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = message;
            }
        }

        private void TicketDetails_Load(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblLocation_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbTech_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
