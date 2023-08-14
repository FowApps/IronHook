using IronHook.EntityFrameworkCore;
using IronHook.EntityFrameworkCore.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IronHook.EntityFrameworkCore.PostgreSql
{
    public class IronHookCoreDbContextPostgreSqlFactory : IDesignTimeDbContextFactory<IronHookCoreDbContext>
    {
        public IronHookCoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IronHookCoreDbContext>();

            optionsBuilder.UseNpgsql(opts => opts.UseIronHookNpgsqlMigrations());

            return new IronHookCoreDbContext(optionsBuilder.Options);
        }
    }
}
