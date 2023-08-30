using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class MovieShow
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Film Film{ get; set; }
    }
}
