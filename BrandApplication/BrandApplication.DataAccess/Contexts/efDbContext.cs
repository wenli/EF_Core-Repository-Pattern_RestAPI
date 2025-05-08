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

    public class YourDbContext : DbContext, IDbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        // 实现 IDbContext 接口的属性
        public bool ChangeTrackerAutoDetectChangesEnabled
        {
            get => ChangeTracker.AutoDetectChangesEnabled;
            set => ChangeTracker.AutoDetectChangesEnabled = value;
        }

        public IModel Model => base.Model;
    }

}