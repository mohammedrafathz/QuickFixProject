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
    public partial class ChangeStatus : Form
    {
        private TicketsData td;
        private int ticketID;
        public ChangeStatus(int ticketID)
        {
            InitializeComponent();
            this.ticketID = ticketID;
            td = new TicketsData();
        }

        private void ChangeStatus_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = td.UpdateTicketStatus(
                cbTicketStatus.SelectedItem.ToString(),
                rtResolution.Text,
                ticketID
            );

            if (message == "Status Changed")
            {
                lblMessage.Text = "Status updated successfully";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbTicketStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTicketStatus.SelectedItem.ToString() == "Resolved")
            {
                lblResolution.Visible = true;
                rtResolution.Visible = true;
            }
            else
            {
                lblResolution.Visible = false;
                rtResolution.Visible = false;
            }
        }
    }
}
