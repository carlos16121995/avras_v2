using avras_v2.Domain.Entities.Financials;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.Financials
{
    public class FundSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.Funds.AddRange(SeedFunds());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Fund> SeedFunds() => new Faker<Fund>()
            .RuleFor((p) => p.Amount, (f) => f.Random.Decimal())
            .Generate(1);
    }
}
