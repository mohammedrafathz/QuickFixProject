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
    public partial class ViewTickets : Form
    {
        private TicketsData tickets;
        public ViewTickets()
        {
            InitializeComponent();
            tickets = new TicketsData();

            List<Tickets> tt = tickets.GetAllTickets();

            foreach (Tickets t in tt)
            {
                dgvTickets.Rows.Add(t.TicketId, t.CustomerName, t.Location, "Details");
            }
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
