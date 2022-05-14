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
    public partial class Dashboard : Form
    {
        private TicketsData tickets;
        public Dashboard()
        {
            InitializeComponent();
            tickets = new TicketsData();
            comboBox1.SelectedIndex = comboBox1.FindString("Technician");

            List<string> x = new List<string>();
            List<int> y = new List<int>();

            TechniciansFilter(out x, out y);
            chart1.Series["Series1"].Points.DataBindXY(x, y);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> x = new List<string>();
            List<int> y = new List<int>();


            switch (comboBox1.SelectedItem.ToString())
            {
                case "Technician":
                    TechniciansFilter(out x, out y);
                    break;
                case "Category":
                    CategoryFilter(out x, out y);
                    break;
                case "Status":
                    StatusFilter(out x, out y);
                    break;
                case "Priority":
                    PriorityFilter(out x, out y);
                    break;
                case "Impact":
                    ImpactFilter(out x, out y);
                    break;
                default:
                    TechniciansFilter(out x, out y);
                    break;
            }

            chart1.Series["Series1"].Points.DataBindXY(x, y);
        }

        private void TechniciansFilter(out List<string> technicians, out List<int> counts)
        {
            List<Tickets> tt = tickets.GetAllTickets();

            technicians = new List<string>();

            foreach (Tickets t in tt)
            {
                string result = technicians.FirstOrDefault(x => x == t.TechnicianId);
                if (result == null)
                {
                    technicians.Add(t.TechnicianId);
                }
            }

            counts = new List<int>();

            foreach (var tech in technicians)
            {
                int count = tt.FindAll(t => t.TechnicianId == tech).Count();
                counts.Add(count);
            }
        }

        private void CategoryFilter(out List<string> categories, out List<int> counts)
        {
            List<Tickets> tt = tickets.GetAllTickets();

            categories = new List<string>();

            foreach (Tickets t in tt)
            {
                string result = categories.FirstOrDefault(x => x == t.Category);
                if (result == null)
                {
                    categories.Add(t.Category);
                }
            }

            counts = new List<int>();

            foreach (var tech in categories)
            {
                int count = tt.FindAll(t => t.Category == tech).Count();
                counts.Add(count);
            }
        }

        private void StatusFilter(out List<string> statuses, out List<int> counts)
        {
            List<Tickets> tt = tickets.GetAllTickets();

            statuses = new List<string>();

            foreach (Tickets t in tt)
            {
                string result = statuses.FirstOrDefault(x => x == t.Status);
                if (result == null)
                {
                    statuses.Add(t.Status);
                }
            }

            counts = new List<int>();

            foreach (var tech in statuses)
            {
                int count = tt.FindAll(t => t.Status == tech).Count();
                counts.Add(count);
            }
        }

        private void PriorityFilter(out List<string> prorities, out List<int> counts)
        {
            List<Tickets> tt = tickets.GetAllTickets();

            prorities = new List<string>();

            foreach (Tickets t in tt)
            {
                string result = prorities.FirstOrDefault(x => x == t.Priority);
                if (result == null)
                {
                    prorities.Add(t.Priority);
                }
            }

            counts = new List<int>();

            foreach (var tech in prorities)
            {
                int count = tt.FindAll(t => t.Priority == tech).Count();
                counts.Add(count);
            }

        }

        private void ImpactFilter(out List<string> impacts, out List<int> counts)
        {
            List<Tickets> tt = tickets.GetAllTickets();

            impacts = new List<string>();

            foreach (Tickets t in tt)
            {
                string result = impacts.FirstOrDefault(x => x == t.Impact);
                if (result == null)
                {
                    impacts.Add(t.Impact);
                }
            }

            counts = new List<int>();

            foreach (var tech in impacts)
            {
                int count = tt.FindAll(t => t.Impact == tech).Count();
                counts.Add(count);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            AdminHomePage ad = new AdminHomePage();

            ad.Show();
            this.Hide();
        }
    }
}
