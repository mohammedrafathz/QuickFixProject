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
    public partial class SearchTickets : Form
    {
        private TicketsData tickets;
        public SearchTickets()
        {
            InitializeComponent();
            tickets = new TicketsData();
            dgvSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Tickets> tt = new List<Tickets>();
            tt = tickets.SearchTickets(txtSearch.Text);
            lblMessage.Text = "";
            dgvSearch.Rows.Clear();
            dgvSearch.Refresh();
            dgvSearch.Visible = false;

            if (tt.Count > 0)
            {
                foreach (Tickets t in tt)
                {
                    dgvSearch.Rows.Add(t.TicketId, t.CustomerName, t.Location, t.Status, "Details");
                }

                dgvSearch.Visible = true;
            }
            else
            {
                dgvSearch.Visible = false;
                lblMessage.Text = "No Records found for the search.";
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSearch.Columns["details"].Index && e.RowIndex >= 0)
            {
                TicketDetails td = new TicketDetails(Convert.ToInt32(dgvSearch.Rows[e.RowIndex].Cells[0].Value));
                td.Show();
                this.Hide();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            AdminHomePage admin = new AdminHomePage();

            admin.Show();

            this.Hide();
        }
    }
}
