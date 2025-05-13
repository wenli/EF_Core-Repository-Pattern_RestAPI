using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using BrandApplication.DataAccess.Repositories; 
using BrandApplication.DataAccess.Interfaces;
using BrandApplication.DataAccess.Contexts; 




namespace BrandApplication.DataAccess.Repositories
{

    /// <summary>
    /// ��@ Entity Framework Unit Of Work �����O�C
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed = false;
        private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();

        /// <summary>
        /// �]�w�� Unit of work (UOF) �� Context�C
        /// </summary>
        /// <param name="context">�]�w UOF �� context�C</param>
        /// <exception cref="ArgumentNullException">�� context �� null �ɩߥX�ҥ~�C</exception>
        public EFUnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// �x�s�Ҧ����ʡC
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// ���B�x�s�Ҧ����ʡC
        /// </summary>
        /// <returns>���ܫD�P�B�x�s�@�~�� Task�C</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// �M���� Class ���귽�C
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// �M���� Class ���귽�C
        /// </summary>
        /// <param name="disposing">�O�_�b�M�z���H</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// ���o�Y�@�� Entity �� Repository�C
        /// �p�G�S�����L�A�|��l�Ƥ@�ӡF�p�G�����ܡA�h���o���e��l�ƪ����ӡC
        /// </summary>
        /// <typeparam name="T">�� Context �̭��� Entity Type�C</typeparam>
        /// <returns>Entity �� Repository�C</returns>
        public IRepository<T> Repository<T>() where T : class
        {
            var typeName = typeof(T).FullName;

            if (!_repositories.ContainsKey(typeName!)) // Add ! to assure typeName is not null
            {
                var repositoryType = typeof(EFGenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(typeName!, repositoryInstance!); // Add ! to assure typeName and repositoryInstance are not null
            }

            return (IRepository<T>)_repositories[typeName!]; // Add ! to assure typeName is not null
        }
    }
}