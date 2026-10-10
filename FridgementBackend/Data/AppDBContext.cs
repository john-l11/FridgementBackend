using FridgementBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgementBackend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql();

        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
    }
}
