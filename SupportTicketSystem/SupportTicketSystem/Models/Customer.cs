using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketSystem.Data.Models
{
    public class Customer
    {
        public Customer()
        {

        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNr { get; set; }

        // Relationships
        public List<Ticket> Tickets { get; set; }
    }
}