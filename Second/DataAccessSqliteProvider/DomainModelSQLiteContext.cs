using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Second.Models;
using Second.ViewModels;

namespace Second.DataAccessSqliteProvider
{
    public class DomainModelSqliteContext : DbContext
    {
        public DomainModelSqliteContext(DbContextOptions<DomainModelSqliteContext> options) : base(options)
        { }

        public DbSet<HorseModel> Horses { get; set; }

        public DbSet<HorseViewModel> HorsesViewmodels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HorseModel>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<HorseModel>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedHorse").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}