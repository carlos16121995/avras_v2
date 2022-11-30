using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace avras_v2.Test.Test
{
    using avras_v2.Application;
    using avras_v2.Infrastructure.Persistence;
    using avras_v2.Test.Core.DataBaseSeeder;
    using avras_v2.Test.Core.Extensions;
    using avras_v2.Test.Core.Seeders.Localities;

    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilder)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            services.RegisterDatabase<Context>();

            services.AddApplicationServices(hostBuilder.Configuration);
            IServiceProvider provider = services
                                            .BuildServiceProvider();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            provider.InitializeDatabase<Context, StateSeeder>();

            services.AddHttpContextAccessor()
                        .TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
