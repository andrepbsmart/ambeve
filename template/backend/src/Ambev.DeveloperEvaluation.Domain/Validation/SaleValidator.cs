using FluentValidation;

using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .GreaterThan(0)
            .WithMessage("The sale number must be greater than zero.");

        RuleFor(sale => sale.CustomerID)
            .NotEmpty()
            .NotNull()
            .WithMessage("Customer ID cannot be empty");

        RuleFor(sale => sale.CustomerName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Customer name cannot be empty.");

        RuleFor(sale => sale.Date)
            .Must(date => date.Date == DateTime.Today)
            .WithMessage("The sale date cannot be different from today.");

        RuleFor(sale => sale.BranchID)
            .NotEmpty()
            .NotNull()
            .WithMessage("Branch ID cannot be empty");

        RuleFor(sale => sale.BranchName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Branch name cannot be empty.");

        RuleFor(sale => sale.Items)
           .NotEmpty()
           .WithMessage("The sale must contain at least one item.");

        RuleFor(sale => sale.TotalAmount)
    .       GreaterThan(0)
            .WithMessage("The total amount must be greater than zero.");

        RuleForEach(sale => sale.Items)
            .SetValidator(new ItemSaleValidator());
    }
}
