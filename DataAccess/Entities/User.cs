
namespace DataAccess.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
