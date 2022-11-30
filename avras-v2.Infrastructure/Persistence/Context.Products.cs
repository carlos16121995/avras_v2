using avras_v2.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductPurchase> ProductsPurchases { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductsCategories { get; set; } = null!;
    }
}
