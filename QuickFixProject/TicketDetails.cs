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
        private Users users1;
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

            if (t.Resolution != null)
            {
                label10.Visible = true;
                lblResolution.Text = t.Resolution;
            }

            users1 = ud.GetUserByid(CurrentUser.CurrentUserId);
            cbTech.Visible = false;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;

            if (users1.IsAdmin)
            {
                cbTech.Visible = true;
                label1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                List<Users> users = ud.GetAllTechnicians();

                foreach (var u in users)
                {
                    cbTech.Items.Add(u.UserID);
                }
            }
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            if (users1.IsAdmin)
            {
                ViewTickets vt = new ViewTickets();
                vt.Show();
                this.Hide();
            }
            else
            {
                TechnicianTickets tt = new TechnicianTickets();
                tt.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (users1.IsAdmin)
            {
                ViewTickets vt = new ViewTickets();
                vt.Show();
                this.Hide();
            }
            else
            {
                TechnicianTickets tt = new TechnicianTickets();
                tt.Show();
                this.Hide();
            }
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

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ChangeStatus cs = new ChangeStatus(tID);
            cs.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TicketDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
