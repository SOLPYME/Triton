using Triton.Core.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Contracts.Persistence
{
    public interface IStreamerRepository : IAsyncRepository<Streamer>
    { }
}
