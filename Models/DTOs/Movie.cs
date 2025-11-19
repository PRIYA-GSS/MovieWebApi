using System.ComponentModel.DataAnnotations;
namespace Models.DTOs
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Cast { get; set; }
        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }
    }
}
