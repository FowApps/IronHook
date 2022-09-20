using IronHook.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace IronHook.EntityFrameworkCore.PostgreSql.Extensions
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
