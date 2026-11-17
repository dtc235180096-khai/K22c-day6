using System.ComponentModel.DataAnnotations;

namespace K22c_day6.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]  
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        //Navigation property

        public Genre? Genre { get; set; }

    }
}
