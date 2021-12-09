﻿using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IronHook.EntityFrameworkCore.SqlServer.Extensions
{
    public static class DbContextBuilderExtensions
    {
        public static SqlServerDbContextOptionsBuilder UseIronHookSqlServerMigrations(this SqlServerDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(IronHookCoreDbContextSqlServerFactory).Assembly.FullName);

            return builder;
        }
    }
}
