using System;

using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Rules;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class ItemSale : BaseEntity
    {
        private readonly IDiscountPolicy _discountPolicy;

        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; protected set; }
        public decimal Total
        {
            get
            {
                Discount = _discountPolicy.CalculateDiscount(Quantity, UnitPrice);
                return (UnitPrice * Quantity) - Discount;
            }
        }

        public ItemSale(IDiscountPolicy discountPolicy)
        {
            _discountPolicy = discountPolicy ?? throw new ArgumentNullException(nameof(discountPolicy));
        }

        public ValidationResultDetail Validate()
        {
            var validator = new ItemSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
