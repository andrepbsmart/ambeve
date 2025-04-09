using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale
{
    public class CreateItemSaleRequestValidator : AbstractValidator<CreateItemSaleRequest>
    {
        public CreateItemSaleRequestValidator()
        {
            RuleFor(item => item.ProductID).NotEmpty();
            RuleFor(item => item.ProductName).NotEmpty();
            RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20).WithMessage("Quantity must be between 1 and 20.");
            RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        }        
    }
}
