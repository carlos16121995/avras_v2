using avras_v2.Domain.Entities.Sales;

namespace avras_v2.Domain.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal SaleValue { get; set; }
        public int Amount { get; set; }
        public int MinAmount { get; set; }

        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ICollection<SaleItems>? SaleItems { get; set; } = new HashSet<SaleItems>();
        public virtual ICollection<ProductBuy>? ProductsBuy { get; set; } = new HashSet<ProductBuy>();
    }
}
