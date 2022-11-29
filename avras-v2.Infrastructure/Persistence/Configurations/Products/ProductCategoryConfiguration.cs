using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Products
{
    using avras_v2.Domain.Entities.Products;

    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .ToTable(nameof(ProductCategory), nameof(Products));

            builder
               .Property((b) => b.Name)
               .IsRequired()
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
               .Property((b) => b.Description)
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
               .Property((b) => b.Url)
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
                .Configure();
        }
    }
}
