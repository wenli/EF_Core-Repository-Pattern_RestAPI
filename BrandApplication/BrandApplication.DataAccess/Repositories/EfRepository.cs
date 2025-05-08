using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using BrandApplication.DataAccess.Interfaces;
using BrandApplication.DataAccess.Contexts;
using BrandApplication.DataAccess.Models;
using System.Collections.Generic;

namespace BrandApplication.DataAccess.Repositories
{


    public class EFGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext Context { get; set; }

        public EFGenericRepository(DbContext inContext)
        {
            Context = inContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity?> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> ReadsAsync()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (updateProperties != null)
            {
                foreach (var property in updateProperties)
                {
                    var propertyName = ((MemberExpression)property.Body).Member.Name;
                    Context.Entry<TEntity>(entity).Property(propertyName).IsModified = true;
                }
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}