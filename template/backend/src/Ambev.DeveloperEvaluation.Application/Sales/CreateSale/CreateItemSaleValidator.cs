using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateItemSaleCommand that defines validation rules for itemsale creation command.
/// </summary>
public class CreateItemSaleCommandValidator : AbstractValidator<CreateItemSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateItemSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductID: 
    /// - ProductName: 
    /// - Quantity: 
    /// - UnitPrice: 
    /// </remarks>
    public CreateItemSaleCommandValidator()
    {
        RuleFor(item => item.ProductID).NotEmpty();
        RuleFor(item => item.ProductName).NotEmpty();
        RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20).WithMessage("Quantity must be between 1 and 20.");
        RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
    }
}