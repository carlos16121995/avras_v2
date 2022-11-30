using avras_v2.Domain.Entities.Patrimonies;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<Concession> Concessions { get; set; } = null!;
        public virtual DbSet<Patrimony> Patrimonies { get; set; } = null!;
        public virtual DbSet<PatrimonyType> PatrimoniesTypes { get; set; } = null!;
    }
}
