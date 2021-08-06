using IronHook.Core.Abstractions;
using IronHook.Core.Concrete;
using IronHook.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.PostgreSql.Extensions
{
    /// <summary>
    /// This class includes IServiceCollection extensions
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Initialize Iron Hook
        /// </summary>
        /// <param name="services">
        /// IServiceCollection
        /// </param>
        /// <param name="options">
        /// Action of DbContextOptionsBuilder
        /// </param>
        /// <returns>
        /// IServiceCollection
        /// </returns>
        public static IServiceCollection AddIronHook(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<IronHookPostgreSqlDbContext>(options, ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<IIronHookContext>(sp => sp.GetService<IronHookPostgreSqlDbContext>());
            services.AddTransient<IHookService<IronHookPostgreSqlDbContext>, DefaultHookService<IronHookPostgreSqlDbContext>>();
            services.AddTransient<IHookOperator, HttpHookOperator>();
            return services;
        }
    }
}
