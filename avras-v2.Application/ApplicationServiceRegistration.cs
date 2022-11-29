using avras_v2.Application.Class;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace avras_v2.Application
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor().TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation((fv) =>
            {
                fv.DisableDataAnnotationsValidation = true;
            }).AddValidatorsFromAssemblyContaining<ClassCommandValidator>(lifetime: ServiceLifetime.Transient);

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterEF<T>(this IServiceCollection services, IConfiguration configuration, string schema = "dbo") where T : DbContext
        {
            IConfiguration configuration2 = configuration;
            string schema2 = schema;
            return services.AddDbContextPool<T>(delegate (IServiceProvider servicesProvider, DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(configuration2.GetConnectionString(typeof(T).Name), delegate (SqlServerDbContextOptionsBuilder option)
                {
                    option.MigrationsHistoryTable("__EFMigrationsHistory", schema2);
                    option.EnableRetryOnFailure();
                    option.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            }, 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="servicesProvider"></param>
        /// <param name="minutesTimeout"></param>
        /// <returns></returns>
        public static async Task MigrateDatabaseAsync<T>(this IServiceProvider servicesProvider, int minutesTimeout = 5) where T : DbContext
        {
            using IServiceScope scope = servicesProvider.CreateScope();
            T requiredService = scope.ServiceProvider.GetRequiredService<T>();
            requiredService.Database.SetCommandTimeout((int)TimeSpan.FromMinutes(minutesTimeout).TotalMilliseconds);
            await requiredService.Database.MigrateAsync();
        }
    }
}
