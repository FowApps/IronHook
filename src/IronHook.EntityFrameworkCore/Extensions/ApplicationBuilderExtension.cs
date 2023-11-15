using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace IronHook.EntityFrameworkCore.Extensions
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
        public static IHost MigrateIronHook(this IHost app)
        {
            using var serviceScope = app.Services.CreateScope();

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
