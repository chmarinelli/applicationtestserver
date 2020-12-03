using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TestServer.Core;
using TestServer.Core.Extensions;
using TestServer.DM.Entities;

namespace TestServer.DM.Context
{
    public class TestServerContext : DbContext
    {
        public TestServerContext(DbContextOptions<TestServerContext> options) : base(options)
        {

        }

        public DbSet<PermitType> PermitsTypes { get; set; }
        public DbSet<Permit> Permits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var type in modelBuilder.Model.GetEntityTypes()
                                .Where(type => typeof(IEntityAuditableBase).IsAssignableFrom(type.ClrType)))
                modelBuilder.SetSoftDeleteFilter(type.ClrType);
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
        private void AuditableEntities()
        {
            foreach (EntityEntry<IEntityAuditableBase> entry in ChangeTracker.Entries<IEntityAuditableBase>())
            {
                if (entry.State == EntityState.Added) entry.Entity.CreatedAt = DateTime.Now;
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedAt = DateTime.Now;
                    Entry(entry.Entity).Property(x => x.CreatedAt).IsModified = false;
                }
            }
        }
        public override int SaveChanges()
        {
            this.AuditableEntities();

            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.AuditableEntities();

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
