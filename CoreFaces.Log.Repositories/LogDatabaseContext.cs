using CoreFaces.Log.Models.Domain;
using CoreFaces.Log.Models.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFaces.Log.Repositories
{
    public class LogDatabaseContext : DbContext
    {
        public LogDatabaseContext(DbContextOptions<LogDatabaseContext> options) : base(options)
        {
            //bool status = this.Database.EnsureDeleted();
            //IExecutionStrategy dd = this.Database.CreateExecutionStrategy();
            //bool test = this.Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new LogMap(modelBuilder.Entity<Log.Models.Domain.Log>());
            new LogCategoryMap(modelBuilder.Entity<Log.Models.Domain.LogCategory>());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var changeSet = ChangeTracker.Entries<EntityBase>();
            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.CreateDate = DateTime.Now;
                    }
                    entry.Entity.UpdateDate = DateTime.Now;
                }
            }
        }
    }


}
