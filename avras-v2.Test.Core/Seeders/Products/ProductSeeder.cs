using avras_v2.Domain.Entities.Products;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Test.Core.Seeders.Products
{
    public class ProductSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            var categoryIds = await context.ProductsCategories.Select(p => p.Id).ToListAsync();
            var r = new Random();
            context.Products.AddRange(SeedProducts(r, categoryIds));

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Product> SeedProducts(Random r, IList<int> ids) => new Faker<Product>()
            .RuleFor((p) => p.Name, (f) => f.Person.FirstName)
            .RuleFor((p) => p.ProductCategoryId, ids.OrderBy(item => r.Next()).First())
            .RuleFor((p) => p.SaleValue, (f) => f.Random.Decimal())
            .RuleFor((p) => p.Amount, (f) => f.Random.Int(50, 100))
            .RuleFor((p) => p.MinAmount, (f) => f.Random.Decimal(10, 30))
            .Generate(3);
    }
}
