using Microsoft.EntityFrameworkCore;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;
using Triton.Sample.Infrastructure.Persistence;

namespace Triton.Sample.Infrastructure.Repository
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(SampleDbContext context) : base(context)
        {
        }
        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            return (await _context.Videos!.Where(o => o.Nombre == nombreVideo).FirstOrDefaultAsync())!;
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
