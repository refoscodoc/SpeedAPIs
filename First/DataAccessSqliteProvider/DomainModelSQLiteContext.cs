using System;
using System.Linq;
using First.Models;
using First.Services;
using Microsoft.EntityFrameworkCore;

namespace First.DataAccessSqliteProvider
{
    public class DomainModelSqliteContext : DbContext
    {
        public DomainModelSqliteContext(DbContextOptions<DomainModelSqliteContext> options) : base(options)
        { }

        public DbSet<GuitarModel> Guitars { get; set; }

        // public DbSet<SourceInfo> SourceInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GuitarModel>().HasKey(m => m.Id);

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