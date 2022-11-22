using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Infrastructure.Persistence;
using IUnitOfWork = Triton.Sample.Application.Contracts.Persistence.IUnitOfWork;

namespace Triton.Sample.Infrastructure.Repository
{
    public class UnitOfWork : Core.Infrastructure.Repository.UnitOfWork, IUnitOfWork
    {
        private readonly SampleDbContext _context;

        private IDirectorRepository _directorRepository;
        private IVideoRepository _videoRepository;
        private IStreamerRepository _streamerRepository;

        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);
        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);
        public IDirectorRepository DirectorRepository => _directorRepository ??= new DirectorRepository(_context);

        public UnitOfWork(SampleDbContext context) : base(context) 
        {
            _context = context;
            _directorRepository= new DirectorRepository(_context);
            _videoRepository ??=new VideoRepository(_context);
            _streamerRepository ??= new StreamerRepository(_context);
        }
    }
}
