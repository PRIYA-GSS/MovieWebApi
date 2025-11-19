using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Theatre
    {
        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
        public string Location { get; set; }
        public IList<Booking> Bookings { get; set; } = new List<Booking>();
        public IList<Movie> Movies { get; set; } = new List<Movie>();

    }
}
