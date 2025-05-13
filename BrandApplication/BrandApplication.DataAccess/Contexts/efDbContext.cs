using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using BrandApplication.DataAccess.Repositories;

namespace BrandApplication.DataAccess.Contexts
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        bool ChangeTrackerAutoDetectChangesEnabled { get; set; }
        IModel Model { get; }
        ChangeTracker ChangeTracker { get; }
    }

    public class efDbContext : DbContext, IDbContext
    {
        public efDbContext(DbContextOptions<efDbContext> options) : base(options)
        {
        }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        // Implement missing members from IDbContext
        public override DatabaseFacade Database => base.Database;
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);
        public bool ChangeTrackerAutoDetectChangesEnabled { get => base.ChangeTracker.AutoDetectChangesEnabled; set => base.ChangeTracker.AutoDetectChangesEnabled = value; }
        public override IModel Model => base.Model;
        public override ChangeTracker ChangeTracker => base.ChangeTracker;
    }

}