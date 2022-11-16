using System.Collections;
using Triton.Core.Application.Contracts.Persistence;
using Triton.Core.Domain.Common;
using Triton.Core.Infrastructure.Persistence;

namespace Triton.Core.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly TritonDbContext _context;

        public TritonDbContext SampleDbContext => _context;

        public UnitOfWork(TritonDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message} in {ex.Source}.");
            }
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
