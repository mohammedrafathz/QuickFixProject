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
    public partial class TechnicianTickets : Form
    {
        private TicketsData tickets;
        public TechnicianTickets()
        {
            InitializeComponent();
            tickets = new TicketsData();
            lblUser.Text = CurrentUser.CurrentUserId;

            List<Tickets> tt = tickets.GetAllTickets();

            foreach (Tickets t in tt)
            {
                if (CurrentUser.CurrentUserId == t.TechnicianId)
                {
                    dgvTickets.Rows.Add(t.TicketId, t.CustomerName, t.Location, t.Status, "Details");
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.CurrentUserId = "";
            TechnicianLogin cl = new TechnicianLogin();
            cl.Show();
            this.Hide();
        }

        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTickets.Columns["details"].Index && e.RowIndex >= 0)
            {
                TicketDetails td = new TicketDetails(Convert.ToInt32(dgvTickets.Rows[e.RowIndex].Cells[0].Value));
                td.Show();
                this.Hide();
            }
        }
    }
}
