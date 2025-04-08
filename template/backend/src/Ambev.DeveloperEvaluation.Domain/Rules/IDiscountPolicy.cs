using System;

namespace Ambev.DeveloperEvaluation.Domain.Rules
{
    public interface IDiscountPolicy
    {
        decimal CalculateDiscount(int quantity, decimal unitPrice);
    }
}
