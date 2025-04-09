namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateItemSaleCommand
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
