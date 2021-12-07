using IronHook.Core.Abstractions;
using IronHook.Core.Entities;
using IronHook.EntityFrameworkCore.Generators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.EntityFrameworkCore
{
    public class IronHookCoreDbContext : DbContext, IIronHookContext
    {
        protected IronHookCoreDbContext()
        {
        }

        public IronHookCoreDbContext(DbContextOptions<IronHookCoreDbContext> options) : base(options)
        {
        }

        #region Tables
        public virtual DbSet<Hook> Hooks { get; set; }

        public virtual DbSet<HookRequest> HookRequests { get; set; }

        public virtual DbSet<HookLog> HookLogs { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hook>(entity =>
            {
                entity
                    .ToTable(nameof(Hooks), "iron-hook");

                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(ix => new { ix.TenantId, ix.Name, ix.Key });

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.CreateDate)
                    .HasValueGenerator<DateTimeGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.UpdateDate)
                    .HasValueGenerator<DateTimeGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Key)
                    .IsRequired();

                entity
                    .Property(p => p.Name)
                    .IsRequired();

                entity
                    .HasMany(m => m.HookRequests).WithOne(o => o.Hook).HasForeignKey(fk => fk.HookId);
            });

            modelBuilder.Entity<HookRequest>(entity =>
            {
                entity
                    .ToTable(nameof(HookRequests), "iron-hook");

                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(ix => ix.HookId);

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.CreateDate)
                    .HasValueGenerator<DateTimeGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.UpdateDate)
                    .HasValueGenerator<DateTimeGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Url)
                    .IsRequired();

                entity
                    .Property(p => p.Method)
                    .IsRequired();

                entity
                    .HasOne(o => o.Hook).WithMany(m => m.HookRequests).HasForeignKey(fk => fk.HookId);

                entity
                    .HasMany(m => m.HookLogs).WithOne(o => o.HookRequest).HasForeignKey(fk => fk.RequestId);
            });

            modelBuilder.Entity<HookLog>(entity =>
            {
                entity
                    .ToTable(nameof(HookLogs), "iron-hook");

                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(ix => new { ix.RequestId });

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .HasOne(o => o.HookRequest).WithMany(m => m.HookLogs).HasForeignKey(fk => fk.RequestId);

            });
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }

        public virtual async Task<T> InsertAsync<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Added;
            await SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
            await SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task DeleteAsync<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            await SaveChangesAsync();
        }
    }
}
