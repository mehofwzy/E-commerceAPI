using EC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EC_API.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasDefaultValue("Pending");


            // Seed initial product data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop OEMN", Description = "OMEN Gaming Laptop I9", Price = 1200.99, Stock = 10 },
                new Product { Id = 2, Name = "Laptop HP", Description = "HP Gaming Laptop I7", Price = 999.99, Stock = 9 },
                new Product { Id = 3, Name = "Laptop DELL", Description = "DELL Gaming Laptop I5", Price = 899.99, Stock = 13 },
                new Product { Id = 4, Name = "Laptop APPLE", Description = "APPLE Gaming Laptop MAC-AIR", Price = 1599.99, Stock = 12 },
                new Product { Id = 5, Name = "Laptop ASUS", Description = "ASUS Gaming Laptop I9", Price = 1300.99, Stock = 11 },
                new Product { Id = 6, Name = "Smartphone APPLE I14", Description = "Smartphone Model I14", Price = 899.50, Stock = 25 },
                new Product { Id = 7, Name = "Smartphone APPLE I15", Description = "Smartphone Model I15", Price = 899.50, Stock = 35 },
                new Product { Id = 8, Name = "Smartphone APPLE I16", Description = "Smartphone Model I16", Price = 899.50, Stock = 40 },
                new Product { Id = 9, Name = "Smartphone OPPO", Description = "Smartphone Model OPPO3", Price = 899.50, Stock = 51 },
                new Product { Id = 10, Name = "Smartphone SAMSUNG S23", Description = "Smartphone Model S23", Price = 899.50, Stock = 20 },
                new Product { Id = 11, Name = "Smartphone SAMSUNG S24", Description = "Smartphone Model S24", Price = 899.50, Stock = 17 },
                new Product { Id = 12, Name = "Smartphone SAMSUNG S25", Description = "Smartphone Model S25", Price = 899.50, Stock = 15 },
                new Product { Id = 13, Name = "Headphone APPLE", Description = "Noise Cancelling Headphone Model APPLE", Price = 199.99, Stock = 55 },
                new Product { Id = 14, Name = "Headphone OPPO", Description = "Noise Cancelling Headphone Model OPPO", Price = 199.99, Stock = 45 },
                new Product { Id = 15, Name = "Headphone SAMSUNG", Description = "Headphone Model SAMSUNG", Price = 199.99, Stock = 30 }
            );
        }
    }
}
