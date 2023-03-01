using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebMidterm.Models
{
    public class MovieArt
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? ArtName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Artist { get; set; }
        public string? ArtistUrl { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string? Description { get; set; }
        [DisplayName("Movie"), ForeignKey("Movie")]
        public int? MovieId { get; set; }

        [NotMapped]
        public IFormFile? FrontImage { get; set; }

        public Movie? Movie { get; set; }
    }
}
