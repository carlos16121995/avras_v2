// Copyright (c) 2022, Vendi Porque Cresci™. All rights reserved.
// Copyright (c) 2022, Marttech Desenvolvimento de Software. All rights reserved.
// PRIVATE SOURCE. Any kind of unauthorized use is prohibited.

using avras_v2.Infrastructure.Persistence;
using avras_v2.Test.Core.DataBaseSeeder;
using avras_v2.Test.Core.Seeders.Users.Addresses;

namespace avras_v2.Test.Core.Extensions
{
    public static class DatabaseSeederRegistration
    {
        public static void SeedInMemoryDatabase(this IServiceProvider provider)
            => provider.InitializeDatabase<Context, StateSeeder>();
    }
}
