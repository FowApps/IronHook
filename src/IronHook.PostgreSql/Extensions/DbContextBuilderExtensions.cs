using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace IronHook.PostgreSql.Extensions
{
    public static class DbContextBuilderExtensions
    {
        public static NpgsqlDbContextOptionsBuilder UseIronHookNpgsqlMigrations(this NpgsqlDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(IronHookCoreDbContextFactory).Assembly.FullName);

            return builder;
        }
    }
}
