using Triton.Core.Domain.Common;

namespace Triton.Core.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
