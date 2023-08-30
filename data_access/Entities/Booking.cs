using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public bool? Status { get; set; }
        public User User { get; set; }
        public Ticket Ticket{ get; set; }
    }
}
