using System;

using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        private readonly List<ItemSale> _items = new();

        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string CustomerID { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount => _items.Sum(i => i.Total);
        public string BranchID { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public bool IsCancelled { get; protected set; } = false;
        public DateTime? CancelledAt { get; protected set; }

        public IReadOnlyCollection<ItemSale> Items => _items.AsReadOnly();

        public void AddItem(ItemSale item)
        {
            item.SetSale(this);
            _items.Add(item);
        }

        public void Cancel()
        {
            IsCancelled = true;
            CancelledAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
