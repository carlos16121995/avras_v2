using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace avras_v2.Test.Core.Extensions
{
    public static class TestServiceRegistration
    {

        public static void RegisterDatabase<T>(this IServiceCollection services)
            where T : DbContext
        {
            services.AddDbContext<T>((provider, optionsBuilder) =>
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseInMemoryDatabase(typeof(T).Name);
                    optionsBuilder.UseLazyLoadingProxies();
                }
            });

            services.AddEntityFrameworkInMemoryDatabase().AddEntityFrameworkProxies();
        }
    }
}
