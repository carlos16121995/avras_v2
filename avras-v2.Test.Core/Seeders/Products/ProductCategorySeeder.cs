using avras_v2.Domain.Entities.Products;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.Products
{
    public class ProductCategorySeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.ProductsCategories.AddRange(SeedProductCategories());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<ProductCategory> SeedProductCategories() => new Faker<ProductCategory>()
            .RuleFor((p) => p.Name, (f) => f.Name.FirstName())
            .RuleFor((p) => p.Description, (f) => f.Name.FullName())
            .Generate(5);
    }
}
