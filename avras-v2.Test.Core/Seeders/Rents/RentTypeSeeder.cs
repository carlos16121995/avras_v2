using avras_v2.Domain.Entities.Rents;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.Rents
{
    public class RentTypeSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.RentsTypes.AddRange(SeedRentTypes());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<RentType> SeedRentTypes() => new Faker<RentType>()
            .RuleFor((p) => p.Name, (f) => f.Name.FirstName())
            .RuleFor((p) => p.Price, (f) => f.Random.Decimal())
            .Generate(5);
    }
}
