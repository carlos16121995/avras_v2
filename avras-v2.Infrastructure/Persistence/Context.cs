using avras_v2.Domain.Entities.Financials;
using avras_v2.Domain.Entities.Users;
using avras_v2.Infrastructure.Persistence.Configurations.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfiguration).Assembly,
                    (type) => (type.Namespace ?? "").Contains("Configurations"));
        }
    }
}
