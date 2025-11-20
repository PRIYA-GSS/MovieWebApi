using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models.DTOs
{
  public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TheatreId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
