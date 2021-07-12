using CartDB.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CartDB.Database.Data
{
    public class NesicomPostgreContext : DbContext
    {
        public NesicomPostgreContext()
        {
        }

        public NesicomPostgreContext(DbContextOptions<NesicomPostgreContext> options)
            : base(options)
        {
        }

        public DbSet<Cartridge> Cartridges { get; set; }
        public DbSet<CartridgeChip> CartridgeChips { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Pcb> Pcbs { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=Nesicom;Username=postgres;Password=password");
            }
        }
    }
}
