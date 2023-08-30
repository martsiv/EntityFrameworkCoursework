using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class CinemaHall : IEntity
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public int NumberOfSeats { get; set; }
        public List<MovieShow> MovieShows { get; set; } = new();
    }
}
