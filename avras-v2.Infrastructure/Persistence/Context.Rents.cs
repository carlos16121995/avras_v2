using avras_v2.Domain.Entities.Rents;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<Rent> Rents { get; set; } = null!;
        public virtual DbSet<RentType> RentsTypes { get; set; } = null!;
    }
}
