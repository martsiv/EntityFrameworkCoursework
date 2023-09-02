using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public int TicketStatusId { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public int MovieShowId { get; set; }
        public MovieShow? MovieShow { get; set; }
        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}
