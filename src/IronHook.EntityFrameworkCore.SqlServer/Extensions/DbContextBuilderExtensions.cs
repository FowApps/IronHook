using IronHook.EntityFrameworkCore;
using IronHook.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbContextBuilderExtensions
    {
        public static SqlServerDbContextOptionsBuilder UseIronHookSqlServerMigrations(this SqlServerDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(IronHookCoreDbContextSqlServerFactory).Assembly.FullName);

            builder.MigrationsHistoryTable(IronHookConsts.MigrationHistoryTableName, IronHookConsts.DatabaseScheme);

            return builder;
        }
    }
}
