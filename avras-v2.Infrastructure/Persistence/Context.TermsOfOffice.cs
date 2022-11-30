using avras_v2.Domain.Entities.TermsOfOffice;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<TermOfOffice> TermsOfOffice { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;
    }
}
