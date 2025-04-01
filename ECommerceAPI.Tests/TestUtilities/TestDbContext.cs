using EC_API.Data;
using EC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Tests.TestUtilities
{
    public static class TestDbContext
    {
        public static ECommerceDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ECommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "ECommerceTestDb")
                .Options;

            var dbContext = new ECommerceDbContext(options);

            dbContext.Customers.Add(new Customer { Id = 1, Name = "Test Customer", Email = "Test@test.com", Phone = "1234567890" });
            dbContext.Products.Add(new Product { Id = 1, Name = "Test Product", Description = "Test Product", Price = 10.99, Stock = 5 });

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
