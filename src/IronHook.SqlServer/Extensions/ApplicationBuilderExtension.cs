using IronHook.SqlServer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IronHook.SqlServer.Extensions
{
    /// <summary>
    /// This class includes Application Builder extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Database Migration for SqlServer
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// </param>
        /// <returns>
        /// Application Builder interface
        /// </returns>
        public static IApplicationBuilder UseIronHook(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IronHookSqlServerDbContext>();
                context.Database.Migrate();
            }
            return app;
        }
    }
}
