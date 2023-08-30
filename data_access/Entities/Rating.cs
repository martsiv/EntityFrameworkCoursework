using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Rating : IEntity
    {
        public int Id { get; set; }
        public float Estimate { get; set; }
        public string Review { get; set; }
        public int FilmId { get; set; }
        public Film? Film { get; set; }
    }
}
