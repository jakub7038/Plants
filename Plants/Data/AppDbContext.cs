using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Plants.Models; // Dodaj tę linię!

namespace Plants.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<CareLog> CareLogs { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>()
                .HasMany(p => p.CareLogs)
                .WithOne(c => c.Plant)
                .HasForeignKey(c => c.PlantId);

            modelBuilder.Entity<Species>()
                .HasMany(s => s.Plants)
                .WithOne(p => p.Species)
                .HasForeignKey(p => p.SpeciesId);
        }
    }
}