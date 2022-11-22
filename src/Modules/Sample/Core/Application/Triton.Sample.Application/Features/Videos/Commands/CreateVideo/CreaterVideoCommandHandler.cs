using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Application.Features.Directors.Commands.CreateDirector;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Features.Videos.Commands.CreateVideo
{
    public class CreaterVideoCommandHandler : IRequestHandler<CreateVideoCommand, int>
    {
        private readonly ILogger<CreaterVideoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreaterVideoCommandHandler(ILogger<CreaterVideoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var dvideoEntity = _mapper.Map<Video>(request);

            _unitOfWork.Repository<Video>().AddEntity(dvideoEntity);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del video");
                throw new Exception("No se pudo insertar el record del video");
            }
            return dvideoEntity.Id;
        }
    }
}
