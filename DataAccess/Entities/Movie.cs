using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public IList<Theatre> Theatres { get; set; } = new List<Theatre>();
        public IList<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
