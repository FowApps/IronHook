using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.SqlServer.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<IronHookSqlServerDbContext>
    {
        public IronHookSqlServerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IronHookSqlServerDbContext>();
            optionsBuilder.UseSqlServer("{YOUR_CONNECTION_STRING}");
            return new IronHookSqlServerDbContext(optionsBuilder.Options);
        }
    }
}
