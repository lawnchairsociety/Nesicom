using CartDB.Database.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CartDB.Database.Data
{
    public partial class NesicomContext : DbContext
    {
        public NesicomContext()
        {
        }

        public NesicomContext(DbContextOptions<NesicomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartridge> Cartridges { get; set; }
        public virtual DbSet<CartridgeCartridgeChip> CartridgeCartridgeChips { get; set; }
        public virtual DbSet<CartridgeChip> CartridgeChips { get; set; }
        public virtual DbSet<CartridgeImage> CartridgeImages { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<ManufacturerImage> ManufacturerImages { get; set; }
        public virtual DbSet<OtherChip> OtherChips { get; set; }
        public virtual DbSet<Pcb> Pcbs { get; set; }
        public virtual DbSet<PcbImage> PcbImages { get; set; }
        public virtual DbSet<PcbOtherChip> PcbOtherChips { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Nesicom;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cartridge>(entity =>
            {
                entity.Property(e => e.CartridgeId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Cartridges)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Cartridges_ManufacturerId");

                entity.HasOne(d => d.Pcb)
                    .WithMany(p => p.Cartridges)
                    .HasForeignKey(d => d.PcbId)
                    .HasConstraintName("FK_Cartridges_PcbId");
            });

            modelBuilder.Entity<CartridgeCartridgeChip>(entity =>
            {
                entity.Property(e => e.CartridgeCartridgeChipId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.CartridgeChip)
                    .WithMany(p => p.CartridgeCartridgeChips)
                    .HasForeignKey(d => d.CartridgeChipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeCartridgeChips_CartridgeChipId");

                entity.HasOne(d => d.Cartridge)
                    .WithMany(p => p.CartridgeCartridgeChips)
                    .HasForeignKey(d => d.CartridgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeCartridgeChips_CartridgeId");
            });

            modelBuilder.Entity<CartridgeChip>(entity =>
            {
                entity.Property(e => e.CartridgeChipId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.CartridgeChips)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_CartridgeChips_ManufacturerId");
            });

            modelBuilder.Entity<CartridgeImage>(entity =>
            {
                entity.Property(e => e.CartridgeImageId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Cartridge)
                    .WithMany(p => p.CartridgeImages)
                    .HasForeignKey(d => d.CartridgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeImages_CartridgeId");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.CartridgeImages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeImages_ImageId");
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.Property(e => e.DeveloperId).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_Games_DeveloperId");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_Games_PublisherId");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Games_RegionId");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.ManufacturerId).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<ManufacturerImage>(entity =>
            {
                entity.Property(e => e.ManufacturerImageId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.ManufacturerImages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManufacturerImages_ImageId");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ManufacturerImages)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManufacturerImages_ManufacturerId");
            });

            modelBuilder.Entity<OtherChip>(entity =>
            {
                entity.Property(e => e.OtherChipId).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Pcb>(entity =>
            {
                entity.Property(e => e.PcbId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Pcbs)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Pcbs_ManufacturerId");
            });

            modelBuilder.Entity<PcbImage>(entity =>
            {
                entity.Property(e => e.PcbImageId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.PcbImages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PcbImages_ImageId");

                entity.HasOne(d => d.Pcb)
                    .WithMany(p => p.PcbImages)
                    .HasForeignKey(d => d.PcbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PcbImages_PcbId");
            });

            modelBuilder.Entity<PcbOtherChip>(entity =>
            {
                entity.Property(e => e.PcbOtherChipId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.OtherChip)
                    .WithMany(p => p.PcbOtherChips)
                    .HasForeignKey(d => d.OtherChipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PcbOtherChips_OtherChipId");

                entity.HasOne(d => d.Pcb)
                    .WithMany(p => p.PcbOtherChips)
                    .HasForeignKey(d => d.PcbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PcbOtherChips_PcbId");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId).HasDefaultValueSql("(newsequentialid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
