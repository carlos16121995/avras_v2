using avras_v2.Domain.Enuns.Users;
using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Test.Core.Seeders.Users
{
    public class AssociationTimeSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 20;

        public async Task Run(Context context)
        {
            var usersId = await context.Users.ToListAsync();

            var r = new Random();
            foreach (var userId in usersId)
            {
                if (r.Next(100) < 50)
                    userId.UpdateUserType(EUserType.ASSOCIATE);
            }

            await context.SaveChangesAsync();
        }
    }
}
