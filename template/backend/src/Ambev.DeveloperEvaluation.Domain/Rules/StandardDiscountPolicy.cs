using System;

namespace Ambev.DeveloperEvaluation.Domain.Rules
{
    public class StandardDiscountPolicy : IDiscountPolicy
    {
        public decimal CalculateDiscount(int quantity, decimal unitPrice)
        {
            if (quantity < 1)
                throw new ArgumentException("Quantity must be at least 1.");

            if (quantity > 20)
                throw new ArgumentException("Cannot sell more than 20 identical items.");

            if (quantity >= 10 && quantity <= 20)
                return quantity * unitPrice * 0.20m;

            if (quantity >= 4)
                return quantity * unitPrice * 0.10m;

            return 0m;
        }
    }
}
