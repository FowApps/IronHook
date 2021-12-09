using IronHook.Core.Abstractions;
using IronHook.Core.Concrete;
using IronHook.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
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
            services.AddDbContext<IronHookCoreDbContext>(options, ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<IIronHookContext>(sp => sp.GetService<IronHookCoreDbContext>());
            services.AddTransient<IHookService, DefaultHookService>();
            services.AddTransient<IHookOperator, HttpHookOperator>();
            return services;
        }
    }
}
