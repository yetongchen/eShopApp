using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> context) : base(context)
        {
        }
        public DbSet<Product_Category> Product_Category { get; set; }
        public DbSet<Category_Variation> Category_Variation { get; set; }
        public DbSet<Variation_Value> Variation_Value { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Product_Variation_Values> Product_Variation_Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key for Product_Variation_Values
            modelBuilder.Entity<Product_Variation_Values>()
                .HasKey(pv => new { pv.Product_Id, pv.Variation_Value_Id });

            // Define relationships
            modelBuilder.Entity<Product_Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.Parent_Category_Id);

            modelBuilder.Entity<Product_Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category_Variation>()
                .HasOne(cv => cv.Category)
                .WithMany(c => c.Category_Variations)
                .HasForeignKey(cv => cv.Category_Id);

            modelBuilder.Entity<Variation_Value>()
                .HasOne(vv => vv.Variation)
                .WithMany(cv => cv.Variation_Values)
                .HasForeignKey(vv => vv.Variation_Id);

            modelBuilder.Entity<Product_Variation_Values>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.Product_Variation_Values)
                .HasForeignKey(pv => pv.Product_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product_Variation_Values>()
                .HasOne(pv => pv.Variation_Value)
                .WithMany(vv => vv.Product_Variation_Values)
                .HasForeignKey(pv => pv.Variation_Value_Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
