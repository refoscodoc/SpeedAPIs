using System;
using System.Linq;
using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.DataAccessSqliteProvider
{
    public class DomainModelSQLiteContext : DbContext
    {
        public DomainModelSQLiteContext(DbContextOptions<DomainModelSQLiteContext> options) : base(options)
        { }

        public DbSet<GuitarModel> DataEventRecords { get; set; }

        // public DbSet<SourceInfo> SourceInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GuitarModel>().HasKey(m => m.Id);

            // shadow properties
            // builder.Entity<GuitarModel>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<GuitarModel>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}