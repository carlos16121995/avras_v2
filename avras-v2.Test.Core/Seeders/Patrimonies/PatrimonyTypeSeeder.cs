using avras_v2.Domain.Entities.Patrimonies;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.Patrimonies
{
    public class PatrimonyTypeSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.PatrimoniesTypes.AddRange(SeedPatrimonyTypes());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<PatrimonyType> SeedPatrimonyTypes() => new Faker<PatrimonyType>()
            .RuleFor((p) => p.Name, (f) => f.Name.FirstName())
            .RuleFor((p) => p.Description, (f) => f.Name.FullName())
            .Generate(5);
    }
}
