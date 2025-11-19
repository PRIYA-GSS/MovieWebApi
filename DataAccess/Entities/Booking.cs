using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
