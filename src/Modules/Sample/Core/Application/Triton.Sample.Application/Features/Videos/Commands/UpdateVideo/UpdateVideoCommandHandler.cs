using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Features.Videos.Commands.UpdateVideo
{
    public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, int>
    {
        private readonly ILogger<UpdateVideoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVideoCommandHandler(ILogger<UpdateVideoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Video>(request);

            _unitOfWork.Repository<Video>().AddEntity(directorEntity);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del video");
                throw new Exception("No se pudo insertar el record del video");
            }
            return directorEntity.Id;
        }
    }
}
