using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Film : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public TimeSpan Duration { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public List<MovieShow> MovieShows { get; set; } = new();
        public Rating? Rating { get; set; }
    }
}
