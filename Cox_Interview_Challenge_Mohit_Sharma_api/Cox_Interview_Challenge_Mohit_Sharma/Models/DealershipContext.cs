using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cox_Interview_Challenge_Mohit_Sharma.Models
{
    public partial class DealershipContext : DbContext
    {
        public virtual DbSet<Dealerships> Dealerships { get; set; }
        public DealershipContext(DbContextOptions<DealershipContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Dealership;Integrated Security=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");           

            modelBuilder.Entity<Dealerships>(entity =>
            {
                entity.Property(e => e.DealNumber)                    
                    .HasColumnName("dealnumber");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customername")
                    .HasColumnType("nvarchar(4000)");

                entity.Property(e => e.DealershipName)
                    .IsRequired()
                    .HasColumnName("dealershipName")
                    .HasMaxLength(100);

                entity.Property(e => e.Vehicle)
                    .IsRequired()
                    .HasColumnName("vehicle")
                    .HasMaxLength(100);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");
            });

            // OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
