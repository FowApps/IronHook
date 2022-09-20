using IronHook.EntityFrameworkCore;
using IronHook.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IronHook.EntityFrameworkCore.SqlServer.Extensions
{
    public static class SqlServerDbContextOptionsBuilderExtensions
    {
        public static SqlServerDbContextOptionsBuilder UseIronHookSqlServerMigrations(this SqlServerDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(IronHookCoreDbContextSqlServerFactory).Assembly.FullName);

            builder.MigrationsHistoryTable(IronHookConsts.MigrationHistoryTableName, IronHookConsts.DatabaseScheme);

            return builder;
        }
    }
}
