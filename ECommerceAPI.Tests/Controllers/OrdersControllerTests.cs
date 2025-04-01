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
    public class OrdersControllerTests
    {
        private readonly OrdersController _controller;
        private readonly ECommerceDbContext _context;

        public OrdersControllerTests()
        {
            _context = TestDbContext.GetDbContext();
            var validator = new OrderValidator();
            _controller = new OrdersController(_context, validator);
        }

        [Fact]
        public async Task CreateOrder_ReturnsCreatedResponse_WhenValidData()
        {
            var newOrder = new Order { CustomerId = 1, Products = new List<int> { 1 } };

            var result = await _controller.CreateOrder(newOrder) as CreatedAtActionResult;
            var order = result.Value as Order;

            Assert.NotNull(order);
            Assert.Equal(1, order.CustomerId);
            Assert.Equal("Pending", order.Status);
        }

        [Fact]
        public async Task GetOrder_ReturnsOrder_WhenValidId()
        {
            var newOrder = new Order { CustomerId = 1, Products = new List<int> { 1 } };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            var result = await _controller.GetOrder(newOrder.Id) as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateOrderStatus_ReturnsSuccessMessage_WhenValidOrder()
        {
            var newOrder = new Order { CustomerId = 1, Products = new List<int> { 1 }, Status = "Pending" };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            var result = await _controller.UpdateOrderStatus(newOrder.Id) as OkObjectResult;
            Assert.NotNull(result);
        }
    }
}
