using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MovieWebApiDb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Theatres)
                .WithMany(t => t.Movies)
                .UsingEntity<Movie>(j => j.ToTable("Movie-Theatres"));
                
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Theatre>()
                .HasMany(t=>t.Bookings)
                .WithOne(b=>b.Theatre)
                .HasForeignKey(b => b.TheatreId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
