using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> context) : base(context)
        {
        }

        public DbSet<OrderMicroservice.ApplicationCore.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Order - OrderDetail (一对多)
            modelBuilder.Entity<OrderMicroservice.ApplicationCore.Entities.Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            // Customer - Address (多对多)
            modelBuilder.Entity<UserAddress>()
                .HasKey(ua => ua.Id);
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Customer)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(ua => ua.CustomerId);
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.AddressId);

            // ShoppingCart - ShoppingCartItem (一对多)
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.ShoppingCartItems)
                .WithOne(sci => sci.ShoppingCart)
                .HasForeignKey(sci => sci.CartId);

            // PaymentMethod - PaymentType (多对一)
            modelBuilder.Entity<PaymentMethod>()
                .HasOne(pm => pm.PaymentType)
                .WithMany(pt => pt.PaymentMethods)
                .HasForeignKey(pm => pm.PaymentTypeId);
        }
    }
}
