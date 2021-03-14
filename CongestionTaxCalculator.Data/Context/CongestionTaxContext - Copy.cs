//using CongestionTaxCalculator.Data.Models;
//using Microsoft.EntityFrameworkCore;

//#nullable disable

//namespace CongestionTaxCalculator.Data.Context
//{
//    public partial class CongestionTaxContext : DbContext
//    {
//        public CongestionTaxContext()
//        {
//        }

//        public CongestionTaxContext(DbContextOptions<CongestionTaxContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Passage> Passages { get; set; }
//public virtual DbSet<TaxFreeDay> TaxFreeDays { get; set; }
//public virtual DbSet<TaxFreePeriod> TaxFreePeriods { get; set; }
//        public virtual DbSet<Tariff> Tariffs { get; set; }
//        public virtual DbSet<Vehicle> Vehicles { get; set; }
//        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
//        public virtual DbSet<Zone> Zones { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder
//                    .UseLazyLoadingProxies()
//                    .UseSqlServer("Server=.\\SQLExpress;Database=CongestionTax;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

//            modelBuilder.Entity<Passage>(entity =>
//            {
//                entity.ToTable("Passage");

//                entity.HasOne(d => d.Vehicle)
//                    .WithMany(p => p.Passages)
//                    .HasForeignKey(d => d.VehicleId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Passage_Vehicle");

//                entity.HasOne(d => d.Zone)
//                    .WithMany(p => p.Passages)
//                    .HasForeignKey(d => d.ZoneId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Passage_Zone");
//            });

//            modelBuilder.Entity<Tariff>(entity =>
//            {
//                entity.ToTable("Tariff");

//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.HasOne(d => d.Zone)
//                    .WithMany(p => p.Tariffs)
//                    .HasForeignKey(d => d.ZoneId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Tariff_Zone");
//            });

//            modelBuilder.Entity<Vehicle>(entity =>
//            {
//                entity.ToTable("Vehicle");

//                entity.Property(e => e.RegNumber)
//                    .IsRequired()
//                    .HasMaxLength(10)
//                    .IsFixedLength(true);

//                entity.HasOne(d => d.VehicleType)
//                    .WithMany(p => p.Vehicles)
//                    .HasForeignKey(d => d.VehicleType)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Vehicle_VehicleType");
//            });

//            modelBuilder.Entity<VehicleType>(entity =>
//            {
//                entity.ToTable("VehicleType");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(100);

//                entity.HasOne(d => d.Zone)
//                    .WithMany(p => p.VehicleTypes)
//                    .HasForeignKey(d => d.ZoneId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_VehicleType_Zone");
//            });

//            modelBuilder.Entity<Zone>(entity =>
//            {
//                entity.ToTable("Zone");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(100);
//            });

//            modelBuilder.Entity<TaxFreeDay>(entity =>
//            {
//                entity.ToTable("TaxFreeDay");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(100);
//            });

//            modelBuilder.Entity<TaxFreePeriod>(entity =>
//            {
//                entity.ToTable("TaxFreePeriod");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(100);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
