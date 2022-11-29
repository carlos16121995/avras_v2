using avras_v2.Domain.Entities.Users;
using avras_v2.Domain.Entities.Users.Addresses;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        #region Address
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        #endregion

        public virtual DbSet<AssociationTime> AssociationsTimes { get; set; } = null!;
    }
}
