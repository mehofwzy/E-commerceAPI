using ECommerceAPI.Tests.TestUtilities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using EC_API.Controllers;
using EC_API.Data;
using EC_API.Models;
using EC_API.Validators;

namespace ECommerceAPI.Tests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly CustomersController _controller;
        private readonly ECommerceDbContext _context;

        public CustomersControllerTests()
        {
            _context = TestDbContext.GetDbContext();
            var validator = new CustomerValidator();
            _controller = new CustomersController(_context, validator);
        }

        [Fact]
        public async Task GetCustomers_ReturnsListOfCustomers()
        {
            var result = await _controller.GetCustomers() as OkObjectResult;
            var customers = result.Value as List<Customer>;

            Assert.NotNull(customers);
            Assert.Single(customers);
        }

        [Fact]
        public async Task GetCustomer_ReturnsCustomer_WhenValidId()
        {
            var result = await _controller.GetCustomer(1) as OkObjectResult;
            var customer = result.Value as Customer;

            Assert.NotNull(customer);
            Assert.Equal("Test Customer", customer.Name);
        }

        [Fact]
        public async Task GetCustomer_ReturnsNotFound_WhenInvalidId()
        {
            var result = await _controller.GetCustomer(99);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task CreateCustomer_ReturnsCreatedResponse_WhenValidData()
        {
            var newCustomer = new Customer { Name = "Test Customer", Email = "test@test.com", Phone = "9876543210" };

            var result = await _controller.CreateCustomer(newCustomer) as CreatedAtActionResult;
            var customer = result.Value as Customer;

            Assert.NotNull(customer);
            Assert.Equal("Test Customer", customer.Name);
        }
    }
}
