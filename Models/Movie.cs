using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieBillboard.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Rated { get; set; }

        [DataType(DataType.Date)]
        public DateTime Released { get; set; }

        public string? Runtime { get; set; }
        
        [Required]
        public string? Genre { get; set; }

        public string? Director { get; set; }

        public string? Actors { get; set; }

        public string? Plot { get; set; }

        [Display(Name = "Poster URL")]
        public string? Poster { get; set; }

        [Display(Name = "Imdb Rating")]
        [Column(TypeName = "decimal(18, 2)")]
        public double ImdbRating { get; set; }

        [Display(Name = "Box Office")]
        public string? BoxOffice { get; set; }

    }
}
