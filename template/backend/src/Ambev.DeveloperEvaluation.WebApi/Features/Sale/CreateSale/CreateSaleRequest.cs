using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateSaleRequest
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string BranchID { get; set; }
    public string BranchName { get; set; }
    public List<CreateItemSaleRequest> Items { get; set; } = new();
}