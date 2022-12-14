using avras_v2.Domain.Entities.TermsOfOffice;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;

namespace avras_v2.Test.Core.Seeders.TermsOfOffice
{
    public class TermOfOfficeSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.TermsOfOffice.AddRange(SeedTermsOfOffice());

            await context.SaveChangesAsync();
        }

        private static IEnumerable<TermOfOffice> SeedTermsOfOffice() => new Faker<TermOfOffice>()
            .RuleFor((p) => p.Name, (f) => f.Name.FirstName())
            .RuleFor((p) => p.Summary, (f) => f.Random.String2(30))
            .RuleFor((p) => p.UrlImage, (f) => f.Person.Avatar)
            .RuleFor((p) => p.StartAt, DateTime.Now)
            .RuleFor((p) => p.EndAt, DateTime.Now)
            .Generate(1);
    }
}
