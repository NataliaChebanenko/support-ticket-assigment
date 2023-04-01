using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketSystem.Data.Models
{
    public class Ticket
    {
        public Ticket()
        {

        }

        public int TicketId { get; set; }
        public string TicketDescription { get; set; }
        public DateTime TicketRegistered { get; set; }
        public string SupportComment { get; set; }
        public DateTime SupportCommentRegistered { get; set; }

        // Relationships
        public Customer Customer { get; set; }
    }
}
