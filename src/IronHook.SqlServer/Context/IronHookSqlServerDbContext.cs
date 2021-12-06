using IronHook.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.SqlServer.Context
{
    /// <summary>
    /// Iron Hook Sql Server DbContext
    /// </summary>
    public class IronHookSqlServerDbContext : IronHookCoreDbContext
    {
        public IronHookSqlServerDbContext()
        {
        }

        public IronHookSqlServerDbContext(DbContextOptions<IronHookSqlServerDbContext> options) : base(options)
        {
        }
    }
}
