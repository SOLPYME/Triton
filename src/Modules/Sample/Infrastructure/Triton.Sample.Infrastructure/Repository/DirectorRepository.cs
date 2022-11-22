using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;
using Triton.Sample.Infrastructure.Persistence;

namespace Triton.Sample.Infrastructure.Repository
{
    public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
    {
        public DirectorRepository(SampleDbContext context) : base(context)
        { }
    }
}
