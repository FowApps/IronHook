using IronHook.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbContextBuilderExtensions
    {
        public static NpgsqlDbContextOptionsBuilder UseIronHookNpgsqlMigrations(this NpgsqlDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(IronHookCoreDbContextPostgreSqlFactory).Assembly.FullName);

            return builder;
        }
    }
}
