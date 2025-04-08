using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Initializes a new instance of the CreateUserCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Email: Must be in valid format (using EmailValidator)
        /// - Username: Required, must be between 3 and 50 characters
        /// - Password: Must meet security requirements (using PasswordValidator)
        /// - Phone: Must match international format (+X XXXXXXXXXX)
        /// - Status: Cannot be set to Unknown
        /// - Role: Cannot be set to None
        /// </remarks>
        
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; } 
        public string CustomerID { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        //public decimal TotalAmount => _items.Sum(i => i.Total);
        public string BranchID { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
    }
}
