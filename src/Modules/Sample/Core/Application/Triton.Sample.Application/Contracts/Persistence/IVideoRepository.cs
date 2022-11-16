using Triton.Core.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
