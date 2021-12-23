using Microsoft.EntityFrameworkCore;

namespace UniversityAutomate.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
            .HasIndex(p => p.CityName)
            .IsUnique(true);

            modelBuilder.Entity<University>()
            .HasIndex(p => p.UniversityName)
            .IsUnique(true);

            modelBuilder.Entity<Group>()
            .HasIndex(p => new {p.GroupName, p.UniversityID})
            .IsUnique(true);

            modelBuilder.Entity<Student>()
            .HasIndex(p => p.StudentName)
            .IsUnique(true);
        }
    }
}
