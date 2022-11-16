using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;
using Triton.Sample.Infrastructure.Persistence;

namespace Triton.Sample.Infrastructure.Repository
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(SampleDbContext context) : base(context)
        { }
    }
}
