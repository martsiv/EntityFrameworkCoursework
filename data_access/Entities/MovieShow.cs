using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class MovieShow : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        //public TimeSpan Duration { get; set; }
        public int FilmId { get; set; }
        public Film? Film { get; set; }
        public int CinemaHallId { get; set; }
        public CinemaHall? CinemaHall { get; set; }
        public List<Ticket> Tikets { get; set; } = new();
    }
}
