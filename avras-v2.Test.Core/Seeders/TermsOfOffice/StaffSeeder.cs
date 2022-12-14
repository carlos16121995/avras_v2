using avras_v2.Domain.Entities.TermsOfOffice;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Test.Core.Seeders.TermsOfOffice
{
    public class StaffSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 20;

        public async Task Run(Context context)
        {
            var termOfOfficeId = await context.TermsOfOffice.Select(x => x.Id).FirstAsync();
            var titlesId = await context.Titles.Select(x => x.Id).ToListAsync();
            var usersId = await context.Users.Select(x => x.Id).Take(titlesId.Count).ToListAsync();
            var rnd = new Random();

            foreach (var titleId in titlesId)
            {
                var userId = usersId.OrderBy(item => rnd.Next()).First();
                context.Staffs.AddRange(SeedStaffs(termOfOfficeId, titleId, userId));
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Staff> SeedStaffs(Guid termOfOfficeId, Guid titleId, Guid userId) => new Faker<Staff>()
            .RuleFor((p) => p.TermOfOfficeId, termOfOfficeId)
            .RuleFor((p) => p.TitleId, titleId)
            .RuleFor((p) => p.UserId, userId)
            .RuleFor((p) => p.Description, (f) => f.Random.String2(15))
            .RuleFor((p) => p.StartedAt, DateTime.Now)
            .Generate(1);
    }
}
