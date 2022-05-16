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
        public int TicketId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Impact { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public string TechnicianId { get; set; }
        public string Resolution { get; set; }
        public override string ToString()
        {
            return $@"{TicketId},{CustomerName},{Email},{PhoneNumber},{Location},{Description},{Category},{Priority},{Impact},{CustomerId},{Status},null,null";
        }
    }

    class TicketsData
    {
        // TODO change the file path
        private readonly string filePath = "C:\\Users\\Mohammed Rafathullah\\source\\repos\\QuickFixProject\\QuickFixProject\\Data\\Tickets.csv";
        List<Tickets> tickets = new List<Tickets>();

        public TicketsData()
        {
            LoadData();
        }

        public void LoadData()
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
                            TicketId = Convert.ToInt32(values[0]),
                            CustomerName = values[1],
                            Email = values[2],
                            PhoneNumber = values[3],
                            Location = values[4],
                            Description = values[5],
                            Category = values[6],
                            Priority = values[7],
                            Impact = values[8],
                            CustomerId = values[9],
                            Status = values[10],
                            TechnicianId = values[11],
                            Resolution = values[12]
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

        public List<Tickets> SearchTickets(string searchTerm)
        {
            List<Tickets> tl = new List<Tickets>();

            foreach (var t in tickets)
            {
                if (t.CustomerName == searchTerm || t.TechnicianId == searchTerm)
                {
                    tl.Add(t);
                }
            }

            return tl;
        }

        public Tickets GetTicketById(int id)
        {
            foreach (var t in tickets)
            {
                if (t.TicketId == id)
                {
                    return t;
                }
            }

            return null;
        }

        public string AddTicket(Tickets ticket)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    ticket.TicketId = tickets.Count + 1;
                    writer.WriteLine(ticket.ToString());
                }

                tickets.Clear();
                LoadData();

                return "Ticket Added Succcessfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create new ticket", ex.Message);
                return null;
            }
        }

        public string UpdateTicketStatus(string status, string resolution, int ticketId)
        {
            try
            {
                bool result = false;
                List<string> lines = new List<string>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(","))
                        {
                            string[] split = line.Split(',');

                            if (Convert.ToInt32(split[0]) == ticketId)
                            {
                                result = true;
                                split[10] = status;
                                split[12] = resolution;
                                line = string.Join(",", split);
                            }
                        }

                        lines.Add(line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (string line in lines)
                        writer.WriteLine(line);
                }
                if (result)
                {
                    return "Status Changed";
                }
                else
                {
                    return "Ticket does not exists.";
                }
            }
            catch (Exception)
            {
                return "Failed to change ticket status, error occured";
            }
        }

        public string AssignTechnician(string technicianId, int ticketId)
        {
            try
            {
                bool result = false;
                List<string> lines = new List<string>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(","))
                        {
                            string[] split = line.Split(',');
                            if (Convert.ToInt32(split[0]) == ticketId)
                            {
                                result = true;
                                split[10] = "Assigned";
                                split[11] = technicianId;
                                line = string.Join(",", split);
                            }
                        }

                        lines.Add(line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (string line in lines)
                        writer.WriteLine(line);
                }

                if (result)
                {
                    return "Ticket Assigned";
                }
                else
                {
                    return "Ticket does not exists.";
                }
            }
            catch (Exception)
            {
                return "Failed to assign ticket, error occured";
            }
        }
    }
}
