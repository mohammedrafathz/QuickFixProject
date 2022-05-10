using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixProject.DataLayer
{
    internal class Tickets
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Impact { get; set; }
    }

    class TicketsData
    {
        private readonly string filePath = "C:\\Users\\Mohammed Rafathullah\\source\\repos\\QuickFixProject\\QuickFixProject\\Data\\Tickets.csv";
        List<Tickets> tickets = new List<Tickets>();

        public TicketsData()
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Tickets ticket = new Tickets()
                        {
                            CustomerName = values[0],
                            Email = values[1],
                            PhoneNumber = values[2],
                            Location = values[3],
                            Description = values[4],
                            Category = values[5],
                            Priority = values[6],
                            Impact = values[7],
                        };

                        tickets.Add(ticket);
                    }
                }
            }
        }

        public List<Tickets> GetAllTickets()
        {
            return tickets;
        }

        public string AddTicket(Tickets ticket)
        {
            return "";
        }

        public string UpdateTicketStatus(Tickets ticket)
        {
            return "";
        }
    }
}
