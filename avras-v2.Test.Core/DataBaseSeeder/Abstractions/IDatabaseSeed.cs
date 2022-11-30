using Microsoft.EntityFrameworkCore;

namespace avras_v2.Test.Core.DataBaseSeeder.Abstractions
{
    public interface IDatabaseSeed<TContext> where TContext : DbContext
    {
        int Ordem { get; }
        Task Run(TContext context);
    }
}
