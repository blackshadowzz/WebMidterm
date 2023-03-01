using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebMidterm.Models;

namespace WebMidterm.Data
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WebMidtermDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

      
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MovieArt> MovieArts { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<DirectorMovie> DirectorMovies { get; set; }
        //public DbSet<WebAppWeek01.Models.PeopleModel> PeopleModel { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<DirectorMovie>()
                .HasKey(am => new { am.DirectorId, am.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(x => x.Actor)
                .WithMany(x => x.ActorMovies)
                .HasForeignKey(x => x.ActorId);
            modelBuilder.Entity<ActorMovie>()
               .HasOne(x => x.Movie)
               .WithMany(x => x.ActorMovies)
               .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<DirectorMovie>()
                .HasOne(x => x.Director)
                .WithMany(x => x.DirectorMovies)
                .HasForeignKey(x => x.DirectorId);
            modelBuilder.Entity<DirectorMovie>()
               .HasOne(x => x.Movie)
               .WithMany(x => x.DirectorMovies)
               .HasForeignKey(x => x.MovieId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
