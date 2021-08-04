using IronHook.PostgreSql.Context;
using Microsoft.AspNetCore.Builder;
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
        public static IApplicationBuilder UseIronHook(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IronHookPostgreSqlDbContext>().Database.Migrate();
            return app;
        }
    }
}
