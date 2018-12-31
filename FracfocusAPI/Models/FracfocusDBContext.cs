using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace FracfocusAPI.Models
{
    public partial class FracfocusDBContext : DbContext
    {
        public FracfocusDBContext()
        {
        }

        public FracfocusDBContext(DbContextOptions<FracfocusDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fracfocus> Fracfocus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=tcp:toannazuredb.database.windows.net,1433;Initial Catalog=FracfocusDB;Persist Security Info=False;User ID=toanngkh;Password=Kh4nht04n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fracfocus>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apinumber)
                    .IsRequired()
                    .HasColumnName("APINumber")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Casnumber)
                    .IsRequired()
                    .HasColumnName("CASNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountyNumber)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientComment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientMsds).HasColumnName("IngredientMSDS");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JobEndDate).HasColumnType("datetime");

                entity.Property(e => e.JobStartDate).HasColumnType("datetime");

                entity.Property(e => e.OperatorName)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.PercentHfjob).HasColumnName("PercentHFJob");

                entity.Property(e => e.Projection)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Purpose)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateNumber)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TradeName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Tvd).HasColumnName("TVD");

                entity.Property(e => e.WellName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
