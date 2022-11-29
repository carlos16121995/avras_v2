using avras_v2.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleItems> SaleItems { get; set; } = null!;
    }
}
