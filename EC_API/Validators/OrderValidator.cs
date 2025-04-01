using EC_API.Models;
using FluentValidation;

namespace EC_API.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID is required");

            RuleFor(o => o.Products)
                .NotEmpty().WithMessage("At least one product is required.");
        }
    }
}
