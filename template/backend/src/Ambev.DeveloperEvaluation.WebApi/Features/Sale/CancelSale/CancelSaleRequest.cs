namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CancelSale;

/// <summary>
/// Request model for cancellation of a sale
/// </summary>
public class CancelSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to be cancelled
    /// </summary>
    public Guid Id { get; set; }
}
