using avras_v2.Domain.Entities.Users.Addresses;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Test.Core.Seeders.Users.Addresses
{
    public class CitySeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 20;

        public async Task Run(Context context)
        {
            var ufs = await context.States.Select(s => s.UF).ToListAsync();

            foreach (var uf in ufs)
                context.Cities.AddRange(SeedCities(uf));

            await context.SaveChangesAsync();
        }

        private static IEnumerable<City> SeedCities(string uf) => new Faker<City>()
            .RuleFor(p => p.Id, (f) => f.Random.Int())
            .RuleFor((p) => p.UF, uf)
            .RuleFor((p) => p.Name, (f) => f.Address.City())
            .Generate(5);
    }
}
