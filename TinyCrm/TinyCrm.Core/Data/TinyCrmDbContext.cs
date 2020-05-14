using System;
using Microsoft.EntityFrameworkCore;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Data
{
    public class TinyCrmDbContext : DbContext
    {
        public readonly string connectioString =
            "Server =localhost;" +
            "Database = tiny;" +
            "User Id = sa;" +
            "Password=admin./a.out test.txt";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectioString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
            modelBuilder.Entity<OrderProduct>().HasKey(op =>new { op.ProductId, op.OrderId });
        }


        public TinyCrmDbContext()
        {
        }
    }
}
