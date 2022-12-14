using avras_v2.Domain.Entities.Patrimonies;
using avras_v2.Domain.Entities.Products;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avras_v2.Test.Core.Seeders.Patrimonies
{
    public class ConcessionSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            var categoryIds = await context.ProductsCategories.Select(p => p.Id).ToListAsync();
            var r = new Random();
            context.Products.AddRange(SeedProducts(r, categoryIds));

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Concession> SeedProducts(Random r, IList<int> ids) => new Faker<Concession>()
            .RuleFor((p) => p.Name, (f) => f.Person.FirstName)
            .RuleFor((p) => p.ProductCategoryId, ids.OrderBy(item => r.Next()).First())
            .RuleFor((p) => p.SaleValue, (f) => f.Random.Decimal())
            .RuleFor((p) => p.Amount, (f) => f.Random.Int(50, 100))
            .RuleFor((p) => p.MinAmount, (f) => f.Random.Decimal(10, 30))
            .Generate(3);
    }
}
