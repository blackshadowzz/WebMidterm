using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebMidterm.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [DisplayName("First Name"), Column(TypeName = ("nvarchar(40)"))]
        public string FirstName { get; set; }
        [DisplayName("Last Name"), Column(TypeName = ("nvarchar(40)"))]
        public string LastName { get; set; }
        [DisplayName("DoB")]

        public DateTime? Dob { get; set; }
        [Column(TypeName = ("nvarchar(15)"))]
        public string? Gender { get; set; }
        [Column(TypeName = ("nvarchar(30)"))]
        public string? JobTitle { get; set; }
        public decimal? Salary { get; set; }
        [Column(TypeName = ("nvarchar(20)"))]
        public string? Phone { get; set; }
        [Column(TypeName = ("varchar(100)"))]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }


        public ICollection<ActorMovie>? ActorMovies { get; set; }
        public ICollection<DirectorMovie>? DirectorMovies { get; set; }
    }
}
