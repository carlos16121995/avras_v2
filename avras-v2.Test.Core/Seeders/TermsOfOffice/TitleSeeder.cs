using avras_v2.Domain.Entities.TermsOfOffice;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.TermsOfOffice
{
    public class TitleSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.Titles.AddRange(SeedTitles());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Title> SeedTitles() => new Faker<Title>()
            .RuleFor((p) => p.Name, (f) => f.Name.FirstName())
            .RuleFor((p) => p.Description, (f) => f.Name.FullName())
            .Generate(5);
    }
}
