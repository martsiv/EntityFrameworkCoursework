using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
