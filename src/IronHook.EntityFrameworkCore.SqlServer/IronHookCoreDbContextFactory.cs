using IronHook.EntityFrameworkCore.SqlServer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IronHook.EntityFrameworkCore.SqlServer
{
    public class IronHookCoreDbContextFactory : IDesignTimeDbContextFactory<IronHookCoreDbContext>
    {
        public IronHookCoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IronHookCoreDbContext>();

            optionsBuilder.UseSqlServer(opts => opts.UseIronHookSqlServerMigrations());

            return new IronHookCoreDbContext(optionsBuilder.Options);
        }
    }
}
