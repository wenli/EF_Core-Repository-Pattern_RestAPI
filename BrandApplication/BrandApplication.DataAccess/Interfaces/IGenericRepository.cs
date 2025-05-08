
using System.Linq.Expressions;
namespace BrandApplication.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task<T?> ReadAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> ReadsAsync(); // �`�N�o�̦^�� IQueryable�A��ڸ��Ū���ɦA�ϥ� ToListAsync ���D�P�B��k
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
