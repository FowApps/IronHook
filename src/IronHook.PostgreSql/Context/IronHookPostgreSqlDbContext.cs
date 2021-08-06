using IronHook.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.PostgreSql.Context
{
    /// <summary>
    /// Iron Hook DbContext for PostgreSql
    /// </summary>
    public class IronHookPostgreSqlDbContext : IronHookCoreDbContext
    {
        public IronHookPostgreSqlDbContext()
        {
        }

        public IronHookPostgreSqlDbContext(DbContextOptions<IronHookPostgreSqlDbContext> options) : base(options)
        {
        }
    }
}
