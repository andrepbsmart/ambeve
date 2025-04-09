using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string CustomerID { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string BranchID { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public bool IsCancelled { get; protected set; } = false;
    public DateTime? CancelledAt { get; protected set; }
}
