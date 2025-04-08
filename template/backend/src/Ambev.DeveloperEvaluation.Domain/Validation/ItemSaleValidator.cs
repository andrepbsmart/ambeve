using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ItemSaleValidator : AbstractValidator<ItemSale>
{
    public ItemSaleValidator()
    {

        RuleFor(item => item.ProductID)
            .NotEmpty()
            .WithMessage("Product ID cannot be empty");

        RuleFor(item => item.ProductName)
            .NotEmpty()
            .WithMessage("Product name cannot be empty.");

        RuleFor(item => item.Quantity)
    .       GreaterThan(0)
            .WithMessage("The Quantity must be greater than zero.")
            .LessThanOrEqualTo(20)
           .WithMessage("You cannot sell more than 20 identical items.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0)
            .WithMessage("The Unit Price must be greater than zero.");

        RuleFor(i => i.Discount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Discount cannot be negative.")
            .Must((item, discount) =>
            {
                var maxAllowedDiscount = item.Quantity * item.UnitPrice;
                return discount <= maxAllowedDiscount;
            })
            .WithMessage("Discount cannot be greater than the item total.");
    }
}
