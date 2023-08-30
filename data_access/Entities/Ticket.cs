using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public MovieShow MovieShow { get; set; }
    }
}
