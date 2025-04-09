using Ambev.DeveloperEvaluation.Domain.Rules;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using System;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class SaleTests
    {
        IDiscountPolicy _discountPolicy = new StandardDiscountPolicy();

        /// <summary>
        /// Tests that validation passes when all sale properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid sale data")]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale(5, _discountPolicy);

            // Act
            var result = sale.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Sale_WithNoItems_ShouldBeInvalid()
        {
            var sale = SaleTestData.GenerateValidSale(0, _discountPolicy);

            var result = sale.Validate();

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
        [Fact]
        public void Sale_WithTodayDate_ShouldBeInvalid()
        {
            var sale = SaleTestData.GenerateValidSale(3, _discountPolicy);
            sale.Date = DateTime.Today.AddDays(-1);

            var result = sale.Validate();

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Sale_WithoutCustomerID_ShouldBeInvalid(string customer)
        {
            var sale = SaleTestData.GenerateValidSale(3, _discountPolicy);
            sale.CustomerID = customer;

            var result = sale.Validate();

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
        [Fact]
        public void Item_WithQuantityAboveLimit_ShouldBeInvalid()
        {
            var item = SaleTestData.GenerateValidItem(_discountPolicy);
            item.Quantity = 21;

            var result = item.Validate();

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void Item_WithZeroUnitPrice_ShouldBeInvalid()
        {
            var item = SaleTestData.GenerateValidItem(_discountPolicy);
            item.UnitPrice = 0;

            var result = item.Validate();

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
