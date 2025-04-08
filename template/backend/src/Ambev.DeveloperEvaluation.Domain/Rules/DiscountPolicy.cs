using System;

namespace Ambev.DeveloperEvaluation.Domain.Rules
{
    public class DiscountPolicy : IDiscountPolicy
    {
        private readonly IDiscountPolicy _policy;

        public DiscountPolicy(IDiscountPolicy policy)
        {
            _policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        public decimal CalculateDiscount(int quantity, decimal unitPrice)
        {
            return _policy.CalculateDiscount(quantity, unitPrice);
        }
    }
}
