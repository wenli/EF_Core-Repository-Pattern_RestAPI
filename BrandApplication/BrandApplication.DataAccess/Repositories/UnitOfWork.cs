using BrandApplication.DataAccess.Interfaces;
using BrandApplication.DataAccess.Contexts;
namespace BrandApplication.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BrandDbContext _dbContext;
        private readonly ShiDbContext _shiDbContext;

        public UnitOfWork(BrandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UnitOfWork(ShiDbContext shiDbContext)
        {
            _shiDbContext = shiDbContext;
        }

        public async Task SaveChangesAsync()
        {
            if (_dbContext != null)
            {
                await _dbContext.SaveChangesAsync();
            }
            else if (_shiDbContext != null)
            {
                await _shiDbContext.SaveChangesAsync();
            }
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_dbContext != null)
            {
                return new GenericRepository<T>(_dbContext);
            }
            else if (_shiDbContext != null)
            {
                return new GenericRepository<T>(_shiDbContext);
            }
            else
            {
                throw new InvalidOperationException("No DbContext is available.");
            }
        }
    }
}
