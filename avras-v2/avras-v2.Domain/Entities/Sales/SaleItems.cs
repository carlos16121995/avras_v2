using avras_v2.Domain.Entities.Products;

namespace avras_v2.Domain.Entities.Sales
{
    public class SaleItems
    {
        public int ProductId { get; set; }
        public Guid SaleId { get; set; }
        public decimal SaleValue { get; set; }
        public int Amount { get; set; }

        public virtual Product? Product { get; set; } 
        public virtual Sale? Sale { get; set; } 
    }
}
