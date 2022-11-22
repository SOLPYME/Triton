using AutoMapper;
using MediatR;
using Triton.Sample.Application.Contracts.Persistence;

namespace Triton.Sample.Application.Features.Directors.Queries.GetDirectorsList
{
    public class GetDirectorsListQueryHandler : IRequestHandler<GetDirectorsListQuery, List<DirectorVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public GetDirectorsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DirectorVM>> Handle(GetDirectorsListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.VideoRepository.GetVideoByUsername(request._Username);

            return _mapper.Map<List<DirectorVM>>(videoList);
        }
    }
}