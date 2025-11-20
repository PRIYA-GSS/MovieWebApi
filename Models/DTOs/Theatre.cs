using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class Theatre
    {
        [Key]
        public int TheatreId { get; set; }
        [Required]
        [MaxLength(100)]
        public string TheatreName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        public IList<int> BookingIds { get; set; } = new List<int>();
        public IList<int> MovieIds { get; set; } = new List<int>();
    }
}
