using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ShipperDbContext : DbContext
    {
        public ShipperDbContext(DbContextOptions<ShipperDbContext> context) : base(context)
        {
        }

        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<Shipper_Region> Shipper_Region { get; set; }
        public DbSet<Shipper_Details> Shipper_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for Shipper_Region
            modelBuilder.Entity<Shipper_Region>()
                .HasKey(sr => new { sr.Region_Id, sr.Shipper_Id });

            // Configure many-to-many relationship between Shipper and Region
            modelBuilder.Entity<Shipper_Region>()
                .HasOne(sr => sr.Region)
                .WithMany(r => r.Shipper_Regions)
                .HasForeignKey(sr => sr.Region_Id);

            modelBuilder.Entity<Shipper_Region>()
                .HasOne(sr => sr.Shipper)
                .WithMany(s => s.Shipper_Regions)
                .HasForeignKey(sr => sr.Shipper_Id);

            modelBuilder.Entity<Shipper_Details>()
                .HasOne(sd => sd.Shipper)
                .WithMany(s => s.Shipping_Details)
                .HasForeignKey(sd => sd.Shipper_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
