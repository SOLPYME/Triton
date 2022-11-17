using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Infrastructure.Persistence;
using IUnitOfWork = Triton.Sample.Application.Contracts.Persistence.IUnitOfWork;

namespace Triton.Sample.Infrastructure.Repository
{
    public class UnitOfWork : Core.Infrastructure.Repository.UnitOfWork, IUnitOfWork
    {
        //private Hashtable _repositories;
        private readonly SampleDbContext _context;
        private IVideoRepository _videoRepository;
        private IStreamerRepository _streamerRepository;

        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);
        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);
        //public SampleDbContext SampleDbContext => _context;

        public UnitOfWork(SampleDbContext context) : base(context) 
        {
            _context = context;
            //_repositories = new Hashtable();
            _videoRepository ??=new VideoRepository(_context);
            _streamerRepository ??= new StreamerRepository(_context);
        }

        //public async Task<int> Complete()
        //{
        //    try
        //    {
        //        return await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error {ex.Message} in {ex.Source}.");
        //    }
        //}
        //public void Dispose()
        //{
        //    _context.Dispose();
        //    GC.SuppressFinalize(this);
        //}
        //public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        //{
        //    _repositories ??= new Hashtable();
        //    var type = typeof(TEntity).Name;
        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(RepositoryBase<>);
        //        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        //        _repositories.Add(type, repositoryInstance);
        //    }
        //    return (IAsyncRepository<TEntity>)_repositories[type]!;
        //}
    }
}
