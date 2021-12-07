using IronHook.EntityFrameworkCore;
using IronHook.EntityFrameworkCore.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.PostgreSql
{
    public class IronHookCoreDbContextFactory : IDesignTimeDbContextFactory<IronHookCoreDbContext>
    {
        public IronHookCoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IronHookCoreDbContext>();

            optionsBuilder.UseNpgsql(opts => opts.UseIronHookNpgsqlMigrations());

            return new IronHookCoreDbContext(optionsBuilder.Options);
        }
    }
}
