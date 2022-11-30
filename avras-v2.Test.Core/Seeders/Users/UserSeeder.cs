using avras_v2.Domain.Entities.Users;
using avras_v2.Domain.Enuns.Users;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;
using Bogus.Extensions.Brazil;

namespace avras_v2.Test.Core.Seeders.Users
{
    public class UserSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public async Task Run(Context context)
        {
            context.Users.AddRange(SeedUsers());

            await context.SaveChangesAsync();
        }

        public static IEnumerable<ApplicationUser> SeedUsers() => new Faker<ApplicationUser>()
            .RuleFor((p) => p.CPF, (f) => f.Person.Cpf())
            .RuleFor((p) => p.UserName, (f) => f.Person.FirstName)
            .RuleFor((p) => p.Email, (f) => f.Person.Email)
            .RuleFor((p) => p.PhoneNumber, (f) => f.Person.Phone)
            .RuleFor((p) => p.BirthDate, (f) => DateTime.Now.AddYears(f.Random.Int(-18, -70)))
            .RuleFor((p) => p.UserType, f => f.Random.Enum<EUserType>())
            .RuleFor((p) => p.UpdateAt, (f) => DateTime.UtcNow)
            .RuleFor((p) => p.CreatedAt, (f) => DateTime.UtcNow)
            .RuleFor((p) => p.PasswordHash, (f) => f.Random.String2(60))
            .RuleFor((p) => p.SecurityStamp, (f) => f.Random.String2(60))
            .Generate(15);
    }
}
