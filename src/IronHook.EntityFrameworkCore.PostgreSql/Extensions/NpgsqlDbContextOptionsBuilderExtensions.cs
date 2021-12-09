using IronHook.EntityFrameworkCore;
using IronHook.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NpgsqlDbContextOptionsBuilderExtensions
    {
        public static NpgsqlDbContextOptionsBuilder UseIronHookNpgsqlMigrations(this NpgsqlDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(IronHookCoreDbContextPostgreSqlFactory).Assembly.FullName);

            builder.MigrationsHistoryTable(IronHookConsts.MigrationHistoryTableName, IronHookConsts.DatabaseScheme);

            return builder;
        }
    }
}
