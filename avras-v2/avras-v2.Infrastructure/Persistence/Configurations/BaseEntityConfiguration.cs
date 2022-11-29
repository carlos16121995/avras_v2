using avras_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations
{
    internal static class BaseEntityConfiguration
    {
        internal static void Configure<T>(this EntityTypeBuilder<T> builder)
            where T : BaseEntityWithoutId
        {
            builder
               .Property(e => e.UpdateDate)
               .HasDefaultValueSql("GetUtcDate()")
               .ValueGeneratedOnAdd();
        }
    }
}
