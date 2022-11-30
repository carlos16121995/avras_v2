﻿using avras_v2.Test.Core.DataBaseSeeder.Abstractions;
using Bogus;
using CRUD.Domain.Entities.Localities;
using CRUD.Infrastructure.Persistence;

namespace avras_v2.Test.Core.Seeders.Localities
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
