using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: 
    /// - CustomerID: 
    /// - CustomerName: 
    /// - BranchID: 
    /// - BranchName: 
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.SaleNumber).GreaterThan(0);
        RuleFor(sale => sale.CustomerID).NotEmpty();
        RuleFor(sale => sale.CustomerName).NotEmpty();
        RuleFor(sale => sale.BranchID).NotEmpty();
        RuleFor(sale => sale.BranchName).NotEmpty();
        RuleFor(x => x.Items).NotEmpty().WithMessage("At least one item must be provided.");
        RuleForEach(x => x.Items).SetValidator(new CreateItemSaleCommandValidator());
    }
}