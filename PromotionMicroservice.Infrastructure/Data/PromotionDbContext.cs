using Microsoft.EntityFrameworkCore;
using PromotionMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.Infrastructure.Data
{
    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions<PromotionDbContext> options) : base(options) { }

        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Promotion_Details> Promotion_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion_Details>(entity =>
            {
                entity.HasOne(e => e.Promotion)
                      .WithMany(p => p.Promotion_Details)
                      .HasForeignKey(e => e.Promotion_Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
