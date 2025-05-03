using Microsoft.EntityFrameworkCore;
using Plants.Models;

namespace Plants.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<CareLog> CareLogs { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CareLog>()
                .Property(e => e.Action)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<Plant>()
                .HasMany(p => p.CareLogs)
                .WithOne(c => c.Plant)
                .HasForeignKey(c => c.PlantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Species>()
                .HasMany(s => s.Plants)
                .WithOne(p => p.Species)
                .HasForeignKey(p => p.SpeciesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plant>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Species>()
                .HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}
