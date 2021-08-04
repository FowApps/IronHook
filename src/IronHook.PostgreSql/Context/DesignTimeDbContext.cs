using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.PostgreSql.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<IronHookPostgreSqlDbContext>
    {
        public IronHookPostgreSqlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IronHookPostgreSqlDbContext>();
            optionsBuilder.UseNpgsql("xxxx");
            return new IronHookPostgreSqlDbContext(optionsBuilder.Options);
        }
    }
}
