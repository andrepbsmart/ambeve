using System;
using Bogus;

using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Rules;


namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public class SaleTestData
    {
        /// <summary>
        /// Expected Parameters
        /// - Quantity (quantity of items that will be generated for sale)
        /// - Discount Policy (discount policy that will be applied to the item - Name of the available rule StandardDiscountPolicy)
        /// 
        /// Configures the Faker to generate valid Sale entities.
        /// The generated sales will have valid:
        /// - SaleNumber (random number between 1 and 9999)
        /// - Date (today)
        /// - CustomerID (random guide)
        /// - CustomerName (using name.fullname)
        /// - TotalAmount (automatic sum of the total of items, including discounts)
        /// - BranchID (random guide)
        /// - BranchName (using company.companyname)
        /// </summary>      

        private static List<ItemSale> GenerateItemSales(int quantity, IDiscountPolicy _discountPolicy)
        {
            var faker = new Faker();

            var itemFaker = new Faker<ItemSale>()
                .CustomInstantiator(f => new ItemSale(_discountPolicy))
                .RuleFor(i => i.ProductID, f => f.Random.Guid())
                .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
                .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10m, 200m));

            var items = new List<ItemSale>();

            for (int i = 0; i < quantity; i++)
            {
                var item = itemFaker.Generate();
                items.Add(item);
            }

            return items;
        }

        public static Sale GenerateValidSale(int itemCount, IDiscountPolicy discountPolicy)
        {
            return new Faker<Sale>()
                .RuleFor(s => s.SaleNumber, f => f.Random.Int(1, 9999))
                .RuleFor(s => s.Date, f => DateTime.Today)
                .RuleFor(s => s.CustomerID, f => f.Random.Guid().ToString())
                .RuleFor(s => s.CustomerName, f => f.Name.FullName())
                .RuleFor(s => s.BranchID, f => f.Random.Guid().ToString())
                .RuleFor(s => s.BranchName, f => f.Company.CompanyName())
                .FinishWith((f, s) =>
                {
                    var items = GenerateItemSales(itemCount, discountPolicy);
                    foreach (var item in items)
                        s.AddItem(item);
                });
        }
        public static ItemSale GenerateValidItem(IDiscountPolicy discountPolicy)
        {
            return new Faker<ItemSale>()
                .CustomInstantiator(f => new ItemSale(discountPolicy))
                .RuleFor(i => i.ProductID, f => f.Random.Guid())
                .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
                .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10m, 200m));
        }
    }
}
