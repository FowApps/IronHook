using IronHook.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace IronHook.PostgreSql
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
