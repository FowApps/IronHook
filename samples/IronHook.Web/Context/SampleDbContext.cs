using IronHook.Web.Entities;
using IronHook.Web.Generators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronHook.Web.Context
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected SampleDbContext()
        {
        }

        #region Tables
        public virtual DbSet<Customer> Customers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(ix => new { ix.Name, ix.Surname, ix.Phone, ix.CreateDate, ix.UpdateDate });

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.CreateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.UpdateDate)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAddOrUpdate();
            });
        }

    }
}
