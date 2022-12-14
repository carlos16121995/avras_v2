using avras_v2.Domain.Entities.Users.Addresses;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.Users.Addresses
{
    public class StateSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.States.AddRange(SeedStates());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<State> SeedStates() => new Faker<State>()
            .RuleFor((p) => p.UF, (f) => f.Address.StateAbbr())
            .RuleFor((p) => p.Name, (f) => f.Address.State())
            .Generate(3);
    }
}
