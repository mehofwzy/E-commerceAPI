using EC_API.Data;
using EC_API.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        private readonly IValidator<Order> _validator;

        public OrdersController(ECommerceDbContext context, IValidator<Order> validator)
        {
            _context = context;
            _validator = validator;
        }

        // POST: api/orders (Create an Order)
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var validationResult = await _validator.ValidateAsync(order);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            // Calculate total price
            double totalPrice = 0;
            foreach (var productId in order.Products)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null || product.Stock <= 0)
                    return BadRequest(new { message = $"Product ID {productId} is not available" });

                totalPrice += product.Price;
            }

            order.TotalPrice = totalPrice;
            order.OrderDate = DateTime.UtcNow;
            order.Status = "Pending";

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // GET: api/orders/{id} (Retrieve Order by ID)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(new
            {
                OrderId = order.Id,
                CustomerName = order.Customer?.Name,
                OrderStatus = order.Status,
                NumberOfProducts = order.Products.Count,
                TotalPrice = order.TotalPrice
            });
        }

        // POST: api/UpdateOrderStatus/{id} (Update Order Status)
        [HttpPost("UpdateOrderStatus/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            if (order.Status == "Delivered")
                return BadRequest(new { message = "Order is already delivered" });

            // Update Order Status
            order.Status = "Delivered";

            // Reduce stock of ordered products
            foreach (var productId in order.Products)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product != null && product.Stock > 0)
                {
                    product.Stock -= 1;
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Order status updated to Delivered" });
        }
    }
}
