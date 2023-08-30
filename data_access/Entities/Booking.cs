using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public bool? Status { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
