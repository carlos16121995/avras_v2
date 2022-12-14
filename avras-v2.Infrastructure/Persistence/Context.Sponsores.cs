using avras_v2.Domain.Entities.Sponsores;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<Sponsor> Sponsors { get; set; } = null!;
    }
}
