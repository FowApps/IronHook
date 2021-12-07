using IronHook.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#if !NET5_0
using Microsoft.Extensions.Hosting;
#endif
using System.Linq;

namespace IronHook.PostgreSql.Extensions
{
    /// <summary>
    /// This class includes Application Builder extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Database Migration for PostgreSql
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// </param>
        /// <returns>
        /// Application Builder interface
        /// </returns>
#if NET5_0
        public static IApplicationBuilder MigrateIronHook(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
#else
        public static IHost MigrateIronHook(this IHost app)
        {
            using var serviceScope = app.Services.CreateScope();
#endif

            var context = serviceScope.ServiceProvider.GetService<IronHookCoreDbContext>();

            var pendingMigrations = context.Database.GetPendingMigrations().ToArray();

            if (pendingMigrations.Length > 0)
            {
                context.Database.Migrate();
            }
            else
            {
                context.Database.EnsureCreated();
            }

            return app;
        }

    }
}
