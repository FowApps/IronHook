using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace IronHook.EntityFrameworkCore.SqlServer
{
    public class IronHookCoreDbContextSqlServerFactory : IDesignTimeDbContextFactory<IronHookCoreDbContext>
    {
        public IronHookCoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IronHookCoreDbContext>();

            optionsBuilder.UseSqlServer(opts => opts.UseIronHookSqlServerMigrations());

            return new IronHookCoreDbContext(optionsBuilder.Options);
        }
    }
}
